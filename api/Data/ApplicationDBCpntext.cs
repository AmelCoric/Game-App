using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBCpntext : DbContext
    {
        public ApplicationDBCpntext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }
        public DbSet<Game>Game{get;set;}
        public DbSet<Category>Categories{get;set;}
    }

}