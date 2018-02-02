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
                      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                 <asp:GridView ID="GridViewVPR"  CssClass="table" OnRowDataBound="GridViewVPR_RowDataBound" runat="server" AutoGenerateColumns="False" Style="width: 100%" >
                     <AlternatingRowstyle BackColor="#f9f9f9"/>
            <Columns>
               
                  <asp:TemplateField HeaderText="Requisition ID" HeaderStyle-CssClass="text-center" HeaderStyle-Font-Size="Smaller">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LBtnRID" runat="server" Visible="true" Text='<%# "RQ" + Eval("RequestID") %>' OnClick="LBtnRID_Click"></asp:LinkButton>
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
        </asp:GridView>
                             </td>        
</tr>
            




            </table>
        </div>
    <br />
    
    <div>
        <asp:UpdatePanel ID="UpdatePanelDetailsView" runat="server" >
            <ContentTemplate>
                <div>
                    <h3><asp:Label ID="LblDetails" runat="server" Text="" EnableViewState="false"></asp:Label></h3>
                    <asp:Label ID="LblSelected" runat="server" Text="" EnableViewState="false"></asp:Label><asp:Label ID="LblItemIDInfo" runat="server" Text="" EnableViewState="false"></asp:Label>
                    <br /><br />
                </div>
                <asp:GridView ID="GridViewDetails" class="table" runat="server" AutoGenerateColumns="False" Width="75%" DataKeyNames="RequestDetailID" ItemType="Team12_SSIS.Model.RequisitionRecordDetail"
                     >
                     <AlternatingRowstyle BackColor="#f9f9f9"/>
                    <Columns>
                        <asp:TemplateField HeaderText="Item ID">
                            <ItemTemplate>
                                <asp:Label ID="LblReqID" runat="server" Text='<%#:Item.ItemID %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Item Name">
                            <ItemTemplate>
                                <asp:Label ID="LblReqID" runat="server" Text='<%#:GetItemDescription(Item.ItemID) %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Requested Quantity">
                            <ItemTemplate>
                                <asp:Label ID="LblReqID" runat="server" Text='<%#:Item.RequestedQuantity %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Units Of Measure">
                            <ItemTemplate>
                                <asp:Label ID="LblReqID" runat="server" Text='<%#:GetUnitsOfMeasure(Item.ItemID) %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="LblStatus" runat="server" Text='<%#:Item.Status %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
   
</asp:Content>
