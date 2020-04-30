using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Packaging;
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
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;

namespace RedditDownloader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string defaultLocation = @"C:\Users\";
        public MainWindow()
        {
            InitializeComponent();
            textBox_filelocation.Text = defaultLocation;
            pb_TotalProgress.Value = 50;
        }

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {    
            textBox_filelocation.Text = defaultLocation + textBox_username.Text;
        }

        private void Location_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Download_Button(object sender, RoutedEventArgs e)
        {
            verifyUser(textBox_username.Text);

            // Create local folder
            var downloadLoc = textBox_filelocation.Text;
            createFolder(downloadLoc);

            // Create folder for each check box
            bool pic = check_Pictures.IsChecked.Value;
            bool vid = check_Videos.IsChecked.Value;
            bool com = check_Comments.IsChecked.Value;

            if (pic)
            {
                createFolder(downloadLoc + @"\Pictures");
            }
            if (vid)
            {
                createFolder(downloadLoc + @"\Videos");
            }
            if (com)
            {
                createFolder(downloadLoc + @"\Comments");
            }
        }

        private void createFolder(string dir)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }

        private void ChangeFileLoc_Button(object sender, RoutedEventArgs e)
        {
            var username = textBox_username.Text;
            var folderLoc = getFolderLocation();
            var downloadLoc = String.Concat(folderLoc, @"\", username);
            textBox_filelocation.Text = downloadLoc;
            defaultLocation = folderLoc + @"\";
        }

        private bool verifyUser(string username)
        {
            // TODO: Verify through reddit if the username exists
            // TODO: regex check for weird characters
            return true;
        }

        private void throwError(string err)
        {
            textBlock_error.Text = err;
        }
        private void clearError()
        {
            textBlock_error.Text = "";
        }
        private string getFolderLocation()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users\\Jeremy\\Desktop\\Test";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                return dialog.FileName;
            }
            return null;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
