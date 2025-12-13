# Wakes Autocare - Website Application

Professional automotive services website for Wakes Autocare, featuring SEO-optimized pages for local search rankings across the South Coast.

## Quick Start

### Prerequisites
- .NET 8 SDK
- SQL Server or SQL Server LocalDB
- Visual Studio 2022 or VS Code

### Initial Setup

1. **Clone and Navigate**
   ```bash
   cd WakesAutocare.Web
   ```

2. **Database Setup**
   ```bash
   # Create initial migration (if not exists)
   dotnet ef migrations add InitialCreate

   # Apply migrations and seed database
   dotnet ef database update
   ```

3. **Run Application**
   ```bash
   dotnet run
   ```

4. **Access Site**
   - Local: https://localhost:5001
   - Sitemap: https://localhost:5001/sitemap.xml

## Project Structure

```
WakesAutocare.Web/
├── Controllers/         # MVC Controllers
│   ├── HomeController.cs
│   ├── ServiceController.cs
│   ├── LocationController.cs
│   ├── CaseStudyController.cs
│   └── SitemapController.cs
├── Data/               # Database Context & Seeders
│   ├── AppDbContext.cs
│   ├── ServiceLocationPageSeeder.cs
│   ├── ContentSnippetSeeder.cs
│   ├── CaseStudySeeder.cs
│   └── DatabaseCleaner.cs
├── Models/             # Entity Models
│   ├── Service.cs
│   ├── Location.cs
│   ├── ServiceLocationPage.cs
│   ├── CaseStudy.cs
│   ├── ContentSnippet.cs
│   └── ContactMessage.cs
├── Services/           # Business Logic
│   ├── SeoService.cs
│   ├── ContentService.cs
│   └── EmailService.cs
├── Views/              # Razor Views
│   ├── Home/
│   ├── Service/
│   ├── Location/
│   ├── CaseStudy/
│   └── Shared/
└── wwwroot/           # Static Files
    ├── css/
    ├── js/
    ├── images/
    └── robots.txt
```

## Key Features

### SEO Optimization
- **80+ Optimized Pages**: 8 services × 10 locations
- **XML Sitemap**: Auto-generated from database
- **JSON-LD Structured Data**: LocalBusiness schema
- **Unique Meta Tags**: Title & description per page
- **Canonical URLs**: Prevent duplicate content
- **robots.txt**: Search engine directives

### Content Management
- **Dynamic Content Snippets**: 18 reusable content blocks
- **Case Studies**: 6 featured projects with image galleries
- **Service Pages**: Individual landing pages per service
- **Location Pages**: Area-specific content
- **Combined Pages**: Service + Location combinations

### Contact Form
- Form submissions saved to ContactMessages table
- Email integration ready (configure SMTP or use database-only)
- IP address tracking
- Success/error messaging

## Database Seeding

The application automatically seeds the database on startup with:
- **8 Services**: Diagnostics, Servicing, Clutch, Timing Belt, Repairs, Mobile, MOT, Inspections
- **10 Locations**: Portsmouth, Waterlooville, Fareham, Havant, Gosport, Southsea, Emsworth, Hayling Island, Southampton, Chichester
- **80 ServiceLocationPages**: All service/location combinations
- **18 Content Snippets**: Reusable content blocks
- **6 Case Studies**: Real work examples with images

## Configuration

### appsettings.json

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=WakesAutocare;..."
  },
  "SiteSettings": {
    "BusinessName": "Wakes Autocare",
    "Phone": "07544 064878",
    "Email": "Wakesautocare@gmail.com"
  }
}
```

### Email Setup (Optional)

Add to appsettings.json for SMTP email:
```json
"EmailSettings": {
  "SmtpHost": "smtp.gmail.com",
  "SmtpPort": 587,
  "SmtpUsername": "your-email@gmail.com",
  "SmtpPassword": "your-app-password"
}
```

Then update `EmailService.cs` to implement actual email sending.

## Routes

| Route Pattern | Example | Description |
|--------------|---------|-------------|
| `/` | Home page | Business overview |
| `/about` | About page | Company info |
| `/contact` | Contact page | Contact form |
| `/services/{slug}` | `/services/diagnostics` | Service landing page |
| `/locations/{slug}` | `/locations/portsmouth` | Location page |
| `/services/{service}/{location}` | `/services/diagnostics/portsmouth` | SEO-optimized combination |
| `/case-studies/{slug}` | `/case-studies/wet-belt-replacement` | Case study detail |
| `/sitemap.xml` | XML sitemap | For search engines |

## Design & Branding

- **Primary Color**: Portsmouth FC Blue (#0033A0)
- **Accent Color**: Gold (#f39c12)
- **Typography**: System font stack (responsive)
- **Layout**: Mobile-first responsive design
- **Icons**: Font Awesome 6.4.0

## Pre-Production Checklist

Before deploying to production:

1. **Create Favicon Files**
   - Generate from logo with Portsmouth FC blue background
   - Add to `/wwwroot/`: favicon.ico, favicon-32x32.png, favicon-16x16.png, apple-touch-icon.png

2. **Configure Email**
   - Set up SMTP or email service API
   - Update EmailService.cs implementation

3. **Domain Setup**
   - Update robots.txt sitemap URL
   - Configure canonical URLs
   - Set up SSL certificate

4. **Google Services**
   - Google Search Console
   - Submit sitemap
   - Google Analytics (optional)
   - Google My Business

5. **Content Review**
   - Review all 80 pages for uniqueness
   - Add more case studies
   - Optimize images

## Development

### Database Migrations

```bash
# Add new migration
dotnet ef migrations add MigrationName

# Update database
dotnet ef database update

# Remove last migration
dotnet ef migrations remove
```

### Running with Watch

```bash
dotnet watch run
```
Auto-reloads on file changes (Razor Runtime Compilation enabled).

### View Contact Messages

Contact form submissions are stored in the `ContactMessages` table. Query directly or build an admin panel.

## SEO Best Practices Implemented

✅ Server-side rendering (MVC)
✅ Unique titles & descriptions
✅ Canonical URLs
✅ Schema.org LocalBusiness
✅ XML sitemap
✅ robots.txt
✅ Mobile-first responsive
✅ Fast page loads
✅ Social media integration
✅ Open Graph tags

## Support

For questions about implementation or architecture, refer to:
- **PROJECT-BRIEF.md** - Full project documentation
- **Answer.txt** - Original architecture recommendation

## License

Private project for Wakes Autocare Ltd.

---

**Built with ASP.NET Core 8 MVC** | **Optimized for Local SEO** | **Portsmouth & South Coast**
