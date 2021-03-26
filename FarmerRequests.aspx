<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Layout_Farmer.Master" AutoEventWireup="true" CodeBehind="FarmerRequests.aspx.cs" Inherits="Onliine_Agro_Products_System.FarmerRequests" %>
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
    <h3>My Requests</h3> 
    <asp:Panel  style="width:555px" runat="server">
<asp:GridView ID="gridProduct" runat="server" AutoGenerateColumns="false" ShowFooter="false" PageSize="10" 
    AllowPaging="true" CssClass="mydatagrid" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" 
    EmptyDataText="No Records Found" OnPageIndexChanging="gridProduct_PageIndexChanging">
        <Columns>
    <asp:TemplateField HeaderText="S.No" ItemStyle-Width="7px">
                <ItemTemplate>
                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>  

            <asp:TemplateField ItemStyle-Width="50px" HeaderText="Crop">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server"
                        Text='<%#Eval("Crop_Name")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField ItemStyle-Width="50px" HeaderText="Qty">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server"
                        Text='<%#Eval("Qty")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>            
           
             <asp:TemplateField ItemStyle-Width="50px" HeaderText="Dealer">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server"
                        Text='<%#Eval("Dealer")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField ItemStyle-Width="50px" HeaderText="Contact">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server"
                        Text='<%#Eval("Contact")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField ItemStyle-Width="50px" HeaderText="Approved">
                <ItemTemplate>                    
                    <asp:CheckBox ID="chkApproved" runat="server" Checked='<%#Eval("IsApproved").ToString().Equals("1")%>' Enabled="false" />
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField ItemStyle-Width="50px" HeaderText="Rejected">
                <ItemTemplate>
                   <asp:CheckBox ID="chkRejected" runat="server" Checked='<%#Eval("IsRejected").ToString().Equals("1")%>' Enabled="false" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
        <asp:Label ID="lblEmptyTxt" runat="server" Text="No Data Found"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
        </asp:Panel>
     
</asp:Content>
