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
    public class ProductToDoManager : IProductToDoListService
    {
        IProductToDoListDal _productToDoListDal;

        public ProductToDoManager(IProductToDoListDal productToDoListDal)
        {
            _productToDoListDal = productToDoListDal;
        }

        public void TDelete(ProductToDoList t)
        {
            _productToDoListDal.Delete(t);
        }

        public void TDeleteByStatus(ProductToDoList t)
        {
            _productToDoListDal.DeleteByStatus(t);
        }

        public ProductToDoList TGetByID(int id)
        {
            return _productToDoListDal.Get(x => x.ID == id);
        }

        public List<ProductToDoList> TGetToDoListByListID(Expression<Func<ProductToDoList, bool>> filter)
        {
            return _productToDoListDal.GetToDoListByListID(filter);
        }

        public void TInsert(ProductToDoList t)
        {
            _productToDoListDal.Insert(t);
        }

        public List<ProductToDoList> TList()
        {
           return _productToDoListDal.List();
        }

        public List<ProductToDoList> TList(Expression<Func<ProductToDoList, bool>> filter)
        {
            return _productToDoListDal.List(filter);
        }

        public void TUpdate(ProductToDoList t)
        {
            _productToDoListDal.Update(t);
        }
    }
}
