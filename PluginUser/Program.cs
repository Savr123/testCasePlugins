using PluginLib;

namespace PluginUser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Plugins.Instance.LoadPlugins();

            Console.WriteLine("Hello world!");
        }
    }
}
