using Notepad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Notepad
{
    public class Utils
    {
        #region UI_Methods
        //source: https://stackoverflow.com/questions/25229503/findvisualchild-reference-issue#:~:text=22-,FindVisualChild,-method%20is%20not
        //finds all visual children(of a given type) of a parent visual element
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj)
            where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        //used for finding a certain type of child visual item under a parent visual element
        public static childItem FindVisualChild<childItem>(DependencyObject obj)
            where childItem : DependencyObject
        {
            foreach (childItem child in FindVisualChildren<childItem>(obj))
            {
                return child;
            }

            return null;
        }
        #endregion

        #region Auxilliary Text Parsing Methods
        public static int FindNext(string searchedText, FileModel selectedFile, TextBox visibleTextBox, bool wrapAround = true)
        {
            int caretPositon = visibleTextBox.CaretIndex, searchStartPosition;

            //checking if the caret is already at a position indicating the searched text
            //if it is, then we search starting with a position starting after the current occurance of the searched text
            searchStartPosition = string.Compare(selectedFile.Text, caretPositon, searchedText, 0, searchedText.Length, true) == 0
                ? caretPositon + searchedText.Length
                : caretPositon;

            int foundIndex = selectedFile.Text.IndexOf(searchedText, searchStartPosition, StringComparison.OrdinalIgnoreCase);

            //checking if the searched text was found in the interval from the given position to the end of the file
            if (foundIndex != -1)
            {
                visibleTextBox.Focus();
                visibleTextBox.Select(foundIndex, searchedText.Length);
            }
            else if (wrapAround)
            {
                searchStartPosition = 0;
                foundIndex = selectedFile.Text.IndexOf(searchedText, searchStartPosition, StringComparison.OrdinalIgnoreCase);

                //if we still didn't find the searched text, then there is no occurance of the searched text in the file
                if (foundIndex != -1)
                {
                    visibleTextBox.Focus();
                    visibleTextBox.Select(foundIndex, searchedText.Length);
                }
                else
                {
                    MessageBox.Show("Text not found!");
                }
            }
            return foundIndex;
        }

        public static int FindPrevious(string searchedText, FileModel selectedFile, TextBox visibleTextBox, bool wrapAround = true)
        {
            int searchStartPosition = visibleTextBox.CaretIndex - 1;

            if (searchStartPosition == -1)
                searchStartPosition = selectedFile.Text.Length;
            int foundIndex = selectedFile.Text.LastIndexOf(searchedText, searchStartPosition, StringComparison.OrdinalIgnoreCase);

            //checking if the searched text was found in the interval from the given position to the end of the file
            //if it wasn't, then we search again from the beggining of the file(for wrap around rearch)
            if (foundIndex != -1)
            {
                visibleTextBox.Focus();
                visibleTextBox.Select(foundIndex, searchedText.Length);
            }
            else if (wrapAround)
            {
                searchStartPosition = selectedFile.Text.Length;
                foundIndex = selectedFile.Text.LastIndexOf(searchedText, searchStartPosition, StringComparison.OrdinalIgnoreCase);

                //if we still didn't find the searched text, then there is no occurance of the searched text in the file
                if (foundIndex != -1)
                {
                    visibleTextBox.Focus();
                    visibleTextBox.Select(foundIndex, searchedText.Length);
                }
                else
                    MessageBox.Show("Text not found!");
            }
            return foundIndex;
        }
        #endregion

    }
}
