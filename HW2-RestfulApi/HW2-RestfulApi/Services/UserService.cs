using HW2_RestfulApi.Interfaces;

namespace HW2_RestfulApi.Services;

public class UserService : IUserService
{
    private readonly Dictionary<string, string> _users = new() { { "admin", "1234" } };
    public bool Login(string username, string password) => _users.TryGetValue(username, out var pwd) && pwd == password;
}