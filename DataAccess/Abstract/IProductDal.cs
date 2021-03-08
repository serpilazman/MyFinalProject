using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //Database operations
   public interface IProductDal:IEntityRepository<Product>
    {
        //Aşağıdaki interface metotları default public'tir.Interface'in kendisi değil
       
    }
}


//Code Refactoring