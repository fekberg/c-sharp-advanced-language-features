namespace WarehouseManagementSystem.Domain.Extensions
{
    public static class OrderExtensions
    {
        public static string GenerateReport
            (this Order order)
        {
            return $"ORDER REPORT ({order.OrderNumber})" +
                    $"{Environment.NewLine}" +
                    $"Items: {order.LineItems.Count()}" +
                    $"{Environment.NewLine}" +
                    $"Total: {order.Total}" +
                    $"{Environment.NewLine}";
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
