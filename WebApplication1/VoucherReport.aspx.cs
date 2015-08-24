using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebApplication1.Reports;
using MySql.Data.MySqlClient;
using DataProcess_PCMS;
using DataProcess_PCMS_Objects;
using System.Globalization;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using ClassLibrary;

namespace WebApplication1
{
    public partial class VoucherReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadPCBDDL();
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //getReport();
            }

            else
            {
                ReportDocument doc = (ReportDocument)Session["ReportDocument"];
                crvVoucherReport.ReportSource = doc;
                crvVoucherReport.DataBind();
            }

        }
        private void loadPCBDDL()
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

     /*   private void getReport()
        {
            Common cm = new Common();
            core_ledger_entry dbAccess = new core_ledger_entry();
            DataSet ds = dbAccess.SelectMethod(@"SELECT 
le.Id_Ledger_Entry,
le.Id_Petty_Cash_Voucher,
pcv.Business_Purpose,
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
le.Post_Payment,
le.Created_Date,
le.Created_User,
le.Edited_Date,
le.Edited_User
FROM core_ledger_entry AS le
INNER JOIN core_petty_cash_payment_voucher AS pcv ON le.Id_Petty_Cash_Voucher=pcv.Id_Petty_Cash_Voucher
INNER JOIN core_petty_cash_book AS pcb ON le.Id_Petty_Cash_Book=pcb.Id_Petty_Cash_Book
INNER JOIN core_petty_cash_category AS pcc ON le.Id_Petty_Cash_Category=pcc.Id_Petty_Cash_Category
WHERE DATE(le.Created_Date) BETWEEN DATE('" + cm.convertToMySqlDate(fromDate.Text.Trim()) + "') and DATE('" + cm.convertToMySqlDate(toDate.Text.Trim()) + "');", "core_ledger_entry");

            CrystalReport1 irpt = new CrystalReport1();

            if (ds.Tables[0].Rows.Count == 0)
            {
                if (IsPostBack)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AlertSweet", "alertSweet();", true);
                    crvVoucherReport.ReportSource = null;
                    //ScriptManager.RegisterStartupScript(this, GetType(), "AlertSweet", "showAlert('error');", true);
                }
            }
            else
            {
                irpt.SetDataSource(ds.Tables["core_ledger_entry"]);
                crvVoucherReport.EnableDatabaseLogonPrompt = false;
                Session["ReportDocument"] = irpt;
                ReportDocument doc = (ReportDocument)Session["ReportDocument"];
                if (doc != null)
                    crvVoucherReport.ReportSource = doc;
                crvVoucherReport.DataBind();

            }

        } */

        private void getReport()
        {
            Common cm = new Common();
            core_ledger_entry obj = new core_ledger_entry();
            string sql = @"SELECT 
le.Id_Ledger_Entry,
le.Id_Petty_Cash_Voucher,
le.Business_Purpose,
le.Id_Petty_Cash_Book,
le.Id_Petty_Cash_Category,
pcc.Petty_Cash_Category_Name,
pcc.Petty_Cash_Category_Code,
le.Id_Ledger_Account,
le.Balance_Carried_Forward,
le.Debit_Amount,
le.Credit_Amount,
le.Post_Payment,
le.Created_Date
FROM core_ledger_entry AS le
INNER JOIN core_petty_cash_book AS pcb ON le.Id_Petty_Cash_Book=pcb.Id_Petty_Cash_Book
INNER JOIN core_petty_cash_category AS pcc ON le.Id_Petty_Cash_Category=pcc.Id_Petty_Cash_Category
WHERE le.Id_Petty_Cash_Book='" + Convert.ToInt32(ddlPCBName.SelectedValue) + @"'";
            if (cm.convertToMySqlDate(fromDate.Text.Trim())!=string.Empty)
            {
                sql = @"SELECT 
Id_Ledger_Entry,
'' AS Id_Petty_Cash_Voucher,
'Balance Carried Forward' AS Business_Purpose,
Id_Petty_Cash_Book,
'42' AS Id_Petty_Cash_Category,
'Movements between PCB and Bank account' AS Petty_Cash_Category_Name,
Petty_Cash_Category_Code,
'6' AS Id_Ledger_Account,
Balance_Carried_Forward,
Debit_Amount,
Credit_Amount,
Post_Payment,
'' AS Created_Date
FROM (
SELECT 
le.Id_Ledger_Entry,
le.Id_Petty_Cash_Voucher,
le.Business_Purpose,
le.Id_Petty_Cash_Book,
le.Id_Petty_Cash_Category,
pcc.Petty_Cash_Category_Name,
pcc.Petty_Cash_Category_Code,
le.Id_Ledger_Account,
(CASE 
WHEN (SUM(le.Credit_Amount)-1*SUM(le.Debit_Amount))>0 
THEN (SUM(le.Credit_Amount)-1*SUM(le.Debit_Amount))
ELSE 0
END) AS Debit_Amount,
(CASE 
WHEN (SUM(le.Credit_Amount)-1*SUM(le.Debit_Amount))<0 
THEN (SUM(le.Credit_Amount)-1*SUM(le.Debit_Amount))
ELSE 0
END) AS Credit_Amount,
(SUM(le.Credit_Amount)-1*SUM(le.Debit_Amount)) AS Balance_Carried_Forward,
le.Post_Payment,
le.Created_Date
FROM
core_ledger_entry AS le
INNER JOIN core_petty_cash_book AS pcb ON le.Id_Petty_Cash_Book=pcb.Id_Petty_Cash_Book
INNER JOIN core_petty_cash_category AS pcc ON le.Id_Petty_Cash_Category=pcc.Id_Petty_Cash_Category
WHERE le.Id_Petty_Cash_Book='" + Convert.ToInt32(ddlPCBName.SelectedValue) + @"' 
AND DATE(le.Created_Date) < '" + cm.convertToMySqlDate(fromDate.Text.Trim()) + @"') AS ZZZ
UNION ALL " + sql + @" AND DATE(le.Created_Date) >= '" + cm.convertToMySqlDate(fromDate.Text.Trim()) + @"' ";
            }
            if (cm.convertToMySqlDate(toDate.Text.Trim()) != string.Empty)
            {
                sql += @"AND DATE(le.Created_Date) <= '" + cm.convertToMySqlDate(toDate.Text.Trim()) + @"' ORDER BY Id_Ledger_Entry;";
            }
            DataSet ds = obj.SelectMethod(sql, "table");
            PettyCashBookReport irpt = new PettyCashBookReport();

            if (ds.Tables[0].Rows.Count == 0)
            {
                if (IsPostBack)
                {
                    /////
                    irpt.SetDataSource(ds.Tables["table"]);
                    crvVoucherReport.EnableDatabaseLogonPrompt = false;
                    Session["ReportDocument"] = irpt;
                    ReportDocument doc = (ReportDocument)Session["ReportDocument"];
                    /////
                    /* ScriptManager.RegisterStartupScript(this, GetType(), "AlertSweet", "alertSweet();", true);
                    crvVoucherReport.ReportSource = null; */
                    ///////
                    crvVoucherReport.ReportSource = doc;
                    crvVoucherReport.DataBind();
                    ///////
                }
            }
            else
            {
                irpt.SetDataSource(ds.Tables["table"]);
                crvVoucherReport.EnableDatabaseLogonPrompt = false;
                ////////////newly added
                if (IsPostBack)
                {
                    TextObject obj1 = (TextObject)irpt.ReportDefinition.Sections["Section1"].ReportObjects["Text5"];
                    TextObject obj2 = (TextObject)irpt.ReportDefinition.Sections["Section1"].ReportObjects["Text7"];
                    obj1.Text = fromDate.Text.Trim();
                    obj2.Text = toDate.Text.Trim();
                }
                ////////////
                Session["ReportDocument"] = irpt;
                ReportDocument doc = (ReportDocument)Session["ReportDocument"];
                if (doc != null)
                    crvVoucherReport.ReportSource = doc;
                crvVoucherReport.DataBind();

            }

        }

        protected void cmdSubmit_Click(object sender, EventArgs e)
        {
            getReport();
        }

        protected void ddlPCBName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPCBCode.SelectedValue = ddlPCBName.SelectedValue;
        }

        protected void ddlPCBCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPCBName.SelectedValue = ddlPCBCode.SelectedValue;
        }
    }
}