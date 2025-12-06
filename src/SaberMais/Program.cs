using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using SaberMais.Authorization;
using SaberMais.Autorizacao;
using SaberMais.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.AccessDeniedPath = "/Home/Index";
        options.LoginPath = "/Usuarios/Login/";
    });
    
builder.Services.AddScoped<IAuthorizationHandler, ManipuladorAutorizacaoDonoDaConta>();
builder.Services.AddScoped<IAuthorizationHandler, ManipuladorAutorizacaoDonoDoCurso>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("DonoDoCurso", policy =>
        policy.Requirements.Add(new RequisitoDonoDoCurso()));

    options.AddPolicy("EhDonoDaConta", policy =>
        policy.AddRequirements(new RequisitoDeveSerDonoDaConta()));
});


builder.Services.Configure<IISServerOptions>(options => 
{
    options.AutomaticAuthentication = false;
});


var app = builder.Build(); 

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();