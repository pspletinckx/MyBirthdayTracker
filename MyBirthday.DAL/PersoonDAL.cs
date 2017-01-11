using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBirthday.DAL
{
    public static class PersoonDAL
    {
        private static DataSet dsPeroon;
        private static DataTable dtPersoon;

        private static SQLDac localDac;
        static PersoonDAL(){}

        public static DataTable GetItem(int id) {
            dtPersoon: new DataTable("persons");

            string sqlSelect = "SELECT * FROM persons ";
            dtPersoon = localDac.ExecuteDT(sqlSelect, OpdrachtTypes.SqlStatement, "Stories");

        }
        public static DataTable GetItems() { }
        public static void SetItems(object obj) { }

    }
}
