using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingDataLib.TransferClasses
{
    public class StringTransferItem
    {
        public int ID { get; set; }
        public string SigTag { get; set; }
        public string TransSignature { get; set; }
        public string ScoreTag { get; set; }
        public string Score { get; set; }
        public string DateTag { get; set; }
        public string TransDate { get; set; }
        public string TimeTag { get; set; }
        public string TransTime { get; set; }
        public string AppNameTag { get; set; }
        public string AppName { get; set; }
        public string PCNameTag { get; set; }
        public string PCName { get; set; }
        public string IpTag { get; set; }
        public string IpAddress { get; set; }
    }
}
 