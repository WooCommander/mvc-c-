using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStart.model
{
   public class Order
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int NumberOrder { get; set; }
        public string NameOrder { get; set; }
        public DateTime DateOrder { get; set; }
        public int IdEmployee { get; set; }
        public int IdClient { get; set; }
        public ICollection<Client> Clients { get; set; } 
        public Client Client { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public Employee Employee { get; set; }
        public int Srok { get; set; }
        public ICollection<ServiceOrder> ServiceOrders { get; set; }
        public ICollection<Contract> Contracts { get; set; }
        public Order()
        {
            ServiceOrders = new List<ServiceOrder>();
            Contracts = new List<Contract>();
        }
        
    }
}
