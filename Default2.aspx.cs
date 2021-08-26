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

public partial class Default2 : System.Web.UI.Page
{
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

            ddlSubBrand.DataSource = dsFetch.Tables[0];
            ddlSubBrand.DataValueField = "SubBrandName";
            ddlSubBrand.DataTextField = "SubBrandName";


            ddlSubBrand.DataBind();

            dsFetch.Dispose();
            ddlSubBrand.Items.Insert(0, new ListItem("All", "00"));
        }
        catch (Exception ex)
        {
            WebMsgBox.Show(ex.Message);
        }
    }

    protected void LoadGrid()
    {
        SqlProcsNew proc = new SqlProcsNew();
        DataSet dsGrid = new DataSet();

        if (ddlSelect.SelectedValue == "01" && ddlSubBrand.SelectedValue == "00")
        {
            dsGrid = proc.ExecuteSP("SP_STSBQtyQ103",
               new SqlParameter() { ParameterName = "@iMode", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.Int, Value = 2 },
               new SqlParameter() { ParameterName = "@DSelect", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSelect.SelectedValue },
               new SqlParameter() { ParameterName = "@DYear", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlYear.SelectedValue },
               new SqlParameter() { ParameterName = "@SubBrand", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSubBrand.SelectedValue });

        }
        else if (ddlSelect.SelectedValue == "02" && ddlSubBrand.SelectedValue == "00")
        {
            dsGrid = proc.ExecuteSP("SP_STSBQtyQ103",
               new SqlParameter() { ParameterName = "@iMode", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.Int, Value = 3 },
               new SqlParameter() { ParameterName = "@DSelect", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSelect.SelectedValue },
               new SqlParameter() { ParameterName = "@DYear", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlYear.SelectedValue },
               new SqlParameter() { ParameterName = "@SubBrand", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSubBrand.SelectedValue });

        }

        else if (ddlSelect.SelectedValue == "03" && ddlSubBrand.SelectedValue == "00")
        {
            dsGrid = proc.ExecuteSP("SP_STSBQtyQ103",
               new SqlParameter() { ParameterName = "@iMode", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.Int, Value = 4 },
               new SqlParameter() { ParameterName = "@DSelect", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSelect.SelectedValue },
               new SqlParameter() { ParameterName = "@DYear", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlYear.SelectedValue },
               new SqlParameter() { ParameterName = "@SubBrand", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSubBrand.SelectedValue });

        }

        if (ddlSelect.SelectedValue == "01" && ddlSubBrand.SelectedValue != "00")
        {
            dsGrid = proc.ExecuteSP("SP_STSBQtyQ103",
               new SqlParameter() { ParameterName = "@iMode", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.Int, Value = 5 },
               new SqlParameter() { ParameterName = "@DSelect", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSelect.SelectedValue },
               new SqlParameter() { ParameterName = "@DYear", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlYear.SelectedValue },
               new SqlParameter() { ParameterName = "@SubBrand", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSubBrand.SelectedValue });

        }
        else if (ddlSelect.SelectedValue == "02" && ddlSubBrand.SelectedValue != "00")
        {
            dsGrid = proc.ExecuteSP("SP_STSBQtyQ103",
               new SqlParameter() { ParameterName = "@iMode", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.Int, Value = 6 },
               new SqlParameter() { ParameterName = "@DSelect", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSelect.SelectedValue },
               new SqlParameter() { ParameterName = "@DYear", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlYear.SelectedValue },
               new SqlParameter() { ParameterName = "@SubBrand", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSubBrand.SelectedValue });

        }

        else if (ddlSelect.SelectedValue == "03" && ddlSubBrand.SelectedValue != "00")
        {
            dsGrid = proc.ExecuteSP("SP_STSBQtyQ103",
               new SqlParameter() { ParameterName = "@iMode", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.Int, Value = 7 },
               new SqlParameter() { ParameterName = "@DSelect", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSelect.SelectedValue },
               new SqlParameter() { ParameterName = "@DYear", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlYear.SelectedValue },
               new SqlParameter() { ParameterName = "@SubBrand", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSubBrand.SelectedValue });

        }

        if (dsGrid != null && dsGrid.Tables.Count > 0 && dsGrid.Tables[0].Rows.Count > 0)
        {
            int TypeCount = dsGrid.Tables[0].Rows.Count;
            rdgQ103.DataSource = dsGrid.Tables[0];
            rdgQ103.DataBind();
        }
        else
        {
            rdgQ103.DataSource = new String[] { };
            rdgQ103.DataBind();
        }



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


            if (ddlSelect.SelectedValue == "01" && ddlSubBrand.SelectedValue == "00")
            {
                dsStatement = proc.ExecuteSP("SP_STSBQtyQ103",
                   new SqlParameter() { ParameterName = "@iMode", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.Int, Value = 2 },
                   new SqlParameter() { ParameterName = "@DSelect", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSelect.SelectedValue },
                   new SqlParameter() { ParameterName = "@DYear", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlYear.SelectedValue },
                   new SqlParameter() { ParameterName = "@SubBrand", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSubBrand.SelectedValue });

            }
            else if (ddlSelect.SelectedValue == "02" && ddlSubBrand.SelectedValue == "00")
            {
                dsStatement = proc.ExecuteSP("SP_STSBQtyQ103",
                   new SqlParameter() { ParameterName = "@iMode", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.Int, Value = 3 },
                   new SqlParameter() { ParameterName = "@DSelect", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSelect.SelectedValue },
                   new SqlParameter() { ParameterName = "@DYear", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlYear.SelectedValue },
                   new SqlParameter() { ParameterName = "@SubBrand", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSubBrand.SelectedValue });

            }

            else if (ddlSelect.SelectedValue == "03" && ddlSubBrand.SelectedValue == "00")
            {
                dsStatement = proc.ExecuteSP("SP_STSBQtyQ103",
                   new SqlParameter() { ParameterName = "@iMode", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.Int, Value = 4 },
                   new SqlParameter() { ParameterName = "@DSelect", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSelect.SelectedValue },
                   new SqlParameter() { ParameterName = "@DYear", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlYear.SelectedValue },
                   new SqlParameter() { ParameterName = "@SubBrand", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSubBrand.SelectedValue });

            }

            if (ddlSelect.SelectedValue == "01" && ddlSubBrand.SelectedValue != "00")
            {
                dsStatement = proc.ExecuteSP("SP_STSBQtyQ103",
                   new SqlParameter() { ParameterName = "@iMode", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.Int, Value = 5 },
                   new SqlParameter() { ParameterName = "@DSelect", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSelect.SelectedValue },
                   new SqlParameter() { ParameterName = "@DYear", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlYear.SelectedValue },
                   new SqlParameter() { ParameterName = "@SubBrand", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSubBrand.SelectedValue });

            }
            else if (ddlSelect.SelectedValue == "02" && ddlSubBrand.SelectedValue != "00")
            {
                dsStatement = proc.ExecuteSP("SP_STSBQtyQ103",
                   new SqlParameter() { ParameterName = "@iMode", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.Int, Value = 6 },
                   new SqlParameter() { ParameterName = "@DSelect", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSelect.SelectedValue },
                   new SqlParameter() { ParameterName = "@DYear", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlYear.SelectedValue },
                   new SqlParameter() { ParameterName = "@SubBrand", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSubBrand.SelectedValue });

            }

            else if (ddlSelect.SelectedValue == "03" && ddlSubBrand.SelectedValue != "00")
            {
                dsStatement = proc.ExecuteSP("SP_STSBQtyQ103",
                   new SqlParameter() { ParameterName = "@iMode", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.Int, Value = 7 },
                   new SqlParameter() { ParameterName = "@DSelect", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSelect.SelectedValue },
                   new SqlParameter() { ParameterName = "@DYear", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlYear.SelectedValue },
                   new SqlParameter() { ParameterName = "@SubBrand", Direction = ParameterDirection.Input, SqlDbType = SqlDbType.NVarChar, Value = ddlSubBrand.SelectedValue });

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
}