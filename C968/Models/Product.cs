using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C968.Models
{
    public class Product
    {
        public BindingList<Part> AssociatedParts { get; set; }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public void AddAssociatedPart(Part part)
        {
            throw new NotImplementedException();
        }

        public bool RemoveAssociatedPart(int id)
        {
            throw new NotImplementedException();
        }

        public Part LookupAssociatedPart(int id)
        {

            throw new NotImplementedException();
        }

    }
}
