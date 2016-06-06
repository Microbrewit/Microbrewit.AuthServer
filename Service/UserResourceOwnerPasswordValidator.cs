using System.Security.Cryptography;
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
                var hash = GenerateSaltedHash(GetBytes(password),GetBytes(user.Salt));
                if(CompateByteArrays(hash,GetBytes(user.Password)))
                {  
                    _logger.LogInformation($"password match");
                    return new CustomGrantValidationResult(user.Username,"password");
                }
            }
            return new CustomGrantValidationResult("Invalid username or password");
        }
             private static byte[] GenerateSaltedHash(byte[] password, byte[] salt)
        {
            HashAlgorithm algorithm = new HMACSHA512();

            var plainTextWithSaltBytes = new byte[password.Length + salt.Length];
            for (int i = 0; i < password.Length; i++)
            {
                plainTextWithSaltBytes[i] = password[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[password.Length + i] = salt[i];
            }
            return plainTextWithSaltBytes;
        }

        private static bool CompateByteArrays(byte[] first, byte[] second)
        {
            if(first.Length != second.Length) return false;
            for (int i = 0; i < first.Length; i++)
            {
                if(first[i] != second[i]) return false;
            }
            return true;
        }

        private static byte[] GetBytes(string str)
        {
            var bytes = new byte[str.Length*sizeof (char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes,0,bytes.Length);
            return bytes;
        }
        
    }
}