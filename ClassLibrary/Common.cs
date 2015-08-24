using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ClassLibrary
{
    public class Common
    {
        #region Fields
        /// <summary>
        /// Saves a record to the country table.
        /// </summary>


        /// <summary>
        /// Selects all records from the country table.
        /// </summary>
        public DataSet SelectMethod(String sqlString, String tblName)
        {

            MySqlConnection scon = Connectivity.Cls_Connection.getConnection();
            MySqlDataAdapter sdap = new MySqlDataAdapter(sqlString, scon);
            DataSet Alldata = new DataSet();

            Alldata.Clear();
            if (scon.State == 0) { scon.Open(); }
            sdap.Fill(Alldata, tblName);
            //scon.Close();

            return Alldata;
        }


        /// <summary>
        /// Selects all records from the country table.
        /// </summary>
        public void UpdateMethod(String sqlString)
        {

            MySqlConnection scon = Connectivity.Cls_Connection.getConnection();
            MySqlDataAdapter sdap = new MySqlDataAdapter(sqlString, scon);
            if (scon.State == 0) { scon.Open(); }

            sdap.SelectCommand.ExecuteNonQuery();

            //scon.Close();
        }

        public string convertToMySqlDate(string customDate)
        {
            string mySqlDate = "";
            try
            {
                mySqlDate = Convert.ToDateTime(customDate).ToString("yyyy-MM-dd");

            }
            catch (Exception ex)
            {

            }

            return mySqlDate;
        }


        public string convertToCustomDate(string mySqlDate)
        {
            string customDate = "";
            try
            {
                customDate = Convert.ToDateTime(mySqlDate).ToString("yyyy-MM-dd");

            }
            catch (Exception ex)
            {

            }

            return customDate;
        }

        public string convertToCustomDate1(string mySqlDate)
        {
            string customDate = "";
            try
            {
                customDate = Convert.ToDateTime(mySqlDate).ToString("dd-MM-yyyy");

            }
            catch (Exception ex)
            {

            }

            return customDate;
        }


        public Boolean isFromDateGreaterThanToDate(string fromDate, string toDate)
        {
            DateTime fromd_date = Convert.ToDateTime(convertToMySqlDate(fromDate));
            DateTime to_date = Convert.ToDateTime(convertToMySqlDate(toDate));
            Boolean var = false;
            if (fromd_date <= to_date)
            {
                var = true;
            }

            return var;
        }


        #endregion
    }
}
