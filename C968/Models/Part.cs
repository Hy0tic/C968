using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C968.Models
{
    public abstract class Part
    {
        public int PartID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        [DisplayName("Inventory")]
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

    }
}
