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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VisualCaller.UserControls
{
    /// <summary>
    /// Interaktionslogik für LogFileItem.xaml
    /// </summary>
    public partial class LogFileItem : UserControl
    {
        public int id;
        private TabControlVisualise mainWindow;
        public LogFileItem(int matchingID, string fileName, TabControlVisualise main)
        {
            InitializeComponent();
            id = matchingID;
            txtFileName.Text = fileName;
            mainWindow = main;
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainWindow.tabControlFileTabs.SelectedIndex = id;
        }
    }
}
