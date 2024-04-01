using System.Drawing;

namespace CustomPlugin
{
    [Serializable]
    public class CustomPlugin
    {
        public CustomPlugin()
        {
            _pluginName = "CustomPlugin";
        }

        private string _pluginName;
        public string PluginName
        {
            get
            {
                return _pluginName;
            }
            set
            {
                _pluginName = value;
            }
        }

        public string Version { get; set; }

        public Image Image => new Bitmap(80, 20);

        public string Description { get; set; }

        public int Run(int input1, int input2)
        {
            return (input1+input2)/2;
        }
    }
}
