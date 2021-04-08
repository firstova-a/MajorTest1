using System;
using System.Collections.Generic;
using System.Text;

namespace cr1
{
	class Dentist
	{
		public int Id { get; set; }
		public string FIO { get; set; }
		public string Phone { get; set; }
		public string LicenseNumber { get; set; }
		public int LicenseDate { get; set; }
		public DateTime WorkingHourFrom { get; set; }
		public DateTime WorkingHourTo { get; set; }

		public List<Client> Clients { get; set; } = new List<Client>();
		public List<Visit> Visits { get; set; } = new List<Visit>();
	}
}
