<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewRequisitionHistory.aspx.cs" Inherits="Team12_SSIS.DepartmentEmployee.ViewRequisitionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div><h1>
         <asp:Label ID="VpoLbl" runat="server" style="text-align: center" Text="List of Past Request"></asp:Label></h1>
        <table><tr>
            <td>
           <asp:DropDownList ID="DdlShow" runat="server" Height="16px" Width="117px" OnSelectedIndexChanged="DdlShow_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Selected="True" Value="All">All</asp:ListItem>
                                            <asp:ListItem Value="Rejected">Rejected</asp:ListItem>
                                            <asp:ListItem Value="Approved">Approved</asp:ListItem>
                                            <asp:ListItem Value="Pending">Pending</asp:ListItem>
                                        </asp:DropDownList></td></tr>
             <tr>
                 <asp:ScriptManager ID="sml" runat="server"></asp:ScriptManager>
                           
                 <asp:GridView ID="GridViewVPR" runat="server" AutoGenerateColumns="False" Style="height: 100px; overflow: auto" ShowHeaderWhenEmpty="True"
                                        OnRowDataBound="OnRowDataBound"
                                        CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridViewVPR_SelectedIndexChanged" >
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller" ShowHeader="true">
                                <ItemTemplate>
                                    <asp:Label ID="LblSn" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
                            </asp:TemplateField>
                  <asp:TemplateField HeaderText="Requisition ID" HeaderStyle-Width="8%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LBtnRID" runat="server" Visible="true" CommandName="ViewDetails" Text='<%# Bind("RequestID") %>' CommandArgument='<%# Bind("RequestID") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="8%"></HeaderStyle>
                                    </asp:TemplateField>
                                

                            <asp:TemplateField HeaderText="Date Created" HeaderStyle-Width="5%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                     
                                    <asp:Label ID="LblDateCreated" runat="server" Width="100%" CssClass="center-block" Text='<%# Bind("RequestDate") %>'></asp:Label>
                                                           
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="5%"></HeaderStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Status" HeaderStyle-Width="8%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblStatus" runat="server" Width="100%" CssClass="center-block" Text='<%# Bind("Status") %>'></asp:Label>
                                                  
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" Width="8%"></HeaderStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Date Processed" HeaderStyle-Width="10%" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>>
                                    <asp:Label ID="LblDateProcessed" runat="server"  Width="100%" CssClass="center-block" Text='<%# Bind("ApprovedDate") %>'></asp:Label>
                                                             
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
            




            </table>
        </div>
   
</asp:Content>
