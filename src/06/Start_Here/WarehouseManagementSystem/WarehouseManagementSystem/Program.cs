﻿using WarehouseManagementSystem.Business;
using WarehouseManagementSystem.Domain;
using WarehouseManagementSystem.Domain.Extensions;


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

var cheapestItems = order.LineItems.Where(item => item.Price > 60)
                                   .OrderBy(item => item.Price)
                                   .Take(5);




var instance = new { Order = order.OrderNumber, Items = order.LineItems.Count(), Total = order.LineItems.Sum(x => x.Price) };



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

var isReadyForShipment = (Order order) =>
{
    return order.IsReadyForShipment;
};
var processor = new OrderProcessor
{
    OnOrderInitialized = isReadyForShipment
};

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