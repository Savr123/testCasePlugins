namespace PluginLib
{
    public class MultiplyPlugin : Plugin
    {
        public override string PluginName { get; set; }
        public override string Version { get; set; }
        public override string Description { get; set; }

        public override int Run(int input1, int input2)
        {
            return input1 * input2;
        }
    }


    public class SumPlugin : Plugin
    {
        public override string PluginName { get; set; }

        public override string Version { get; set; }

        public override string Description { get; set; }

        public override int Run(int input1, int input2)
        {
            return input1 + input2;
        }
    }

    public class DividePlugin : Plugin
    {
        public override string PluginName { get; set; }
        public override string Version { get; set; }
        public override string Description { get; set; }

        public override int Run(int input1, int input2)
        {
            return input1 / input2;
        }
    }

    public class SubstructPlugin : Plugin
    {
        public override string PluginName { get; set; }
        public override string Version { get; set; }
        public override string Description { get; set; }

        public override int Run(int input1, int input2)
        {
            return input1 - input2;
        }
    }
}
