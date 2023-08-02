using System;
using System.Collections;
using System.Windows.Controls.Primitives;

namespace CoreLand.UI.CustomControls
{
    public partial class EnumSelector : Selector
    {
        public Type EnumType
        {
            get { return (Type)GetValue(EnumTypeProperty); }
            set { SetValue(EnumTypeProperty, value); }
        }

        public new IEnumerable ItemsSource 
        { 
            get { return (IEnumerable)GetValue(ItemsSourceProperty); } 
            internal set { SetValue(ItemsSourceProperty, value);}
        }

        public EnumSelector() : base()
        {
            Initialize();
        }

        private void Initialize()
        {

        }
    }
}
