﻿using EasyProfiler.Core.Entities;
using EasyProfiler.Core.Helpers.Extensions;
using EasyProfiler.EntityFrameworkCore.Abstractions;
using EasyProfiler.PostgreSQL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using System.Threading.Tasks;

namespace EasyProfiler.PostgreSQL.Interceptors
{
    /// <summary>
    /// Profiler Interceptors.
    /// </summary>
    public class EasyProfilerInterceptors : DbCommandInterceptor
    {
        private readonly IEasyProfilerBaseService<ProfilerDbContext> baseService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public EasyProfilerInterceptors(IEasyProfilerBaseService<ProfilerDbContext> baseService,IHttpContextAccessor httpContextAccessor)
        {
            this.baseService = baseService;
            this.httpContextAccessor = httpContextAccessor;
        }
        /// <summary>
        /// Data reader Disposing.
        /// </summary>
        /// <param name="command">
        /// DbCommand.
        /// </param>
        /// <param name="eventData">
        /// Event data.
        /// </param>
        /// <param name="result">
        /// Interception result.
        /// </param>
        /// <returns></returns>
        public override InterceptionResult DataReaderDisposing(DbCommand command, DataReaderDisposingEventData eventData, InterceptionResult result)
        {
            Task.Run(() => baseService.InsertAsync(new Profiler
            {
                Duration = eventData.Duration.Ticks,
                Query = command.CommandText,
                RequestUrl = httpContextAccessor?.HttpContext?.Request?.Path.Value,
                QueryType = command.FindQueryType()
            }));
            return base.DataReaderDisposing(command, eventData, result);
        }
    }
}
