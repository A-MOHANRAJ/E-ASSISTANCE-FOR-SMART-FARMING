<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Layout_Common.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Onliine_Agro_Products_System.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ValidateAll() {
         
            var userName = document.getElementById("<%= txtUserName.ClientID %>");
            var password = document.getElementById("<%= txtPassword.ClientID %>");
            if (userName.value == "") {
                alert("Please Enter Your Name");
                userName.focus();
                return false;
            }
            else if (password.value == "") {
                alert("Please Enter Your Password");
                password.focus();
                return false;
            }            
        }
    </script>
    <style type="text/css">
        .auto-style1 {
            width: 111px;
            font-weight: 700;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3><strong>&nbsp;&nbsp;Login</strong></h3>
    <div align="right" style="font-size: 14px; font-weight: 600;"><a href="SignupFarmer.aspx" style="color:mediumblue!important">Register as Farmer</a> | <a href="SignupDealer.aspx">Register as Dealer&nbsp;&nbsp;</a></div>
    <div style="border: 2px solid salmon;padding:5px; margin: 95px;margin-top: 29px!important; background-color: antiquewhite; font-size: 13px; ">
       <table><tr><td>
        <asp:Image ID="imgLogin" runat="server" ImageUrl="~/login.png" Height="165" Width="165" /></td><td>
        <table>
            <tr style="height: 45px">
                <td class="auto-style1"><strong>Username</strong></td>
                <td><strong>
                    <asp:TextBox ID="txtUserName" runat="server" Width="167px" Height="25px" BorderColor="#808080" BorderWidth="1px" BorderStyle="Solid"></asp:TextBox></strong></td>
            </tr>
            <tr style="height: 45px">
                <td class="auto-style1"><strong>Password</strong></td>
                <td><strong>
                    <asp:TextBox ID="txtPassword" runat="server" Width="167px" TextMode="Password" Height="25px" BorderColor="#808080" BorderWidth="1px" BorderStyle="Solid"></asp:TextBox></strong></td>
            </tr>
            <tr style="height: 45px">
                <td><strong>Login As</strong></td>
                <td colspan="2">
                    <strong>
                        <asp:DropDownList ID="ddlUserType" runat="server" Width="155px" Height="30px"></asp:DropDownList>
                    </strong>
                </td>
            </tr>
            <tr style="height: 45px">
                <td><strong>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="83px" Style="font-weight: 700" OnClick="btnCancel_Click" /></strong></td>
                <td><strong>
                   &nbsp; <asp:Button ID="btnSubmit" Text="Login" runat="server" Width="83px" OnClick="btnSubmit_Click" OnClientClick="return ValidateAll()" Style="font-weight: 700" /></strong>

                           
                </td>
            </tr>
            <tr>
                <td colspan="2"> <span style="display:block;font-weight:600"><asp:Label runat="server" ID="lblLoginMsg"></asp:Label></span></td>
            </tr>
         
        </table></td>
</tr></table>
    </div>
</asp:Content>
