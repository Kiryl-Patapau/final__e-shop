using Ardalis.GuardClauses;
using Microsoft.eShopWeb.Web.ConfigurationModels;
using Microsoft.eShopWeb.Web.DataTransferObjects;
using Microsoft.eShopWeb.Web.Interfaces;
using Microsoft.Extensions.Options;

namespace Microsoft.eShopWeb.Web.Services;

public class DeliveryService : IDeliveryService
{
    private readonly HttpClient _httpClient;
    private readonly DeliveryServiceConfiguration _configuration;

    public DeliveryService(HttpClient httpClient, IOptions<DeliveryServiceConfiguration> configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration.Value;
    }

    public async Task SaveOrder(DeliveredOrderDto order)
    {
        Guard.Against.Null(order, nameof(order));
        Guard.Against.NullOrEmpty(order.Items, nameof(order.Items));

        using var request = new HttpRequestMessage(HttpMethod.Post, _configuration.SaveUri);
        request.Headers.Add(DeliveryServiceConfiguration.KeyHeader, _configuration.Key);
        request.Content = JsonContent.Create(order);
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
    }
}
