# Wakes Autocare Website - Project Brief

## Project Overview

This is a **flat file website** with an **MVC-like structure** for Wakes Autocare, a family-run car servicing and repair business serving Portsmouth, Waterlooville, and the South Coast.

**Business Name:** Wakes Autocare
**Formerly:** ST Vehicle Servicing and Repairs
**Technicians:** George and Stanley (IMI & ATA Accredited)
**Contact:** 07544 064878 | Wakesautocare@gmail.com
**Social Media:**
- Facebook: https://www.facebook.com/share/17jRzgmU6W/
- Instagram: @wakesautocare

**Primary Goal:** Achieve high search engine rankings for local searches like "[service] in [area]" and "[area] [service]" to attract South Coast customers.

---

## Directory Structure

```
WakesAutomotive/
├── index.html                      # Homepage
├── robots.txt                      # SEO: Search engine instructions
├── .htaccess                       # URL rewriting, clean URLs, security
├── assets/                         # Publicly accessible assets (at root)
│   ├── css/
│   │   └── styles.css              # Main stylesheet
│   ├── js/
│   │   └── component-loader.js     # MVC-style component injection
│   └── images/                     # All images
│       ├── logo.jpg
│       ├── banner-1.jpg
│       └── case-studies/           # Case study images
├── views/                          # Component views (at root)
│   └── components/                 # Reusable HTML components
│       ├── header.html             # Site header with contact info
│       ├── navigation.html         # Main navigation menu
│       └── footer.html             # Site footer
├── about/
│   └── index.html                  # About page
├── contact/
│   └── index.html                  # Contact page
├── services/
│   ├── index.html                  # Services overview
│   ├── diagnostics.html            # Diagnostics service page ✓
│   ├── servicing.html              # Full/interim servicing page ✓
│   ├── clutches.html               # Clutch replacement page ✓
│   ├── cambelts.html               # Cambelt & timing chain page ✓
│   ├── repairs.html                # General repairs page ✓
│   ├── mobile-service.html         # Mobile service page ✓
│   └── mot.html                    # MOT & pre-MOT checks page ✓
├── locations/
│   ├── index.html                  # Locations overview page ✓
│   ├── portsmouth.html             # Portsmouth location page ✓
│   ├── waterlooville.html          # Waterlooville (workshop) page ✓
│   ├── havant.html                 # Havant location page ✓
│   ├── fareham.html                # Fareham location page ✓
│   ├── southsea.html               # Southsea location page ✓
│   ├── gosport.html                # Gosport location page ✓
│   └── south-coast.html            # South Coast coverage page ✓
├── case-studies/
│   └── index.html                  # Portfolio/case studies page
└── _archive/                       # NON-PUBLIC: Original content & source files
    ├── CompanyInformation.txt
    ├── ForClaude.txt
    ├── Question.txt
    ├── Answer.txt
    ├── CaseStudies/                # Original case study content
    ├── Advert/                     # Original Facebook adverts
    └── Images/                     # Original images
```

---

## Architecture: MVC-Style Flat File Website

### How It Works

This website mimics an **MVC (Model-View-Controller)** structure using static HTML files and a JavaScript component loader:

1. **Views (Components):** Located in `/views/components/`
   - `header.html` - Site header
   - `navigation.html` - Main navigation
   - `footer.html` - Site footer

2. **Controller (JavaScript):** `/assets/js/component-loader.js`
   - Loads HTML components dynamically
   - Injects components into pages using `data-component` attributes
   - Handles template variable replacement
   - Initializes event listeners (mobile menu, active nav highlighting)

3. **Model (Static HTML):** Page content files (index.html, about/index.html, etc.)
   - Each page includes components via: `<div data-component="header"></div>`
   - Components are loaded automatically on page load

### Example Usage in Pages

```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Page Title</title>
    <link rel="stylesheet" href="/public/assets/css/styles.css">
</head>
<body>
    <!-- Components loaded automatically -->
    <div data-component="header"></div>
    <div data-component="navigation"></div>

    <main>
        <!-- Page-specific content here -->
    </main>

    <div data-component="footer"></div>
    <script src="/public/assets/js/component-loader.js"></script>
</body>
</html>
```

