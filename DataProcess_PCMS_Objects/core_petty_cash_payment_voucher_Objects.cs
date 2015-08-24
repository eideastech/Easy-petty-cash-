using System;
using System.Collections.Generic;
using System.Data;

namespace DataProcess_PCMS_Objects{
	public sealed class core_petty_cash_payment_voucher_Objects {
		#region Fields
		private int id_Petty_Cash_Voucher;
		private int id_Petty_Cash_Book;
		private int id_Petty_Cash_Category;
		private double available_Balance_Amount;
		private string business_Purpose;
		private double cash_Out_Amount;
		private string received_By;
		private string petty_Cash_Voucher_Remark;
		private DateTime created_Date;
		private int created_User;
		private DateTime edited_Date;
		private int edited_User;
		private byte is_Active;
		private int post_Payment;
		private DataSet alldata=new DataSet();
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the core_petty_cash_payment_voucher_Objects class.
		/// </summary>
		public core_petty_cash_payment_voucher_Objects() {
		}
		
		/// <summary>
		/// Initializes a new instance of the core_petty_cash_payment_voucher class.
		/// </summary>
		public core_petty_cash_payment_voucher_Objects (int id_Petty_Cash_Voucher, int id_Petty_Cash_Book, int id_Petty_Cash_Category, double available_Balance_Amount, string business_Purpose, double cash_Out_Amount, string received_By, string petty_Cash_Voucher_Remark, DateTime created_Date, int created_User, DateTime edited_Date, int edited_User, byte is_Active, int post_Payment) {
			this.id_Petty_Cash_Voucher = id_Petty_Cash_Voucher;
			this.id_Petty_Cash_Book = id_Petty_Cash_Book;
			this.id_Petty_Cash_Category = id_Petty_Cash_Category;
			this.available_Balance_Amount = available_Balance_Amount;
			this.business_Purpose = business_Purpose;
			this.cash_Out_Amount = cash_Out_Amount;
			this.received_By = received_By;
			this.petty_Cash_Voucher_Remark = petty_Cash_Voucher_Remark;
			this.created_Date = created_Date;
			this.created_User = created_User;
			this.edited_Date = edited_Date;
			this.edited_User = edited_User;
			this.is_Active = is_Active;
			this.post_Payment = post_Payment;
		}
		#endregion
		
		#region Properties
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
		/// Gets or sets the Available_Balance_Amount value.
		/// </summary>
		public double Available_Balance_Amount {
			get { return available_Balance_Amount; }
			set { available_Balance_Amount = value; }
		}
		
		/// <summary>
		/// Gets or sets the Business_Purpose value.
		/// </summary>
		public string Business_Purpose {
			get { return business_Purpose; }
			set { business_Purpose = value; }
		}
		
		/// <summary>
		/// Gets or sets the Cash_Out_Amount value.
		/// </summary>
		public double Cash_Out_Amount {
			get { return cash_Out_Amount; }
			set { cash_Out_Amount = value; }
		}
		
		/// <summary>
		/// Gets or sets the Received_By value.
		/// </summary>
		public string Received_By {
			get { return received_By; }
			set { received_By = value; }
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
		
		/// <summary>
		/// Gets or sets the Post_Payment value.
		/// </summary>
		public int Post_Payment {
			get { return post_Payment; }
			set { post_Payment = value; }
		}
		public DataSet Alldata  
		{
			get { return alldata; }
			set { alldata = value; }
		}
		#endregion
		
	}
}
