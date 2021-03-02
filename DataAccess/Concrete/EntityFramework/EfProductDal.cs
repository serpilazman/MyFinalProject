using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)

            //using : IDisposable pattern implementation of C#,kütüphane using i ile aynı şey değil
        {
            using (NorthwindContext context=new NorthwindContext()) //Garbage collector Nortwind'in işi bitince hemen bellekten temizliyor anında bu da performanslı bir yazılım ortaya koymamızı sağlıyor bunu da using sağlıyor
            {
                var addedEntity = context.Entry(entity);//Referansı yakala, NorthwindContext ile bu veriyi(entity) bağla
                addedEntity.State = EntityState.Added;// Durumu ekleme olarak set et
                context.SaveChanges();//Ekleme işlemini yap

            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext()) //Garbage collector Nortwind'in işi bitince hemen bellekten temizliyor anında bu da performanslı bir yazılım ortaya koymamızı sağlıyor bunu da using sağlıyor
            {
                var deletedEntity = context.Entry(entity);//Referansı yakala, NorthwindContext ile bu veriyi(entity) bağla
                deletedEntity.State = EntityState.Deleted;// Durumu silme olarak set et
                context.SaveChanges();//Ekleme işlemini yap

            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter =null )
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList(): context.Set<Product>().Where(filter).ToList();

                //filter == null ? context.Set<Product>().ToList() :

                //context.Set<Product>().Where(filter).ToList();
                //context.Set<Product>().ToList() Product class'ının tüm verilerini alır listeye çevirir,o da zaten veritabanındaki products tablosuna bağlı verileri ordan çeker
                //Verilerin hepsini getir : // Verileri filtreye uygun getir
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext()) //Garbage collector Nortwind'in işi bitince hemen bellekten temizliyor anında bu da performanslı bir yazılım ortaya koymamızı sağlıyor bunu da using sağlıyor
            {
                var updatedEntity = context.Entry(entity);//Referansı yakala, NorthwindContext ile bu veriyi(entity) bağla
                updatedEntity.State = EntityState.Modified;// Durumu güncelleme olarak set et
                context.SaveChanges();//Ekleme işlemini yap

            }
        }
    }
}
