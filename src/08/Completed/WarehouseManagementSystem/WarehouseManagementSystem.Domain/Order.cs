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
        public static bool operator ==(Order? left, Order? right)
        {
            return EqualityComparer<Order>.Default.Equals(left, right);
        }
        public static bool operator !=(Order? left, Order? right)
        {
            return !(left == right);
        }

        public static implicit operator decimal(Order order) => order.Total;
        public static explicit operator Order(List<Item> items)
        {
            return new() { LineItems = items.ToArray() };
        }
        
        public void Deconstruct(out decimal total,
            out bool ready)
        {
            total = Total;
            ready = IsReadyForShipment;
        }

        public void Deconstruct(out decimal total,
            out bool ready,
            out IEnumerable<Item> items)
        {
            total = Total;
            ready = IsReadyForShipment;
            items = LineItems;
        }
    
    }

    public class PriorityOrder : Order { }

    public class ShippedOrder : Order 
    {
        public DateTime ShippedDate { get; set; }
    }

    public class CancelledOrder : Order
    {
        public DateTime CancelledDate { get; set; }
    }










    public class ProcessedOrder : Order { }

    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
    }
}