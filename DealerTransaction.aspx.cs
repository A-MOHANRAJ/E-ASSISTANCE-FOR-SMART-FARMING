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
    public partial class DealerTransaction : System.Web.UI.Page
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
                        LoadProductDropdown();
                        ddlMyProduct.SelectedIndex = ddlMyProduct.Items.IndexOf(ddlMyProduct.Items.FindByValue("--Select Product--"));
                        pnlDetails.Visible = false;
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

        protected void ddlMyProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMyProduct.SelectedValue.Equals("0"))
            {
                pnlDetails.Visible = false;
            }
            else
            {
                LoadProductDetails(ddlMyProduct.SelectedValue);
                pnlDetails.Visible = true;
            }
        }
        private void LoadProductDetails(string productID)
        {
            DataTable resultData = new DataTable();
            DataTable resultData_SoldQty = new DataTable();
            BusinessLayer.BusinessLogic business = new BusinessLayer.BusinessLogic();
            try
            {
                string query = "select cr.Crop_Name,date_format(fp.created_on,'%d-%m-%y') as Posted_On,fp.Id as ProductID,fp.Request_Qty as Quantity,ut.Unit_Name as UOM,st.Status_Name as Status  from dealer_requirement_details fp " +
                            "inner join master_crop_details cr on fp.Crop_ID = cr.Id inner join master_unit_details ut on fp.Unit_ID = ut.Id " +
                            "inner join master_status_details st on fp.Status_ID = st.Id " +
                            "where fp.IsActive = True and fp.Id=" + productID;
                resultData = business.GetQueryResult(query);

                if (resultData.Rows.Count > 0)
                {
                    lblCrop.Text = resultData.Rows[0]["Crop_Name"].ToString();
                    lblDate.Text = resultData.Rows[0]["Posted_On"].ToString();
                    lblSellingQty.Text = resultData.Rows[0]["Quantity"].ToString();
                    lblUnit.Text = resultData.Rows[0]["UOM"].ToString();
                    lblStatus.Text = resultData.Rows[0]["Status"].ToString();
                    lblSoldQty.Text = "0";
                }
                string querySoldQty = "SELECT Received_Qty FROM farmer_db.dealer_farmer_transaction where Dealer_Req_ID=" + productID+" and IsApproved=1";
                resultData_SoldQty = business.GetQueryResult(querySoldQty);
                if (resultData_SoldQty.Rows.Count > 0)
                {
                    object sumObject;
                    sumObject = resultData_SoldQty.Compute("Sum(Received_Qty)", string.Empty);
                    lblSoldQty.Text = sumObject.ToString();
                    LoadGrid();
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
        private void LoadProductDropdown()
        {
            DataTable resultData = new DataTable();
            BusinessLayer.BusinessLogic business = new BusinessLayer.BusinessLogic();
            try
            {
                string query = "select concat(cr.Crop_Name,' - ',date_format(fp.created_on,'%d-%m-%y')) as PrdInfo,fp.Id as ProductID from dealer_requirement_details fp " +
                    "inner join master_crop_details cr on fp.Crop_ID = cr.Id inner join master_unit_details ut on fp.Unit_ID = ut.Id " +
                    "inner join master_status_details st on fp.Status_Id = st.Id where fp.IsActive = True and fp.Dealer_ID =" + Session["Id"].ToString();
                resultData = business.GetQueryResult(query);

                if (resultData.Rows.Count > 0)
                {
                    ddlMyProduct.DataSource = resultData;
                    ddlMyProduct.DataTextField = "PrdInfo";
                    ddlMyProduct.DataValueField = "ProductID";
                    ddlMyProduct.DataBind();
                    LoadGrid();
                }
                ddlMyProduct.Items.Insert(0, new ListItem("--Select Product--", "0"));
            }
            catch (Exception ex)
            {

            }
        }
        private void LoadGrid()
        {
            try
            {
                DataTable resultData = new DataTable();
                BusinessLogic business = new BusinessLogic();
                string query = "select dud.Name as Dealer,fdt.Received_Qty as Purchased_Qty,ut.Unit_Name,date_format(fdt.created_on,'%d-%m-%y') " +
                    "as Purchased_On from dealer_requirement_details fp inner join master_unit_details ut on   fp.Unit_ID = ut.Id inner join dealer_farmer_transaction fdt on" +
                    " fp.Id = fdt.Dealer_Req_ID inner join farmer_user_details dud on fdt.Farmer_ID = dud.id  where fp.IsActive = True and fdt.IsApproved=True and fp.Id =" + ddlMyProduct.SelectedValue;
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