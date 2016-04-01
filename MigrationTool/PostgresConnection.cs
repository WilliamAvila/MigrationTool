using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace MigrationTool
{
    class PostgresConnection
    {
        private List<TableInfo> tables;
        private NpgsqlConnection conn;
        private string connstring;
        public void Connect(string host, string port, string user, string password, string database)
        {
            
            try{
				// PostgeSQL-style connection string
				 connstring = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
					host, port, user, password, database );

                getSystables();
            }
			catch (Exception msg)
			{
				// something went wrong, and you wanna know why
				MessageBox.Show(msg.ToString());
				throw;
			}
        }

        public void getSystables()
        {

            conn = new NpgsqlConnection(connstring);
            conn.Open();
            string sysTables = "SELECT table_name FROM information_schema.tables WHERE table_schema='public'";

            NpgsqlCommand command = new NpgsqlCommand(sysTables, conn);

            NpgsqlDataReader dr = command.ExecuteReader();
            tables = new List<TableInfo>();
            
            while (dr.Read())
            {
                tables.Add(new TableInfo(dr[0].ToString()));
            }
            conn.Close();
        }

        public void fillTables()
        {
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();

            foreach (var table in tables)
            {

                string columns = "SELECT * FROM information_schema.columns where table_name = '" + table.name + "'";
                NpgsqlCommand command = new NpgsqlCommand(columns, conn);

                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    var type = dr[7].ToString();
                    if(type.Contains("char"))
                        table.columns.Add(new ColumnInfo(dr[3].ToString(), dr[7].ToString().ToUpper(), dr[8].ToString()));
                    else
                        table.columns.Add(new ColumnInfo(dr[3].ToString(), dr[7].ToString().ToUpper(), ""));
                    
                }
                dr.Close();

            }
            conn.Close();
          
        }

        public void getDataTables()
        {
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();

            foreach (var table in tables)
            {

                string columns = "SELECT * FROM " + "\"" + table.name + "\"";
                NpgsqlCommand command = new NpgsqlCommand(columns, conn);

                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    string row = "";
                   
                  
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        var value = dr.GetValue(i);
                        var type = value.GetType();
                        if (type.Name.Equals("DBNull"))
                            row += "NULL";
                        else if (type.Name.Equals("String") )
                            row += "'" + value + "'";
                        else if (type.Name.Equals("DateTime"))
                        {
                            var meridian = ((DateTime)value).ToString("tt", CultureInfo.InvariantCulture);
                            row += "TO_DATE('" + value + "', 'mm/dd/yyyy hh:mi:ss " + meridian + "')";
                        }
                        else
                            row += value;

                        row += ",";
                    
                    }
                    row = row.Remove(row.Length - 1);
                    table.rows.Add(row);
               }
                
                dr.Close();


            }
            conn.Close();
        }


        public void ExecuteQuery(string query)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }

        public string GetCreateTableQueries()
        {
            List<string> tableQueries = new List<string>();
            foreach (var table in tables)
            {
                tableQueries.Add(table.GetCreateTableQuery());
            }
            return String.Join(";",tableQueries);
        }

        public List<string> GetCreateTableOracleQueries()
        {
            List<string> tableQueries = new List<string>();
            foreach (var table in tables)
            {
                tableQueries.Add(table.GetCreateTableQueryOracleType());
            }
            return tableQueries;
        }

        public string GetInsertDataQueries()
        {
            List<string> insertQueries = new List<string>();
            foreach (var table in tables)
            {
                insertQueries.Add(table.GetInsertAllDataPostgresQuery());
            }
            return  String.Join(";", insertQueries) ;
        }

        public List<string> GetInsertOracleDataQueries()
        {
            List<string> insertQueries = new List<string>();
            foreach (var table in tables)
            {
                insertQueries.Add(table.GetInsertAllDataToOracleQuery());
            }
            return insertQueries;
        }

        public void ExecuteQueries(List<string> queries)
        { 
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            foreach (var query in queries)
            {
                if (query.Equals(" "))
                    continue;
                NpgsqlCommand command = new NpgsqlCommand(query, conn);
                command.ExecuteNonQuery();
            }

            conn.Close();
        }
    }
}
