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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack != true)
            {
                RetrievePCBDetails();

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
                InsertPCBDetails();
                ClearFeilds();
            }
            RetrievePCBDetails();

        }

        private void InsertPCBDetails()
        {

            if (cmdSubmit.CommandName.ToLower() == "SAVE".ToLower())
            {


                core_petty_cash_book pcbObj = new core_petty_cash_book();
                core_petty_cash_book_Objects ObjPCB = new core_petty_cash_book_Objects();
                ObjPCB.Petty_Cash_Book_Name = PCB_Name.Text;
                ObjPCB.Petty_Cash_Book_Code = PCB_Code.Text;
                ObjPCB.Petty_Cash_Book_Max_Amount = Convert.ToDouble(PCB_Max_Amount.Text);
                ObjPCB.Available_Balance_Amount = Convert.ToDouble(hfAvailableBalance.Value);
                ObjPCB.Petty_Cash_Book_Remark = PCB_Remark.Text;
                ObjPCB.Created_Date = DateTime.Today;

                //ObjPCB.Created_Date = Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy-MM-dd"));
                //txtTrDate.Text = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(DateTime.Now.Date));

                pcbObj.Insert(ObjPCB);
                //ScriptManager.RegisterStartupScript(this, GetType(), "AlertSweet", "alertSweet1();", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "insert", "showAlert('success');", true);
            }
            if (cmdSubmit.CommandName.ToLower() == "UPDATE".ToLower())
            {
                if (!((HiddenField1.Value) == null || (HiddenField1.Value) == ""))
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "updateConfirm", "alertSweet1();", true);
                    var sc = new core_petty_cash_book();//System.Net.WebUtility.HtmlEncode()
                    sc.UpdateMethod(@"UPDATE `core_petty_cash_book`
                                        SET                                        
                                        `Petty_Cash_Book_Name` = '" + PCB_Name.Text.Trim().Replace("'", "''") + @"',
                                        `Petty_Cash_Book_Code` = '" + PCB_Code.Text.Trim().Replace("'", "''") + @"',
                                        `Petty_Cash_Book_Max_Amount` = '" + Convert.ToDouble(PCB_Max_Amount.Text) + @"',
                                        `Available_Balance_Amount` = '" + Convert.ToDouble(PCB_Available_Balance_Amount.Text) + @"',
                                        `Petty_Cash_Book_Remark` = '" + PCB_Remark.Text.Trim().Replace("'", "''") + @"',
                                        `Edited_Date` = now()
                                        WHERE `Id_Petty_Cash_Book` = '" + Convert.ToInt32(HiddenField1.Value) + @"';
                                        ");
                    //ScriptManager.RegisterStartupScript(this, GetType(), "AlertSweet", "alertSweet4();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "update", "showAlert('success');", true);
                    cmdSubmit.CommandName = "SAVE";
                    cmdSubmit.Text = "Save";
                }
            }
            ClearFeilds();
            RetrievePCBDetails();
        }

        private void RetrievePCBDetails()
        {
            core_petty_cash_book pcbObj = new core_petty_cash_book();
            core_petty_cash_book_Objects ObjPCB = new core_petty_cash_book_Objects();
            DataSet ds = pcbObj.SelectMethod(@"SELECT  
PCB.Id_Petty_Cash_Book,
PCB.Petty_Cash_Book_Name, 
PCB.Petty_Cash_Book_Code, 
PCB.Petty_Cash_Book_Max_Amount, 
PCB.Available_Balance_Amount, 
PCB.Petty_Cash_Book_Remark,
PCB.Created_Date, 
PCB.Created_User, 
PCB.Edited_Date, 
PCB.Edited_User, 
PCB.Is_Active
FROM core_petty_cash_book as PCB WHERE PCB.Is_Active='0';", "core_petty_cash_book");
            GridView1.DataSource = ds.Tables["core_petty_cash_book"];
            GridView1.DataBind();

        }

        private void ClearFeilds()
        {
            PCB_Name.Text = "";
            PCB_Code.Text = "";
            PCB_Max_Amount.Text = "";
            PCB_Available_Balance_Amount.Text = "";
            PCB_Remark.Text = "";
            HiddenField1.Value = "";
            hfAvailableBalance.Value = "";

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IdPCB = Convert.ToInt32(GridView1.DataKeys[GridView1.SelectedIndex].Values["Id_Petty_Cash_Book"].ToString());
            GridViewRow row = GridView1.SelectedRow;
            PCB_Name.Text = System.Net.WebUtility.HtmlDecode(row.Cells[0].Text);
            PCB_Code.Text = System.Net.WebUtility.HtmlDecode(row.Cells[1].Text);
            PCB_Max_Amount.Text = System.Net.WebUtility.HtmlDecode(row.Cells[2].Text);
            PCB_Available_Balance_Amount.Text = System.Net.WebUtility.HtmlDecode(row.Cells[3].Text);
            PCB_Remark.Text = System.Net.WebUtility.HtmlDecode(row.Cells[4].Text);
            HiddenField1.Value = IdPCB.ToString();

            cmdSubmit.CommandName = "UPDATE";
            cmdSubmit.Text = "Update";
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Delete"))
            {
                try
                {
                    LinkButton LB = (LinkButton)e.CommandSource;
                    GridViewRow GVRow = (GridViewRow)LB.Parent.Parent;
                    GridView GV = (GridView)sender;
                    string PCBid = GV.DataKeys[GVRow.RowIndex]["Id_Petty_Cash_Book"].ToString();
                    HiddenField1.Value = PCBid.ToString();

                    var PCB = new core_petty_cash_book();
                    PCB.UpdateMethod(@"UPDATE `core_petty_cash_book`
                                        SET
                                        `Is_Active` = 1,
                                        `Edited_Date` = now()
                                        WHERE `Id_Petty_Cash_Book` = '" + Convert.ToInt32(HiddenField1.Value) + @"';");
                    //ScriptManager.RegisterStartupScript(this, GetType(), "AlertSweet", "alertSweet3();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "delete", "showAlert('success');", true);
                }
                catch (Exception ex)
                {
                    Exception E = ex;
                }

                RetrievePCBDetails();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void cmdClear_Click(object sender, EventArgs e)
        {
            ClearFeilds();
        }

        protected void cvPCB_Name_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                if (cmdSubmit.CommandName.ToLower() == "SAVE".ToLower())
                {
                    DataView dv;
                    core_petty_cash_category pccObj = new core_petty_cash_category();

                    DataSet ds = pccObj.SelectMethod(@"SELECT PCB.Petty_Cash_Book_Name FROM core_petty_cash_book AS PCB WHERE PCB.Is_Active='0';", "core_petty_cash_book");
                    dv = ds.Tables["core_petty_cash_book"].DefaultView;
                    string pcbn;
                    args.IsValid = true;
                    // Loop through table and compare each record against user's entry
                    foreach (DataRowView datarow in dv)
                    {
                        // Extract e-mail address from the current row
                        //txtEmail = datarow["Alias "].ToString();
                        pcbn = datarow["Petty_Cash_Book_Name"].ToString();

                        // Compare e-mail address against user's entry
                        if (pcbn == args.Value)
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

        protected void cvPCB_Code_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                if (cmdSubmit.CommandName.ToLower() == "SAVE".ToLower())
                {
                    DataView dv;
                    core_petty_cash_category pccObj = new core_petty_cash_category();

                    //DataSet dataSet11 = new DataSet();
                    DataSet ds = pccObj.SelectMethod(@"SELECT PCB.Petty_Cash_Book_Code FROM core_petty_cash_book AS PCB WHERE PCB.Is_Active='0';", "core_petty_cash_book");
                    dv = ds.Tables["core_petty_cash_book"].DefaultView;
                    string pcbc;
                    args.IsValid = true;
                    // Loop through table and compare each record against user's entry
                    foreach (DataRowView datarow in dv)
                    {
                        // Extract e-mail address from the current row
                        //txtEmail = datarow["Alias "].ToString();
                        pcbc = datarow["Petty_Cash_Book_Code"].ToString();

                        // Compare e-mail address against user's entry
                        if (pcbc == args.Value)
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