using System;
using System.Collections.Generic;
using System.Data;

namespace DataProcess_PCMS_Objects {
	public sealed class core_ledger_account_Objects {
		#region Fields
		private int id_Ledger_Account;
		private string ledger_Account_Name;
		private double balance_Carried_Forward;
		private DateTime created_Date;
		private int created_User;
		private DateTime edited_Date;
		private int edited_User;
		private byte is_Active;
		private DataSet alldata=new DataSet();
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the core_ledger_account_Objects class.
		/// </summary>
		public core_ledger_account_Objects() {
		}
		
		/// <summary>
		/// Initializes a new instance of the core_ledger_account class.
		/// </summary>
		public core_ledger_account_Objects (int id_Ledger_Account, string ledger_Account_Name, double balance_Carried_Forward, DateTime created_Date, int created_User, DateTime edited_Date, int edited_User, byte is_Active) {
			this.id_Ledger_Account = id_Ledger_Account;
			this.ledger_Account_Name = ledger_Account_Name;
			this.balance_Carried_Forward = balance_Carried_Forward;
			this.created_Date = created_Date;
			this.created_User = created_User;
			this.edited_Date = edited_Date;
			this.edited_User = edited_User;
			this.is_Active = is_Active;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Id_Ledger_Account value.
		/// </summary>
		public int Id_Ledger_Account {
			get { return id_Ledger_Account; }
			set { id_Ledger_Account = value; }
		}
		
		/// <summary>
		/// Gets or sets the Ledger_Account_Name value.
		/// </summary>
		public string Ledger_Account_Name {
			get { return ledger_Account_Name; }
			set { ledger_Account_Name = value; }
		}
		
		/// <summary>
		/// Gets or sets the Balance_Carried_Forward value.
		/// </summary>
		public double Balance_Carried_Forward {
			get { return balance_Carried_Forward; }
			set { balance_Carried_Forward = value; }
		}
		
		/// <summary>
		/// Gets or sets the Created_Date value.
		/// </summary>
		public DateTime Created_Date {
			get { return created_Date; }
			set { created_Date = value; }
		}
		
		/// <summary>
		/// Gets or sets the Created_User value.
		/// </summary>
		public int Created_User {
			get { return created_User; }
			set { created_User = value; }
		}
		
		/// <summary>
		/// Gets or sets the Edited_Date value.
		/// </summary>
		public DateTime Edited_Date {
			get { return edited_Date; }
			set { edited_Date = value; }
		}
		
		/// <summary>
		/// Gets or sets the Edited_User value.
		/// </summary>
		public int Edited_User {
			get { return edited_User; }
			set { edited_User = value; }
		}
		
		/// <summary>
		/// Gets or sets the Is_Active value.
		/// </summary>
		public byte Is_Active {
			get { return is_Active; }
			set { is_Active = value; }
		}
		public DataSet Alldata  
		{
			get { return alldata; }
			set { alldata = value; }
		}
		#endregion
		
	}
}
