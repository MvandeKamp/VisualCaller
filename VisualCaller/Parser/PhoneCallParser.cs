using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VisualCaller.DataClasses;

namespace VisualCaller.Parser
{
    public class PhoneCallParser
    {
        private List<FileLine> lines = new List<FileLine>();

        public List<FileLine> StartParsing(string path)
        {
            try 
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    string currentLine;
                    while((currentLine = streamReader.ReadLine()) != null)
                    {
                        var context = currentLine.Split('|');
                        switch (context[4])
                        {
                            case "COMPLETEAGENT":
                            case "COMPLETECALLER":
                                lines.Add(new FileLine(Double.Parse(context[1], CultureInfo.InvariantCulture), Command.COMPLETEAGENT, Int32.Parse(context[5]), Int32.Parse(context[6])));
                                break;
                            case "ABANDON":
                                lines.Add(new FileLine(Double.Parse(context[1], CultureInfo.InvariantCulture), Command.ABANDON, Int32.Parse(context[7]), 0));
                                break;
                            case "ENTERQUEUE":
                                lines.Add(new FileLine(Double.Parse(context[1], CultureInfo.InvariantCulture), Command.ENTERQUEUE, context[6]));
                                break;
                            default:
                                break;
                        }
                    }
                }
            } catch
            {
                Console.WriteLine("Error while parsing the file");
            }
            return lines;
        }
       
    }
}
