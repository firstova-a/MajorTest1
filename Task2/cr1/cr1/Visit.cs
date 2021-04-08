using System;
using System.Collections.Generic;
using System.Text;

namespace cr1
{
	class Visit
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public int DentistId { get; set; }
		public Dentist Dentist { get; set; }
		public int ClientId { get; set; }
		public Client Client { get; set; }
		public string Reason { get; set; }
		public decimal Coast { get; set; }
	}
}
