using Infrastructure.Persitence;
using AgendaMedica.Core.Application;
using Agencita.Presentation.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(option =>
{
    option.Filters.Add<ValidateUserSession>();
});

builder.Services.AddSession( options =>
{
    options.IdleTimeout = TimeSpan.FromDays(1);
});

builder.Services.AddAuthorization();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddPersistenceService(builder.Configuration);
builder.Services.AddApplicationLayer();
builder.Services.AddTransient<ValidateUserSession>();


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
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
