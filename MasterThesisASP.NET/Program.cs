using FluentValidation;
using FluentValidation.AspNetCore;
using MasterThesisASP.NET;
using MasterThesisASP.NET.Data;
using MasterThesisASP.NET.Models;
using MasterThesisASP.NET.Validators.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddEndpointsApiExplorer();



var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>( options =>{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddServiceDependencies();

builder.Services.AddAuthentication()
.AddCookie(IdentityConstants.ApplicationScheme)
.AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorization();

builder.Services.AddIdentityCore<User>()
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddApiEndpoints();

builder.Services.AddControllers();

/*todo uncomment*/
//builder.Services.AddValidatorsFromAssemblyContaining<UpdateTaskRequestDtoValidator>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapIdentityApi<User>();    

app.MapPost("/logout", async (SignInManager<User> signInManager) =>
{
	await signInManager.SignOutAsync().ConfigureAwait(false);
});

app.MapControllers();

app.Run();
