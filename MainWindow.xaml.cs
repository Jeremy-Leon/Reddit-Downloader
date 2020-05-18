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
using RedditSharp;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Threading;
using System.Net;
using System.Drawing;
using Image = System.Drawing.Image;
using System.Security.Cryptography;

namespace RedditDownloader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*
        public void getUserPosts(string folderPath)
        {
            var reddit = new Reddit();
            var user = reddit.GetUser(username);
            //var user = reddit.GetUser("SckaughtE_D");
            string link = null;
            string title = null;
            var posts = user.Posts.Take(5);

            foreach (var post in posts)
            {
                title = post.Title.ToString();
                link = post.Url.ToString();

                System.Drawing.Image image = DownloadImageFromUrl(link);
                string rootPath = @"C:\\Users\\Jeremy\\Desktop\\Test";
                string fileName = System.IO.Path.Combine(rootPath, title + ".png");
                image.Save(fileName);
            }
            
        }
        */

        public System.Drawing.Image DownloadImageFromUrl(string imageUrl)
        {
            System.Drawing.Image image = null;

            try
            {
                System.Net.HttpWebRequest webRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(imageUrl);
                webRequest.AllowWriteStreamBuffering = true;
                webRequest.Timeout = 30000;

                System.Net.WebResponse webResponse = webRequest.GetResponse();

                System.IO.Stream stream = webResponse.GetResponseStream();

                image = System.Drawing.Image.FromStream(stream);

                webResponse.Close();
            }
            catch (Exception ex)
            {
                return null;
            }

            return image;
        }

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

        private void Test_Button(object sender, RoutedEventArgs e)
        {
            /*
            System.Drawing.Image image = DownloadImageFromUrl("https://thumbs.gfycat.com/SharpCourageousDesertpupfish-mobile.mp4");
            string rootPath = @"C:\\Users\\Jeremy\\Desktop\\Test";
            string fileName = System.IO.Path.Combine(rootPath, "test" + ".gif");
            image.Save(fileName);
            */

            using (var client = new WebClient())
            {
                client.DownloadFile("https://v.redd.it/hxxifx1a0zx41/DASH_720", "C:\\Users\\Jeremy\\Desktop\\Test\\test[♥️].mp4");
            }

        }
        private void Download_Button(object sender, RoutedEventArgs e)
        {
            clearError();
            InvalidateVisual();
            if (!verifyUser(textBox_username.Text))
            {
                throwError("User Does Not Exist!");
                return;
            }
                
            // Create local folder
            var downloadLoc = textBox_filelocation.Text;
            createFolder(downloadLoc);

            if (!Directory.Exists(downloadLoc))
                return;

            // Create folder for each check box
            bool pic = check_Pictures.IsChecked.Value;
            bool vid = check_Videos.IsChecked.Value;
            bool com = check_Comments.IsChecked.Value;
            string picLoc = null;
            string vidLoc = null;
            string comLoc = null;

            if (pic)
            {
                picLoc = downloadLoc + @"\Pictures";
                createFolder(picLoc);
            }
            if (vid)
            {
                vidLoc = downloadLoc + @"\Videos";
                createFolder(vidLoc);
            }
            if (com)
            {
                comLoc = downloadLoc + @"\Comments";
                createFolder(comLoc);
            }

            var reddit = new Reddit();
            var user = reddit.GetUser(textBox_username.Text);
            //var user = reddit.GetUser("SckaughtE_D");
            string link = null;
            string title = null;
            var posts = user.Posts.Take(200);
            Dictionary<int, string> picDict = new Dictionary<int, string>();
            int i = 0;
            List<string> dupeList = new List<string>();
            List<string> dupeTitle = new List<string>();

            foreach (var post in posts)
            {
                title = post.Title.ToString();
                link = post.Url.ToString();
                //Console.WriteLine(link);

                // Link is a picture
                if (Regex.Match(link, @"^.*\.(jpg|JPG|png|PNG|jpeg|JPEG)$").Success && pic)
                {
                    using (var client = new WebClient())
                    {
                        // Remove any non alphanumeric characters and shorten title
                        Regex rgx = new Regex("[^a-zA-Z0-9 ]");
                        title = rgx.Replace(title, "");
                        if(title.Length > 100)
                            title = title.Substring(0, 100);
                        if (dupeTitle.Contains(title))
                        {
                            continue;
                        }
                        else
                        {
                            dupeTitle.Add(title);
                        }

                        // Download and check for duplicates
                        string fileLoc = picLoc + "\\" + title + ".png";
                        client.DownloadFile(link, fileLoc);
                        Image img = Image.FromFile(fileLoc);
                        byte[] bytes = (byte[])(new ImageConverter()).ConvertTo(img, typeof(byte[]));

                        string hash;
                        using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
                        {
                            hash = Convert.ToBase64String(sha1.ComputeHash(bytes));
                        }

                        if(picDict.ContainsValue(hash))
                        {
                            dupeList.Add(fileLoc);
                        }
                        else
                        {
                            picDict.Add(i++, hash);
                        }
                        

                    }
                }
                // Link is a video/gif TODO: Format v.reddit, gfycat, redgifs links to work propperly
                if (Regex.Match(link, @"^.*\.(mp4|MP4|gif|GIF|gifv|GIFV)$").Success && pic)
                {/*
                    System.Drawing.Image image = DownloadImageFromUrl(link);
                    string rootPath = vidLoc;
                    string fileName = System.IO.Path.Combine(rootPath, title + ".mp4");
                    image.Save(fileName);
                    */
                }
            }
            // Delete duplicates
            foreach (var item in dupeList)
            {
                File.Delete(item);
            }

        }

        private void createFolder(string dir)
        {
            if (!Directory.Exists(dir))
            {
                try
                {
                    Directory.CreateDirectory(dir);
                }
                catch (Exception ex)
                {
                    throwError("Invalid Path or Path Denied");
                }
                
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
            var reddit = new Reddit();
            try
            {
                var user = reddit.GetUser(username);
            }
            catch (Exception ex)
            {
                return false;
            }
            clearError();
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
