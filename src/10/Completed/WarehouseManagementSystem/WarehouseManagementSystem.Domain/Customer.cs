namespace WarehouseManagementSystem.Domain
{
    public record Customer(string Firstname, 
        string Lastname)
    {
        public string Fullname => $"{Firstname} {Lastname}";
    
        public Address Address { get; init; }
    }

    public record Address(string street, string postalCode);

    public record PriorityCustomer
        (string Firstname, string Lastname) 
        : Customer(Firstname, Lastname);
}
