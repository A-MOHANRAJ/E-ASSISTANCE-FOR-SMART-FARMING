<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index-1.aspx.cs" Inherits="Onliine_Agro_Products_System.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body  style="background-color: #0066FF">
    <form id="form1" runat="server">
        <div>
           
            <asp:TextBox ID="txtPassword" runat="server" BorderStyle="Outset" style="z-index: 1; left: 302px; top: 269px; position: absolute; width: 371px; height: 23px" ></asp:TextBox>
           
            <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 301px; top: 166px; position: absolute" Text="Username" Font-Underline="True"></asp:Label>
            <br />
            
            
            <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 302px; top: 241px; position: absolute" Text="Password" Font-Underline="True"></asp:Label>
            
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Font-Overline="False" Font-Size="XX-Large" Font-Underline="True" style="z-index: 1; left: 293px; top: 102px; position: absolute; width: 108px" Text="LOGIN"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" style="z-index: 1; left: 303px; top: 198px; position: absolute; width: 366px; height: 23px"></asp:TextBox>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            
        </div>
        <p>
            <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" style="z-index: 1; left: 500px; top: 345px; position: absolute; bottom: 192px" BorderStyle="Outset" />
            <asp:Button ID="Button1" runat="server" BorderStyle="Outset" style="z-index: 1; left: 316px; top: 345px; position: absolute" Text="Cancel" />
        </p>
    </form>
</body>
</html>
