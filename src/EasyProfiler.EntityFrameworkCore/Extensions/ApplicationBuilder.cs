using EasyProfiler.EntityFrameworkCore.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EasyProfiler.MariaDb.Extensions
{
    /// <summary>
    /// This class includes Application Builder extensions for database migrations.
    /// Implements database migration.
    /// </summary>
    public static class ApplicationBuilder
    {
        /// <summary>
        /// Database migration for SQL Server.
        /// </summary>
        /// <param name="app">
        /// IApplicationBuilder
        /// </param>
        /// <param name="dbContext">
        /// Profiler DbContext
        /// </param>
        public static void ApplyEasyProfiler(this IApplicationBuilder app)
        {
            // TODO: Test if it's working
            foreach (var dbContext in app.ApplicationServices.CreateScope().ServiceProvider.GetServices<ProfilerCoreDbContext>())
                dbContext.Database.Migrate();
        }
    }
}
