<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web_Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>TDD - Login</title>
    <link href="css/styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="page-content">
            <table class="content">
                <tr>
                    <td class="TdToRight"><asp:Label ID="LabelUsername" runat="server" Text="Username"></asp:Label></td>
                    <td colspan="2"><asp:TextBox ID="TextUsername" runat="server" TabIndex="1"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="TdToRight"><asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label></td>
                    <td colspan="2"><asp:TextBox ID="TextPassword" runat="server" TabIndex="2" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="TdToRight"></td>
                    <td colspan="2">
                        <asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click" TabIndex="5" />
                        <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" OnClick="ButtonCancelar_Click" TabIndex="6"  />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
