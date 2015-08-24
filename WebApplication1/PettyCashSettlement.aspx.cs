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
    public partial class WebForm7 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadGrid();
                netcashOutAmount.Attributes.Add("readonly", "readonly");
            }
            //idPrePV.Focus();


            //if (IsPostBack)
            //{
            //    var fieldSelectedName = hdnSelectedField.Value;
            //    if (!String.IsNullOrEmpty(fieldSelectedName))
            //        Page.FindControl(fieldSelectedName).Focus();
            //}

        }

        protected void idPrePV_TextChanged(object sender, EventArgs e)
        {
            //if (!IsCallback)
            //{
            //hfVoucherID.Value = idPrePV.Text.Trim();                
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
pcc.Id_Ledger_Account,
la.Balance_Carried_Forward,
pcv.Cash_Out_Amount,
pcv.Business_Purpose,
pcv.Received_By,
pcv.Petty_Cash_Voucher_Remark,
pcv.Post_Payment,
pcv.Created_Date,
pcv.Created_User,
pcv.Edited_Date,
pcv.Edited_User
FROM core_petty_cash_payment_voucher AS pcv
INNER JOIN core_petty_cash_book AS pcb ON pcv.Id_Petty_Cash_Book=pcb.Id_Petty_Cash_Book
INNER JOIN core_petty_cash_category AS pcc ON pcv.Id_Petty_Cash_Category=pcc.Id_Petty_Cash_Category
INNER JOIN core_ledger_account AS la ON pcc.Id_Ledger_Account=la.Id_Ledger_Account
WHERE pcv.Id_Petty_Cash_Voucher='" + Convert.ToInt32(hfVoucherID.Value) + @"' AND pcv.Is_Active='0' AND pcv.Post_Payment='1';", "core_petty_cash_payment_voucher");
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    hfPCBID.Value = ds.Tables[0].Rows[0]["Id_Petty_Cash_Book"].ToString();
                    ddlPCBName.Text = ds.Tables[0].Rows[0]["Petty_Cash_Book_Name"].ToString();
                    ddlPCBCode.Text = ds.Tables[0].Rows[0]["Petty_Cash_Book_Code"].ToString();
                    PCBAvailableBalance.Text = ds.Tables[0].Rows[0]["Available_Balance_Amount"].ToString();
                    hfPCCID.Value = ds.Tables[0].Rows[0]["Id_Petty_Cash_Category"].ToString();
                    ddlPCCName.Text = ds.Tables[0].Rows[0]["Petty_Cash_Category_Name"].ToString();
                    ddlPCCCode.Text = ds.Tables[0].Rows[0]["Petty_Cash_Category_Code"].ToString();

                    hfIDLedgerAccount.Value = ds.Tables[0].Rows[0]["Id_Ledger_Account"].ToString();
                    hfIDLedgerAccountBCF.Value = ds.Tables[0].Rows[0]["Balance_Carried_Forward"].ToString();

                    cashOutAmount.Text = ds.Tables[0].Rows[0]["Cash_Out_Amount"].ToString();
                    receivedBy.Text = ds.Tables[0].Rows[0]["Received_By"].ToString();
                    businessPurpose.Text = ds.Tables[0].Rows[0]["Business_Purpose"].ToString();
                    PCV_Remark.Text = ds.Tables[0].Rows[0]["Petty_Cash_Voucher_Remark"].ToString();
                }
                else
                {
                    ddlPCBName.Text = "";
                    ddlPCBCode.Text = "";
                    PCBAvailableBalance.Text = "";
                    ddlPCCName.Text = "";
                    ddlPCCCode.Text = "";
                    cashOutAmount.Text = "";
                    receivedBy.Text = "";
                    cashInAmount.Text = "";
                    netcashOutAmount.Text = "";
                    businessPurpose.Text = "";
                    PCV_Remark.Text = "";
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            

        }

        protected void cmdSubmit_Click(object sender, EventArgs e)
        {
            updatePCVTable();
            updatePCBTable();
            insertUpdatedVoucherDetails();
            //insertLedgerEntry();
        }



        private void updatePCVTable()
        {
            if (!((hfVoucherID.Value) == null || (hfVoucherID.Value) == ""))
            {
                //String.IsNullOrEmpty(txtRefCode.Text.Trim()) ? "0" : txtRefCode.Text.Trim();
                businessPurpose.Text = String.IsNullOrEmpty(businessPurpose.Text.Trim()) ? "\u00A0" : businessPurpose.Text.Trim();
                PCV_Remark.Text = String.IsNullOrEmpty(PCV_Remark.Text.Trim()) ? "\u00A0" : PCV_Remark.Text.Trim();
                core_petty_cash_payment_voucher pcvObj = new core_petty_cash_payment_voucher();
                pcvObj.UpdateMethod(@"UPDATE `core_petty_cash_payment_voucher` SET `Cash_Out_Amount` = '" + Convert.ToDouble(hfnetcashOutAmount.Value) + @"', `Business_Purpose` = '" + businessPurpose.Text.Trim().Replace("'", "''") + @"', `Petty_Cash_Voucher_Remark` = '" + PCV_Remark.Text.Trim().Replace("'", "''") + @"', `Edited_Date` = now() WHERE `Id_Petty_Cash_Voucher` = '" + Convert.ToInt32(hfVoucherID.Value) + @"' AND `Is_Active` = '0' AND `Post_Payment` = '1';");
            }
        }


        private void updatePCBTable()
        {
            if (!((hfPCBID.Value) == null || (hfPCBID.Value) == ""))
            {
                core_petty_cash_book pcbObj = new core_petty_cash_book();
                pcbObj.UpdateMethod(@"UPDATE `core_petty_cash_book` SET `Available_Balance_Amount` = '" + Convert.ToDouble(hfUpdatedAV.Value) + @"' WHERE `Id_Petty_Cash_Book` = '" + Convert.ToInt32(hfPCBID.Value) + @"';");
            }
        }

        protected void cashInAmount_TextChanged(object sender, EventArgs e)
        {

            double availableBalance = 0.00;
            double cashinamount = 0.00;
            double cashoutamount = 0.00;
            availableBalance = Convert.ToDouble(PCBAvailableBalance.Text);
            cashoutamount = Convert.ToDouble(cashOutAmount.Text);
            cashinamount = Convert.ToDouble(cashInAmount.Text.Trim());
            double updatedAV = Convert.ToDouble(availableBalance + cashinamount);
            hfUpdatedAV.Value = updatedAV.ToString();
            double netCashOut = Convert.ToDouble(cashoutamount - cashinamount);
            //netcashOutAmount.Text = netCashOut.ToString();
        }

        private void insertUpdatedVoucherDetails()
        {
            if (cmdSubmit.CommandName.ToLower() == "SAVE".ToLower())
            {
                core_petty_cash_settlement pcvsObj = new core_petty_cash_settlement();
                core_petty_cash_settlement_Objects objPCVS = new core_petty_cash_settlement_Objects();
                objPCVS.Id_Petty_Cash_Voucher = Convert.ToInt32(idPrePV.Text);
                //objPCVS.Id_Petty_Cash_Book = Convert.ToInt32(ddlPCBName.Text);
                objPCVS.Id_Petty_Cash_Book = Convert.ToInt32(hfPCBID.Value);
                //objPCVS.Id_Petty_Cash_Category = Convert.ToInt32(ddlPCCName.Text);
                objPCVS.Id_Petty_Cash_Category = Convert.ToInt32(hfPCCID.Value);
                objPCVS.Cash_Out_Amount = Convert.ToDouble(cashOutAmount.Text);
                objPCVS.Cash_In_Amount = Convert.ToDouble(cashInAmount.Text);
                objPCVS.Net_Cash_Out_Amount = Convert.ToDouble(hfnetcashOutAmount.Value);
                objPCVS.Petty_Cash_Voucher_Remark = PCV_Remark.Text;
                objPCVS.Created_Date = DateTime.Now;
                pcvsObj.Insert(objPCVS);


                //Inserting Ledger Entry & Updating Ledger Account BCF
                core_ledger_entry leObj = new core_ledger_entry();
                core_ledger_entry_Objects objLE = new core_ledger_entry_Objects();

                objLE.Id_Petty_Cash_Book = Convert.ToInt32(hfPCBID.Value);
                objLE.Id_Petty_Cash_Category = Convert.ToInt32(hfPCCID.Value);
                objLE.Id_Ledger_Account = Convert.ToInt32(hfIDLedgerAccount.Value);
                objLE.Id_Petty_Cash_Voucher = Convert.ToInt32(idPrePV.Text);

                double x = Convert.ToDouble(hfIDLedgerAccountBCF.Value);
                double y = Convert.ToDouble(cashInAmount.Text);
                objLE.Credit_Amount = Convert.ToDouble(cashInAmount.Text);
                objLE.Balance_Carried_Forward = (x - y);
                double z = (x - y);

                objLE.Created_Date = DateTime.Now;
                objLE.Post_Payment = 1;
                leObj.Insert(objLE);


                core_ledger_account laObj = new core_ledger_account();
                laObj.UpdateMethod(@"UPDATE `core_ledger_account`
                                        SET
                                        `Balance_Carried_Forward` = '" + z + @"'                                                                                                                                                            
                                        WHERE `Id_Ledger_Account` = '" + Convert.ToInt32(hfIDLedgerAccount.Value) + @"';");
            }

            clearFields();
            loadGrid();
        }

        //        private void insertLedgerEntry()
        //        {
        //            if (cmdSubmit.CommandName.ToLower() == "SAVE".ToLower())
        //            {
        //                core_ledger_entry leObj = new core_ledger_entry();
        //                core_ledger_entry_Objects objLE = new core_ledger_entry_Objects();

        //                objLE.Id_Petty_Cash_Book = Convert.ToInt32(hfPCBID.Value);
        //                objLE.Id_Petty_Cash_Category = Convert.ToInt32(hfPCCID.Value);
        //                objLE.Id_Ledger_Account = Convert.ToInt32(hfIDLedgerAccount.Value);
        //                objLE.Id_Petty_Cash_Voucher = Convert.ToInt32(idPrePV.Text);

        //                double x = Convert.ToDouble(hfIDLedgerAccountBCF.Value);
        //                double y = Convert.ToDouble(cashInAmount.Text);
        //                objLE.Credit_Amount = Convert.ToDouble(cashInAmount.Text);
        //                objLE.Balance_Carried_Forward = (x - y);
        //                double z = (x - y);

        //                objLE.Created_Date = DateTime.Now;
        //                objLE.Post_Payment = 1;
        //                leObj.Insert(objLE);


        //                core_ledger_account laObj = new core_ledger_account();
        //                laObj.UpdateMethod(@"UPDATE `core_ledger_account`
        //                                        SET
        //                                        `Balance_Carried_Forward` = '" + z + @"'                                                                                                                                                            
        //                                        WHERE `Id_Ledger_Account` = '" + Convert.ToInt32(hfIDLedgerAccount.Value) + @"';");
        //            }
        //        }

        private void loadGrid()
        {
            core_petty_cash_settlement pcvsObj = new core_petty_cash_settlement();
            DataSet ds = pcvsObj.SelectMethod(@"SELECT 
pcvs.Id_Petty_Cash_Settlement,
pcvs.Id_Petty_Cash_Voucher,
pcvs.Id_Petty_Cash_Book,
pcb.Petty_Cash_Book_Name,
pcb.Petty_Cash_Book_Code,
pcvs.Id_Petty_Cash_Category,
pcc.Petty_Cash_Category_Name,
pcc.Petty_Cash_Category_Code,  
pcvs.Cash_Out_Amount,
pcvs.Cash_In_Amount,
pcvs.Net_Cash_Out_Amount,
pcvs.Petty_Cash_Voucher_Remark,
pcvs.Created_Date,
pcvs.Created_User,
pcvs.Edited_Date,
pcvs.Edited_User
FROM core_petty_cash_settlement AS pcvs
INNER JOIN core_petty_cash_book AS pcb ON pcvs.Id_Petty_Cash_Book=pcb.Id_Petty_Cash_Book
INNER JOIN core_petty_cash_category AS pcc ON pcvs.Id_Petty_Cash_Category=pcc.Id_Petty_Cash_Category
WHERE pcvs.Is_Active='0';", "core_petty_cash_settlement");
            if (ds.Tables["core_petty_cash_settlement"] != null)
            {
                pcvsGrid.DataSource = ds.Tables["core_petty_cash_settlement"];
                pcvsGrid.DataBind();
            }
            else
            {
                pcvsGrid.DataSource = new int[] { };
                pcvsGrid.DataBind();
            }
        }

        private void clearFields()
        {
            idPrePV.Text = "";
            ddlPCBName.Text = "";
            ddlPCBCode.Text = "";
            PCBAvailableBalance.Text = "";
            ddlPCCName.Text = "";
            ddlPCCCode.Text = "";
            cashOutAmount.Text = "";
            receivedBy.Text = "";
            cashInAmount.Text = "";
            netcashOutAmount.Text = "";
            businessPurpose.Text = "";
            PCV_Remark.Text = "";
            hfVoucherID.Value = null;
            hfPCBID.Value = null;
            hfUpdatedAV.Value = null;
            hfnetcashOutAmount.Value = null;

        }

        protected void cmdClear_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        protected void pcvsGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void pcvsGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void pcvsGrid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void searchID_Click(object sender, EventArgs e)
        {            
                hfVoucherID.Value = idPrePV.Text.Trim();
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
pcc.Id_Ledger_Account,
la.Balance_Carried_Forward,
pcv.Cash_Out_Amount,
pcv.Business_Purpose,
pcv.Received_By,
pcv.Petty_Cash_Voucher_Remark,
pcv.Post_Payment,
pcv.Created_Date,
pcv.Created_User,
pcv.Edited_Date,
pcv.Edited_User
FROM core_petty_cash_payment_voucher AS pcv
INNER JOIN core_petty_cash_book AS pcb ON pcv.Id_Petty_Cash_Book=pcb.Id_Petty_Cash_Book
INNER JOIN core_petty_cash_category AS pcc ON pcv.Id_Petty_Cash_Category=pcc.Id_Petty_Cash_Category
INNER JOIN core_ledger_account AS la ON pcc.Id_Ledger_Account=la.Id_Ledger_Account
WHERE pcv.Id_Petty_Cash_Voucher='" + Convert.ToInt32(hfVoucherID.Value) + @"' AND pcv.Is_Active='0' AND pcv.Post_Payment='1';", "core_petty_cash_payment_voucher");

            if (ds.Tables[0].Rows.Count == 0)
            {
                if (IsPostBack)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AlertSweet", "alertSweet();", true);
                    ddlPCBName.Text = "";
                    ddlPCBCode.Text = "";
                    PCBAvailableBalance.Text = "";
                    ddlPCCName.Text = "";
                    ddlPCCCode.Text = "";
                    cashOutAmount.Text = "";
                    receivedBy.Text = "";
                    cashInAmount.Text = "";
                    netcashOutAmount.Text = "";
                    businessPurpose.Text = "";
                    PCV_Remark.Text = "";
                }

            }
            else
            {
                try
                {
                    hfPCBID.Value = ds.Tables[0].Rows[0]["Id_Petty_Cash_Book"].ToString();
                    ddlPCBName.Text = ds.Tables[0].Rows[0]["Petty_Cash_Book_Name"].ToString();
                    ddlPCBCode.Text = ds.Tables[0].Rows[0]["Petty_Cash_Book_Code"].ToString();
                    PCBAvailableBalance.Text = ds.Tables[0].Rows[0]["Available_Balance_Amount"].ToString();
                    hfPCCID.Value = ds.Tables[0].Rows[0]["Id_Petty_Cash_Category"].ToString();
                    ddlPCCName.Text = ds.Tables[0].Rows[0]["Petty_Cash_Category_Name"].ToString();
                    ddlPCCCode.Text = ds.Tables[0].Rows[0]["Petty_Cash_Category_Code"].ToString();

                    hfIDLedgerAccount.Value = ds.Tables[0].Rows[0]["Id_Ledger_Account"].ToString();
                    hfIDLedgerAccountBCF.Value = ds.Tables[0].Rows[0]["Balance_Carried_Forward"].ToString();

                    cashOutAmount.Text = ds.Tables[0].Rows[0]["Cash_Out_Amount"].ToString();
                    receivedBy.Text = ds.Tables[0].Rows[0]["Received_By"].ToString();
                    businessPurpose.Text = ds.Tables[0].Rows[0]["Business_Purpose"].ToString();
                    PCV_Remark.Text = ds.Tables[0].Rows[0]["Petty_Cash_Voucher_Remark"].ToString();

                }
                catch
                {

                }
            }

            
        }
    }
}