using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Stregelisten.Models;

namespace Stregelisten.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
        
            
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        [BindProperty]
        public DbSet<Beverage> Beverages { get; set; }

        [BindProperty]
        public DbSet<Tab> Tabs { get; set; }

        [BindProperty]
        public DbSet<Procurement> Procurements { get; set; }

        public DbSet<Stregelisten.Models.ApplicationUser> ApplicationUser { get; set; }
    }

    public class Beverage
    {
        [BindProperty]
        public int Id { get; set; }

        [JsonProperty("Name")]
        [BindProperty]
        public String Name { get; set; }

        [JsonProperty("Price")]
        [BindProperty]
        public int Price { get; set; }
                
    }   
    
    public class Procurement
    {
        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public int TabId { get; set; }        

        [BindProperty]
        public int BeverageId { get; set; }        

        [JsonProperty("Price")]
        [BindProperty]
        public int Price { get; set; }
    }

    public class Tab
    {
        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public List<Procurement> Procurements { get; set; }

        [BindProperty]
        public int ProcurementId { get; set; }

        [BindProperty]
        public string UserId { get; set; }

        [BindProperty]
        public bool IsPaid { get; set; }

        [BindProperty]
        public DateTime DateTime { get; set; }
    }
    
}
