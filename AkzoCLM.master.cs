using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.Drawing;
using Telerik.Web.UI;
using System.Text;
using System.Web.Services;

public partial class AkzoCLM : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlProcsNew proc = new SqlProcsNew();
        DataSet dsDT = null;
        if (!IsPostBack)
        {
            dsDT = proc.ExecuteSP("GetServerDateTime");
            GetserverDateTime.Text = Convert.ToDateTime(dsDT.Tables[0].Rows[0][0].ToString()).ToString("ddd") + "   " + Convert.ToDateTime(dsDT.Tables[0].Rows[0][0].ToString()).ToString("dd-MMM-yyyy HH:mm 'Hrs'"); ;
        }
    }

    protected void lblSignOut_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}
