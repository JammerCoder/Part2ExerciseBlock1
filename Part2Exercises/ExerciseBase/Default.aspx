﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ExerciseBase.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Exercise 12</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="400px" align="center">
                <tr valign="top">
                    <td align="left">
                        <asp:Label ID="lblBookID" runat="server" Text="Search ID : " />
                        <asp:TextBox ID="txtBookID" runat="server" Text="" />
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblBookTitle" runat="server" Text="BookTitle: " />
                        <asp:TextBox ID="txtBookTitle" runat="server" Text="" /><br />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblAuthorsName" runat="server" Text="Author's Name: " />
                        <asp:TextBox ID="txtAuthorsName" runat="server" Text="" /><br />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblLength" runat="server" Text="Length: " />
                        <asp:TextBox ID="txtLength" runat="server" Text="" /><br />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblDateCreated" runat="server" Text="Date Created: " />
                        <asp:TextBox ID="txtDateCreated" runat="server" Text="" /><br />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:CheckBox ID="chkIsOnAmazon" runat="server" Text="On Amazon" />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:DataGrid ID="dgBookInfo" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblErrorMessage" runat="server" Text="" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
