<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Team12_SSIS.StoreManager.Home" %>

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
    <!-- home page for store supervisor and manager -->
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Timer ID="Timer1" runat="server" Interval="1000"></asp:Timer>
   
    <asp:Timer ID="Timer3" runat="server" Interval="600000"></asp:Timer>

   
 
                                <asp:SqlDataSource ID="SqlDataSource_CurrnetMonthRequets" runat="server" ConnectionString="<%$ ConnectionStrings:SA45Team12AD %>" SelectCommand="SELECT  
		D.DepartmentName,
        COUNT(*) TotalRequests 
FROM    RequisitionRecords Rr, Departments D
WHERE   Rr.DepartmentID = D.DeptID AND 
		Rr.RequestDate &gt;= DATEADD(day, 1, EOMONTH(DATEADD(month, -1, GETDATE()))) AND 
        Rr.RequestDate &lt;= GetDate()
GROUP BY D.DepartmentName"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource_PO_AMT" runat="server" ConnectionString="<%$ ConnectionStrings:SA45Team12AD %>" SelectCommand="SELECT SUM(PD.UnitPrice * PD.Quantity) AS AMOUNT_SGD,CC.CatalogueName
FROM PORecordDetails PD,CatalogueCategory CC,InventoryCatalogue I,PORecords PO
WHERE PD.ItemID = I.ItemID AND 
I.CategoryID = CC.CategoryID AND 
PO.DateProcessed&gt;= DATEADD(day, 1, EOMONTH(DATEADD(month, -1, GETDATE()))) AND
PO.DateProcessed &lt;= GETDATE()
GROUP BY CC.CatalogueName"></asp:SqlDataSource>


    <div class="container-fluid" style="padding: 2px 2px 2px 2px">
            <div class="row">
                    <a href="ListOfAdjustmentVouchers.aspx" style="text-decoration:none"> 
            <div class="col-md-5">
                      <div class="panel panel-default" style="border-color: #006699;box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);padding:101px 0px 111px 0px">
               
                    <div class="auto-style2">
                        <span>You have</span>
                        <br />
                        <br />
     
                       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer1" />
                            </Triggers>
                            <ContentTemplate>
                                <h1 ><strong><%= GetPendingAVR() %></strong></h1>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                          <br />
                        <br />

                        <span>pending adjustment vouchers for approval</span>
                    </div>
                       
                </div>
                
            </div>
               </a>
            <div class="col-md-7">
                           <a href="../StoreReport/DeptRequisitionReport.aspx" style="text-decoration:none"> 
               <div class="panel panel-default" style="border-color: #006699;box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)">
                   <div class="panel-heading" style="text-align: left; background-color: transparent; color: #1A6ECC";font-weight:600><h4>Requisition Trend</h4><h6>Numbers of Ruquests By Department For Current Month</h6></div>
                    <div class="auto-style2">
                        <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer3" />
                            </Triggers>
                            <ContentTemplate>
                                <asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource_CurrnetMonthRequets" BackColor="Transparent" BackImageTransparentColor="Transparent" BorderlineColor="Transparent" OnLoad="Chart2_Load" Width="500px" Palette="Pastel" PaletteCustomColors="26, 110, 204; 39, 128, 227; 190, 216, 246; 171, 194, 221; 18, 77, 142; 41, 94, 153; 212, 222, 234">
                                    <Series>
                                        <asp:Series ChartType="Doughnut" Name="Product Category" XValueMember="DepartmentName" YValueMembers="TotalRequests" BackImageTransparentColor="Silver" Legend="Legend1" LabelForeColor="DimGray">
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
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SA45Team12AD %>" SelectCommand="SELECT  
		D.DepartmentName,
        COUNT(*) TotalRequests 
FROM    RequisitionRecords Rr, Departments D
WHERE   Rr.DepartmentID = D.DeptID AND 
		Rr.RequestDate &gt;= DATEADD(day, 1, EOMONTH(DATEADD(month, -1, GETDATE()))) AND 
        Rr.RequestDate &lt;= GetDate()
GROUP BY D.DepartmentName"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:SA45Team12AD %>" SelectCommand="SELECT SUM(PD.UnitPrice * PD.Quantity) AS AMOUNT_SGD,CC.CatalogueName
FROM PORecordDetails PD,CatalogueCategory CC,InventoryCatalogue I,PORecords PO
WHERE PD.ItemID = I.ItemID AND 
I.CategoryID = CC.CategoryID AND 
PO.DateProcessed&gt;= DATEADD(day, 1, EOMONTH(DATEADD(month, -1, GETDATE()))) AND
PO.DateProcessed &lt;= GETDATE()
GROUP BY CC.CatalogueName"></asp:SqlDataSource>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                  </div>
                </div>
                               </a>
            </div>
        </div>
    <br />
         <div class="row">
        <div class="col-lg-12">
                       <a href="../StoreReport/RequisitionTrendReport.aspx" style="text-decoration:none"> 
                 <div class="panel panel-default" style="border-color: #006699;box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)">
            <div class="panel-heading" style="text-align: left; background-color: transparent; color: #1A6ECC";font-weight:600><h4>Purchasing Trend</h4><h6>Expenditure By Category For Current Month</h6></div>
                    <div class="auto-style2">
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer3" />
                            </Triggers>
                            <ContentTemplate>
                                <asp:Chart ID="Chart3" runat="server" DataSourceID="SqlDataSource_PO_AMT" BackColor="Transparent" Height="325px" Width="900px">
                                    <Series>
                                        <asp:Series Name="Series1" XValueMember="CatalogueName" YValueMembers="AMOUNT_SGD" CustomProperties="PixelPointWidth=5" LabelForeColor="RoyalBlue" YValuesPerPoint="10" YValueType="Double">
                                            <EmptyPointStyle LabelForeColor="DimGray" />
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1" BackColor="Transparent">
                                            <AxisY LineColor="Transparent" Title="Amount in SGD">
                                                <MajorGrid LineColor="Silver" LineDashStyle="Dot" />
                                                <MajorTickMark LineColor="DimGray" />
                                            </AxisY>
                                            <AxisX LineColor="Transparent" Title="Category" IsLabelAutoFit="False" Interval="1">
                                                <MajorGrid LineColor="Silver" LineDashStyle="Dot" />
                                                <MajorTickMark LineColor="DimGray" />
                                                <LabelStyle Angle="45" Font="Segoe UI, 8.25pt" />
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
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                           </a>
                   
                  
                </div>
         </div>
        </div>
    <br />


</asp:Content>
