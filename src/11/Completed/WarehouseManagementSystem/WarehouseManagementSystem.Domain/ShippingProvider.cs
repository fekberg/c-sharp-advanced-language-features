namespace WarehouseManagementSystem.Domain
{
    public class ShippingProvider
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal FreightCost { get; set; }
    }

    public class SwedishPostalServiceShippingProvider : ShippingProvider
    {
        public bool DeliverNextDay { get; set; }
    }
}