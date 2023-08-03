using CoreLand.UI.CustomControls.Windows;
using System.ComponentModel;
using System.Windows;

namespace CoreLand.UI.Modules.Designer
{
    public class DesignerReporter
    {

        #region static Instance

        /// <summary>
        /// Статический экземпляр объекта.
        /// </summary>
        public static DesignerReporter Instance { get; private set; }

        static DesignerReporter()
        {
            Instance = new DesignerReporter();
        }

        #endregion

        /// <summary>
        /// Проверка на DesignMode.
        /// </summary>
        /// <returns>Возвращает true, если объект <seealso cref="DependencyObject"/> находится в режиме разработки</returns>
        public bool IsInDesignMode(DependencyObject dependencyObject) 
        {
            return DesignerProperties.GetIsInDesignMode(dependencyObject);
        }

        public T GetParentExtendedWindow<T>(DependencyObject startFindObject) where T : ExtendedWindow
        {
            return (T)ExtendedWindow.GetWindow(startFindObject);
        }
    }
}
