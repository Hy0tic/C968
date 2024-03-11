using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C968.Models
{
    public class Inventory
    {
        public BindingList<Product> Products { get; set; }
        public BindingList<Part> Parts { get; set; }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public bool RemoveProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Product LookupProduct(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(int id, Product product)
        {
            throw new NotImplementedException();
        }

        public void AddPart(Part part)
        {
            throw new NotImplementedException("AddPart method is not implemented.");
        }

        public bool DeletePart(Part part)
        {
            throw new NotImplementedException("DeletePart method is not implemented.");
        }

        public Part LookupPart(int partId)
        {
            throw new NotImplementedException("LookupPart method is not implemented.");
        }

        public void UpdatePart(int partId, Part newPart)
        {
            throw new NotImplementedException("UpdatePart method is not implemented.");
        }
    }
}
