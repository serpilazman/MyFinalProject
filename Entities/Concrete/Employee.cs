using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
  public  class Employee:IEntity
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
    }
}
