using System.Drawing;
using System.Collections.Generic;
using System.Text.Json;

namespace PluginLib
{

    public class Plugins : IPluginFactory
    {
        private Dictionary<string, Type> _plugins = new Dictionary<string, Type>();

        /// <summary>
        /// Возвращает список плагинов для создания.
        /// </summary>
        public string[] PluginNameList
        {
            get
            {
                return _plugins.Keys.ToArray<string>();
            }
        }

        int PluginsCount { get 
            {
                return _plugins.Count;
            }
        }


        /// <summary>
        /// Регистрирует новый тип плагина, который можно создать.
        /// </summary>
        /// <param name="pluginName"> - имя плагина</param>
        /// <param name="pluginType"> - тип плагина</param>
        /// <exception cref="ArgumentException"> - возвращается ошибка, если полученный тип не реализует интерфейс IPlugin</exception>
        public void RegisterPlugin(string pluginName, Type pluginType)
        {
            if (!pluginType.GetInterfaces().Contains(typeof(IPlugin)))
                throw new ArgumentException("given plugin type {0} do not implement IPlugin interface", pluginType.Name);

            _plugins.Add(pluginName, pluginType);
        }

        /// <summary>
        /// Возвращает новый плагин
        /// </summary>
        /// <param name="pluginName"> - имя создаваемого плагина</param>
        /// <returns>Возвращает новый плагин типа <see cref="IPlugin"/></returns>
        /// <exception cref="ArgumentException"> - возвращается в случае если не плагин не зарегистрирован, либо 
        /// не удалось создать плагин по иным причинам
        /// </exception>
        public IPlugin CreatePlugin(string pluginName)
        {
            if (!_plugins.ContainsKey(pluginName))
                throw new ArgumentException(string.Format("Plugin name {0} not found", pluginName));

            if (Activator.CreateInstance(_plugins[pluginName]) is IPlugin createdPlugin)
                return createdPlugin;

            throw new ArgumentException($"Plugin {pluginName} is not created. Invalid type received.");
        }

        /// <summary>
        /// Возвращает новый плагин
        /// </summary>
        /// <param name="pluginName"> - имя создаваемого плагина</param>
        /// <param name="args"> - список параметров для конструктора</param>
        /// <returns>Возвращает новый плагин типа <see cref="IPlugin"/></returns>
        /// <exception cref="ArgumentException"> - возвращается в случае если не плагин не зарегистрирован, либо 
        /// не удалось создать плагин по иным причинам
        /// </exception>
        public IPlugin CreatePlugin(string pluginName, params object?[]? args)
        {
            if (!_plugins.ContainsKey(pluginName))
                throw new ArgumentException(string.Format("Plugin name {0} not found", pluginName));

            if (Activator.CreateInstance(_plugins[pluginName], args) is IPlugin createdPlugin)
                return createdPlugin;

            throw new ArgumentException($"Plugin {pluginName} is not created. Invalid type received.");
        }
    }

    interface IPluginFactory
    {
        void RegisterPlugin(string pluginName, Type pluginType);
        IPlugin CreatePlugin(string pluginName);
    }
}
