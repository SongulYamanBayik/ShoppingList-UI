using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppinglist_EntityLayer.Concrete
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public bool Status { get; set; }


        public List<Product> Products { get; set; }
    }
}
