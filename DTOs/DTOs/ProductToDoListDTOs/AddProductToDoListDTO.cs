using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs.ProductToDoListDTOs
{
    public class AddProductToDoListDTO
    {
        public int productID { get; set; }
        public int toDoListID { get; set; }
        public string description { get; set; }
    }
}
