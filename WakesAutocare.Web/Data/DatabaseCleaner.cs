using Microsoft.EntityFrameworkCore;
using WakesAutocare.Web.Data;

namespace WakesAutocare.Web.Data;

public static class DatabaseCleaner
{
    public static async Task ClearAndReseedCaseStudies(AppDbContext context)
    {
        // Remove existing case studies
        var existingCaseStudies = await context.CaseStudies.ToListAsync();
        if (existingCaseStudies.Any())
        {
            context.CaseStudies.RemoveRange(existingCaseStudies);
            await context.SaveChangesAsync();
        }

        // Reseed with updated data
        await CaseStudySeeder.SeedCaseStudies(context);
    }
}
