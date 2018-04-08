using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stregelisten.Data
{
    public static class Seeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            if (!context.Beverages.Any())
            {
                context.Beverages.Add(new Beverage() { Name = "Øl", Price = 10  });
                context.Beverages.Add(new Beverage() { Name = "Sodavand", Price = 5 });
                context.Beverages.Add(new Beverage() { Name = "Shot", Price = 5 });
                context.SaveChanges();
            }
        }
    }
}
