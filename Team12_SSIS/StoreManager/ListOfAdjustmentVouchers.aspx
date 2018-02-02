<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListOfAdjustmentVouchers.aspx.cs" Inherits="Team12_SSIS.StoreManager.ListOfAdjustmentVouchers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 25px;
        }
        .auto-style2 {
            height: 35px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
     <div>
        <table style="width: 100%">
           
                <tr>
                    <td class="auto-style1">
                       <h2 class="auto-style2">Inventory Adjustment Voucher Request</h2>
                    </td>
                    </tr>
            <tr>
                    <td class="auto-style1">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" Text="Show: " Style="padding-right: 10px"></asp:Label>
                        <asp:DropDownList ID="DdlStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DdlStatus_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="Pending">Pending</asp:ListItem>
                            <asp:ListItem Value="Approved">Approved</asp:ListItem>
                            <asp:ListItem Value="Rejected">Rejected</asp:ListItem>
                            <asp:ListItem Value="ForApproval">For Approval</asp:ListItem>
                            <asp:ListItem Value="All">All</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div>

                            <asp:GridView ID="GridViewAdjV" Class="table" runat="server" AutoGenerateColumns="False" Style="width:100%"
                                ShowHeaderWhenEmpty="True"  EmptyDataText="No Record Found"
                                OnRowDataBound="OnRowDataBound" OnRowCommand="GridViewAdjV_RowCommand"
                                CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="AVRID" AllowPaging="true"
                                OnPageIndexChanging="OnPageIndexChanging" PageSize="15" >
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>
                                <Columns>
                                    <asp:TemplateField HeaderText="#" HeaderStyle-Width="3%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSn" runat="server" CssClass="center-block" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="3%"></HeaderStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Adjustment Request ID" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                        <ItemTemplate >
                                            <asp:LinkButton ID="LBtnVoucherId" runat="server" Visible="false" CommandName="ViewDetails" CommandArgument='<%# Bind("AVRID") %>'></asp:LinkButton>
                                           <asp:LinkButton ID="LBtnRequestId" runat="server" Visable="false" CommandName="ViewDetails" Text='<%# "AVR" + ((int)Eval("AVRID")).ToString("0000") %>' CommandArgument='<%# Bind("AVRID") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%" ></HeaderStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Date Created" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                        <ItemTemplate>
                                            <asp:Label ID="LblCreateDate" runat="server" Text='<%# ((DateTime)Eval("DateRequested")).ToString("d") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Requested By" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                        <ItemTemplate>
                                            <asp:Label ID="LblRequestor" runat="server" Text='<%# Bind("RequestedBy") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Status" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                        <ItemTemplate>
                                            <asp:Label ID="LblStatus" runat="server" Width="5%" CssClass="center-block" Text='<%# Bind("Status") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Date Processed" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                        <ItemTemplate>
                                            <asp:Label ID="LblProcessDate" runat="server" Text='<%# Bind("DateProcessed") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="text-left" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Handled By" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                        <ItemTemplate>
                                            <asp:Label ID="LblHandledBy" runat="server" Text='<%# Bind("HandledBy") %>'></asp:Label>
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
                        </div>
                    </td>
                </tr>
        </table>
    </div>

     <br />
     <asp:Label ID="LblMsg" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green" Text="statusMessage"></asp:Label>

</asp:Content>                        