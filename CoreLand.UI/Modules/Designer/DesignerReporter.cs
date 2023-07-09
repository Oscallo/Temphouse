using CoreLand.UI.CustomControls;
using System;
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

        public static T GetParent<T> (DependencyObject startFindObject) where T : DependencyObject
        {
            var parent = startFindObject;
            while ((parent is T) == false)
            {
                parent = LogicalTreeHelper.GetParent((DependencyObject)parent);

            }
            return (T)parent;
        }

        public static T GetParentExtendedWindow<T>(DependencyObject startFindObject) where T : ExtendedWindow
        {
            return (T)GetParent<ExtendedWindow>(startFindObject);
        }
    }
}
