using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using DataProcess_PCMS_Objects;

namespace DataProcess_PCMS
{
	public sealed class core_ledger_entry {
public core_ledger_entry()
{

}
		#region Fields
		/// <summary>
		/// Saves a record to the core_ledger_entry table.
		/// </summary>
		public void Insert(core_ledger_entry_Objects objCls) {
 
			MySqlConnection scon = Connectivity.Cls_Connection.getConnection();
			MySqlCommand scom = new MySqlCommand("core_ledger_entryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("COL_Id_Ledger_Entry", MySqlDbType.Int32,0);
			scom.Parameters.Add("COL_Id_Ledger_Account", MySqlDbType.Int32,0);
			scom.Parameters.Add("COL_Id_Petty_Cash_Voucher", MySqlDbType.Int32,0);
			scom.Parameters.Add("COL_Id_Petty_Cash_Book", MySqlDbType.Int32,0);
			scom.Parameters.Add("COL_Id_Petty_Cash_Category", MySqlDbType.Int32,0);
			scom.Parameters.Add("COL_Debit_Amount", MySqlDbType.Double,0);
			scom.Parameters.Add("COL_Credit_Amount", MySqlDbType.Double,0);
			scom.Parameters.Add("COL_Balance_Carried_Forward", MySqlDbType.Double,0);
			scom.Parameters.Add("COL_Created_Date", MySqlDbType.DateTime,0);
			scom.Parameters.Add("COL_Created_User", MySqlDbType.Int32,0);
			scom.Parameters.Add("COL_Edited_Date", MySqlDbType.DateTime,0);
			scom.Parameters.Add("COL_Edited_User", MySqlDbType.Int32,0);
			scom.Parameters.Add("COL_Is_Active", MySqlDbType.Bit,0);
			scom.Parameters.Add("COL_Post_Payment", MySqlDbType.Int32,0);
			scom.Parameters.Add("COL_Business_Purpose", MySqlDbType.Text,65535);
 
			scom.Parameters["COL_Id_Ledger_Entry"].Value = objCls.Id_Ledger_Entry;
			scom.Parameters["COL_Id_Ledger_Account"].Value = objCls.Id_Ledger_Account;
			scom.Parameters["COL_Id_Petty_Cash_Voucher"].Value = objCls.Id_Petty_Cash_Voucher;
			scom.Parameters["COL_Id_Petty_Cash_Book"].Value = objCls.Id_Petty_Cash_Book;
			scom.Parameters["COL_Id_Petty_Cash_Category"].Value = objCls.Id_Petty_Cash_Category;
			scom.Parameters["COL_Debit_Amount"].Value = objCls.Debit_Amount;
			scom.Parameters["COL_Credit_Amount"].Value = objCls.Credit_Amount;
			scom.Parameters["COL_Balance_Carried_Forward"].Value = objCls.Balance_Carried_Forward;
			scom.Parameters["COL_Created_Date"].Value = objCls.Created_Date;
			scom.Parameters["COL_Created_User"].Value = objCls.Created_User;
			scom.Parameters["COL_Edited_Date"].Value = objCls.Edited_Date;
			scom.Parameters["COL_Edited_User"].Value = objCls.Edited_User;
			scom.Parameters["COL_Is_Active"].Value = objCls.Is_Active;
			scom.Parameters["COL_Post_Payment"].Value = objCls.Post_Payment;
			scom.Parameters["COL_Business_Purpose"].Value = objCls.Business_Purpose;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the core_ledger_entry table.
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
		/// Selects all records from the core_ledger_entry table.
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
			MySqlDataAdapter sdap = new MySqlDataAdapter("select * from core_ledger_entry", scon);
			DataSet alldata=new DataSet();
 
			scon.Open();
			sdap.Fill(alldata, "core_ledger_entry");
			scon.Close();
 
			return alldata;
		}
		
		public DataRow SelectByPK(int  Id_Ledger_Entry_col) {
 
			MySqlConnection scon = Connectivity.Cls_Connection.getConnection();
			MySqlDataAdapter sdap = new MySqlDataAdapter("select * from core_ledger_entry where Id_Ledger_Entry= " + Id_Ledger_Entry_col, scon);
			DataSet alldata=new DataSet();
 
			scon.Open();
			sdap.Fill(alldata, "core_ledger_entry");
			scon.Close();
 
			return alldata.Tables[0].Rows[0];
		}
		
		#endregion
	}
}
