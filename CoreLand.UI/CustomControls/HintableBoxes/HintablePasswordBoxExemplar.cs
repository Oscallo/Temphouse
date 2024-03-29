﻿using CoreLand.UI.CustomControls.HintableBoxes.Consts;
using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CoreLand.UI.CustomControls.HintableBoxes
{
    /// <summary>
    /// Спасибо за помощь в решении проблемы <seealso cref="https://stackoverflow.com/questions/17407620/custom-masked-passwordbox-in-wpf">Stackoverflow</seealso>
    /// </summary>
    [TemplatePart(Name = HintablePasswordBoxStrings.ButtonXAMLName, Type = typeof(Button))]
    public partial class HintablePasswordBox : HintableBoxBase
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
            _InitializeEvents();
            _InitializeHandlers();
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
            Text = new string(SecureStringToString(Password));
        }

        internal string SecureStringToString(SecureString value)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _InitializeTemplateEvents();
        }

        private void _InitializeTemplateEvents()
        {
            ((Button)Template.FindName(HintablePasswordBoxStrings.ButtonXAMLName, this)).PreviewMouseDown += HintablePasswordBox_MouseLeftButtonDown;
            ((Button)Template.FindName(HintablePasswordBoxStrings.ButtonXAMLName, this)).PreviewMouseUp += HintablePasswordBox_MouseLeftButtonUp;
        }

        private void _InitializeEvents() 
        {
            PreviewTextInput += _OnPreviewTextInput;
            PreviewKeyDown += _OnPreviewKeyDown;
        }

        private void HintablePasswordBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.IsPasswordMasked = true;
        }

        private void HintablePasswordBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.IsPasswordMasked = false;
        }

        private void _InitializeHandlers()
        {
            CommandManager.AddPreviewExecutedHandler(this, _PreviewExecutedHandler);
        }

        private void _UnInitializeHandlers()
        {
            CommandManager.RemovePreviewExecutedHandler(this, _PreviewExecutedHandler);
        }

        private void _UnInitializeEvents()
        {
            PreviewTextInput -= _OnPreviewTextInput;
            PreviewKeyDown -= _OnPreviewKeyDown;
            Loaded -= (_, __) =>
            {
                ((Button)Template.FindName(HintablePasswordBoxStrings.ButtonXAMLName, this)).MouseLeftButtonDown -= HintablePasswordBox_MouseLeftButtonDown;
                ((Button)Template.FindName(HintablePasswordBoxStrings.ButtonXAMLName, this)).MouseLeftButtonUp -= HintablePasswordBox_MouseLeftButtonUp;
            };
        }

    }
}
