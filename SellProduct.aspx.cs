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
    public partial class SellProduct : System.Web.UI.Page
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
                    if (Session != null && Session["Master_Type_ID"].Equals("2"))
                    {
                        GetCropDetails();
                        GetUnitDetails();
                    }
                    else {
                        Response.Redirect("~/Login.aspx");
                    }
                }
            }
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            BusinessLogic businessLogic = new BusinessLogic();
            List<String> resultList = new List<string>();
            var fieldValueList = new Dictionary<string, string>();
            fieldValueList.Add("Farmer_ID", "'" + Session["Id"].ToString() + "'");
            fieldValueList.Add("Crop_ID", "'" + ddlCrop.SelectedItem.Value + "'");
            fieldValueList.Add("Qty", "'" + txtQty.Text + "'");
            fieldValueList.Add("Unit_ID", "'" + ddlUnit.SelectedItem.Value + "'");
            fieldValueList.Add("Product_Status", "1");
            fieldValueList.Add("Remarks", "'" + txtRemarks.Text + "'");
            fieldValueList.Add("IsActive", "True");
            fieldValueList.Add("ToSale", "'" + txtQty.Text + "'");
            resultList = businessLogic.InsertRecord(ConfigurationManager.AppSettings["Farmer_Product_Info"].ToString(), fieldValueList);
            if (resultList.Count > 1)
            {
                lblMsg.Text = "Crop posted successfully";                
                lblMsg.ForeColor = System.Drawing.Color.Green;   
                lblMsg.Focus();        
            }
            else
            {
                lblMsg.Text = "Something went wrong.Please Contact Support Team";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Focus();
            }
        }
        private void GetCropDetails() {
            DataTable resultData = new DataTable();
            BusinessLayer.BusinessLogic business = new BusinessLayer.BusinessLogic();
            try
            {
                resultData = business.GetTableDetails(ConfigurationManager.AppSettings["Crop_Info"].ToString());
                ddlCrop.DataSource = resultData;
                if (resultData.Rows.Count > 0)
                {
                    ddlCrop.DataTextField = "Crop_Name";
                    ddlCrop.DataValueField = "Id";
                    ddlCrop.DataBind();
                }
                ddlCrop.Items.Insert(0, new ListItem("--Select Crop--", "0"));
            }
            catch (Exception ex)
            {

            }
        }
        private void GetUnitDetails() {
            DataTable resultData = new DataTable();
            BusinessLayer.BusinessLogic business = new BusinessLayer.BusinessLogic();
            try
            {
                resultData = business.GetTableDetails(ConfigurationManager.AppSettings["Unit_Info"].ToString());
                ddlUnit.DataSource = resultData;
                if (resultData.Rows.Count > 0)
                {
                    ddlUnit.DataTextField = "Unit_Name";
                    ddlUnit.DataValueField = "Id";
                    ddlUnit.DataBind();
                }
                ddlUnit.Items.Insert(0, new ListItem("--Select Unit--", "0"));
            }
            catch (Exception ex)
            {

            }

        }
    }
}