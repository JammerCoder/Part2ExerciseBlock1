﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ExerciseBase.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Exercise 21</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="800px" align="center" border="0">
                <tr valign="top">
                    <td align="left">
                        <asp:Label ID="lblBookID" runat="server" Text="Search ID : " />
                        <asp:TextBox ID="txtBookID" runat="server" Text="" />
                        <asp:Button ID="btnSearchID" runat="server" Text="Search" OnClick="btnSearchID_Click" /> <br />
                        <asp:Label ID="lblBookTitle" runat="server" Text="BookTitle: " />
                        <asp:TextBox ID="txtBookTitle" runat="server" Text=""  />
                        <asp:Button ID="btnSearchTitle" runat="server" Text="Search" OnClick="btnSearchTitle_Click" /> <br />
                        <asp:Label ID="lblAuthorsName" runat="server" Text="Author's Name: " />
                        <asp:TextBox ID="txtAuthorsName" runat="server" Text="" /> <br />
                        <asp:Label ID="lblLength" runat="server" Text="Length: " />
                        <asp:TextBox ID="txtLength" runat="server" Text=""  TextMode="Number" /> <br />
                        <asp:Label ID="lblDateCreated" runat="server" Text="Date Created: " />
                        <asp:TextBox ID="txtDateCreated" runat="server" Text="" /><br />
                        <asp:Label ID="lblSellingPrice" runat="server" Text="Selling Price: " />
                        <asp:TextBox ID="txtSellingPrice" runat="server" Text="" TextMode="Number" /><br />
                        <asp:CheckBox ID="chkIsOnAmazon" runat="server" Text="On Amazon" /><br />
                        <asp:Button ID="btnNew" runat="server" Text="Add" OnClick="btnNew_Click" />
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Enabled="False" /><br />
                        <asp:Label ID="lblErrorMessage" runat="server" Text="" /><br />
                        <asp:Literal ID="litSearchResult" runat="server" />
                        <asp:DataGrid ID="grdBookInfo" runat="server" AllowPaging="true" />
                    </td>                    
                    <td align="left">    
                        <asp:DropDownList ID="drdSelectColor" runat="server" OnSelectedIndexChanged="drdSelectColor_SelectedIndexChanged" AutoPostBack="True" /> <br />
                        <asp:CheckBoxList ID="cblColorSelectItem" runat="server" />
                    </td>                    
                </tr>
                <tr>
                    <td align="left">
                        <asp:Calendar ID="calDefault" runat="server" OnSelectionChanged="calDefault_SelectionChanged" ondayrender="calDefault_DayRender">
                            <NextPrevStyle ForeColor="#CCCCCC" />
                            <SelectedDayStyle Font-Bold="True" ForeColor="Red" />                            
                        </asp:Calendar>
                        <br />                        
                    </td>
                    <td align="left" >                        
                        <asp:Label ID="lblMonth" runat="server" Text=""/> <br />
                        <asp:DropDownList ID="drdList" runat="server" OnSelectedIndexChanged="drdList_SelectedIndexChanged" />                        
                    </td>
                </tr>
                <tr>    
                    <td align="left">                                                
                        <asp:CheckBoxList ID="chlCheckList" runat="server" OnSelectedIndexChanged="chlCheckList_SelectedIndexChanged" /> <br />                        
                    </td>                
                    <td align="left">                        
                        <asp:RadioButtonList ID="rdoRadioList" runat="server" OnSelectedIndexChanged="rdoRadioList_SelectedIndexChanged" /> 
                    </td>
                </tr>
                <tr>
                    <td align="left">                        
                        <asp:ImageButton ID="ibtnImageBtn" runat="server" OnClick="ibtnImageBtn_Click" ImageUrl="~/images/clickme.jpg" />
                    <td>                        
                        <asp:Literal ID="litEventMessage" runat="server" /><br />
                        <asp:Literal ID="litCustomMessage" runat="server" Text="Custom Message here..."/>
                    </td>
                </tr>
                <tr>
                    <td align="left">                        
                    </td>
                </tr>
                <tr>
                    <td align="left">                        
                    </td>
                    
                </tr>
                <tr>                    
                    <td align="left" width="400">                        
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
