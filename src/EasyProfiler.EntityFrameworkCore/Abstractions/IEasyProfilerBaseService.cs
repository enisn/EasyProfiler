using EasyProfiler.Core.Entities;
using EasyProfiler.Core.Helpers.AdvancedQuery;
using EasyProfiler.Core.Helpers.Responses;
using EasyProfiler.EntityFrameworkCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyProfiler.EntityFrameworkCore.Abstractions
{
    public interface IEasyProfilerBaseService<TDbContext> where TDbContext : ProfilerCoreDbContext
    {
        Task InsertAsync(Profiler profiler);

        Task<List<Profiler>> AdvancedFilterAsync(AdvancedFilterModel advancedFilterModel);

        Task<List<SlowestEndpointResponseModel>> GetSlowestEndpointsAsync();
    }
}
