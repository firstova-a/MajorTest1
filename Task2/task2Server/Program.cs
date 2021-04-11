using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace task2Server
{
	class Program
	{
		static UdpClient client;
		const int port = 2365;
		static bool isRunning;

		static async Task Work()
		{
			while (isRunning)
			{
				UdpReceiveResult datagram = await client.ReceiveAsync();
				string text = Encoding.UTF8.GetString(datagram.Buffer);
				Console.WriteLine($"got \"{text}\" from client");
				/*string answer = text + " " + DateTime.Now.ToString();
				byte[] answerDatagram = Encoding.UTF8.GetBytes(answer);
				await client.SendAsync(answerDatagram, answerDatagram.Length, datagram.RemoteEndPoint);*/
			}
		}

		static async Task Main(string[] args)
		{
			client = new UdpClient(port);
			Console.WriteLine("Server start");
			isRunning = true;
			Task runTask = Work();
			Console.ReadLine();
			isRunning = false;
			await runTask;
		}
	}
}
