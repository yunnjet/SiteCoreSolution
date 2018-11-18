<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SiteCoreWebSite.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnLogin" runat="server" Text="Login" Visible="true" OnClick="btnLogin_Click"/>
        <asp:Button ID="btnRegister" runat="server" Text="Register" Visible="true" OnClick="btnRegister_Click" />
          <asp:Label ID="LoginName" runat="server" Visible="false"></asp:Label>
        <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" Visible="false"/>
    </div>
    </form>
</body>
</html>
