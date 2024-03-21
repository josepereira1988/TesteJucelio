using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using teste.Models;

namespace teste.Persistencia
{
	public class GeneroPersist
	{
		private readonly Conexao _con;
		public GeneroPersist()
		{
			_con = new Conexao();
		}
		public List<Genero> Lista()
		{
			var lista = new List<Genero>();
			string sql = "select ID,NomeGenero from GeneroTB";
			var dt = _con.ExecutarDtQuery(sql);
			if(dt.Rows.Count > 0)
			{
				for(int i = 0;i < dt.Rows.Count; i++)
				{
					var genero = new Genero();
					genero.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
					genero.Nome = Convert.ToString(dt.Rows[i]["NomeGenero"]);
					lista.Add(genero);
				}
			}
			return lista;
		}
	}
}
