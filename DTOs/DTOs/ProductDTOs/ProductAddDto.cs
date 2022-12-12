using Shoppinglist_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.DTOs.ProductDTOs
{
    public class ProductAddDto
    {
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }

    }
}
