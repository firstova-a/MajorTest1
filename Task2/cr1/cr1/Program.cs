using System;

namespace cr1
{
	class Program
	{
		static void Main(string[] args)
		{
			DentistContext context = new DentistContext();
			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

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
			context.Dispose();
		}
	}
}
