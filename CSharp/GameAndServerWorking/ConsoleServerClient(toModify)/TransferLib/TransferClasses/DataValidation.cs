using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferLib.TransferClasses
{
    public class DataValidation
    {
        string sigStatus;
        int i = 0;
        int toCheckSize = 0;
        bool tagCorrect = false;
        byte[] toCheck = new byte[1024];
        public string CheckSignature(byte[] item)
        {
            for (int a = 0; a <= item.Length; a++)
            {
                if (item[i] == 126)
                {
                    i++;
                    for (int b = i; b <= item.Length; b++, i++)
                    {
                        if (item[i] == 126)
                        {
                            return CompareSignature(toCheck);
                        }
                        else
                        {
                            toCheckSize++;
                            toCheck[toCheckSize - 1] = item[i];
                        }
                    }
                    return "No Ending Signature Tag Found";
                }
                i++;
            }
            return "No Starting Signature Tag Found";
        }
        private string CompareSignature(byte[] toCompare)
        {
            byte[] dataBuf = new byte[toCheckSize];
            Array.Copy(toCheck, dataBuf, toCheckSize);
            string sigComp = Encoding.ASCII.GetString(dataBuf);
            if (sigComp == "LAGOTRONICS")
            {
                return "correct";
            }
            else
            {
                return "Wrong Signature";
            }
        }
    }
}
