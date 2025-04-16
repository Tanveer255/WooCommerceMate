using RestSharp;
namespace WooCommerceMate.Service;

public class WooCommerceService
{
    private readonly string baseUrl;
    private readonly string consumerKey;
    private readonly string consumerSecret;

    public WooCommerceService(string url, string key, string secret)
    {
        baseUrl = url;
        consumerKey = key;
        consumerSecret = secret;
    }

    public async Task<string> GetProductsAsync()
    {
        var client = new RestClient($"{baseUrl}/wp-json/wc/v3/");
        var request = new RestRequest("products", Method.Get);
        request.AddQueryParameter("consumer_key", consumerKey);
        request.AddQueryParameter("consumer_secret", consumerSecret);

        var response = await client.ExecuteAsync(request);
        return response.Content;
    }
    public async Task<string> RegisterWebhookAsync(string topic, string deliveryUrl)
    {
        var client = new RestClient($"{baseUrl}/wp-json/wc/v3/");
        var request = new RestRequest("webhooks", Method.Post);
        request.AddQueryParameter("consumer_key", consumerKey);
        request.AddQueryParameter("consumer_secret", consumerSecret);

        var webhook = new
        {
            name = $"{topic} Webhook",
            topic = topic, // e.g., "order.created"
            delivery_url = deliveryUrl,
            status = "active"
        };

        request.AddJsonBody(webhook);

        var response = await client.ExecuteAsync(request);
        return response.Content;
    }
}

