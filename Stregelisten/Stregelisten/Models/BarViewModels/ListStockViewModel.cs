using Microsoft.EntityFrameworkCore;
using Stregelisten.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stregelisten.Models.BarViewModels
{
    public class ListStockViewModel
    {
        public IEnumerable<Beverage> BeverageFromDB { get; set; }

        public IEnumerable<Beverage> beveragesToProcure { get; set; }
               
    }
    
}
