using System.Threading.Tasks;
using Microbrewit.AuthServer.Model;

namespace Microbrewit.AuthSever.Service
{
    public interface IUserRepository
    {
        Task<User> GetSingleAsync(string userId);
    }
}