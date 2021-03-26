<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Layout_Admin.Master" AutoEventWireup="true" CodeBehind="Admin_DailyPrice.aspx.cs" Inherits="Onliine_Agro_Products_System.Admin_DailyPrice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Daily Price Details</h3>
    <b>State:</b>&nbsp; <strong>
                         <asp:DropDownList ID="ddlState" runat="server" Width="152px" Height="26px"
                             OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true">
                             
                         </asp:DropDownList>

                    </strong>&nbsp <b>District:</b>    <strong>
                        <asp:DropDownList ID="ddlDistrict" runat="server" Width="152px" Height="26px">
                      
                        </asp:DropDownList>
                    </strong>
        &nbsp Date: &nbsp <asp:Label ForeColor="Red" Font-Bold="true" Font-Size="Small" runat="server" Text="DD-MMM-YY"></asp:Label>          
    <asp:Panel ScrollBars="Horizontal" style="width:555px" runat="server">
<asp:GridView ID="gridProduct" runat="server" AutoGenerateColumns="false" ShowFooter="false" PageSize="10" 
    AllowPaging="true" CssClass="auto-style1" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" 
    EmptyDataText="No Records Found" OnPageIndexChanging="gridProduct_PageIndexChanging" Width="533px">
        <Columns>
    <asp:TemplateField HeaderText="S.No" ItemStyle-Width="7px">
                <ItemTemplate>
                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>  

            <asp:TemplateField ItemStyle-Width="50px" HeaderText="Crop">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server"
                        Text='<%#Eval("Tips_Details")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField ItemStyle-Width="50px" HeaderText="Description">
                <ItemTemplate>
                    
             <asp:HyperLink ToolTip='<%#Eval("Tips_Description")%>' Text="View" runat="server" ID="hypDescription"></asp:HyperLink>
                  
                </ItemTemplate>
            </asp:TemplateField>            
           
             <asp:TemplateField ItemStyle-Width="50px" HeaderText="Posted On">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server"
                        Text='<%#Eval("Posted_On")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField ItemStyle-Width="50px" HeaderText="Author">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server"
                        Text='<%#Eval("Author")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
               
        </Columns>
        <EmptyDataTemplate>
        <asp:Label ID="lblEmptyTxt" runat="server" Text="No Data Found"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
        </asp:Panel>
</asp:Content>
