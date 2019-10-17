using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace BrokenDigSky.AmdOnlyRts.Networking
{
	public class NetClient
	{

		public string Name { get; set; }
		public int UID { get; set; }
		public int Port { get; set; }
		
		public string ServerAddress = "255.255.255.255";

		UdpClient receivingClient;
		UdpClient sendingClient;

		Thread receivingThread;

		public delegate void ReceiveMessage(string message);
		public ReceiveMessage OnMessageReceive;

		public NetClient(string name, int port)
		{
			//Generate UID
			Random rnd = new Random();

			Name = name;
			Port = port;

			sendingClient = new UdpClient(ServerAddress, Port);
			receivingClient = new UdpClient(port);

			sendingClient.EnableBroadcast = true;
			OnMessageReceive += MessageReceived;

			ThreadStart start = new ThreadStart(Receiver);
			receivingThread = new Thread(start);
			receivingThread.IsBackground = true;
			receivingThread.Start();
		}

		private void Receiver()
		{
			IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, Port);
			
			
			while (true)
			{
				byte[] data = receivingClient.Receive(ref endPoint);
				string message = endPoint.Address.ToString() + ":" + Encoding.ASCII.GetString(data);
				OnMessageReceive(message);
			}
		}

		public void SendMessage(string message)
		{
			
			if(!string.IsNullOrEmpty(message))
			{
				string msg = message;
				byte[] data = Encoding.ASCII.GetBytes(msg);
				sendingClient.Send(data, data.Length);
			}
		}

		private void MessageReceived(string message) {
			
		}
	}
}
