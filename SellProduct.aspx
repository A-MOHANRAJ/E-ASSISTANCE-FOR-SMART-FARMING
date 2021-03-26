<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Layout_Farmer.Master" AutoEventWireup="true" CodeBehind="SellProduct.aspx.cs" Inherits="Onliine_Agro_Products_System.SellProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style1 {
            width: 132px;
        }
        table, th, td {
  border: 0px solid black;
  padding: 3px;
}
table {
  border-spacing: 0px;
}
    </style>

    <script type="text/javascript">
        function ValidateAll() {
         
            var crop = document.getElementById("<%= ddlCrop.ClientID %>");
            var qty = document.getElementById("<%= txtQty.ClientID %>");
            var unit = document.getElementById("<%= ddlUnit.ClientID %>");
            if (crop.value == "0") {
                alert("Please Select Crop");
                crop.focus();
                return false;
            }
            if (qty.value == "") {
                alert("Please Enter Quantity");
                qty.focus();
                return false;
            }     
            if (unit.value == "0") {
                alert("Please Select Unit");
                unit.focus();
                return false;
            }
            return true;
        }

    function onlyNumbers(event) {
             var charCode = (event.which) ? event.which : event.keyCode
             if (charCode > 31 && (charCode < 48 || charCode > 57))
                 return false;

             return true;
         }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3><asp:Label ID="lblheading" runat="server" Text="Sell Product"></asp:Label> </h3>
    <div>
        <table >
            <tr>
                <td class="auto-style1"><strong>Select Crop<span style="color:red"> *</span></strong></td>
                <td colspan="2">
                    <strong>
                         <asp:DropDownList ID="ddlCrop" runat="server" Width="252px" Height="26px">
                             
                         </asp:DropDownList>

                    </strong>
                    </td>
                </tr>
            
            <tr>
                <td class="auto-style1"><strong style="width:170px!important">Quantity<span style="color:red"> *</span></strong></td>
                <td><strong><asp:TextBox ID="txtQty" runat="server" Width="247px" Height="26px" onkeypress="return onlyNumbers(event)"></asp:TextBox></strong></td>
            </tr>
              <tr>
                <td class="auto-style1"><strong>Unit<span style="color:red"> *</span></strong></td>
                <td colspan="2">
                    <strong>
                        <asp:DropDownList ID="ddlUnit" runat="server" Width="252px" Height="26px">
                      
                        </asp:DropDownList>
                    </strong>
                    </td>
                </tr>                
             <tr>
                <td class="auto-style1"><strong>Remarks</strong></td><td><strong><asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine"  Width="248px" Height="72px"></asp:TextBox></strong></td>
            </tr>
                           
            <tr>
                <td colspan="2">
                    <span style="color:red"> * marked fields are mandatory</span> .
                </td>
            </tr>

            <tr>
                  <td></td>
                <td style="padding-top:20px"><strong><asp:Button ID="btnRegister" Text="Submit" runat="server" Width="83px"  style="font-weight: 700" OnClick="btnRegister_Click" 
OnClientClick="return ValidateAll()" /></strong></td>             
            </tr>
            <tr>
                <td colspan="2">
                    <strong>
                  <br />  <asp:Label runat="server" ID="lblMsg"></asp:Label>
                    </strong>
                </td>
            </tr>
           
        </table>
        </div>
</asp:Content>
