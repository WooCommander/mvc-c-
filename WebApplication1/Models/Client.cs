using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStart.model
{
    public class Client
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string NameCompany { get; set; }
        public string Adres { get; set; }
        public int Tel { get; set; }
        public string City { get; set; }
        public int Index { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public Client()
        {
            Orders = new List<Orders>();
        }
    }
}
