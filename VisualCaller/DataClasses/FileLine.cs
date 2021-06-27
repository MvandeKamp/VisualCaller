using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualCaller.DataClasses
{
    public class FileLine
    {
        public double LineID { get; set; }
        public Command Command { get; set; }
        public int WaitTime { get; set; }
        public int CallTime { get; set; }
        public string PhoneNumber { get; set; }

        public FileLine(double lID, Command c, string pN)
        {
            LineID = lID;
            Command = c;
            WaitTime = 0;
            CallTime = 0;
            PhoneNumber = pN;
        }
        public FileLine(double lID, Command c, int wT, int cT)
        {
            LineID = lID;
            Command = c;
            WaitTime = wT;
            CallTime = cT;
            PhoneNumber = null;
        }
    }

    public enum Command{
        COMPLETEAGENT,
        ABANDON,
        ENTERQUEUE
    }
}
