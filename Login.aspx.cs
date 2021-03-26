using System;
using System.Configuration;
using System.Data;
using BusinessLayer;
namespace Onliine_Agro_Products_System
{
    public partial class Login : System.Web.UI.Page
    {
        string dbConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetUserTypeDetails();
                
            }

        }
        /// <summary>
        /// Check Login Action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataTable resultData = new DataTable();
            BusinessLogic business = new BusinessLogic();
            string tableName_Admin = ConfigurationManager.AppSettings["Admin_Info"].ToString();
            string tableName_Farmer = ConfigurationManager.AppSettings["Farmer_Info"].ToString();
            string tableName_Dealer = ConfigurationManager.AppSettings["Dealer_Info"].ToString();
            if (ddlUserType.SelectedValue.Length > 0)
            {
                //Admin
                if (ddlUserType.SelectedItem.Value.Equals("1")) {
                    tableName_Admin = "select Master_User_Type,Id,Name,Email from " + tableName_Admin + " where Username='" + txtUserName.Text + "' and Password='" + txtPassword.Text + "' and IsActive=true";
                    resultData =business.GetQueryResult(tableName_Admin);
                    if (resultData.Rows.Count > 0)
                    {
                        Session["Id"] = resultData.Rows[0]["Id"].ToString();
                        Session["Name"] = resultData.Rows[0]["Name"].ToString();
                        Session["Email"] = resultData.Rows[0]["Email"].ToString();
                        Session["Master_Type_ID"] = resultData.Rows[0]["Master_User_Type"].ToString();
                        Response.Redirect("Admin_FarmingTips.aspx");
                    }
                    else {
                        lblLoginMsg.ForeColor = System.Drawing.Color.Red;
                        lblLoginMsg.Text = "User details not found!! Please check username & password";
                    }
                }
                //Farmer
                else if (ddlUserType.SelectedItem.Value.Equals("2"))
                {
                    tableName_Farmer = "select Master_Type_ID,Id,Name,Email from " + tableName_Farmer + " where Username='" + txtUserName.Text + "' and Password='" + txtPassword.Text + "' and IsActive=true";
                    resultData = business.GetQueryResult(tableName_Farmer);
                    if (resultData.Rows.Count > 0)
                    {
                        Session["Id"] = resultData.Rows[0]["Id"].ToString();
                        Session["Name"] = resultData.Rows[0]["Name"].ToString();
                        Session["Email"] = resultData.Rows[0]["Email"].ToString();
                        Session["Master_Type_ID"] = resultData.Rows[0]["Master_Type_ID"].ToString();
                        Response.Redirect("FarmerDashboard.aspx");
                    }
                    else
                    {
                        lblLoginMsg.ForeColor = System.Drawing.Color.Red;
                        lblLoginMsg.Text = "User details not found!! Please check username & password";
                    }
                } 
                //Dealer
                else if (ddlUserType.SelectedItem.Value.Equals("3"))
                {
                    tableName_Dealer = "select Master_Type_ID,Id,Name,Email from " + tableName_Dealer + " where Username='" + txtUserName.Text + "' and Password='" + txtPassword.Text + "' and IsActive=true";
                    resultData = business.GetQueryResult(tableName_Dealer);
                    if (resultData.Rows.Count > 0)
                    {
                        Session["Id"] = resultData.Rows[0]["Id"].ToString();
                        Session["Name"] = resultData.Rows[0]["Name"].ToString();
                        Session["Email"] = resultData.Rows[0]["Email"].ToString();
                        Session["Master_Type_ID"] = resultData.Rows[0]["Master_Type_ID"].ToString();
                        Response.Redirect("DealerDashboard.aspx");
                    }
                    else
                    {
                        lblLoginMsg.ForeColor = System.Drawing.Color.Red;
                        lblLoginMsg.Text = "User details not found!! Please check username & password";
                    }
                }

            }
            else {
                lblLoginMsg.ForeColor = System.Drawing.Color.Red;
                lblLoginMsg.Text = "Please select atleast one usertype";

            }
        }
        /// <summary>
        /// Method to Get Master User Type Details
        /// </summary>
        public void GetUserTypeDetails()
        {
            DataTable resultData = new DataTable();
            BusinessLayer.BusinessLogic business = new BusinessLayer.BusinessLogic();
            try
            {
                resultData = business.GetTableDetails(ConfigurationManager.AppSettings["User_Type"].ToString());
                ddlUserType.DataSource = resultData;
                if (resultData.Rows.Count > 0)
                {
                    ddlUserType.DataTextField = "User_Type";
                    ddlUserType.DataValueField = "Id";
                    ddlUserType.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
    
}