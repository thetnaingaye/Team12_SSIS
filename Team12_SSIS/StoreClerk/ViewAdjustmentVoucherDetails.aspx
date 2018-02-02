<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAdjustmentVoucherDetails.aspx.cs" Inherits="Team12_SSIS.StoreClerk.ViewAdjustmentVoucherDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 42px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

        <table style="width: 100%">
            <tbody style="width: 100%">
                <tr>
                    <td colspan="2" style="height: 25px">
                        <h2>
                            <asp:Label ID="LblPageTitle" runat="server"></asp:Label></h2>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LblRequestIDLabel" runat="server" Style="padding-right: 10px"></asp:Label>
                        <asp:Label ID="LblRequestID" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="LblHandledByLabel" runat="server" Text="Handled By: " Style="padding-right: 10px"></asp:Label>
                        <asp:Label ID="LblHandledBy" runat="server"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LblDateReqLabel" runat="server" Text="Date of Request: " Style="padding-right: 10px"></asp:Label>
                        <asp:Label ID="LblDateReq" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LblStatusLabel" runat="server" Text="Status: " Style="padding-right: 10px"></asp:Label>
                        <asp:Label ID="LblStatus" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LblReqByLabel" runat="server" Text="Requested By: " Style="padding-right: 10px"></asp:Label>
                        <asp:Label ID="LblReqBy" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LblDateProcessedLabel" runat="server" Text="Date processed: "></asp:Label>
                        <asp:Label ID="LblDateProcessed" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div>
                            <asp:ScriptManager ID="sm1" runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel ID="Up1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                <ContentTemplate>
                                    <asp:GridView ID="GridViewAdjV" runat="server" AutoGenerateColumns="False"
                                        Style="width: 100%" ShowHeaderWhenEmpty="True"
                                        OnRowDataBound="OnRowDataBound"
                                        CellPadding="4" ForeColor="#333333" DataKeyNames="ItemID">
                                        <AlternatingRowStyle BackColor="#F9F9F9" />
                                        <Columns>

                                            <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblSn" runat="server" CssClass="center-block" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                </ItemTemplate>

                                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Item Code" HeaderStyle-Width="8%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                                <ItemTemplate>
                                                    <asp:UpdatePanel runat="server" ID="UpId" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                                        <ContentTemplate>
                                                            <asp:Label ID="LblItemCode" runat="server" Text='<%# Bind("ItemID") %>' OnTextChanged="TxtItemCode_TextChanged" AutoPostBack="true"></asp:Label>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>

                                                </ItemTemplate>

                                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="8%"></HeaderStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Description" HeaderStyle-Width="52%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblDesc" runat="server"></asp:Label>
                                                </ItemTemplate>

                                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="52%"></HeaderStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Adjustment Type" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblAdjType" runat="server" Text='<%# Bind("Type") %>'></asp:Label>
                                                </ItemTemplate>

                                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Adjustment Quantity" HeaderStyle-Width="10%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                                <ItemTemplate>
                                                    <asp:UpdatePanel runat="server" ID="UpValue" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                                        <ContentTemplate>
                                                            <asp:Label ID="LblAdjQty" runat="server" Width="80%" CssClass="center-block" Text='<%# Bind("Quantity") %>' OnTextChanged="TxtAdjQty_TextChanged" AutoPostBack="true"></asp:Label>
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

                                            <asp:TemplateField HeaderText="Value" HeaderStyle-Width="10%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblValue" runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="10%"></HeaderStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Reason" HeaderStyle-Width="22%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblReason" runat="server" Text='<%# Bind("Reason") %>'></asp:Label>
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
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="BtnCancelReq" runat="server" Text="Cancel Request" CssClass="btn btn-primary btn-xs" OnClick="BtnCancelReq_Click" Visible="false" />
                        <br />
                        <b><asp:Label ID="LblRmk" runat="server" Text="Remarks" Visible="false"></asp:Label></b>
                        <br />
                        <asp:Label ID="LblRemarks" runat="server" Visible="false"></asp:Label>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>
