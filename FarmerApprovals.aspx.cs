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
    public partial class FarmerApprovals : System.Web.UI.Page
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
                    if (Session["Master_Type_ID"].Equals("2"))
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
        protected void grdApproval_Approve(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            Label lblID = gvr.FindControl("lblTranID") as Label;
            BusinessLogic businessLogic = new BusinessLogic();
            Boolean result = UpdateRequestStatus(lblID.Text, "Approve");
            if (result)
            {
                lblMsg.Text = "Product Approved Successfully!";
                DataTable dtQty = new DataTable();
                string qry = "SELECT fp.Id,Qty,sum(fdt.Sold_Qty) as Received FROM farmer_dealer_transaction fdt inner join farmer_product_details " +
                    "fp on fdt.Farmer_Req_ID=fp.Id where fdt.IsApproved=1 and fdt.id=" + lblID.Text;
                dtQty = businessLogic.GetQueryResult(qry);
                if (dtQty.Rows.Count > 0) {
                    int qty = Convert.ToInt32(dtQty.Rows[0]["Qty"]);
                    int sold_Qty = Convert.ToInt32(dtQty.Rows[0]["Received"]);
                    int available_qty = qty - sold_Qty;
                    var fieldValueList = new Dictionary<string, string>();
                    if (sold_Qty < qty)
                    {
                        fieldValueList.Add("Product_Status", "2");
                        fieldValueList.Add("ToSale", available_qty.ToString());
                        result = businessLogic.UpdateRecord(dtQty.Rows[0]["Id"].ToString(), ConfigurationManager.AppSettings["Farmer_Product_Info"].ToString(), fieldValueList);
                    }
                    else if(sold_Qty==qty) {
                        fieldValueList.Add("Product_Status", "3");
                        fieldValueList.Add("ToSale", available_qty.ToString());
                        result = businessLogic.UpdateRecord(dtQty.Rows[0]["Id"].ToString(), ConfigurationManager.AppSettings["Farmer_Product_Info"].ToString(), fieldValueList);
                    }
                }
                LoadGrid();
            }
            else
            {
                lblMsg.Text = "Sorry,Something went wrong";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void grdApproval_Reject(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            Label lblID = gvr.FindControl("lblTranID") as Label;
            Boolean result = UpdateRequestStatus(lblID.Text, "Reject");
            if (result)
            {
                lblMsg.Text = "Product Rejected Successfully!";
                LoadGrid();
            }
            else
            {
                lblMsg.Text = "Sorry,Something went wrong";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }

        }
        private Boolean UpdateRequestStatus(string productID, string mode)
        {
            Boolean saveResult;
            List<String> resultList = new List<string>();
            String imageName = ConfigurationManager.AppSettings["DefaultImage"].ToString();
            BusinessLogic businessLogic = new BusinessLogic();
            var fieldValueList = new Dictionary<string, string>();
            if (mode.Equals("Approve"))
            {
                fieldValueList.Add("IsApproved", "True");
                saveResult = businessLogic.UpdateRecord(productID, ConfigurationManager.AppSettings["Farmer_Transaction_Info"].ToString(), fieldValueList);                
            }
            else
            {
                fieldValueList.Add("IsRejected", "True");
                saveResult = businessLogic.UpdateRecord(productID, ConfigurationManager.AppSettings["Farmer_Transaction_Info"].ToString(), fieldValueList);
            }

            return saveResult;
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
                string query = " select fdt.id as FDT_Id,cr.Crop_name,dud.Contact_No,dud.Office_Name as Dealer,concat(fdt.Sold_Qty,' ',ut.Unit_Name)as Purchased_Qty,date_format(fdt.created_on,'%d-%m-%y') as Purchased_On from farmer_product_details fp " +
                                "inner join master_crop_details cr on fp.Crop_ID = cr.Id inner join master_unit_details ut on fp.Unit_ID = ut.Id " +
                                "inner join master_status_details st on fp.Product_Status = st.Id " +
                                "inner join farmer_dealer_transaction fdt on fp.Id = fdt.Farmer_Req_ID " +
                                "inner join dealer_user_details dud on fdt.Dealer_ID = dud.id " +
                                "where fp.IsActive = True and fdt.IsApproved = false and fdt.IsRejected = false and fp.Farmer_ID =" + Session["Id"].ToString() + " order by fdt.Created_On desc";
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