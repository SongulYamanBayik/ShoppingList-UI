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
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void TDelete(Product t)
        {
            _productDal.Delete(t);
        }

        public void TDeleteByStatus(Product t)
        {
            _productDal.DeleteByStatus(t);
        }


        public Product TGetByID(int id)
        {
            return _productDal.Get(x => x.ID == id);
        }

        public void TInsert(Product t)
        {
            _productDal.Insert(t);
        }


        public List<Product> TList()
        {
           return _productDal.List();
        }

        public List<Product> TList(Expression<Func<Product, bool>> filter)
        {
           return _productDal.List(filter);
        }

        public void TUpdate(Product t)
        {
            _productDal.Update(t);
        }
    }
}
