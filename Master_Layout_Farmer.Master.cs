﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Onliine_Agro_Products_System
{
    public partial class Master_Layout_Farmer : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
        }

    }
}