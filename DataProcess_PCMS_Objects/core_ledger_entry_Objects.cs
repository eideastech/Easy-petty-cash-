using System;
using System.Collections.Generic;
using System.Data;

namespace DataProcess_PCMS_Objects
{
	public sealed class core_ledger_entry_Objects {
		#region Fields
		private int id_Ledger_Entry;
		private int id_Ledger_Account;
		private int id_Petty_Cash_Voucher;
		private int id_Petty_Cash_Book;
		private int id_Petty_Cash_Category;
		private double debit_Amount;
		private double credit_Amount;
		private double balance_Carried_Forward;
		private DateTime created_Date;
		private int created_User;
		private DateTime edited_Date;
		private int edited_User;
		private byte is_Active;
		private int post_Payment;
		private string business_Purpose;
		private DataSet alldata=new DataSet();
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the core_ledger_entry_Objects class.
		/// </summary>
		public core_ledger_entry_Objects() {
		}
		
		/// <summary>
		/// Initializes a new instance of the core_ledger_entry class.
		/// </summary>
		public core_ledger_entry_Objects (int id_Ledger_Entry, int id_Ledger_Account, int id_Petty_Cash_Voucher, int id_Petty_Cash_Book, int id_Petty_Cash_Category, double debit_Amount, double credit_Amount, double balance_Carried_Forward, DateTime created_Date, int created_User, DateTime edited_Date, int edited_User, byte is_Active, int post_Payment, string business_Purpose) {
			this.id_Ledger_Entry = id_Ledger_Entry;
			this.id_Ledger_Account = id_Ledger_Account;
			this.id_Petty_Cash_Voucher = id_Petty_Cash_Voucher;
			this.id_Petty_Cash_Book = id_Petty_Cash_Book;
			this.id_Petty_Cash_Category = id_Petty_Cash_Category;
			this.debit_Amount = debit_Amount;
			this.credit_Amount = credit_Amount;
			this.balance_Carried_Forward = balance_Carried_Forward;
			this.created_Date = created_Date;
			this.created_User = created_User;
			this.edited_Date = edited_Date;
			this.edited_User = edited_User;
			this.is_Active = is_Active;
			this.post_Payment = post_Payment;
			this.business_Purpose = business_Purpose;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Id_Ledger_Entry value.
		/// </summary>
		public int Id_Ledger_Entry {
			get { return id_Ledger_Entry; }
			set { id_Ledger_Entry = value; }
		}
		
		/// <summary>
		/// Gets or sets the Id_Ledger_Account value.
		/// </summary>
		public int Id_Ledger_Account {
			get { return id_Ledger_Account; }
			set { id_Ledger_Account = value; }
		}
		
		/// <summary>
		/// Gets or sets the Id_Petty_Cash_Voucher value.
		/// </summary>
		public int Id_Petty_Cash_Voucher {
			get { return id_Petty_Cash_Voucher; }
			set { id_Petty_Cash_Voucher = value; }
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
		/// Gets or sets the Debit_Amount value.
		/// </summary>
		public double Debit_Amount {
			get { return debit_Amount; }
			set { debit_Amount = value; }
		}
		
		/// <summary>
		/// Gets or sets the Credit_Amount value.
		/// </summary>
		public double Credit_Amount {
			get { return credit_Amount; }
			set { credit_Amount = value; }
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
		
		/// <summary>
		/// Gets or sets the Post_Payment value.
		/// </summary>
		public int Post_Payment {
			get { return post_Payment; }
			set { post_Payment = value; }
		}
		
		/// <summary>
		/// Gets or sets the Business_Purpose value.
		/// </summary>
		public string Business_Purpose {
			get { return business_Purpose; }
			set { business_Purpose = value; }
		}
		public DataSet Alldata  
		{
			get { return alldata; }
			set { alldata = value; }
		}
		#endregion
		
	}
}
