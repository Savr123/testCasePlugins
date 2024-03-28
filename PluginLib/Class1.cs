using System.Drawing;

namespace PluginLib
{
    public class Plugins : IPluginFactory
    {
        public int PluginsCount => throw new NotImplementedException();

        public string[] GetPluginNames => throw new NotImplementedException();

        public IPlugin GetPlugin(string pluginName)
        {
            throw new NotImplementedException();
        }
    }

    interface IPluginFactory
    {
        int PluginsCount { get; }
        string[] GetPluginNames { get; }
        IPlugin GetPlugin(string pluginName);
    }

    public interface IPlugin
    {
        string PluginName { get; }
        string Version { get; }
        System.Drawing.Image Image { get; }
        string Description { get; }
        int Run(int input1, int input2);
    }

    public abstract class Plugin: IPlugin
    {
        protected Plugin() { }

        public string PluginName => throw new NotImplementedException();

        public string Version => throw new NotImplementedException();

        public Image Image => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public int Run(int input1, int input2)
        {
            throw new NotImplementedException();
        }
    }


}
