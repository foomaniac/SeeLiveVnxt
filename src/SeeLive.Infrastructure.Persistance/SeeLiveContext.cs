using System;

namespace SeeLive.Infrastructure.Persistance
{
    public class SeeLiveContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSql();
    }
}
