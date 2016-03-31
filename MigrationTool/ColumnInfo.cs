using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool
{
    class ColumnInfo
    {

        public string name;
        public string type;
        public string precision;

        public ColumnInfo(string name, string type, string precision)
        {
            this.type = type;
            this.name = name;
            this.precision = precision;
        }

        public string GetOracleType()
        {
            if (type.Equals("CHARACTER"))
                return "CHARACTER";
            return Types.dbtypes.FirstOrDefault(x => x.Value == type).Key; 
        }

        public string GetPostgresType()
        {
            return Types.dbtypes[type];
        }


        public string GetCharPrecision()
        {
            var pres = "";
            if (!precision.Any())
                pres = "1";
            else
                pres = precision;

            return pres;

        }
    }
}
