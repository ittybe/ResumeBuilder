using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ResumeBuilderGui
{
    /// <summary>
    /// Interaction logic for SelectTemplateWindow.xaml
    /// </summary>
    public partial class SelectTemplateWindow : Window
    {
        public SelectTemplateWindow()
        {
            InitializeComponent();
        }

        private void WorkTemplate_Click(object sender, RoutedEventArgs e)
        {
            WorkTemplateWindow window = new WorkTemplateWindow();
            window.ShowActivated = true;
            window.Show();
        }

        private void WorkTemplate2_Click(object sender, RoutedEventArgs e)
        {
            WorkTemplate2Window window = new WorkTemplate2Window();
            window.ShowActivated = true;
            window.Show();
        }
    }
}
