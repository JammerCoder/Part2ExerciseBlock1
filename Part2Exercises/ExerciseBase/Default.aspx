﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ExerciseBase.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Exercise 8</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="400px" align="center">
                <tr valign="top">
                    <td align="left">                        
                        <asp:Label ID="lblBookID" runat="server" Text="Search ID : " />
                        <asp:TextBox ID="txtBookID" runat="server" Text=""/>
                    </td>                    
                    <td align="left">      
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                    </td>                                        
                    <td align="left">      
                        <asp:HyperLink ID="hypPage2" runat="server" Text="Page 2 >>"/> <br />
                        <asp:HyperLink ID="hypPage3" runat="server" Text="To Book Listing"/>                                          
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">                        
                    </td>
                </tr>
        </table>            
    </div>
    </form>
</body>
</html>
