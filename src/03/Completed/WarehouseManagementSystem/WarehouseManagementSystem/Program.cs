using WarehouseManagementSystem.Business;
using WarehouseManagementSystem.Domain;

var order = new Order
{
    LineItems = new[]
    {
        new Item { Name = "PS1", Price = 50 },
        new Item { Name = "PS2", Price = 60 },
        new Item { Name = "PS4", Price = 70 },
        new Item { Name = "PS5", Price = 80 }
    }
};

var isReadyForShipment = (Order order) =>
{
    return order.IsReadyForShipment;
};

var processor = new OrderProcessor
{
    OnOrderInitialized = isReadyForShipment
};

var onCompleted = (Order order) =>
{
    Console.WriteLine($"Processed {order.OrderNumber}");
}; 

processor.Process(order, onCompleted);











bool SendMessageToWarehouse(Order order)
{
    Console.WriteLine($"Please pack the order {order.OrderNumber}");

    return true;
}

void SendConfirmationEmail(Order order)
{
    Console.WriteLine($"Order Confirmation Email for {order.OrderNumber}");
}

Console.ReadLine();