<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewRequisitionHistory.aspx.cs" Inherits="Team12_SSIS.DepartmentEmployee.ViewRequisitionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div><h1>
         <asp:Label ID="VpoLbl" runat="server" style="text-align: center" Text="List of Past Request"></asp:Label></h1>
        <table><tr>
            <td class="auto-style1">
            <asp:Label ID="EmnLbl" runat="server" Text="Emplyee Name:"></asp:Label>
            <td><asp:Label ID="Name" runat="server"></asp:Label></td>
            </td></tr>
            <td class="auto-style1">
            <asp:Label ID="EpnLbl" runat="server" Text="Employee Number:"></asp:Label>
            <td><asp:Label ID="NumberLbl" runat="server"></asp:Label></td>
            </td></tr>
            <td class="auto-style1">
            <asp:Label ID="EeaLbl" runat="server" Text="Employee Email Address:"></asp:Label>
            <td><asp:Label ID="AddressLbl" runat="server"></asp:Label></td>
            </td></tr>
            <td class="auto-style1">
            <asp:Label ID="DpnLbl" runat="server" Text="Dept Name:"></asp:Label>
            <td><asp:Label ID="DpnameLbl" runat="server"></asp:Label></td>
            </td></tr>
            <td class="auto-style1">
            <asp:Label ID="DpcLbl" runat="server" Text="Dept Code:"></asp:Label>
            <td><asp:Label ID="CodeLbl" runat="server"></asp:Label></td>
            </td></tr>
             <tr>
                 <asp:GridView ID="GridViewVPR" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                <ItemTemplate>
                                    <asp:Label ID="LblSn" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
                            </asp:TemplateField>
                  <asp:TemplateField HeaderText="Requisition Form ID" HeaderStyle-Width="8%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LBtnRID" runat="server" Visible="false" CommandName="ViewDetails" CommandArgument='<%# Bind("RequestID") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="8%"></HeaderStyle>
                                    </asp:TemplateField>
                                

                            <asp:TemplateField HeaderText="Date Created" HeaderStyle-Width="52%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblDateCreated" runat="server" Width="100%" CssClass="center-block" Text='<%# Eval("RequestDate") %>'></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="52%"></HeaderStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Status" HeaderStyle-Width="8%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblStatus" runat="server" Width="100%" CssClass="center-block" Text='<%# Eval("Status") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="8%"></HeaderStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Date Processed" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblDateProcessed" runat="server" Text='<%# Bind("DateProcessed") %>'></asp:Label>
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Handled By" HeaderStyle-Width="22%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblHandle" runat="server" Width="100%" CssClass="center-block" Text='<%# Bind("ApproverName") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="22%"></HeaderStyle>
                            </asp:TemplateField>

            </Columns>
        </asp:GridView></tr>
            <tr>
                <td class="auto-style3">
                    <td><td><td><td> <td > <td> <td>
                <asp:Button ID="btnback" runat="server" Text="Back" Height="27px" Width="64px" /></td></td></td></td></td></td></td>
                </tr>
            





        </div>
</asp:Content>
