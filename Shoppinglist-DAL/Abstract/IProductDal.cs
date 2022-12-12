using Microsoft.EntityFrameworkCore;
using Shoppinglist_DAL.Concrete;
using Shoppinglist_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppinglist_DAL.Abstract
{
    public interface IProductDal:IGenericDal<Product>
    {
    }
}
