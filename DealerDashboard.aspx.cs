using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;

namespace Onliine_Agro_Products_System
{
    public partial class DealerDashboard : System.Web.UI.Page
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
                    if (Session["Master_Type_ID"].Equals("3"))
                    {

                        if (Request.QueryString.Count > 0)
                        {
                            if (Request.QueryString["mode"].Equals("chpass"))
                            {
                                pnlDashboard.Visible = false;
                                pnlPassword.Visible = true;
                            }
                            LoadGrid();
                        }
                        else
                        {
                            pnlDashboard.Visible = true;
                            pnlPassword.Visible = false;
                            LoadGrid();
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Login.aspx");
                    }
                }
            }
        }

        private void LoadGrid()
        {
            try
            {
                DataTable resultData = new DataTable();
                BusinessLogic business = new BusinessLogic();
                string query = "select date_format(fp.created_on,'%d-%m-%y') as CreatedOn,fp.Id,cr.Crop_Name,fp.Request_Qty,ut.Unit_Name,st.Status_Name,fp.Remarks from dealer_requirement_details fp inner join master_crop_details cr on fp.Crop_ID=cr.Id " +
                    "inner join master_unit_details ut on fp.Unit_ID = ut.Id inner join master_status_details st on fp.Status_Id = st.Id where fp.IsActive = True and fp.Dealer_ID =" + Session["Id"].ToString() + " order by fp.id desc";
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
        protected void gridProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridProduct.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        protected void btnSubmitPassword_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean saveResult;
                List<String> resultList = new List<string>();
                String imageName = ConfigurationManager.AppSettings["DefaultImage"].ToString();
                BusinessLogic businessLogic = new BusinessLogic();
                var fieldValueList = new Dictionary<string, string>();
                fieldValueList.Add("Password", "'" + txtRePassword.Text + "'");
                saveResult = businessLogic.UpdateRecord(Session["Id"].ToString(), ConfigurationManager.AppSettings["Dealer_Info"].ToString(), fieldValueList);
                if (saveResult)
                {
                    lblMsg.Text = "Your Password Updated";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Focus();
                }
                else
                {
                    lblMsg.Text = "Sorry !Something went wrong.Please try again";

                }


            }
            catch (Exception ex)
            {

            }
        }
    }
}