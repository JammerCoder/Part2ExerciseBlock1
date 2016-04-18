<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ExerciseBase.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Exercise 18</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="800px" align="center" border="0">
                <tr valign="top">
                    <td align="left">
                        <asp:Label ID="lblBookID" runat="server" Text="Search ID : " />
                        <asp:TextBox ID="txtBookID" runat="server" Text="" />
                        <asp:Button ID="btnSearchID" runat="server" Text="Search" OnClick="btnSearchID_Click" />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblBookTitle" runat="server" Text="BookTitle: " />
                        <asp:TextBox ID="txtBookTitle" runat="server" Text=""  />
                        <asp:Button ID="btnSearchTitle" runat="server" Text="Search" OnClick="btnSearchTitle_Click" />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblAuthorsName" runat="server" Text="Author's Name: " />
                        <asp:TextBox ID="txtAuthorsName" runat="server" Text="" />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblLength" runat="server" Text="Length: " />
                        <asp:TextBox ID="txtLength" runat="server" Text=""  TextMode="Number" />
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
                        <asp:Label ID="lblSellingPrice" runat="server" Text="Selling Price: " />
                        <asp:TextBox ID="txtSellingPrice" runat="server" Text="" TextMode="Number" />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:CheckBox ID="chkIsOnAmazon" runat="server" Text="On Amazon" />
                    </td>
                </tr>
                <tr>
                    <td align="left">                        
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Button ID="btnNew" runat="server" Text="Add" OnClick="btnNew_Click" />
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Enabled="False" /><br />
                        <asp:Label ID="lblErrorMessage" runat="server" Text="" />
                    </td>
                    
                </tr>
                <tr>                    
                    <td align="left" width="400">
                        <asp:Literal ID="litSearchResult" runat="server" />
                        <asp:DataGrid ID="grdBookInfo" runat="server" AllowPaging="true" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
