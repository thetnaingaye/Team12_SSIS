<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Team12_SSIS.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="col-xs-12">
        <div style="width: 400px; margin-left: auto; margin-right: auto;">
            <div class="container-fluid" style="padding: 50px 0px 150px 0px">
                <h2 class="text-center">Welcome To SSIS</h2>
                <asp:Login ID="Login1" runat="server" Width="380px" TextLayout="TextOnTop" Orientation="Vertical" DisplayRememberMe="true" TitleText="">
                    <LoginButtonStyle CssClass="btn" Width="150px" Font-Size="Medium" BorderColor="#006699" BackColor="White" ForeColor="#003366" BorderStyle="Solid" BorderWidth="1" />

                    <TextBoxStyle CssClass="form-control" />
                </asp:Login>
            </div>
        </div>
    </div>



</asp:Content>
