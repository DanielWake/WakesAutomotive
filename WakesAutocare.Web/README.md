# Wakes Autocare - ASP.NET Core MVC Web Application

Professional automotive services website for Wakes Autocare, optimized for local SEO across the South Coast.

## Project Overview

This is an ASP.NET Core 8 MVC application designed to provide a strong web presence for Wakes Autocare with a focus on local SEO optimization. The application enables the business to rank highly for location-based automotive service searches (e.g., "car servicing in Portsmouth", "Portsmouth mechanic").

## Technology Stack

- **Framework:** ASP.NET Core 8 MVC
- **Database:** SQL Server with Entity Framework Core
- **Language:** C# 12
- **Frontend:** Razor Views, HTML5, CSS3, JavaScript
- **SEO:** Server-side rendering, JSON-LD structured data, XML sitemaps

## Features

### Public-Facing Features
- Homepage with business overview and featured services
- Service pages for each automotive service
- Location landing pages for targeted areas
- Dynamic service + location combination pages (e.g., `/services/diagnostics/portsmouth`)
- Case studies showcase
- Contact form
- About us page
- XML sitemap generation (`/sitemap.xml`)
- Robots.txt for search engines

### SEO Features
- Unique meta titles and descriptions for each page
- Canonical URL management
- JSON-LD LocalBusiness structured data on all location pages
- Breadcrumb structured data
- Server-side rendering for optimal crawlability
- Mobile-responsive design
- Sitemap auto-generation from database

### Planned Features
- Admin area for content management
- Content snippet system for scaling unique content
- Database seeding from existing case studies
- Email functionality for contact form
- Image optimization and lazy loading

## Project Structure

```
WakesAutocare.Web/
├── Controllers/           # MVC Controllers
│   ├── HomeController.cs
│   ├── ServiceController.cs
│   ├── LocationController.cs
│   ├── CaseStudyController.cs
│   └── SitemapController.cs
├── Models/               # Entity models
│   ├── Service.cs
│   ├── Location.cs
│   ├── ServiceLocationPage.cs
│   ├── CaseStudy.cs
│   └── ContentSnippet.cs
├── Data/                 # Database context
│   └── AppDbContext.cs
├── Services/             # Business logic services
│   ├── ISeoService.cs
│   ├── SeoService.cs
│   ├── IContentService.cs
│   └── ContentService.cs
├── Views/                # Razor views
│   ├── Home/
│   ├── Service/
│   ├── Location/
│   ├── CaseStudy/
│   └── Shared/
├── wwwroot/              # Static files
│   ├── css/
│   ├── js/
│   └── images/
└── Areas/                # Admin area (planned)
```

## Getting Started

### Prerequisites

- .NET 8 SDK
- SQL Server or SQL Server Express
- Visual Studio 2022 or VS Code (optional)

### Installation

1. **Clone or open the project**
   ```bash
   cd WakesAutocare.Web
   ```

2. **Update connection string**

   Edit `appsettings.json` and update the connection string to match your SQL Server instance:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=WakesAutocare;Trusted_Connection=True;"
   }
   ```

3. **Create database and apply migrations**
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Access the application**

   Navigate to `https://localhost:5001` or the URL shown in the terminal

## Database Schema

### Core Entities

**Service** - Automotive services offered
- Id, Slug, Title, Summary, Description, Icon, DisplayOrder, IsActive

**Location** - Service areas and towns
- Id, Slug, Name, County, PostcodePrefix, Latitude, Longitude, IsActive

**ServiceLocationPage** - SEO-optimized pages for service+location combinations
- Id, ServiceId, LocationId, TitleTag, MetaDescription, H1, BodyHtml, CanonicalUrl, IsPublished

**CaseStudy** - Portfolio of work completed
- Id, Slug, Title, Summary, Content, ServiceId, Images, IsFeatured, IsPublished

**ContentSnippet** - Reusable content blocks
- Id, Name, Type, Content, ServiceId, LocationId, IsActive

## SEO Strategy

### URL Structure
- Services: `/services/{service-slug}`
- Locations: `/locations/{location-slug}`
- Service + Location: `/services/{service-slug}/{location-slug}`
- Case Studies: `/case-studies/{slug}`

### Meta Tag Management
All pages have unique:
- Title tags (max 60 chars)
- Meta descriptions (max 160 chars)
- Canonical URLs
- Open Graph tags

### Structured Data
- LocalBusiness JSON-LD on all service+location pages
- Breadcrumb JSON-LD for navigation
- Proper schema.org markup

## Initial Data

The database is seeded with:

**Services:**
- Diagnostics
- Car Servicing
- Clutch Replacement
- Timing Belt Replacement
- Vehicle Repairs
- Mobile Mechanic
- MOT Testing
- Pre-Purchase Inspection

**Locations (South Coast):**
- Portsmouth
- Waterlooville
- Fareham
- Havant
- Gosport
- Southsea
- Emsworth
- Hayling Island
- Southampton
- Chichester

## Development Workflow

### Adding a New Service
1. Add entry to Services table via admin (or manually)
2. Pages automatically generated for all locations
3. Update service description and content
4. Publish pages

### Adding a New Location
1. Add entry to Locations table
2. Pages automatically generated for all services
3. Add location-specific content snippets
4. Publish pages

### Creating Custom Content
1. Navigate to ServiceLocationPages in admin
2. Select service + location combination
3. Add custom H1, meta tags, and body content
4. Or use content snippets for programmatic generation

## Configuration

### appsettings.json

```json
{
  "SiteSettings": {
    "BusinessName": "Wakes Autocare",
    "Phone": "07544 064878",
    "Email": "Wakesautocare@gmail.com",
    "Address": "Waterlooville, Portsmouth, Hampshire",
    "DefaultMetaDescription": "..."
  }
}
```

## Deployment

### Before Deployment
1. Update connection string for production database
2. Update SiteSettings in appsettings.json
3. Set environment to Production
4. Update sitemap and canonical URLs with production domain
5. Build in Release mode

### Publishing
```bash
dotnet publish -c Release -o ./publish
```

### Post-Deployment
1. Submit sitemap to Google Search Console
2. Verify structured data with Google Rich Results Test
3. Check mobile-friendliness
4. Monitor Search Console for indexing

## Future Enhancements

- [ ] Admin area for content management
- [ ] User authentication for admin
- [ ] Contact form email integration
- [ ] Case study image galleries
- [ ] Blog functionality
- [ ] Customer testimonials
- [ ] Service booking system
- [ ] Google My Business integration
- [ ] Analytics dashboard

## Support

For questions or issues related to the codebase, refer to:
- Main project documentation: `../PROJECT-BRIEF.md`
- Entity models in `/Models`
- Service implementations in `/Services`

## License

Proprietary - Wakes Autocare Ltd

## Contact

**Business Contact:**
- Phone: 07544 064878
- Email: Wakesautocare@gmail.com
- Location: Waterlooville, Portsmouth, Hampshire
