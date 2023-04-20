using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace WorkWithPermissions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string FileName = "";

        public MainWindow()
        {
            InitializeComponent();

            if (IsAdmin())
            {
                MessageBox.Show("You are logged in with administrator rights!" +
                    "\nFor the application to work, you should disable them");
                Application.Current.Shutdown();
            }
        }

        private bool IsAdmin()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);

            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void BtnChooseFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == true)
            {
                FileName = openFileDialog.FileName ;
                TextFileName.Text = FileName;
            }
        }

        private void BtnZipFile(object sender, RoutedEventArgs e)
        {
            FileName = TextFileName.Text;
            if (FileName == "" && !File.Exists(FileName))
            {
                MessageBox.Show("Incorrect file!");
                return;
            }

            Process process = new Process();
            process.StartInfo.FileName = "ZipProcess.exe";
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.Verb = "open";
            process.StartInfo.Arguments = "\"" + FileName + "\"";

            process.Start();
            while (!process.HasExited) ;

            if (process.ExitCode == -2)
            {
                process.StartInfo.Verb = "runas";
                process.Start();
                while (!process.HasExited) ;
            };

            if (process.ExitCode == -3)
            {
                MessageBox.Show("Sorry, something went wrong...");
            }
            else if (process.ExitCode == 0)
            {
                MessageBox.Show("Zip file was created successfully!");
            }
            process.Close();
        }

        public void BtnConvertToPng(object sender, RoutedEventArgs e)
        {
            FileName = TextFileName.Text;
            if (FileName == "" && !File.Exists(FileName))
            {
                MessageBox.Show("Incorrect file!");
                return;
            }

            if (!IsImage(FileName))
            {
                MessageBox.Show("This is not an image!");
                return;
            }

            Process process = new Process();
            process.StartInfo.FileName = "PngProcess.exe";
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.Verb = "open";
            process.StartInfo.Arguments = "\"" + FileName + "\"";

            process.Start();
            while (!process.HasExited) ;

            if (process.ExitCode == -2)
            {
                process.StartInfo.Verb = "runas";
                process.Start();
                while (!process.HasExited) ;
            }

            if (process.ExitCode == 0)
            {
                MessageBox.Show("File was convert successfully!");
            }

            process.Close();
        }

        private static readonly HashSet<string> ImageExtensions = new HashSet<string>
        {
            ".jpg", ".tiff", ".gif", ".bmp", ".png" ,".pcx", ".jpeg", ".tif"
        };

        private bool IsImage(string filename)
        {
            string extension = Path.GetExtension(filename);
            return (ImageExtensions.Contains(extension));
        }

        public void BtnGetHash(object sender, RoutedEventArgs e)
        {
            FileName = TextFileName.Text;
            if (FileName == "" && !File.Exists(FileName))
            {
                MessageBox.Show("Incorrect file!");
                return;
            }

            ComboBoxItem typeItem = (ComboBoxItem)HashTypes.SelectedItem;
            string value = typeItem.Content.ToString();

            Process process = new Process();
            process.StartInfo.FileName = "HashProcess.exe";
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.Verb = "open";
            process.StartInfo.Arguments = "\"" + FileName + "\"" + " " + value;

            process.Start();
            while (!process.HasExited) ;

            if (process.ExitCode == -2)
            {
                process.StartInfo.Verb = "runas";
                process.Start();
                while (!process.HasExited) ;
            }

            if (process.ExitCode == 0)
            {
                MessageBox.Show("Hash was compute successfully!");
            }

            process.Close();
        }
    }
}