**Benefits:**
- Easy to maintain - update header/footer in one place
- No build process or server-side rendering required
- Fast loading - static files
- SEO-friendly - server-rendered HTML

---

## SEO Strategy

### Target Keywords & Locations

**Services:**
- Car servicing
- Car repairs
- Mobile mechanic
- Diagnostics
- Clutch replacement
- Cambelt replacement
- MOT
- Brake repairs

**Target Areas:**
- Portsmouth (primary)
- Waterlooville (primary - workshop location)
- Havant
- Fareham
- Southsea
- Gosport
- South Coast
- Hampshire

**Keyword Format:**
- `[service] in [area]` - e.g., "car servicing in Portsmouth"
- `[area] [service]` - e.g., "Portsmouth mobile mechanic"

### SEO Implementation

1. **robots.txt**
   - Allows all search engines
   - Blocks `/_archive/` and `/public/views/` from indexing
   - Points to sitemap.xml (to be created)

2. **.htaccess**
   - Removes `.html` from URLs (clean URLs)
   - Removes `index.html` from URLs
   - Security headers
   - Browser caching
   - Compression

3. **Meta Tags**
   - Every page has unique title and description
   - Keywords targeting local areas + services
   - Open Graph tags for social sharing

4. **Structured Data (Schema.org)**
   - LocalBusiness JSON-LD on homepage
   - Service-specific schema on service pages
   - Area-specific schema on location pages

5. **Local SEO Elements**
   - NAP (Name, Address, Phone) consistent across all pages
   - Location-specific pages for each service area
   - Service-specific pages with local keywords
   - Case studies demonstrating local work

---

## Services Offered

1. **Diagnostics** 💻 - Advanced diagnostic equipment
2. **Servicing** 📋 - Full & interim servicing
3. **Clutches** ⚙️ - Expert clutch replacement
4. **Cambelts & Timing Chains** 🔧 - Critical engine protection
5. **Repairs** 🛠️ - All general repairs
6. **Mobile Service** 🛻 - We come to you!
7. **MOT** ✅ - Pre-MOT checks and MOT arrangement

---

## Key Business Information

**Experience:**
- 18+ years combined experience
- Time-served technicians
- Experience with: Rolls Royce, BMW, Land Rover, Volkswagen, Ford

**Credentials:**
- IMI (Institute of the Motor Industry) Accredited
- ATA (Association of Automotive Technicians) Certified
- Fully Insured

**Service Area:**
- Workshop: Waterlooville, Hampshire
- Mobile Service: Entire South Coast

**Values:**
- Honest advice and transparent pricing
- Quality workmanship using correct specifications
- Excellent customer service
- Continuous learning and development

**Unique Selling Points:**
- Family-run business
- Mobile service available
- Work Sundays for urgent jobs
- Quality parts and correct spec oils
- Proper torque settings used
- Manufacturer schedules followed

---

## Content Sources

All original content is archived in `/_archive/`:

