﻿using EasyProfiler.EntityFrameworkCore.Abstractions;
using EasyProfiler.PostgreSQL.Context;
using EasyProfiler.PostgreSQL.Interceptors;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EasyProfiler.PostgreSQL.Extensions
{
    /// <summary>
    /// Interception extension method for dbcontext.
    /// </summary>
    public static class Interception
    {
        /// <summary>
        /// Add easy profiler for interceptions.
        /// </summary>
        /// <param name="optionsBuilder">
        /// DbContextOptionsBuilder
        /// </param>
        /// <returns>
        /// DbContextOptionsBuilder.
        /// </returns>
        public static DbContextOptionsBuilder AddEasyProfiler(this DbContextOptionsBuilder optionsBuilder, IServiceCollection services)
        {
            var buildServices = services.BuildServiceProvider();
            optionsBuilder.AddInterceptors(new EasyProfilerInterceptors(buildServices.GetService<IEasyProfilerBaseService<ProfilerDbContext>>(),buildServices.GetService<IHttpContextAccessor>()));
            return optionsBuilder;
        }
    }
}
