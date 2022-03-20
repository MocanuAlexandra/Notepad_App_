using Microsoft.Win32;
using Notepad.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;


namespace Notepad.View_Models
{
    public class MainViewModel
    {
        #region Commands

        #region File Menu commands

        public ICommand NewFileCommand { get; }
        public ICommand OpenCommand { get; }
        public ICommand SaveFileCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand ExitCommand { get; }
       
        #endregion

        #region  Search Menu commands

        public ICommand FindCommand { get; }
        public ICommand ReplaceCommand { get; }
        public ICommand ReplaceAllCommand { get; }
        public ICommand GoToLineCommand { get; }

        #endregion

        #region Edit Menu commands

        public ICommand CopyCommand { get; }
        public ICommand PasteCommand { get; }
        public ICommand CutCommand { get; }
        public ICommand LowercaseCommand { get; }
        public ICommand UppercaseCommand { get; }
        public ICommand RemoveEmptyLinesCommand { get; }
        public ICommand ReadOnlyCommand { get; }

        #endregion

        #region About Menu commands
        public ICommand AboutCommand { get; }

        #endregion

        #endregion

        // Counter for new files
        private int newFiles = 0;

        // Observable collection in tabControl
        public ObservableCollection<FileModel> openFiles { get; set; } = new ObservableCollection<FileModel>();

        public MainViewModel()
        {
            // ************* File Menu ************** //
            NewFileCommand = new RelayCommand(NewFile);
            OpenCommand = new RelayCommand(OpenFile);
            SaveFileCommand = new RelayCommand(SaveFile);
            SaveAsCommand = new RelayCommand(SaveFileAs);
            ExitCommand = new RelayCommand(Exit);

            // ************* Search Menu ************ //
            FindCommand = new RelayCommand(Find);
            ReplaceCommand = new RelayCommand(Replace);
            ReplaceAllCommand = new RelayCommand(ReplaceAll);
            GoToLineCommand = new RelayCommand(GoToLine);

            // ************ Edit Menu **************** //
            CopyCommand = new RelayCommand(Copy);
            PasteCommand = new RelayCommand(Paste);
            CutCommand = new RelayCommand(Cut);
            LowercaseCommand = new RelayCommand(Lowercase);
            UppercaseCommand = new RelayCommand(Uppercase);
            RemoveEmptyLinesCommand = new RelayCommand(RemoveEmptyLines);
            ReadOnlyCommand = new RelayCommand(ReadOnly);

            // ************ About Menu **************** //
            AboutCommand = new RelayCommand(DisplayAbout);
        }

        #region Events

        #region File Menu Events
        public void NewFile(object obj)
        {
            openFiles.Add(new FileModel($"File({newFiles}).txt"));
            newFiles++;
        }

        public void OpenFile(object obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                openFiles.Add(new FileModel(openFileDialog.FileName));
            }
        }

        public void SaveFile(object obj)
        {
            FileModel selectedFile = MainWindow.mainWindow.tabControl.SelectedItem as FileModel;

            if (selectedFile == null)
                return;

            if (!File.Exists(selectedFile.FilePath))
            {
                SaveFileAs(obj);
            }
            else
            {
                selectedFile.WriteFile();
            }
        }

