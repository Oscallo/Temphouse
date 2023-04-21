using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Temphouse.Modules.Information
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
        public static string ApplicationVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();


        /// <summary>
        /// Название ПО.
        /// </summary>
        public static string ApplicationName => Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>
        /// Иконка ПО.
        /// </summary>
        public static Icon ApplicationIcon => Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);

        #pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
        #pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
    }
}

