using System;
using System.Collections.Generic;
using System.Data;

namespace DataProcess_PCMS_Objects
{
	public sealed class core_petty_cash_book_Objects {
		#region Fields
		private int id_Petty_Cash_Book;
		private string petty_Cash_Book_Name;
		private string petty_Cash_Book_Code;
		private double petty_Cash_Book_Max_Amount;
		private double available_Balance_Amount;
		private string petty_Cash_Book_Remark;
		private DateTime created_Date;
		private int created_User;
		private DateTime edited_Date;
		private int edited_User;
		private byte is_Active;
		private DataSet alldata=new DataSet();
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the core_petty_cash_book_Objects class.
		/// </summary>
		public core_petty_cash_book_Objects() {
		}
		
		/// <summary>
		/// Initializes a new instance of the core_petty_cash_book class.
		/// </summary>
		public core_petty_cash_book_Objects (int id_Petty_Cash_Book, string petty_Cash_Book_Name, string petty_Cash_Book_Code, double petty_Cash_Book_Max_Amount, double available_Balance_Amount, string petty_Cash_Book_Remark, DateTime created_Date, int created_User, DateTime edited_Date, int edited_User, byte is_Active) {
			this.id_Petty_Cash_Book = id_Petty_Cash_Book;
			this.petty_Cash_Book_Name = petty_Cash_Book_Name;
			this.petty_Cash_Book_Code = petty_Cash_Book_Code;
			this.petty_Cash_Book_Max_Amount = petty_Cash_Book_Max_Amount;
			this.available_Balance_Amount = available_Balance_Amount;
			this.petty_Cash_Book_Remark = petty_Cash_Book_Remark;
			this.created_Date = created_Date;
			this.created_User = created_User;
			this.edited_Date = edited_Date;
			this.edited_User = edited_User;
			this.is_Active = is_Active;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Id_Petty_Cash_Book value.
		/// </summary>
		public int Id_Petty_Cash_Book {
			get { return id_Petty_Cash_Book; }
			set { id_Petty_Cash_Book = value; }
		}
		
		/// <summary>
		/// Gets or sets the Petty_Cash_Book_Name value.
		/// </summary>
		public string Petty_Cash_Book_Name {
			get { return petty_Cash_Book_Name; }
			set { petty_Cash_Book_Name = value; }
		}
		
		/// <summary>
		/// Gets or sets the Petty_Cash_Book_Code value.
		/// </summary>
		public string Petty_Cash_Book_Code {
			get { return petty_Cash_Book_Code; }
			set { petty_Cash_Book_Code = value; }
		}
		
		/// <summary>
		/// Gets or sets the Petty_Cash_Book_Max_Amount value.
		/// </summary>
		public double Petty_Cash_Book_Max_Amount {
			get { return petty_Cash_Book_Max_Amount; }
			set { petty_Cash_Book_Max_Amount = value; }
		}
		
		/// <summary>
		/// Gets or sets the Available_Balance_Amount value.
		/// </summary>
		public double Available_Balance_Amount {
			get { return available_Balance_Amount; }
			set { available_Balance_Amount = value; }
		}
		
		/// <summary>
		/// Gets or sets the Petty_Cash_Book_Remark value.
		/// </summary>
		public string Petty_Cash_Book_Remark {
			get { return petty_Cash_Book_Remark; }
			set { petty_Cash_Book_Remark = value; }
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
