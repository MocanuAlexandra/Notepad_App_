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
        private FileModel _document;

        // File Menu commands:
        public ICommand NewFileCommand { get; }
        public ICommand OpenCommand { get; }
        public ICommand SaveFileCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand CloseFileCommand { get; }
        public ICommand ExitCommand { get; }


        // Search Menu commands:
        public ICommand FindCommand { get; }
        public ICommand ReplaceCommand { get; }

        public ICommand ReplaceAllCommand { get; }


        // Edit Menu commands:
        public ICommand CopyCommand { get; }
        public ICommand PasteCommand { get; }


        // About Menu commands:
        public ICommand AboutCommand { get; }


        public ObservableCollection<FileModel> openFiles { get; set; } = new ObservableCollection<FileModel>();

        public MainViewModel()
        {

            NewFileCommand = new RelayCommand(NewFile);
            OpenCommand = new RelayCommand(OpenFile);
            SaveFileCommand = new RelayCommand(SaveFile);
            SaveAsCommand = new RelayCommand(SaveFileAs);
            CloseFileCommand = new RelayCommand(CloseFile);
            ExitCommand = new RelayCommand(Exit);

            FindCommand = new RelayCommand(Find);
            ReplaceCommand = new RelayCommand(Replace);
            ReplaceAllCommand = new RelayCommand(ReplaceAll);

            CopyCommand = new RelayCommand(Copy);
            PasteCommand = new RelayCommand(Paste);

            AboutCommand = new RelayCommand(DisplayAbout);
        }

        #region File Menu Events
        public void NewFile()
        {
            _document = new FileModel(string.Empty)
            {
                Text = string.Empty
            };

            int index = MainWindow.mainWindow.tabControl.Items.Count;
            _document.FilePath = "File (" + index + ")";
            openFiles.Add(_document);
        }

        public void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                openFiles.Add(new FileModel(openFileDialog.FileName));
            }
        }

        public void SaveFile()
        {
            FileModel selectedFile = MainWindow.mainWindow.tabControl.SelectedItem as FileModel;

            if (!File.Exists(selectedFile.FilePath))
            {
                SaveFileAs();
            }
            else
            {
                selectedFile.WriteFile();
            }
        }

        private void SaveFileAs()
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

        private void CloseFile()
        {
            FileModel selectedFile = MainWindow.mainWindow.tabControl.SelectedItem as FileModel;

            if (selectedFile != null)
            {
                openFiles.Remove(selectedFile);
            }
            else
            {
                MessageBox.Show("No file selected!");
            }
        }

        private void Exit()
        {
            Application.Current.Shutdown();
        }

        #endregion

        #region Search Menu Events
        private void Find()
        {
            FindWindow findWindow = new FindWindow();
            findWindow.Show();
        }

        private void Replace()
        {
            ReplaceWindow replaceWindow = new ReplaceWindow(false);
            replaceWindow.Show();
        }

        private void ReplaceAll()
        {
            ReplaceWindow replaceWindow = new ReplaceWindow(true);
            replaceWindow.Show();
        }

        #endregion

        #region Edit Menu Events
        private void Copy()
        {

        }
        private void Paste()
        {

        }
        #endregion

        #region Help Menu Events
        private void DisplayAbout()
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Show();
        }
        #endregion
    }
}
