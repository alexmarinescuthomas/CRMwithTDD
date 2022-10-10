using Customers.API.Models;
using System;
using System.Net;
using System.Reflection.Metadata.Ecma335;

public interface IUsersService
{
    public Task<List<User>> GetAllUsers();
}

public class UsersService : IUsersService
{
    private readonly HttpClient _httpClient;
    public UsersService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<User>> GetAllUsers()
    {
        //Fetch Users from a DB or alternatively from an API
        var userResponse = await _httpClient.GetAsync("https://someLink.com");
        if (userResponse.StatusCode == HttpStatusCode.NotFound)
            return new List<User>();

        var responseContent = userResponse.Content;
        var allUsers = await responseContent.ReadFromJsonAsync<List<User>>();
        return allUsers.ToList();
    }
}
