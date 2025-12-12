using WakesAutocare.Web.Models;

namespace WakesAutocare.Web.Data;

public static class ContentSnippetSeeder
{
    public static async Task SeedContentSnippets(AppDbContext context)
    {
        // Check if snippets already exist
        if (context.ContentSnippets.Any())
        {
            return; // Already seeded
        }

        var snippets = new List<ContentSnippet>
        {
            // Global Introduction Snippets
            new ContentSnippet
            {
                Name = "Intro - Professional Service",
                Type = SnippetType.Introduction,
                Content = "<p>At Wakes Autocare, we pride ourselves on delivering professional automotive services with a personal touch. Our IMI and ATA accredited technicians bring 27 years of combined experience to every job.</p>",
                DisplayOrder = 1,
                IsActive = true
            },
            new ContentSnippet
            {
                Name = "Intro - Family Business",
                Type = SnippetType.Introduction,
                Content = "<p>As a family-established business, we understand the importance of trust and reliability. We treat every customer's vehicle as if it were our own, ensuring the highest standards of workmanship.</p>",
                DisplayOrder = 2,
                IsActive = true
            },
            new ContentSnippet
            {
                Name = "Intro - Expert Technicians",
                Type = SnippetType.Introduction,
                Content = "<p>Our technicians have extensive experience working with premium brands including Rolls Royce, BMW, Land Rover, Volkswagen, and Ford. This expertise translates to exceptional service for all makes and models.</p>",
                DisplayOrder = 3,
                IsActive = true
            },

            // Why Choose Us Snippets
            new ContentSnippet
            {
                Name = "Why - Qualified Team",
                Type = SnippetType.WhyChooseUs,
                Content = "<h3>Fully Qualified Technicians</h3><p>All our technicians are IMI and ATA accredited, ensuring you receive service from qualified professionals who stay up-to-date with the latest automotive technology and techniques.</p>",
                DisplayOrder = 1,
                IsActive = true
            },
            new ContentSnippet
            {
                Name = "Why - Competitive Pricing",
                Type = SnippetType.WhyChooseUs,
                Content = "<h3>Honest, Transparent Pricing</h3><p>We believe in straightforward pricing with no hidden costs. You'll receive a detailed quote before any work begins, so you know exactly what you're paying for.</p>",
                DisplayOrder = 2,
                IsActive = true
            },
            new ContentSnippet
            {
                Name = "Why - Mobile Service",
                Type = SnippetType.WhyChooseUs,
                Content = "<h3>Convenient Mobile Service</h3><p>Can't get to a garage? Our mobile service brings professional automotive care to your door. Fully insured and equipped, we cover the entire South Coast.</p>",
                DisplayOrder = 3,
                IsActive = true
            },
            new ContentSnippet
            {
                Name = "Why - Customer Reviews",
                Type = SnippetType.WhyChooseUs,
                Content = "<h3>Excellent Customer Reviews</h3><p>Our Facebook reviews speak for themselves. We've built our reputation on quality work, fair pricing, and exceptional customer service.</p>",
                DisplayOrder = 4,
                IsActive = true
            },

            // Service-Specific: Diagnostics
            new ContentSnippet
            {
                Name = "Diagnostics - Process",
                Type = SnippetType.ProcessDescription,
                Content = "<h3>Professional Diagnostic Services</h3><p>Using the latest diagnostic equipment, we can quickly identify issues with your vehicle's electronic systems, engine management, and onboard computers. Our comprehensive diagnostics save you time and money by pinpointing problems accurately.</p>",
                ServiceId = 1, // Diagnostics
                DisplayOrder = 1,
                IsActive = true
            },

            // Service-Specific: Servicing
            new ContentSnippet
            {
                Name = "Servicing - What's Included",
                Type = SnippetType.ProcessDescription,
                Content = "<h3>Comprehensive Vehicle Servicing</h3><p>Our full and interim services include oil and filter changes, fluid level checks, brake inspections, and a thorough vehicle health check. We use quality parts and manufacturer-specified fluids to keep your vehicle running smoothly.</p>",
                ServiceId = 2, // Servicing
                DisplayOrder = 1,
                IsActive = true
            },

            // Service-Specific: Clutch Replacement
            new ContentSnippet
            {
                Name = "Clutch - Expertise",
                Type = SnippetType.ProcessDescription,
                Content = "<h3>Expert Clutch Replacement</h3><p>Clutch problems can range from slipping to complete failure. Our experienced technicians can diagnose clutch issues and carry out professional replacements, including flywheel inspection and slave cylinder checks.</p>",
                ServiceId = 3, // Clutch Replacement
                DisplayOrder = 1,
                IsActive = true
            },

            // Service-Specific: Timing Belt
            new ContentSnippet
            {
                Name = "Timing Belt - Importance",
                Type = SnippetType.ProcessDescription,
                Content = "<h3>Critical Timing Belt Service</h3><p>Timing belts (including wet belts) are crucial to engine operation. Failure can cause catastrophic engine damage. We specialize in timing belt replacement, following manufacturer specifications for timing and tension to ensure your engine runs perfectly.</p>",
                ServiceId = 4, // Timing Belt
                DisplayOrder = 1,
                IsActive = true
            },

            // Call to Action Snippets
            new ContentSnippet
            {
                Name = "CTA - Book Today",
                Type = SnippetType.CallToAction,
                Content = "<h3>Book Your Service Today</h3><p>Contact us on <a href='tel:07544064878'><strong>07544 064878</strong></a> or email <a href='mailto:Wakesautocare@gmail.com'>Wakesautocare@gmail.com</a> to book your appointment or get a free quote.</p>",
                DisplayOrder = 1,
                IsActive = true
            },
            new ContentSnippet
            {
                Name = "CTA - Free Advice",
                Type = SnippetType.CallToAction,
                Content = "<h3>Need Advice?</h3><p>Not sure what your vehicle needs? We're happy to provide free, honest advice. Give us a call and we'll talk you through your options with no obligation.</p>",
                DisplayOrder = 2,
                IsActive = true
            },

            // Local Info Template (will be customized per location)
            new ContentSnippet
            {
                Name = "Local - South Coast Coverage",
                Type = SnippetType.LocalInfo,
                Content = "<h3>Serving the South Coast</h3><p>Based in Waterlooville, we're perfectly positioned to serve customers across Hampshire and West Sussex. Our mobile service means we can bring our expertise directly to you.</p>",
                DisplayOrder = 1,
                IsActive = true
            },

            // Features
            new ContentSnippet
            {
                Name = "Feature - Quality Parts",
                Type = SnippetType.Feature,
                Content = "<div class='feature-item'><i class='fa fa-check-circle'></i> <strong>Quality Parts:</strong> We use genuine or premium aftermarket parts for all repairs and services.</div>",
                DisplayOrder = 1,
                IsActive = true
            },
            new ContentSnippet
            {
                Name = "Feature - Warranty",
                Type = SnippetType.Feature,
                Content = "<div class='feature-item'><i class='fa fa-check-circle'></i> <strong>Work Guarantee:</strong> All our work is fully guaranteed for your peace of mind.</div>",
                DisplayOrder = 2,
                IsActive = true
            },
            new ContentSnippet
            {
                Name = "Feature - Flexible Hours",
                Type = SnippetType.Feature,
                Content = "<div class='feature-item'><i class='fa fa-check-circle'></i> <strong>Flexible Appointments:</strong> We work around your schedule, including weekend appointments when possible.</div>",
                DisplayOrder = 3,
                IsActive = true
            }
        };

        await context.ContentSnippets.AddRangeAsync(snippets);
        await context.SaveChangesAsync();
    }
}
