using WakesAutocare.Web.Data;
using WakesAutocare.Web.Models;

namespace WakesAutocare.Web.Data;

public static class CaseStudySeeder
{
    public static async Task SeedCaseStudies(AppDbContext context)
    {
        // Check if case studies already exist
        if (context.CaseStudies.Any())
        {
            return; // Already seeded
        }

        var caseStudies = new List<CaseStudy>
        {
            new CaseStudy
            {
                Slug = "clutch-replacement-ford-fiesta",
                Title = "Clutch Replacement - Ford Fiesta",
                Summary = "Professional clutch replacement service on a Ford Fiesta",
                Content = @"<p>Nice little clutch replacement on a Ford Fiesta for us today.</p>
                          <p>Our experienced technicians completed a full clutch replacement, ensuring the vehicle is back on the road with smooth gear changes and reliable performance.</p>
                          <h3>Work Completed:</h3>
                          <ul>
                            <li>Full clutch kit replacement</li>
                            <li>Flywheel inspection and resurfacing</li>
                            <li>Slave cylinder check</li>
                            <li>Road test and quality assurance</li>
                          </ul>
                          <p>If you need clutch work, drop us a message for any enquiries. We're also happy to provide free advice.</p>",
                FeaturedImage = "/images/case-studies/new-clutch.jpg",
                ServiceId = 3, // Clutch Replacement
                IsFeatured = true,
                IsPublished = true,
                DatePublished = DateTime.UtcNow.AddDays(-30)
            },
            new CaseStudy
            {
                Slug = "wet-belt-replacement-vauxhall-crossland",
                Title = "Wet Belt Replacement - Vauxhall Crossland",
                Summary = "Saved a Vauxhall Crossland from being sold - wet belt replacement success story",
                Content = @"<p>This customer contacted us after being advised to sell their car due to the wet belt needing replacing. We were able to save their vehicle!</p>
                          <h3>Work Completed:</h3>
                          <ul>
                            <li>Wet belt / timing belt replacement</li>
                            <li>Tensioner replacement</li>
                            <li>Idler replacement</li>
                            <li>Oil and oil filter change</li>
                            <li>Rear discs and pads replacement</li>
                            <li>Sump sealant renewal</li>
                            <li>Sump removal to clean broken belt fragments from strainer</li>
                          </ul>
                          <p><strong>Got a wet belt that needs replacing? Been advised you need to sell your car?</strong> Drop us a message and we will see how we can help.</p>
                          <p>Don't give up on your vehicle - we specialize in these complex repairs that other garages might shy away from.</p>",
                FeaturedImage = "/images/case-studies/1.jpg",
                Images = "['/images/case-studies/1.jpg','/images/case-studies/2.jpg','/images/case-studies/3.jpg','/images/case-studies/4.jpg','/images/case-studies/5.jpg','/images/case-studies/6.jpg','/images/case-studies/7.jpg','/images/case-studies/8.jpg']",
                ServiceId = 4, // Timing Belt
                IsFeatured = true,
                IsPublished = true,
                DatePublished = DateTime.UtcNow.AddDays(-25)
            },
            new CaseStudy
            {
                Slug = "full-service-ford-puma-2021",
                Title = "Full Service - 2021 Ford Puma",
                Summary = "Sunday morning full service for a loyal customer's Ford Puma",
                Content = @"<p>No rest for the wicked! Up nice and early this morning for a good friend of ours. Sunday morning was their only opportunity to get their vehicle in for a Full Service.</p>
                          <h3>Vehicle:</h3>
                          <p>2021 Ford Puma</p>
                          <h3>Work Completed:</h3>
                          <ul>
                            <li>Full Bosch filter kit including spark plugs</li>
                            <li>Correct spec Millers oil (supplied by customer)</li>
                            <li>Levels set correctly ✅</li>
                            <li>Torque settings used ✅</li>
                            <li>Correct spec oil ✅</li>
                          </ul>
                          <p>Another happy customer! We go the extra mile to accommodate our customers' schedules, even if that means working on Sunday mornings.</p>",
                FeaturedImage = "/images/case-studies/ford-puma-bonnet-up.jpg",
                ServiceId = 2, // Servicing
                IsFeatured = true,
                IsPublished = true,
                DatePublished = DateTime.UtcNow.AddDays(-20)
            },
            new CaseStudy
            {
                Slug = "mobile-service-south-coast",
                Title = "Mobile Service Across the South Coast",
                Summary = "Convenient mobile servicing brought directly to the customer",
                Content = @"<p>Another mobile service carried out this week - bringing professional automotive care directly to our customers.</p>
                          <h3>Why Choose Our Mobile Service?</h3>
                          <ul>
                            <li>📲 Book via message or phone call</li>
                            <li>📍 We cover the whole of the south coast</li>
                            <li>👨‍🔧 IMI / ATA accredited technicians</li>
                            <li>📋 Fully insured</li>
                          </ul>
                          <p>Can't get to a garage? No problem. Our fully-equipped mobile service means you don't have to disrupt your day. We'll come to your home or workplace at a time that suits you.</p>
                          <p>Drop us a message to get your service booked in!</p>",
                FeaturedImage = "/images/case-studies/mazda-bonnet-open.jpg",
                ServiceId = 6, // Mobile Mechanic
                IsFeatured = false,
                IsPublished = true,
                DatePublished = DateTime.UtcNow.AddDays(-15)
            },
            new CaseStudy
            {
                Slug = "pre-purchase-inspection-audi-q5",
                Title = "Pre-Purchase Inspection - 2019 Audi Q5",
                Summary = "Recently purchased car inspection uncovered hidden faults",
                Content = @"<p>Recently purchased a car? Want it inspected for peace of mind?</p>
                          <p>We were contacted by one of our customers after purchasing this stunning 2019 Audi Q5. A week into ownership the car developed a couple of faults.</p>
                          <h3>Faults Found:</h3>
                          <p><strong>Airbag light illuminated on dash ⚠️</strong></p>
                          <p>Diagnosis: Passenger rear seat belt - resistance too high</p>
                          <p>We removed the rear quarter panel and found a disconnected seat belt with a resistor in its place! This is a serious safety issue that was hidden from the initial purchase inspection.</p>
                          <h3>Other Work:</h3>
                          <ul>
                            <li>Audi A4 - Diagnostics and coilover adjustment</li>
                            <li>Mercedes A150 - Annual service</li>
                            <li>BMW 3 series M Sport - Light fault traced to burnt out earth</li>
                          </ul>
                          <p>Pre-purchase inspections can save you from expensive surprises. Get your peace of mind before committing to a purchase.</p>",
                FeaturedImage = "/images/case-studies/audi-q5-bonnet-up.jpg",
                Images = "['/images/case-studies/audi-q5-bonnet-up.jpg','/images/case-studies/disconnected-seatbelt.jpg','/images/case-studies/audi-a4-coilover.jpg','/images/case-studies/mercedes-service.jpg']",
                ServiceId = 8, // Pre-Purchase Inspection
                IsFeatured = false,
                IsPublished = true,
                DatePublished = DateTime.UtcNow.AddDays(-10)
            },
            new CaseStudy
            {
                Slug = "non-runner-vauxhall-vivaro-starter-motor",
                Title = "Non-Runner Diagnosis - Vauxhall Vivaro",
                Summary = "Diagnosed and repaired a non-running Vauxhall Vivaro with multiple electrical issues",
                Content = @"<p>2010 Vauxhall Vivaro came in this morning as a non-runner.</p>
                          <h3>Diagnosis Process:</h3>
                          <p>Carried out thorough investigation and found multiple fault codes relating to battery voltage. After checking earth connections, found the gearbox earth strap to be loose and not making a full connection.</p>
                          <p>During investigation, we found multiple connections loose throughout the vehicle!</p>
                          <h3>Main Fault:</h3>
                          <p>The primary cause of the vehicle not starting was a faulty starter motor.</p>
                          <h3>Work Completed:</h3>
                          <ul>
                            <li>New starter motor fitted</li>
                            <li>All electrical connections re-tightened</li>
                            <li>Gearbox earth strap secured</li>
                            <li>Full electrical system check</li>
                          </ul>
                          <p>One happy customer back on the road! Proper diagnostics save time and money by identifying all issues, not just the obvious ones.</p>",
                FeaturedImage = "/images/case-studies/vauxhal-vivaro-bonnet-open.jpg",
                Images = "['/images/case-studies/vauxhal-vivaro-bonnet-open.jpg','/images/case-studies/old-and-new-starter-motor.jpg']",
                ServiceId = 1, // Diagnostics
                IsFeatured = false,
                IsPublished = true,
                DatePublished = DateTime.UtcNow.AddDays(-5)
            }
        };

        await context.CaseStudies.AddRangeAsync(caseStudies);
        await context.SaveChangesAsync();
    }
}
