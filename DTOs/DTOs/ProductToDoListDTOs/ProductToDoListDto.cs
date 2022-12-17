using Shoppinglist_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs.ProductToDoListDTOs
{
    public class ProductToDoListDto
    {
        public List<Product> products { get; set; }
        public List<ProductToDoList> selectedListItems { get; set; }
        public List<ToDoList> toDoLists { get; set; }
        public int toDoListID { get; set; }

    }
}
