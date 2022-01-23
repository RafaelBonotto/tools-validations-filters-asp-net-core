using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Colaboracao.Core
{
    public interface ICriptografia
    {
        string Encrypt(string plainText);

        string Decrypt(string encryptedText);

        string MD5Hash(string text);

    }
}