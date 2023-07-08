using CoreLand.UI.Modules.Boxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoreLand.UI.CustomControls
{
    /// <summary>
    /// Спасибо за помощь в решении проблемы <seealso cref="https://stackoverflow.com/questions/17407620/custom-masked-passwordbox-in-wpf">Stackoverflow</seealso>
    /// </summary>

    public partial class HintablePasswordBox : HintableTextBox
    {
        public SecureString Password
        {
            get {return (SecureString)GetValue(PasswordProperty);}
            set {SetValue(PasswordProperty, value);}
        }

        public string HiddenText
        {
            get {return (string)GetValue(HiddenTextProperty);}
            set {SetValue(HiddenTextProperty, value);}
        }

        public char PasswordChar
        {
            get { return (char)GetValue(PasswordCharProperty); }
            set { SetValue(PasswordCharProperty, value); }
        }

        public bool IsPasswordMasked
        {
            get { return (bool)GetValue(IsPasswordMaskedProperty); }
            set { SetValue(IsPasswordMaskedProperty, value); }
        }

        public HintablePasswordBox()
        {
            PreviewTextInput += _OnPreviewTextInput;
            PreviewKeyDown += _OnPreviewKeyDown;
            CommandManager.AddPreviewExecutedHandler(this, _PreviewExecutedHandler);
        }

        private static void _PreviewExecutedHandler(object sender, ExecutedRoutedEventArgs executedRoutedEventArgs)
        {
            if (executedRoutedEventArgs.Command == ApplicationCommands.Copy || executedRoutedEventArgs.Command == ApplicationCommands.Cut || executedRoutedEventArgs.Command == ApplicationCommands.Paste)
            {
                executedRoutedEventArgs.Handled = true;
            }
        }

        private void _OnPreviewKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            Key pressedKey = keyEventArgs.Key == Key.System ? keyEventArgs.SystemKey : keyEventArgs.Key;
            switch (pressedKey)
            {
                case Key.Space:
                    {
                        _AddToSecureString(" ");
                        keyEventArgs.Handled = true;
                        break;
                    }
                case Key.Back:
                case Key.Delete:
                    {
                        if (SelectionLength > 0)
                        {
                            _RemoveFromSecureString(SelectionStart, SelectionLength);
                        }
                        else if (pressedKey == Key.Delete && CaretIndex < Text.Length)
                        {
                            _RemoveFromSecureString(CaretIndex, 1);
                        }
                        else if (pressedKey == Key.Back && CaretIndex > 0)
                        {
                            int caretIndex = CaretIndex;
                            if (CaretIndex > 0 && CaretIndex < Text.Length)
                            {
                                caretIndex = caretIndex - 1;
                            }
                            _RemoveFromSecureString(CaretIndex - 1, 1);
                            CaretIndex = caretIndex;
                        }

                        keyEventArgs.Handled = true;
                        break;
                    }
            }
        }

        private void _OnPreviewTextInput(object sender, TextCompositionEventArgs textCompositionEventArgs)
        {
            _AddToSecureString(textCompositionEventArgs.Text);
            textCompositionEventArgs.Handled = true;
        }

        private void _AddToSecureString(string text)
        {
            if (SelectionLength > 0)
            {
                _RemoveFromSecureString(SelectionStart, SelectionLength);
            }

            foreach (char symbol in text)
            {
                int caretIndex = CaretIndex;
                Password.InsertAt(caretIndex, symbol);
                HiddenText = HiddenText.Insert(caretIndex, symbol.ToString());
                if (IsPasswordMasked == true)
                {
                    MaskAllDisplayText();
                }
                Text = Text.Insert(caretIndex++, PasswordChar.ToString());
                CaretIndex = caretIndex;
            }
        }

        private void _RemoveFromSecureString(int startIndex, int trimLength)
        {
            int caretIndex = CaretIndex;
            for (int i = 0; i < trimLength; ++i)
            {
                Password.RemoveAt(startIndex);
                HiddenText = HiddenText.Remove(startIndex, 1);
            }

            Text = Text.Remove(startIndex, trimLength);
            CaretIndex = caretIndex;
        }

        internal void MaskAllDisplayText()
        {
            Text = new string(PasswordChar, Text.Length);
        }

        internal void UnMaskAllDisplayText()
        {
            Text = new string(Password.ToString());
        }
    }
}
