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
    public partial class ViewTips : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDataList();
            }
        }

        private void LoadDataList()
        {
            BusinessLogic businessLogic = new BusinessLogic();
            DataTable resultData = new DataTable();
            string qry = "select date_format(Created_On,'%d-%m-%y') as Posted_On,Tips_Details,Tips_Description from tips_details order by created_On desc;";
            try
            {
                resultData = businessLogic.GetQueryResult(qry);
                if (resultData.Rows.Count > 0)
                {
                    dlTips.DataSource = resultData;
                    dlTips.DataBind();
                }
                else
                {
                    dlTips.DataSource = null;
                    dlTips.DataBind();
                    lblmsg.Text = "Sorry,Currently No Data Available!!";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    lblmsg.Font.Size = 14;
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}