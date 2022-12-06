using TodolistAppModels.Entities;
using TodolistAppModels.Informations;

namespace TodolistAppDomain.Identity
{
    public interface IIdentityService
    {
        System.Threading.Tasks.Task CreateUser(UserInformation userInformation);
        Task<string> GetToken(string username, string password);
        Task<int> SerachUserByEmail(string email);
        Task<User> GetUserData(int userId);
    }
}
