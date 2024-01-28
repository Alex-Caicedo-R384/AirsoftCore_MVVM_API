using AirsoftMVVM.Models;

namespace AirsoftMVVM.Services;
public interface ILoginRepository
{
    Task<User> Login(string email, string password );
    Task<User> Register(string email, string password, string password1);
    Task<bool> EmailExists(string email);
}
