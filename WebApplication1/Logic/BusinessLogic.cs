using ConsoleAppStart.model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStart.Logic
{
    class BusinessLogic
    {
        MyAppContext db;
        public BusinessLogic()
        {
            db = new MyAppContext();
        }
        /// <summary>
        /// Получить список клиентов
        /// </summary>
        /// <param name="Name">Имя компании</param>
        /// <returns></returns>
        public List<Client> GetClients(string Name = "")
        {
            if (Name == "")
            {
                return db.Clients.ToList<Client>();
            }
            else
            {
                return db.Clients.Where(item => item.NameCompany.IndexOf(Name) > -1).ToList<Client>();
            }
        }
        public string GetStringClient(Client client)
        {
            return $"Имя компании:{client.NameCompany}\tИмя клиента:{client.FIO}";
        }
        /// <summary>
        /// Добавить клиента в базу данных
        /// </summary>
        /// <param name="client">Клиент</param>
        public void AddClient(Client client)
        {
            //проверка 
            db.Clients.Add(client);
            db.SaveChanges();
        }
        public void RemoveClient(int id)
        {
           Client c1 = db.Clients.Where(x => x.Id == id).First();
            if (c1 != null)
            {
                db.Clients.Remove(c1);
                db.SaveChanges();
            }

        }
        public void Sum (int k)
        {
            k = db.Orders.Sum(x => x.Srok);
        }
       


    }
}
