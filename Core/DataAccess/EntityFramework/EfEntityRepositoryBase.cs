using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace Core.DataAccess.EntityFramework
{
   public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>

    where TEntity : class, IEntity, new()
    where TContext :DbContext,new()
    {
        public void Add(TEntity entity)

        //using : IDisposable pattern implementation of C#,kütüphane using i ile aynı şey değil
        {
            using (TContext context = new TContext()) //Garbage collector Nortwind'in işi bitince hemen bellekten temizliyor anında bu da performanslı bir yazılım ortaya koymamızı sağlıyor bunu da using sağlıyor
            {
                var addedEntity = context.Entry(entity);//Referansı yakala, NorthwindContext ile bu veriyi(entity) bağla
                addedEntity.State = EntityState.Added;// Durumu ekleme olarak set et
                context.SaveChanges();//Ekleme işlemini yap

            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext()) //Garbage collector Nortwind'in işi bitince hemen bellekten temizliyor anında bu da performanslı bir yazılım ortaya koymamızı sağlıyor bunu da using sağlıyor
            {
                var deletedEntity = context.Entry(entity);//Referansı yakala, NorthwindContext ile bu veriyi(entity) bağla
                deletedEntity.State = EntityState.Deleted;// Durumu silme olarak set et
                context.SaveChanges();//Ekleme işlemini yap

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();

                //filter == null ? context.Set<Product>().ToList() :

                //context.Set<Product>().Where(filter).ToList();
                //context.Set<Product>().ToList() Product class'ının tüm verilerini alır listeye çevirir,o da zaten veritabanındaki products tablosuna bağlı verileri ordan çeker
                //Verilerin hepsini getir : // Verileri filtreye uygun getir
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext()) //Garbage collector Nortwind'in işi bitince hemen bellekten temizliyor anında bu da performanslı bir yazılım ortaya koymamızı sağlıyor bunu da using sağlıyor
            {
                var updatedEntity = context.Entry(entity);//Referansı yakala, NorthwindContext ile bu veriyi(entity) bağla
                updatedEntity.State = EntityState.Modified;// Durumu güncelleme olarak set et
                context.SaveChanges();//Ekleme işlemini yap

            }
        }
    }
}
