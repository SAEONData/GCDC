using GCDC_API.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCDC_API.EntityFramework
{
    public class SqlDbContext : DbContext
    {
        public DbSet<DownloadLog> DownloadLogs { get; set; }

        public SqlDbContext() : base() { }

        public SqlDbContext(DbContextOptions options) : base(options) {}
    }
}
