using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teste.Models
{
	public class FuncionarioViewModel
	{
		public FuncionarioViewModel()
		{
			funcionario = new Funcionario();
			dependente = new List<Dependente>();
		}
		public Funcionario funcionario { get; set; }
		public List<Dependente> dependente { get; set; }
	}
}
