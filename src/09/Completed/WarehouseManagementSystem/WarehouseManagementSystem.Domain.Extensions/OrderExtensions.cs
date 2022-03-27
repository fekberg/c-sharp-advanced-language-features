namespace WarehouseManagementSystem.Domain.Extensions
{
    public static class OrderExtensions
    {
        public static string GenerateReport
            (this Order order)
        {

            var status = order switch
            {
                ShippedOrder => "Already Shipped",

                CancelledOrder => "Cancelled",

                PriorityOrder or 
                ((total: >100, true) /*and not (ShippedOrder or CancelledOrder)*/) => "High Priority Order",

                { Total: >50 and <=100 and not 75 } => "Priority Order",
                // (>50 and <=100, true) => "Priority Order",

                (var total, true) => $"Order is ready {total}",
                (_, false) => "Order is not ready",
                _ => "Order is null!!"
            };

            var shippingProviderStatus =
                (order.ShippingProvider, order.LineItems.Count(), order.IsReadyForShipment)
                switch
                { 
                    (_, >10, true) => "Multiple shipments!",

                    (SwedishPostalServiceShippingProvider, 1, _) 
                    => "Manual pickup required",
                    
                    (_, _, true) => "Ready for shipment",

                    _ => "Not ready for shipment"
                };


            return $"ORDER REPORT ({order.OrderNumber})" +
                    $"{Environment.NewLine}" +
                    $"Items: {order.LineItems.Count()}" +
                    $"{Environment.NewLine}" +
                    $"Total: {order.Total}" +
                    $"{Environment.NewLine}" +
                    $"{status} {shippingProviderStatus}";
        }

        public static string GenerateReport
            (this Order order, string recipient)
        {
            return $"ORDER REPORT ({order.OrderNumber})" +
                    $"{Environment.NewLine}" +
                    $"Items: {order.LineItems.Count()}" +
                    $"{Environment.NewLine}" +
                    $"Total: {order.Total}" +
                    $"{Environment.NewLine}" +
                    $"Send to: {recipient}";
        }

        public static string GenerateReport
            (this (Guid, int, decimal, IEnumerable<Item>) order)
        {
            return $"ORDER REPORT ({order.Item1})" +
                    $"{Environment.NewLine}" +
                    $"Items: {order.Item2}" +
                    $"{Environment.NewLine}" +
                    $"Total: {order.Item3}" +
                    $"{Environment.NewLine}";
        }
    
        public static void Deconstruct(this Order order,
            out Guid orderNumber,
            out decimal totalNumberOfItems,
            out IEnumerable<Item> items,
            out decimal averagePrice)
        {
            orderNumber = order.OrderNumber;
            totalNumberOfItems = order.LineItems.Count();
            items = order.LineItems;
            averagePrice =
                order.LineItems.Average(item => item.Price);
        }
    }
}
