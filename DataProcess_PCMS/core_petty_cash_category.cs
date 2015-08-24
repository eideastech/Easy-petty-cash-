using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using DataProcess_PCMS_Objects;

namespace DataProcess_PCMS_Objects {
	public sealed class core_petty_cash_category {
public core_petty_cash_category()
{

}
		#region Fields
		/// <summary>
		/// Saves a record to the core_petty_cash_category table.
		/// </summary>
		public void Insert(core_petty_cash_category_Objects objCls) {
 
			MySqlConnection scon = Connectivity.Cls_Connection.getConnection();
			MySqlCommand scom = new MySqlCommand("core_petty_cash_categoryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("COL_Id_Petty_Cash_Category", MySqlDbType.Int32,0);
			scom.Parameters.Add("COL_Id_Ledger_Account", MySqlDbType.Int32,0);
			scom.Parameters.Add("COL_Petty_Cash_Category_Name", MySqlDbType.VarChar,45);
			scom.Parameters.Add("COL_Petty_Cash_Category_Code", MySqlDbType.VarChar,45);
			scom.Parameters.Add("COL_Created_Date", MySqlDbType.DateTime,0);
			scom.Parameters.Add("COL_Created_User", MySqlDbType.Int32,0);
			scom.Parameters.Add("COL_Edited_Date", MySqlDbType.DateTime,0);
			scom.Parameters.Add("COL_Edited_User", MySqlDbType.Int32,0);
			scom.Parameters.Add("COL_Is_Active", MySqlDbType.Bit,0);
 
			scom.Parameters["COL_Id_Petty_Cash_Category"].Value = objCls.Id_Petty_Cash_Category;
			scom.Parameters["COL_Id_Ledger_Account"].Value = objCls.Id_Ledger_Account;
			scom.Parameters["COL_Petty_Cash_Category_Name"].Value = objCls.Petty_Cash_Category_Name;
			scom.Parameters["COL_Petty_Cash_Category_Code"].Value = objCls.Petty_Cash_Category_Code;
			scom.Parameters["COL_Created_Date"].Value = objCls.Created_Date;
			scom.Parameters["COL_Created_User"].Value = objCls.Created_User;
			scom.Parameters["COL_Edited_Date"].Value = objCls.Edited_Date;
			scom.Parameters["COL_Edited_User"].Value = objCls.Edited_User;
			scom.Parameters["COL_Is_Active"].Value = objCls.Is_Active;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the core_petty_cash_category table.
		/// </summary>
		public DataSet SelectMethod(String sqlString,String tblName) {
 
			MySqlConnection scon = Connectivity.Cls_Connection.getConnection();
			MySqlDataAdapter sdap = new MySqlDataAdapter(sqlString, scon);
			DataSet Alldata=new DataSet();
 
			Alldata.Clear();
			scon.Open();
			sdap.Fill(Alldata, tblName);
			scon.Close();
 
			return Alldata;
		}
		
		/// <summary>
		/// Selects all records from the core_petty_cash_category table.
		/// </summary>
		public void UpdateMethod(String sqlString) {
 
			MySqlConnection scon = Connectivity.Cls_Connection.getConnection();
			MySqlDataAdapter sdap = new MySqlDataAdapter(sqlString, scon);
			scon.Open();
 
			sdap.SelectCommand.ExecuteNonQuery(); 
 
			scon.Close();
		}
		
		public DataSet SelectAll() {
 
			MySqlConnection scon = Connectivity.Cls_Connection.getConnection();
			MySqlDataAdapter sdap = new MySqlDataAdapter("select * from core_petty_cash_category", scon);
			DataSet alldata=new DataSet();
 
			scon.Open();
			sdap.Fill(alldata, "core_petty_cash_category");
			scon.Close();
 
			return alldata;
		}
		
		public DataRow SelectByPK(int  Id_Petty_Cash_Category_col) {
 
			MySqlConnection scon = Connectivity.Cls_Connection.getConnection();
			MySqlDataAdapter sdap = new MySqlDataAdapter("select * from core_petty_cash_category where Id_Petty_Cash_Category= " + Id_Petty_Cash_Category_col, scon);
			DataSet alldata=new DataSet();
 
			scon.Open();
			sdap.Fill(alldata, "core_petty_cash_category");
			scon.Close();
 
			return alldata.Tables[0].Rows[0];
		}
		
		#endregion
	}
}
