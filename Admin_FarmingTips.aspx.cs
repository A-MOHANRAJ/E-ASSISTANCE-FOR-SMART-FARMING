using System;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Collections.Generic;
using System.Configuration;

namespace Onliine_Agro_Products_System
{
    public partial class Admin_FarmingTips : System.Web.UI.Page
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
                string query = "select Tips_Details,Tips_Description,date_format(tp.created_on,'%d-%m-%y') as Posted_On,au.Name as Author from tips_details tp " +
                    "inner join admin_user_details au on tp.Admin_Id=au.Id order by tp.Created_On desc";
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
            List<String> resultList = new List<string>();
            var fieldValueList = new Dictionary<string, string>();
            fieldValueList.Add("Admin_Id", "'" + Session["Id"].ToString() + "'");
            fieldValueList.Add("Tips_Details", "'" + txtTitle.Text + "'");
            fieldValueList.Add("Tips_Description", "'" + txtRemarks.Text + "'");
            fieldValueList.Add("IsActive", "True");
            resultList = businessLogic.InsertRecord(ConfigurationManager.AppSettings["Tips_Info"].ToString(), fieldValueList);
            if (resultList.Count > 1)
            {
                lblMsg.Text = "Tips Added successfully";
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