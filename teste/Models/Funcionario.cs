using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teste.Models
{
	public class Funcionario
	{
		public Funcionario()
		{
			ID = 0;
			Nome = "";
			Salario = 0;
			DataNascimento = DateTime.Now;
			GeneroID = 0;
		}
		public int ID { get; set; }
		public string Nome { get; set; }
		public DateTime DataNascimento { get; set; }
		public decimal Salario { get; set; }
		public int GeneroID { get; set; }
	}
}
