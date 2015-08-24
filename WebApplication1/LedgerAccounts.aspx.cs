using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using DataProcess_PCMS;
using DataProcess_PCMS_Objects;
using ClassLibrary;

namespace WebApplication1
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.loadDDL();
            }
        }
        private void loadDDL()
        {
            core_ledger_account laObj = new core_ledger_account();
            DataSet ds = laObj.SelectMethod(@"SELECT LA.Id_Ledger_Account,LA.Ledger_Account_Name FROM core_ledger_account AS LA WHERE LA.Is_Active='0';", "core_ledger_account");
            DataRow dr = ds.Tables["core_ledger_account"].NewRow();
            dr[0] = "0";
            dr[1] = "Select";
            ds.Tables["core_ledger_account"].Rows.InsertAt(dr, 0);
            ddlLAName.DataSource = ds.Tables["core_ledger_account"];
            ddlLAName.DataValueField = "Id_Ledger_Account";
            ddlLAName.DataTextField = "Ledger_Account_Name";
            ddlLAName.DataBind();
        }

        protected void ddlLAName_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfLAID.Value = ddlLAName.SelectedValue.ToString();      
        }

        private void loadGrid()
        {
            Common cm = new Common();
            core_ledger_entry objLE = new core_ledger_entry();
            DataSet ds = objLE.SelectMethod(@"SELECT 
le.Id_Ledger_Entry,
le.Id_Petty_Cash_Voucher,
le.Id_Petty_Cash_Book,
pcb.Petty_Cash_Book_Name,
pcb.Petty_Cash_Book_Code,
le.Id_Petty_Cash_Category,
pcc.Petty_Cash_Category_Name,
pcc.Petty_Cash_Category_Code,
le.Id_Ledger_Account,
le.Balance_Carried_Forward,
le.Debit_Amount,
le.Credit_Amount,
CASE WHEN le.Post_Payment='0' THEN 'Post Payment' ELSE 'Pre Payment' END AS Post_Payment,
le.Created_Date,
le.Created_User,
le.Edited_Date,
le.Edited_User
FROM core_ledger_entry AS le
INNER JOIN core_petty_cash_book AS pcb ON le.Id_Petty_Cash_Book=pcb.Id_Petty_Cash_Book
INNER JOIN core_petty_cash_category AS pcc ON le.Id_Petty_Cash_Category=pcc.Id_Petty_Cash_Category
WHERE le.Id_Ledger_Account='" + Convert.ToInt32(hfLAID.Value) + @"' AND DATE(le.Created_Date) BETWEEN DATE('" + cm.convertToMySqlDate(fromDate.Text.Trim()) + "') and DATE('" + cm.convertToMySqlDate(toDate.Text.Trim()) + "');", "core_ledger_entry");
            
            if (ds.Tables[0].Rows.Count > 0)
            {
                leGrid.DataSource = ds.Tables["core_ledger_entry"];
                leGrid.DataBind();
            }
            else
            {
                leGrid.DataSource = new int[] { };
                leGrid.DataBind();
                ScriptManager.RegisterStartupScript(this, GetType(), "AlertSweet", "alertSweet();", true);
                //ScriptManager.RegisterStartupScript(up1, GetType(), "AlertSweet", "showAlert('error');", true);
            }
        }

        protected void cmdSubmit_Click(object sender, EventArgs e)
        {
            loadGrid();
        }


    }
}