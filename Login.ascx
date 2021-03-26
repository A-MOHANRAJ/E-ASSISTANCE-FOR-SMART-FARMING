<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="Onliine_Agro_Products_System.Login1" %>





<p style="padding:2px;background-color:darkgreen;font-family:'Trebuchet MS';font-weight:bold;color:white" align="right">
 
     <table style="background-color: darkgreen; width: 100%;">
    <tr>
        <td colspan="2" style="color:white;text-align:right" >Welcome,&nbsp;<asp:Label ID="lblUserName" runat="server"></asp:Label>&nbsp;&nbsp;  </td>
    </tr>
    <tr>
<td><asp:Button ID="btnHome" runat="server" Text="My Account" style="font-weight: 700;margin-right:510px;" OnClick="btnHome_Click" /></td>
 <td> <asp:Button ID="btnRegister" Text="Logout" runat="server" Width="83px"  style="font-weight: 700" OnClick="btnRegister_Click" />&nbsp;&nbsp;   </td>
    </tr>
</table>
    
   
    </p>