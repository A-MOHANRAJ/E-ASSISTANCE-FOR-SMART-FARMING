using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Onliine_Agro_Products_System
{
    public partial class Login1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["Master_Type_ID"] as string))
            {

                lblUserName.Text = Session["Name"].ToString();
            }
            else {
                lblUserName.Text = "Guest";
                btnHome.Visible = false;
                btnRegister.Text = "Login";
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["Master_Type_ID"] as string))
            {
                Session.Abandon();
                Response.Redirect("~/home.aspx");
            }
            else
            {
                Response.Redirect("~/login.aspx");
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            if (Session["Master_Type_ID"].Equals("1"))
            {
                Response.Redirect("~/AdminDashboard.aspx");

            }
            else if (Session["Master_Type_ID"].Equals("2")) {
                Response.Redirect("~/FarmerDashboard.aspx");
            }
            else if (Session["Master_Type_ID"].Equals("3"))
            {
                Response.Redirect("~/DealerDashboard.aspx");
            }
            
        }
    }
}