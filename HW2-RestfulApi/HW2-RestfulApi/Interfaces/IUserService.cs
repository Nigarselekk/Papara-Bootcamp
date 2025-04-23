namespace HW2_RestfulApi.Interfaces;

public interface IUserService
{
    bool Login(string username, string password);
}
