<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Layout_Dealer.Master" AutoEventWireup="true" CodeBehind="DealerDashboard.aspx.cs" Inherits="Onliine_Agro_Products_System.DealerDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style1 {
            margin-left: 6px;
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
    <script type="text/javascript">
    function ValidateAll() {

        var password = document.getElementById("<%= txtPassword.ClientID %>");
        var rePassword = document.getElementById("<%= txtRePassword.ClientID %>");
        if (password.value == "") {
               alert("Please Enter Your New Password");
            password.focus();
                return false;
            }
        if (rePassword.value == "") {
                alert("Please Re-Enter Your Password");
            rePassword.focus();
                return false;
        }
        if (password.value.length < 5) {
            alert("Password is too short");
            password.focus();
            return false;
        }
        if (rePassword.value.length < 5) {
            alert("Password is too short");
            rePassword.focus();
            return false;
        }
        if (password != rePassword) {
            alert("Password Doesn't Match");
            password.focus();
            return false;
        }
    }
    function clearAll() {
        var password = document.getElementById("<%= txtPassword.ClientID %>");
        var rePassword = document.getElementById("<%= txtRePassword.ClientID %>");
        password.value = "";
        repassword.value = "";
        password.focus();
        return false;
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlDashboard" runat="server"> 
    <h3>My Dashboard</h3>
    <asp:GridView ID="gridProduct" runat="server" AutoGenerateColumns="false" ShowFooter="false" PageSize="6" AllowPaging="true" CssClass="mydatagrid" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" Width="517px" EmptyDataText="No Records Found" OnPageIndexChanging="gridProduct_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="S.No" ItemStyle-Width="10">
                <ItemTemplate>
                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField ItemStyle-Width="50px" HeaderText="Created">
                <ItemTemplate>
                    <asp:Label ID="lblID" runat="server"
                        Text='<%#Eval("CreatedOn")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField ItemStyle-Width="50px" HeaderText="Crop Name">
                <ItemTemplate>
                    <asp:Label ID="lblID" runat="server"
                        Text='<%#Eval("Crop_Name")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField ItemStyle-Width="50px" HeaderText="Quantity">
                <ItemTemplate>
                    <asp:Label ID="lblID" runat="server"
                        Text='<%#Eval("Request_Qty")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField ItemStyle-Width="50px" HeaderText="UOM">
                <ItemTemplate>
                    <asp:Label ID="lblID" runat="server"
                        Text='<%#Eval("Unit_Name")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField ItemStyle-Width="50px" HeaderText="Status">
                <ItemTemplate>
                    <asp:Label ID="lblID" runat="server"
                        Text='<%#Eval("Status_Name")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             
        </Columns>
        <EmptyDataTemplate>
        <asp:Label ID="lblEmptyTxt" runat="server" Text="No Data Found"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
        </asp:Panel>
    <asp:Panel ID="pnlPassword" runat="server" Visible="false">
<h3>Change Password</h3>
          <div>
        <table>
            <tr>
                <td class="auto-style1"><strong>New Password</strong></td><td><strong>
                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" Width="147px">

                    </asp:TextBox></strong></td>
            </tr>
             <tr>
                <td class="auto-style1"><strong>Re-enter Password</strong></td><td><strong>
                    <asp:TextBox ID="txtRePassword" TextMode="Password" runat="server" Width="147px" ></asp:TextBox></strong>

                                                                               </td>
            </tr>
                   <tr>
                  <td><strong><asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="83px" style="font-weight: 700" OnClientClick="return clearAll()"  /></strong></td>
                <td><strong><asp:Button ID="btnSubmitPassword" Text="Change" runat="server" Width="83px" OnClientClick="return ValidateAll()" style="font-weight: 700" OnClick="btnSubmitPassword_Click" /></strong></td>             
            </tr>
            <tr>
                <td colspan="2">
                    <strong>
                  <br />  <asp:Label runat="server" ID="lblMsg" ></asp:Label>
                    </strong>
                </td>
            </tr>
        </table>

    </div>

    </asp:Panel>&nbsp;
</asp:Content>
