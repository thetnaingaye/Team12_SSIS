<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApprovePurchaseOrder.aspx.cs" Inherits="Team12_SSIS.StoreManager.StoreSupervisor.ApprovePurchaseOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 98px;
        }
        .auto-style2 {
            width: 98px;
            height: 24px;
        }
        .auto-style3 {
            height: 24px;
        }
        .auto-style4 {
            width: 98px;
            height: 21px;
        }
        .auto-style5 {
            height: 21px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div><h1> 
    <asp:Label ID="Label1" runat="server" style="text-align: center" Text="Purchase Order Approval"></asp:Label></h1>
        <table><tr><td class="auto-style1">
            <asp:Label ID="LblPo" runat="server" Text="PO#:"></asp:Label>
            <td><asp:Label ID="LblNumbeer" runat="server"></asp:Label></td>
            </td></tr>
            <tr><td class="auto-style1">
                <asp:Label ID="LblDsm" runat="server" Text="Date Submitted:"></asp:Label>
            <td><asp:Label ID="LblDate" runat="server"></asp:Label></td>
            </td></tr>
            <tr><td class="auto-style1">
                <asp:Label ID="LblPos" runat="server" Text="PO Status:"></asp:Label>
            <td class="auto-style3"><asp:Label ID="LblStatus" runat="server" Text="Pending"></asp:Label></td>
            </td></tr>
            <tr><td class="auto-style1">
                <asp:Label ID="LblDlt" runat="server" Text="Deliver to:"></asp:Label>
            <td><asp:Label ID="LblDeliver" runat="server"></asp:Label></td>
            </td></tr>
            <tr><td class="auto-style4">
                <asp:Label ID="LblAds" runat="server" Text="Address:"></asp:Label>
            <td class="auto-style5"><asp:Label ID="LblAddress" runat="server"></asp:Label></td>
            </td></tr>
            <tr><td class="auto-style4">
                <asp:Label ID="LblRes" runat="server" Text="Requested by:"></asp:Label>
            <td class="auto-style5"><asp:Label ID="LblRequest" runat="server"></asp:Label></td>
            </td></tr>
                <tr><td class="auto-style1">
                <asp:Label ID="LblSlc" runat="server" Text="Supplier Code:"></asp:Label>
            <td><asp:Label ID="LblCode" runat="server"></asp:Label></td>
            </td></tr>
            <tr><td class="auto-style1">
                <asp:Label ID="LblOdb" runat="server" Text="Ordered by:"></asp:Label>
            <td><asp:Label ID="LblOrder" runat="server" Text="Logic University Stationery Store"></asp:Label></td>
            </td></tr>
            </table>
                 <asp:ScriptManager ID="sml" runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel ID="Upl" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                <ContentTemplate>
                 <asp:GridView ID="GridViewAPO" runat="server" AutoGenerateColumns="False"
                      Style="height: 100px; overflow: auto" ShowHeaderWhenEmpty="True"
                                        OnRowDataBound="OnRowDataBound"
                                        CellPadding="4" ForeColor="#333333" GridLines="None" >
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>

                            <asp:TemplateField HeaderText="Description" HeaderStyle-Width="52%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblDesc" runat="server"></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="52%"></HeaderStyle>
                            </asp:TemplateField>

                           <asp:TemplateField HeaderText="Quantity">
                                    <ItemTemplate>
                                        <asp:UpdatePanel runat="server" ID="UpValue" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                                        <ContentTemplate>
                                        <asp:Label ID="Lblquantity" runat="server" Text='<%# Bind("Quantity") %>' OnTextChanged="Txtquantity_TextChanged" AutoPostBack="true"></asp:Label>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                    </ItemTemplate>
                               <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="10%"></HeaderStyle>
                                </asp:TemplateField>

                            <asp:TemplateField HeaderText="UOM" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblUom" runat="server" Text='<%# Bind("UOM") %>'></asp:Label>
                                                </ItemTemplate>

                                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unit Price" HeaderStyle-Width="22%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblUnp" runat="server" Width="100%" CssClass="center-block" Text=""></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="22%"></HeaderStyle>
                            </asp:TemplateField>
                <asp:TemplateField HeaderText="Price" HeaderStyle-Width="22%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblPrice" runat="server" Width="100%" CssClass="center-block" Text=""></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="22%"></HeaderStyle>
                            </asp:TemplateField>
            </Columns>
                                         <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

        </asp:GridView> 

                                </ContentTemplate>
                            </asp:UpdatePanel>

       </tr>
            <tr><td class="auto-style1"> <asp:Label ID="LblRmk" runat="server" Text="Remarks :"></asp:Label></td>
                <td><asp:TextBox ID="txtRmk" runat="server"></asp:TextBox> 
                   </tr></td>
            <tr>
                <td class="auto-style2">
                    <td><td><td><td> <td >
                <asp:Button ID="btnapr" runat="server" Text="Approve" Height="27px" Width="64px" /></td></td></td></td></td>
            <td> <td>
                <asp:Button ID="btncancel" runat="server" Text="Reject"  Height="27px" Width="64px" /></td></td>
                </tr></tr>
             <tr>
                <td class="auto-style3">
                    <td><td><td><td> <td > <td> <td>
                <asp:Button ID="btnback" runat="server" Text="Back" Height="27px" Width="64px" /></td></td></td></td></td></td></td>
                </tr>
            








    </div>
</asp:Content>
