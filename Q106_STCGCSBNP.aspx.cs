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

public partial class Q106_STCGCSBNP : System.Web.UI.Page
{
    string constring = @"Data Source=49.50.68.207\SQLEXPRESS,1433;Initial Catalog=AKZOCLM;uid=sa;pwd=India~1@;Integrated Security=false;Trusted_Connection=False";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadSB();
        }
    }

    protected void LoadSB()
    {
        try
        {
            //SqlConnection con = new SqlConnection(constring);
            //string com = "Select * from LkupSubBrandCLM where SchemeYesNo='Yes' order by ProductCluster,SubBrandName";
            //SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            //DataTable dt = new DataTable();
            //adpt.Fill(dt);

            //ddlSubBrand.DataSource = dt;
            //ddlSubBrand.DataBind();
            //ddlSubBrand.DataTextField = "SubBrandName";
            //ddlSubBrand.DataValueField = "SubBrandName";
            //ddlSubBrand.DataBind();

            SqlProcsNew sqlobj = new SqlProcsNew();
            DataSet dsFetch = new DataSet();
            dsFetch = sqlobj.ExecuteSP("SP_STSBQtyQ103",
             new SqlParameter() { ParameterName = "@iMode", SqlDbType = SqlDbType.Int, Value = 1 });

            rdgCombo.DataSource = dsFetch.Tables[0];
            rdgCombo.DataValueField = "SubBrandName";
            rdgCombo.DataTextField = "SubBrandName";
            rdgCombo.DataBind();


        }
        catch (Exception ex)
        {
            //WebMsgBox.Show(ex.Message.ToString());
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (CnfResult.Value == "true")
        {
            try
            {
                var collection = rdgCombo.CheckedItems;


                if (collection.Count != 0)
                {
                    var sb = new StringBuilder();
                    foreach (var item in collection)
                        sb.Append(item.Text + ",");
                    string SB = sb.ToString().Remove(sb.ToString().Length - 1, 1);


                    SqlConnection con = new SqlConnection(constring);
                    SqlCommand cmd = new SqlCommand("SP_CGCodePtvMontsQ106", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@iMode", 1);
                    cmd.Parameters.AddWithValue("@ForYear", ddlForYear.SelectedValue);
                    cmd.Parameters.AddWithValue("@SubBrand", SB);
                    cmd.Parameters.AddWithValue("@Formula", ddlFormula.SelectedValue);
                    cmd.Parameters.AddWithValue("@PtvMonths", ddlPtvMonth.SelectedValue);
                    cmd.Parameters.AddWithValue("@SendTo", ddlSendTo.SelectedValue);


                    con.Open();
                    int numRes = cmd.ExecuteNonQuery();
                    if (numRes > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('Request submitted. Report will be sent to your Email ID shortly.');", true);
                        //btnUpload.Visible = false;
                        ClearAllData();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('Please Try Again.');", true);

                    }
                }



            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", "alert('" + ex.ToString() + "');", true);

                //WebMsgBox.Show(ex.ToString());
            }


        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearAllData();
    }

    protected void ClearAllData()
    {
        ddlForYear.SelectedIndex = 0;         
        rdgCombo.ClearSelection();
        rdgCombo.Text = String.Empty;
        ddlFormula.SelectedIndex = 0;
        ddlPtvMonth.SelectedIndex = 0;
        ddlSendTo.SelectedIndex = 0;

    }
}