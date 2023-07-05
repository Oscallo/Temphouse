using System.ComponentModel;
using System.Windows;

namespace CoreLand.UI.Modules.Designer
{
    public class DesignerReporter
    {
        /// <summary>
        /// Проверка на DesignMode.
        /// </summary>
        /// <returns>Возвращает true, если объект <seealso cref="DependencyObject"/> находится в режиме разработки</returns>
        public static bool IsInDesignMode(DependencyObject dependencyObject) 
        {
            return DesignerProperties.GetIsInDesignMode(dependencyObject);
        }

    }
}
