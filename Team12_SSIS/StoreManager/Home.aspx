<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Team12_SSIS.StoreManager.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style2 {
            padding: 5px 15px 0px 15px;
            text-align: center;
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Timer ID="Timer1" runat="server" Interval="1000"></asp:Timer>
    <asp:Timer ID="Timer2" runat="server" Interval="10000"></asp:Timer>
    <asp:Timer ID="Timer3" runat="server" Interval="600000"></asp:Timer>
    <div class="container-fluid" style="padding: 5px 40px 0px 40px">

        <div class="row">
            <div class="col-md-6 well col-sm-12" style="background-color: transparent; border: none; box-shadow: none; padding: 5px 30px 0px 30px">
                <div class="well" style="background-color: steelblue;box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)">

                    <div class="auto-style2">
                        <span>You have</span>

                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer1" />
                            </Triggers>
                            <ContentTemplate>
                                <h1 style="color: white"><strong><%= GetPendingPO() %></strong></h1>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <span>pending purchase orders for approval</span>
                    </div>

                </div>
                <div class="well" style="background-color: steelblue;box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)">

                    <div class="auto-style2">
                        <span>You have</span>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer1" />
                            </Triggers>
                            <ContentTemplate>
                                <h1 style="color: white"><strong><%= GetPendingAVR() %></strong></h1>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <span>pending adjustment vouchers for approval</span>
                    </div>

                </div>

            </div>


            <div class="col-md-6 col-sm-12">
                <div class="panel panel-default" style="border-color: #006699;box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)">
                    <div class="panel-heading" style="text-align: center; background-color: #006699; color: white">Panel Heading</div>
                    <div class="auto-style2">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer3" />
                            </Triggers>
                            <ContentTemplate>
                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SA45Team12AD %>" SelectCommand="SELECT CategoryID, COUNT(*) AS TotalItem FROM InventoryCatalogue GROUP BY CategoryID" OnSelecting="SqlDataSource3_Selecting"></asp:SqlDataSource>
                                <asp:Chart ID="Chart8" runat="server" DataSourceID="SqlDataSource_PO_AMT">
                                    <Series>
                                        <asp:Series Name="Series1" XValueMember="CatalogueName" YValueMembers="AMOUNT_SGD" ChartType="SplineArea">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                            <AxisY>
                                                <MajorGrid LineColor="LightGray" LineDashStyle="Dot" />
                                            </AxisY>
                                            <AxisX>
                                                <MajorGrid LineColor="LightGray" LineDashStyle="Dot" />
                                                <MajorTickMark LineColor="LightGray" />
                                            </AxisX>
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                </div>
            </div>


        </div>

        <div class="row">
            <div class="col-md-6 col-sm-12">
                <div class="panel panel-default" style="border-color: #006699;box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)">
            <div class="panel-heading" style="text-align: left; background-color: transparent; color: #1A6ECC";font-weight:600><h4>Purchasing Trend</h4><h6>Expenditure By Category For Current Month</h6></div>
                    <div class="auto-style2">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer3" />
                            </Triggers>
                            <ContentTemplate>
                                <asp:Chart ID="Chart4" runat="server" DataSourceID="SqlDataSource_PO_AMT" BackColor="Transparent" Height="325px" Width="400px">
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
                                            <AxisX LineColor="Transparent" Title="Category" IsLabelAutoFit="False">
                                                <MajorGrid LineColor="Silver" LineDashStyle="Dot" />
                                                <MajorTickMark LineColor="DimGray" />
                                                <LabelStyle Angle="45" />
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
            </div>
            <div class="col-md-6 col-sm-12">
                <div class="panel panel-default" style="border-color: #006699;box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)">
                   <div class="panel-heading" style="text-align: left; background-color: transparent; color: #1A6ECC";font-weight:600><h4>Requisition Trend</h4><h6>Numbers of Ruquests By Department For Current Month</h6></div>
                    <div class="auto-style2">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer2" />
                            </Triggers>
                            <ContentTemplate>
                                <asp:Chart ID="Chart5" runat="server" DataSourceID="SqlDataSource_CurrnetMonthRequets" BackColor="Transparent" BackImageTransparentColor="Transparent" BorderlineColor="Transparent" OnLoad="Chart2_Load" Width="500px" Height="325px" Palette="Pastel" PaletteCustomColors="26, 110, 204; 39, 128, 227; 190, 216, 246; 171, 194, 221; 18, 77, 142; 41, 94, 153; 212, 222, 234">
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
                            </ContentTemplate>
                        </asp:UpdatePanel>


                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
