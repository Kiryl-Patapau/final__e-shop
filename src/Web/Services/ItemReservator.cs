using Ardalis.GuardClauses;
using Azure.Messaging.ServiceBus;
using Microsoft.eShopWeb.Web.DataTransferObjects;
using Microsoft.eShopWeb.Web.Interfaces;
using Newtonsoft.Json;

namespace Microsoft.eShopWeb.Web.Services;

public class ItemReservator : IItemReservator
{
    private const string QueueName = "sbq-reserving-items";

    private readonly ServiceBusClient _serviceBusClient;

    public ItemReservator(ServiceBusClient serviceBusClient)
    {
        _serviceBusClient = serviceBusClient;
    }

    public async Task Reserve(ReservedOrderDto order)
    {
        Guard.Against.Null(order, nameof(order));
        Guard.Against.NullOrEmpty(order.Items, nameof(order.Items));

        await using var sender = _serviceBusClient.CreateSender(QueueName);
        var message = new ServiceBusMessage(JsonConvert.SerializeObject(order))
        {
            ContentType = "application/json"
        };
        await sender.SendMessageAsync(message);
    }
}
