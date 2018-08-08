<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Member_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style32 {
            width: 40%;
            height: 30px;
            text-align: center;
        }

        .style33 {
            height: 30px;
            width: 60%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<center>
    <table style="background-image: url('image/會員登入table.jpg'); width: 800px; height: 600px;">
        <tr>
            <td>
                <table align="center" width="80%">
                    <tr>
                    <td width="25%">
                    </td>
                        <td>
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/image/圖示/會員登入.jpg" />
                        </td>
                    </tr>
                </table>
                <table align="center" border="2" width="80%">
                    <tr>
                        <td class="style32">
                            <asp:Label ID="Label2" runat="server"
                                Style="font-size: large; font-weight: 700" Text="帳號"></asp:Label>
                        </td>
                        <td class="style33">
                            <asp:TextBox ID="TextBox_Id" runat="server" ForeColor="Red" Height="80%"
                                ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            <asp:Label ID="Label3" runat="server" Text="密碼"
                                Style="font-size: large; font-weight: 700"></asp:Label>
                        </td>
                        <td class="style33">
                            <asp:TextBox ID="TextBox_Pwd" runat="server" ForeColor="Red"
                                TextMode="Password" Height="80%"
                                ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table width="100%">
                                <tr align="center">
                                    <td width="50%">
                                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click"
                                            Style="font-size: large; font-weight: 700" Text="申請會員" />
                                    </td>
                                    <td width="50%">
                                        <asp:Button ID="Button_Login" runat="server" Text="登入"
                                            OnClick="Button_Login_Click1" Style="font-size: large; font-weight: 700" />
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td colspan="2">
                                        <asp:Label ID="Label_Message" runat="server" Style="font-size: medium"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </center>
</asp:Content>
