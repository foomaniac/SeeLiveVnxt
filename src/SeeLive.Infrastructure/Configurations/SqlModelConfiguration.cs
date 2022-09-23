using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SeeLive.Abstractions;

namespace SeeLive.Infrastructure.Configurations
{
    internal class SqlModelConfiguration : IModelConfiguration
    {
        public void ConfigureModel(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlModelConfiguration).Assembly);
        }
    }
}
