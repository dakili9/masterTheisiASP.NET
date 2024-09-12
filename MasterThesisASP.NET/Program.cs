using MasterThesisASP.NET;
using MasterThesisASP.NET.AuthorizationHandlers;
using MasterThesisASP.NET.Data;
using MasterThesisASP.NET.IdentityEnhancemets;
using MasterThesisASP.NET.Models;
using MasterThesisASP.NET.Validators.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
.AddClaimsPrincipalFactory<AppClaimsFactory>()
.AddApiEndpoints();

builder.Services.AddTransient<IAuthorizationHandler, TaskAuthorizationHandler>();
builder.Services.AddTransient<IAuthorizationHandler, UserAuthorizationHandler>();
builder.Services.AddTransient<IAuthorizationHandler, CategoryAuthorizationHandler>();


builder.Services.AddControllers();

/*todo uncomment*/
//for adding fluent validation
//builder.Services.AddValidatorsFromAssemblyContaining<UpdateTaskRequestDtoValidator>();

/*for exception handlers*/
builder.Services.AddExceptionHandlers();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapIdentityApi<User>();   

app.MapControllers();

/*for exception handlers*/
app.UseExceptionHandler();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); 

app.MapPost("/logout", async (SignInManager<User> signInManager) =>
{
	await signInManager.SignOutAsync().ConfigureAwait(false);
});


app.Run();
