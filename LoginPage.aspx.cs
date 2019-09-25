using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
//using System.Data.SqlClient;
using Oracle.DataAccess.Client;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Security;

public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblErrorMessage.Visible = false;
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
            OracleConnection orclcon = new OracleConnection("Data Source=orcl;Persist Security Info=True;User ID=DBCactus;Password=DBC123Temp");
            OracleCommand com;
            OracleDataAdapter orada;
            string str;
            DataTable dt;
            int RowCount;

            string UserName = txtUserName.Text.Trim();
            string Password = txtPassword.Text.Trim();
            orclcon.Open();
            str = "Select * from login_info";
            com = new OracleCommand(str);
            orada = new OracleDataAdapter(com.CommandText, orclcon);
            dt = new DataTable();
            orada.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                UserName = dt.Rows[i]["UserName"].ToString();
                Password = dt.Rows[i]["Password"].ToString();
                if (UserName == txtUserName.Text && Password == txtPassword.Text)
                {
                    Session["UserName"] = UserName;
                    Response.Redirect("Be_Pro.aspx");
                }
                else
                {
                    lblErrorMessage.Visible=true;
                }
            }
        }
    }