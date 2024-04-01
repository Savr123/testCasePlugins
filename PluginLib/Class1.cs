using System.Drawing;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PluginLib
{

    public class Plugins : IPluginFactory
    {
        private Dictionary<string, Type> _pluginDictionary = new Dictionary<string, Type>();

        /// <summary>
        /// Возвращает список плагинов для создания.
        /// </summary>
        public string[] PluginNameList
        {
            get
            {
                return _pluginDictionary.Keys.ToArray<string>();
            }
        }

        /// <summary>
        /// Возвращает общее колличество зарегистрированных плагинов
        /// </summary>
        public int PluginsCount { 
            get 
            {
                return _pluginDictionary.Count;
            }
        }

        private List<PluginConfig> LoadPluginConfigsFromJSON()
        {

            // Specify the path to your JSON file
            string filePath = "plugins.json";

            // Read JSON data from file
            string json = File.ReadAllText(filePath);

            List<PluginConfig> pluginList = JsonConvert.DeserializeObject<List<PluginConfig>>(json);
            return pluginList;
        }

        private static Plugins _instance;
        private static readonly object _lockObj = new object();

        public static Plugins Instance
        {
            get
            {
                if(_instance == null )
                    lock(_lockObj)
                        if(_instance ==null)
                            _instance = new Plugins();

                return _instance;
            }
        }

        public void Init()
        {
            var pluginConfigs = LoadPluginConfigsFromJSON();

            foreach (var item in pluginConfigs)
            {
                Type type = Type.GetType("PluginLib." + item.TypeName);
                RegisterPlugin(item.PluginName, type);
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

            _pluginDictionary.Add(pluginName, pluginType);
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
            if (!_pluginDictionary.ContainsKey(pluginName))
                throw new ArgumentException(string.Format("Plugin name {0} not found", pluginName));

            if (Activator.CreateInstance(_pluginDictionary[pluginName]) is IPlugin createdPlugin)
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
        public IPlugin CreatePlugin(string pluginName, IPluginConfig config)
        {
            var plugin = CreatePlugin(pluginName);
            plugin.Version = config.Version;

            return plugin;
        }
    }

    interface IPluginFactory
    {
        void RegisterPlugin(string pluginName, Type pluginType);
        IPlugin CreatePlugin(string pluginName);
    }
}
