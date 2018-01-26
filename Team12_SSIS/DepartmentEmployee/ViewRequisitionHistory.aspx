<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewRequisitionHistory.aspx.cs" Inherits="Team12_SSIS.DepartmentEmployee.ViewRequisitionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div><h1>
         <asp:Label ID="VpoLbl" runat="server" style="text-align: center" Text="List of Past Request"></asp:Label></h1>
        <table style="width: 100%"><tr>
            <td>
                   <%-- <asp:DropDownList ID="DdlShow" runat="server" Height="16px" Width="117px" OnSelectedIndexChanged="DdlShow_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Value="Pending" Selected="True">Pending</asp:ListItem>
                        <asp:ListItem Value="Approved">Approved</asp:ListItem>
                        <asp:ListItem Value="Rejected">Rejected</asp:ListItem>
                        <asp:ListItem Value="All">All</asp:ListItem>
                    </asp:DropDownList>--%></td></tr>
             <tr>
                  <td colspan="5">
                           
                 <asp:GridView ID="GridViewVPR" OnRowDataBound="GridViewVPR_RowDataBound" runat="server" AutoGenerateColumns="False" Style="width: 100%" >
            <Columns>
               
                  <asp:TemplateField HeaderText="Requisition ID" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LBtnRID" runat="server" Visible="true" Text='<%# Bind("RequestID") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="text-center" Font-Size="Smaller" ></HeaderStyle>
                                    <ItemStyle CssClass="text-center"></ItemStyle>
                                    </asp:TemplateField>
                                

                            <asp:TemplateField HeaderText="Date Created"  HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                     
                                    <asp:Label ID="LblDateCreated" runat="server" CssClass="center-block" Text='<%# ((DateTime)Eval("RequestDate")).ToString("d")  %>'></asp:Label>
                                                           
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" ></HeaderStyle>
                                <ItemStyle CssClass="text-center"></ItemStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Status"  HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblStatus" runat="server"></asp:Label>
                                                  
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" Font-Size="Smaller"></HeaderStyle>
                                <ItemStyle CssClass="text-center"></ItemStyle>
                            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Date Processed"  HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                     
                                    <asp:Label ID="LblDateProcessed" runat="server" CssClass="center-block" ></asp:Label>
                                                           
                                </ItemTemplate>

                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" ></HeaderStyle>
                     <ItemStyle CssClass="text-center"></ItemStyle>
                            </asp:TemplateField>
                           

                            <asp:TemplateField HeaderText="Handled By"  HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                <ItemTemplate>
                                    <asp:Label ID="LblHandle" runat="server"  CssClass="center-block" Text='<%# Bind("ApproverName") %>'></asp:Label>
                                                            
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" Font-Size="Smaller" ></HeaderStyle>
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
