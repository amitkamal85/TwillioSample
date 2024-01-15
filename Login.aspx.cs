using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Twilio
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("ForwardCall.aspx");
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {

            //try
            //{                
            //    if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Password"].ToString()) && ConfigurationManager.AppSettings["Password"].ToString() == txt_pasword.Text.Trim().ToString())
            //    {
            //        Session["Password"] = ConfigurationManager.AppSettings["Password"].ToString();
            //        Response.Redirect("ForwardCall.aspx");
            //    }
            //    else
            //    {
            //        lbl_password.Text = "Invalid Password";
            //    }
            //}
            //catch (Exception ex )
            //{
            //}
        }
    }
}