using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Npgsql;

namespace MigrationTool
{
    internal class OracleTest
    {
        public OracleConnection con;
        public string owner;
        private List<TableInfo> tables;
        private string connectionString;

        public bool Connect(string host, string port, string user, string password)
        {
            try
            {
                owner = user;
                con = new OracleConnection();
                connectionString = "Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST =" + host + ")(PORT =" +
                                       port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = XE)))" +
                                       ";User Id=" + user + ";Password=" + password + ";";
                con.ConnectionString = connectionString;
                con.Open();
            }
            catch (Exception e)
            {
                throw e;
            }
       

            return true;
        }

        public void executeQuery(string query)
        {
       
                OracleCommand command = new OracleCommand(query, con);
                command.ExecuteNonQuery();
          
        }

        public void executeQueries(List<string> queries)
        {
            
            foreach (var query in queries)
            {
                if(query.Equals(" "))
                    continue;
                OracleCommand command = new OracleCommand(query, con);
                command.ExecuteNonQuery();
            }
        }

        public void Close()
        {
            con.Close();
            con.Dispose();
        }

        public void migrateData(string owner, List<string> tables, List<string> columnInfo, List<string> columnNames, List<List<string>> columnValuesList)
        {

            for (int i = 0; i < tables.Count; i++)
            {
                createTable(owner,tables[i], columnInfo[i]);

                for (int j = 0; j <tables.Count; j++)
                {

                    fillTable(owner, tables[i], columnNames[i], columnValuesList[i]);
                }
            }
         
        }


        public void getSysTables()
        {
            tables = new List<TableInfo>();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from all_tables where owner = '" + owner.ToUpper() + "'";
            cmd.CommandType = CommandType.Text;


            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tables.Add(new TableInfo(dr.GetString(1)));
            }

        }
        public void fillTables()
        {
       
            foreach (var table in tables)
            {

                string columns = "select * from ALL_TAB_COLUMNS where owner = '" + owner.ToUpper() +
                                 "' and TABLE_NAME = '" + table.name + "'";
                OracleCommand command = new OracleCommand(columns, con);
               
                OracleDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    var type = dr[3].ToString();
                    if (type.Contains("char") || type.Contains("CHAR"))
                        table.columns.Add(new ColumnInfo(dr[2].ToString(), dr[3].ToString().ToUpper(), dr[6].ToString()));
                    else
                        table.columns.Add(new ColumnInfo(dr[2].ToString(), dr[3].ToString().ToUpper(), ""));

                }
                dr.Close();

            }

        }
        public void getDataTables()
        {
          
            foreach (var table in tables)
            {

                string columns = "SELECT * FROM " + "\"" + table.name + "\"";
                OracleCommand command = new OracleCommand(columns, con);

                OracleDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    string row = "";


                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        var value = dr.GetValue(i);
                        var type = value.GetType();
                        if (type.Name.Equals("DBNull"))
                            row += "NULL";
                        else if (type.Name.Equals("String") || type.Name.Equals("DateTime"))
                            row += "'" + value + "'";
                        else
                            row += value;

                        row += ",";

                    }
                    row = row.Remove(row.Length - 1);
                    table.rows.Add(row);
                }

                dr.Close();


            }
        }
        public void getSystables()
        {
            string sysTables = "select * from all_tables where owner = '" + owner.ToUpper() + "'";

            OracleCommand command = new OracleCommand(sysTables, con);

            OracleDataReader dr = command.ExecuteReader();
            tables = new List<TableInfo>();

            while (dr.Read())
            {
                tables.Add(new TableInfo(dr[0].ToString()));
            }
            con.Close();
        }

        public void createTable(string schema, string tableName, string columnInfo)
        {

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "create table "  + schema + "." + tableName +" (" + columnInfo + ")";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

        }


        public string getColumnInfo(string owner, string tableName)
        {
            string columnInfo = "";
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from ALL_TAB_COLUMNS where owner = '" + owner.ToUpper() + "' and TABLE_NAME = '" + tableName + "'";
            cmd.CommandType = CommandType.Text;


            OracleDataReader dr = cmd.ExecuteReader();
            List<string> columnName = new List<string>();

            List<string> columnDataType = new List<string>();

            List<int> columnDataLength = new List<int>();

            while (dr.Read())
            {
                columnName.Add(dr.GetString(2));
                columnDataType.Add(dr.GetString(3));
                columnDataLength.Add(dr.GetInt32(6));
            }

            for (int i = 0; i < columnName.Count; i++)
            {
                if (columnDataType[i].Equals("DATE"))
                    columnInfo += columnName[i] + " " + columnDataType[i] + ",";
                else
                    columnInfo += columnName[i] + " " + columnDataType[i] + "(" + columnDataLength[i] + "),";
            }

            columnInfo = columnInfo.Remove(columnInfo.Length - 1);

            return columnInfo;
        }

        public List<string> getColumnInfoList(List<string> tables )
        {
            List<string> columnData = new List<string>();
            for (int i = 0; i < tables.Count; i++)
            {
                columnData.Add(getColumnInfo(owner, tables[i]));
            }

            return columnData;
        }

        public void fillTable(string owner, string tableName, string columnNames, List<string> columnValuesList)
        {

            if (columnValuesList.Count > 0)
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert  all ";
                for (int i = 0; i < columnValuesList.Count; i++)
                {
                    cmd.CommandText += "into " + owner + "." + tableName + " (" + columnNames + ") values (" +
                                       columnValuesList[i] + ") ";

                }
                cmd.CommandText += "SELECT * FROM dual";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }


        }


        public string getColumnNames(string owner, string tableName)
        {
            
            OracleCommand cmd = new OracleCommand();
        
            cmd.Connection = con;
            cmd.CommandText = "select * from ALL_TAB_COLUMNS where owner = '" + owner.ToUpper() + "' and TABLE_NAME = '" + tableName + "'";
            cmd.CommandType = CommandType.Text;


            OracleDataReader dr = cmd.ExecuteReader();
            List<string> columnName = new List<string>();


            while (dr.Read())
            {
                columnName.Add(dr.GetString(2));
            }


            return string.Join(",", columnName);
        }

        public List<string> getColumnNamesList(string owner, List<string> tables )
        {


            List<string> columnNameList = new List<string>();

            for (int i = 0; i < tables.Count; i++)
            {
                columnNameList.Add(getColumnNames(owner,tables[i]));
            }




            return columnNameList;
        }

        public List<string> getColumnValuesList(string tableName)
        {

            OracleCommand cmd = new OracleCommand();

            cmd.Connection = con;
            cmd.CommandText = "select * from " + tableName;
            cmd.CommandType = CommandType.Text;


            OracleDataReader dr = cmd.ExecuteReader();
            List<string> columnValues = new List<string>();
            string row = "";
           
            while (dr.Read())
            {
                row = "";
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    var value = dr.GetValue(i);
                    var type = value.GetType();
                    if (type.Name.Equals("String"))
                        row += "'" + value + "',";
                    else if (type.Name.Equals("DateTime"))
                    {
                        var meridian = ((DateTime)value).ToString("tt", CultureInfo.InvariantCulture);
                        row += "TO_DATE('" + value + "', 'mm/dd/yyyy hh:mi:ss " + meridian + "'),";
                    }
                    else if (type.Name.Equals("DBNull"))
                    {
                        row += "NULL,";
                    }
                    else{
                        row += value + ",";
                    }

                }
                row = row.Remove(row.Length - 1);

                columnValues.Add(row);
            }

            return columnValues;
        }

        public List<List<string>> getAllColumnValues(List<string> tables)
        {
            List<List<string>> allvalues = new List<List<string>>();

            for (int i = 0; i < tables.Count; i++)
            {
                allvalues.Add(getColumnValuesList(tables[i]));
            }

            return allvalues;
        } 

       public void createUser(String user,String password)
       {
           
            OracleCommand myCommand = con.CreateCommand();
            OracleTransaction myTrans;

            // Start a local transaction
            myTrans = con.BeginTransaction(IsolationLevel.ReadCommitted);
            // Assign transaction object for a pending local transaction
            myCommand.Transaction = myTrans;

            try
            {
                myCommand.CommandText = "CREATE USER "+user+" IDENTIFIED BY "+password+"";;
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "GRANT CONNECT,RESOURCE,DBA TO "+user+"";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "GRANT UNLIMITED TABLESPACE TO "+user+"";
                myCommand.ExecuteNonQuery();


                myTrans.Commit();
            }
            catch(Exception e)
            {
                myTrans.Rollback();
                MessageBox.Show(e.ToString());
                MessageBox.Show("Neither record was written to database.");
            }
            finally
            {
                con.Close();
            }
               
       }

        public string GetCreateTableQueries()
        {
            List<string> insertQueries = new List<string>();
            foreach (var table in tables)
            {
                insertQueries.Add(table.GetCreateTableQueryPostgresType());
            }
            return String.Join(";", insertQueries);
        }

        public List<string> GetInsertDataQueries()
        {
            List<string> insertQueries = new List<string>();
            foreach (var table in tables)
            {
                insertQueries.Add(table.GetInsertAllDataToPostgresQuery());
            }
            return insertQueries;
            
        }
    }
}