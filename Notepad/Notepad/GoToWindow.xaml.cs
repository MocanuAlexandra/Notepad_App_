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
            TextBox visibleTextBox = Utils.FindVisualChild<TextBox>(MainWindow.mainWindow.tabControl);
            if (visibleTextBox == null)
            {
                MessageBox.Show("No tabs selected!");
                return;
            }

            int lineNumber;
            try
            {
                lineNumber = Int32.Parse(textBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Not a valid line number!");
                return;
            }

            if (visibleTextBox.LineCount < lineNumber)
            {
                MessageBox.Show("Line number does not exist in the selected file!");
                return;
            }

            visibleTextBox.Focus();
            visibleTextBox.Select(visibleTextBox.GetCharacterIndexFromLineIndex(lineNumber), 1);
            Focus();
        }

        #endregion
    }
}
