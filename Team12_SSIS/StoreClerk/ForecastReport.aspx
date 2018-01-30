<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForecastReport.aspx.cs" Inherits="Team12_SSIS.StoreClerk.ForecastReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel='stylesheet prefetch' href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <br />
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Panel ID="PanelControl" runat="server" HorizontalAlign="Center">
            <asp:UpdatePanel ID="UpdatePanelControl" runat="server">
                <ContentTemplate>
                    <div class="wrap">
	                    <div class="search">
			                <input runat="server" id="inputValue" type="text" class="searchTerm" placeholder="Search..." name="inputValue" value="" enableviewstate="true"/>
			                <button runat="server" id="BtnSubmit1" class="searchPicture" type="submit" onServerClick="BtnSubmit1_Click"><i class="fa fa-search"></i></button>
	                    </div>
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
    <div id="MainArea">
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
                        <asp:Label ID="LblChartHeader" runat="server" Text="Demand for the period January 2014 to January 2018" Font-Size="Large" Visible="False"></asp:Label><br /><br />
                        <div>
                            <asp:Image ID="ImgChart" class="center-block" runat="server" ImageUrl="~/images/Charts/chart1.png" width="75%" BorderStyle="Inset" BorderWidth="1px" Visible="False"/>
                        </div>    
                    </asp:Panel>
                </div>
                <br /><br /><br />
                <div>
                    <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center">
                        <asp:Label ID="LblExpectedDemand" runat="server" Text="Expected demand for the next five weeks" Font-Size="Large" Visible="false"></asp:Label><br /><br />
                        <asp:GridView ID="GridViewForecastList" runat="server" AutoGenerateColumns="False" Width="80%" DataKeyNames="FID" ItemType="Team12_SSIS.Model.ForecastedData"
                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="Inset" Visible="false" HorizontalAlign="Center">
                            <Columns>
                                <asp:TemplateField HeaderText="Season">
                                    <ItemTemplate>
                                        <asp:Label ID="LblSeason" runat="server" Text='<%#:Item.Season %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Period">
                                    <ItemTemplate>
                                        <asp:Label ID="LblPeriod" runat="server" Text='<%#:Item.Period %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Forecasted Demand">
                                    <ItemTemplate>
                                        <asp:Label ID="LblForecastedDemand" runat="server" Text='<%#:Item.ForecastedDemand %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Low 80">
                                    <ItemTemplate>
                                        <asp:Label ID="LblReqID" runat="server" Text='<%#:Item.Low80 %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="High 80">
                                    <ItemTemplate>
                                        <asp:Label ID="LblHigh80" runat="server" Text='<%#:Item.High80 %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Low 95">
                                    <ItemTemplate>
                                        <asp:Label ID="LblLow95" runat="server" Text='<%#:Item.Low95 %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="High 95">
                                    <ItemTemplate>
                                        <asp:Label ID="LblHigh95" runat="server" Text='<%#:Item.High95 %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle CssClass="text-center" Font-Size="Small" ></HeaderStyle>
                                </asp:TemplateField>
                            </Columns>
                                <EmptyDataRowStyle Font-Italic="True" Font-Size="Medium" Font-Underline="False" ForeColor="#FF3300" />
                                    <EmptyDataTemplate>
                                        <table runat="server">
                                            <tr>
                                                <td>There are no requisition orders at present.</td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                        </asp:GridView>        
                        <div>
                            <br /><br />
                            <asp:button id="BtnPrint" runat="server" onclientclick="javascript:CallPrint('MainArea');" text="Print" xmlns:asp="#unknown" Visible="false"/>
                        </div>
                    </asp:Panel>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel> 
    </div>
    <br />


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
.search {
	width: 100%;
	position: relative
}

.searchTerm {
	float: left;
	width: 95%;
	border: 3px solid #3A3A87;
	padding: 5px;
	height: 33px;
	border-radius: 5px;
	outline: none;
	color: #3A3A87;
	font-size: 20px;
}

.searchTerm:focus {
	color: #3A3A87;
}

.searchPicture {
	position: absolute;
	right: -3%;
	width: 55px;
	height: 33px;
	border: 1px solid #3A3A87;
	background: #3A3A87;
	text-align: center;
	color: #fff;
	border-radius: 5px;
	cursor: pointer;
	font-size: 20px;
}

.wrap {
	width: 40%;
	position: absolute;
	top: 15%;
	left: 50%;
	transform: translate(-50%, -50%);
}
</style>
</asp:Content>



