using Microsoft.Win32;
using Notepad.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;


namespace Notepad.View_Models
{
    public class MainViewModel
    {
        // counter for new files
        private int newFiles = 0;

        // File Menu commands:
        public ICommand NewFileCommand { get; }
        public ICommand OpenCommand { get; }
        public ICommand SaveFileCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand ExitCommand { get; }


        // Search Menu commands:
        public ICommand FindCommand { get; }
        public ICommand ReplaceCommand { get; }
        public ICommand ReplaceAllCommand { get; }


        // Edit Menu commands:
        public ICommand CopyCommand { get; }
        public ICommand PasteCommand { get; }
        public ICommand CutCommand { get; }
        public ICommand LowercaseCommand { get; }
        public ICommand UppercaseCommand { get; }


        // About Menu commands:
        public ICommand AboutCommand { get; }

        public ObservableCollection<FileModel> openFiles { get; set; } = new ObservableCollection<FileModel>();

        public MainViewModel()
        {
            NewFileCommand = new RelayCommand(NewFile);
            OpenCommand = new RelayCommand(OpenFile);
            SaveFileCommand = new RelayCommand(SaveFile);
            SaveAsCommand = new RelayCommand(SaveFileAs);
            ExitCommand = new RelayCommand(Exit);

            FindCommand = new RelayCommand(Find);
            ReplaceCommand = new RelayCommand(Replace);
            ReplaceAllCommand = new RelayCommand(ReplaceAll);

            CopyCommand = new RelayCommand(Copy);
            PasteCommand = new RelayCommand(Paste);
            CutCommand = new RelayCommand(Cut);
            LowercaseCommand = new RelayCommand(Lowercase);
            UppercaseCommand = new RelayCommand(Uppercase);


            AboutCommand = new RelayCommand(DisplayAbout);
        }

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
                Filter = "Text File (*.txt)|*.txt",
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
            TextBox visibleTextBox = Utility.FindVisualChild<TextBox>(MainWindow.mainWindow.tabControl);
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

            TextBox visibleTextBox = Utility.FindVisualChild<TextBox>(MainWindow.mainWindow.tabControl);
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
            TextBox visibleTextBox = Utility.FindVisualChild<TextBox>(MainWindow.mainWindow.tabControl);
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
            TextBox visibleTextBox = Utility.FindVisualChild<TextBox>(MainWindow.mainWindow.tabControl);
            int caretPositon = visibleTextBox.CaretIndex;
            FileModel selectedFile = MainWindow.mainWindow.tabControl.SelectedItem as FileModel;
            selectedFile.Text = selectedFile.Text.Remove(caretPositon, textToModify.Length);

            // paste modified text
            selectedFile.Text = selectedFile.Text.Insert(caretPositon, modifiedText);
        }

        #endregion

        #region Help Menu Events
        private void DisplayAbout(object obj)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Show();
        }
        #endregion

    }
}
