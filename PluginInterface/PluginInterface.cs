using System;
using Microsoft.SPOT;

namespace PluginInterface
{
    public interface IPlugin
    {
        string GetPluginName();

        string GetInformation();

        void SetVar(string var);
    }
}
