using System;
using System.Collections.Generic;
using System.Data;

namespace DataProcess_PCMS_Objects {
	public sealed class core_petty_cash_settlement_Objects {
		#region Fields
		private int id_Petty_Cash_Settlement;
		private int id_Petty_Cash_Voucher;
		private int id_Ledger_Account;
		private int id_Petty_Cash_Book;
		private int id_Petty_Cash_Category;
		private double cash_Out_Amount;
		private double cash_In_Amount;
		private double net_Cash_Out_Amount;
		private string petty_Cash_Voucher_Remark;
		private DateTime created_Date;
		private int created_User;
		private DateTime edited_Date;
		private int edited_User;
		private byte is_Active;
		private DataSet alldata=new DataSet();
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the core_petty_cash_settlement_Objects class.
		/// </summary>
		public core_petty_cash_settlement_Objects() {
		}
		
		/// <summary>
		/// Initializes a new instance of the core_petty_cash_settlement class.
		/// </summary>
		public core_petty_cash_settlement_Objects (int id_Petty_Cash_Settlement, int id_Petty_Cash_Voucher, int id_Ledger_Account, int id_Petty_Cash_Book, int id_Petty_Cash_Category, double cash_Out_Amount, double cash_In_Amount, double net_Cash_Out_Amount, string petty_Cash_Voucher_Remark, DateTime created_Date, int created_User, DateTime edited_Date, int edited_User, byte is_Active) {
			this.id_Petty_Cash_Settlement = id_Petty_Cash_Settlement;
			this.id_Petty_Cash_Voucher = id_Petty_Cash_Voucher;
			this.id_Ledger_Account = id_Ledger_Account;
			this.id_Petty_Cash_Book = id_Petty_Cash_Book;
			this.id_Petty_Cash_Category = id_Petty_Cash_Category;
			this.cash_Out_Amount = cash_Out_Amount;
			this.cash_In_Amount = cash_In_Amount;
			this.net_Cash_Out_Amount = net_Cash_Out_Amount;
			this.petty_Cash_Voucher_Remark = petty_Cash_Voucher_Remark;
			this.created_Date = created_Date;
			this.created_User = created_User;
			this.edited_Date = edited_Date;
			this.edited_User = edited_User;
			this.is_Active = is_Active;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Id_Petty_Cash_Settlement value.
		/// </summary>
		public int Id_Petty_Cash_Settlement {
			get { return id_Petty_Cash_Settlement; }
			set { id_Petty_Cash_Settlement = value; }
		}
		
		/// <summary>
		/// Gets or sets the Id_Petty_Cash_Voucher value.
		/// </summary>
		public int Id_Petty_Cash_Voucher {
			get { return id_Petty_Cash_Voucher; }
			set { id_Petty_Cash_Voucher = value; }
		}
		
		/// <summary>
		/// Gets or sets the Id_Ledger_Account value.
		/// </summary>
		public int Id_Ledger_Account {
			get { return id_Ledger_Account; }
			set { id_Ledger_Account = value; }
		}
		
		/// <summary>
		/// Gets or sets the Id_Petty_Cash_Book value.
		/// </summary>
		public int Id_Petty_Cash_Book {
			get { return id_Petty_Cash_Book; }
			set { id_Petty_Cash_Book = value; }
		}
		
		/// <summary>
		/// Gets or sets the Id_Petty_Cash_Category value.
		/// </summary>
		public int Id_Petty_Cash_Category {
			get { return id_Petty_Cash_Category; }
			set { id_Petty_Cash_Category = value; }
		}
		
		/// <summary>
		/// Gets or sets the Cash_Out_Amount value.
		/// </summary>
		public double Cash_Out_Amount {
			get { return cash_Out_Amount; }
			set { cash_Out_Amount = value; }
		}
		
		/// <summary>
		/// Gets or sets the Cash_In_Amount value.
		/// </summary>
		public double Cash_In_Amount {
			get { return cash_In_Amount; }
			set { cash_In_Amount = value; }
		}
		
		/// <summary>
		/// Gets or sets the Net_Cash_Out_Amount value.
		/// </summary>
		public double Net_Cash_Out_Amount {
			get { return net_Cash_Out_Amount; }
			set { net_Cash_Out_Amount = value; }
		}
		
		/// <summary>
		/// Gets or sets the Petty_Cash_Voucher_Remark value.
		/// </summary>
		public string Petty_Cash_Voucher_Remark {
			get { return petty_Cash_Voucher_Remark; }
			set { petty_Cash_Voucher_Remark = value; }
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
