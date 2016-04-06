<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page2.aspx.cs" Inherits="ExerciseBase.Page2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Page 2</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="400px" align="center">
                <tr valign="top">
                    <td align="left">                        
                        <asp:Label ID="lblPassOnValue" runat="server" Text="" />
                    </td>
                    <td align="left">      
                        <asp:Label ID="lblGlobalID" runat="server" Text="" />                    
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">    
                        <asp:Label ID="lblCacheVal" runat="server" Text="" />
                    </td>
                </tr>
        </table>             
    </div>
    </form>
</body>
</html>
