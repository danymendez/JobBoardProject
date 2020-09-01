using JobBoard.EN.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobBoard.DAL
{
    public class JobBoardContext : DbContext
    {
        public JobBoardContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

        public JobBoardContext(DbContextOptions<JobBoardContext> options)  
            :base(options)  
        {  
            Database.EnsureCreated();  
        }  

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }


        public DbSet<JobEntity> JobEntity { get; set; }



    }
}
