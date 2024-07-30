using Lab4_Part2.Models;
using Lab4_Part2.Services.Absractions;
using Newtonsoft.Json.Linq;

namespace Lab4_Part2.Services;

public class KeycloakService : IKeycloakService
{
    private readonly HttpClient _httpClient;
    private readonly string _tokenEndpoint;

    public KeycloakService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _tokenEndpoint = "http://localhost:8080/realms/myRealm/protocol/openid-connect/token";
    }

    public async Task<string> Login(string Username,string Password)
    {

        var requestContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("client_id", "KeyCloack"),
            new KeyValuePair<string, string>("client_secret", "KveftIqKLMoI7cDGAorTVGzZlaFtEtzz"),
            new KeyValuePair<string, string>("grant_type", "password"),
            new KeyValuePair<string, string>("username", Username),
            new KeyValuePair<string, string>("password", Password)
        });

        try
        {
            var response = await _httpClient.PostAsync(_tokenEndpoint, requestContent);


            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error from Keycloak: {errorContent}");
            }

            var content = await response.Content.ReadAsStringAsync();
            
            var jsonResponse = JObject.Parse(content);
            
            var accessToken = jsonResponse["access_token"]?.ToString();
            
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new Exception("Authentication failed: Access token not found.");
            }

            return accessToken;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while authenticating: {ex.Message}", ex);
        }
    }


}