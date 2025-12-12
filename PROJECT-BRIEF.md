# Wakes Autocare - Web Application Project Brief

**Last Updated:** 2025-12-12
**Status:** Active Development
**Single Source of Truth:** YES - This document should be updated whenever project scope, architecture, or key decisions change.

## Project Overview

Building a professional web presence for **Wakes Autocare**, a family-established automotive service business in Waterlooville/Portsmouth, UK. The application focuses on local SEO optimization to rank highly for location-based automotive service searches.

## Business Information

### Company Details
- **Business Name:** Wakes Autocare Ltd
- **Formerly:** ST vehicle servicing and repairs
- **Technicians:** George and Stanley
- **Contact:**
  - Mobile: 07544 064878
  - Email: Wakesautocare@gmail.com
- **Location:** Waterlooville/Portsmouth, Hampshire
- **Service Area:** Whole of the South Coast

### Expertise & Credentials
- **Combined Experience:** 27 years in automotive industry
- **Accreditations:** IMI and ATA accredited Automotive Technicians
- **Brand Experience:** Rolls Royce, BMW, Land Rover, Volkswagen, Ford

### Core Services
1. **Diagnostics** - Computer diagnostics and fault finding
2. **Servicing** - Full and interim services
3. **Clutches** - Clutch replacement and repair
4. **Cambelts/Timing Chains** - Timing belt and wet belt replacement
5. **Repairs** - General automotive repairs
6. **Mobile Service** - On-site service across the south coast
7. **MOTs** - MOT testing
8. **Pre-purchase Inspections** - New car checks

## Technical Architecture

### Technology Stack
- **Framework:** ASP.NET Core 8 MVC
- **Database:** SQL Server with Entity Framework Core
- **Language:** C# (Developer is experienced with C# MVC and Blazor)
- **Hosting:** TBD (Consider Azure App Service or similar)

### Why MVC?
- Clean separation of concerns
- Server-rendered HTML (excellent for SEO)
- Easy templating with Razor
- Full control of meta tags, canonical URLs, and structured data
- Developer's existing expertise

## SEO Strategy

### Primary Goals
1. Rank high for "[service] in [location]" searches
2. Rank high for "[location] [service]" searches
3. Target multiple towns, cities, and counties across the south coast

### URL Structure
```
/services/{serviceSlug}/{locationSlug}   -> /services/diagnostics/portsmouth
/services/{serviceSlug}                  -> /services/diagnostics
/locations/{locationSlug}                -> /locations/portsmouth
/case-studies/{slug}                     -> /case-studies/wet-belt-replacement
```

### SEO Requirements
- Unique title tags and meta descriptions per page
- Canonical URLs to avoid duplicate content
- JSON-LD LocalBusiness structured data on all location pages
- XML sitemap generation
- Mobile-first responsive design
- Fast page load times

## Database Schema

### Core Entities

**Service**
- Id (int)
- Slug (string) - e.g., "diagnostics"
- Title (string) - e.g., "Diagnostics"
- Summary (string)
- Description (string)

**Location**
- Id (int)
- Slug (string) - e.g., "portsmouth"
- Name (string) - e.g., "Portsmouth"
- County (string) - e.g., "Hampshire"
- PostcodePrefix (string) - optional

**ServiceLocationPage**
- Id (int)
- ServiceId (int)
- LocationId (int)
- TitleTag (string) - SEO title
- MetaDescription (string) - SEO description
- H1 (string)
- BodyHtml (string) - Unique content for this combination
- CanonicalUrl (string)
- LastUpdated (DateTime)

**CaseStudy**
- Id (int)
- Slug (string)
- Title (string)
- Summary (string)
- Content (string/HTML)
- Images (collection)
- DatePublished (DateTime)
- ServiceId (int) - Related service

**ContentSnippet**
- Id (int)
- Type (enum: Introduction, Feature, Testimonial, etc.)
- Content (string/HTML)
- ServiceId (int?) - Optional link to specific service

## Content Strategy

### Avoiding Duplicate Content
Instead of simple template replacement, the application will:
1. Store reusable content snippets
2. Programmatically combine 2-3 snippets per page
3. Allow manual overrides per ServiceLocationPage
4. Inject local facts (nearest landmarks, service areas)
5. Track LastUpdated for freshness signals

### Existing Content Assets
Located in `/CaseStudies/` folder:
- Clutch Replacement
- Full Service
- Mobile Service
- MOT Failures
- New Car Check
- Non Runner / Starter Motor
- Track Day
- Wet Belt Replacement
- Winter Check
- General work (August 2025, September 2025)

### Marketing Content
Located in `/Advert/` folder:
- Business introduction adverts
- Service listings

