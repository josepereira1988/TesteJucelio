using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace teste.Persistencia
{
	public class Conexao
	{
		string constring = "Server=localhost;Database=TesteProgramacao;User Id=sa;Password=paralela09;";
        public SqlConnection Conn = new SqlConnection();
        public Conexao()
        {            
            Conn.ConnectionString = constring;
        }
        public SqlConnection Conectar()
        {
            try
            {
                if (Conn.State == System.Data.ConnectionState.Closed)
                {
                    Conn.Open();
                }
                return Conn;
            }
            catch (System.Exception ex)
            {
                //
                return Conn;
            }

        }
        public void Desconectar()
        {

            try
            {
                Conn.Close();

            }
            catch (System.Exception ex)
            {

            }
        }

        public DataTable ExecutarDtQuery(string sql)
		{
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            cmd.Connection = Conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);
            return dt;
        }

    }
}
