using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microbrewit.AuthServer.Model;
using Microbrewit.AuthServer.Settings;
using Microsoft.Extensions.OptionsModel;
using Npgsql;

namespace Microbrewit.AuthSever.Service
{
    public class UserRepository : IUserRepository
    {
        private readonly ServerSettings _serverSettings;
        
        public UserRepository(IOptions<ServerSettings> serverSettings)
        {
            _serverSettings = serverSettings.Value;
        }
        public async Task<User> GetSingleAsync(string userId)
        {
            using (DbConnection context = new NpgsqlConnection(_serverSettings.DbConnection))
            {
                var sql = "SELECT username, email, settings, gravatar, longitude, latitude, header_image_url AS HeaderImage, " +
                          "avatar_url AS Avatar, firstname, lastname, password, salt" + 
                          " FROM users WHERE username = @Username";
                var users = await context.QueryAsync<User>(sql,new {Username = userId});
                return users.SingleOrDefault();
            }
        }
    }

}