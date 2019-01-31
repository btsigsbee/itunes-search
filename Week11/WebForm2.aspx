<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Week11.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="tbxSearch" runat="server" Width="167px" ></asp:TextBox>
        </div>
       
        <br />
        <asp:DropDownList ID="typeDdl" runat="server">
            <asp:ListItem Value="movie">Movie</asp:ListItem>
            <asp:ListItem Value="software">Software</asp:ListItem>
            <asp:ListItem Value="music">Music</asp:ListItem>
        </asp:DropDownList>
         <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
    </form>
</body>
</html>