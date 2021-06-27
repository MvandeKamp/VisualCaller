using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

namespace VisualCaller.UserControls
{
    /// <summary>
    /// Interaktionslogik für PhonenumberWithBitmap.xaml
    /// </summary>
    public partial class PhonenumberWithBitmap : UserControl
    {
        public PhonenumberWithBitmap(FileLine enterQueueFileLine, FileLine complete, Bitmap bitmap)
        {
            InitializeComponent();
            txtPhoneNumber.Text = enterQueueFileLine.PhoneNumber;
            bitmapImage.Source = BitmapToImageSource(bitmap);
            if(complete != null)
            {
                if (complete.Command == Command.ABANDON)
                {
                    txtWaitTime.Text = "Wartezeit: " + complete.WaitTime + "s";
                    txtCallTime.Text = "Sprechzeit: /";
                }
                else
                {
                    txtWaitTime.Text = "Wartezeit: " + complete.WaitTime + "s";
                    txtCallTime.Text = "Sprechzeit: " + complete.CallTime + "s";
                }
            }
        }
        //Copypasted aber nur relevant für WPF nicht für die Aufgabe 
        private BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }
    }
}
