using System;
using System.Collections.Generic;
using System.Text;

namespace cr1
{
	class Client
	{
		public int Id { get; set; }
		public string FIO { get; set; }
		public string Phone { get; set; }

		public List<Dentist> Dentists { get; set; } = new List<Dentist>();
		public List<Visit> Visits { get; set; } = new List<Visit>();
	}
}
