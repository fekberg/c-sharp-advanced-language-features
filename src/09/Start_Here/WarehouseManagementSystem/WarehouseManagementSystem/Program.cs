﻿using System.Text.Json;
using WarehouseManagementSystem.Business;
using WarehouseManagementSystem.Domain;
using WarehouseManagementSystem.Domain.Extensions;


var isReadyForShipment = (Order order) =>
{
    return order.IsReadyForShipment;
};

Order order = new CancelledOrder
{
    ShippingProvider = new ShippingProvider() { FreightCost = 500},
    LineItems = new[]
    {
        new Item { Name = "PS1", Price = 50 },
        new Item { Name = "PS2", Price = 60 },
        new Item { Name = "PS4", Price = 70 },
        new Item { Name = "PS5", Price = 80 }
    },
    Total = 101
};

var result = order switch
{
    PriorityOrder when HasAvailability() => "",
    _ => ""
};

bool HasAvailability() => true;

Console.WriteLine(order.GenerateReport());

Console.ReadLine();
















#region Load the orders from orders.json
IEnumerable<Order> orders = JsonSerializer.Deserialize<Order[]>(File.ReadAllText("orders.json"));
#endregion

var processor = new OrderProcessor
{
    OnOrderInitialized = isReadyForShipment
};




// Deconstruct Other Objects 
var (orderTotal, isReady) = order;

var dictionary = new Dictionary<string, Order>();

foreach (var (orderId, theOrder) in dictionary)
{

}

// Using Tuples as Return Types or Parameters
foreach (var summary in processor.Process(orders))
{
    Console.WriteLine(summary.GenerateReport());
}

// Tuple elements ignored because of the names
(Guid id, int total) GetSummary()
{
    return (orderId: Guid.Empty, orderTotal: 10);
}

var (id, items, total, _) = processor.Process(orders).First();

Action<(Guid id, int amountOfItems)> log = (tuple) =>
{

};

var first = processor.Process(orders).First();

var second = first with { amountOfItems = 0 };

Console.WriteLine($"Are these equal? {first == second}");

Console.ReadLine();

// Tuple Assignment and Deconstruction 
Guid orderNumber;
decimal sum;

(orderNumber, _, sum) =
    (order.OrderNumber,
    order.LineItems,
    order.LineItems.Sum(item => item.Price));

// Introducing Tuples 
var group = (order.OrderNumber, order.LineItems, order.LineItems.Sum(item => item.Price));
var groupAsAnonymousType = new
{
    order.OrderNumber,
    order.LineItems,
    Sum = order.LineItems.Sum(item => item.Price)
};

var json = JsonSerializer.Serialize(group,
options: new() { IncludeFields = true, WriteIndented = true });

Console.WriteLine(json);

Console.ReadLine();

// Modifying and Returning Anonymous Types 
var result2 = processor.Process(orders);

var type = result2.GetType();
var properties = type.GetProperties();

foreach (var property in properties)
{
    Console.WriteLine($"Property: {property.Name}");
    Console.WriteLine($"Value: {property.GetValue(result2)}");
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