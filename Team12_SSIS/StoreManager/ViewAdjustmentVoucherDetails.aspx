<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAdjustmentVoucherDetails.aspx.cs" Inherits="Team12_SSIS.StoreManager.ViewAdjustmentVoucherDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-left: 0;
        }
        .auto-style2 {
            margin-top: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table style="width: 100%">
            <tbody style="width: 100%">
                <tr>
                    <td colspan="2" style="height: 25px">
                        <h2>Inventory Adjustment Voucher Request Details</h2>
                       
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LblReqID" runat="server" Style="padding-right: 10px" Font-Bold="true"></asp:Label>
                        <asp:Label ID="LblRequestID" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LblHandledBy" runat="server" Text="Handled By: " Style="padding-right: 10px" Font-Bold="true"></asp:Label>
                        <asp:Label ID="LblHandledByD" runat="server"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LblDateReq" runat="server" Text="Date of Request: " Style="padding-right: 10px" Font-Bold="true"></asp:Label>
                        <asp:Label ID="LblDateReqD" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LblStatus" runat="server" Text="Status: " Style="padding-right: 10px" Font-Bold="true"></asp:Label>
                        <asp:Label ID="LblStatusD" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LblReqBy" runat="server" Text="Requested By: " Style="padding-right: 10px" Font-Bold="true"></asp:Label>
                        <asp:Label ID="LblReqByD" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LblDateProcessed" runat="server" Text="Date processed: " Font-Bold="true"></asp:Label>
                        <asp:Label ID="LblDateProcessedD" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div>
                            <asp:ScriptManager ID="sm1" runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel ID="Up1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                <ContentTemplate>
                                    <asp:GridView ID="GridViewAdjVoucher" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True"
                                        OnRowDataBound="OnRowDataBound"
                                        CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="ItemID" Height="138px">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>

                                            <asp:TemplateField HeaderText="#" HeaderStyle-Width="3%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblSn" runat="server" CssClass="center-block" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                </ItemTemplate>

                                                <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="3%"></HeaderStyle>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Item Code" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-left" HeaderStyle-Font-Size="Smaller">
                                                <ItemTemplate>
                                                        <asp:Label ID="LblItemCode" runat="server" Text='<%# Bind("ItemID") %>' OnTextChanged="TxtItemCode_TextChanged" AutoPostBack="true" ></asp:Label>
                                                                                                  </ItemTemplate>
                                                <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Description" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblDesc" runat="server"></asp:Label>
                                                </ItemTemplate>

                                                <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Adjustment Type" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblAdjType" runat="server" Text='<%# Bind("Type") %>'></asp:Label>
                                                </ItemTemplate>

                                                <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Adjustment Quantity" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-left" HeaderStyle-Font-Size="Smaller">
                                                <ItemTemplate>
                                                   
                                                            <asp:Label ID="LblAdjQty" runat="server" Width="5%" CssClass="center-block" Text='<%# Bind("Quantity") %>' OnTextChanged="TxtAdjQty_TextChanged" AutoPostBack="true"></asp:Label>
                                                                                                     </ItemTemplate>

                                                <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="UOM" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblUom" runat="server" Text='<%# Bind("UOM") %>'></asp:Label>
                                                </ItemTemplate>

                                                <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Value" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblValue" runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Reason" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblReason" runat="server" Text='<%# Bind("Reason") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
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
                        <br />
                        <asp:Label ID="LblRemarks" runat="server" Font-Size="Small" Text="Remarks:"></asp:Label>
                        <br />
                        <asp:TextBox ID="TxtRemarks" runat="server" Height="67px"  TextMode="MultiLine" Width="652px" CssClass="auto-style2"></asp:TextBox>
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp  ;
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Btnapprove" runat="server" Text="Approve" Width="160px" OnClick="Btnapprove_Click" Height="44px" cssclass="btn btn-primary" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Btnreject" runat="server" Text="Reject" Width="160px" OnClick="Btnreject_Click"  cssclass="btn btn-danger" Height="44px"/>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
                        <br />
                        <br />
                        &nbsp;<asp:Label ID="LblMsg" runat="server" Text="statusMessage" Font-Bold="false" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
            </tbody>
        </table>
    </div>
    <p>
        <br />
    </p>
</asp:Content>
