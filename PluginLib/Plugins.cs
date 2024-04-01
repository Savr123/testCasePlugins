namespace PluginLib
{
    /// <summary>
    /// Плагин для реализации умножения
    /// </summary>
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

    /// <summary>
    /// плагин для реализации сложения
    /// </summary>
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

    /// <summary>
    /// плагин для реализации деления
    /// </summary>
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

    /// <summary>
    /// плагин для реализации вычитания
    /// </summary>
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
