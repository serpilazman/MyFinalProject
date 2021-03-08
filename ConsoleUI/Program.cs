using Business;
using Business.Concrete;
using DataAccess;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{

    //SOLID
    //O-- Open Closed Principle,Yazdığın koda yeni bir özellik ekliyosan mevcuttaki hiç bir koduna dokunamazsın
    class Program
    {
        static void Main(string[] args)
        {
            //Data Transformation Object
            ProductTest();

            //CategoryTest();

            //EmployeeManager employeeManager = new EmployeeManager(new EfEmployeeDal());
            //foreach (var employee in employeeManager.GetAll())
            //{
            //    Console.WriteLine("{0}/{1}/{2}",employee.Id,employee.Name,employee.Surname);
            //}

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetProductDetails())
            {
                Console.WriteLine(product.ProductName+"/"+product.CategoryName);
            }
        }
    }
}
