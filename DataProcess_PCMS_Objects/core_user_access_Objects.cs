using System;
using System.Collections.Generic;
using System.Data;

namespace DataProcess_PCMS_Objects {
	public sealed class core_user_access_Objects {
		#region Fields
		private int id_User_Access;
		private string username;
		private string password;
		private DateTime created_Date;
		private int created_User;
		private DateTime edited_Date;
		private int edited_User;
		private byte is_Active;
		private DataSet alldata=new DataSet();
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the core_user_access_Objects class.
		/// </summary>
		public core_user_access_Objects() {
		}
		
		/// <summary>
		/// Initializes a new instance of the core_user_access class.
		/// </summary>
		public core_user_access_Objects (int id_User_Access, string username, string password, DateTime created_Date, int created_User, DateTime edited_Date, int edited_User, byte is_Active) {
			this.id_User_Access = id_User_Access;
			this.username = username;
			this.password = password;
			this.created_Date = created_Date;
			this.created_User = created_User;
			this.edited_Date = edited_Date;
			this.edited_User = edited_User;
			this.is_Active = is_Active;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Id_User_Access value.
		/// </summary>
		public int Id_User_Access {
			get { return id_User_Access; }
			set { id_User_Access = value; }
		}
		
		/// <summary>
		/// Gets or sets the Username value.
		/// </summary>
		public string Username {
			get { return username; }
			set { username = value; }
		}
		
		/// <summary>
		/// Gets or sets the Password value.
		/// </summary>
		public string Password {
			get { return password; }
			set { password = value; }
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
