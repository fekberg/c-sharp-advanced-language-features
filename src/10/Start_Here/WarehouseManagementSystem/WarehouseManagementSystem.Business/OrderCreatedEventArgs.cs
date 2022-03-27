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
        public Order Order { get; set; }
        public decimal OldTotal { get; set; }
        public decimal NewTotal { get; set; }
    }
}
