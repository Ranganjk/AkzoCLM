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
using System.IO;
using System.Net;
using System.Text;


public partial class Q103_STSBQTY : System.Web.UI.Page
{

    string constring = @"Data Source=49.50.68.207\SQLEXPRESS,1433;Initial Catalog=AKZOCLM;uid=sa;pwd=India~1@;Integrated Security=false;Trusted_Connection=False";
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            LoadSubBrand();
            LoadGrid();

            lblYear.Visible = false;
            ddlYear.Visible = false;



        }

    }

    protected void LoadSubBrand()
    {
        try
        {
            SqlProcsNew sqlobj = new SqlProcsNew();
            DataSet dsFetch = new DataSet();
            dsFetch = sqlobj.ExecuteSP("SP_STSBQtyQ103",
             new SqlParameter() { ParameterName = "@iMode", SqlDbType = SqlDbType.Int, Value = 1 });

            //ddlSubBrand.DataSource = dsFetch.Tables[0];
            //ddlSubBrand.DataValueField = "SubBrandName";
            //ddlSubBrand.DataTextField = "SubBrandName";
            //ddlSubBrand.DataBind();



            rdgCombo.DataSource = dsFetch.Tables[0];
            rdgCombo.DataValueField = "SubBrandName";
            rdgCombo.DataTextField = "SubBrandName";
            rdgCombo.DataBind();

            dsFetch.Dispose();
            //ddlSubBrand.Items.Insert(0, new ListItem("All", "00"));
        }
        catch (Exception ex)
        {
            WebMsgBox.Show(ex.Message);
        }
    }

    protected void ChkSubBrand()
    {
        int ChkSBrand = rdgCombo.CheckedItems.Count;
        if (ChkSBrand > 0)
        {
            var sb = new StringBuilder();
            var collection = rdgCombo.CheckedItems;
            string SB;

            if (collection.Count != 0)
            {
                sb.Append("<h3>Checked Items:</h3><ul class=\"results\">");

                foreach (var item in collection)
                    sb.Append("<li>" + item.Text + "</li>");

                sb.Append("</ul>");

                SB = sb.ToString();
            }
            else
            {
                SB = "<p>No items selected</p>";
            }

        }

    }

    protected void LoadGrid()
    {
        SqlProcsNew proc = new SqlProcsNew();
        DataSet dsGrid = new DataSet();

        SqlConnection con = new SqlConnection(constring);
        DataSet ds = new DataSet();
        string com;

        //ChkSubBrand();


        var collection = rdgCombo.CheckedItems;


        if (collection.Count != 0)
        {
           

            var sb = new StringBuilder();

            foreach (var item in collection)
                sb.Append("'" + item.Text + "',");

            string SB = sb.ToString().Remove(sb.ToString().Length -1,1);
            


            if (ddlSelect.SelectedValue == "01")
            {
                com = "Select top 500 SubBrand,ProductCluster,YYMM,QuantityKL,CGCodes,VPC,Rank,PercentShare,RateofIncrease From ST_SB_QTY_Q103 where SUBSTRING(YYMM,3,1) = 'Q' and SubBrand in (" + SB + ") order by SubBrand,YYMM desc";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                adpt.Fill(ds);
                rdgQ103.DataSource = ds.Tables[0];
                rdgQ103.DataBind();

                // dsGrid = proc.ExecuteSP("SP_STSBQtyQ103_2",
                //new SqlParameter() { ParameterName = "@iMode", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.Int, Value = 2 },
                //new SqlParameter() { ParameterName = "@DSelect", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSelect.SelectedValue },
                //new SqlParameter() { ParameterName = "@DYear", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlYear.SelectedValue },
                //new SqlParameter() { ParameterName = "@SubBrand", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = RAM });

            }
            else if (ddlSelect.SelectedValue == "02")
            {
                com = "Select top 500 SubBrand,ProductCluster,YYMM,QuantityKL,CGCodes,VPC,Rank,PercentShare,RateofIncrease From ST_SB_QTY_Q103 where SUBSTRING(YYMM,3,1) != 'Q' and YYMM = '" + ddlYear.SelectedValue + "' and SubBrand in (" + SB + ") order by SubBrand,YYMM desc";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                adpt.Fill(ds);
                rdgQ103.DataSource = ds.Tables[0];
                rdgQ103.DataBind();

                //  dsGrid = proc.ExecuteSP("SP_STSBQtyQ103_2",
                //new SqlParameter() { ParameterName = "@iMode", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.Int, Value = 3 },
                //new SqlParameter() { ParameterName = "@DSelect", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSelect.SelectedValue },
                //new SqlParameter() { ParameterName = "@DYear", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlYear.SelectedValue },
                //new SqlParameter() { ParameterName = "@SubBrand", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = SB });

            }
            else if (ddlSelect.SelectedValue == "03")
            {
                com = "Select top 500 SubBrand,ProductCluster,YYMM,QuantityKL,CGCodes,VPC,Rank,PercentShare,RateofIncrease From ST_SB_QTY_Q103 where SUBSTRING(YYMM,3,1) != 'Q' and cast(SUBSTRING(YYMM,3,2) as int) <= 12 and SubBrand in (" + SB + ") order by  SubBrand,YYMM desc";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                adpt.Fill(ds);
                rdgQ103.DataSource = ds.Tables[0];
                rdgQ103.DataBind();

                //   dsGrid = proc.ExecuteSP("SP_STSBQtyQ103_2",
                //new SqlParameter() { ParameterName = "@iMode", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.Int, Value = 4 },
                //new SqlParameter() { ParameterName = "@DSelect", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSelect.SelectedValue },
                //new SqlParameter() { ParameterName = "@DYear", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlYear.SelectedValue },
                //new SqlParameter() { ParameterName = "@SubBrand", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = SB });

            }

          
        }
        else
        {
            if (ddlSelect.SelectedValue == "01")
            {
                com = "Select top 500 SubBrand,ProductCluster,YYMM,QuantityKL,CGCodes,VPC,Rank,PercentShare,RateofIncrease From ST_SB_QTY_Q103 where SUBSTRING(YYMM,3,1) = 'Q' order by SubBrand,YYMM desc";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                adpt.Fill(ds);
                rdgQ103.DataSource = ds.Tables[0];
                rdgQ103.DataBind();

                // dsGrid = proc.ExecuteSP("SP_STSBQtyQ103_2",
                //new SqlParameter() { ParameterName = "@iMode", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.Int, Value = 5 },
                //new SqlParameter() { ParameterName = "@DSelect", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSelect.SelectedValue },
                //new SqlParameter() { ParameterName = "@DYear", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlYear.SelectedValue });

            }
            else if (ddlSelect.SelectedValue == "02")
            {
                com = "Select top 500 SubBrand,ProductCluster,YYMM,QuantityKL,CGCodes,VPC,Rank,PercentShare,RateofIncrease From ST_SB_QTY_Q103 where SUBSTRING(YYMM,3,1) != 'Q' and YYMM = '" + ddlYear.SelectedValue + "'order by SubBrand,YYMM desc";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                adpt.Fill(ds);
                rdgQ103.DataSource = ds.Tables[0];
                rdgQ103.DataBind();

                //  dsGrid = proc.ExecuteSP("SP_STSBQtyQ103_2",
                //new SqlParameter() { ParameterName = "@iMode", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.Int, Value = 6 },
                //new SqlParameter() { ParameterName = "@DSelect", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSelect.SelectedValue },
                //new SqlParameter() { ParameterName = "@DYear", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlYear.SelectedValue });

            }
            else if (ddlSelect.SelectedValue == "03")
            {
                com = "Select top 500 SubBrand,ProductCluster,YYMM,QuantityKL,CGCodes,VPC,Rank,PercentShare,RateofIncrease From ST_SB_QTY_Q103 where SUBSTRING(YYMM,3,1) != 'Q' and cast(SUBSTRING(YYMM,3,2) as int) <= 12  order by  SubBrand,YYMM desc";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                adpt.Fill(ds);
                rdgQ103.DataSource = ds.Tables[0];
                rdgQ103.DataBind();

                //   dsGrid = proc.ExecuteSP("SP_STSBQtyQ103_2",
                //new SqlParameter() { ParameterName = "@iMode", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.Int, Value = 7 },
                //new SqlParameter() { ParameterName = "@DSelect", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSelect.SelectedValue },
                //new SqlParameter() { ParameterName = "@DYear", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlYear.SelectedValue });

            }

            


        }

        //if (dsGrid != null && dsGrid.Tables.Count > 0 && dsGrid.Tables[0].Rows.Count > 0)
        //{
        //    int TypeCount = dsGrid.Tables[0].Rows.Count;
        //    rdgQ103.DataSource = dsGrid.Tables[0];
        //    rdgQ103.DataBind();
        //}
        //else
        //{
        //    rdgQ103.DataSource = new String[] { };
        //    rdgQ103.DataBind();




        






    }


    protected void rdgQ103_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        LoadGrid();
    }
    protected void rdgQ103_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
    {
        LoadGrid();
    }

    protected void rdgQ103_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        //LoadGrid();
    }

    protected void ddlSelect_Change(object sender, EventArgs e)
    {
        if (ddlSelect.SelectedValue == "02")
        {
            lblYear.Visible = true;
            ddlYear.Visible = true;
        }
        else
        {
            lblYear.Visible = false;
            ddlYear.Visible = false;
        }
    }

    protected void BtnShow_Click(object sender, EventArgs e)
    {
        LoadGrid();
    }

    protected void BtnnExcelExport_Click(object sender, EventArgs e)
    {
        try
        {

            SqlProcsNew proc = new SqlProcsNew();
            DataSet dsGrid = new DataSet();

            DataSet dsStatement = new DataSet();

            SqlConnection con = new SqlConnection(constring);            
            string com;

            var sb = new StringBuilder();
            var collection = rdgCombo.CheckedItems;
            string SB;

            if (collection.Count != 0)
            {
                //sb.Append("<h3>Checked Items:</h3><ul class=\"results\">");

                foreach (var item in collection)
                    sb.Append("'" + item.Text + "',");

                //sb.Append("</ul>");
                //SB = sb.ToString();
                SB = sb.ToString().Remove(sb.ToString().Length - 1, 1);


                if (ddlSelect.SelectedValue == "01")
                {
                    com = "Select top 500 SubBrand,ProductCluster,YYMM,QuantityKL,CGCodes,VPC,Rank,PercentShare,RateofIncrease From ST_SB_QTY_Q103 where SUBSTRING(YYMM,3,1) = 'Q' and SubBrand in (" + SB + ") order by SubBrand,YYMM desc";
                    SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                    adpt.Fill(dsStatement);

                   // dsStatement = proc.ExecuteSP("SP_STSBQtyQ103_2",
                   //new SqlParameter() { ParameterName = "@iMode", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.Int, Value = 2 },
                   //new SqlParameter() { ParameterName = "@DSelect", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSelect.SelectedValue },
                   //new SqlParameter() { ParameterName = "@DYear", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlYear.SelectedValue },
                   //new SqlParameter() { ParameterName = "@SubBrand", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = SB });

                }
                else if (ddlSelect.SelectedValue == "02")
                {
                    com = "Select top 500 SubBrand,ProductCluster,YYMM,QuantityKL,CGCodes,VPC,Rank,PercentShare,RateofIncrease From ST_SB_QTY_Q103 where SUBSTRING(YYMM,3,1) != 'Q' and YYMM = '" + ddlYear.SelectedValue + "' and SubBrand in (" + SB + ") order by SubBrand,YYMM desc";
                    SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                    adpt.Fill(dsStatement);

                  //  dsStatement = proc.ExecuteSP("SP_STSBQtyQ103_2",
                  //new SqlParameter() { ParameterName = "@iMode", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.Int, Value = 3 },
                  //new SqlParameter() { ParameterName = "@DSelect", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSelect.SelectedValue },
                  //new SqlParameter() { ParameterName = "@DYear", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlYear.SelectedValue },
                  //new SqlParameter() { ParameterName = "@SubBrand", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = SB });

                }
                else if (ddlSelect.SelectedValue == "03")
                {

                    com = "Select top 500 SubBrand,ProductCluster,YYMM,QuantityKL,CGCodes,VPC,Rank,PercentShare,RateofIncrease From ST_SB_QTY_Q103 where SUBSTRING(YYMM,3,1) != 'Q' and cast(SUBSTRING(YYMM,3,2) as int) <= 12 and SubBrand in (" + SB + ") order by  SubBrand,YYMM desc";
                    SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                    adpt.Fill(dsStatement);

                 //   dsStatement = proc.ExecuteSP("SP_STSBQtyQ103_2",
                 //new SqlParameter() { ParameterName = "@iMode", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.Int, Value = 4 },
                 //new SqlParameter() { ParameterName = "@DSelect", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSelect.SelectedValue },
                 //new SqlParameter() { ParameterName = "@DYear", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlYear.SelectedValue },
                 //new SqlParameter() { ParameterName = "@SubBrand", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = SB });

                }
            }
            else
            {
                if (ddlSelect.SelectedValue == "01")
                {
                    com = "Select top 500 SubBrand,ProductCluster,YYMM,QuantityKL,CGCodes,VPC,Rank,PercentShare,RateofIncrease From ST_SB_QTY_Q103 where SUBSTRING(YYMM,3,1) = 'Q' order by SubBrand,YYMM desc";
                    SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                    adpt.Fill(dsStatement);

                   // dsStatement = proc.ExecuteSP("SP_STSBQtyQ103_2",
                   //new SqlParameter() { ParameterName = "@iMode", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.Int, Value = 5 },
                   //new SqlParameter() { ParameterName = "@DSelect", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSelect.SelectedValue },
                   //new SqlParameter() { ParameterName = "@DYear", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlYear.SelectedValue });

                }
                else if (ddlSelect.SelectedValue == "02")
                {
                    com = "Select top 500 SubBrand,ProductCluster,YYMM,QuantityKL,CGCodes,VPC,Rank,PercentShare,RateofIncrease From ST_SB_QTY_Q103 where SUBSTRING(YYMM,3,1) != 'Q' and YYMM = '" + ddlYear.SelectedValue + "'order by SubBrand,YYMM desc";
                    SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                    adpt.Fill(dsStatement);

                  //  dsStatement = proc.ExecuteSP("SP_STSBQtyQ103_2",
                  //new SqlParameter() { ParameterName = "@iMode", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.Int, Value = 6 },
                  //new SqlParameter() { ParameterName = "@DSelect", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSelect.SelectedValue },
                  //new SqlParameter() { ParameterName = "@DYear", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlYear.SelectedValue });

                }
                else if (ddlSelect.SelectedValue == "03")
                {
                    com = "Select top 500 SubBrand,ProductCluster,YYMM,QuantityKL,CGCodes,VPC,Rank,PercentShare,RateofIncrease From ST_SB_QTY_Q103 where SUBSTRING(YYMM,3,1) != 'Q' and cast(SUBSTRING(YYMM,3,2) as int) <= 12  order by  SubBrand,YYMM desc";
                    SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                    adpt.Fill(dsStatement);

                 //   dsStatement = proc.ExecuteSP("SP_STSBQtyQ103_2",
                 //new SqlParameter() { ParameterName = "@iMode", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.Int, Value = 7 },
                 //new SqlParameter() { ParameterName = "@DSelect", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSelect.SelectedValue },
                 //new SqlParameter() { ParameterName = "@DYear", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlYear.SelectedValue });

                }
            }



            if (dsStatement.Tables[0].Rows.Count > 0)
            {

                DataGrid dg = new DataGrid();

                dg.DataSource = dsStatement.Tables[0];
                dg.DataBind();

                DateTime sdate = DateTime.Now;
                //DateTime edate = dtpTillDate.SelectedDate.Value;

                // THE EXCEL FILE.
                string sFileName = "Q103_SubBrandVPC_" + sdate.ToString("dd/MM/yyyy") + ".xls";
                //string sFileName = "Q103_SubBrandVPC_.xls";
                sFileName = sFileName.Replace("/", "");

                // SEND OUTPUT TO THE CLIENT MACHINE USING "RESPONSE OBJECT".
                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment; filename=" + sFileName);
                Response.ContentType = "application/vnd.ms-excel";
                EnableViewState = false;

                System.IO.StringWriter objSW = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter objHTW = new System.Web.UI.HtmlTextWriter(objSW);

                dg.HeaderStyle.Font.Bold = true;     // SET EXCEL HEADERS AS BOLD.
                dg.RenderControl(objHTW);


                Response.Write("<table><tr><td><b>Q103 - Sub Brand VPC View" + " " + "</td></b></tr></table>");


                // STYLE THE SHEET AND WRITE DATA TO IT.
                Response.Write("<style> TABLE { border:dotted 1px #999; } " +
                    "TD { border:dotted 1px #D5D5D5; text-align:center } </style>");
                Response.Write(objSW.ToString());


                Response.End();
                dg = null;


            }
            else
            {
                //WebMsgBox.Show(" From" + dtpFromDate.SelectedDate.Value + " To " + dtpTillDate.SelectedDate.Value + " Preview Summary does not exist");
                WebMsgBox.Show("There are no records to Export");
            }
        }
        catch (Exception ex)
        {
            //WebMsgBox.Show(ex.Message);
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("Q103_STSBQTY.aspx");
    }

}