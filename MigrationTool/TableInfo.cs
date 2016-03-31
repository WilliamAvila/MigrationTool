using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool
{
    class TableInfo
    {
        public string name;

        public string tableType;
    
        public List<ColumnInfo> columns;

        public List<String> rows; 

        public TableInfo(string s)
        {
            name = s;
            rows = new List<String>();
            columns = new List<ColumnInfo>();
        }

        public string GetInsertAllDataPostgresQuery()
        {
            if (!rows.Any())
                return " ";
            string cols = " ";
            foreach (var column in columns)
            {
                cols += column.name + ",";
               
            }

            cols = cols.Remove(cols.Length - 1);

            string insertQuery = "INSERT INTO " + name +"(" + cols + ") VALUES ";

            List<String> data = new List<String>();
            foreach (var row in rows)
            {
                string item ="(" + String.Join(",", row) + ")";
                data.Add(item);
            }

            insertQuery += String.Join(",",data);
            return insertQuery;
        }

        public string GetInsertAllDataToOracleQuery()
        {
            if (!rows.Any())
                return " ";
            string cols = " ";
            foreach (var column in columns)
            {
                cols += column.name + ",";

            }

            cols = cols.Remove(cols.Length - 1);
            string oracleQuery = "insert  all ";
            foreach (var row in rows)
            {
                oracleQuery += "into " + name + " (" + cols + ") values (" +
                                   row + ") ";

            }
            oracleQuery += "SELECT * FROM dual";

            return oracleQuery;
        }

        public string GetCreateTableQuery()
        {
            string columnData = " ";

            foreach (var column in columns)
            {
                if(column.type.Contains("CHAR") && !column.GetCharPrecision().Equals("1"))
                     columnData += column.name + " " + column.type +"("+ column.GetCharPrecision() + "),";
                else
                    columnData += column.name + " " + column.type + ",";
                
            }
            columnData = columnData.Remove(columnData.Length -1);

            string createTable = "CREATE TABLE " + name + "(" + columnData +")";

            return createTable;
        }


        public string GetCreateTableQueryOracleType()
        {
            string columnData = " ";

            foreach (var column in columns)
            {
                if (column.type.Contains("CHAR") && !column.GetCharPrecision().Equals("1"))
                    columnData +=  column.name  + " " + column.GetOracleType() + "(" + column.GetCharPrecision() + "),";
                else
                    columnData +=  column.name + " " + column.GetOracleType() + ",";

            }
            columnData = columnData.Remove(columnData.Length - 1);

            string createTable = "CREATE TABLE " + name + "(" + columnData + ")";

            return createTable;
        }

        public string GetCreateTableQueryPostgresType()
        {
            string columnData = " ";

            foreach (var column in columns)
            {
                if (column.type.Contains("CHAR") && !column.GetCharPrecision().Equals("1"))
                    columnData += column.name + " " + Types.dbtypes[column.type] + "(" + column.GetCharPrecision() + "),";
                else
                    columnData += column.name + " " + Types.dbtypes[column.type] + ",";

            }
            columnData = columnData.Remove(columnData.Length - 1);

            string createTable = "CREATE TABLE " + name + "(" + columnData + ")";

            return createTable;
        }

        public string GetInsertAllDataToPostgresQuery()
        {
            if (!rows.Any())
                return " ";
            string cols = " ";
            foreach (var column in columns)
            {
                cols += column.name + ",";
            }

            cols = cols.Remove(cols.Length - 1);

            string insertQuery = "INSERT INTO " + name + "(" + cols + ") VALUES ";

            List<String> data = new List<String>();
            foreach (var row in rows)
            {
                string item = "(" + String.Join(",", row) + ")";
                data.Add(item);
            }

            insertQuery += String.Join(",", data);
            return insertQuery;
        }
    }
}
