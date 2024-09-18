using FluentValidation;
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
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

/*todo uncomment*/
//for adding fluent validation

//builder.Services.AddValidatorsFromAssemblyContaining<UpdateTaskRequestDtoValidator>();

builder.Services.AddTransient<IAuthorizationHandler, TaskAuthorizationHandler>();
builder.Services.AddTransient<IAuthorizationHandler, UserAuthorizationHandler>();
builder.Services.AddTransient<IAuthorizationHandler, CategoryAuthorizationHandler>();


builder.Services.AddControllers();

builder.Services.AddExceptionHandlers();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapIdentityApi<User>();   

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*for exception handlers*/
app.UseExceptionHandler();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); 

app.MapPost("/logout", async (SignInManager<User> signInManager) =>
{
	await signInManager.SignOutAsync().ConfigureAwait(false);
});


app.Run();
