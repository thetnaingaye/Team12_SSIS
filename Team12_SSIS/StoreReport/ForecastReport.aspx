<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForecastReport.aspx.cs" Inherits="Team12_SSIS.StoreClerk.ForecastReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>

<%----------------------------------------         SYED MOHAMAD KHAIRWANCYK BIN SAYED HIRWAINI         ---------------------------------------------%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel='stylesheet prefetch' href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <br />
    <div style="width: 100%;">
        <div style="float:left; width: 22%; height:555px; background-color:#D8E2FF; border-radius: 25px;">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:Panel ID="PanelControl" runat="server" HorizontalAlign="Center">
                <asp:UpdatePanel ID="UpdatePanelControl" runat="server">
                    <ContentTemplate>
                        <br /><br />
                        <div>
                            <td>
                                <asp:TextBox id="inputValue" Text="" runat="server" Width="66%" ControlStyle-CssClass="searchTerm" placeholder="Search..." OnTextChanged="inputValue_TextChanged" AutoPostBack="True"/>
                                <button runat="server" id="BtnSubmit1" type="submit" class="searchPicture" onServerClick="BtnSubmit1_Click"><i class="fa fa-search"></i></button>
                            </td>
                        </div>
                        <br />
                        <div>
                            <asp:Label ID="LblSelectedItem" runat="server" Text="Selected Item: " Font-Bold="True" Visible="false"></asp:Label><br /><asp:Label ID="LblItemDesc" runat="server" Text="" ></asp:Label>
                            <asp:Label ID="LblItemID" runat="server" Text="" Visible="false"></asp:Label><br /><br />
                            <asp:Label ID="LblSelectNumber" runat="server" Text="Select period(s) to forecast: " Font-Bold="True" Visible="false" ></asp:Label><br />
                            <asp:DropDownList ID="DdlNoForeacast" runat="server" Width="30%" ControlStyle-CssClass="basicTerm" Visible="false" >
                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                <asp:ListItem Text="15" Value="15"></asp:ListItem>
                            </asp:DropDownList><br /><br />
                            <asp:Label ID="LblSelectType" runat="server" Text="Select chart type: " Font-Bold="True" Visible="false" ></asp:Label><br />
                            <asp:DropDownList ID="DdlTypeChart" runat="server" Width="50%" Visible="false" >
                                <asp:ListItem Text="Line" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Points and line" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Steps" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Histogram" Value="4"></asp:ListItem>
                            </asp:DropDownList><br /><br />
                            <asp:Label ID="LblDateFrom" runat="server" Text="From: " Font-Bold="True" Visible="false" ></asp:Label><br /><input runat="server" id="DateFrom" type="date" style="width: 50%" visible="false" /><br /><br />
                            <asp:Label ID="LblDateTo" runat="server" Text="To: " Font-Bold="True" Visible="false" ></asp:Label><br /><input runat="server" id="DateTo" type="date" style="width: 50%" visible="false" /><br /><br /><br />
                            <asp:Button ID="BtnGenerate" CssClass="btn btn-primary" runat="server" Text="Generate" OnClick="BtnGenerate_Click" Visible="false" /><br /><br />
                            <asp:Label ID="LblErrorMsg" runat="server" Text="" ForeColor="Red" Visible="false" Width="70%"></asp:Label>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
            </asp:Panel>
            <div>
                <asp:UpdateProgress ID="UpdateProgress" DisplayAfter="10" runat="server" AssociatedUpdatePanelID="UpdatePanelControl">
                    <ProgressTemplate>
                      <div class="divWaiting">
	                    <asp:Image ID="imgWait" runat="server" ImageAlign="Middle" Width="15%" ImageUrl="~/images/wait.gif" />
                      </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
        <div id="MainArea" style="float:right; width: 78%;">
            <asp:UpdatePanel ID="UpdatePanelChart" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div>
                        <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center"><br />
                            <asp:Label ID="LblHeader" runat="server" Text="Forecast Report" Font-Size="XX-Large" Visible="False"></asp:Label><br /><br />
                            <asp:Label ID="LblCode" runat="server" Text="Item Code: " Font-Size="X-Large" Visible="False"></asp:Label><asp:Label ID="LblItemCode" runat="server" Text="" Font-Size="X-Large" Visible="False"></asp:Label><br />
                            <asp:Label ID="LblDescription" runat="server" Text="Item Description: " Font-Size="X-Large" Visible="False"></asp:Label><asp:Label ID="LblItemDescription" runat="server" Text="" Font-Size="X-Large" Visible="False"></asp:Label><br />
                            <asp:Label ID="LblCategory" runat="server" Text="Item Category: " Font-Size="X-Large" Visible="False"></asp:Label><asp:Label ID="LblItemCategory" runat="server" Text="" Font-Size="X-Large" Visible="False"></asp:Label><br /><br /><br />
                        </asp:Panel>
                    </div>
                    <div>
                        <asp:Panel ID="PanelChart" runat="server" HorizontalAlign="Center">
                            <asp:Label ID="LblChartHeader" runat="server" Text="Chart" Font-Size="Large" Visible="False"></asp:Label><br /><br />
                            <div>
                                <asp:Image ID="ImgChart" class="center-block" runat="server" ImageUrl="~/images/Charts/chart1.png" width="75%" BorderStyle="Inset" BorderWidth="1px" Visible="False"/>
                            </div>    
                        </asp:Panel>
                    </div>
                    <br /><br /><br />
                    <div>
                        <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center">
                            <asp:Label ID="LblModel" runat="server" Text="Autoregressive Integrated Moving Average (ARIMA) Model" Font-Size="Large" Visible="false"></asp:Label><br /><br />
                            <asp:Image ID="ImgTableModel" class="center-block" runat="server" style="max-width:200px;max-height:120px;height:auto;width:auto;" ImageUrl="~/images/Charts/tableModel.png" BorderStyle="Inset" BorderWidth="1px" Visible="False"/><br /><br /> 
                            <asp:Label ID="LblExpectedDemand" runat="server" Text="Forecasted Demand" Font-Size="Large" Visible="false"></asp:Label><br /><br />
                            <asp:Image ID="ImgTableResult" class="center-block" runat="server" style="max-width:100%;height:auto;width:auto;" ImageUrl="~/images/Charts/tableResults.png" BorderStyle="Inset" BorderWidth="1px" Visible="False"/><br /><br />
                            <asp:Label ID="LblAccuracy" runat="server" Text="Measures of Accuracy" Font-Size="Large" Visible="false"></asp:Label><br /><br />
                            <asp:Image ID="ImgTableAccuracy" class="center-block" runat="server" style="max-width:100%;max-height:500px;height:auto;width:auto;" ImageUrl="~/images/Charts/tableAccuracy.png" BorderStyle="Inset" BorderWidth="1px" Visible="False"/><br /><br />
                            <div>
                                <br /><br />
                                <asp:button id="BtnPrint" ControlStyle-CssClass="btn btn-success" style="position: absolute; top: 19%; right: 9%;" runat="server" onclientclick="javascript:CallPrint('MainArea');" text="Print" xmlns:asp="#unknown" Visible="false"/>
                            </div>
                        </asp:Panel>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel> 
        </div>
    </div>
    <br />
    <div style="clear:both"></div>


