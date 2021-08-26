using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.Common;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

//using CarlosAg.ExcelXmlWriter;
//using Ionic.Zip;
//using SendGrid;
//using SendGrid.Helpers.Mail;

public partial class Q104_SBVolComp : System.Web.UI.Page
{
    string constring = @"Data Source=49.50.68.207\SQLEXPRESS,1433;Initial Catalog=AKZOCLM;uid=sa;pwd=India~1@;Integrated Security=false;Trusted_Connection=False";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //lblCurrentDt.Text = DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss");
            LoadDD();
        }
    }

    protected void LoadDD()
    {
        try
        {


            SqlConnection con = new SqlConnection(constring);
            string com = "Select * from LkupSubBrandCLM where SchemeYesNo='Yes' order by ProductCluster,SubBrandName";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            ddlSubBrand1.DataSource = dt;
            ddlSubBrand1.DataBind();
            ddlSubBrand1.DataTextField = "SubBrandName";
            ddlSubBrand1.DataValueField = "SubBrandName";
            ddlSubBrand1.DataBind();

            ddlSubBrand2.DataSource = dt;
            ddlSubBrand2.DataBind();
            ddlSubBrand2.DataTextField = "SubBrandName";
            ddlSubBrand2.DataValueField = "SubBrandName";
            ddlSubBrand2.DataBind();




        }
        catch (Exception ex)
        {
            //WebMsgBox.Show(ex.Message.ToString());
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlSubBrand1.Text != ddlSubBrand2.Text)
        {
            if (CnfResult.Value == "true")
            {
                try
                {
                    SqlConnection con = new SqlConnection(constring);
                    SqlCommand cmd = new SqlCommand("SP_SBVolCompQ104", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@iMode", 1);
                    cmd.Parameters.AddWithValue("@FromYear", ddlFromYear.SelectedValue);
                    cmd.Parameters.AddWithValue("@FromMonth", ddlFromMonth.SelectedValue);
                    cmd.Parameters.AddWithValue("@ToYear", ddlToYear.SelectedValue);
                    cmd.Parameters.AddWithValue("@ToMonth", ddlToMonth.SelectedValue);
                    cmd.Parameters.AddWithValue("@SubBrand1", ddlSubBrand1.SelectedValue);
                    cmd.Parameters.AddWithValue("@Formula1", ddlFormula1.SelectedValue);
                    cmd.Parameters.AddWithValue("@SB1Volume", txtSB1Volume.Text);
                    cmd.Parameters.AddWithValue("@SubBrand2", ddlSubBrand2.SelectedValue);
                    cmd.Parameters.AddWithValue("@Formula2", ddlFormula2.SelectedValue);
                    cmd.Parameters.AddWithValue("@SB2Volume", txtSB2Volume.Text);
                    cmd.Parameters.AddWithValue("@Status", ddlStatus.SelectedValue);
                    cmd.Parameters.AddWithValue("@SendTo", ddlSendTo.SelectedValue);

                    con.Open();
                    int numRes = cmd.ExecuteNonQuery();
                    if (numRes > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('Q104 Sub Brand Volume Comparison request submitted.Report will be sent to your Email ID shortly.');", true);
                        //btnUpload.Visible = false;
                        ClearAllData();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('Please Try Again.');", true);

                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + ex.ToString() + "');", true);
                    //WebMsgBox.Show(ex.ToString());
                }
            }
        }
        else
        {
            WebMsgBox.Show("Select different SubBrand, you can't compare the same SubBrand");
        }
        
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearAllData();
    }

    protected void ClearAllData()
    {
        ddlFromYear.SelectedIndex = 0;
        ddlFromMonth.SelectedIndex = 0;
        ddlToYear.SelectedIndex = 0;
        ddlToMonth.SelectedIndex = 0;
        ddlSubBrand1.SelectedIndex = 0;
        ddlFormula1.SelectedIndex = 0;
        txtSB1Volume.Text = "0";
        ddlSubBrand2.SelectedIndex = 0;
        ddlFormula2.SelectedIndex = 0;
        txtSB2Volume.Text = "0"; 
        ddlStatus.SelectedIndex = 0;
        ddlSendTo.SelectedIndex = 0;

    }

    protected void lblSignOut_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }


   

    

}