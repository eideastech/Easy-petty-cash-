using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace WebApplication1
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
     
        protected void submitLogIn_Click(object sender, EventArgs e)
        {
            LoginHandler login = new LoginHandler();
            try
            {
                if (Page.IsValid)
                {
                    if (login.checkUserLogin(tb_username.Text, tb_password.Text))
                    {
                        Response.Redirect("PettyCashBook.aspx", false);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "AlertSweet", "alertSweet();", true);
                        //logerror.Text = "Invalid User Name or Password!";
                    }
                }
            }
            catch (Exception ex)
            {
                logerror.Text = ex.Message;
            }
        }
    }
}