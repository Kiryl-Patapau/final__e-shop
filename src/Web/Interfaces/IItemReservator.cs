using Microsoft.eShopWeb.Web.DataTransferObjects;

namespace Microsoft.eShopWeb.Web.Interfaces;

public interface IItemReservator
{
    Task Reserve(ReservedOrderDto order);
}
