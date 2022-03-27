using WarehouseManagementSystem.Domain;

namespace WarehouseManagementSystem.Business
{
    public class OrderProcessCompletedEventArgs
    {
        public Order? Order { get; set; }
    }
}