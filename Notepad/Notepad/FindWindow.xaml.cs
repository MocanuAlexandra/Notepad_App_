using Notepad.Models;
using Notepad.View_Models;
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
    /// Interaction logic for FindWindow.xaml
    /// </summary>

    public partial class FindWindow : Window
    {
        public FindWindow()
        {
            InitializeComponent();
        }

        #region Events
        private void Find_Click(object sender, RoutedEventArgs e)      
        {
            string searchedText = textBox.Text;         //get the input text from the textbox
            if (string.IsNullOrEmpty(searchedText))     //check if the user gave a valid input
            {
                return;
            }
            searchedText = searchedText.ToLower();

            FileModel selectedFile = MainWindow.mainWindow.tabControl.SelectedItem as FileModel; //get the current FileModel object

            //making sure that a tab is selected before beginning the search
            if (selectedFile == null)
            {
                if (MainWindow.mainViewModel.openFiles.Count == 0)
                    return;

                MainWindow.mainWindow.ChangeTab(0);
                selectedFile = MainWindow.mainWindow.tabControl.SelectedItem as FileModel;
            }

            //needed for caret position and displaying the found text position
            TextBox visibleTextBox = Utils.FindVisualChild<TextBox>(MainWindow.mainWindow.tabControl);
            Button senderButton = sender as Button;
            if (senderButton.Tag.ToString() == "next")
            {
                if (!allFiles.IsChecked.Value)
                {
                    Utils.FindNext(searchedText, selectedFile, visibleTextBox);
                }
                else
                {
                    //iterating through all files once, searching for the text
                    for (int searchedFilesCount = 0; searchedFilesCount <= MainWindow.mainViewModel.openFiles.Count; searchedFilesCount++)
                    {
                        if (Utils.FindNext(searchedText, selectedFile, visibleTextBox, false) == -1)
                        {
                            MainWindow.mainWindow.NextTab();
                            selectedFile = MainWindow.mainWindow.tabControl.SelectedItem as FileModel;
                            visibleTextBox = Utils.FindVisualChild<TextBox>(MainWindow.mainWindow.tabControl);
                        }
                        else
                        {
                            Focus();
                            return;
                        }
                    }
                    MessageBox.Show("Text not found!");
                }
            }
            else if (senderButton.Tag.ToString() == "previous")
            {
                if (!allFiles.IsChecked.Value)
                {
                    Utils.FindPrevious(searchedText, selectedFile, visibleTextBox);
                }
                else
                {
                    //iterating through all files once, searching for the text
                    for (int searchedFilesCount = 0; searchedFilesCount <= MainWindow.mainViewModel.openFiles.Count; searchedFilesCount++)
                    {
                        if (Utils.FindPrevious(searchedText, selectedFile, visibleTextBox, false) == -1)
                        {
                            MainWindow.mainWindow.PrevTab();
                            selectedFile = MainWindow.mainWindow.tabControl.SelectedItem as FileModel;
                            visibleTextBox = Utils.FindVisualChild<TextBox>(MainWindow.mainWindow.tabControl);
                        }
                        else
                        {
                            Focus();
                            return;
                        }
                    }

                    MessageBox.Show("Text not found!");
                }
            }
            Focus();
        }
        #endregion
    }
}
