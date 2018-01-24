<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Team12_SSIS.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowUpdating="GridView1_Updating " GridLines="Both">
            <Columns>
                <asp:TemplateField HeaderText="Item ID">
<ItemTemplate>
<asp:Label ID="ItemID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ItemID") %>' >></asp:Label>
</ItemTemplate>
                    <EditItemTemplate >
               <asp:TextBox ID="txtitemid" runat="server" Text='
			<%# DataBinder.Eval(Container.DataItem,"ItemID")%>'  ></asp:TextBox>
           </EditItemTemplate>
               </asp:TemplateField>
                </Columns>
            </asp:GridView>
    </div>
    </form>
</body>
</html>
