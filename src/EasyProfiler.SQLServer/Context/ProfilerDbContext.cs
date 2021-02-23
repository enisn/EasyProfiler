using EasyProfiler.Core.Entities;
using EasyProfiler.EntityFrameworkCore.Context;
using EasyProfiler.EntityFrameworkCore.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EasyProfiler.SQLServer.Context
{
    /// <summary>
    /// Profiler DbContext.
    /// </summary>
    public class ProfilerDbContext : ProfilerCoreDbContext
    {
        public ProfilerDbContext(DbContextOptions<ProfilerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Profiler>(entity =>
            {
                entity
                    .Property(p => p.Duration)
                    .HasColumnType("bigint");
            });
        }
    }
}
