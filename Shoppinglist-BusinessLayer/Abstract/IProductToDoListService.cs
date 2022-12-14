using Shoppinglist_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shoppinglist_BusinessLayer.Abstract
{
    public interface IProductToDoListService:IGenericService<ProductToDoList>
    {
        List<ProductToDoList> TGetToDoListByListID(Expression<Func<ProductToDoList, bool>> filter);

    }
}
