using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sport
{
	public class Query
	{
		public string QueryId { get; set; }
		public int ClientId { get; set; }
		public string TrainerName{ get; set; }
		public List<string> TrainerNames { get; set; }

		public string ClientName { get; set; }

		public string ClientSurname { get; set; }
		public List<string> ClientNames { get; set; }
		public List<string> ClientSurnames { get; set; }

		public string GymName { get; set; }
		public List <string> GymNames { get; set; }

		public decimal TrainerSalary { get; set; }
		public List <decimal> TrainerSalaries { get; set; }
		public string PaymentMonth { get; set; }

		public decimal CountClients { get; set; }

		public List<string> ClientEmails { get; set; }

		public string ClientEmail { get; set; }
		public bool HasDebt { get; set; }
		public string Error { get; set; }

		public int ErrorFlag { get; set; }


	}
}