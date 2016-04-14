using System.Threading.Tasks;
using IdentityServer4.Core.Validation;
using Microsoft.Extensions.Logging;

namespace Microbrewit.AuthSever.Service
{
    public class UserResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserResourceOwnerPasswordValidator> _logger;
        public UserResourceOwnerPasswordValidator(IUserRepository userRepository,ILogger<UserResourceOwnerPasswordValidator> logger)
        {
            _logger = logger;
            _userRepository = userRepository;
        }
        public async Task<CustomGrantValidationResult> ValidateAsync(string userName, string password, ValidatedTokenRequest request)
        {
            _logger.LogInformation($"Username {userName}");
            var user = await _userRepository.GetSingleByUsername(userName);
            
            if(user != null)
            {
                _logger.LogInformation($"User found with username {user.Username}");
                if(password == user.Password)
                {  
                    _logger.LogInformation($"password match");
                    return new CustomGrantValidationResult(user.Username,"password");
                }
            }
            return new CustomGrantValidationResult("Invalid username or password");
        }
    }
}