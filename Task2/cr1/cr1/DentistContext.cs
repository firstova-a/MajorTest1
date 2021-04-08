using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace cr1
{
	class DentistContext:DbContext
	{
		public DbSet<Dentist> Dentists { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<Visit> Visits { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=DESKTOP-M1QFAN7;Database=ControlWork;Trusted_Connection=True;");
		}
	}
}