### Visual Assets
Located in `/Images/` folder:
- logo.jpg - Main logo
- logo-winter.jpg - Seasonal variant
- logo-christmas.jpg - Seasonal variant
- banner-1.jpg - Facebook banner

## Application Features

### Public-Facing Features
1. **Home Page** - Business introduction, featured services
2. **Service Pages** - Individual service information
3. **Location Pages** - Area-specific landing pages
4. **Service + Location Pages** - Combined pages for SEO
5. **Case Studies Section** - Showcase work with images
6. **Contact Page** - Contact form and business details
7. **About Us** - Business history, technicians, credentials
8. **Sitemap (XML)** - Auto-generated from database

### Admin Area (CMS)
1. Manage Services
2. Manage Locations
3. Manage ServiceLocationPages
4. Edit SEO metadata (titles, descriptions, canonical URLs)
5. Manage Content Snippets
6. Manage Case Studies
7. Preview pages before publishing
8. Validation for unique titles/descriptions

## Initial Service Areas to Target

### Priority Locations (South Coast)
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
- Cowes (Isle of Wight)
- Newport (Isle of Wight)

### Services to Promote
- Vehicle Diagnostics
- Car Servicing
- Clutch Replacement
- Timing Belt Replacement
- Cambelt Replacement
- Mobile Mechanic
- Vehicle Repairs
- MOT Preparation
- Pre-Purchase Inspection

## Development Phases

### Phase 1: Foundation (CURRENT)
- [x] Project brief creation
- [ ] Project structure setup
- [ ] Database models and EF Core configuration
- [ ] Basic routing and controllers
- [ ] SEO service implementation

### Phase 2: Core Features
- [ ] Service pages
- [ ] Location pages
- [ ] Service + Location combination pages
- [ ] Case studies section
- [ ] Contact functionality

### Phase 3: SEO & Content
- [ ] Sitemap generation
- [ ] JSON-LD structured data
- [ ] Content snippet system
- [ ] Meta tag management
- [ ] Database seeding with initial content

### Phase 4: Admin Area
- [ ] Admin authentication
- [ ] Service management
- [ ] Location management
- [ ] Page content editing
- [ ] SEO metadata editing

### Phase 5: Polish & Launch
- [ ] Responsive design implementation
- [ ] Performance optimization
- [ ] Testing (unit, integration, SEO)
- [ ] Deployment setup
- [ ] Search Console setup

## Key Files & Their Purpose

### Documentation Files
- **PROJECT-BRIEF.md** (this file) - Single source of truth for project scope and architecture
- **ForClaude.txt** - Initial instructions for AI
- **Question.txt** - Original question about architecture
- **Answer.txt** - Detailed MVC architecture response
- **CompanyInformation.txt** - Business details

### Source Folders (To Be Created)
- **/WakesAutocare.Web** - Main MVC application
- **/WakesAutocare.Web/Models** - Entity models
- **/WakesAutocare.Web/Data** - DbContext and migrations
- **/WakesAutocare.Web/Services** - Business logic and SEO services
- **/WakesAutocare.Web/Controllers** - MVC controllers
- **/WakesAutocare.Web/Views** - Razor views
- **/WakesAutocare.Web/Areas/Admin** - Admin CMS area
- **/WakesAutocare.Web/wwwroot** - Static files (CSS, JS, images)

## Decision Log

### 2025-12-12: Technology Choice
**Decision:** Use ASP.NET Core 8 MVC
**Rationale:**
- Developer expertise in C# and MVC
- Server-side rendering excellent for SEO
- Full control over meta tags and structured data
- Proven architecture from AI recommendation

### 2025-12-12: Database Choice
**Decision:** SQL Server with Entity Framework Core
**Rationale:**
- Native support in .NET ecosystem
- Developer familiarity
- Good tooling and migration support

## Reference Documentation

- **Original AI Response:** See Answer.txt for detailed code examples
- **SEO Best Practices:** Google LocalBusiness JSON-LD, canonical tags
- **Case Study Content:** See /CaseStudies/ folder for real business examples
- **Visual Assets:** See /Images/ folder for branding

## Next Steps for New Sessions

When starting a new session, Claude should:
1. Read this PROJECT-BRIEF.md file first
2. Check current git branch status
3. Review latest commits to understand progress
4. Ask user what specific task to work on
5. Update this brief if scope or architecture changes

## Update Triggers

This document should be updated when:
- Architecture decisions change
- New features are added to scope
- Database schema is modified
- New service areas are identified
- Deployment decisions are made
- Major milestones are completed

---

**Developer Note:** You are a C# developer familiar with HTML, CSS, MVC, and Blazor. Feel free to suggest improvements or alternative approaches based on your expertise.
