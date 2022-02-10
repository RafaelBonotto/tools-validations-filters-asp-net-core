using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Colaboracao.Core.Interfaces
{
    public interface IAspNetUser
    {
        string Cpf { get; }
        string Token { get; }
    }
}