<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Layout_Common.Master" AutoEventWireup="true" CodeBehind="SignupFarmer.aspx.cs" Inherits="Onliine_Agro_Products_System.SignupFarmer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 132px;
        }

        .myclas {
            color: red;
        }

        table, tr, td {
            border: 0px solid black;
            padding: 3px;
        }

        table {
            border-spacing: 0px;
        }
    </style>

    <script type="text/javascript">

        function ValidateAll() {            
            
            var farmerName = document.getElementById("<%= txtFarmerName.ClientID %>");
            var email = document.getElementById("<%= txtEmail.ClientID %>");
            var contactNo = document.getElementById("<%= txtContactno.ClientID %>");
            var address = document.getElementById("<%= txtAddress.ClientID %>");
            var state = document.getElementById("<%= ddlState.ClientID %>");
            var district = document.getElementById("<%= ddlDistrict.ClientID %>");
            var userName = document.getElementById("<%= txtUserName.ClientID %>");
            var password = document.getElementById("<%= txtPassword.ClientID %>");        
          
         
            if (farmerName.value == "") {
                alert("Please Enter Your Name");
                farmerName.focus();
                return false;
            }
            if (email.value == "") {
                alert("Please Enter Your Email");
                email.focus();
                return false;
            }                     
            if (contactNo.value == "") {
                alert("Please Enter Your Contact Number");
                contactNo.focus(); return false;

            }
            if (contactNo.value.length < 10) {
                alert("Contact Number Should be 10 Digits");
                contactNo.focus(); return false;
            }
            if (address.value == "") {
                alert("Please Enter Your Address");
                address.focus(); return false;
            }
            if (state.value == "0") {
                alert("Please Select Your State");
                state.focus(); return false;
            }
            if (state.value != "0") {
                if (district.value == "0") {
                    alert("Please Select Your District");
                    district.focus(); return false;
                }
            }
            if (userName.value == "") {
                alert("Please Enter Your User Name");
                userName.focus();
                return false;
            }
            if (userName.value.length < 5) {
                alert("UserName is too Short");
                userName.focus();
                return false;
            }   
            if (password.value == "") {
                alert("Please Enter Your Password");
                password.focus();
                return false;
            }
            if (password.value.length < 5) {
                alert("Password is too short");
                password.focus();
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
    <h3>
        <asp:Label ID="lblheading" runat="server" Text="New Farmer Registration"></asp:Label>
    </h3>
    <div style="margin-left: 74px!important">
        <table>
            <tr>
                <td class="auto-style1"><strong style="width: 170px!important">Name<span style="color: red"> *</span></strong></td>
                <td><strong>
                    <asp:TextBox ID="txtFarmerName" runat="server" Width="247px" Height="26px"></asp:TextBox></strong></td>
            </tr>
            <tr>
                <td class="auto-style1"><strong>Email<span style="color: red"> *</span></strong></td>
                <td><strong>
                    <asp:TextBox ID="txtEmail" runat="server" Width="247px" Height="26px"></asp:TextBox></strong></td>
            </tr>
            <tr>
                <td class="auto-style1"><strong>Contact no<span style="color: red"> *</span></strong></td>
                <td><strong>
                    <asp:TextBox ID="txtContactno" onkeypress="return onlyNumbers(event)" runat="server" MaxLength="10" Width="247px" Height="26px"></asp:TextBox></strong></td>
            </tr>
            <tr>
                <td class="auto-style1"><strong>Address<span style="color: red"> *</span></strong></td>
                <td><strong>
                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Width="248px" Height="72px"></asp:TextBox></strong></td>
            </tr>
            <tr>
                <td class="auto-style1"><strong>City</strong></td>
                <td><strong>
                    <asp:TextBox ID="txtCity" runat="server" Width="247px" Height="26px"></asp:TextBox></strong></td>
            </tr>
            <tr>
                <td class="auto-style1"><strong>State<span style="color: red"> *</span></strong></td>
                <td colspan="2">
                    <strong>
                        <asp:DropDownList ID="ddlState" runat="server" Width="252px" Height="26px"
                            OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>

                    </strong>
                </td>
            </tr>
            <tr>
                <td class="auto-style1"><strong>District<span style="color: red"> *</span></strong></td>
                <td colspan="2">
                    <strong>
                        <asp:DropDownList ID="ddlDistrict" runat="server" Width="252px" Height="26px">
                        </asp:DropDownList>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="auto-style1"><strong>Farmer Card no</strong></td>
                <td><strong>
                    <asp:TextBox ID="txtFarmerCardNo" runat="server" Width="247px" Height="26px"></asp:TextBox></strong></td>
            </tr>
            <tr>
                <td class="auto-style1"><strong>Photo</strong></td>
                <td>
                    <asp:Image ID="imgprofile" runat="server" Height="130" Width="130" Visible="false" BorderColor="#FF9933" BorderStyle="Dotted" BorderWidth="1px" />
                    &nbsp;<asp:FileUpload runat="server" ID="photoUpload" /></td>
            </tr>
            <tr>
                <td class="auto-style1"><strong>UserName<span style="color: red"> *</span></strong></td>
                <td><strong>
                    <asp:TextBox ID="txtUserName" runat="server" Width="247px" Height="26px"></asp:TextBox></strong></td>
            </tr>
            <tr>
                <td class="auto-style1"><strong>Password<span style="color: red"> *</span></strong></td>
                <td><strong>
                    <asp:TextBox ID="txtPassword" runat="server" Width="247px" Height="26px" TextMode="Password"></asp:TextBox></strong></td>
            </tr>
            <tr>
                <td colspan="2">
                    <span style="color: red">* marked fields are mandatory</span>
                </td>
            </tr>

            <tr>
                <td class="auto-style1" style="padding-top: 20px"><strong>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="83px" Style="font-weight: 700" OnClick="btnCancel_Click" /></strong></td>
                <td style="padding-top: 20px"><strong>
                    <asp:Button ID="btnRegister" Text="Register" runat="server" Width="83px" Style="font-weight: 700" OnClientClick="return ValidateAll()" OnClick="btnRegister_Click" /></strong></td>
            </tr>
            <tr>
                <td colspan="2">
                    <strong>
                        <br />
                        <asp:Label runat="server" ID="lblMsg"></asp:Label>
                    </strong>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:LinkButton ID="linkRedirect" runat="server" Visible="false">View Dashboard</asp:LinkButton>
                </td>
            </tr>
        </table>

    </div>
</asp:Content>
