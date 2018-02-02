<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewRequisitionFormList.aspx.cs" Inherits="Team12_SSIS.DepartmentHead.ViewRequisitionFormList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<%----------------------------------------         SYED MOHAMAD KHAIRWANCYK BIN SAYED HIRWAINI         ---------------------------------------------%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Requisition Forms List</h2>
    </div>
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanelFilter" runat="server">
            <ContentTemplate>
                <div>
                    <asp:Label ID="LblShow" runat="server" text-align="center" Text="Show: "></asp:Label>
                    <asp:DropDownList ID="DdlStatusList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DdlStatusList_SelectedIndexChanged">
                        <asp:ListItem>Pending</asp:ListItem>
                        <asp:ListItem>All</asp:ListItem>
                        <asp:ListItem>Processed</asp:ListItem>
                        <asp:ListItem>Approved</asp:ListItem>
                        <asp:ListItem>Rejected</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <br />
    <div>
        <asp:UpdatePanel ID="UpdatePanelList" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridViewReqList" runat="server" AutoGenerateColumns="False" Width="75%" DataKeyNames="RequestID" ItemType="Team12_SSIS.Model.RequisitionRecord"
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="Inset" EnableSortingAndPagingCallbacks="True" >
                    <Columns>
                        <asp:TemplateField HeaderText="Requisition ID">
                            <ItemTemplate>
                                <asp:Label ID="LblReqID" runat="server" text-align="center" Text='<%#:"RQ" + Item.RequestID %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Employee Name">
                            <ItemTemplate>
                                <asp:Label ID="LblEmpName" runat="server" text-align="center" Text='<%#:Item.RequestorName %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Created">
                            <ItemTemplate>
                                <asp:Label ID="LblReqDate" runat="server" text-align="center" Text='<%#:Item.RequestDate.Value.ToString("MM/dd/yyyy") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="LblStatus" runat="server" text-align="center" Text='<%#:GetStatus(Item.RequestID) %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Approved / Rejected">
                            <ItemTemplate>
                                <asp:Label ID="LblProcDate" runat="server" text-align="center" Text='<%#:GetApprovedDate(Item.ApprovedDate) %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="View Details">
                            <ItemTemplate>
                                <asp:Button ID="BtnView" class="btn btn-primary sm" runat="server" Text="View" CommandArgument="<%#:Item.RequestID %>" CommandName="ThisBtnClick" OnClick="btnView_Click"/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataRowStyle Font-Italic="True" Font-Size="Medium" Font-Underline="False" ForeColor="#FF3300" />
                    <EmptyDataTemplate>
                        <table runat="server">
                            <tr>
                                <td>There are no records associated with this status.</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DdlStatusList" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

</asp:Content>
