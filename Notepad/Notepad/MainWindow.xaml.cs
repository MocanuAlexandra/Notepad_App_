using Notepad.Models;
using Notepad.View_Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public static MainWindow mainWindow;
        public static MainViewModel mainVM;
        public MainWindow()
        {
            InitializeComponent();
            DirManager.FileExplorer.InitFileExplorer(fileExplorer);

            mainWindow = this;
            mainVM = DataContext as MainViewModel;

            FileModel textFile = new FileModel(@"..\..\Some files\Machiavelli-ThePrince.txt");
            mainVM.openFiles.Add(textFile);

        }

        #region TabControl Events
        private void CloseTab(object sender, RoutedEventArgs e)
        {
            Button closeBtn = sender as Button;

            //find the FileModel object that is responsible for the tab to be closed
            foreach (FileModel file in mainVM.openFiles)
            {
                if (file.FilePath == closeBtn.Tag.ToString())
                {
                    mainVM.openFiles.Remove(file);
                    break;
                }
            }
        }
        #endregion

        #region FileExplorer Events
        private void TreeViewItem_Expanded(object sender, RoutedEventArgs e)
        {
            //when the tree is expanded, explore the new children
            TreeViewItem item = e.OriginalSource as TreeViewItem;
            DirManager.FileExplorer.ExploreChildren(item);
        }
        #endregion

        #region Auxilliary Methods
        public void ChangeTab(int tabIndex)
        {
            tabControl.SelectedIndex = tabIndex;
            UpdateLayout(); //needed in order for the change to be applied immediatly
        }

        //changes tab to the next one in indexing order
        public void NextTab(bool wrapAround = true)
        {
            if (mainVM.openFiles.Count == 0)
                return;

            if (tabControl.SelectedIndex == mainVM.openFiles.Count - 1 && wrapAround)
                ChangeTab(0);
            else
                ChangeTab(tabControl.SelectedIndex + 1);
        }

        //changes tab to the previous one in indexing order
        public void PrevTab(bool wrapAround = true)
        {
            if (mainVM.openFiles.Count == 0)
                return;

            if (tabControl.SelectedIndex == 0 && wrapAround)
                ChangeTab(mainVM.openFiles.Count - 1);
            else
                ChangeTab(tabControl.SelectedIndex - 1);
        }
        #endregion

       
    }
}
