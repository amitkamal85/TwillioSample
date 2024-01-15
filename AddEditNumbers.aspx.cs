using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;


namespace Twilio
{
    public partial class AddEditNumbers : System.Web.UI.Page
    {
        String MyConnectionString = "Connection String";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack == false)
            {
                Bind_Rec();
            }
           

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

        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                MySqlConnection connection = new MySqlConnection(MyConnectionString);
                MySqlCommand cmd;
                connection.Open();

                cmd = connection.CreateCommand();

                if (hdnID.Value != "")
                {

                    cmd.CommandText = "update tbl_Addnumbers SET Name =@Name, Number = @Number where ID=@ID";
                    cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(hdnID.Value));
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Number", txtNumber.Text);
                    cmd.ExecuteNonQuery();
                    btnSave.Text = "Save";
                    hdnID.Value = "";
          
                }
                else
                {

                    cmd.CommandText = "Insert into tbl_Addnumbers(Name, Number)Values(@Name, @Number)";
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Number", txtNumber.Text);
                    cmd.ExecuteNonQuery();
                }
               
                Clear_rec();
                connection.Close();
                Bind_Rec();
            }
            catch(Exception exp)
            {

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Clear_rec();
        }

        private void Clear_rec()
        {
            txtName.Text = "";
            txtNumber.Text = "";
        }

        protected void grdListofNumbers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
             if (e.CommandName == "Newedit")
             {
                String ID =  e.CommandArgument.ToString();

                MySqlConnection connection = new MySqlConnection(MyConnectionString);
                MySqlCommand cmd;

                connection.Open();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select * from tbl_Addnumbers where ID= " + ID;
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                
                 if(ds.Tables[0].Rows.Count > 0)
                 {
                     txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                     txtNumber.Text = ds.Tables[0].Rows[0]["Number"].ToString();
                     btnSave.Text = "Update";
                     hdnID.Value = ID;
                 }

           }
           if(e.CommandName == "Newdelete")
           {
               String ID = e.CommandArgument.ToString();

               if(ID != "")
               {
                   MySqlConnection connection = new MySqlConnection(MyConnectionString);
                   MySqlCommand cmd;
                   connection.Open();
                   cmd = connection.CreateCommand();
                   cmd.CommandText = "delete from tbl_Addnumbers where ID= " + ID;
                   cmd.ExecuteNonQuery();
                   connection.Close();

                   Bind_Rec();
               }
           }
        }
    }
}