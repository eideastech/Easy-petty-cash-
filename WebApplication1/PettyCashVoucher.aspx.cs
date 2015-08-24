using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DataProcess_PCMS;
using DataProcess_PCMS_Objects;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using WebApplication1.Reports; 


namespace WebApplication1
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadDDL();
                loadPCBAvailableBalance();
                //loadGrid();
                //getReport();
                loadNextPCVid();
            }
        }
        protected void loadDDL()
        {
            loadPCBDDL();           
            loadPCCDDL();
            
        }

        protected void Page_Init(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                getReport();
            }

            else
            {
                ReportDocument doc = (ReportDocument)Session["ReportDocument"];
                crvPettyCashVoucherReport.ReportSource = doc;
                crvPettyCashVoucherReport.DataBind();
            }

        }


        private void loadPCBDDL()
        {
            core_petty_cash_book objPCB=new core_petty_cash_book();
            DataSet ds = objPCB.SelectMethod(@"SELECT PCB.Id_Petty_Cash_Book,PCB.Petty_Cash_Book_Name,PCB.Petty_Cash_Book_Code FROM core_petty_cash_book AS PCB WHERE PCB.Is_Active='0';", "core_petty_cash_book");
            DataRow dr = ds.Tables["core_petty_cash_book"].NewRow();
            dr[0] = "0";
            dr[1] = "Select";
            dr[2] = "Select";
            ds.Tables["core_petty_cash_book"].Rows.InsertAt(dr, 0);

            ddlPCBName.DataSource=ds.Tables["core_petty_cash_book"];
            ddlPCBName.DataValueField="Id_Petty_Cash_Book";
            ddlPCBName.DataTextField="Petty_Cash_Book_Name";
            ddlPCBName.DataBind();

            ddlPCBCode.DataSource = ds.Tables["core_petty_cash_book"];
            ddlPCBCode.DataValueField = "Id_Petty_Cash_Book";
            ddlPCBCode.DataTextField = "Petty_Cash_Book_Code";
            ddlPCBCode.DataBind();
        }

        private void loadPCCDDL()
        {
            core_petty_cash_category objPCB=new core_petty_cash_category();
            DataSet ds = objPCB.SelectMethod(@"SELECT PCC.Id_Petty_Cash_Category,PCC.Petty_Cash_Category_Name,PCC.Petty_Cash_Category_Code FROM core_petty_cash_category AS PCC WHERE PCC.Is_Active='0';", "core_petty_cash_category");
            DataRow dr = ds.Tables["core_petty_cash_category"].NewRow();
            dr[0] = "0";
            dr[1] = "Select";
            dr[2] = "Select";
            ds.Tables["core_petty_cash_category"].Rows.InsertAt(dr, 0);

            ddlPCCName.DataSource=ds.Tables["core_petty_cash_category"];
            ddlPCCName.DataValueField = "Id_Petty_Cash_Category";
            ddlPCCName.DataTextField = "Petty_Cash_Category_Name";
            ddlPCCName.DataBind();

            ddlPCCCode.DataSource = ds.Tables["core_petty_cash_category"];
            ddlPCCCode.DataValueField = "Id_Petty_Cash_Category";
            ddlPCCCode.DataTextField = "Petty_Cash_Category_Code";
            ddlPCCCode.DataBind();
        }

        private void loadNextPCVid()
        {
            core_petty_cash_payment_voucher pcvObj = new core_petty_cash_payment_voucher();
            DataSet ds = pcvObj.SelectMethod(@"SELECT
COUNT(pcv.Id_Petty_Cash_Voucher) AS count
FROM core_petty_cash_payment_voucher AS pcv;", "core_petty_cash_payment_voucher");
            string count = ds.Tables[0].Rows[0]["count"].ToString();
            int x=(Convert.ToInt32(count)+1);
            //PCV_Id.Text = x.ToString().PadLeft(4, '0');
            PCV_Id.Text = x.ToString();

        }
        private void loadLedgerAccountDetails()
        {
            core_petty_cash_category pccObj = new core_petty_cash_category();
            DataSet ds = pccObj.SelectMethod(@"SELECT 
pcc.Id_Petty_Cash_Category,
la.Id_Ledger_Account, 
la.Ledger_Account_Name, 
la.Balance_Carried_Forward
FROM core_petty_cash_category AS pcc
INNER JOIN core_ledger_account AS la ON la.Id_Ledger_Account=pcc.Id_Ledger_Account
WHERE pcc.Is_Active='0' AND pcc.Id_Petty_Cash_Category='" + ddlPCCName.SelectedValue + "' OR pcc.Id_Petty_Cash_Category='" + ddlPCCCode.SelectedValue + "';", "core_petty_cash_category");
            if (ds.Tables["core_petty_cash_category"] != null && ds.Tables["core_petty_cash_category"].Rows.Count > 0)
            {
                hfIDLedgerAccount.Value = ds.Tables["core_petty_cash_category"].Rows[0]["Id_Ledger_Account"].ToString();
                hfIDLedgerAccountBCF.Value = ds.Tables["core_petty_cash_category"].Rows[0]["Balance_Carried_Forward"].ToString();
            }               
            
        }

        protected void ddlPCBName_SelectedIndexChanged(object sender, EventArgs e)
        {          
            ddlPCBCode.SelectedValue = ddlPCBName.SelectedValue;
            loadPCBAvailableBalance();           
        }

        protected void ddlPCBCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPCBName.SelectedValue = ddlPCBCode.SelectedValue;
            loadPCBAvailableBalance(); 
        }

        protected void ddlPCCName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPCCCode.SelectedValue = ddlPCCName.SelectedValue;
            loadLedgerAccountDetails();
        }

        protected void ddlPCCCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPCCName.SelectedValue = ddlPCCCode.SelectedValue;
            loadLedgerAccountDetails();
        }

        private void loadPCBAvailableBalance()
        {
            core_petty_cash_book pcbObj = new core_petty_cash_book();
            DataSet ds = pcbObj.SelectMethod(@"SELECT 
pcb.Id_Petty_Cash_Book, 
pcb.Petty_Cash_Book_Name, 
pcb.Petty_Cash_Book_Code, 
pcb.Available_Balance_Amount
FROM core_petty_cash_book AS pcb
WHERE pcb.Is_Active='0' AND pcb.Id_Petty_Cash_Book='"+ddlPCBName.SelectedValue+"' OR pcb.Id_Petty_Cash_book='"+ddlPCBCode.SelectedValue+"';","core_petty_cash_book");
            if (ds.Tables["core_petty_cash_book"] != null && ds.Tables["core_petty_cash_book"].Rows.Count > 0)            
                PCBAvailableBalance.Text = ds.Tables["core_petty_cash_book"].Rows[0]["Available_Balance_Amount"].ToString();
            else
                PCBAvailableBalance.Text="0.00";
        }

        protected void cmdSubmit_Click(object sender, EventArgs e)
        {
            insertPCVDetails();
            //loadGrid();
            
            getReport();
            clearFields();
            loadNextPCVid();
        }
        private void insertPCVDetails()
        {

            int payment_Type;
            if (selectedPost.Selected == true)
            {
                payment_Type = 0;
            }
            else if (selectedPre.Selected == true)            
            {
                payment_Type = 1;
            }
            else
           {
                payment_Type = 2;
                MessageBox.Show("Error! Please Select a Payment Type");
                
            }

            if (cmdSubmit.CommandName.ToLower() == "SAVE".ToLower())
            {
                core_petty_cash_payment_voucher pcvObj = new core_petty_cash_payment_voucher();
                core_petty_cash_payment_voucher_Objects objPCV = new core_petty_cash_payment_voucher_Objects();
               
                objPCV.Id_Petty_Cash_Voucher = Convert.ToInt32(PCV_Id.Text);
                objPCV.Id_Petty_Cash_Book=Convert.ToInt32(ddlPCBName.SelectedValue);
                objPCV.Id_Petty_Cash_Category = Convert.ToInt32(ddlPCCName.SelectedValue);
 
                double result;
                if(double.TryParse(PCBAvailableBalance.Text,out result))                
                    objPCV.Available_Balance_Amount = Convert.ToDouble(PCBAvailableBalance.Text);
                                
                objPCV.Business_Purpose=businessPurpose.Text;
                objPCV.Cash_Out_Amount=Convert.ToDouble(cashOutAmount.Text);
                objPCV.Received_By=receivedBy.Text;
               
                objPCV.Petty_Cash_Voucher_Remark=PCV_Remark.Text;
                objPCV.Created_Date=DateTime.Now;
                objPCV.Edited_Date = DateTime.Now;
                objPCV.Post_Payment= payment_Type;
                pcvObj.Insert(objPCV);

            }
            if (cmdSubmit.CommandName.ToLower() == "SAVE".ToLower())
            {
                 double availableBalance;
                 double cashoutamount;
                 availableBalance = 0.00;
                 cashoutamount = 0.00;
                 availableBalance =Convert.ToDouble(PCBAvailableBalance.Text);
                 cashoutamount = Convert.ToDouble(cashOutAmount.Text.Trim());
                 double newAmount = Convert.ToDouble(availableBalance - cashoutamount);
              
                core_petty_cash_book pcbObj = new core_petty_cash_book();
                pcbObj.UpdateMethod(@"UPDATE `core_petty_cash_book`
                                        SET
                                        `Available_Balance_Amount` = '" + newAmount + @"'                                                                                                                                                            
                                        WHERE `Id_Petty_Cash_Book` = '" + Convert.ToInt32(ddlPCBName.SelectedValue) + @"';");
            }
            if (cmdSubmit.CommandName.ToLower() == "SAVE".ToLower())
            {
                core_ledger_entry leObj = new core_ledger_entry();
                core_ledger_entry_Objects objLE = new core_ledger_entry_Objects();
                
                objLE.Id_Petty_Cash_Book = Convert.ToInt32(ddlPCBName.SelectedValue);
                objLE.Id_Petty_Cash_Category = Convert.ToInt32(ddlPCCName.SelectedValue);
                objLE.Id_Ledger_Account = Convert.ToInt32(hfIDLedgerAccount.Value);
                objLE.Id_Petty_Cash_Voucher = Convert.ToInt32(PCV_Id.Text);
                objLE.Business_Purpose = businessPurpose.Text;
               
                //double x = Convert.ToDouble(hfIDLedgerAccountBCF.Value);
                //////
                double x = Convert.ToDouble(PCBAvailableBalance.Text);
                //////
                double y = Convert.ToDouble(cashOutAmount.Text);
                objLE.Debit_Amount = Convert.ToDouble(cashOutAmount.Text);
                objLE.Balance_Carried_Forward = (x-y);
                //double z = (x + y);
                                
                objLE.Created_Date = DateTime.Now;                
                objLE.Post_Payment = payment_Type;
                leObj.Insert(objLE);


                //core_ledger_account laObj = new core_ledger_account();
                //laObj.UpdateMethod(@"UPDATE `core_ledger_account`
                //                        SET
                //                        `Balance_Carried_Forward` = '" + z + @"'                                                                                                                                                            
                //                        WHERE `Id_Ledger_Account` = '" + Convert.ToInt32(hfIDLedgerAccount.Value) + @"';");
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "insert", "showAlert('success');", true);
            //this.clearFields();
            //loadGrid();
            //Response.Redirect("PettyCashVoucher.aspx", false);

        }
     /*   private void loadGrid()
        {
            core_petty_cash_payment_voucher pcvObj = new core_petty_cash_payment_voucher();
            DataSet ds = pcvObj.SelectMethod(@"SELECT 
pcv.Id_Petty_Cash_Voucher,
pcv.Id_Petty_Cash_Book,
pcb.Petty_Cash_Book_Name,
pcb.Petty_Cash_Book_Code,
pcb.Available_Balance_Amount,
pcv.Id_Petty_Cash_Category,
pcc.Petty_Cash_Category_Name,
pcc.Petty_Cash_Category_Code,  
pcv.Cash_Out_Amount,
pcv.Business_Purpose,
pcv.Received_By,
pcv.Petty_Cash_Voucher_Remark,
pcv.Post_Payment,
CASE WHEN  pcv.Post_Payment=0 THEN 'Post-payment' ELSE 'Pre-payment' END AS Payment_Type,
pcv.Created_Date,
pcv.Created_User,
pcv.Edited_Date,
pcv.Edited_User
FROM core_petty_cash_payment_voucher AS pcv
INNER JOIN core_petty_cash_book AS pcb ON pcv.Id_Petty_Cash_Book=pcb.Id_Petty_Cash_Book
INNER JOIN core_petty_cash_category AS pcc ON pcv.Id_Petty_Cash_Category=pcc.Id_Petty_Cash_Category
WHERE pcv.Is_Active='0';", "core_petty_cash_payment_voucher");
            if (ds.Tables["core_petty_cash_payment_voucher"] != null)
            {
                GridView1.DataSource = ds.Tables["core_petty_cash_payment_voucher"];
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = new int[] { };
                GridView1.DataBind();
            }
        } */

        private void getReport()
        {
            PettyCashVoucherReport irpt = new PettyCashVoucherReport();
            if (IsPostBack)
            {
                TextObject pcvID = (TextObject)irpt.ReportDefinition.Sections["Section1"].ReportObjects["Text3"];
                TextObject cashoutamount = (TextObject)irpt.ReportDefinition.Sections["Section3"].ReportObjects["Text21"];
                TextObject receivedby = (TextObject)irpt.ReportDefinition.Sections["Section3"].ReportObjects["Text22"];
                TextObject paymentType = (TextObject)irpt.ReportDefinition.Sections["Section3"].ReportObjects["Text23"];
                TextObject businesssPurpose = (TextObject)irpt.ReportDefinition.Sections["Section3"].ReportObjects["Text24"];
                TextObject pcbName = (TextObject)irpt.ReportDefinition.Sections["Section3"].ReportObjects["Text25"];
                TextObject pcbCode = (TextObject)irpt.ReportDefinition.Sections["Section3"].ReportObjects["Text26"];
                TextObject pccName = (TextObject)irpt.ReportDefinition.Sections["Section3"].ReportObjects["Text27"];
                TextObject pccCode = (TextObject)irpt.ReportDefinition.Sections["Section3"].ReportObjects["Text28"];
                TextObject remark = (TextObject)irpt.ReportDefinition.Sections["Section3"].ReportObjects["Text29"];
                pcbName.Text = ddlPCBName.SelectedItem.Text;
                pcbCode.Text = ddlPCBCode.SelectedItem.Text;
                pccName.Text = ddlPCCName.SelectedItem.Text;
                pccCode.Text = ddlPCCCode.SelectedItem.Text;
                remark.Text = PCV_Remark.Text;
                pcvID.Text = PCV_Id.Text;
                cashoutamount.Text = cashOutAmount.Text;
                receivedby.Text = receivedBy.Text;
                paymentType.Text = RadioButtonList1.SelectedValue.ToString();
                businesssPurpose.Text = businessPurpose.Text;
            }


            // crvPettyCashVoucherReport.ReportSource = null;

            crvPettyCashVoucherReport.EnableDatabaseLogonPrompt = false;

            Session["ReportDocument"] = irpt;
            ReportDocument doc = (ReportDocument)Session["ReportDocument"];


            if (doc != null)
                crvPettyCashVoucherReport.ReportSource = doc;


            crvPettyCashVoucherReport.DataBind();
        }
        private void clearFields()
        {
            if (ddlPCBName.Items.Count > 0)
                ddlPCBName.SelectedIndex = 0;
            if (ddlPCBCode.Items.Count > 0)
                ddlPCBCode.SelectedIndex = 0;
            if (ddlPCCName.Items.Count > 0)
                ddlPCCName.SelectedIndex = 0;
            if (ddlPCCCode.Items.Count > 0)
                ddlPCCCode.SelectedIndex = 0;
            loadDDL();
            //loadGrid();
            PCBAvailableBalance.Text = "0.00";                       
            selectedPost.Selected = false;
            selectedPre.Selected = false;
            cashOutAmount.Text = "";
            receivedBy.Text = "";
            businessPurpose.Text = "";
            PCV_Remark.Text = "";
            hfIDLedgerAccount.Value = "";
            hfIDLedgerAccountBCF.Value = "";
            
        }

        protected void cmdClear_Click(object sender, EventArgs e)
        {
            this.clearFields();
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
                    string PCVid = GV.DataKeys[GVRow.RowIndex]["Id_Petty_Cash_Voucher"].ToString();
                    HiddenField1.Value = PCVid.ToString();

                    var PCB = new core_petty_cash_book();
                    PCB.UpdateMethod(@"UPDATE `core_petty_cash_payment_voucher`
                                        SET
                                        `Is_Active` = 1,
                                        `Edited_Date` = now()
                                        WHERE `Id_Petty_Cash_Voucher` = '" + Convert.ToInt32(HiddenField1.Value) + @"';");
                    ScriptManager.RegisterStartupScript(this, GetType(), "delete", "showAlert('success');", true);
                }
                catch (Exception ex)
                {
                    Exception E = ex;
                }

                //loadGrid();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}