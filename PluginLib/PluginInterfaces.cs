using System.Drawing;

namespace PluginLib
{
    public interface IPlugin
    {
        /// <summary>
        /// Имя плагина
        /// </summary>
        string PluginName { get; set; }
        /// <summary>
        /// Версия плагина
        /// </summary>
        string Version { get; set; }
        /// <summary>
        /// Видимо картинка для плагина, но я не понял где её показывать
        /// </summary>
        System.Drawing.Image Image { get;}
        /// <summary>
        /// Описание плагина
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Реализация математических функций
        /// </summary>
        /// <param name="input1"> - целочисленный аргумент 1</param>
        /// <param name="input2"> - целочисленный аргумент 1</param>
        /// <returns>Возвращает результат выполнения математических преобразований функции</returns>
        int Run(int input1, int input2);
    }

    public abstract class Plugin : IPlugin
    {
        /// <inheritdoc/>
        public abstract string PluginName { get; set; }
        /// <inheritdoc/>
        public abstract string Version { get; set; }
        /// <inheritdoc/>
        public abstract string Description { get; set; }

        /// <inheritdoc/>
        public virtual Image Image => Properties.Resources.pluginImage;

        /// <inheritdoc/>
        public abstract int Run(int input1, int input2);
    }

    public class PluginConfigExpanded
    {
        /// <inheritdoc/>
        public string PluginName { get ; set; }
        /// <inheritdoc/>
        public string Version { get; set; }
        /// <inheritdoc/>
        public string Image { get; set; }
        /// <inheritdoc/>
        public string Description { get; set; }
        /// <inheritdoc/>
        public string TypeName { get; set; }
    }

    public class PluginConfig
    {
        /// <summary>
        /// Имя плагина
        /// </summary>
        public string PluginName { get; set; }
        /// <summary>
        /// Тип плагина
        /// </summary>
        public string TypeName { get; set; }
    }
}
