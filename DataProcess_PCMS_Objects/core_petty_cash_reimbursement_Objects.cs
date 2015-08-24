using System;
using System.Collections.Generic;
using System.Data;

namespace DataProcess_PCMS_Objects{
	public sealed class core_petty_cash_reimbursement_Objects {
		#region Fields
		private int id_Petty_Cash_Reimbursement;
		private int id_Petty_Cash_Book;
		private double amount_ThatShouldBe_Reimbursed;
		private double reimbursement_Amount;
		private double balance_Carried_Forward;
		private string petty_Cash_Reimbursement_Remark;
		private DateTime created_Date;
		private int created_User;
		private DateTime edited_Date;
		private int edited_User;
		private byte is_Active;
		private DataSet alldata=new DataSet();
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the core_petty_cash_reimbursement_Objects class.
		/// </summary>
		public core_petty_cash_reimbursement_Objects() {
		}
		
		/// <summary>
		/// Initializes a new instance of the core_petty_cash_reimbursement class.
		/// </summary>
		public core_petty_cash_reimbursement_Objects (int id_Petty_Cash_Reimbursement, int id_Petty_Cash_Book, double amount_ThatShouldBe_Reimbursed, double reimbursement_Amount, double balance_Carried_Forward, string petty_Cash_Reimbursement_Remark, DateTime created_Date, int created_User, DateTime edited_Date, int edited_User, byte is_Active) {
			this.id_Petty_Cash_Reimbursement = id_Petty_Cash_Reimbursement;
			this.id_Petty_Cash_Book = id_Petty_Cash_Book;
			this.amount_ThatShouldBe_Reimbursed = amount_ThatShouldBe_Reimbursed;
			this.reimbursement_Amount = reimbursement_Amount;
			this.balance_Carried_Forward = balance_Carried_Forward;
			this.petty_Cash_Reimbursement_Remark = petty_Cash_Reimbursement_Remark;
			this.created_Date = created_Date;
			this.created_User = created_User;
			this.edited_Date = edited_Date;
			this.edited_User = edited_User;
			this.is_Active = is_Active;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Id_Petty_Cash_Reimbursement value.
		/// </summary>
		public int Id_Petty_Cash_Reimbursement {
			get { return id_Petty_Cash_Reimbursement; }
			set { id_Petty_Cash_Reimbursement = value; }
		}
		
		/// <summary>
		/// Gets or sets the Id_Petty_Cash_Book value.
		/// </summary>
		public int Id_Petty_Cash_Book {
			get { return id_Petty_Cash_Book; }
			set { id_Petty_Cash_Book = value; }
		}
		
		/// <summary>
		/// Gets or sets the Amount_ThatShouldBe_Reimbursed value.
		/// </summary>
		public double Amount_ThatShouldBe_Reimbursed {
			get { return amount_ThatShouldBe_Reimbursed; }
			set { amount_ThatShouldBe_Reimbursed = value; }
		}
		
		/// <summary>
		/// Gets or sets the Reimbursement_Amount value.
		/// </summary>
		public double Reimbursement_Amount {
			get { return reimbursement_Amount; }
			set { reimbursement_Amount = value; }
		}
		
		/// <summary>
		/// Gets or sets the Balance_Carried_Forward value.
		/// </summary>
		public double Balance_Carried_Forward {
			get { return balance_Carried_Forward; }
			set { balance_Carried_Forward = value; }
		}
		
		/// <summary>
		/// Gets or sets the Petty_Cash_Reimbursement_Remark value.
		/// </summary>
		public string Petty_Cash_Reimbursement_Remark {
			get { return petty_Cash_Reimbursement_Remark; }
			set { petty_Cash_Reimbursement_Remark = value; }
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
