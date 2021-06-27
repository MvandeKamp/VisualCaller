using Microsoft.Win32;
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
using VisualCaller.DataClasses;
using VisualCaller.Parser;
using VisualCaller.UserControls;

namespace VisualCaller
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TabControlVisualise mainVersion;
        public List<TabControlBitmapWrappanel> bitmapWrappanels = new List<TabControlBitmapWrappanel>();
        private int logFileCount = 0;
        public MainWindow()
        {
            InitializeComponent();
            mainVersion = new TabControlVisualise();
            tabControlMenuTabs.Items.Add(mainVersion);
            tabControlMenuTabs.SelectedItem = 0;
        }

        private void ReadFile_Click(object sender, RoutedEventArgs e)
        {
            List<FileLine> lines = new List<FileLine>();
            PhoneCallParser callParser = new PhoneCallParser();
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                InitialDirectory = Environment.CurrentDirectory
            };
            openFileDialog.ShowDialog();
            if(openFileDialog.FileName != null)
            {
                TabControlBitmapWrappanel activePanel;
                lines = callParser.StartParsing(openFileDialog.FileName);
                mainVersion.stackPanelLogFiles.Children.Add(new LogFileItem(logFileCount, openFileDialog.SafeFileName, mainVersion));
                activePanel = new TabControlBitmapWrappanel(logFileCount);
                bitmapWrappanels.Add(activePanel);
                mainVersion.tabControlFileTabs.Items.Add(activePanel);
                foreach (FileLine fileLine in lines.Where(fL => fL.Command == Command.ENTERQUEUE))
                {
                    try
                    {
                        FileLine matchingPair = lines.First(l => l.LineID == fileLine.LineID && l.Command != Command.ENTERQUEUE);
                        activePanel.contentPanel.Children.Add(new PhonenumberWithBitmap(fileLine, matchingPair, LineToBitmap.Create(matchingPair)));
                    } catch
                    {
                        Console.WriteLine("Nothing found");
                    }
                }
                mainVersion.tabControlFileTabs.SelectedIndex = logFileCount;
                logFileCount++;
            }
        }
    }
}
