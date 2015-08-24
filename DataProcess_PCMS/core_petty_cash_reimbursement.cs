using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using DataProcess_PCMS_Objects;

namespace DataProcess_PCMS_Objects {
	public sealed class core_petty_cash_reimbursement{
public core_petty_cash_reimbursement()
{

}
		#region Fields
		/// <summary>
		/// Saves a record to the core_petty_cash_reimbursement table.
		/// </summary>
		public void Insert(core_petty_cash_reimbursement_Objects objCls) {
 
			MySqlConnection scon = Connectivity.Cls_Connection.getConnection();
			MySqlCommand scom = new MySqlCommand("core_petty_cash_reimbursementInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("COL_Id_Petty_Cash_Reimbursement", MySqlDbType.Int32,0);
			scom.Parameters.Add("COL_Id_Petty_Cash_Book", MySqlDbType.Int32,0);
			scom.Parameters.Add("COL_Amount_ThatShouldBe_Reimbursed", MySqlDbType.Double,0);
			scom.Parameters.Add("COL_Reimbursement_Amount", MySqlDbType.Double,0);
			scom.Parameters.Add("COL_Balance_Carried_Forward", MySqlDbType.Double,0);
			scom.Parameters.Add("COL_Petty_Cash_Reimbursement_Remark", MySqlDbType.Text,65535);
			scom.Parameters.Add("COL_Created_Date", MySqlDbType.DateTime,0);
			scom.Parameters.Add("COL_Created_User", MySqlDbType.Int32,0);
			scom.Parameters.Add("COL_Edited_Date", MySqlDbType.DateTime,0);
			scom.Parameters.Add("COL_Edited_User", MySqlDbType.Int32,0);
			scom.Parameters.Add("COL_Is_Active", MySqlDbType.Bit,0);
 
			scom.Parameters["COL_Id_Petty_Cash_Reimbursement"].Value = objCls.Id_Petty_Cash_Reimbursement;
			scom.Parameters["COL_Id_Petty_Cash_Book"].Value = objCls.Id_Petty_Cash_Book;
			scom.Parameters["COL_Amount_ThatShouldBe_Reimbursed"].Value = objCls.Amount_ThatShouldBe_Reimbursed;
			scom.Parameters["COL_Reimbursement_Amount"].Value = objCls.Reimbursement_Amount;
			scom.Parameters["COL_Balance_Carried_Forward"].Value = objCls.Balance_Carried_Forward;
			scom.Parameters["COL_Petty_Cash_Reimbursement_Remark"].Value = objCls.Petty_Cash_Reimbursement_Remark;
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
		/// Selects all records from the core_petty_cash_reimbursement table.
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
		/// Selects all records from the core_petty_cash_reimbursement table.
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
			MySqlDataAdapter sdap = new MySqlDataAdapter("select * from core_petty_cash_reimbursement", scon);
			DataSet alldata=new DataSet();
 
			scon.Open();
			sdap.Fill(alldata, "core_petty_cash_reimbursement");
			scon.Close();
 
			return alldata;
		}
		
		public DataRow SelectByPK(int  Id_Petty_Cash_Reimbursement_col) {
 
			MySqlConnection scon = Connectivity.Cls_Connection.getConnection();
			MySqlDataAdapter sdap = new MySqlDataAdapter("select * from core_petty_cash_reimbursement where Id_Petty_Cash_Reimbursement= " + Id_Petty_Cash_Reimbursement_col, scon);
			DataSet alldata=new DataSet();
 
			scon.Open();
			sdap.Fill(alldata, "core_petty_cash_reimbursement");
			scon.Close();
 
			return alldata.Tables[0].Rows[0];
		}
		
		#endregion
	}
}
