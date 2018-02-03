<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PastRequisitionOrders.aspx.cs" Inherits="Team12_SSIS.StoreClerk.PastRequisitionOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<%----------------------------------------         SYED MOHAMAD KHAIRWANCYK BIN SAYED HIRWAINI         ---------------------------------------------%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Past Requisition Records</h2>
    </div>
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanelList" runat="server" >
            <ContentTemplate>
                <div>
                    <asp:Label ID="LblFilter" runat="server" text-align="center" Text="Filter by department: "></asp:Label>
                    <asp:DropDownList ID="DdlDeptList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DdlDeptList_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <br />
                <asp:GridView ID="GridViewReqList" runat="server" AutoGenerateColumns="False" Width="85%" DataKeyNames="RequestID" ItemType="Team12_SSIS.Model.RequisitionRecord"
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="Inset" AllowPaging="True" PageSize="5" style="margin-top: 5px" OnPageIndexChanging="GridViewReqList_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="RequestID">
                            <ItemTemplate>
                                <asp:Label ID="LblReqID" runat="server" Text='<%#:"RQ"+Item.RequestID %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Department">
                            <ItemTemplate>
                                <asp:Label ID="LblDeptName" runat="server" Text='<%#:GetDepartmentName(Item.DepartmentID)%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Requestor">
                            <ItemTemplate>
                                <asp:Label ID="LblReqName" runat="server" Text='<%#:Item.RequestorName %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Date Requested">
                            <ItemTemplate>
                                <asp:Label ID="LblReqDate" runat="server" Text='<%#:Item.RequestDate.Value.ToString("MM/dd/yyyy") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Date Processed">
                            <ItemTemplate>
                                <asp:Label ID="LblProDate" runat="server" Text='<%#:Item.ApprovedDate.Value.ToString("MM/dd/yyyy") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Approver">
                            <ItemTemplate>
                                <asp:Label ID="LblApprName" runat="server" Text='<%#:Item.ApproverName %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="View">
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
                                <td>No past records were retrieved.</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <br /><br /><br />

    <div>
        <asp:UpdatePanel ID="UpdatePanelDetailsView" runat="server" >
            <ContentTemplate>
                <div>
                    <h4><asp:Label ID="LblDetails" runat="server" Text="" EnableViewState="false"></asp:Label></h4>
                    <asp:Label ID="LblSelected" runat="server" Text="" EnableViewState="false"></asp:Label><asp:Label ID="LblItemIDInfo" runat="server" Text="" EnableViewState="false"></asp:Label>
                    <br /><br />
                </div>
                <asp:GridView ID="GridViewDetails" runat="server" AutoGenerateColumns="False" Width="75%" DataKeyNames="RequestDetailID" ItemType="Team12_SSIS.Model.RequisitionRecordDetail"
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="Inset" >
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

