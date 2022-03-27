using WarehouseManagementSystem.Domain;

namespace WarehouseManagementSystem.Business
{
    public class OrderProcessor
    {
        public Func<Order, bool> OnOrderInitialized { get; set; }

        public event EventHandler<OrderCreatedEventArgs> OrderCreated;
        public event EventHandler<OrderProcessCompletedEventArgs> OrderProcessCompleted;
        protected virtual void OnOrderCreated(OrderCreatedEventArgs args)
        {
            OrderCreated?.Invoke(this, args);
        }

        protected virtual void OnOrderProcessCompleted(OrderProcessCompletedEventArgs args)
        {
            OrderProcessCompleted?.Invoke(this, args);
        }

        private void Initialize(Order order)
        {
            ArgumentNullException.ThrowIfNull(order);

            if (OnOrderInitialized?.Invoke(order) == false)
            {
                throw new Exception($"Couldn't initialize {order.OrderNumber}");
            }
        }

        public void Process(Order order)
        {
            Initialize(order);

            OnOrderCreated(new()
            {
                Order = order,
                OldTotal = 100,
                NewTotal = 80
            });

            OnOrderProcessCompleted(new() { Order = order });
        }
    }
}