using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppinglist_EntityLayer.Concrete
{
    public class ProductToDoList
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int ToDoListID { get; set; }
        public string? Description { get; set; }


        public Product product { get; set; }
        public ToDoList toDoList { get; set; }
    }


}
