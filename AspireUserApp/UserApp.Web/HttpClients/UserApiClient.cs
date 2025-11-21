using UserApp.Web.Models;

namespace UserApp.Web.HttpClients;

public class UserApiClient(HttpClient httpClient)
{
    public async Task<User[]> GetUsersAsync()
    {
        return await httpClient.GetFromJsonAsync<User[]>("/users") ?? [];
    }

    public async Task AddUserAsync(User user)
    {
        await httpClient.PostAsJsonAsync("/users", user);
    }
}