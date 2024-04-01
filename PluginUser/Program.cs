using PluginLib;

namespace PluginUser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Plugins.Instance.Init();

            Console.WriteLine("Hello world!");
        }
    }
}
