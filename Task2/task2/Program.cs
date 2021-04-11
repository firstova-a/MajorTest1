using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
	class Program
	{
		static UdpClient client;
		const int serverPort = 2365;
		static IPAddress serverAddress = IPAddress.Loopback;
		static IPEndPoint serverEP;

		static void Main(string[] args)
		{
			client = new UdpClient();
			serverEP = new IPEndPoint(serverAddress, serverPort);
			bool isRuning = true;
			while (isRuning)
			{
				Console.WriteLine("Главное меню:");
				Console.WriteLine("Список команд:" + Environment.NewLine + "Добавить дантиста - 1" + Environment.NewLine + "Удалить дантиста - 2"
					+ Environment.NewLine + "Добавить клиента - 3" + Environment.NewLine + "Удалить клиента - 4"
					+ Environment.NewLine + "Найти дантиста по ФИО - 5" + Environment.NewLine + "Найти дантиста по лицензии - 6"
					+ Environment.NewLine + "Найти дантиста по ФИО клиента - 7" + Environment.NewLine + "Найти дантиста по времени работа - 8"
					+ Environment.NewLine + "Очистить консоль - 9" + Environment.NewLine + "Закончить программу - 10");
				Console.WriteLine("Введите команду:");
				string command = Console.ReadLine();
				switch (command)
				{
					case "1":
						AddDentist();
						break;
					case "2":
						DeleteDentist();
						break;
					case "3":
						AddClient();
						break;
					case "4":
						DeleteClient();
						break;
					case "5":
						FindDentistFIO();
						break;
					case "6":
						FindDentistLicense();
						break;
					case "7":
						FindDentistClientFIO();
						break;
					case "8":
						FindDentistTime();
						break;
					case "9":
						Console.Clear();
						break;
					case "10":
						isRuning = false;
						break;
					default:
						Console.WriteLine("Неопознаная команда");
						break;
				}
			}
		}

		public static void AddDentist()
		{
			Console.WriteLine("Выбрана команда добавления дантиста, продолжить?");
			Console.Write("(для продолжения введите y (или любой другой символ, исключая n), для прекращения введите n)");
			if (Console.ReadLine() == "n") return;
			string numCommand = "1";
			string FIO = "";
			string Phone = "";
			string LicenseNumber = "";
			int LicenseDate = 0;
			DateTime WorkingHourFrom;
			DateTime WorkingHourTo;
			Console.WriteLine("Введите параметры: ");
			Console.Write("ФИО: ");
			FIO = Console.ReadLine();
			Console.Write("Телефон: ");
			Phone = Console.ReadLine();
			Console.Write("Номер лицензии: ");
			LicenseNumber = Console.ReadLine();
			Console.Write("Год выдачи лицензии (Пример: 1999): ");
			LicenseDate = int.Parse(Console.ReadLine());
			Console.Write("Работает с (Пример: 10:00): ");
			WorkingHourFrom = DateTime.Parse(Console.ReadLine());
			Console.Write("Работает до (Пример: 19:00): ");
			WorkingHourTo = DateTime.Parse(Console.ReadLine());
			string dataString = numCommand+"_"+FIO + "_" + Phone + "_" + LicenseNumber + "_" + LicenseDate + "_" + WorkingHourFrom.ToString() + "_" + WorkingHourTo.ToString();
			SendMessage(dataString);
		}

		public static void DeleteDentist()
		{
			Console.WriteLine("Выбрана команда удаления дантиста, продолжить?");
			Console.WriteLine("Потребуется номер лицензии дантиста, если не знаете/не помните, перед удалением используйте поиск");
			Console.Write("(для продолжения введите y (или любой другой символ, исключая n), для прекращения введите n)");
			if (Console.ReadLine() == "n") return;
			string numCommand = "2";
			string LicenseNumber = "";
			Console.WriteLine("Введите параметры: ");
			Console.Write("Номер лицензии: ");
			LicenseNumber = Console.ReadLine();
			SendMessage(numCommand + "_" + LicenseNumber);
		}

		public static void AddClient()
		{
			Console.WriteLine("Выбрана команда добавления клиента, продолжить?");
			Console.Write("(для продолжения введите y (или любой другой символ, исключая n), для прекращения введите n)");
			if (Console.ReadLine() == "n") return;
			string numCommand = "3";
			string FIO = "";
			string Phone = "";
			Console.WriteLine("Введите параметры: ");
			Console.Write("ФИО: ");
			FIO = Console.ReadLine();
			Console.Write("Телефон: ");
			Phone = Console.ReadLine();
			SendMessage(numCommand + "_" + FIO + "_" + Phone);
		}

		public static void DeleteClient()
		{
			Console.WriteLine("Выбрана команда удаления клиента, продолжить?");
			Console.WriteLine("Потребуется номер телефона и имя, если не знаете/не помните, перед удалением используйте поиск");
			Console.Write("(для продолжения введите y (или любой другой символ, исключая n), для прекращения введите n)");
			if (Console.ReadLine() == "n") return;
			string numCommand = "4";
			string FIO = "";
			string Phone = "";
			Console.WriteLine("Введите параметры: ");
			Console.Write("ФИО: ");
			FIO = Console.ReadLine();
			Console.Write("Телефон: ");
			Phone = Console.ReadLine();
			SendMessage(numCommand + "_" + FIO + "_" + Phone);
		}

		public static void FindDentistFIO()
		{
			Console.WriteLine("Выбрана команда поиска дантиста по ФИО, продолжить?");
			Console.Write("(для продолжения введите y (или любой другой символ, исключая n), для прекращения введите n)");
			if (Console.ReadLine() == "n") return;
			string numCommand = "5";
			string FIO = "";
			Console.WriteLine("Введите параметры: ");
			Console.Write("ФИО: ");
			FIO = Console.ReadLine();
			SendMessage(numCommand + "_" + FIO);
		}

		public static void FindDentistLicense()
		{
			Console.WriteLine("Выбрана команда поиска дантиста по ФИО, продолжить?");
			Console.Write("(для продолжения введите y (или любой другой символ, исключая n), для прекращения введите n)");
			if (Console.ReadLine() == "n") return;
			string numCommand = "6";
			string LicenseNumber = "";
			Console.WriteLine("Введите параметры: ");
			Console.Write("Номер лицензии: ");
			LicenseNumber = Console.ReadLine();
			SendMessage(numCommand + "_" + LicenseNumber);
		}

		public static void FindDentistClientFIO()
		{
			Console.WriteLine("Выбрана команда поиска дантиста по ФИО клиента, продолжить?");
			Console.Write("(для продолжения введите y (или любой другой символ, исключая n), для прекращения введите n)");
			if (Console.ReadLine() == "n") return;
			string numCommand = "7";
			string FIO = "";
			Console.WriteLine("Введите параметры: ");
			Console.Write("ФИО клиента: ");
			FIO = Console.ReadLine();
			SendMessage(numCommand + "_" + FIO);
		}

		public static void FindDentistTime()
		{
			Console.WriteLine("Выбрана команда поиска дантиста по времени работы, продолжить?");
			Console.Write("(для продолжения введите y (или любой другой символ, исключая n), для прекращения введите n)");
			if (Console.ReadLine() == "n") return;
			string numCommand = "8";
			DateTime time;
			Console.WriteLine("Введите параметры: ");
			Console.Write("Интересующие время (в виде ЧЧ:ММ): ");
			time = DateTime.Parse(Console.ReadLine());
			SendMessage(numCommand + "_" + time.ToString());
		}

		public static async Task<string> SendMessage(string Message)
		{
			byte[] datagram = Encoding.UTF8.GetBytes(Message);
			client.SendAsync(datagram, datagram.Length, serverEP);
			UdpReceiveResult answerDatagram = await client.ReceiveAsync();
			string text = Encoding.UTF8.GetString(answerDatagram.Buffer);
			return text;
		}


		/*
		 * подключение к серверу
		 * 
		 * в сообщении номер команды, переданные аргументы
		 * 
		 * чтение ответа от сервера
		 * 
		 * 
		 */
	}
}
