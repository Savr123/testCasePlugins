using System.Drawing;
using System.Collections.Generic;
using System.Text.Json;

namespace PluginLib
{
    //public class SumPlugin : IPlugin
    //{
    //    public string PluginName => "SumPlugin";

    //    public string Version => throw new NotImplementedException();

    //    public Image Image => throw new NotImplementedException();

    //    public string Description => throw new NotImplementedException();

    //    public int Run(int input1, int input2)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class DividePlugin: IPlugin
    //{

    //}

    //public class SubstractPlugin: IPlugin
    //{

    //}



    public interface IPlugin
    {
        string PluginName { get; }
        string Version { get; }
        System.Drawing.Image Image { get; }
        string Description { get; }
        int Run(int input1, int input2);
    }

    public abstract class Plugin : IPlugin
    {
        public abstract string PluginName { get; set; }
        public abstract string Version { get; set; }
        public abstract string Description { get; set; }

        public Image Image => null;

        public int Run(int input1, int input2)
        {
            return input1 * input2;
        }
    }

    public class MultiplyPlugin :IPlugin
    {
        public string PluginName { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }

        public Image Image => null;

        public int Run(int input1, int input2)
        {
            return input1 * input2;
        }
    }


}
