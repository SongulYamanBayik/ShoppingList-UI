using Shoppinglist_DAL.Abstract;
using Shoppinglist_DAL.Repositories;
using Shoppinglist_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppinglist_DAL.EntityFramework
{
    public class EFToDoListDal:GenericRepository<ToDoList>, IToDoListDal
    {
    }
}
