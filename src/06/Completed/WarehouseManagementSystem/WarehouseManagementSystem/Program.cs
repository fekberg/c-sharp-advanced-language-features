using System.Text.Json;
using WarehouseManagementSystem.Business;
using WarehouseManagementSystem.Domain;
using WarehouseManagementSystem.Domain.Extensions;

#region Load the orders from orders.json
IEnumerable<Order> orders = JsonSerializer.Deserialize<Order[]>(File.ReadAllText("orders.json"));
#endregion

var isReadyForShipment = (Order order) =>
{
    return order.IsReadyForShipment;
};
var processor = new OrderProcessor
{
    OnOrderInitialized = isReadyForShipment
};

Order order = new Order 
{
    LineItems = new[]
    {
        new Item { Name = "PS1", Price = 50 },
        new Item { Name = "PS2", Price = 60 },
        new Item { Name = "PS4", Price = 70 },
        new Item { Name = "PS5", Price = 80 }
    }
};

processor.Process(orders);






// Modifying and Returning Anonymous Types 
var result = processor.Process(orders);

var type = result.GetType();
var properties = type.GetProperties();

foreach(var property in properties)
{
    Console.WriteLine($"Property: {property.Name}");
    Console.WriteLine($"Value: {property.GetValue(result)}");
}

Console.ReadLine();

// Introducing Anonymous Types
var subset = new 
{ 
    order.OrderNumber, 
    order.Total,
    AveragePrice = order.LineItems.Average(item => item.Price)
};

Console.WriteLine($"Average Price {subset.AveragePrice}");

Console.ReadLine();

var instance = new { Total = 100, AmountOfItems = 10 };

var secondInstance = new { Total = 100, AmountOfItems = 10 };

Console.WriteLine(instance.Equals(secondInstance));
Console.WriteLine(instance == secondInstance);

Console.ReadLine();

// Real-World Implementations of Extension Methods
var cheapestItems = order.LineItems.Where(item => item.Price > 60)
                                   .OrderBy(item => item.Price)
                                   .Take(5);
Console.ReadLine();

// Creating an Extension Method Library
var report = order.GenerateReport(recipient: "Filip Ekberg");
Console.WriteLine(report);


Console.ReadLine();

// Creating an Extension Method for IEnumerable<T> 
foreach (var item in order.LineItems.Find(item => item.Price > 60))
{
    Console.WriteLine(item.Price);
}

processor.OrderCreated += (sender, args) =>
{

};

processor.OrderCreated += Log;

processor.Process(order);


void Log(object sender, EventArgs args)
{
    Console.WriteLine("Log method call");
}

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