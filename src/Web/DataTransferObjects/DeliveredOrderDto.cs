namespace Microsoft.eShopWeb.Web.DataTransferObjects;

public class DeliveredOrderDto
{
    public string? RecipientEmail { get; set; }

    public string? ShippingAddress { get; set; }

    public IEnumerable<DeliveredItemDto>? Items { get; set; }

    public decimal FinalPrice { get; set; }
}
