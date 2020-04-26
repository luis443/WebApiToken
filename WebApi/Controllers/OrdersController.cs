using ClaseModelo.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class OrdersController : ApiController
    {
        NorthwindEntities NorthwindDB = new NorthwindEntities();

        [HttpGet]
        public List<Orders> Get()
        {
            List<Orders> lista = new List<Orders>();
            lista = NorthwindDB.Orders.ToList();
            return lista;
        }
        [HttpGet]
        public Orders Get(int id)
        {
            Orders orden = new Orders();
            orden = NorthwindDB.Orders.FirstOrDefault(x => x.EmployeeID == id);
            return orden;
        }
        [HttpPost]
        public bool Post(Orders orders)
        {
            NorthwindDB.Orders.Add(orders);
            //esta es prueba
            return NorthwindDB.SaveChanges() > 0;
            
        }
        [HttpPut]
        public bool Put(Orders orders)
        {
            var OrdenEdit = NorthwindDB.Orders.FirstOrDefault(x => x.OrderID == orders.OrderID);
            OrdenEdit.ShipName = orders.ShipName;           
            OrdenEdit.ShipAddress = orders.ShipAddress;
            OrdenEdit.ShipCity = orders.ShipCity;
            return NorthwindDB.SaveChanges() > 0;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            var OrdenEliminar = NorthwindDB.Orders.FirstOrDefault(x => x.OrderID == id);
            NorthwindDB.Orders.Remove(OrdenEliminar);
            return NorthwindDB.SaveChanges() > 0;
        }
    }
}
