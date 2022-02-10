using System;
using Microsoft.Extensions.Logging;

namespace Colaboracao.Core
{
    public interface ILogCore
    {
        void Log(string message, Levels level);
    }
}