<%-- Script used for printing out only the a selected area of the webpage --%>
<script type="text/javascript">
    function CallPrint(strid) {
        var prtContent = document.getElementById(strid);
        var WinPrint = window.open('', '', 'letf=0,top=0,width=800,height=100,toolbar=0,scrollbars=0,status=0,dir=ltr');
        WinPrint.document.write(prtContent.innerHTML);
        WinPrint.document.close();
        WinPrint.focus();
        WinPrint.print();
        WinPrint.close();
        prtContent.innerHTML = strOldOne;
    }
</script>

<%-- Stylings for the loading screen --%>
<style type="text/css" media="screen">
    html, body{height:100%;} 
    .divWaiting{
    position: fixed;
    top:0%;
    bottom:0%;
    left:0%;
    right:0%;
    background-color: #FAFAFA;
    z-index: 2147483647 !important;
    opacity: 0.8;
    overflow: hidden;
    text-align: center;
    height: 100%;
    width: 100%;
    padding-top:20%;
    } 
</style>

<style>
/* For the search bar */

.searchTerm {
	border: 3px solid #4769CA;
	border-radius: 5px;
	outline: none;
	color: #4769CA;
    height: 35px;
}

.searchTerm:focus {
	color: #3A3A87;
}

.searchPicture {
	border: 1px solid #4769CA;
	background: #4769CA;
	text-align: center;
	color: #fff;
	border-radius: 5px;
	cursor: pointer;
    height: 35px;
    width: 30px;
}
</style>
</asp:Content>



