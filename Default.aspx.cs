using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace Twilio
{
    public partial class Default : System.Web.UI.Page
    {
        NewCall objCall = new NewCall();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack == false)
            {
                if(Request.QueryString.Count > 0)
                {

                    String Value = Request.QueryString["Call"].ToString();
                    if(Value == "1")
                    {
                        PrepareStartXmlForPinNumber();

                    }
                    else
                    {
                        PrepareEndXmlForPinNumber();
                    }
                    
                }
                
            }
        }

        public void PrepareStartXmlForPinNumber()
        {
            
           // string phoneno = Session["Phonenumber"].ToString();
            if (!string.IsNullOrEmpty(Request.QueryString["phone"].ToString()))
            {
                string phoneno = Request.QueryString["phone"].ToString();
                Page.Response.ContentType = "text/xml";
                StringBuilder text = new StringBuilder();
                text.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                text.Append("<Response>");
                text.Append("<Pause length=\"10\"/>");
                text.Append("<Play digits=\"4135495649#wwwwwwww1234#wwwwwww*72#wwwwww1#wwwwww" + phoneno + "#1#wwwwww\"></Play>");
                //text.Append("<Play digits=\"4135495649#wwwwwwww1234#wwwwwww*72#wwwwww1#wwwwww8572933006#1#wwwwww\"></Play>");
                text.Append("</Response>");

                WriteXmltoResponseString(text.ToString(), new string[1] { objCall.GetRedirectUrl("", "self") });
            }
            
        }

        public void PrepareEndXmlForPinNumber()
        {
            Page.Response.ContentType = "text/xml";
            StringBuilder text = new StringBuilder();
            text.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            text.Append("<Response>");
            text.Append("<Pause length=\"10\"/>");
            text.Append("<Play digits=\"4135495649#wwwwwwww1234#wwwwwww*73#wwwwww1#wwwwwwwwww\"></Play>");
            text.Append("</Response>");
            WriteXmltoResponseString(text.ToString(), new string[1] { objCall.GetRedirectUrl("", "self") });
        }


        private void WriteXmltoResponseString(string xml, string[] parameters)
        {
            try
            {
                string xmlData = string.Format(xml, parameters);
                Response.Write(xmlData);
            }
            catch (Exception ex)
            {
                objCall.MessageLogTFN("CallTwillio:", "Error = " + ex.Message);
            }
        }

    }
}