using System;
using System.Collections.Generic;
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
		static DentistContext context = new DentistContext();

		static async Task Work()
		{
			while (isRunning)
			{
				UdpReceiveResult datagram = await client.ReceiveAsync();
				string text = Encoding.UTF8.GetString(datagram.Buffer);
				Console.WriteLine($"got \"{text}\" from client");
				string[] commandList = text.Split("_");
				string answer = await decryptCommand(commandList);
				/*string answer = text + " " + DateTime.Now.ToString();
				byte[] answerDatagram = Encoding.UTF8.GetBytes(answer);
				await client.SendAsync(answerDatagram, answerDatagram.Length, datagram.RemoteEndPoint);*/
			}
			context.Dispose();
		}	


		static async Task Main(string[] args)
		{
			client = new UdpClient(port);
			Console.WriteLine("Server start");
			try
			{				
				context.Database.EnsureDeleted();
				context.Database.EnsureCreated();
				SetDB();
				Console.WriteLine("DB connected");
			}
			catch
			{
				Console.WriteLine("Problem with connect DB");
			}
			isRunning = true;
			Task runTask = Work();
			Console.ReadLine();
			isRunning = false;
			await runTask;
		}

		public static void SetDB()
		{
			Dentist dentist1 = new Dentist
			{
				FIO = "Иванов Рудольф Исаакович",
				LicenseDate = 1999,
				Phone = "999 - 999 - 99 - 99",
				LicenseNumber = "ABC123",
				WorkingHourFrom = DateTime.Parse("8:00"),
				WorkingHourTo = DateTime.Parse("17:00")
			};

			Dentist dentist2 = new Dentist
			{
				FIO = "Петров Александр Иванович",
				LicenseDate = 2010,
				Phone = "999 - 777 - 32 - 28",
				LicenseNumber = "DBS751",
				WorkingHourFrom = DateTime.Parse("10:00"),
				WorkingHourTo = DateTime.Parse("19:00")
			};

			Client client1 = new Client
			{
				FIO = "Гринев Олег Вячеславович",
				Phone = "4839480299"
			};

			Client client2 = new Client
			{
				FIO = "Крайний Семен Геннадьевич",
				Phone = "1213545667"
			};

			Client client3 = new Client
			{
				FIO = "Незлобин Виктор Вильгельмович",
				Phone = "4434354579"
			};

			Visit visit1 = new Visit
			{
				Reason = "Удаление нижних левых 6,7 зубов",
				Coast = 14500,
				Date = DateTime.Parse("Apr 02 2021")
			};
			visit1.Dentist = dentist1;
			visit1.Client = client1;
			client1.Dentists.Add(dentist1);
			dentist1.Clients.Add(client1);

			Visit visit2 = new Visit
			{
				Reason = "Установка коронок",
				Coast = 20000,
				Date = DateTime.Parse("Apr 10 2021")
			};
			visit2.Dentist = dentist1;
			visit2.Client = client2;
			client2.Dentists.Add(dentist1);
			dentist1.Clients.Add(client2);

			Visit visit3 = new Visit
			{
				Reason = "Чистка кармы",
				Coast = 1500,
				Date = DateTime.Parse("Apr 19 2021")
			};
			visit3.Dentist = dentist2;
			visit3.Client = client3;
			client3.Dentists.Add(dentist2);
			dentist2.Clients.Add(client3);

			Visit visit4 = new Visit
			{
				Reason = "Пломбирование",
				Coast = 3500,
				Date = DateTime.Parse("Mar 04 2021")
			};
			visit4.Dentist = dentist2;
			visit4.Client = client3;
			client3.Dentists.Add(dentist2);
			dentist2.Clients.Add(client3);

			Visit visit5 = new Visit
			{
				Reason = "Пытка",
				Coast = 50000,
				Date = DateTime.Parse("Feb 16 2021")
			};
			visit5.Dentist = dentist2;
			visit5.Client = client1;
			client1.Dentists.Add(dentist2);
			dentist2.Clients.Add(client1);

			Visit visit6 = new Visit
			{
				Reason = "Очень важная причина",
				Coast = 10000,
				Date = DateTime.Parse("May 02 2021")
			};
			visit6.Dentist = dentist2;
			visit6.Client = client2;
			client2.Dentists.Add(dentist2);
			dentist2.Clients.Add(client2);

			context.Add(dentist1);
			context.Add(dentist2);

			context.Add(client1);
			context.Add(client2);
			context.Add(client3);
			context.SaveChanges();


			context.Add(visit1);
			context.Add(visit2);
			context.Add(visit3);
			context.Add(visit4);
			context.Add(visit5);
			context.Add(visit6);

			context.SaveChanges();
		}

		public static async Task<string> decryptCommand(string[] commandArray)
		{
			string answer = "";
			if(commandArray[0]=="1")
			{
				/*добавление дантиста*/
				try
				{
					Dentist newDentist = new Dentist
					{
						FIO = commandArray[1],
						Phone = commandArray[2],
						LicenseNumber = commandArray[3],
						LicenseDate = int.Parse(commandArray[4]),
						WorkingHourFrom = DateTime.Parse(commandArray[5]),
						WorkingHourTo = DateTime.Parse(commandArray[6])
					};
					context.Add(newDentist);
					context.SaveChanges();
					answer = "Done";
				}
				catch
				{
					answer = "Error";
				}
			}
			else if (commandArray[0] == "2")
			{
				/*удаление дантиста*/
			}
			else if (commandArray[0] == "3")
			{
				/*добавление клиента*/
				try
				{
					Client newClient = new Client
					{
						FIO = commandArray[1],
						Phone = commandArray[2]
					};
					context.Add(newClient);
					context.SaveChanges();
					answer = "Done";
				}
				catch
				{
					answer = "Error";
				}
			}
			else if (commandArray[0] == "4")
			{
				/*удаление клиента*/
				Client removeClient = new Client
				{
					FIO = commandArray[1],
					Phone = commandArray[2]
				};

				context.Clients.Attach(removeClient);
				context.Clients.Remove(removeClient);
				context.SaveChanges();
			}
			else if (commandArray[0] == "5")
			{
				/*найти дантиста по ФИО*/
			}
			else if (commandArray[0] == "6")
			{
				/*найти дантиста по лицензии*/
			}
			else if (commandArray[0] == "7")
			{
				/*найти дантиста по ФИО клиента*/
			}
			else if (commandArray[0] == "8")
			{
				/*найти дантиста по времени работы*/
			}


			return answer;
		}
}
}
