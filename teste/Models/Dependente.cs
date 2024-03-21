using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teste.Models
{
	public class Dependente
	{
		public Dependente()
		{
			ID = 0;
			Nome = "";
			FuncionarioId = 0;
			DataNascimento = DateTime.Now;
			GeneroID = 0;
		}
		public int ID { get; set; }
		public string Nome { get; set; }
		public int FuncionarioId { get; set; }
		public DateTime DataNascimento { get; set; }
		public int GeneroID { get; set; }
	}
}
