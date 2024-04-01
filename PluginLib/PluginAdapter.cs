using System;
using System.Collections.Generic;
using System.Drawing;
using CustomPlugin;

namespace PluginLib
{
    /// <summary>
    /// Адаптер для кастомного плагина, чтобы была возможность использовать интерфейс
    /// </summary>
    internal class CustomPluginAdapter : IPlugin
    {
        private CustomPlugin.CustomPlugin _customPlugin;

        public CustomPluginAdapter()
        {
            _customPlugin = new CustomPlugin.CustomPlugin();
        }

        public string PluginName 
        {
            get { return _customPlugin.PluginName;}
            set { _customPlugin.PluginName = value;}
        }
        public string Version 
        {
            get => _customPlugin.Version;
            set => _customPlugin.Version = value;
        }

        public Image Image => _customPlugin.Image;

        public string Description 
        {
            get => _customPlugin.Description;
            set => _customPlugin.Description = value;
        }

        public int Run(int input1, int input2)
        {
            return _customPlugin.Run(input1, input2);
        }
    }
}
