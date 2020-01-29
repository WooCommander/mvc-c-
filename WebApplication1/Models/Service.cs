﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStart.model
{
   public class Service
   {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public ICollection<Order> Orders { get; set; }
        public Service()
        {
            Orders = new List<Order>();
        }
    }
}
