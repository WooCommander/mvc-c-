using ConsoleAppStart.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SortApp.Models;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        List<Client> Clients;
        List<Employee> Employees;
        MyAppContext db;
        public HomeController()
        {
            db = new MyAppContext();

           
                //Client client1 = new Client { FIO = "Иванов Иван Иванович", NameCompany = "Восток", Adres = "Ленина 2-А", City = "Тирасполь", Index = 3300, Tel = 053325687 };
                //Client client2 = new Client { FIO = "Петров Антон Дмитриевич", NameCompany = "МирПК", Adres = "Восстания 56", City = "Тирасполь", Index = 3300, Tel = 0533569874 };
                //db.Clients.Add(client1);
                //db.Clients.Add(client2);
                //db.SaveChanges();
                //var clients = db.Clients;
                Clients = db.Clients.ToList();
                //Console.WriteLine("Список клиентов:");
                //foreach (Client u in clients)
                //{
                //    Console.WriteLine(u.FIO, u.NameCompany, u.Adres, u.City, u.Index, u.Tel);
                //}
                //Employee employee1 = new Employee { FIO = "Пименов Иван Анатольевич", Adres = "Гагарина 2", Tel = 055338725, NumberOrder = 1 };
                //Employee employee2 = new Employee { FIO = "Агатий Ирина Игоревна", Adres = "25 октября 105", Tel = 07896325, NumberOrder = 2 };
                //db.Employees.Add(employee1);
                //db.Employees.Add(employee2);
                //db.SaveChanges();
                //var employees = db.Employees;
                Employees = db.Employees.ToList();
                //Console.WriteLine("Список Работников:");
                //foreach (Employee x in employees)
                //{
                //    Console.WriteLine(x.FIO, x.Adres, x.Tel, x.NumberOrder);
                //}
                //Orders orders1 = new Orders { }
            
        }
        public ActionResult Index()
        {
            return View();
        }
             
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View(Clients);
        }

        [HttpGet]
        public ActionResult Client()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Client(Client client)
        {
            db.Clients.Add(client);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult ViewClients()
        {
            return View(Clients);
        }

        [HttpGet]
        public ActionResult ViewFor()
        {
            String x = "";
            return View();
        }
        [HttpPost]
        public ActionResult ViewFor(Client model)
        {
            var x = model;

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Index(SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<Client> clients = db.Clients.Include(x => x.NameCompany);

            ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            ViewData["CitySort"] = sortOrder == SortState.CityAsc ? SortState.CityDesc : SortState.CityAsc;
            ViewData["CompSort"] = sortOrder == SortState.CompanyAsc ? SortState.CompanyDesc : SortState.CompanyAsc;

            clients = sortOrder switch
            {
                SortState.NameDesc => clients.OrderByDescending(s => s.Name),
                SortState.CityAsc => clients.OrderBy(s => s.City),
                SortState.CityDesc => clients.OrderByDescending(s => s.City),
                SortState.CompanyAsc => clients.OrderBy(s => s.NameCompany),
                SortState.CompanyDesc => clients.OrderByDescending(s => s.NameCompany),
                _ => clients.OrderBy(s => s.Name),
            };
            return View(await clients.AsNoTracking().ToListAsync());
    }



}
}