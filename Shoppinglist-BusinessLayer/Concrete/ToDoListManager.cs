using Shoppinglist_BusinessLayer.Abstract;
using Shoppinglist_DAL.Abstract;
using Shoppinglist_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shoppinglist_BusinessLayer.Concrete
{
    public class ToDoListManager : IToDoListService
    {
        IToDoListDal _toDoListDal;

        public ToDoListManager(IToDoListDal toDoListDal)
        {
            _toDoListDal = toDoListDal;
        }

        public void TDelete(ToDoList t)
        {
            _toDoListDal.Delete(t);
        }

        public void TDeleteByStatus(ToDoList t)
        {
            _toDoListDal.DeleteByStatus(t);
        }

        public ToDoList TGetByID(int id)
        {
            return _toDoListDal.Get(x => x.ID == id);
        }

        public void TInsert(ToDoList t)
        {
            _toDoListDal.Insert(t);
        }

        public List<ToDoList> TList()
        {
           return _toDoListDal.List();
        }

        public List<ToDoList> TList(Expression<Func<ToDoList, bool>> filter)
        {
           return _toDoListDal.List(filter);
        }

        public void TUpdate(ToDoList t)
        {
            _toDoListDal.Update(t);
        }
    }
}
