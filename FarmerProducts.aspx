<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Layout_Common.Master" AutoEventWireup="true" UnobtrusiveValidationMode="None" CodeBehind="FarmerProducts.aspx.cs" Inherits="Onliine_Agro_Products_System.FarmerProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Farmer Products</h3>
    <b>
        <asp:Label ID="lblmsg" runat="server"></asp:Label></b>
    <% if (string.IsNullOrEmpty(Session["Master_Type_ID"] as string))
        { }
        else if (Session["Master_Type_ID"].Equals("2"))
        { %>
    <i style="color: maroon; display: block; background-color: khaki">Only Dealer are allowed to send Request</i><%} %>
    <%if (dataAvailable)
        { %>
    <div style="height: 40px; padding: 3px">

        <b>Filter By </b>&nbsp;<b>State:</b>&nbsp;
        <asp:DropDownList ID="ddlState" runat="server" Width="252px" Height="36px"
            OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true">
        </asp:DropDownList>&nbsp;&nbsp;<b>Crop:</b>;&nbsp;
        <strong>
            <asp:DropDownList ID="ddlCrop" runat="server" Width="252px" Height="36px" OnSelectedIndexChanged="ddlCrop_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
        </strong>
    </div>
    <%} %>
    <div style="padding: 25px">
        <asp:DataList ID="dlProduct" runat="server" RepeatDirection="Vertical" Width="700px" OnItemCommand="dlProduct_ItemCommand">
            <ItemTemplate>
                <div style="width: 100%; border: 1px solid goldenrod; padding: 5px; background-color: ghostwhite; line-height: 23px">
                    <span style="font-size: 16px; font-weight: bold; color: peru; padding: 2px;">Product:&nbsp;&nbsp</span> <%# Eval("Crop_Name") %><span></span>
                    <span style="font-size: 13px; font-weight: bold; padding-left: 320px">Posted On:&nbsp;</span><%# Eval("Posted_On") %><div style="border-bottom: 1px solid violet;"></div>

                    <div style="padding: 2px">
                        <span style="font-size: 13px; font-weight: 600">Posted Qty:&nbsp;&nbsp</span><span style="color: blue; font-weight: 600"><%# Eval("Qty") %>&nbsp;<%# Eval("Unit") %>&nbsp;</span>
                        <span style="font-size: 13px; font-weight: 600">Current Available Qty:&nbsp;&nbsp</span><span style="color: forestgreen; font-weight: 600"><asp:Label ID="lblavailbleQty" runat="server" Text='<%# Eval("ToSale") %>'></asp:Label>
                            &nbsp;<%# Eval("Unit") %>&nbsp</span>
                    </div>
                    <span style="font-size: 13px; font-weight: 600">State:&nbsp;&nbsp</span><%# Eval("State_Name") %>
                    <div style="padding: 2px">
                        <span style="font-size: 13px; font-weight: 600">Farmer:&nbsp;&nbsp</span><%# Eval("Name") %>&nbsp;&nbsp;
                    </div>
                    <asp:Label Visible="false" runat="server" ID="lbl1" Text='<%# Eval("FP_ID") %>'></asp:Label>

                    <asp:Label Visible="false" runat="server" ID="lbl3" Text='<%# Eval("UNT_ID") %>'></asp:Label>
                    <div style="padding: 2px">
                        <span style="font-size: 13px; font-weight: 600">Address:&nbsp;&nbsp</span><%# Eval("Address") %>&nbsp;&nbsp;
                    </div>
                    <div style="padding: 2px">
                        <div><span style="font-size: 13px; font-weight: 600">Contact:</span> &nbsp;&nbsp;<%# Eval("Contact_No") %><span style="font-size: 13px; font-weight: 600">&nbsp;&nbsp;Email:&nbsp;&nbsp</span><%# Eval("Email") %></div>
                        <div style="padding: 2px">
                            <span style="font-size: 13px; font-weight: 600">Product Remarks:&nbsp;&nbsp</span><%# Eval("Remarks") %>&nbsp;&nbsp;
                 <% if (string.IsNullOrEmpty(Session["Master_Type_ID"] as string))
                     { %>
                            <div style="text-align: right; font-weight: bolder; font-size: 14px; color: crimson!important; border: 1px solid grey!important; margin-left: 380px; margin-left: 535px; padding-right: 3px; background-color: antiquewhite;">
                                <asp:LinkButton Text="Login to Send Request" PostBackUrl="~/Login.aspx" runat="server"></asp:LinkButton>
                            </div>
                            <%}
                                else if (Session["Master_Type_ID"].Equals("3"))
                                { %>
                            <div style="text-align: right">
                                <span style="font-size: 13px; font-weight: 600">Required Qty:&nbsp;</span>&nbsp;<asp:TextBox ID="txtQty" runat="server" BorderStyle="Solid" BorderWidth="2px"
                                    BorderColor="#0099cc" Width="90" Height="30" TextMode="Number"></asp:TextBox>
                                &nbsp;&nbsp;
                                <asp:Button ID="btnPopup" runat="server"
                                    Text="Send Request" Font-Bold="true" BackColor="#66ff66" CommandName="request" CommandArgument='<%#Eval("FP_ID")+","+ Eval("UNT_ID")+","+ Eval("ToSale")%>' />                           


                            </div>
                            <%} %>
                        </div>
                    </div>
                    <asp:Label ID="lblItemText" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>


            </ItemTemplate>
        </asp:DataList>
    </div>


</asp:Content>
