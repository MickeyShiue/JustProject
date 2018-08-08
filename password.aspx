<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="password.aspx.cs" Inherits="password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style17
        {
            width: 385px;
            height: 112px;
        }
        .style18
        {
            width: 131px;
        }
        .style19
        {
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <center><asp:Image ID="Image1" runat="server" ImageUrl="~/image/圖示/修改密碼.jpg" /></center>
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
    <table border="1" align="center" class="style17">
        <tr>
            <td class="style18">
                <span class="style19">*</span>
                <asp:Label ID="Label_Password" runat="server" Text="舊密碼" Style="font-weight: 700"
                    CssClass="style6"></asp:Label>
            </td>
            <td class="style33">
                <asp:TextBox ID="TextBox_Password" runat="server" Height="85%" Width="85%" CssClass="style6"
                    Style="text-align: left" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style18">
                <span class="style19">*</span>
                <asp:Label ID="Label_NewPassword" runat="server" Text="新密碼" Style="font-weight: 700"
                    CssClass="style6"></asp:Label>
            </td>
            <td class="style30">
                <asp:TextBox ID="TextBox_NewPassword" runat="server" Height="85%" Width="85%" 
                    CssClass="style6" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style18">
                <span class="style19">*</span>
                <asp:Label ID="Label_NewPassword2" runat="server" Text="確認密碼" Style="font-weight: 700"
                    CssClass="style6"></asp:Label>
            </td>
            <td class="style33">
                <asp:TextBox ID="TextBox_NewPassword2" runat="server" Height="85%" Width="85%" 
                    CssClass="style6" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <table align="center" style="width: 378px; height: 62px;">
            <tr>
                <td align="center">
                    <asp:Button ID="Button_back" runat="server" Text="返回" Height="25px" 
                        Width="60px" onclick="Button_back_Click" />
                </td>
                <td align="center">
                    <asp:Button ID="Button_Save" runat="server" Text="儲存" Height="25px" Width="60px"
                        OnClick="Button_Save_Click" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="Label_Message" runat="server"  Visible="False" 
                        style="color: #FF0000; font-weight: 700; font-size: x-large"></asp:Label>
                </td>
            </tr>
        </table>
    </table>
       </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>
