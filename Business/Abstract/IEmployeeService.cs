using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
  public  interface IEmployeeService
    {
        List<Employee> GetAll();
    }
}
