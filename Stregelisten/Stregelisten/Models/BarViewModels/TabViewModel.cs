using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stregelisten.Models.BarViewModels
{
    public class TabViewModel
    {       
        public int Id { get; set; }            
            
        public string UserId { get; set; }
            
        public bool IsPaid { get; set; }
            
        public DateTime DateTime { get; set; }

        public int Price { get; set; }

    }
}
