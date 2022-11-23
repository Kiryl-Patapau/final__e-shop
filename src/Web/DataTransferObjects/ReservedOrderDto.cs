namespace Microsoft.eShopWeb.Web.DataTransferObjects;

public class ReservedOrderDto
{
    public string? CustomerEmail { get; set; }

    public IEnumerable<ReservedItemDto>? Items { get; set; }
}
