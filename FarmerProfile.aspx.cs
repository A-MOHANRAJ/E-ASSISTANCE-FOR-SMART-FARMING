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
    public partial class FarmerProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (string.IsNullOrEmpty(Session["Master_Type_ID"] as string))
                {
                    Response.Redirect("~/Login.aspx");
                }
                else
                {
                   

                    if (Request.QueryString["mode"].Equals("predit") && !string.IsNullOrEmpty(Session.SessionID) && Session["Master_Type_ID"].ToString().Equals("2"))
                    {
                        GetStateDetails(); 
                        GetFarmerInfo();
                        imgprofile.Visible = true;
                        btnRegister.Text = "Update";
                        lblheading.Text = "Edit Profile";
                    }
                    else { 
                        Response.Redirect("~/Login.aspx");
                    }
                }
            }
        }
        private void GetFarmerInfo()
        {
            DataTable dtResult = new DataTable();
            BusinessLogic business = new BusinessLogic();
            string query;
            query = "select * from farmer_user_details fa inner join master_state_details st on fa.State_ID=st.Id inner join master_district_details dt on fa.Id=dt.Id where fa.IsActive=True and fa.Id=" + Session["Id"].ToString();
            dtResult = business.GetQueryResult(query);
            if (dtResult.Rows.Count > 0)
            {
                txtFarmerName.Text = dtResult.Rows[0]["Name"].ToString();
                txtEmail.Text = dtResult.Rows[0]["Email"].ToString();
                txtContactno.Text = dtResult.Rows[0]["Contact_No"].ToString();
                txtAddress.Text = dtResult.Rows[0]["Address"].ToString();
                txtCity.Text = dtResult.Rows[0]["City"].ToString();
                ddlState.SelectedValue = dtResult.Rows[0]["State_ID"].ToString();
                GetDistrictDetails("edit");
                ddlDistrict.SelectedValue = dtResult.Rows[0]["District_ID"].ToString();
                txtFarmerCardNo.Text = dtResult.Rows[0]["Reg_Card_No"].ToString();
                if (string.IsNullOrEmpty(dtResult.Rows[0]["Photo"].ToString()))
                {
                    imgprofile.ImageUrl = "~/User_Images/noimage.jpg";
                }
                else
                {
                    imgprofile.ImageUrl = "~/User_Images/" + dtResult.Rows[0]["Photo"].ToString();
                }
            }

        }

        private void GetStateDetails()
        {
            DataTable resultData = new DataTable();
            BusinessLayer.BusinessLogic business = new BusinessLayer.BusinessLogic();
            try
            {
                resultData = business.GetTableDetails(ConfigurationManager.AppSettings["State_Info"].ToString());
                ddlState.DataSource = resultData;
                if (resultData.Rows.Count > 0)
                {
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

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean saveResult;
                List<String> resultList = new List<string>();
                String imageName = ConfigurationManager.AppSettings["DefaultImage"].ToString();
                BusinessLogic businessLogic = new BusinessLogic();
                var fieldValueList = new Dictionary<string, string>();
                fieldValueList.Add("Name", "'" + txtFarmerName.Text + "'");
                fieldValueList.Add("Email", "'" + txtEmail.Text + "'");
                fieldValueList.Add("Contact_No", "'" + txtContactno.Text + "'");
                fieldValueList.Add("Address", "'" + txtAddress.Text + "'");
                fieldValueList.Add("City", "'" + txtCity.Text + "'");
                fieldValueList.Add("District_ID", "'" + ddlDistrict.SelectedItem.Value + "'");
                fieldValueList.Add("State_ID", "'" + ddlState.SelectedItem.Value + "'");
                fieldValueList.Add("Reg_Card_No", "'" + txtFarmerCardNo.Text + "'");

                //update record 

                if (photoUpload.FileName != "")
                {
                    fieldValueList.Add("Photo", "'" + photoUpload.FileName + "'");
                }
                if (photoUpload.HasFile)
                {
                    string extension = Path.GetExtension(photoUpload.PostedFile.FileName);
                    photoUpload.PostedFile.SaveAs(Server.MapPath("~/User_Images/") + DateTime.Now.ToString("MMddyyyyHHmmss") + extension);
                }
                saveResult = businessLogic.UpdateRecord(Session["Id"].ToString(), ConfigurationManager.AppSettings["Farmer_Info"].ToString(), fieldValueList);
                if (saveResult)
                {
                    lblMsg.Text = "Your Profile Updated";
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
