using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppinglist_EntityLayer.Concrete
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }


        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public List<ProductToDoList> ProductToDoLists { get; set; }
    }
}
