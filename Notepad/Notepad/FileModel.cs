using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Models
{
    public class FileModel : ObservableObject
    {
        private string _text;
        private string _filePath;
        private string _selectedTextFile;
        private bool _hasChanged;

        public string Text
        {
            get => _text;
            set
            {
                OnPropertyChange(ref _text, value);
                OnPropertyChange(ref _hasChanged, true, "HasChanged");
            }
        }
        public string FilePath
        {
            get => _filePath;
            set => OnPropertyChange(ref _filePath, value, "Name");
        }
        public string SelectedTextFile
        {
            get => _selectedTextFile;
            set => OnPropertyChange(ref _selectedTextFile, value);

        }
        public bool HasChanged
        {
            get => _hasChanged;
            set
            {
                _hasChanged = value;
            }
        }
        public FileModel(string FilePath)
        {
            _filePath = FilePath;
            _text = string.Empty;
            ReadFile();
        }
        public string Name => Path.GetFileName(FilePath);

        public void WriteFile()
        {
            File.WriteAllText(_filePath, _text);
            HasChanged = false;
            OnPropertyChange(ref _hasChanged, false, "HasChanged");
        }
        private void ReadFile()
        {
            if (File.Exists(_filePath))
                _text = File.ReadAllText(_filePath);
        }
    }
}
