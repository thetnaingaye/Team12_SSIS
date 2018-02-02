<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewDelegationHistory.aspx.cs" Inherits="Team12_SSIS.DepartmentHead.ViewDelegationHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Delegation History</h2>
    <p>
        Search Employee:<asp:TextBox ID="SearchTxt" runat="server"></asp:TextBox>
        <asp:Button ID="SearchBtn" CssClass="btn btn-primary btn-xs" runat="server" OnClick="SearchBtn_Click" Text="Search" />
        <asp:Button ID="ViewAllBtn" CssClass="btn btn-primary btn-xs" runat="server" OnClick="ViewAllBtn_Click" Text="View All" />
    </p>
    <p>
        
        <asp:GridView ID="GridViewDelegationHistory" runat="server" AutoGenerateColumns="False"
                                ShowHeaderWhenEmpty="True"
                                CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="ID" AllowPaging="true"
                                 PageSize="15">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="#" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSn" runat="server" CssClass="center-block" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
                                    </asp:TemplateField>

                                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Department Head Delegate" HeaderStyle-Width="40%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                        <ItemTemplate>
                                            <asp:Label ID="LblDepartmentHeadDelegate" runat="server" CssClass="center-block" Text='<%# Bind("DepartmentHeadDelegate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="40%"></HeaderStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Start Date" HeaderStyle-Width="30%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                        <ItemTemplate>
                                            <asp:Label ID="LblStartDate" runat="server" CssClass="center-block" Text='<%# ((DateTime)Eval("StartDate")).ToString("d") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="30%"></HeaderStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="End Date" HeaderStyle-Width="30%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                        <ItemTemplate>
                                            <asp:Label ID="LblStartDate" runat="server" CssClass="center-block" Text='<%# ((DateTime)Eval("EndDate")).ToString("d") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="30%"></HeaderStyle>
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
    </p>
</asp:Content>
