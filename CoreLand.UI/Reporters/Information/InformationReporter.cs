using System.Drawing;
using System.Reflection;

namespace CoreLand.UI.Reporters.Information
{
    /// <summary>
    /// Фасад от <seealso cref="Assembly"/> и <seealso cref="Icon"/>
    /// <br/>
    /// Получение всей информации о приложении.
    /// </summary>
    public static class InformationReporter
    {
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.


        /// <summary>
        /// Версия ПО.
        /// </summary>
        public static string ApplicationVersion => Assembly.GetEntryAssembly().GetName().Version.ToString();


        /// <summary>
        /// Название ПО.
        /// </summary>
        public static string ApplicationName => Assembly.GetEntryAssembly().GetName().Name;

        /// <summary>
        /// Иконка ПО.
        /// </summary>
        public static Icon ApplicationIcon => Icon.ExtractAssociatedIcon(Assembly.GetEntryAssembly().Location);

#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
    }
}

