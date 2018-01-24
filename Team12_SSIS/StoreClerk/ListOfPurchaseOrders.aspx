<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListOfPurchaseOrders.aspx.cs" Inherits="Team12_SSIS.StoreClerk.ListOfPurchaseOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <style type="text/css">
        .auto-style2 {
            height: 25px;
        }

        .auto-style4 {
            height: 25px;
            width: 442px;
        }

        .auto-style5 {
            width: 442px;
        }

        .auto-style6 {
            height: 25px;
            width: 27px;
        }

        .auto-style7 {
            width: 27px;
        }

        .auto-style8 {
            margin-left: 1112px;
        }
    </style>
    <div>
        <h1>
            <asp:Label ID="Label1" runat="server" Style="text-align: center" Text="List of Purchase Order "></asp:Label></h1>
        <table>
            <tr>
                <td class="auto-style2">
                    <td class="auto-style2">
                        <td class="auto-style2">
                            <td class="auto-style2">
                                <td class="auto-style4">
                                    <td class="auto-style6">
                                        <asp:Label ID="UserLbl" runat="server" Text="User:"></asp:Label>

                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label ID="ULbl" runat="server"></asp:Label></td>
                                    <td class="auto-style2"></td>
                                    <td class="auto-style2">
                                        <td class="auto-style2">
                                            <asp:Label ID="RoleLbl" runat="server" Text="Role:"></asp:Label>
                                            <asp:Label ID="RLbl" runat="server"></asp:Label></td>
                                    </td>
            </tr>
            </tr></td></td></td></td></td>
            <tr>
                <td>
                    <td>
                        <td>
                            <td>
                                <td class="auto-style5">
                                    <td class="auto-style7">
                                        <asp:Label ID="LblShow" runat="server" Text="Show:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DdlShow" runat="server" Height="16px" Width="117px" OnSelectedIndexChanged="DdlShow_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Selected="True" Value="All">All</asp:ListItem>
                                            <asp:ListItem Value="Rejected">Rejected</asp:ListItem>
                                            <asp:ListItem Value="Approved">Approved</asp:ListItem>
                                            <asp:ListItem Value="Pending">Pending</asp:ListItem>
                                        </asp:DropDownList></td>
            </tr>
            </tr></td></td></td></td></td>
        <tr>
            <td>
                <asp:GridView ID="GridViewLPO" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                            <ItemTemplate>
                                <asp:Label ID="LblSn" runat="server" CssClass="center-block" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PO#" HeaderStyle-Width="8%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                            <ItemTemplate>
                                <asp:LinkButton ID="LBtnPONumber" runat="server" CommandName="ViewDetails" Text='<%# Bind("PONumber")%>' CommandArgument='<%# Bind("PONumber") %>'></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="8%"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PO Total" HeaderStyle-Width="52%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                            <ItemTemplate>
                                <asp:Label ID="LblPOT" runat="server" Text='<%#:GetTotal(Eval("PONumber")) %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="52%"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status" HeaderStyle-Width="52%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                            <ItemTemplate>
                                <asp:Label ID="LblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="52%"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Submitted" HeaderStyle-Width="52%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                            <ItemTemplate>
                                <asp:Label ID="LblDsm" runat="server" Text='<%# Bind("DateRequested") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="52%"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Processed" HeaderStyle-Width="52%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                            <ItemTemplate>
                                <asp:Label ID="LblDpr" runat="server" Text='<%# Eval("DateProcessed") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="52%"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Requested By" HeaderStyle-Width="52%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                            <ItemTemplate>
                                <asp:Label ID="LblReq" runat="server" Text='<%# Bind("CreatedBy") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="52%"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Approved By" HeaderStyle-Width="52%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                            <ItemTemplate>
                                <asp:Label ID="LblApp" runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="52%"></HeaderStyle>
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
        </tr>
            </td>
                <tr>
                    <td>
                        <asp:Button ID="backBtn" runat="server" Text="Back" /></td>
                </tr>



        </table>

    </div>

</asp:Content>






















