﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;

namespace HistoricBlog.WebApi.Providers
{
    public class ApplicationRefreshTokenProvider : IAuthenticationTokenProvider
    {
        public void Create(AuthenticationTokenCreateContext context)
        {
            var guid = Guid.NewGuid().ToString();

            // maybe only create a handle the first time, then re-use for same client
            // copy properties and set the desired lifetime of refresh token
            var refreshTokenProperties = new AuthenticationProperties(context.Ticket.Properties.Dictionary)
            {
                IssuedUtc = context.Ticket.Properties.IssuedUtc,
                ExpiresUtc = DateTime.UtcNow.AddYears(1)
            };
            var refreshTokenTicket = new AuthenticationTicket(context.Ticket.Identity, refreshTokenProperties);

            //_refreshTokens.TryAdd(guid, context.Ticket);
            _refreshTokens.TryAdd(guid, refreshTokenTicket);

            // consider storing only the hash of the handle
            context.SetToken(guid);
        }

        private static ConcurrentDictionary<string, AuthenticationTicket> _refreshTokens = new ConcurrentDictionary<string, AuthenticationTicket>();

        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var guid = Guid.NewGuid().ToString();

            // maybe only create a handle the first time, then re-use for same client
            // copy properties and set the desired lifetime of refresh token
            var refreshTokenProperties = new AuthenticationProperties(context.Ticket.Properties.Dictionary)
            {
                IssuedUtc = context.Ticket.Properties.IssuedUtc,
                ExpiresUtc = DateTime.UtcNow.AddYears(1)
            };
            var refreshTokenTicket = new AuthenticationTicket(context.Ticket.Identity, refreshTokenProperties);

            //_refreshTokens.TryAdd(guid, context.Ticket);
            _refreshTokens.TryAdd(guid, refreshTokenTicket);

            // consider storing only the hash of the handle
            context.SetToken(guid);
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            AuthenticationTicket ticket;
            if (_refreshTokens.TryRemove(context.Token, out ticket))
            {
                context.SetTicket(ticket);
            }
        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            AuthenticationTicket ticket;
            if (_refreshTokens.TryRemove(context.Token, out ticket))
            {
                context.SetTicket(ticket);
            }
        }
    }
}