<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SiteCoreWebSite.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="UserName"></asp:Label>
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Plase Fill in Username" ControlToValidate="txtUserName"></asp:RequiredFieldValidator><br />
        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox> 
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Plase Fill in Password" ControlToValidate="txtPassword"></asp:RequiredFieldValidator><br/>
        <asp:Label ID="Label3" runat="server" Text="Confirm Password"></asp:Label>
        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>    
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Plase Fill in Confirm Password" ControlToValidate="txtConfirmPassword"></asp:RequiredFieldValidator><br/>
    
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password and Confirm Password NOT MATCH!" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword"></asp:CompareValidator><br/>
        <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
    </div>
    </form>
</body>
</html>
