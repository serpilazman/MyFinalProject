using Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //generic constraint --cenerik kısıt-- where T:class
    //class : referans tip olabilir manasında
    //IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir
    //new() : new'lenebilir olmalı--Burada IEntity interface'ini kullanılamaz yapıyoruz,yani IEntity implemente eden bir nesne olabilir-->Category,Customer,Product
    //Böylelikle sistem veritabanı nesneleriyle çalışan bir repository oldu
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
       // T-- Generic repository design pattern
        List<T> GetAll(Expression<Func<T,bool>> filter=null);//(1) içerisi productManager'da GetAll(p=>p.CategoryId==2) gibi bir şart verebilmemizi sağlar,null filtre vermeyebilirsin demek yani tüm data yı istiyor anlamına gelir

        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        // List<T> GetAllByCategory(int categoryId); //(1) sayesinde artık buraya ihtiyacımız kalmadı,her zaman Id istenmeyebilir
    }
}
