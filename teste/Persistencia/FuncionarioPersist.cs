using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using teste.Models;

namespace teste.Persistencia
{
	public class FuncionarioPersist
	{
		private Conexao _con;
		public FuncionarioPersist()
		{
			_con = new Conexao();
		}

		public bool Add(Funcionario funcionario)
		{
			string sql = "INSERT INTO FuncionarioTB (Nome, DataNascimento, Salario, GeneroID) Values ";
			sql += $"('{funcionario.Nome}','{funcionario.DataNascimento.ToString("yyyy-MM-dd")}',{funcionario.Salario.ToString().Replace(",",".")},{funcionario.GeneroID})";
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = sql;
			cmd.Connection = _con.Conectar();
			cmd.ExecuteNonQuery();
			return true;
		}
		public bool Update(Funcionario funcionario)
		{
			string sql = "UPDATE FuncionarioTB SET ";
			sql += $"Nome = '{funcionario.Nome}'";
			sql += $",DataNascimento = '{funcionario.DataNascimento.ToString("yyyy-MM-dd")}'";
			sql += $",Salario = {funcionario.Salario.ToString().Replace(",", ".")}";
			sql += $",GeneroID = {funcionario.GeneroID}";
			sql += $" where ID = '{funcionario.ID}'";
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = sql;
			cmd.Connection = _con.Conectar();
			cmd.ExecuteNonQuery();
			return true;
		}
		public Funcionario GetId(int ID)
		{
			var funcionario = new Funcionario();
			var dt = _con.ExecutarDtQuery($"select ID,Nome, DataNascimento, Salario, GeneroID from FuncionarioTB where ID = {ID}");

			if(dt.Rows.Count > 0)
			{
				//funcionario.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
				//funcionario.Nome = Convert.ToString(dt.Rows[0]["Nome"]);
				//funcionario.DataNascimento = DateTime.Parse(dt.Rows[0]["DataNascimento"].ToString());
				//funcionario.Salario = Convert.ToDecimal(dt.Rows[0]["Salario"]);
				//funcionario.GeneroID = Convert.ToInt32(dt.Rows[0]["GeneroID"]);
				funcionario = addFuncionario(dt.Rows[0]);
			}

			return funcionario;
		}
		public List<Funcionario> Lista(DateTime datade, DateTime dataate,int genero)
		{
			var lista = new List<Funcionario>();
			var dt = _con.ExecutarDtQuery($"select ID,Nome, DataNascimento, Salario, GeneroID from FuncionarioTB where DataNascimento between '{datade.ToString("yyyy-MM-dd")}' AND '{dataate.ToString("yyyy-MM-dd")}' and GeneroID = '{genero}'");
			if(dt.Rows.Count > 0)
			{
				for(int i = 0; i < dt.Rows.Count; i++)
				{
					lista.Add(addFuncionario(dt.Rows[i]));
				}
				
			}

			return lista;
		}
		public List<Funcionario> Lista()
		{
			var lista = new List<Funcionario>();
			var dt = _con.ExecutarDtQuery($"select ID,Nome, DataNascimento, Salario, GeneroID from FuncionarioTB Order by Nome");
			if (dt.Rows.Count > 0)
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					lista.Add(addFuncionario(dt.Rows[i]));
				}

			}

			return lista;
		}
		public bool Excluir(int ID)
		{
			string sql = $"DELETE FROM FuncionarioTB where ID = {ID}";
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = sql;
			cmd.Connection = _con.Conectar();
			cmd.ExecuteNonQuery();
			return true;
		}
		private Funcionario addFuncionario(DataRow dt)
		{
			var funcionario = new Funcionario();
			funcionario.ID = Convert.ToInt32(dt["ID"]);
			funcionario.Nome = Convert.ToString(dt["Nome"]);
			funcionario.DataNascimento = DateTime.Parse(dt["DataNascimento"].ToString());
			funcionario.Salario = Convert.ToDecimal(dt["Salario"]);
			funcionario.GeneroID = Convert.ToInt32(dt["GeneroID"]);
			return funcionario;
		}
	}
}
