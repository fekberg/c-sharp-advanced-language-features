using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Business;
using WarehouseManagementSystem.Domain;

namespace WarehouseManagementSystem
{
    public class OrderLogger
    {
        public OrderLogger()
        {} 

        public void Log(Order order) =>
            Console.WriteLine("Log order creation");
    }
}
