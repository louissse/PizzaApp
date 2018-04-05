using System.Threading.Tasks;
using PizzaApp.Models;

namespace PizzaApp.Services
{
    public interface IUserService
    {
        Task<UserModel> GetUserByEmail(string email);
        Task<bool> RegisterUser(UserModel userModel);
        Task UpdateUser(UserModel userModel);
    }
}