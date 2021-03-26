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
    public partial class DealerPosts : System.Web.UI.Page
    {
        public Boolean dataAvailable = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCropDetails();
                GetStateDetails();
                LoadDataList("landing", "");
            }
        }
        private void LoadDataList(string mode, string value)
        {
            BusinessLogic businessLogic = new BusinessLogic();
            DataTable resultData = new DataTable();
            string qry = "";
            if (mode.Equals("landing"))
            {
                qry = "select unt.Unit_Name as Unit,crp.Crop_Name,fp.Request_Qty,fp.ToBuy,st.State_Name,fud.Name,fud.Office_Name,fud.Office_Address," +
                    "fud.Contact_No,fud.Email,fp.Remarks,date_format(fp.created_on,'%d-%m-%y') as Posted_On,fp.Id as FP_ID,fud.Id as DUD_ID," +
                    "unt.Id as UNT_ID from master_state_details st inner join dealer_user_details fud on st.Id = fud.State_ID inner join " +
                    "dealer_requirement_details fp on fud.Id = fp.Dealer_ID inner join master_crop_details crp on fp.Crop_ID = crp.Id " +
                    "inner join master_unit_details unt on fp.Unit_ID=unt.Id where fp.Tobuy > 0   order by fp.Created_On desc;";
            }
            else if (mode.Equals("state"))
            {
                qry = "select unt.Unit_Name as Unit,crp.Crop_Name,fp.Request_Qty,fp.ToBuy,st.State_Name,fud.Name,fud.Office_Name,fud.Office_Address," +
                    "fud.Contact_No,fud.Email,fp.Remarks,date_format(fp.created_on,'%d-%m-%y') as Posted_On,fp.Id as FP_ID,fud.Id as DUD_ID," +
                    "unt.Id as UNT_ID from master_state_details st inner join dealer_user_details fud on st.Id = fud.State_ID inner join " +
                    "dealer_requirement_details fp on fud.Id = fp.Dealer_ID inner join master_crop_details crp on fp.Crop_ID = crp.Id " +
                    "inner join master_unit_details unt on fp.Unit_ID=unt.Id where fp.Tobuy > 0 and st.id='" + value.ToString() + "'  order by fp.Created_On desc;";               

            }
            //Sort by Crop Name
            else
            {
                qry = "select unt.Unit_Name as Unit,crp.Crop_Name,fp.Request_Qty,fp.ToBuy,st.State_Name,fud.Name,fud.Office_Name,fud.Office_Address," +
                   "fud.Contact_No,fud.Email,fp.Remarks,date_format(fp.created_on,'%d-%m-%y') as Posted_On,fp.Id as FP_ID,fud.Id as DUD_ID," +
                   "unt.Id as UNT_ID from master_state_details st inner join dealer_user_details fud on st.Id = fud.State_ID inner join " +
                   "dealer_requirement_details fp on fud.Id = fp.Dealer_ID inner join master_crop_details crp on fp.Crop_ID = crp.Id " +
                   "inner join master_unit_details unt on fp.Unit_ID=unt.Id where fp.Tobuy > 0 and crp.id='" + value.ToString() + "'  order by fp.Created_On desc;";              

            }
            try
            {
                resultData = businessLogic.GetQueryResult(qry);
                if (resultData.Rows.Count > 0)
                {
                    dataAvailable = true;
                    dlProduct.DataSource = resultData;
                    dlProduct.DataBind();
                }
                else
                {
                    dlProduct.DataSource = null;
                    dlProduct.DataBind();
                    lblmsg.Text = "Sorry,Currently No Posts Available!!";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    lblmsg.Font.Size = 14;
                }
             
            }
            catch (Exception ex)
            {

            }

        }

        protected void dlProduct_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "request")
            {
                TextBox txtQty = (TextBox)e.Item.FindControl("txtQty");
                if (txtQty.Text.Equals(""))
                {
                    txtQty.Text = "0";
                }
                Label lblItemMsg = (Label)e.Item.FindControl("lblItemText");
                List<String> resultList = new List<string>();
                BusinessLogic businessLogic = new BusinessLogic();
                var fieldValueList = new Dictionary<string, string>();
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string fp_Id = commandArgs[0];
                string dud_Id = Session["Id"].ToString();
                string unt_Id = commandArgs[1];
                string av_Qty = commandArgs[2];
                int avl_Qty = Convert.ToInt32(av_Qty);
                int req_Qty = Convert.ToInt32(txtQty.Text);
                if (Convert.ToInt32(req_Qty) > Convert.ToInt32(avl_Qty))
                {
                    lblmsg.Text = "Propose qty should not be greater than Required";
                    lblmsg.ForeColor = System.Drawing.Color.Red;

                }
                else if (Convert.ToInt32(req_Qty) <= 0)
                {

                    lblItemMsg.Text = "Minimum Qty Required..ie 1";
                }
                else
                {
                    fieldValueList.Add("Dealer_Req_ID", fp_Id);
                    fieldValueList.Add("Farmer_ID", dud_Id);
                    fieldValueList.Add("Received_Qty", req_Qty.ToString());
                    fieldValueList.Add("Unit_ID", unt_Id);
                    resultList = businessLogic.InsertRecord(ConfigurationManager.AppSettings["Dealer_Transaction_Info"].ToString(), fieldValueList);
                    if (resultList.Count > 1)
                    {
                        lblmsg.Text = "Request Sent Successfully";
                        lblmsg.ForeColor = System.Drawing.Color.Green;
                        LoadDataList("landing", "");
                        lblmsg.Focus();
                    }
                    else
                    {
                        lblmsg.Text = "Something went wrong.Please Contact Support Team";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }

        }

        protected void ddlCrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList list = (DropDownList)sender;
            string value = (string)list.SelectedValue;
            if (value.Equals("0"))
            {
                LoadDataList("landing", value);
            }
            else
            {
                LoadDataList("crop", value);
            }

        }
        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList list = (DropDownList)sender;
            string value = (string)list.SelectedValue;
            if (value.Equals("0"))
            {
                LoadDataList("landing", value);
            }
            else
            {
                LoadDataList("state", value);
            }

        }
        private void GetCropDetails()
        {
            DataTable resultData = new DataTable();
            BusinessLayer.BusinessLogic business = new BusinessLayer.BusinessLogic();
            try
            {
                resultData = business.GetTableDetails(ConfigurationManager.AppSettings["Crop_Info"].ToString());
                ddlCrop.DataSource = resultData;
                if (resultData.Rows.Count > 0)
                {
                    ddlCrop.DataTextField = "Crop_Name";
                    ddlCrop.DataValueField = "Id";
                    ddlCrop.DataBind();
                }
                ddlCrop.Items.Insert(0, new ListItem("--Select Crop--", "0"));
            }
            catch (Exception ex)
            {

            }
        }
        private void GetStateDetails()
        {
            DataTable resultData = new DataTable();
            BusinessLayer.BusinessLogic business = new BusinessLayer.BusinessLogic();
            try
            {
                resultData = business.GetTableDetails(ConfigurationManager.AppSettings["State_Info"].ToString());

                if (resultData.Rows.Count > 0)
                {
                    ddlState.DataSource = resultData;
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
    }
}