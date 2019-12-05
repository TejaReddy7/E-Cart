using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using E_Cart.WebSite.Models;

namespace E_Cart.WebSite.Models
{
    public class ECartDbContext : DbContext
    {

        public ECartDbContext(DbContextOptions<ECartDbContext> options) : base(options)
        {
            //var siteSettings = this.GetInfrastructure().GetRequiredService<IOptionsSnapshot<SiteSettings>>();
        }

        public ECartDbContext()
        { }

        public DbSet<Products> Products { get; set; }
        public DbSet<Sellers> Sellers { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<SellerAccounts> SellerAccounts { get; set; }
        public DbSet<Shipments> Shipments { get; set; }
        public DbSet<Users> Users { get; set; }
        
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Products>().HasData(new Products { });
        //}


    }
}
