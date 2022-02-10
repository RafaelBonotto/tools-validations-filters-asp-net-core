using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Colaboracao.Core.Interfaces;

namespace Colaboracao.Core.Impl
{
    public class AspNetUser : IAspNetUser
    {
        private readonly Microsoft.AspNetCore.Http.IHttpContextAccessor HttpContextAccessor;
        private readonly ITokens _tokens;

        public AspNetUser(Microsoft.AspNetCore.Http.IHttpContextAccessor pHttpContextAccessor, ITokens tokens)
        {
            HttpContextAccessor = pHttpContextAccessor;
            _tokens = tokens;

            if (Claims() != null && Claims().Count() > 0)
            {
                this.Token = Claims().Where(m => m.Type == "Token").FirstOrDefault().Value;
                this.Cpf = _tokens.ReverterToken(this.Token);
            }
        }

        private IEnumerable<Claim> Claims()
        {
            return HttpContextAccessor.HttpContext.User.Claims;
        }

        public string Cpf { get; }
        public string Token { get; }
    }
}
