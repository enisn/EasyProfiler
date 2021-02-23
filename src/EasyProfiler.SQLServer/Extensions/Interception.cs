using EasyProfiler.EntityFrameworkCore.Abstractions;
using EasyProfiler.SQLServer.Context;
using EasyProfiler.SQLServer.Interceptors;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EasyProfiler.SQLServer.Extensions
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
            optionsBuilder.AddInterceptors(new EasyProfilerInterceptors(buildServices.GetService<IEasyProfilerBaseService<ProfilerDbContext>>(), buildServices.GetService<IHttpContextAccessor>()));
            return optionsBuilder;
        }
    }
}
