using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {

        //bu class için tanımlanmış global değişken alt çizgi ile oluşturulur.Class'ın içinde metotların dışında tanımlanır.
        //Bu da .NET projelerinde genellikle kullanılan bir isimlendirme standardı,Naming Convension
        List<Product> _products; //Referans tip

        //ctor tab tab
        public InMemoryProductDal()//Constructor--Class'ın adı void veya değer döndüren cir yapıda olmaz--Bellekte referans alındığında çalışacak olan blok
        {
            _products = new List<Product> {  //İşte burada bir referans alan oluştu
            new Product{ProductID=1,CategoryID=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
            new Product{ProductID=2,CategoryID=2,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
            new Product{ProductID=3,CategoryID=3,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
            new Product{ProductID=4,CategoryID=4,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
            new Product{ProductID=5,CategoryID=5,ProductName="Fare",UnitPrice=85,UnitsInStock=1},
            };
        }
        
        
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {

            Product productToDelete= _products.SingleOrDefault(p => p.ProductID == product.ProductID);//foreach Deki p gibi elemanları tek tek döner
                     
            _products.Remove(productToDelete);

            //Burası silme işlemi yapmaz çünkü referans tip gelen product bilgisini farklı bellek bölgesi ile gösterir
            //Bu sebeple product ın Id'sini tutan adres referansını yakalamamız lazım
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()  //Business kaymanına veri gönderme
        {
            return _products;//Veritabanı olduğu gibi döner
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p=>p.CategoryID==categoryId).ToList();//Gelen categoryId ile aynı olan categoryId'li productları bir liste yapar

        }

        public void Update(Product product)
        {
            //Gönderilen ürün Id'sine sahip olan listedeki ürünü Id'sini bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductID == product.ProductID);//Güncellenecek referansı bulduğumuz yer
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.ProductID = product.ProductID;
            productToUpdate.CategoryID = product.CategoryID;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
