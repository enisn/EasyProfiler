﻿using EasyProfiler.EntityFrameworkCore.Abstractions;
using EasyProfiler.EntityFrameworkCore.Concrete;
using EasyProfiler.PostgreSQL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EasyProfiler.PostgreSQL.Extensions
{
    public static class ServiceCollection
    {
        /// <summary>
        /// Add DbContext for EasyProfiler.
        /// </summary>
        /// <param name="services">
        /// Service collection.
        /// </param>
        /// <param name="optionsBuilder">
        /// DbContextOptionsBuilder.
        /// </param>
        /// <returns>
        /// Service Collection.
        /// </returns>
        public static IServiceCollection AddEasyProfilerDbContext(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsBuilder)
        {
            services.AddDbContext<ProfilerDbContext>(optionsBuilder);
            services.AddTransient<IEasyProfilerBaseService<ProfilerDbContext>, EasyProfilerBaseManager<ProfilerDbContext>>();
            return services;
        }
    }
}
