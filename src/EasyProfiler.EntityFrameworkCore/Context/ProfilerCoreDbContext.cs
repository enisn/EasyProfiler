using EasyProfiler.Core.Entities;
using EasyProfiler.EntityFrameworkCore.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyProfiler.EntityFrameworkCore.Context
{
    public abstract class ProfilerCoreDbContext : DbContext
    {
        public ProfilerCoreDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Profiler> Profilers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Profiler>(entity =>
            {
                entity
                    .HasKey(pk => pk.Id);

                entity
                    .HasIndex(i => i.Duration);

                entity
                    .Property(p => p.Id)
                    .HasValueGenerator<GuidGenerator>()
                    .ValueGeneratedOnAdd();

                entity
                    .Property(p => p.Query)
                    .IsRequired();

                entity
                    .Property(p => p.QueryType)
                    .IsRequired()
                    .HasConversion(new EnumToStringConverter<QueryType>());

            });
        }
    }
}
