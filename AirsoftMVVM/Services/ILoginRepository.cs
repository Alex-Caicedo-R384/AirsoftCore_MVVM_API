using AirsoftMVVM.Models;

namespace AirsoftMVVM.Services;
public interface ILoginRepository
{
    Task<User> Login(string email, string password );
}
