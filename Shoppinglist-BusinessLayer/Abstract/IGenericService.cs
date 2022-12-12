using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shoppinglist_BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        List<T> TList();
        void TInsert(T t);
        void TDelete(T t);
        void TDeleteByStatus(T t);
        void TUpdate(T t);
        List<T> TList(Expression<Func<T, bool>> filter);
        T TGetByID(int id);
    }
}
