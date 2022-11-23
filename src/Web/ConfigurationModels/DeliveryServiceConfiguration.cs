namespace Microsoft.eShopWeb.Web.ConfigurationModels;

public class DeliveryServiceConfiguration
{
    public const string ConfigPath = "DeliveryService";
    public const string KeyHeader = "x-functions-key";

    public string? Url { get; set; }

    public string? Key { get; set; }

    public string SaveUri => Url?.TrimEnd('/') + "/api/save";
}
