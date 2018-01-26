<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Team12_SSIS.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="col-xs-12">
      <div style="padding:80px 0px 80px 0px">

        <div class="panel panel-default" style="border-color: none; width: 380px; margin-left:auto; margin-right: auto; box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)" ;>
            <div class="panel-heading" style="text-align: center; background-color: #1a6ecc; color: white; padding-top: 3px; padding-bottom: 3px ">
                <h3>Logic University</h3>
                <h4>Stationery Store Inventory System</h4>
            </div>
            <div class="container-fluid" style="padding: 50px 10px 50px 20px">

                <asp:Login ID="Login1" runat="server" Width="340px" TextLayout="TextOnTop" Orientation="Vertical" DisplayRememberMe="true" TitleText="">
                    <LayoutTemplate>
                        <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                            <tr>
                                <td>
                                    <table cellpadding="0" style="width:340px;">
                                        <tr>
                                            <td>
                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="UserName" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="Password" runat="server" CssClass="form-control" TextMode="Password" Width="300px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="RememberMe" runat="server" Text=" Remember me next time." ForeColor="Gray" Font-Size="X-Small" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="color:Red;" font-size="Small">
                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:Button ID="LoginButton" runat="server" BackColor="White" BorderColor="#006699" BorderStyle="Solid" BorderWidth="1px" CommandName="Login" CssClass="btn" Font-Size="Medium" ForeColor="#003366" Text="Log In" ValidationGroup="Login1" Width="150px" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <LoginButtonStyle CssClass="btn" Width="150px" Font-Size="Medium" BorderColor="#006699" BackColor="White" ForeColor="#003366" BorderStyle="Solid" BorderWidth="1" />

                    <TextBoxStyle CssClass="form-control" Width="300px" />
                </asp:Login>
            </div>
        </div>
    </div>
 </div>
</asp:Content>
