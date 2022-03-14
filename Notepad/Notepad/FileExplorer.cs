using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DirManager
{
    public static class FileExplorer
    {
        //gets the main partitions and explorer one level down
        public static void InitFileExplorer(TreeView fileExplorer)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = item.Tag = drive.Name;
                fileExplorer.Items.Add(item);
                ExploreDir(item, drive.Name);
            }
        }

        //explores the subdirectories and files of the given item
        public static void ExploreChildren(TreeViewItem parentItem)
        {

            foreach (TreeViewItem subDir in parentItem.Items)
            {
                if (Directory.Exists(subDir.Tag.ToString()))
                    ExploreDir(subDir, subDir.Tag.ToString());
            }
        }

        //explores the contents of a directory
        public static void ExploreDir(TreeViewItem parentItem, string parentPath)
        {
            try
            {
                DirectoryInfo currentDirInfo = new DirectoryInfo(parentPath);

                //listing subdirectories
                DirectoryInfo[] subDirs = currentDirInfo.GetDirectories();

                foreach (DirectoryInfo directory in subDirs)
                {
                    //check if the directory is hidden or is a system dir
                    //(so we do not show dirs like recycle bin)
                    if ((directory.Attributes & FileAttributes.System) != FileAttributes.System &&
                               (directory.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                    {
                        TreeViewItem item = new TreeViewItem();
                        item.Header = directory.Name;
                        item.Tag = directory.FullName;
                        parentItem.Items.Add(item);
                    }
                }

                //listing files
                FileInfo[] files = currentDirInfo.GetFiles();

                foreach (FileInfo file in files)
                {
                    if ((file.Attributes & FileAttributes.System) != FileAttributes.System &&
                               (file.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                    {
                        TreeViewItem item = new TreeViewItem();
                        item.Header = file.Name;
                        item.Tag = file.FullName;
                        parentItem.Items.Add(item);
                    }
                }
            }
            catch (Exception)
            {
                /*exception caught*/
            }
        }
    }
}
