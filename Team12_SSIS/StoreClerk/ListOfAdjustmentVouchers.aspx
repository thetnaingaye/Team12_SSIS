<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListOfAdjustmentVouchers.aspx.cs" Inherits="Team12_SSIS.StoreClerk.ListOfAdjustmentVouchers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table style="width: 100%">
                <tr>
                    <td style="height: 25px">
                        <h2>List Inventory Adjustment Vouchers</h2>
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Show: " Style="padding-right: 10px"></asp:Label>
                        <asp:DropDownList ID="DdlStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DdlStatus_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="Pending">Pending</asp:ListItem>
                            <asp:ListItem Value="Approved">Approved</asp:ListItem>
                            <asp:ListItem Value="Rejected">Rejected</asp:ListItem>
                            <asp:ListItem Value="All">All</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div>
                            <asp:GridView ID="GridViewAdjV" runat="server" AutoGenerateColumns="False" Style="width:100%"
                                ShowHeaderWhenEmpty="True"
                                OnRowDataBound="OnRowDataBound" OnRowCommand="GridViewAdjV_RowCommand"
                                CellPadding="4" ForeColor="#333333" DataKeyNames="AVRID" AllowPaging="true"
                                OnPageIndexChanging="OnPageIndexChanging" PageSize="15" >
                                <AlternatingRowStyle BackColor="#F9F9F9"/>
                                <Columns>
                                    <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSn" runat="server" CssClass="center-block" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Voucher ID / Request ID" HeaderStyle-Width="8%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LBtnVoucherId" runat="server" Visible="false" CommandName="ViewDetails" CommandArgument='<%# Bind("AVRID") %>'></asp:LinkButton>
                                            <asp:LinkButton ID="LBtnRequestId" runat="server" Visable="false" CommandName="ViewDetails" Text='<%# "AVR" + ((int)Eval("AVRID")).ToString("0000") %>' CommandArgument='<%# Bind("AVRID") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="8%"></HeaderStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Date Created" HeaderStyle-Width="52%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                        <ItemTemplate>
                                            <asp:Label ID="LblCreateDate" runat="server" Text='<%# ((DateTime)Eval("DateRequested")).ToString("d") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="52%"></HeaderStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Requested By" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                        <ItemTemplate>
                                            <asp:Label ID="LblRequestor" runat="server" Text='<%# Bind("RequestedBy") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Status" HeaderStyle-Width="10%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                        <ItemTemplate>
                                            <asp:Label ID="LblStatus" runat="server" Width="80%" CssClass="center-block" Text='<%# Bind("Status") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="10%"></HeaderStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Date Processed" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                        <ItemTemplate>
                                            <asp:Label ID="LblProcessDate" runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Handled By" HeaderStyle-Width="10%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                        <ItemTemplate>
                                            <asp:Label ID="LblHandledBy" runat="server" Text='<%# Bind("HandledBy") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="10%"></HeaderStyle>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#1A6ECC" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
        </table>
    </div>
</asp:Content>
