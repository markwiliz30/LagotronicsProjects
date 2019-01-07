using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketConnectionLib;

namespace SavingDataLib.TransferClasses
{
    public class TransferManager
    {
        StringTransferItem itemToSend;
        SendReceive transSendRec = new SendReceive();
        string holdVal;
        public void SetAndSend(StringTransferItem myItem)
        {
            itemToSend = new StringTransferItem();
            itemToSend.SigTag = "~";
            itemToSend.TransSignature = myItem.TransSignature;
            itemToSend.IpTag = "!";
            itemToSend.IpAddress = transSendRec._publicClientSocket.LocalEndPoint.ToString();
            itemToSend.PCNameTag = "@";
            itemToSend.PCName = System.Environment.MachineName;
            itemToSend.AppNameTag = "#";
            itemToSend.AppName = myItem.AppName;
            itemToSend.ScoreTag = "$";
            itemToSend.Score = myItem.Score;
            itemToSend.DateTag = "%";
            itemToSend.TransDate = DateTime.Today.ToShortDateString();
            itemToSend.TimeTag = "^";
            itemToSend.TransTime = DateTime.Now.ToString("HH:mm");

            holdVal = itemToSend.SigTag + itemToSend.TransSignature + itemToSend.SigTag + itemToSend.IpTag + itemToSend.IpAddress + itemToSend.IpTag + itemToSend.PCNameTag + itemToSend.PCName + itemToSend.PCNameTag + itemToSend.AppNameTag + itemToSend.AppName + itemToSend.AppNameTag + itemToSend.ScoreTag + itemToSend.Score + itemToSend.ScoreTag + itemToSend.DateTag + itemToSend.TransDate + itemToSend.DateTag + itemToSend.TimeTag + itemToSend.TransTime + itemToSend.TimeTag;
            SendReceive(holdVal);
        }
        private void SendReceive(string toSend)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(toSend);
            transSendRec._publicClientSocket.Send(buffer);

            /*byte[] receivedBuf = new byte[1024];
            int rec = transSendRec._publicClientSocket.Receive(receivedBuf);
            byte[] data = new byte[rec];
            Array.Copy(receivedBuf, data, rec);*/
        }
    }
}
