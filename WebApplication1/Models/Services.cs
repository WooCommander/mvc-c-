using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStart.model
{
   public  class Services
    {
        public int Id { get; set; }
        public string NameSercvice { get; set; }
        public int PrceService { get; set; }
        public int ServiceCode { get; set; }
        public ICollection<ServiceOrder> ServiceOrders { get; set; }
        public Services()
        {
            ServiceOrders = new List<ServiceOrder>();
        }

    }
}
