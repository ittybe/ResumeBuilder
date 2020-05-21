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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ResumeBuilderGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            SelectTemplateWindow window = new SelectTemplateWindow();
            window.ShowDialog();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "resume builder file(*.rmsbldr)|*.rmsbldr|All files(*.*)|*.*";

            if (open.ShowDialog() == true) 
            {
                BinaryFormatter formatter = new BinaryFormatter();

                object template;
                // десериализация
                using (FileStream fs = new FileStream(open.FileName, FileMode.OpenOrCreate))
                {
                    template = formatter.Deserialize(fs);
                }
                if (template is WorkTemplate)
                {
                    WorkTemplateWindow window = new WorkTemplateWindow((WorkTemplate)template);
                    window.ShowActivated = true;
                    window.Show();
                }
                else if (template is WorkTemplate2)
                {
                    WorkTemplate2Window window = new WorkTemplate2Window((WorkTemplate2)template);
                    window.ShowActivated = true;
                    window.Show();
                }
            }
        }
    }
}
