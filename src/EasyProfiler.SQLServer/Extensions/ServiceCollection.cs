using EasyProfiler.EntityFrameworkCore.Abstractions;
using EasyProfiler.EntityFrameworkCore.Concrete;
using EasyProfiler.EntityFrameworkCore.Context;
using EasyProfiler.SQLServer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EasyProfiler.SQLServer.Extensions
{
    /// <summary>
    /// Service collection extensions method for DbContext.
    /// </summary>
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
            services.AddTransient<ProfilerCoreDbContext, ProfilerDbContext>();
            services.AddTransient<IEasyProfilerBaseService<ProfilerDbContext>, EasyProfilerBaseManager<ProfilerDbContext>>();
            return services;
        }
    }
}