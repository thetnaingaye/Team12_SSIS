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
                                <asp:Chart ID="Chart8" runat="server" DataSourceID="SqlDataSource3">
                                    <Series>
                                        <asp:Series Name="Series1" XValueMember="CategoryID" YValueMembers="TotalItem">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
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
                    <div class="panel-heading" style="text-align: center; background-color: #006699; color: white">Panel Heading</div>
                    <div class="auto-style2">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer3" />
                            </Triggers>
                            <ContentTemplate>
                                <asp:Chart ID="Chart4" runat="server" DataSourceID="SqlDataSource3" BackColor="Transparent" Height="325px" Width="400px">
                                    <Series>
                                        <asp:Series Name="Series1" XValueMember="CategoryID" YValueMembers="TotalItem">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1" BackColor="Transparent">
                                            <Area3DStyle Enable3D="True" LightStyle="Realistic" />
                                        </asp:ChartArea>
                                    </ChartAreas>
                                    <BorderSkin PageColor="DarkGray" />
                                </asp:Chart>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <div class="col-md-6 col-sm-12">
                <div class="panel panel-default" style="border-color: #006699;box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)">
                    <div class="panel-heading" style="text-align: center; background-color: #006699; color: white">Number of Items by Category</div>
                    <div class="auto-style2">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer2" />
                            </Triggers>
                            <ContentTemplate>
                                <asp:Chart ID="Chart5" runat="server" DataSourceID="SqlDataSource3" BackColor="Transparent" BackImageTransparentColor="Transparent" BorderlineColor="Transparent" OnLoad="Chart2_Load" Width="500px" Height="325px">
                                    <Series>
                                        <asp:Series ChartType="Pie" Name="Product Category" XValueMember="CategoryID" YValueMembers="TotalItem" BackImageTransparentColor="Silver" Legend="Legend1">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1" BackColor="Transparent" BackSecondaryColor="Transparent">
                                            <Area3DStyle Enable3D="True" />
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
    </div>
</asp:Content>
