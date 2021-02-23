using System;
using System.Collections.Generic;
using System.Text;

namespace EasyProfiler.Core.Entities
{
    /// <summary>
    /// SQL Query type.
    /// </summary>
    public enum QueryType
    {
        NONE,
        SELECT,
        INSERT,
        UPDATE,
        DELETE,
        OTHER
    }
}
