<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Team12_SSIS.DepartmentHead.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       <asp:Timer ID="Timer1" runat="server" Interval="1000"></asp:Timer>

    <asp:Timer ID="Timer3" runat="server" Interval="600000"></asp:Timer>
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
                            <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource_dept" BackColor="Transparent" Height="325px" Width="900px">
                                <Series>
                                    <asp:Series Name="Series1" XValueMember="RequestDate" CustomProperties="PixelPointWidth=5" LabelForeColor="RoyalBlue">
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
                            <asp:SqlDataSource ID="SqlDataSource_dept" runat="server" ConnectionString="<%$ ConnectionStrings:SA45Team12AD %>" SelectCommand="PastReqRecordsByDept" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:Parameter Name="DeptName" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        </div>

    <br />
    <br />
    <br />

</asp:Content>
