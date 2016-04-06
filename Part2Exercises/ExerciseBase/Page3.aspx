<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page3.aspx.cs" Inherits="ExerciseBase.Page3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Page 3</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="400px" align="center">
                <tr valign="top">
                    <td align="left">                        
                        <asp:Label ID="lblBookList" runat="server" Text="Book Listing" Font-Bold="true" Font-Size="Medium"/>
                    </td>
                    <td align="left">                           
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">    
                        <asp:DataGrid ID="dgBookInfo" runat="server" />
                        <asp:Label ID="lblErrorMessage" runat="server" Text="" />                    
                    </td>
                </tr>
        </table>        
    </div>
    </form>
</body>
</html>
