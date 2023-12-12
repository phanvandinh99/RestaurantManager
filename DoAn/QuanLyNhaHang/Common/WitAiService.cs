using QuanLyNhaHang.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class WitAiService
{
    private readonly string witApiKey;
    private readonly HttpClient httpClient;

    public WitAiService(string witApiKey)
    {
        this.witApiKey = witApiKey;
        this.httpClient = new HttpClient();
    }

    public async Task<WitAiResponse> ProcessMessage(string message)
    {
        var apiUrl = "https://api.wit.ai/message?v=20231210&q=" + Uri.EscapeDataString(message);

        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {witApiKey}");

        var response = await httpClient.GetStringAsync(apiUrl);

        // Deserialize the response JSON as needed
        // Example: var result = JsonConvert.DeserializeObject<WitAiResponse>(response);

        return new WitAiResponse { Text = response };
    }
}
