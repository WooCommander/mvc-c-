using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStart.model
{
  public  class Employee
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Adres { get; set; }
        public int Tel { get; set; }
        public int NumberOrder { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public Employee()
        {
            Orders = new List<Orders>();
        }
    }
}
