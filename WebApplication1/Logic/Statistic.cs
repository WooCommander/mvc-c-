using ConsoleAppStart.model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Statistic
    {
        List<IServiceView> listServices;
        public  Statistic()
        {
            listServices = new List<IServiceView>();
        }

        public List<IServiceView>  getListServices() {

            MyAppContext db = new MyAppContext();
            var result = db.Orders.GroupBy(item1 => item1.Service).Select(item => new  { Name = item.Key.Name, Count = item.Count() }).ToList();
            return result;
        }


    }
}