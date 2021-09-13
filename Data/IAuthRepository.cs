using System.Threading.Tasks;
using tasks.Entities;
using tasks.Models;

namespace tasks.Data
{
    public interface IAuthRepository 
    {
         Task<ServiceResponse<int>> Register(UserEntity user, string Password);
         Task<ServiceResponse<string>> Login(string username, string password);
         Task<bool> UserExists(string username);
    }
}