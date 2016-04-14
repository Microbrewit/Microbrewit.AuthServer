using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Core.Extensions;
using IdentityServer4.Core.Models;
using IdentityServer4.Core.Services;
using Microbrewit.AuthSever.Service;

namespace Microbrewit.AuthServer.Service
{
    public class UserProfileService : IProfileService
    {
        private readonly IUserRepository _userRepository;
        public UserProfileService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = await _userRepository.GetSingleByUsername(context.Subject.GetSubjectId());
            var claims = new List<Claim>{
                new Claim(JwtClaimTypes.Subject, user.UserId),
            };

            //claims.AddRange(user.Claims);
            // if (!context.AllClaimsRequested)
            // {
            //     claims = claims.Where(x => context.RequestedClaimTypes.Contains(x.Type)).ToList();
            // }

            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
             if (context.Subject == null) throw new ArgumentNullException("subject");

            var user = await _userRepository.GetSingleByUsername(context.Subject.GetSubjectId());
            context.IsActive = (user != null);
        }
    }
}