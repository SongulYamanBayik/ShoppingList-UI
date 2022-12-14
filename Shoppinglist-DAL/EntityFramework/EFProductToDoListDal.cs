using Shoppinglist_DAL.Abstract;
using Shoppinglist_DAL.Concrete;
using Shoppinglist_DAL.Repositories;
using Shoppinglist_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shoppinglist_DAL.EntityFramework
{
    public class EFProductToDoListDal : GenericRepository<ProductToDoList>, IProductToDoListDal
    {
        Context context = new Context();

        List<ProductToDoList> IProductToDoListDal.GetToDoListByListID(Expression<Func<ProductToDoList, bool>> filter)
        {
            return context.ProductToDoLists.Where(filter).ToList();
        }
    }
}
