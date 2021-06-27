using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualCaller.DataClasses;

namespace VisualCaller.Parser
{
    static class LineToBitmap
    {
        public static Bitmap Create(FileLine line)
        {
            Bitmap bitmap = new Bitmap(1000, 100);
            int x, y;
            if (line != null)
            {
                /*Dieser Code erlaubt nur 100 sekunden aber mir würde gerade kein anderer einfallen der die Daten
                nicht verfälschen würde und damit das vergleichen zwischen verschiedenen Anrufen nicht möglich wäre.
                Dazu ist es recht langsam so auf Bitmaps zu zeichen anstatt sich vorher rectangles zusammen zu setzen
                und diese zu benutzen aber es wurde nach Bitmaps gefragt und ich deswegen eine konventierung von 
                rectangles zu images und dann von den images zu bitmaps nur um sie dann wieder als image anzuzeigen
                nicht für sinvoll heiße*/
                for (x = 0; x < bitmap.Width; x++)
                {
                    for (y = 0; y < bitmap.Height; y++)
                    {
                        bitmap.SetPixel(x, y, Color.FromArgb(32, 34, 37));
                    }
                }
                if (line.Command == Command.ABANDON)
                {
                    Color red = Color.FromArgb(255, 0, 0);
                    for (x = 0; x < (line.WaitTime * 10); x++)
                    {
                        for (y = 0; y < 40; y++)
                        {
                            bitmap.SetPixel(x, y, red);
                        }
                    }
                }
                else
                {
                    Color yellow = Color.FromArgb(255, 255, 0);
                    Color green = Color.FromArgb(0, 255, 0);
                    for (x = 0; x < (line.WaitTime * 10); x++)
                    {
                        for (y = 0; y < 40; y++)
                        {
                            bitmap.SetPixel(x, y, yellow);
                        }
                    }
                    for (x = 0; x < (line.CallTime * 10); x++)
                    {
                        for (y = 50; y < 100; y++)
                        {
                            bitmap.SetPixel(x, y, green);
                        }
                    }
                }
            }
            return bitmap;
        }
    }
}
