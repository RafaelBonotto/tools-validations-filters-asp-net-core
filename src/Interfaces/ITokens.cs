using System;
namespace Colaboracao.Core.Interfaces
{
    public interface ITokens
    {
        string ReverterToken(string token);
        string Base64(string token);
    }
}
