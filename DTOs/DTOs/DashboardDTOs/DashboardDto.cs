using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs.DashboardDTOs
{
    public class DashboardDto
    {
        public int ActiveProductCount { get; set; }
        public int PassiveProductCount { get; set; }
        public int CategoryCount { get; set; }
    }
}
