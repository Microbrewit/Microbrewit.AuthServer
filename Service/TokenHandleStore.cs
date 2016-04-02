using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.Core.Models;
using IdentityServer4.Core.Services;

namespace Microbrewit.AuthServer.Service
{
    public class TokenHandleStore : ITokenHandleStore
    {
        public Task StoreAsync(string key, Token value)
        {
            throw new NotImplementedException();
        }

        public Task<Token> GetAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ITokenMetadata>> GetAllAsync(string subject)
        {
            throw new NotImplementedException();
        }

        public Task RevokeAsync(string subject, string client)
        {
            throw new NotImplementedException();
        }
    }
}
