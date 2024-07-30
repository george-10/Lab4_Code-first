using Lab4_Part2.Models;

namespace Lab4_Part2.Services.Absractions;

public interface IKeycloakService
{
    public Task<string> Login(string Username,string Password);
}