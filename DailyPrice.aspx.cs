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
    public partial class DailyPrice : System.Web.UI.Page
    {
        public string todayDate = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                LoadGrid();
                todayDate = DateTime.Now.ToString("MMMM dd yyyy");
                lblDate.Text = todayDate;
            }
        }
        private void LoadGrid() {

            try
            {
                DataTable resultData = new DataTable();
                BusinessLogic business = new BusinessLogic();
                string query = "select st.State_Name,crp.Crop_Name,dp.Price,unt.Unit_Name from daily_price_details dp inner join master_state_details " +
                    "st on st.id=dp.State_Id inner join master_crop_details crp on dp.Crop_ID=crp.Id inner join master_unit_details unt on dp.Unit_ID=unt.Id";
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

    }
}