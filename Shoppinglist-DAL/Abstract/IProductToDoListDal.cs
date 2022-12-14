using Shoppinglist_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shoppinglist_DAL.Abstract
{
    public interface IProductToDoListDal:IGenericDal<ProductToDoList>
    {
       List<ProductToDoList> GetToDoListByListID(Expression<Func<ProductToDoList, bool>> filter);
    }
}
