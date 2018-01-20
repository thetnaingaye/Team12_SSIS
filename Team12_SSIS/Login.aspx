<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Team12_SSIS.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="col-xs-12">
      <div style="padding:80px 0px 100px 0px">

        <div class="panel panel-default" style="border-color: #006699; width: 380px; margin-left:auto; margin-right: auto;box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)" ;>
            <div class="panel-heading" style="text-align: center; background-color: #006699; color: white">
                <h3>Logic University</h3>
                <h4>Stationary Store Inventory System</h4>
            </div>
            <div class="container-fluid" style="padding: 50px 10px 100px 20px">

                <asp:Login ID="Login1" runat="server" Width="340px" TextLayout="TextOnTop" Orientation="Vertical" DisplayRememberMe="true" TitleText="">
                    <LoginButtonStyle CssClass="btn" Width="150px" Font-Size="Medium" BorderColor="#006699" BackColor="White" ForeColor="#003366" BorderStyle="Solid" BorderWidth="1" />

                    <TextBoxStyle CssClass="form-control" />
                </asp:Login>
            </div>
        </div>
    </div>
 </div>
</asp:Content>
