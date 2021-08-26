using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //lblCurrentDt.Text = DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss");
    }

    protected void lblSignOut_Click(object sender, EventArgs e)
    {
        //Response.Redirect("Login.aspx");
    }
}