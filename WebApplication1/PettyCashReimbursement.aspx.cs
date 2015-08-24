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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
                this.loadDDL();
                this.loadGrid();
                bcf.Attributes.Add("readonly", "readonly");
                
            }
            //clearFields();

        }
        private void loadDDL()
        {
            core_petty_cash_book objPCB = new core_petty_cash_book();
            DataSet ds = objPCB.SelectMethod(@"SELECT PCB.Id_Petty_Cash_Book,PCB.Petty_Cash_Book_Name,PCB.Petty_Cash_Book_Code FROM core_petty_cash_book AS PCB WHERE PCB.Is_Active='0';", "core_petty_cash_book");
            DataRow dr = ds.Tables["core_petty_cash_book"].NewRow();
            dr[0] = "0";
            dr[1] = "Select";
            dr[2] = "Select";
            ds.Tables["core_petty_cash_book"].Rows.InsertAt(dr, 0);

            ddlPCBName.DataSource = ds.Tables["core_petty_cash_book"];
            ddlPCBName.DataValueField = "Id_Petty_Cash_Book";
            ddlPCBName.DataTextField = "Petty_Cash_Book_Name";
            ddlPCBName.DataBind();

            ddlPCBCode.DataSource = ds.Tables["core_petty_cash_book"];
            ddlPCBCode.DataValueField = "Id_Petty_Cash_Book";
            ddlPCBCode.DataTextField = "Petty_Cash_Book_Code";
            ddlPCBCode.DataBind();
            
        }
              
        protected void ddlPCBName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPCBCode.SelectedValue = ddlPCBName.SelectedValue;
            loadAvailableBalance();
            loadMaxAmount();
            calAmountToBeReimbursed();
            hfPCBID.Value = ddlPCBName.SelectedValue;
        }

        protected void ddlPCBCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPCBName.SelectedValue = ddlPCBCode.SelectedValue;
            loadAvailableBalance();
            loadMaxAmount();
            calAmountToBeReimbursed();
        }

        private void loadAvailableBalance()
        {
            core_petty_cash_book pcbObj = new core_petty_cash_book();
            DataSet ds = pcbObj.SelectMethod(@"SELECT 
pcb.Id_Petty_Cash_Book,  
pcb.Available_Balance_Amount
FROM core_petty_cash_book AS pcb
WHERE pcb.Is_Active='0' AND pcb.Id_Petty_Cash_Book='" + ddlPCBName.SelectedValue + "' OR pcb.Id_Petty_Cash_book='" + ddlPCBCode.SelectedValue + "';", "core_petty_cash_book");
            if (ds.Tables["core_petty_cash_book"] != null && ds.Tables["core_petty_cash_book"].Rows.Count > 0)
                PCBAvailableBalance.Text = ds.Tables["core_petty_cash_book"].Rows[0]["Available_Balance_Amount"].ToString();
            else 
            {
                PCBAvailableBalance.Text = "";
                //AmountToBeReimbursed.Text = "0.00";
            }
                          
        }
        private void loadMaxAmount()
        {
            core_petty_cash_book pcbObj = new core_petty_cash_book();
            DataSet ds = pcbObj.SelectMethod(@"SELECT 
pcb.Id_Petty_Cash_Book,  
pcb.Petty_Cash_Book_Max_Amount
FROM core_petty_cash_book AS pcb
WHERE pcb.Is_Active='0' AND pcb.Id_Petty_Cash_Book='" + ddlPCBName.SelectedValue + "' OR pcb.Id_Petty_Cash_book='" + ddlPCBCode.SelectedValue + "';", "core_petty_cash_book");
            if (ds.Tables["core_petty_cash_book"] != null && ds.Tables["core_petty_cash_book"].Rows.Count > 0)
                PCBMaxAmount.Text = ds.Tables["core_petty_cash_book"].Rows[0]["Petty_Cash_Book_Max_Amount"].ToString();
            else
            {
                PCBMaxAmount.Text = "";
                //AmountToBeReimbursed.Text = "0.00";
            }                
        }

        private void calAmountToBeReimbursed()
        {
            //if (cmdClear.CommandName.ToLower() != "CLEAR".ToLower())
            //{
                double availableBalance = 0.00;
                double maxAmount = 0.00;
                double amountToBeReimbursed = 0.00;
                availableBalance = Convert.ToDouble(PCBAvailableBalance.Text.Trim());
                maxAmount = Convert.ToDouble(PCBMaxAmount.Text.Trim());
                amountToBeReimbursed = Convert.ToDouble(maxAmount - availableBalance);
                AmountToBeReimbursed.Text = amountToBeReimbursed.ToString();

                //if (maxAmount != null)
                AmountToBeReimbursed.Text = amountToBeReimbursed.ToString();
                //else 
                //AmountToBeReimbursed.Text = "";
            //}     
                     
        }

        //protected void reimburseAmount_TextChanged(object sender, EventArgs e)
        //{
        //    hfReimburseAmount.Value = reimburseAmount.Text.Trim();

        //    if (!((hfReimburseAmount.Value) == null || (hfReimburseAmount.Value) == ""))
        //    {
        //        double availableBalance = 0.00;
        //        double reimbursedAmount = 0.00;
        //        double amountToBeReimbursed = 0.00;
        //        availableBalance = Convert.ToDouble(PCBAvailableBalance.Text.Trim());
        //        reimbursedAmount = Convert.ToDouble(hfReimburseAmount.Value);
        //        amountToBeReimbursed = Convert.ToDouble(AmountToBeReimbursed.Text.Trim());
        //        if (amountToBeReimbursed >= reimbursedAmount)
        //            bcf.Text = (availableBalance + reimbursedAmount).ToString();
        //        //else
        //        //    Message.Text = "You can not Reimburse an amount which will result exceed the Float amount";
        //        //has to get the Msgbox.dll
        //    }
        //    else
        //        bcf.Text = "";
            
        //}

        protected void cmdSubmit_Click(object sender, EventArgs e)
        {
            hfReimburseAmount.Value = reimburseAmount.Text.Trim();
            if (!((hfReimburseAmount.Value) == null || (hfReimburseAmount.Value) == ""))
            {
                double reimbursedAmount = 0.00;
                double amountToBeReimbursed = 0.00;
                double balanceCarriedForward = 0.00;
                reimbursedAmount = Convert.ToDouble(hfReimburseAmount.Value);
                amountToBeReimbursed = Convert.ToDouble(AmountToBeReimbursed.Text.Trim());
                balanceCarriedForward = Convert.ToDouble(PCBAvailableBalance.Text.Trim()) + reimbursedAmount;
                hfBCF.Value=balanceCarriedForward.ToString();
                if (Page.IsPostBack)
                {
                    //insertPCRDetails();
                    if (cmdSubmit.CommandName.ToLower() == "SAVE".ToLower())
                    {
                        core_petty_cash_reimbursement pcrObj = new core_petty_cash_reimbursement();
                        core_petty_cash_reimbursement_Objects objPCR = new core_petty_cash_reimbursement_Objects();

                        objPCR.Id_Petty_Cash_Book = Convert.ToInt32(ddlPCBName.SelectedValue);
                        objPCR.Amount_ThatShouldBe_Reimbursed = Convert.ToDouble(AmountToBeReimbursed.Text.Trim());
                        objPCR.Reimbursement_Amount = Convert.ToDouble(reimburseAmount.Text.Trim());
                        objPCR.Balance_Carried_Forward = Convert.ToDouble(hfBCF.Value);
                        objPCR.Petty_Cash_Reimbursement_Remark = PCR_Remark.Text.Trim();
                        objPCR.Created_Date = DateTime.Now;
                        pcrObj.Insert(objPCR);
                        ScriptManager.RegisterStartupScript(this, GetType(), "insert", "showAlert('success');", true);
                    }
                    /////// added code below
                    if (cmdSubmit.CommandName.ToLower() == "SAVE".ToLower())
                    {
                        core_ledger_entry leObj = new core_ledger_entry();
                        core_ledger_entry_Objects objLE = new core_ledger_entry_Objects();

                        objLE.Id_Petty_Cash_Book = Convert.ToInt32(ddlPCBName.SelectedValue);
                        objLE.Id_Petty_Cash_Category = 42;
                        objLE.Id_Ledger_Account = 6;
                        //objLE.Id_Petty_Cash_Voucher = 0;
                        objLE.Business_Purpose = "Reimbursement";
                        
                        //double x = Convert.ToDouble(hfIDLedgerAccountBCF.Value);
                        //double y = Convert.ToDouble(cashOutAmount.Text);
                        objLE.Credit_Amount = Convert.ToDouble(reimburseAmount.Text.Trim());
                        objLE.Balance_Carried_Forward = Convert.ToDouble(hfBCF.Value);
                        //double z = (x + y);

                        objLE.Created_Date = DateTime.Now;
                        //objLE.Post_Payment = payment_Type;
                        leObj.Insert(objLE);
                    }
                    //////////
                    /*if (cmdSubmit.CommandName.ToLower() == "SAVE".ToLower())
                    {
                        core_petty_cash_payment_voucher pcvObj = new core_petty_cash_payment_voucher();
                        core_petty_cash_payment_voucher_Objects objPCV = new core_petty_cash_payment_voucher_Objects();

                        //objPCV.Id_Petty_Cash_Voucher = Convert.ToInt32(PCV_Id.Text);
                        objPCV.Id_Petty_Cash_Book = Convert.ToInt32(ddlPCBName.SelectedValue);
                        objPCV.Id_Petty_Cash_Category = 42;

                        double result;
                        if (double.TryParse(PCBAvailableBalance.Text, out result))
                            objPCV.Available_Balance_Amount = Convert.ToDouble(PCBAvailableBalance.Text);

                        objPCV.Business_Purpose = "Reimbursement";
                        //objPCV.Cash_Out_Amount = Convert.ToDouble(cashOutAmount.Text);
                        objPCV.Received_By = "Shan";

                        //objPCV.Petty_Cash_Voucher_Remark = PCV_Remark.Text;
                        objPCV.Created_Date = DateTime.Now;
                        objPCV.Edited_Date = DateTime.Now;
                        //objPCV.Post_Payment = payment_Type;
                        objPCV.Is_Active = 1;
                        pcvObj.Insert(objPCV);

                    }*/
                    //////////
                    /////// added code ends
                   
                    //updatePCBTable();
                    core_petty_cash_book pcbObj = new core_petty_cash_book();
                    pcbObj.UpdateMethod(@"UPDATE `core_petty_cash_book` SET `Available_Balance_Amount` = '" + Convert.ToDouble(hfBCF.Value) + @"' WHERE `Id_Petty_Cash_Book` = '" + Convert.ToInt32(ddlPCBName.SelectedValue) + @"' AND `Is_Active` = '0';");
                    clearFields(); 
                    Response.Redirect("PettyCashReimbursement.aspx", false);
                }
                
            }
            else
            {
                //Message.Text
            }
            clearFields();
            loadGrid();
            
        }

    /*    private void insertPCRDetails()
        {

            if (cmdSubmit.CommandName.ToLower() == "SAVE".ToLower())
            {
                core_petty_cash_reimbursement pcrObj = new core_petty_cash_reimbursement();
                core_petty_cash_reimbursement_Objects objPCR = new core_petty_cash_reimbursement_Objects();

                objPCR.Id_Petty_Cash_Book = Convert.ToInt32(ddlPCBName.SelectedValue);
                objPCR.Amount_ThatShouldBe_Reimbursed = Convert.ToDouble(AmountToBeReimbursed.Text.Trim());
                objPCR.Reimbursement_Amount = Convert.ToDouble(reimburseAmount.Text.Trim());
                objPCR.Balance_Carried_Forward = Convert.ToDouble(hfBCF.Value);
                objPCR.Petty_Cash_Reimbursement_Remark = PCR_Remark.Text.Trim();
                objPCR.Created_Date = DateTime.Now;
                pcrObj.Insert(objPCR);
                ScriptManager.RegisterStartupScript(this, GetType(), "insert", "showAlert('success');", true);
            }
            clearFields();                       
        } */

        //private void updatePCBTable()
        //{                                       
            ////if (!((hfPCBID.Value) == null || (hfPCBID.Value) == ""))
            ////{
                //core_petty_cash_book pcbObj = new core_petty_cash_book();
                //pcbObj.UpdateMethod(@"UPDATE `core_petty_cash_book` SET `Available_Balance_Amount` = '" + Convert.ToDouble(hfBCF.Value) + @"' WHERE `Id_Petty_Cash_Book` = '" +  Convert.ToInt32(ddlPCBName.SelectedValue) + @"' AND `Is_Active` = '0';");
                
            //}            
        //}

        private void clearFields()
        {
            if (ddlPCBName.Items.Count > 0)
                ddlPCBName.SelectedIndex = 0;
            if (ddlPCBCode.Items.Count > 0)
                ddlPCBCode.SelectedIndex = 0;           
            loadDDL();
            loadGrid();
            PCBAvailableBalance.Text = "";
            PCBMaxAmount.Text = "";
            AmountToBeReimbursed.Text = "";
            reimburseAmount.Text = "";
            bcf.Text = "";
            PCR_Remark.Text = "";
            hfPCBID.Value = "";
            hfReimburseAmount.Value = "";
            hfBCF.Value = "";
        }

        protected void cmdClear_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void loadGrid()
        {
            core_petty_cash_reimbursement pcrObj = new core_petty_cash_reimbursement();
            DataSet ds = pcrObj.SelectMethod(@"SELECT 
pcr.Id_Petty_Cash_Reimbursement,
pcr.Id_Petty_Cash_Book,
pcb.Petty_Cash_Book_Name,
pcb.Petty_Cash_Book_Code,
pcb.Petty_Cash_Book_Max_Amount,
pcr.Amount_ThatShouldBe_Reimbursed,
pcr.Reimbursement_Amount,
pcr.Balance_Carried_Forward,
pcr.Petty_Cash_Reimbursement_Remark,
pcr.Created_Date,
pcr.Created_User,
pcr.Edited_Date,
pcr.Edited_User
FROM core_petty_cash_reimbursement AS pcr
INNER JOIN core_petty_cash_book AS pcb ON pcr.Id_Petty_Cash_Book=pcb.Id_Petty_Cash_Book
WHERE pcr.Is_Active='0' AND pcb.Is_Active='0';", "core_petty_cash_reimbursement");
            if (ds.Tables["core_petty_cash_reimbursement"] != null)
            {
                pcrGrid.DataSource = ds.Tables["core_petty_cash_reimbursement"];
                pcrGrid.DataBind();
            }
            else
            {
                pcrGrid.DataSource = new int[] { };
                pcrGrid.DataBind();
            }

        }
       
    }
}