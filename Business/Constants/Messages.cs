﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    //static koyduğumuzda new lemek gerekmiyor,uygulama boyunca tek instance kullanılıyor
  public static  class Messages
    {
        public static string ProductAdded = "Ürün eklendi";// public ler PascalCase yazılır
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime="Sistem Bakımda";
        public static string ProductsListed="Ürünler listelendi";
    }
}
