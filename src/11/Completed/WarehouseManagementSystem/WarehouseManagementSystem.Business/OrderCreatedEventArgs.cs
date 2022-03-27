using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Domain;

namespace WarehouseManagementSystem.Business
{
    public class OrderCreatedEventArgs : EventArgs
    {
        public Order Order { get; init; }
        public decimal OldTotal { get; set; }
        public decimal NewTotal { get; set; }

        public OrderCreatedEventArgs(Order order)
        {
            Order = order;
        }
    }
}
