using Notepad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Notepad
{
    /// <summary>
    /// Interaction logic for GoToWindow.xaml
    /// </summary>
    public partial class GoToWindow : Window
    {
        public GoToWindow()
        {
            InitializeComponent();
        }

        #region Event
        private void GoTo_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                return;
            }

            int lineNumber = Int32.Parse(textBox.Text);
            TextBox visibleTextBox = Utils.FindVisualChild<TextBox>(MainWindow.mainWindow.tabControl);
            visibleTextBox.ScrollToLine(lineNumber);
            visibleTextBox.CaretIndex = lineNumber;
            visibleTextBox.Focus();
        }

        #endregion
    }
}
