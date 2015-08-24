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

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
            if(IsPostBack!=true)
            {
                loadDDL();
                loadGrid();
            }
         
        }
        
        protected void cmdSubmit_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
            {
                return;
            }
            else
            {
                InsertPCCDetails();
                ClearFeilds();
            }           
            loadGrid();
            
        }
        private void loadGrid()
        {
            core_petty_cash_category pccObj=new core_petty_cash_category();
            DataSet ds=pccObj.SelectMethod(@"SELECT
PCC.Id_Petty_Cash_Category,
PCC.Id_Ledger_Account,
LA.Ledger_Account_Name,
PCC.Petty_Cash_Category_Name,
PCC.Petty_Cash_Category_Code,
PCC.Created_Date, 
PCC.Created_User, 
PCC.Edited_Date, 
PCC.Edited_User, 
PCC.Is_Active
FROM core_petty_cash_category AS PCC
INNER JOIN core_ledger_account AS LA
ON  PCC.Id_Ledger_Account=LA.Id_Ledger_Account
WHERE PCC.Is_Active='0';", "core_petty_cash_category");
            if(ds.Tables["core_petty_cash_category"] != null)
            {
            GridView1.DataSource=ds.Tables["core_petty_cash_category"];
            GridView1.DataBind();
            }
            else
            {
            GridView1.DataSource=new int[]{};
            GridView1.DataBind();
            }
        }
        private void InsertPCCDetails()
        {
            if (cmdSubmit.CommandName.ToLower() == "SAVE".ToLower())
            {
                core_petty_cash_category pccObj = new core_petty_cash_category();
                core_petty_cash_category_Objects ObjPCC = new core_petty_cash_category_Objects();                
                ObjPCC.Petty_Cash_Category_Name = PCC_Name.Text;
                ObjPCC.Petty_Cash_Category_Code = PCC_Code.Text;
                ObjPCC.Id_Ledger_Account = Convert.ToInt32(ddlLedgerAccountType.SelectedValue);                
                ObjPCC.Created_Date = DateTime.Now;
                pccObj.Insert(ObjPCC);
                ScriptManager.RegisterStartupScript(this, GetType(), "insert", "showAlert('success');", true);
            }
            if (cmdSubmit.CommandName.ToLower() == "UPDATE".ToLower())
            {
                if (!((HiddenField1.Value) == null || (HiddenField1.Value) == ""))
                {
                    var sc = new core_petty_cash_category();//System.Net.WebUtility.HtmlEncode()
                    sc.UpdateMethod(@"UPDATE `core_petty_cash_category`
                                        SET
                                        `Petty_Cash_Category_Name` = '" + PCC_Name.Text.Trim().Replace("'", "''") + @"',
                                        `Petty_Cash_Category_Code` = '" + PCC_Code.Text.Trim().Replace("'", "''") + @"',
                                        `Id_Ledger_Account` = '" + Convert.ToInt32(ddlLedgerAccountType.SelectedValue) + @"',                                                                              
                                        `Edited_Date` = now()
                                        WHERE `Id_Petty_Cash_Category` = '" + Convert.ToInt32(HiddenField1.Value) + @"';");
                    ScriptManager.RegisterStartupScript(this, GetType(), "update", "showAlert('success');", true);
                }
            }
            this.ClearFeilds();
            loadGrid();
        }
        private void ClearFeilds()
        {
            PCC_Name.Text = "";
            PCC_Code.Text = "";
            if (ddlLedgerAccountType.Items.Count > 0)
            {
                ddlLedgerAccountType.SelectedIndex = 0;              
            }
            loadDDLLedgerAccountType();
            loadGrid();
            cmdSubmit.Text = "\u00A0\u00A0Save\u00A0\u00A0";
            cmdSubmit.CommandName = "SAVE";
            cmdClear.Text = "\u00A0\u00A0Clear\u00A0\u00A0";
            HiddenField1.Value = null;
        }

        private void loadDDL()
        {
            loadDDLLedgerAccountType();
        }

        private void loadDDLLedgerAccountType()
        {
            var sc=new core_ledger_account();
            DataSet ds=sc.SelectMethod(@"SELECT
LA.Id_Ledger_Account,
LA.Ledger_Account_Name
from core_ledger_account AS LA 
WHERE LA.Is_Active='0';","core_ledger_account");
            DataRow dr = ds.Tables["core_ledger_account"].NewRow();
            dr[0] = "0";
            dr[1] = "Select";
            ds.Tables["core_ledger_account"].Rows.InsertAt(dr, 0);
            ddlLedgerAccountType.DataSource=ds.Tables["core_ledger_account"];
            ddlLedgerAccountType.DataValueField = "Id_Ledger_Account";
            ddlLedgerAccountType.DataTextField = "Ledger_Account_Name";            
            ddlLedgerAccountType.DataBind();
        }
        protected void ddlLedgerAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Delete"))
            {
                try
                {               
                LinkButton LB = (LinkButton)e.CommandSource;
                GridView GV=(GridView)sender;
                GridViewRow GVRow = (GridViewRow)LB.Parent.Parent;
                string PCCid = GV.DataKeys[GVRow.RowIndex]["Id_Petty_Cash_Category"].ToString();
                HiddenField1.Value = PCCid.ToString();
                
                core_petty_cash_category PCC=new core_petty_cash_category();
                PCC.UpdateMethod(@"UPDATE `core_petty_cash_category`
                                        SET
                                        `Is_Active` = 1,
                                        `Edited_Date` = now()
                WHERE `Id_Petty_Cash_Category` = '" + Convert.ToInt32(HiddenField1.Value) + @"';");
                //PCC.UpdateMethod(@"UPDATE core_petty_cash_category SET Is_Active='1',Edited_date=now() WHERE Id_Petty_Cash_Category='" + Convert.ToString(HiddenField1.Value) + @"';");
                ScriptManager.RegisterStartupScript(this, GetType(), "delete", "showAlert('success');", true);    
                this.ClearFeilds();
                this.loadDDL();
                }
                catch(Exception ex)
                {
                    Exception E=ex;
                }

            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {           
            try {
                int IdPCC = Convert.ToInt32(GridView1.DataKeys[GridView1.SelectedIndex].Values["Id_Petty_Cash_Category"].ToString());
                // int Typeid = Convert.ToInt32(gridViewAccountCategory.DataKeys[gridViewAccountCategory.SelectedIndex].Values["Id_Acc_Account_Type"].ToString());
                int IdLA = Convert.ToInt32(GridView1.DataKeys[GridView1.SelectedIndex].Values["Id_Ledger_Account"].ToString());
                //int IdLA = Convert.ToInt32(GridView1.DataKeys[GridView1.SelectedIndex].Values["Ledger_Account_Name"]);
                GridViewRow GVRow = GridView1.SelectedRow;
                //PCB_Name.Text = System.Net.WebUtility.HtmlDecode(row.Cells[0].Text);
                PCC_Name.Text = System.Net.WebUtility.HtmlDecode(GVRow.Cells[0].Text);
                PCC_Code.Text = System.Net.WebUtility.HtmlDecode(GVRow.Cells[1].Text);


                if (ddlLedgerAccountType.Items.FindByValue(IdLA.ToString()) != null)
                {
                    ddlLedgerAccountType.SelectedValue = IdLA.ToString();

                }              
                HiddenField1.Value = IdPCC.ToString();

                cmdSubmit.CommandName = "UPDATE";
                cmdSubmit.Text = "Update";
                if (cmdSubmit.CommandName.ToLower() == "UPDATE".ToLower())
                {
                    cmdClear.Text = "Cancel";
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught", ex);
            }
                        
        }

        protected void cmdClear_Click(object sender, EventArgs e)
        {
            ClearFeilds();
        }

        protected void PCCName_ServerValidate1(object source, ServerValidateEventArgs args)
        {
            try
            {
                if (cmdSubmit.CommandName.ToLower() == "SAVE".ToLower())
                {
                    DataView dv;
                    core_petty_cash_category pccObj = new core_petty_cash_category();

                    //DataSet dataSet11 = new DataSet();
                    DataSet ds = pccObj.SelectMethod(@"SELECT PCC.Petty_Cash_Category_Name FROM core_petty_cash_category AS PCC WHERE PCC.Is_Active='0';", "core_petty_cash_category");
                    dv = ds.Tables["core_petty_cash_category"].DefaultView;
                    string pccn;
                    args.IsValid = true;    // Assume False
                    // Loop through table and compare each record against user's entry
                    foreach (DataRowView datarow in dv)
                    {
                        // Extract e-mail address from the current row
                        //txtEmail = datarow["Alias "].ToString();
                        pccn = datarow["Petty_Cash_Category_Name"].ToString();

                        // Compare e-mail address against user's entry
                        if (pccn == args.Value)
                        {
                            args.IsValid = false;
                        }
                    } 
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void cvPCC_Code_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                if (cmdSubmit.CommandName.ToLower() == "SAVE".ToLower())
                {
                    DataView dv;
                    core_petty_cash_category pccObj = new core_petty_cash_category();

                    //DataSet dataSet11 = new DataSet();
                    DataSet ds = pccObj.SelectMethod(@"SELECT PCC.Petty_Cash_Category_Code FROM core_petty_cash_category AS PCC WHERE PCC.Is_Active='0';", "core_petty_cash_category");
                    dv = ds.Tables["core_petty_cash_category"].DefaultView;
                    string pccc;
                    args.IsValid = true;
                    // Loop through table and compare each record against user's entry
                    foreach (DataRowView datarow in dv)
                    {
                        // Extract e-mail address from the current row
                        //txtEmail = datarow["Alias "].ToString();
                        pccc = datarow["Petty_Cash_Category_Code"].ToString();

                        // Compare e-mail address against user's entry
                        if (pccc == args.Value)
                        {
                            args.IsValid = false;
                        }
                    } 
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}