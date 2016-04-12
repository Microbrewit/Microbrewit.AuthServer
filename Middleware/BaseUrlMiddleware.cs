﻿using Microsoft.AspNet.Builder;
using System.Threading.Tasks;
using Microbrewit.AuthServer.Settings;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.OptionsModel;

namespace Microbrewit.AuthServer.Middlevare
{

    public class BaseUrlMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ServerSettings _serverSettings;
        
        public BaseUrlMiddleware(RequestDelegate next, IOptions<ServerSettings> serverSettings)
        {
            _next = next;
            _serverSettings = serverSettings.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;
            request.Host = new HostString(_serverSettings.Url);
            await _next(context);
        }
    }
}
