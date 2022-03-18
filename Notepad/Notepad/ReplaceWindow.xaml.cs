using Notepad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for ReplaceWindow.xaml
    /// </summary>
    public partial class ReplaceWindow : Window
    {
        public ReplaceWindow(bool replaceAllFunction)
        {
            InitializeComponent();
            replaceAll.IsEnabled = replaceAllFunction;
        }

        #region Events
        private void Replace_Clicked(object sender, RoutedEventArgs e)
        {

            string textToBeReplaced, replacementText;
            textToBeReplaced = replaceTextBox.Text;
            replacementText = withTextBox.Text;
          
            //check if strings are empty or there is no file open in tab
            if (textToBeReplaced == string.Empty || replacementText == string.Empty ||
                MainWindow.mainViewModel.openFiles.Count == 0)
                return;

            FileModel selectedFile = MainWindow.mainWindow.tabControl.SelectedItem as FileModel; //get the current File Model object

            if (allFiles.IsChecked.Value) //checking all files for first occurance to replace
            {
                if (selectedFile == null)
                {
                    MainWindow.mainWindow.ChangeTab(0);
                    selectedFile = MainWindow.mainWindow.tabControl.SelectedItem as FileModel;
                }

                TextBox visibleTextBox = Utility.FindVisualChild<TextBox>(MainWindow.mainWindow.tabControl);

                //iterating through all files, searching for the text
                for (int searchedFilesCount = 0; searchedFilesCount <= MainWindow.mainViewModel.openFiles.Count; searchedFilesCount++)
                {
                    //finding the first position of the text that needs to be replaced
                    int posIndex = Utility.FindNext(textToBeReplaced, selectedFile, visibleTextBox, false);

                    //if text not found in one file, we are changing the tab to search in another file
                    if (posIndex == -1)
                    {
                        MainWindow.mainWindow.NextTab();
                        selectedFile = MainWindow.mainWindow.tabControl.SelectedItem as FileModel;
                        visibleTextBox = Utility.FindVisualChild<TextBox>(MainWindow.mainWindow.tabControl);
                    }
                    else
                    {
                        //replacing the string by deleting it, and inserting the replacement
                        selectedFile.Text = selectedFile.Text.Remove(posIndex,
                                                    textToBeReplaced.Length).Insert(posIndex, replacementText);
                        visibleTextBox.Select(posIndex, replacementText.Length);
                        Focus();
                        return;
                    }
                }
            }
            else //checking the current file for first occurance and replacing
            {
                if (selectedFile == null)
                {
                    MessageBox.Show("No selected file!");
                    return;
                }

                //finding the first occurance of the text that needs to be replaced
                TextBox visibleTextBox = Utility.FindVisualChild<TextBox>(MainWindow.mainWindow.tabControl);
                int posIndex = Utility.FindNext(textToBeReplaced, selectedFile, visibleTextBox);

                //replacing the string by deleting it, and inserting the replacement
                selectedFile.Text = selectedFile.Text.Remove(posIndex,
                                            textToBeReplaced.Length).Insert(posIndex, replacementText);
                visibleTextBox.Select(posIndex, replacementText.Length);
            }
            Focus();
        }

        private void ReplaceAll_Clicked(object sender, RoutedEventArgs e)
        {
           
            string textToBeReplaced, replacementText;
            textToBeReplaced = replaceTextBox.Text;
            replacementText = withTextBox.Text;

            //check if strings are empty or there is no file open in tab
            if (textToBeReplaced == string.Empty || replacementText == string.Empty ||
                MainWindow.mainViewModel.openFiles.Count == 0)
                return;

            FileModel selectedFile = MainWindow.mainWindow.tabControl.SelectedItem as FileModel; //get the current FileModel object

            if (allFiles.IsChecked.Value) //checking all files for first occurance to replace
            {
                foreach (FileModel file in MainWindow.mainViewModel.openFiles)
                    file.Text = Regex.Replace(file.Text, textToBeReplaced, replacementText, RegexOptions.IgnoreCase);
            }
            else //else we only need to replace all text in just the selected file
            {
                selectedFile = MainWindow.mainWindow.tabControl.SelectedItem as FileModel; //get the current FileModel object

                if (selectedFile == null)
                {
                    MessageBox.Show("No selected file!");
                    return;
                }
                selectedFile.Text = Regex.Replace(selectedFile.Text, textToBeReplaced, replacementText, RegexOptions.IgnoreCase);
            }
        }

        #endregion
    }
}
