using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace MigrationTool
{
    class PostgresTest
    {

        public void connect(string host, string port, string user, string password, string database)
        {
            
            try{
				// PostgeSQL-style connection string
				string connstring = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
					host, port, user, password, database );
				// Making connection with Npgsql provider
				NpgsqlConnection conn = new NpgsqlConnection(connstring);
				conn.Open();
				// quite complex sql statement
				string sql = "SELECT * FROM simple_table";
                string sysTables = "SELECT table_name FROM information_schema.tables WHERE table_schema='public'";
				// data adapter making request from our connection
				NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
	
				// since we only showing the result we don't need connection anymore
				conn.Close();
			}
			catch (Exception msg)
			{
				// something went wrong, and you wanna know why
				MessageBox.Show(msg.ToString());
				throw;
			}
        }
    }
}
