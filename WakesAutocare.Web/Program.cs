using Microsoft.EntityFrameworkCore;
using WakesAutocare.Web.Data;
using WakesAutocare.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation(); // Enable runtime compilation for development

builder.Services.AddHttpContextAccessor();

// Configure Entity Framework with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()
    )
);

// Register custom services
builder.Services.AddScoped<ISeoService, SeoService>();
builder.Services.AddScoped<IContentService, ContentService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// SEO-friendly route for service + location pages
app.MapControllerRoute(
    name: "serviceLocation",
    pattern: "services/{serviceSlug}/{locationSlug}",
    defaults: new { controller = "Service", action = "Location" });

// Service landing pages
app.MapControllerRoute(
    name: "service",
    pattern: "services/{serviceSlug}",
    defaults: new { controller = "Service", action = "Index" });

// Location landing pages
app.MapControllerRoute(
    name: "location",
    pattern: "locations/{locationSlug}",
    defaults: new { controller = "Location", action = "Index" });

// Case study pages
app.MapControllerRoute(
    name: "caseStudy",
    pattern: "case-studies/{slug}",
    defaults: new { controller = "CaseStudy", action = "Details" });

// Sitemap
app.MapControllerRoute(
    name: "sitemap",
    pattern: "sitemap.xml",
    defaults: new { controller = "Sitemap", action = "Index" });

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
