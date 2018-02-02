<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListOfPurchaseOrders.aspx.cs" Inherits="Team12_SSIS.StoreClerk.ListOfPurchaseOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <h1>
            <asp:Label ID="Label1" runat="server" Style="text-align: center" Text="List of Purchase Order "></asp:Label></h1>
        <table style="width: 100%">
            <tr>

                <td>
                    <asp:Label ID="LblShow" runat="server" Text="Show:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DdlShow" runat="server" Height="20px" Width="117px" OnSelectedIndexChanged="DdlShow_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Value="Pending" Selected="True">Pending</asp:ListItem>
                        <asp:ListItem Value="Approved">Approved</asp:ListItem>
                        <asp:ListItem Value="Rejected">Rejected</asp:ListItem>
                        <asp:ListItem Value="All">All</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:GridView ID="GridViewLPO"  class="table" runat="server" AutoGenerateColumns="False" Style="width: 100%" OnRowCommand="GridViewVPO_RowCommand">
                         <AlternatingRowstyle BackColor="#f9f9f9"/>
                        <Columns>
                            <asp:TemplateField HeaderText="PO#" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LBtnPONumber" runat="server" CommandName="ViewDetails" Text='<%# Bind("PONumber")%>' CommandArgument='<%# Bind("PONumber") %>'></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" Font-Size="Smaller"></HeaderStyle>
                                <ItemStyle CssClass="text-center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PO Total" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblPOT" runat="server" Text='<%#:GetTotal(Eval("PONumber")) %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" Font-Size="Smaller"></HeaderStyle>
                                <ItemStyle CssClass="text-center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" Font-Size="Smaller"></HeaderStyle>
                                <ItemStyle CssClass="text-center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date Submitted" HeaderStyle-CssClass="text-center" SortExpression="DateRequested" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblDsm" runat="server" Text='<%# ((DateTime)Eval("DateRequested")).ToString("d") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" Font-Size="Smaller"></HeaderStyle>
                                <ItemStyle CssClass="text-center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date Processed" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblDpr" runat="server" Text='<%# Eval("DateProcessed") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" Font-Size="Smaller"></HeaderStyle>
                                <ItemStyle CssClass="text-center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Requested By" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblReq" runat="server" Text='<%# Bind("CreatedBy") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" Font-Size="Smaller"></HeaderStyle>
                                <ItemStyle CssClass="text-center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Approved By" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblApp" runat="server" Text='<%# Eval("HandledBy") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" Font-Size="Smaller"></HeaderStyle>
                                <ItemStyle CssClass="text-center"></ItemStyle>
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
                </td>
            </tr>
            
        </table>
    </div>
</asp:Content>






















