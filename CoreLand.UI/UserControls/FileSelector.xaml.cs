using CoreLand.UI.Reporters.Information;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using OpenDialogNamespace = System.Windows.Forms;

namespace CoreLand.UI.UserControls
{
    /// <summary>
    /// Логика взаимодействия для FileSelector.xaml
    /// </summary>
    [ContentProperty("FileName")]
    public partial class FileSelector : UserControl
    {
        public static readonly DependencyProperty FileNameProperty = DependencyProperty.Register("FileName", typeof(string), typeof(FileSelector),new PropertyMetadata(InformationReporter.ApplicationFolder));
        
        public static readonly RoutedEvent FileNameChangedEvent = EventManager.RegisterRoutedEvent("FileNameChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FileSelector));

        private OpenDialogNamespace.OpenFileDialog fileDialog = new OpenDialogNamespace.OpenFileDialog();

        public FileSelector()
        {
            InitializeComponent();

            fileDialog.Filter = "Database files (*.db)|*.db|All files (*.*)|*.*";
            fileDialog.CheckFileExists = false;
            fileDialog.CheckPathExists = true;
        }

        public string FileName
        {
            get { return (string) GetValue(FileNameProperty);}
            set { SetValue(FileNameProperty, value);}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fileDialog.InitialDirectory = System.IO.Path.GetDirectoryName((string)GetValue(FileNameProperty));
            fileDialog.FileName = System.IO.Path.GetFileName((string)GetValue(FileNameProperty));

            if (fileDialog.ShowDialog() == OpenDialogNamespace.DialogResult.OK)
            {
                FileName = fileDialog.FileName;
            }
        }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            if (oldContent != null)
            {
                throw new InvalidOperationException("You cannot change Content");
            }
        }

        public event RoutedEventHandler FileNameChanged
        {
            add { AddHandler(FileNameChangedEvent, value);}
            remove { RemoveHandler(FileNameChangedEvent, value);}
        }

    }   
}
