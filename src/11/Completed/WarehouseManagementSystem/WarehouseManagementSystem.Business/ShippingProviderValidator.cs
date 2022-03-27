using WarehouseManagementSystem.Domain;
using System.Diagnostics.CodeAnalysis;

namespace WarehouseManagementSystem.Business
{
    public class ShippingProviderValidator
    {
        public static bool
            ValidateShippingProvider(
            [NotNullWhen(true)]
            ShippingProvider? provider)
        {
            if (provider is { FreightCost: > 100 })
            {
                return true;
            }

            return false;
        }
    }
}