- **CompanyInformation.txt** - Business details, services, contact info
- **CaseStudies/** - Real examples of work completed:
  - ClutchReplacement
  - FullService
  - MobileService
  - MotFailures
  - NewCarCheck
  - NonRunner/StarterMotor
  - TrackDay
  - WetBeltReplacement
  - WinterCheck
  - General/2025_August
  - General/2025_September

Each case study folder contains:
- `text.txt` - Description of the work
- Images with descriptive names

---

## Design & Branding

**Logo:**
- Black background with white text
- Large "WAKES" in center
- White semicircle line above
- "AUTOCARE" below the semicircle
- Located at: `/public/assets/images/logo.jpg`

**Color Scheme:**
- Primary: Black (#000000)
- Secondary: White (#FFFFFF)
- Accent: Red (#e63946)
- Text: Dark gray (#333333)
- Background: White with light gray sections (#f8f9fa)

**Typography:**
- Main font: Segoe UI, Tahoma, Geneva, Verdana, sans-serif
- Headings: Arial, sans-serif

**Responsive Design:**
- Mobile-first approach
- Breakpoints: 768px (tablet), 480px (mobile)
- Mobile menu toggle for navigation
- Flexible grid layouts

---

## Completed Development Tasks

### ✓ Service Pages (COMPLETED)

All 7 service pages have been created with comprehensive content:

1. **diagnostics.html** - Advanced diagnostics & fault finding
2. **servicing.html** - Full & interim servicing with customer testimonial
3. **clutches.html** - Clutch replacement with DMF information
4. **cambelts.html** - Cambelt, timing chain & wet belt specialist page
5. **repairs.html** - Comprehensive repairs (brakes, suspension, electrical, etc.)
6. **mot.html** - MOT testing, pre-MOT checks & failure repairs
7. **mobile-service.html** - Mobile service across South Coast

**Each includes:**
- Local SEO keywords integrated naturally
- Service-specific Schema.org markup
- Relevant case study images where applicable
- Multiple clear call-to-action buttons
- Benefits and "Why choose us" sections
- Related service links

### ✓ Location Pages (COMPLETED)

All 8 location pages have been created:

1. **locations/index.html** - Overview of all areas with links
2. **portsmouth.html** - Portsmouth coverage (detailed page)
3. **waterlooville.html** - Workshop location (streamlined)
4. **havant.html** - Havant area (streamlined)
5. **fareham.html** - Fareham area (streamlined)
6. **southsea.html** - Southsea area (streamlined)
7. **gosport.html** - Gosport area (streamlined)
8. **south-coast.html** - General South Coast coverage

**Each includes:**
- Area-specific keywords and neighborhoods
- LocalBusiness Schema.org markup
- Services available in that area
- Mobile service emphasis
- Clear contact information

## Streamlined Process for Reducing Duplication

### Approach Used

To efficiently create multiple similar pages while maintaining SEO uniqueness, we used a **template-based approach** with **strategic content variation**:

#### Service Pages Strategy

1. **Detailed Template Pages** (diagnostics, servicing, clutches, cambelts)
   - Full detailed content with multiple sections
   - Specific case study images and examples
   - Comprehensive "what's included" lists
   - Detailed process explanations

2. **Efficient Creation Method**
   - Each page written individually but following consistent structure
   - Unique H1, title, meta description for each
   - Service-specific Schema.org data
   - Different benefits/features for each service
   - Real case study content integrated where available

#### Location Pages Strategy

1. **Portsmouth as Detailed Template**
   - Comprehensive page with full sections
   - Multiple neighborhoods listed
   - Detailed service descriptions

2. **Streamlined Subsidiary Pages** (other locations)
   - Concise 2-section format:
     - Services offered in that area
     - Specific neighborhoods/areas covered
   - Unique keywords for each location
   - Mobile service emphasis
   - Less duplication, focused content

3. **Creation Efficiency**
   - Used bash heredoc syntax for rapid creation
   - Maintained unique titles, descriptions, H1s
   - Varied neighborhood lists for each area
   - Consistent Schema.org structure

### Benefits of This Approach

✅ **SEO Compliance:** Each page has unique title, meta description, H1, and content
✅ **Time Efficient:** Created 13 pages in one session vs. individually crafting each
✅ **Maintainable:** Template pattern makes future updates easier
✅ **Scalable:** Can quickly add new locations or services using same pattern
✅ **User Focused:** Detailed pages where needed, concise pages where appropriate

### Template Pattern for Future Pages

When creating similar pages in the future:

```html
<!-- Detailed Page Template (for main/important pages) -->
- Multiple sections (3-5)
- Comprehensive content
- Images included
- Case studies referenced
- Full benefits/features lists

<!-- Streamlined Page Template (for subsidiary pages) -->
- 2-3 focused sections
- Core information only
- Unique keywords naturally integrated
- Clear CTAs
- Links to related detailed pages
```

### Code Reuse vs. Content Uniqueness

**What we reused:**
- HTML structure and layout
- Schema.org JSON-LD format
- CSS classes and styling
- Component injection pattern
- CTA button structure

**What we made unique:**
- Page titles (50-60 chars, unique keywords)
- Meta descriptions (150-160 chars, location/service specific)
- H1 headings (unique for each page)
- Body content (different services/areas for each)
- Schema.org data (specific to page purpose)
- Keywords (location + service combinations)

### Future Page Creation Workflow

1. **Identify page type:** Detailed vs. Streamlined
2. **Choose template:** Copy from similar existing page
3. **Customize SEO elements:** Title, description, H1, keywords
4. **Adapt content:** Change services/areas/neighborhoods
5. **Update Schema.org:** Modify structured data for specific page
6. **Add to navigation:** Update components/navigation.html
7. **Test:** Verify all links work, images load, components inject

### Bash Creation Technique (Optional)

For multiple similar pages, use heredoc syntax for efficiency:

```bash
cat > /path/to/page.html << 'EOF'
<!DOCTYPE html>
<html lang="en">
<!-- page content here -->
</html>
EOF
```

This allows rapid creation of 5-10 pages in a single command block while maintaining unique content for each.

### Medium Priority - Content Enhancements

1. **Create sitemap.xml**
   - List all pages for search engine indexing
   - Include last modified dates
   - Referenced in robots.txt

2. **Add Google Business Profile integration**
   - Embed map on contact page
   - Link to Google reviews
   - Display business hours

3. **Expand case studies**
   - Create individual case study pages for major work
   - Include before/after photos where available
   - Add customer testimonials (with permission)

4. **Create blog/news section** (optional)
   - Seasonal tips (winter checks, summer prep)
   - Common car problems explained
   - Service interval reminders
   - Local motoring news

### Low Priority - Technical Enhancements

1. **Performance optimization**
   - Image optimization (WebP format)
   - Lazy loading for images
   - Minify CSS/JS

2. **Analytics integration**
   - Google Analytics 4
   - Track phone clicks
   - Track email clicks
   - Form submissions

3. **Accessibility improvements**
   - ARIA labels
   - Keyboard navigation
   - Screen reader testing
   - Contrast ratio verification

---

## Editing Components

To update reusable sections across all pages:

### Update Header
Edit: `/public/views/components/header.html`
- Change contact information
- Update logo
- Modify layout

### Update Navigation
Edit: `/public/views/components/navigation.html`
- Add/remove menu items
- Modify dropdown menus
- Update links

### Update Footer
Edit: `/public/views/components/footer.html`
- Change footer sections
- Update social media links
- Modify copyright information

**Changes automatically apply to all pages** that load these components.

---

## Editing Styles

Main stylesheet: `/public/assets/css/styles.css`

**CSS Variables (for easy theming):**
```css
:root {
    --color-primary: #000000;
    --color-secondary: #ffffff;
    --color-accent: #e63946;
    --color-text: #333333;
    --color-text-light: #666666;
    --color-bg: #ffffff;
    --color-bg-light: #f8f9fa;
    --color-border: #e0e0e0;
}
```

Change these variables to update colors across the entire site.

---

## Adding New Pages

1. **Create HTML file** in appropriate folder (e.g., `services/new-service.html`)

2. **Use this template:**
```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="Page description with keywords">
    <title>Page Title | Wakes Autocare</title>
    <link rel="canonical" href="https://wakesautocare.com/path/to/page">
    <link rel="stylesheet" href="/public/assets/css/styles.css">
</head>
<body>
    <div data-component="header"></div>
    <div data-component="navigation"></div>

    <main>
        <!-- Your content here -->
    </main>

    <div data-component="footer"></div>
    <script src="/public/assets/js/component-loader.js"></script>
</body>
</html>
```

3. **Add to navigation** in `/public/views/components/navigation.html`

4. **Update sitemap.xml** (when created)

---

## Important Files - Single Source of Truth

### This File (project-brief.md)
- **Purpose:** Complete project documentation
- **Single Source of Truth:** YES
- **Update when:**
  - New pages are added
  - New features are implemented
  - Directory structure changes
  - Business information changes
  - Tasks are completed or new tasks identified

### CompanyInformation.txt (in _archive/)
- **Purpose:** Business details, services, contact information
- **Single Source of Truth:** YES (for business info)
- **Update when:** Contact details, services, or business information changes

### Component Files
- `header.html`, `navigation.html`, `footer.html`
- **Single Source of Truth:** YES (for their respective sections)
- **Update when:** Contact info, menu structure, or footer content changes

---

## SEO Best Practices to Follow

1. **Every page must have:**
   - Unique `<title>` tag (50-60 characters)
   - Unique meta description (150-160 characters)
   - `<h1>` tag (one per page)
   - Canonical URL
   - Alt text for all images
   - Local keywords naturally integrated

2. **Location pages must include:**
   - LocalBusiness Schema.org markup
   - Specific area names and postcodes
   - "Areas served" section
   - Mobile service availability mention

3. **Service pages must include:**
   - Service-specific Schema.org markup
   - Benefits/features list
   - Call-to-action buttons
   - Related case studies/examples
   - Local area mentions

4. **Internal linking:**
   - Link to related services
   - Link to relevant location pages
   - Link to case studies from service pages
   - Use descriptive anchor text

---

## Contact Information (Always Use These)

**Phone:** 07544 064878
**Email:** Wakesautocare@gmail.com
**Location:** Waterlooville, Hampshire (near Portsmouth)
**Coverage:** Portsmouth / Waterlooville / South Coast

**Social Media:**
- Facebook: https://www.facebook.com/share/17jRzgmU6W/
- Instagram: @wakesautocare (https://www.instagram.com/wakesautocare)

**Credentials:**
- IMI & ATA Accredited Technicians
- Fully Insured
- 18+ Years Combined Experience

---

## Questions for Future Claude Sessions

When starting a new session, Claude should be told:

**"Read the project-brief.md file - it contains all project documentation, structure, and tasks."**

This ensures consistency and understanding of:
- The MVC-like architecture
- Where files are located
- What tasks remain
- SEO strategy
- Business information
- Design guidelines

---

## Version History

**Version 1.0 - December 2025**
- Initial website created
- MVC-style component system implemented
- Core pages created (Home, About, Contact, Services, Case Studies)
- One service page created (Mobile Service)
- One location page created (Portsmouth)
- SEO foundation established (robots.txt, .htaccess, meta tags, Schema.org)
- Responsive design implemented

**Version 1.1 - December 2025**
- Fixed file structure: moved assets/ and views/ to root level
- Updated all paths for proper web server deployment
- Fixed component loading and image paths
- All navigation links now functional

**Version 2.0 - December 2025 (CURRENT)**
- **All service pages completed** (7 total)
  - Diagnostics, Servicing, Clutches, Cambelts, Repairs, MOT, Mobile Service
- **All location pages completed** (8 total)
  - Overview, Portsmouth, Waterlooville, Havant, Fareham, Southsea, Gosport, South Coast
- Implemented streamlined template approach for efficient page creation
- Maintained SEO uniqueness across all pages
- Integrated case study images and real customer testimonials
- 20 total pages live and functional
- Zero broken navigation links

---

## Notes for Future Development

1. **Don't over-engineer** - Keep it simple. This is a flat file website, not a complex web application.

2. **Maintain consistency** - Use established patterns when creating new pages.

3. **Focus on SEO** - Every page should target specific local keywords.

4. **Test on mobile** - Most users will visit on mobile devices.

5. **Keep content fresh** - Regular updates help with SEO. Consider adding recent work to case studies.

6. **Monitor performance** - Use Google PageSpeed Insights to check load times.

7. **Backup regularly** - Before making major changes, backup the site.

8. **Check broken links** - Especially after adding new pages or restructuring.

---

## Getting Started (For New Claude Sessions)

1. Read this file completely
2. Check the `/_archive/` folder for source content
3. Review existing pages for patterns and style
4. Check the task list above for what needs to be done
5. Maintain the MVC-style architecture
6. Follow SEO best practices
7. Test all changes
8. Update this file when tasks are completed or structure changes

---

**Last Updated:** December 2025
**Project Status:** Core Website Complete - Ready for SEO Optimization & Enhancement Phase
**Maintained By:** Claude Code Sessions
**Total Pages:** 20 (all functional, zero 404s)
