using System;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;


namespace Onliine_Agro_Products_System
{
    public partial class DealerRequests : System.Web.UI.Page
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
                        LoadGrid();
                    }
                    else
                    {
                        Response.Redirect("~/Login.aspx");
                    }
                }
            }
        }
        protected void gridProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridProduct.PageIndex = e.NewPageIndex;
            LoadGrid();
        }


        private void LoadGrid()
        {
            try
            {   
                DataTable resultData = new DataTable();
                BusinessLogic business = new BusinessLogic();
                string query = "  select cr.Crop_Name,concat(dft.Sold_Qty,' ',ut.Unit_Name)as Qty,dud.Name as Dealer,dud.Contact_No as Contact,dft.IsApproved," +
                    "dft.IsRejected from farmer_dealer_transaction dft inner join farmer_product_details drd on dft.Farmer_Req_ID=drd.Id " +
                    "  inner join master_crop_details cr on drd.Crop_ID=cr.Id inner join master_unit_details ut on drd.Unit_ID = ut.Id " +
                    "  inner join farmer_user_details dud on drd.Farmer_ID=dud.Id where dud.IsActive=True and dft.Dealer_ID=" + Session["Id"].ToString() +
                    " order by dft.Created_On desc";
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
    }
}