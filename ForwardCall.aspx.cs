using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using MySql.Data.MySqlClient;
using System.Data;

namespace Twilio
{
    public partial class ForwardCall : System.Web.UI.Page
    {
        static string AccountSid = ConfigurationManager.AppSettings["AccountSid"];//"";
        static string AuthToken = ConfigurationManager.AppSettings["AuthToken"];//"";
        XmlDocument xmlEmloyeeDoc = null;
        XmlElement ParentElement = null;
        XmlElement ID = null;
        XmlNode value = null;
        String MyConnectionString = "Connection String";
        String Number = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {

                //if (Session["Password"] != null)
                //{
                //xmlEmloyeeDoc = new XmlDocument();
                //xmlEmloyeeDoc.Load(Server.MapPath("~/file.xml"));
                //value = xmlEmloyeeDoc.ChildNodes[1];

                Boolean Status = ChkBoxAlert();
                if (Status == true)
                {
                    Get_Current_Number();

                }
                Bind_Rec();

                //}
                //else
                //{
                //    Response.Redirect("Login.aspx");
                //}

            }
        }

        private void Get_Current_Number()
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            cmd = connection.CreateCommand();
            cmd.CommandText = "Select * from tbl_EnabledNumber";
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Number = ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
            }
        }

        private Boolean ChkBoxAlert()
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            cmd = connection.CreateCommand();
            cmd.CommandText = "Select * from tbl_twillioStatus";
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            Boolean Status = false;
            if (ds.Tables[0].Rows.Count > 0)
            {
                Status = Convert.ToBoolean(ds.Tables[0].Rows[0]["Status"]);

                if (Status == false)
                {
                    rdb_end.Checked = true;
                }
                else
                {
                    rdb_start.Checked = Status;
                }

            }
            return Status;
        }

        protected virtual void StartCall(string phonenumber)
        {
            try
            {
                var twilio = new TwilioRestClient(AccountSid, AuthToken);
                var options = new CallOptions();
                options.Url = "http://" + HttpContext.Current.Request.Url.Authority + "/Default.aspx?Call=1&phone=" + phonenumber;

                options.To = "4136876699";
                options.From = "+14133764257";
                options.Method = "GET";
                var call = twilio.InitiateOutboundCall(options);
                Console.WriteLine(call.Sid);



                //xmlEmloyeeDoc = new XmlDocument();
                //xmlEmloyeeDoc.Load(Server.MapPath("~/file.xml"));
                //value = xmlEmloyeeDoc.ChildNodes[1];
                //value.InnerText = "true";
                //xmlEmloyeeDoc.Save(Server.MapPath("~/file.xml"));
                //isDone.Value = "true";
                Change_Status(true);
            }
            catch
            {

            }
        }

        protected virtual void EndCall()
        {
            try
            {
                var twilio = new TwilioRestClient(AccountSid, AuthToken);
                var options = new CallOptions();
                options.Url = "http://" + HttpContext.Current.Request.Url.Authority + "/Default.aspx?Call=0";
                options.To = "4136876699";
                options.From = "+14133764257";
                options.Method = "GET";
                var call = twilio.InitiateOutboundCall(options);
                Console.WriteLine(call.Sid);


                //xmlEmloyeeDoc = new XmlDocument();
                //xmlEmloyeeDoc.Load(Server.MapPath("~/file.xml"));
                //ID = xmlEmloyeeDoc.CreateElement("Value");
                //ID.InnerText = "false";
                //value = xmlEmloyeeDoc.ChildNodes[1];
                //value.InnerText = "false";
                //xmlEmloyeeDoc.Save(Server.MapPath("~/file.xml"));
                //isDone.Value = "false";

                Change_Status(false);
                Bind_Rec();

            }
            catch
            {

            }
        }
        private void Change_Status(Boolean Status)
        {

            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            cmd = connection.CreateCommand();
            cmd.CommandText = "Update tbl_twillioStatus SET Status = @Status  where ID = @ID";
            cmd.Parameters.AddWithValue("@ID", 1);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.ExecuteNonQuery();
            connection.Close();


        }

        protected void btnStartCall_Click(object sender, EventArgs e)
        {
            try
            {

                rdb_start.Checked = true;
                rdb_end.Checked = false;
                string phonenumber = SaveNumber();
                StartCall(phonenumber);
                //string url = "Default.aspx?Call=1";
                //Response.Redirect(url, false);


            }
            catch (Exception ex)
            {

            }
        }

        protected void btnEndCall_Click(object sender, EventArgs e)
        {
            try
            {
                rdb_start.Checked = false;
                rdb_end.Checked = true;
                EndCall();
            }
            catch (Exception ex)
            {
            }
        }



        private void Save_Status()
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();

            cmd = connection.CreateCommand();

            cmd.CommandText = "delete from  tbl_EnabledNumber";
            cmd.ExecuteNonQuery();

            connection.Clone();
        }

        private void Bind_Rec()
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;

            try
            {
                connection.Open();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select * from tbl_Addnumbers";
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                grdListofNumbers.DataSource = ds;
                grdListofNumbers.DataBind();
            }
            catch (Exception exp)
            {

            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Clone();
                }
            }

        }

        public string SaveNumber()
        {
            string phnonenumber = string.Empty;
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();

            cmd = connection.CreateCommand();

            foreach (GridViewRow row in grdListofNumbers.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkval = (row.Cells[0].FindControl("chk") as CheckBox);

                    if (chkval.Checked)
                    {
                        phnonenumber = (row.Cells[0].FindControl("lblNumber") as Label).Text;
                        Session["Phonenumber"] = phnonenumber;
                    }
                }
            }

            try
            {
                cmd.CommandText = "delete from  tbl_EnabledNumber";

                cmd.Dispose();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "Insert into tbl_EnabledNumber(PhoneNumber)Values(@Number)";

                cmd.Parameters.AddWithValue("@Number", phnonenumber);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            return phnonenumber;
        }

        private void Get_All_Bind_rec()
        {
            DataTable dt = new DataTable();
            //dt.Columns.Add("Id");
            dt.Columns.Add("Name");
            dt.Columns.Add("Number");
            foreach (GridViewRow item in grdListofNumbers.Rows)
            {
                if ((item.Cells[0].FindControl("grdListofNumbers") as CheckBox).Checked)
                {
                    DataRow dr = dt.NewRow();
                    dr["Name"] = item.Cells[1].Text;
                    dr["Number"] = item.Cells[2].Text;
                    dt.Rows.Add(dr);
                }
            }


        }

        protected void btnAddNumbers_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEditNumbers.aspx");
        }

        protected void grdListofNumbers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Number != "0")
                {
                    // lblID

                    Label ddl = (Label)(e.Row.FindControl("lblNumber"));


                    CheckBox chk = (CheckBox)e.Row.FindControl("chk");

                    if (!string.IsNullOrEmpty(ddl.Text.ToString()) && chk != null)
                    {
                        if (ddl.Text == Convert.ToString(Number))
                        {
                            chk.Checked = true;
                        }
                    }

                }
            }
        }
    }


}