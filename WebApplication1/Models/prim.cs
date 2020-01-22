using ConsoleAppStart.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class prim
    {
        public IEnumerable<Client> Client { get; set; }
        public SelectList City { get; set; }
        public SelectList NameCompany { get; set; }
    }
}