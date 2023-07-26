using ApiHW;
using System.Net.Http.Json;


try
{
    using (var httpClient = new HttpClient())
    {
        string apiUrl = "https://catfact.ninja/fact";

        HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

        response.EnsureSuccessStatusCode();

        var catFact = await response.Content.ReadFromJsonAsync<CatFact>();

        if (catFact != null)
        {
            Console.WriteLine($"Random fact about kitties: {catFact.Fact}");
        }
        else
        {
            Console.WriteLine("Something went wrong...");
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"ERROR ALERT: {ex.Message}");
}