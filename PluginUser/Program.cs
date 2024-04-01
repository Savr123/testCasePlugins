using PluginLib;
using System.Reflection;
using System.Xml.Serialization;

namespace PluginUser
{
    public class Program
    {
        static void Main(string[] args)
        {
            Plugins.Instance.Init();

            IPlugin plugin = Plugins.Instance.CreatePlugin(Plugins.DefaultPlugins.MultiplyPlugin);
            Plugins.Instance.RegisterPlugin("CustomPlugin", (new CustomPlugin.CustomPlugin()).GetType());
            IPlugin customPlugin = Plugins.Instance.CreatePlugin("CustomPlugin");

            Console.WriteLine(plugin.Run(1, 2));
            Console.WriteLine(customPlugin.Run(1, 2));
        }
    }
}
