using Microsoft.eShopWeb.Web.DataTransferObjects;

namespace Microsoft.eShopWeb.Web.Interfaces;

public interface IDeliveryService
{
    Task SaveOrder(DeliveredOrderDto order);
}
