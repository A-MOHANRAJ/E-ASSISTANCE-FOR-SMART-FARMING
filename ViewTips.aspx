<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Layout_Common.Master" AutoEventWireup="true" CodeBehind="ViewTips.aspx.cs" Inherits="Onliine_Agro_Products_System.ViewTips" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h3>Farming Tips</h3>
     <div style="padding: 25px">
        <asp:DataList ID="dlTips" runat="server" RepeatDirection="Vertical" Width="700px" >
            <ItemTemplate>
                <div style="width: 100%; border: 1px solid goldenrod; padding: 5px; background-color: ghostwhite; line-height: 23px">
                    <span style="font-size:14px;color:royalblue;font-weight:600">Tips For:&nbsp;&nbsp;<%# Eval("Tips_Details") %></span><div style="border-bottom: 1px solid violet;"></div>
                    <div>
                        <b>Description</b>
                        <span style="display:block;padding:7px;text-align:justify"><%# Eval("Tips_Description") %> </span>
                    </div>
                    <div>
                       <i style="color:black"> Posted On :&nbsp;&nbsp;<%# Eval("Posted_On") %></i></div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
         </div>
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
</asp:Content>
