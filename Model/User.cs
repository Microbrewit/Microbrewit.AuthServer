using System.Collections.Generic;

namespace Microbrewit.AuthServer.Model
{
    public class User
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Settings { get; set; }
        public string Gravatar { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string HeaderImage { get; set; }
        public string Avatar { get; set; }
        public string Password { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}