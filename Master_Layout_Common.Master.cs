using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Onliine_Agro_Products_System
{
    public partial class Master_Layout_Common : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Session["Master_Type_ID"] as string))
                {                    
                    pnlMyAccount.Visible = true;
                  //  lnkLogin.Visible = false;
                }
                else {
                    pnlMyAccount.Visible = false;
                   // lnkLogin.Visible = true;
                }
            }
        }
    }
}