using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Temphouse.Modules.Information
{
    public static class InformationReporter
    {
        #pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        #pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.

        public static string ApplicationVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public static string ApplicationName => Assembly.GetExecutingAssembly().GetName().Name;

        public static Icon ApplicationIcon => Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);

        #pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
        #pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
    }
}

