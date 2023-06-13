using Data.Models;

namespace Data.Services.Interfaces
{
    public interface IUserServices
    {
        Task<List<User>> GetAllUser();
        Task<bool> Update(User u);
        Task<bool> Delete(Guid id);
        Task<bool> Add(User user);
        Task<User> GetById(Guid id);
        Task<List<string>> GetByName(string name);
        Task<bool> IsClient(string username, string password);
        Task<bool> IsAdministrator(string username, string password);
        string GenerateTokenString(string username, string password);

    }
}
