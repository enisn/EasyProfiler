﻿using EasyProfiler.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.SQLServer.Context
{
    /// <summary>
    /// Profiler DbContext.
    /// </summary>
    internal class ProfilerDbContext : DbContext
    {
        internal ProfilerDbContext(DbContextOptions options) : base(options)
        {
        }

        internal ProfilerDbContext()
        {
        }
        #region Tables
        public virtual DbSet<Profiler> Profilers { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
