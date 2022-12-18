using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppinglist_EntityLayer.Concrete
{
    public class ToDoList
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool ShoppingStatus { get; set; }


        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
        public List<ProductToDoList> ProductToDoLists { get; set; }
    }
}