        private void SaveFileAs(object obj)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                DefaultExt = ".txt",
                Filter = "Text documents (*.txt)|*.txt",
                Title = "Save Text File"
            };

            FileModel selectedFile = MainWindow.mainWindow.tabControl.SelectedItem as FileModel;

            //checking if there is any file currently selected
            if (selectedFile == null)
            {
                MessageBox.Show("No file selected!");
                return;
            }

            //asking the user to select where to save the file
            if (saveFileDialog.ShowDialog() == true)
            {
                selectedFile.FilePath = saveFileDialog.FileName;
                selectedFile.WriteFile();
            }
        }

        private void Exit(object obj)
        {
            Application.Current.Shutdown();
        }

        #endregion

        #region Search Menu Events
        private void Find(object obj)
        {
            FindWindow findWindow = new FindWindow();
            findWindow.Show();
        }

        private void Replace(object obj)
        {
            ReplaceWindow replaceWindow = new ReplaceWindow(false);
            replaceWindow.Show();
        }

        private void ReplaceAll(object obj)
        {
            ReplaceWindow replaceWindow = new ReplaceWindow(true);
            replaceWindow.Show();
        }

        private void GoToLine(object obj)
        {
            GoToWindow gotoWindow = new GoToWindow();
            gotoWindow.Show();
        }

        #endregion

        #region Edit Menu Events
        private void Copy(object obj)
        {
            Clipboard.SetText(obj.ToString());
        }
             
        private void Paste(object obj)
        {
            // get the text from clipboard  
            string textToPaste = Clipboard.GetText();
            TextBox visibleTextBox = Utils.FindVisualChild<TextBox>(MainWindow.mainWindow.tabControl);
            int caretPositon = visibleTextBox.CaretIndex;

            // concatenate the text from selected file with text from clipboard
            // startIndex to insert is caretPosition
            FileModel selectedFile = MainWindow.mainWindow.tabControl.SelectedItem as FileModel;
            selectedFile.Text = selectedFile.Text.Insert(caretPositon, textToPaste);

        }

        private void Cut(object obj)
        {
            // set the text to clipboard
            string textToCut = obj.ToString();
            Clipboard.SetText(textToCut);

            TextBox visibleTextBox = Utils.FindVisualChild<TextBox>(MainWindow.mainWindow.tabControl);
            int caretPositon = visibleTextBox.CaretIndex;

            // remove textToCut from slectedFile.Text 
            // startIndex to remove is caretPosition
            FileModel selectedFile = MainWindow.mainWindow.tabControl.SelectedItem as FileModel;
            selectedFile.Text = selectedFile.Text.Remove(caretPositon, textToCut.Length);
        }

        private void Lowercase(object obj)
        {
            // set the text to clipboard
            string textToModify = obj.ToString();
            Clipboard.SetText(textToModify);

            // modify text
            string modifiedText = textToModify.ToLower();

            // cut original text
            TextBox visibleTextBox = Utils.FindVisualChild<TextBox>(MainWindow.mainWindow.tabControl);
            int caretPositon = visibleTextBox.CaretIndex;
            FileModel selectedFile = MainWindow.mainWindow.tabControl.SelectedItem as FileModel;
            selectedFile.Text = selectedFile.Text.Remove(caretPositon, textToModify.Length);

            // paste modified text
            selectedFile.Text = selectedFile.Text.Insert(caretPositon, modifiedText);
        }

        private void Uppercase(object obj)
        {
            // set the text to clipboard
            string textToModify = obj.ToString();
            Clipboard.SetText(textToModify);

            // modify text
            string modifiedText = textToModify.ToUpper();

            // cut original text
            TextBox visibleTextBox = Utils.FindVisualChild<TextBox>(MainWindow.mainWindow.tabControl);
            int caretPositon = visibleTextBox.CaretIndex;
            FileModel selectedFile = MainWindow.mainWindow.tabControl.SelectedItem as FileModel;
            selectedFile.Text = selectedFile.Text.Remove(caretPositon, textToModify.Length);

            // paste modified text
            selectedFile.Text = selectedFile.Text.Insert(caretPositon, modifiedText);
        }

        private void RemoveEmptyLines(object obj)
        {
            string textToModify = obj.ToString();
            string newText = Regex.Replace(textToModify, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);

            FileModel selectedFile = MainWindow.mainWindow.tabControl.SelectedItem as FileModel;
            selectedFile.Text = newText;
        }

        private void ReadOnly(object obj)
        {
            bool isReadOnly = (bool)obj;
            FileModel selectedFile = MainWindow.mainWindow.tabControl.SelectedItem as FileModel;
            if (selectedFile == null)
            {
                MessageBox.Show("No file selected!");
                return;
            }
            selectedFile.IsReadonly = !isReadOnly;
        }
        #endregion

        #region Help Menu Events
        private void DisplayAbout(object obj)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Show();
        }
        #endregion

        #endregion
    }
}
