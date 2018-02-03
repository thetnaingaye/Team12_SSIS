<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RetrievalList.aspx.cs" Inherits="Team12_SSIS.StoreClerk.RetrievalList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<%----------------------------------------         SYED MOHAMAD KHAIRWANCYK BIN SAYED HIRWAINI         ---------------------------------------------%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Stationery Retrieval List</h1>
        <asp:Label ID="LblMessage" runat="server" Text=""></asp:Label>
    </div>
    <asp:GridView ID="GridViewMainList" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="ItemID" ItemType="Team12_SSIS.Model.InventoryCatalogue"
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="Inset" style="margin-top: 5px" OnRowDataBound="GridViewMainList_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="BIN">
                    <ItemTemplate>
                        <asp:Label ID="LblBin" runat="server" Text='<%#:Item.BIN %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle CssClass="text-center" Font-Size="Smaller" Height="8%"></HeaderStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Item Code">
                    <ItemTemplate>
                        <asp:Label ID="LblItemID1" runat="server" Text='<%#:Item.ItemID %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle CssClass="text-center" Font-Size="Smaller" Height="8%"></HeaderStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>
                        <asp:Label ID="LblDesc" runat="server" Text='<%#:Item.Description %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle CssClass="text-center" Font-Size="Smaller" Height="8%"></HeaderStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Existing Quantity">
                    <ItemTemplate>
                        <asp:Label ID="LblTotalExistingQuantity" runat="server" Text='<%#:GetExistingQuantity(Item.ItemID) %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle CssClass="text-center" Font-Size="Smaller" Height="8%"></HeaderStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Needed Quantity">
                    <ItemTemplate>
                        <asp:Label ID="LblTotalQtyNeeded" runat="server" Text='<%#:GetTotalQtyNeeded(Item.ItemID) %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle CssClass="text-center" Font-Size="Smaller" Height="8%"></HeaderStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Units">
                    <ItemTemplate>
                        <asp:Label ID="LblUom" runat="server" Text='<%#:Item.UOM %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle CssClass="text-center" Font-Size="Smaller" Height="8%"></HeaderStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Breakdown By Department">
                    <ItemTemplate>
                        <div>
                            <asp:GridView ID="GridViewSubList" runat="server" BorderStyle="None" Width="100%" AutoGenerateColumns="false" DataKeyNames="RequestID" 
                                    ItemType="Team12_SSIS.Model.TempInventoryRetrieval" CssClass="ChildGrid" ShowHeader="false">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="LblDeptName" runat="server" Text='<%#:GetDepartmentName(Item.DepartmentID) %>'></asp:Label>
                                            <asp:Label ID="LblDeptID" runat="server" Text='<%#:Item.DepartmentID %>' Visible="false"></asp:Label>
                                            <asp:Label ID="LblReqID" runat="server" Text='<%#:Item.RequestID %>' Visible="false"></asp:Label>
                                            <asp:Label ID="LblReqDetailID" runat="server" Text='<%#:Item.RequestDetailID %>' Visible="false"></asp:Label>
                                            <asp:Label ID="LblIsOverride" runat="server" Text='<%#:Item.IsOverride %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30%"/>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="LblQtyNeeded" runat="server" Text='<%#:Item.RequestedQty %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%"/>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:TextBox ID="TbxActualQty" runat="server" Width="40%" Text='<%#:Item.ActualQty %>' ></asp:TextBox>*&nbsp;&nbsp;&nbsp;
                                            <asp:RangeValidator ID="RVQuantity" runat="server" ControlToValidate="TbxActualQty" ErrorMessage="Error" SetFocusOnError="True"
                                                MaximumValue="10000" MinimumValue="0" Type="Integer" Display="Dynamic" ></asp:RangeValidator>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30%" />
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="LblPriority" runat="server" Text='<%#:GetPriority(Item.RequestDetailID) %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25%"/>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ItemTemplate>
                    <HeaderStyle CssClass="text-center" Font-Size="Smaller" Height="8%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
            </Columns>
    </asp:GridView>
    <asp:Label ID="LblNote" runat="server" Text="*Quantity displayed here has been pre-calculated by the system."></asp:Label>
    <br /><br /><br /><br />
    <div>
        <asp:TextBox ID="TbxResult" runat="server" TextMode="MultiLine" Width="60%" BorderStyle="Ridge" Height="105px" ReadOnly="True" Visible="False"></asp:TextBox>
        <asp:Button ID="BtnCumulativeSubmit" CssClass="btn btn-primary" runat="server" Text="Submit" style="position: absolute; left:82%;" OnClientClick = "SetSource(this.id)" OnClick="BtnCumulativeSubmit_Click" />
    </div>
    <br /><br /><br /><br />
    <div>
        <asp:HiddenField ID="HdParam" runat="server" />
    </div>




    <script type = "text/javascript">
        function SetSource(SourceID) {
            var HdParam = document.getElementById("<%=HdParam.ClientID%>");
            HdParam.value = SourceID;
        }
    </script>

</asp:Content>






