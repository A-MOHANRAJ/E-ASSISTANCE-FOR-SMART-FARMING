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
    public partial class SignupFarmer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetStateDetails();
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                List<String> resultList = new List<string>();
                String imageName = ConfigurationManager.AppSettings["DefaultImage"].ToString();
                BusinessLogic businessLogic = new BusinessLogic();
                var fieldValueList = new Dictionary<string, string>();
                DataTable dtExists = new DataTable();
                string checkExists = "select * from " + ConfigurationManager.AppSettings["Farmer_Info"].ToString() + " where Email='" + txtEmail.Text + "'" +
                     " or Contact_No='" + txtContactno.Text + "' or Username='" + txtUserName.Text + "'";
                dtExists = businessLogic.GetQueryResult(checkExists);
                if (dtExists.Rows.Count > 0)
                {
                    lblMsg.Text = "Registration Failed.Email / Contac_No / UserName are Exists";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    fieldValueList.Add("Master_Type_ID", "2");
                    fieldValueList.Add("Name", "'" + txtFarmerName.Text + "'");
                    fieldValueList.Add("Email", "'" + txtEmail.Text + "'");
                    fieldValueList.Add("Contact_No", "'" + txtContactno.Text + "'");
                    fieldValueList.Add("Address", "'" + txtAddress.Text + "'");
                    fieldValueList.Add("City", "'" + txtCity.Text + "'");
                    fieldValueList.Add("District_ID", "'" + ddlDistrict.SelectedItem.Value + "'");
                    fieldValueList.Add("State_ID", "'" + ddlState.SelectedItem.Value + "'");
                    fieldValueList.Add("Reg_Card_No", "'" + txtFarmerCardNo.Text + "'");
                    fieldValueList.Add("Username", "'" + txtUserName.Text + "'");
                    fieldValueList.Add("Password", "'" + txtPassword.Text + "'");

                    if (photoUpload.FileName != "")
                    {
                        fieldValueList.Add("Photo", "'" + photoUpload.FileName + "'");
                    }
                    else
                    {
                        fieldValueList.Add("Photo", "'" + imageName + "'");
                    }
                    if (photoUpload.HasFile)
                    {
                        string extension = Path.GetExtension(photoUpload.PostedFile.FileName);
                        photoUpload.PostedFile.SaveAs(Server.MapPath("~/User_Images/") + DateTime.Now.ToString("MMddyyyyHHmmss") + extension);
                    }
                    resultList = businessLogic.InsertRecord(ConfigurationManager.AppSettings["Farmer_Info"].ToString(), fieldValueList);
                    if (resultList.Count > 1)
                    {
                        lblMsg.Text = "Hi," + txtFarmerName.Text + " you have successfully registered";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        linkRedirect.Visible = true;
                        linkRedirect.PostBackUrl = "~/FarmerDashboard.aspx?mode=normal&id=" + resultList[1];
                        Session["Id"] = resultList[1];
                        Session["Master_Type_ID"] = "2";
                        Session["Name"] = txtFarmerName.Text.ToString();
                        Session["Email"] = txtEmail.Text.ToString();
                    }
                    else
                    {
                        lblMsg.Text = "Registration Failed.Please Contact Support Team";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void GetStateDetails()
        {
            DataTable resultData = new DataTable();
            BusinessLayer.BusinessLogic business = new BusinessLayer.BusinessLogic();
            try
            {
                resultData = business.GetTableDetails(ConfigurationManager.AppSettings["State_Info"].ToString());

                if (resultData.Rows.Count > 0)
                {
                    ddlState.DataSource = resultData;
                    ddlState.DataTextField = "State_Name";
                    ddlState.DataValueField = "Id";
                    ddlState.DataBind();
                }
                ddlState.Items.Insert(0, new ListItem("--Select State--", "0"));
            }
            catch (Exception ex)
            {

            }
        }
        private void GetDistrictDetails(string mode)
        {
            DataTable resultData = new DataTable();
            BusinessLayer.BusinessLogic business = new BusinessLayer.BusinessLogic();
            try
            {
                ddlDistrict.Items.Clear();

                if (mode.Equals("change"))
                {
                    string query = "select * from master_district_details where State_ID=" + ddlState.SelectedItem.Value;
                    resultData = business.GetQueryResult(query);
                }
                else
                {
                    resultData = business.GetTableDetails(ConfigurationManager.AppSettings["District_Info"].ToString());
                }

                ddlDistrict.DataSource = resultData;
                if (resultData.Rows.Count > 0)
                {
                    ddlDistrict.DataTextField = "District_Name";
                    ddlDistrict.DataValueField = "Id";
                    ddlDistrict.DataBind();
                }
                ddlDistrict.Items.Insert(0, new ListItem("--Select District--", "0"));
            }
            catch (Exception ex)
            {

            }
        }
        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList list = (DropDownList)sender;
            string value = (string)list.SelectedValue;
            GetDistrictDetails("change");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

    }
}