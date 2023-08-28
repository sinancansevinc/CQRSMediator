﻿using CQRSMediator.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediator.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        
        public DbSet<Product> Products { get; set; }
    }
}
