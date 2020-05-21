using Microsoft.Win32;
using ResumeBuilderLib.Templates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ResumeBuilderGui
{
    /// <summary>
    /// Interaction logic for WorkTemplateWindow.xaml
    /// </summary>
    public partial class WorkTemplateWindow : Window
    {
        public FileInfo FocusedFile { get; set; } = null;

        private FileInfo imagePath;
        public WorkTemplate Template { get; set; }
        public WorkTemplateWindow()
        {
            InitializeComponent();
            Template = new WorkTemplate();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SetImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "png image (*.png)|*.png|jpg image (*.jpg)|*.jpg|All files (*.*)|*.*";
                if (open.ShowDialog() == true) 
                {
                    profileImage.Source = new BitmapImage(new Uri(open.FileName));
                    imagePath = new FileInfo(open.FileName);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddExp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextDocumentWindow text = new TextDocumentWindow();
                if (text.ShowDialog() == true) 
                {
                    expListBox.Items.Add(text.Text);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RemoveExp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                expListBox.Items.Remove(expListBox.SelectedItem);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddContact_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextDocumentWindow text = new TextDocumentWindow();
                if (text.ShowDialog() == true)
                {
                    contactListBox.Items.Add(text.Text);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RemoveContact_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                contactListBox.Items.Remove(contactListBox.SelectedItem);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Save() 
        {
            DumpTemplate();
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(FocusedFile.FullName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Template);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (FocusedFile == null)
                {
                    SaveFileDialog save = new SaveFileDialog();
                    save.Filter = "resume builder file(*.rmsbldr)|*.rmsbldr|All files(*.*)|*.*";
                    if (save.ShowDialog() == true)
                    {
                        FocusedFile = new FileInfo(save.FileName);
                        Save();
                    }
                }
                else 
                {
                    Save();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DumpTemplate() 
        {
            // Experience
            List<string> tempList = new List<string>();
            Template.Experience.Header = "Experience";

            foreach (var item in expListBox.Items)      
            {
                tempList.Add(item.ToString());
            }
            Template.Experience.Info = tempList.ToArray();
            tempList.Clear();

            // ProfileImage
            if (string.IsNullOrEmpty(imagePath.FullName) == true)
                throw new ApplicationException("profile image is empty");
            Template.ProfileImage.Filepath = imagePath.FullName;

            // Name
            Template.Name.Text = nameBox.Text;

            // ContactInfo
            Template.ContactInfo.Header = "ContactInfo";

            foreach (var item in contactListBox.Items)
            {
                tempList.Add(item.ToString());
            }
            Template.ContactInfo.Info = tempList.ToArray();
            tempList.Clear();

            // Birthday
            Template.Birthday.Text = birthdayBox.Text;
        }
    }
}
