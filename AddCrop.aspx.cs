using System;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Collections.Generic;
using System.Configuration;

namespace Onliine_Agro_Products_System
{
    public partial class AddCrop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Session["Master_Type_ID"] as string))
                {
                    Response.Redirect("~/Login.aspx");
                }
                else
                {
                    if (Session["Master_Type_ID"].Equals("1"))
                    {
                        LoadGrid();
                    }
                    else
                    {
                        Response.Redirect("~/Login.aspx");
                    }
                }
            }

        }
        protected void btnAddTips_Click(object sender, EventArgs e)
        {
            pnlAddTips.Visible = true;
        }
        protected void gridProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridProduct.PageIndex = e.NewPageIndex;
            LoadGrid();
        }


        private void LoadGrid()
        {
            try
            {
                DataTable resultData = new DataTable();
                BusinessLogic business = new BusinessLogic();
                string query = "select Crop_Name from master_crop_details order by crop_name asc;";
                resultData = business.GetQueryResult(query);
                if (resultData.Rows.Count > 0)
                {
                    gridProduct.DataSource = resultData;
                    gridProduct.DataBind();
                }
                else
                {
                    gridProduct.DataSource = null;
                    gridProduct.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            BusinessLogic businessLogic = new BusinessLogic();
            DataTable resultData = new DataTable();
            List<String> resultList = new List<string>();
            var fieldValueList = new Dictionary<string, string>();
            fieldValueList.Add("Crop_Name", "'" + txtTitle.Text + "'");
            fieldValueList.Add("IsActive", "True");
            string query = "select Crop_Name from master_crop_details where Crop_Name='" + txtTitle.Text+"'";
            resultData = businessLogic.GetQueryResult(query);
            if (resultData.Rows.Count > 0)
            {
                lblMsg.Text = "Crop Already Exists.Try Adding New";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {

                resultList = businessLogic.InsertRecord(ConfigurationManager.AppSettings["Crop_Info"].ToString(), fieldValueList);
                if (resultList.Count > 1)
                {
                    lblMsg.Text = "Crop Added successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    pnlAddTips.Visible = false;
                    LoadGrid();
                }
                else
                {
                    lblMsg.Text = "Something went wrong.Please Contact Support Team";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}