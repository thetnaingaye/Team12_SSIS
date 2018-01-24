<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Team12_SSIS.StoreManager.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style2 {
            padding: 5px 0px 5px 0px;
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
    <div class="container-fluid" style="padding: 2px 2px 2px 2px">
            <div class="row">
            <div class="col-md-4">
                <div class="well" style="background-color: steelblue;box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)">

                    <div class="auto-style2">
                        <span>You have</span>

                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer1" />
                            </Triggers>
                            <ContentTemplate>
                                <h1 style="color: white"><strong><%= Session["count"] %></strong></h1>
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
                                <h1 style="color: white"><strong><%= DateTime.Now.Second%10 %></strong></h1>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <span>pending adjustment vouchers for approval</span>
                    </div>

                </div>

            </div>


<div class="col-md-4">
                <div class="panel panel-default" style="border-color: #006699; box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)">
                    <div class="panel-heading" style="text-align: center; background-color: #006699; color: white">Panel Heading</div>
                    <div class="auto-style2">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer3" />
                            </Triggers>
                            <ContentTemplate>
                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SA45Team12AD %>" SelectCommand="SELECT CategoryID, COUNT(*) AS TotalItem FROM InventoryCatalogue GROUP BY CategoryID" OnSelecting="SqlDataSource3_Selecting"></asp:SqlDataSource>
                                <asp:Chart ID="Chart8" runat="server" DataSourceID="SqlDataSource3">
                                    <Series>
                                        <asp:Series Name="Series1" XValueMember="CategoryID" YValueMembers="TotalItem" ChartType="SplineArea">
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
            <div class="col-md-4">
                <div class="panel panel-default" style="border-color: #006699; box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)">
                    <div class="panel-heading" style="text-align: center; background-color: #006699; color: white">Number of Items by Category</div>
                    <div class="auto-style2">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer2" />
                            </Triggers>
                            <ContentTemplate>
                                <asp:Chart ID="Chart5" runat="server" DataSourceID="SqlDataSource3" BackColor="Transparent" BackImageTransparentColor="Transparent" BorderlineColor="Transparent" OnLoad="Chart2_Load" Width="500px" Height="325px" Palette="None" PaletteCustomColors="26, 110, 204; 39, 128, 227; 190, 216, 246; 171, 194, 221; 18, 77, 142; 41, 94, 153; 212, 222, 234">
                                    <Series>
                                        <asp:Series ChartType="Doughnut" Name="Product Category" XValueMember="CategoryID" YValueMembers="TotalItem" BackImageTransparentColor="Silver" Legend="Legend1" LabelForeColor="DimGray">
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
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    <br />
        <div class="col-lg-12">
            <div class="panel panel-default" style="border-color: #006699; box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)">
                <div class="panel-heading" style="text-align: center; background-color: #006699; color: white">Panel Heading</div>
                <div class="auto-style2">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Timer3" />
                        </Triggers>
                        <ContentTemplate>
                            <asp:Chart ID="Chart4" runat="server" DataSourceID="SqlDataSource3" BackColor="Transparent" Height="325px" Width="900px">
                                <Series>
                                    <asp:Series Name="Series1" XValueMember="CategoryID" YValueMembers="TotalItem" CustomProperties="PixelPointWidth=5" LabelForeColor="RoyalBlue">
                                        <EmptyPointStyle LabelForeColor="DimGray" />
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1" BackColor="Transparent">
                                        <AxisY LineColor="Transparent">
                                            <MajorGrid LineColor="Silver" LineDashStyle="Dot" />
                                            <MajorTickMark LineColor="DimGray" />
                                        </AxisY>
                                        <AxisX LineColor="Transparent">
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
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    <br />
    <br />


    <!-- DEP HEAD-->
    <h1>FOR DEPT HEAD</h1>
    <br />
    <br />
    <div="row">
    <div class="container-fluid" style="padding: 2px 2px 2px 2px">
            <div class="col-sm-6" style="background-color: transparent; border: none; box-shadow: none; padding: 5px 5px 0px 5px">
                <div class="well" style="background-color: steelblue; box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)">

                    <div class="auto-style2">
                        <span>You have</span>

                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer1" />
                            </Triggers>
                            <ContentTemplate>
                                <h1 style="color: white"><strong><%= Session["count"] %></strong></h1>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <span>pending purchase orders for approval</span>
                    </div>
                </div>
            </div>
             <div class="col-sm-6" style="background-color: transparent; border: none; box-shadow: none; padding: 5px 5px 0px 5px">
                <div class="well" style="background-color: steelblue; box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)">

                    <div class="auto-style2">
                        <span>You have</span>

                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer1" />
                            </Triggers>
                            <ContentTemplate>
                                <h1 style="color: white"><strong><%= Session["count"] %></strong></h1>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <span>pending purchase orders for approval</span>
                    </div>
                </div>
            </div>
    </div>

    <br />
    <br />
    <br />


    <!-- Full width Chart-->

<div class="col-lg-12">
            <div class="panel panel-default" style="border-color: #006699; box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)">
                <div class="panel-heading" style="text-align: center; background-color: #006699; color: white">Panel Heading</div>
                <div class="auto-style2">
                    <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Timer3" />
                        </Triggers>
                        <ContentTemplate>
                            <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource3" BackColor="Transparent" Height="325px" Width="900px">
                                <Series>
                                    <asp:Series Name="Series1" XValueMember="CategoryID" YValueMembers="TotalItem" CustomProperties="PixelPointWidth=5" LabelForeColor="RoyalBlue">
                                        <EmptyPointStyle LabelForeColor="DimGray" />
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1" BackColor="Transparent">
                                        <AxisY LineColor="Transparent">
                                            <MajorGrid LineColor="Silver" LineDashStyle="Dot" />
                                            <MajorTickMark LineColor="DimGray" />
                                        </AxisY>
                                        <AxisX LineColor="Transparent">
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
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        </div>

    <br />
    <br />
    <br />


    <!-- EMP-->
     <h1>FOR EMPLOYEES</h1>
    <br />
    <br />
    <br />
    <br />

        <!-- First Container - quick research-->
    <div class="container-fluid">
                <asp:Xml ID="Xml1" runat="server"></asp:Xml>
    <div class="row">
        <div class="col-sm-6" style="text-align:left">
                <p>No of pending requisitions:</p>
               <h1>zero</h1>
            </div>
        <div class="col-sm-6" style="text-align:left">
                <p>Upcoming delivery date:</p>
               <h1>Wed, January 31, 2018</h1>
            </div>
        </div>
    <br />
    <br />

    <!-- Second Container - quick research-->
    <div class="col-lg-12 text-center">
        <h3 class="margin">Looking for an item or request?</h3>
        <p>It's one click away. </p>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Search" />
    </div>
    <br />
    <br />
    <!-- Third Container - quick buttons -->

        <div class="row">
            <div class="col-sm-4">
                <p>Raise another requisition.</p>
                <img src="../Images/birds3.jpg"" class="img-responsive margin" style="width: 100%" alt="Image">
            </div>
            <div class="col-sm-4">
                <p>Check the status of recent requests.</p>
                <img src="../Images/birds2.jpg"" class="img-responsive margin" style="width: 100%" alt="Image">
            </div>
            <div class="col-sm-4">
                <p>When and where is the next collection?</p>
                <a href="#"><img src="../Images/birds1.jpg"" class="img-responsive margin" style="width: 100%" alt="Image"></a>
            </div>
        </div>
    </div>
  
</asp:Content>
