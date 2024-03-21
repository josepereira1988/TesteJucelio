using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using teste.Models;

namespace teste.Persistencia
{
	public class DependentePersist
	{
		private Conexao _con;
		public DependentePersist()
		{
			_con = new Conexao();
		}
		public bool Add(Dependente dependente)
		{
			string sql = "INSERT INTO DependentesTB (FuncionarioId, Nome, DataNascimento, GeneroID) Values ";
			sql += $" ('{dependente.FuncionarioId}','{dependente.Nome}','{dependente.DataNascimento.ToString("yyyy-MM-dd")}',{dependente.GeneroID})";
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = sql;
			cmd.Connection = _con.Conectar();
			cmd.ExecuteNonQuery();
			return true;
		}
		public bool Update(Dependente dependente)
		{
			string sql = "UPDATE FuncionarioTB SET ";
			sql += $" FuncionarioId = '{dependente.FuncionarioId}'";
			sql += $",Nome = '{dependente.Nome}'";
			sql += $",DataNascimento = {dependente.DataNascimento.ToString("yyyy-MM-dd")}";
			sql += $",GeneroID = {dependente.GeneroID}";
			sql += $" where ID = {dependente.ID}";
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = sql;
			cmd.Connection = _con.Conectar();
			cmd.ExecuteNonQuery();
			return true;
		}
		public Dependente GetId(int ID)
		{
			var dependente = new Dependente();
			var dt = _con.ExecutarDtQuery($"select ID,Nome, DataNascimento, FuncionarioId, GeneroID from DependentesTB where ID = {ID}");

			if (dt.Rows.Count > 0)
			{
				dependente = addDependente(dt.Rows[0]);
			}

			return dependente;
		}
		public List<Dependente> Lista(int ID)
		{
			var lista = new List<Dependente>();
			var dt = _con.ExecutarDtQuery($"select ID,Nome, DataNascimento, FuncionarioId, GeneroID from DependentesTB where FuncionarioId = {ID}");
			if (dt.Rows.Count > 0)
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					lista.Add(addDependente(dt.Rows[i]));
				}

			}

			return lista;
		}

		public bool Excluir(int ID)
		{
			if(GetId(ID).ID == 0)
			{
				return false;
			}
			string sql = $"DELETE FROM DependentesTB WHERE ID = {ID}";
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = sql;
			cmd.Connection = _con.Conectar();
			cmd.ExecuteNonQuery();
			return true;
		}
		private Dependente addDependente(DataRow dt)
		{
			var dependente = new Dependente();
			dependente.ID = Convert.ToInt32(dt["ID"]);
			dependente.Nome = Convert.ToString(dt["Nome"]);
			dependente.DataNascimento = DateTime.Parse(dt["DataNascimento"].ToString());
			dependente.FuncionarioId = Convert.ToInt32(dt["FuncionarioId"]);
			dependente.GeneroID = Convert.ToInt32(dt["GeneroID"]);
			return dependente;
		}
	}
}
