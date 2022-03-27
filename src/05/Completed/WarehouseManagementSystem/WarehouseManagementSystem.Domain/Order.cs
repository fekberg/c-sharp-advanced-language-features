namespace WarehouseManagementSystem.Domain
{
    public class Order : IEquatable<Order?>
    {
        public Guid OrderNumber { get; init; }
        public ShippingProvider ShippingProvider { get; init; }
        public int Total { get; set; }
        public bool IsReadyForShipment { get; set; } = true;
        public IEnumerable<Item> LineItems { get; set; }

        public Order()
        {
            OrderNumber = Guid.NewGuid();
        }

        public string GenerateReport(string email)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Order);
        }

        public bool Equals(Order? other)
        {
            return other != null &&
                   OrderNumber.Equals(other.OrderNumber) &&
                   EqualityComparer<ShippingProvider>.Default.Equals(ShippingProvider, other.ShippingProvider) &&
                   Total == other.Total &&
                   IsReadyForShipment == other.IsReadyForShipment &&
                   EqualityComparer<IEnumerable<Item>>.Default.Equals(LineItems, other.LineItems);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(OrderNumber, ShippingProvider, Total, IsReadyForShipment, LineItems);
        }

        public static bool operator ==(Order? left, 
            Order? right)
        {
            return EqualityComparer<Order>.Default.Equals(left, right);
        }

        public static bool operator !=(Order? left, 
            Order? right)
        {
            return !(left == right);
        }

        public static implicit operator decimal(Order order) => order.Total;
        public static explicit operator Order(List<Item> items)
        {
            return new() { LineItems = items.ToArray() };
        }
    }









    public class ProcessedOrder : Order { }

    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
    }
}