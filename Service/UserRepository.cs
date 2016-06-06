using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microbrewit.AuthServer.Model;
using Microbrewit.AuthServer.Settings;
using Microsoft.Extensions.Options;
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
                var sql = "SELECT user_id AS UserId, username, email, settings, gravatar, longitude, latitude, header_image_url AS HeaderImage, " +
                          "avatar_url AS Avatar, firstname, lastname, password, salt" + 
                          " FROM users WHERE user_id = @UserId";
                var users = await context.QueryAsync<User>(sql,new {UserId = userId});
                 var rolesSql = "SELECT name FROM roles r INNER JOIN user_roles ur ON r.role_id = ur.role_id WHERE ur.user_id = @UserId;";
                 foreach (var user in users)
                 {
                     var roles = await context.QueryAsync<string>(rolesSql, new { UserId = user.UserId });
                     user.Roles = roles;
                 }
                return users.SingleOrDefault();
            }
        }

        public async Task<User> GetSingleByUsername(string username)
        {
            using (DbConnection context = new NpgsqlConnection(_serverSettings.DbConnection))
            {
                var sql = "SELECT user_id AS UserId, username, email, settings, gravatar, longitude, latitude, header_image_url AS HeaderImage, " +
                          "avatar_url AS Avatar, firstname, lastname, password " +
                          " FROM users WHERE username = @Username";
                var users = await context.QueryAsync<User>(sql, new { Username = username});
                 var rolesSql = "SELECT name FROM roles r INNER JOIN user_roles ur ON r.role_id = ur.role_id WHERE ur.user_id = @UserId;";
                 foreach (var user in users)
                 {
                     var roles = await context.QueryAsync<string>(rolesSql, new { UserId = user.UserId });
                     user.Roles = roles;
                 }
                return users.SingleOrDefault();
            }
        }
    }
}