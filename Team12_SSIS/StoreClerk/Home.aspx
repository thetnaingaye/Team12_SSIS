<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Team12_SSIS.StoreClerk.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        

        .auto-style2 {
            padding: 5px 15px 0px 15px;
            text-align: center;
            color: #1A6ECC;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Timer ID="Timer1" runat="server" Interval="1000"></asp:Timer>

    <asp:Timer ID="Timer3" runat="server" Interval="600000"></asp:Timer>
    <div class="container-fluid" style="padding: 5px 40px 0px 40px">

        <div class="row">
            <div class="col-md-6 well col-sm-12" style="background-color: transparent; border: none; box-shadow: none; padding: 0px 15px 0px 15px">
                 <a href="ReorderList.aspx" style="text-decoration:none"> 
                <div class="well" style="background-color: transparent; box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)">

                    <div class="auto-style2">
                        <span>You have</span>

                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer1" />
                            </Triggers>
                            <ContentTemplate>
                                <h1 style="font-size:50px;font-weight:600"><strong><%= GetReorders("Pending") %></strong></h1>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <span>reorder list proccessed by system</span>
                    </div>

                </div>
                     </a>
                 <a href="ListOfPurchaseOrders.aspx" style="text-decoration:none"> 
                <div class="well" style="background-color: transparent; box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)">

                    <div class="auto-style2">
                        <span>You have</span>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer1" />
                            </Triggers>
                            <ContentTemplate>
                                <h1 ><strong><%=  GetDeliveryOrders("Approved")  %></strong></h1>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <span>pending delivery orders</span>
                    </div>

                </div>
                     </a>

            </div>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SA45Team12AD %>" SelectCommand="SELECT CategoryID, COUNT(*) AS TotalItem FROM InventoryCatalogue GROUP BY CategoryID" OnSelecting="SqlDataSource3_Selecting"></asp:SqlDataSource>

            <div class="col-md-6 col-sm-12">
                 <a href="CurrentRequisitionOrders.aspx" style="text-decoration:none"> 
                <div class="panel panel-default" style="border-color: #006699; box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)">
                    <div class="panel-heading" style="text-align: left; background-color: transparent; color: #1A6ECC";font-weight:600><h4>Requisition Forms</h4><h6>Oustanding requisition forms by department</h6></div>
                    <div class="panel panel-body">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer3" />
                            </Triggers>
                            <ContentTemplate>
                                
                                <div class="pre-scrollable" style="height: 150px; width: 100%; overflow-y: scroll;">

                                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableSortingAndPagingCallbacks="True" Height="100%" HorizontalAlign="Center" PageSize="3" Width="100%" AutoGenerateColumns="False"
                                        OnRowDataBound="OnRowDataBound" CellSpacing="3" GridLines="Horizontal">
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="LabRequestID" runat="server" Text='<%# Bind("RequestID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department">
                                              <ItemTemplate>
                                                    <asp:Label ID="LblDept" runat="server" Text='<%# Bind("DepartmentID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date Requested">
                                                  <ItemTemplate>
                                                    <asp:Label ID="LblDateRequested" runat="server" Text='<%# ((DateTime)Eval("RequestDate")).ToString("d") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           
                                        </Columns>

                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                        <RowStyle ForeColor="#000066" />
                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                    </asp:GridView>
                                </div>
                                       
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        
                    </div>
                </div>
                 </a>
            </div>
           

        </div>

        <div class="row">
            <div class="col-md-5 col-sm-12">
                      <a href="../StoreReport/RequisitionTrendReport.aspx" style="text-decoration:none"> 
                <div class="panel panel-default" style="border-color: #006699; box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)">
                     <div class="panel-heading" style="text-align: left; background-color: transparent; color: #1A6ECC";font-weight:600><h4>Requisition Trend</h4><h6>number of requisitions current and past three months</h6></div>
                    <div class="auto-style2">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer3" />
                            </Triggers>
                            <ContentTemplate>
                                <asp:Chart ID="Chart4" runat="server" DataSourceID="SqlDataSource_RuquestsbyMonth" BackColor="Transparent" Height="325px" Width="400px">
                                    <Series>
                                        <asp:Series Name="Series1" XValueMember="Column1" YValueMembers="TotalRequests" CustomProperties="PixelPointWidth=5" LabelForeColor="RoyalBlue" IsValueShownAsLabel="True">
                                            <EmptyPointStyle LabelForeColor="DimGray" />
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1" BackColor="Transparent">
                                            <AxisY LineColor="Transparent" Title="Number of requests">
                                                <MajorGrid LineColor="Silver" LineDashStyle="Dot" />
                                                <MajorTickMark LineColor="DimGray" />
                                            </AxisY>
                                            <AxisX LineColor="Transparent" Title="Month" TitleFont="Segoe UI, 8.25pt">
                                                <MajorGrid LineColor="Silver" LineDashStyle="Dot" />
                                                <MajorTickMark LineColor="DimGray" />
                                            </AxisX>
                                            <AxisX2 LineColor="Transparent">
                                                <MajorTickMark LineColor="DimGray" />
                                            </AxisX2>
                                            <AxisY2 LineColor="Transparent">
                                                <MajorTickMark LineColor="DimGray" />
                                            </AxisY2>
                                            <Area3DStyle LightStyle="Realistic" />
                                        </asp:ChartArea>
                                    </ChartAreas>
                                    <BorderSkin PageColor="DarkGray" BorderColor="Transparent" />
                                </asp:Chart>
                                <asp:SqlDataSource ID="SqlDataSource_RuquestsbyMonth" runat="server" ConnectionString="<%$ ConnectionStrings:SA45Team12AD %>" SelectCommand="select
  Concat(LEFT(datename(month,dateadd(mm,datediff(mm,0,RequestDate),0)),3),'_', year(dateadd(mm,datediff(mm,0,RequestDate),0))),
   [TotalRequests]   = count(*)
FROM    RequisitionRecords
WHERE   RequestDate &gt;= DATEADD(month, -3, GETDATE())
AND     RequestDate &lt;= GetDate()
group by
   dateadd(mm,datediff(mm,0,RequestDate),0)
order by
   dateadd(mm,datediff(mm,0,RequestDate),0) 
"></asp:SqlDataSource>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                          </a>
            </div>
            <div class="col-md-7 col-sm-12">
                  <a href="../StoreReport/RequisitionTrendReport.aspx" style="text-decoration:none"> 
                <div class="panel panel-default" style="border-color: #006699; box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)">
                     <div class="panel-heading" style="text-align: left; background-color: transparent; color: #1A6ECC";font-weight:600><h4>Requisition Trend</h4><h6>number of requisitions by department for current and past three months</h6></div>
                    <div class="auto-style2">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer3" />
                            </Triggers>
                            <ContentTemplate>
                                <asp:Chart ID="Chart5" runat="server" DataSourceID="SqlDataSource_RequestyByDept" BackColor="Transparent" BackImageTransparentColor="Transparent" BorderlineColor="Transparent" OnLoad="Chart2_Load" Width="500px" Height="325px" Palette="None" PaletteCustomColors="26, 110, 204; 39, 128, 227; 190, 216, 246; 171, 194, 221; 18, 77, 142; 41, 94, 153; 212, 222, 234">
                                    <Series>
                                        <asp:Series ChartType="Doughnut" Name="Product Category" XValueMember="DepartmentID" YValueMembers="TotalRequests" BackImageTransparentColor="Silver" Legend="Legend1" LabelForeColor="DimGray">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1" BackColor="Transparent" BackSecondaryColor="Transparent" BorderColor="Transparent" IsSameFontSizeForAllAxes="True">
                                            <Area3DStyle IsClustered="True" LightStyle="None" />
                                        </asp:ChartArea>
                                    </ChartAreas>
                                    <Legends>
                                        <asp:Legend Name="Legend1">
                                        </asp:Legend>
                                    </Legends>
                                    <BorderSkin PageColor="DarkGray" />
                                </asp:Chart>
                                <asp:SqlDataSource ID="SqlDataSource_requestbyDept_bycurrentmonth" runat="server" ConnectionString="<%$ ConnectionStrings:SA45Team12AD %>" SelectCommand="SELECT  
		D.DepartmentName,
        COUNT(*) TotalRequests 
FROM    RequisitionRecords Rr, Departments D
WHERE   Rr.DepartmentID = D.DeptID AND 
		Rr.RequestDate &gt;= DATEADD(day, 1, EOMONTH(DATEADD(month, -1, GETDATE()))) AND 
        Rr.RequestDate &lt;= GetDate()
GROUP BY D.DepartmentName"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource_RequestyByDept" runat="server" ConnectionString="<%$ ConnectionStrings:SA45Team12AD %>" SelectCommand="SELECT  
 
		DepartmentID,
        COUNT(*) TotalRequests 
FROM    RequisitionRecords
WHERE   RequestDate &gt;= DATEADD(month, -3, GETDATE())
AND     RequestDate &lt;= GetDate()
GROUP BY DepartmentID"></asp:SqlDataSource>
                            </ContentTemplate>
                        </asp:UpdatePanel>


                    </div>
                </div>
                      </a>
            </div>
        </div>
    </div>
</asp:Content>
