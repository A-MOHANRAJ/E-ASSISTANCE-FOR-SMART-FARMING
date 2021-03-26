<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Layout_Farmer.Master" AutoEventWireup="true" CodeBehind="FarmerTransaction.aspx.cs" Inherits="Onliine_Agro_Products_System.FarmerTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style style="text/css">
      table,tr,td{
        border:0px solid black;
        padding:3px;
    }
      .mydatagrid
{
width: 80%;
border: solid 2px black;
min-width: 80%;
}
.header
{
background-color: #646464;
font-family: 'Trebuchet MS';
color: White;
border: none 0px transparent;
height: 25px;
text-align: center;
font-size: 14px;
}

.rows
{
background-color: #fff;
font-family: 'Trebuchet MS';
font-size: 13px;
color: #000;
min-height: 25px;
text-align: left;
border: none 0px transparent;
}
.rows:hover
{
background-color: moccasin;
font-family: 'Trebuchet MS';
color: #fff;
text-align: left;
}
.selectedrow
{
background-color: #ff8000;
font-family: 'Trebuchet MS';
color: #fff;
font-weight: bold;
text-align: left;
}
.mydatagrid a /** FOR THE PAGING ICONS **/
{
background-color: Transparent;
padding: 5px 5px 5px 5px;
color: #bf2020;
text-decoration: none;
font-weight: bold;
}

.mydatagrid a:hover /** FOR THE PAGING ICONS HOVER STYLES**/
{
background-color: #000;
color: #fff;
}
.mydatagrid span /** FOR THE PAGING ICONS CURRENT PAGE INDICATOR **/
{

color: #000;
padding: 5px 5px 5px 5px;
}
.pager
{
background-color: #646464;
font-family: 'Trebuchet MS';
color: White;
height: 30px;
text-align: left;
}

.mydatagrid td
{
padding: 5px;
}
.mydatagrid th
{
padding: 5px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3><asp:Label ID="lblheading" runat="server" Text="Product Transaction Details"></asp:Label> </h3>
   <table>
       <tr>
            <td colspan="1"><strong>Pick Product</strong></td>
            <td colspan="3"><asp:DropDownList ID="ddlMyProduct" runat="server" Width="252px" Height="26px"
                             AutoPostBack="true" OnSelectedIndexChanged="ddlMyProduct_SelectedIndexChanged">
                             
                         </asp:DropDownList></td>
        </tr>
   </table>
    <asp:panel id="pnlDetails" runat="server" >
    <table>       
        <tr>
            <td><strong> Crop Name&nbsp;&nbsp;</strong></td><td><asp:Label ID="lblCrop" runat="server" width="180px" ></asp:Label> </td>
            <td><strong> Posted On&nbsp;&nbsp;</strong></td><td><asp:Label ID="lblDate" runat="server" width="180px"></asp:Label></td>
        </tr>
          <tr>
            <td><strong> Selling Qty&nbsp;&nbsp;</strong> </td><td><asp:Label ID="lblSellingQty" runat="server" width="180px" ></asp:Label></td>
              <td><strong> Unit&nbsp;&nbsp;</strong> </td><td><asp:Label ID="lblUnit" runat="server" width="180px" ></asp:Label></td>
        </tr>
          <tr>
            <td><strong> Sold Qty&nbsp;&nbsp;</strong> </td><td><asp:Label ID="lblSoldQty" runat="server" width="180px"></asp:Label></td>
              <td><strong> Status&nbsp;&nbsp;</strong> </td><td><asp:Label ID="lblStatus" runat="server" width="180px"></asp:Label></td>
        </tr>
    </table>
    <br />
   <div class="subheader">   <span>Dealer Transaction</span> </div> <br />
    <asp:GridView ID="gridProduct" runat="server" AutoGenerateColumns="false" ShowFooter="false" PageSize="10" AllowPaging="true" CssClass="mydatagrid" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" Width="517px" EmptyDataText="No Records Found" OnPageIndexChanging="gridProduct_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="S.No" ItemStyle-Width="7px">
                <ItemTemplate>
                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField ItemStyle-Width="50px" HeaderText="Dealer">
                <ItemTemplate>
                    <asp:Label ID="lblID" runat="server"
                        Text='<%#Eval("Dealer")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField ItemStyle-Width="50px" HeaderText="Purchased Qty">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server"
                        Text='<%#Eval("Purchased_Qty")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField ItemStyle-Width="50px" HeaderText="Unit">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server"
                        Text='<%#Eval("Unit_Name")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>            
           
             <asp:TemplateField ItemStyle-Width="50px" HeaderText="Purchased On">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server"
                        Text='<%#Eval("Purchased_On")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             
        </Columns>
        <EmptyDataTemplate>
        <asp:Label ID="lblEmptyTxt" runat="server" Text="No Data Found"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
        </asp:panel>
</asp:Content>
