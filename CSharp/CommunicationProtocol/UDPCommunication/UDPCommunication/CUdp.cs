using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace UDPCommunication
{
    public class CUdp
    {
        public static string CommunicateViaUDP(string InputIpAddress, int InputPort, string message)
        {
            //Port and IP Data for Socket Client
            string IP = InputIpAddress;
            int port = InputPort;

            string inputVal = message;
            var udpClient = new UdpClient();
            var clientReturn = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            try
            {
                //int inputInt;
                //int.TryParse(inputVal, out inputInt);

                udpClient.Connect(IPAddress.Parse(IP), port);
                //Sends a message to the host to which you have connected.
                Byte[] sendBytes = Encoding.ASCII.GetBytes(inputVal);

                udpClient.Send(sendBytes, sendBytes.Length);
                return "";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
