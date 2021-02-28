using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    //İş katmanının somut sınıfı
    public class ProductManager : IProductService
    {
        IProductDal _productDal;// Aşağıdaki kullanım yerine bu kullanım ile injection yapıyoruz

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }



        public List<Product> GetAll()
        {
            //İş kodları
            // InMemoryProductDal ınMemoryProductDal = new InMemoryProductDal(); Bir iş sınıfı başka sınıfları new'lemez


            //Yetkisi var mı?
            return _productDal.GetAll();//Veritabanından ürünler geliyor
        }
    }
}
