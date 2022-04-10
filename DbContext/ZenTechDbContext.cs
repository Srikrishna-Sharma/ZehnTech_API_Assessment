using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZehnTech_API_Assessment.DTOs;
using ZehnTech_API_Assessment.Repositories.Domain;

namespace ZehnTech_API_Assessment.DbContextFile 
{
    public class ZenTechDbContext : DbContext
    {
        public ZenTechDbContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductInformation> ProductInformation { get; set; }
    }
}
