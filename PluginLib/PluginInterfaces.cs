using System.Drawing;
using System.Collections.Generic;
using System.Text.Json;
using System.Reflection;

namespace PluginLib
{
    public interface IPlugin
    {
        string PluginName { get; set; }
        string Version { get; set; }
        System.Drawing.Image Image { get;}
        string Description { get; set; }
        int Run(int input1, int input2);
    }

    public interface IPluginConfig
    {
        string PluginName { get; set; }
        string Version { get; set; }
        string Description { get; set; }
        string TypeName { get; set; }
    }

    public abstract class Plugin : IPlugin
    {
        public abstract string PluginName { get; set; }
        public abstract string Version { get; set; }
        public abstract string Description { get; set; }

        public virtual Image Image => Properties.Resources.pluginImage;

        public abstract int Run(int input1, int input2);
    }

    public class PluginConfig : IPluginConfig
    {
        public string PluginName { get ; set; }
        public string Version { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string TypeName { get; set; }
    }

    public class PluginTypeConfig
    {
        public string PluginName { get; set; }
        public string TypeName { get; set; }
    }
}
