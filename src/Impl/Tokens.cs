using System;
using System.Text;
using Colaboracao.Core.Interfaces;

namespace Colaboracao.Core.Impl
{
    public class Tokens : ITokens
    {
        public string ReverterToken(string token)
        {
            try
            {
                token = token.Split(':')[0];
                return Criptografia.Decrypt(token).Split('|')[0];
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string Base64(string token)
        {
            try
            {
                byte[] textoAsBytes = Encoding.ASCII.GetBytes(token);
                return System.Convert.ToBase64String(textoAsBytes);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
