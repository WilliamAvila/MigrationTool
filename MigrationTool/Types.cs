using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool
{
    class Types
    {
        public static  Dictionary<string, string> dbtypes = new Dictionary<string, string>
        {
            {"BFILE", "VARCHAR(255)" },
            {"BINARY_FLOAT", "REAL" },
            {"BINARY_DOUBLE", "DOUBLE PRECISION"},
            {"BLOB","BYTEA"},
            {"CHAR","CHAR"},
            {"CHARACTER","CHARACTER VARYING"},
            {"CLOB","	TEXT"},
            {"DATE","TIMESTAMP(0)"},
            {"DECIMAL","DECIMAL"},
            {"DEC","DEC"},
            {"DOUBLE PRECISION","DOUBLE PRECISION"},
            {"FLOAT","DOUBLE PRECISION"},
            {"INTEGER","INTEGER"},
            {"INT","DECIMAL(38)"},
            {"INTERVAL YEAR(p) TO MONTH","INTERVAL YEAR TO MONTH"},
            {"INTERVAL DAY(p) TO SECOND(s","INTERVAL DAY TO SECOND(s)"},
            {"LONG","TEXT"},
            {"LONG RAW","BYTEA"},
            {"NCHAR","CHAR"},
            {"NCHAR VARYING","VARCHAR"},
            {"NCLOB","TEXT"},
            {"NUMBER","INT"},
            {"NUMERIC","NUMERIC"},
            {"NVARCHAR2","VARCHAR"},
            {"RAW","BYTEA"},
            {"REAL","DOUBLE PRECISION"},
            {"ROWID","CHAR(10)"},
            {"SMALLINT","DECIMAL(38)"},
            {"TIMESTAMP","TIMESTAMP"},
            {"TIMESTAMP(p) WITH TIME ZONE","TIMESTAMP(p) WITH TIME ZONE"},
            {"UROWID","VARCHAR"},
            {"VARCHAR","VARCHAR"},
            {"VARCHAR2","VARCHAR"},
            {"XMLTYPE","XML"}
        };
    }
  
}
