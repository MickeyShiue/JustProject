<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Update.aspx.cs" Inherits="Updata" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link type="test/css" rel="Stylesheet" href="style.css" />
    <style type="text/css">
        .style14 {
            height: 30px;
        }
        .style32 {
            width: 30%;
            height: 30px;
            text-align:center;
        }
        .style33 {
            height: 30px;
            width: 70%;
        }
        .style34 {
            height: 80px;
            width: 70%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <center><asp:Image ID="Image1" runat="server" ImageUrl="~/image/圖示/會員資料.jpg" /></center>
    <br />
    <table border="1"  style="width: 700px; margin-left:auto; margin-right:auto;">
        <tr>
            <td class="style32">
                <asp:Label ID="Label_Account" runat="server"
                    Text="註冊帳號" Style="font-weight: 700"  ></asp:Label>
            </td>
            <td class="style33">
                <asp:TextBox ID="TextBox_Account" runat="server" Height="80%"
                    Width="85%"   Enabled="False" Style="text-align: left"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style32">
                <asp:Label ID="Label_Nickname" runat="server"
                    Text="線上暱稱" Style="font-weight: 700"  ></asp:Label>
            </td>
            <td class="style33">
                <asp:TextBox ID="TextBox_Nickname" runat="server" Height="80%"
                    Width="85%" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style32">
                <asp:Label ID="Label_Address" runat="server"
                    Text="通訊地址" Style="font-weight: 700"  ></asp:Label>
            </td>
            <td class="style34">
                <asp:DropDownList ID="ddlcity" runat="server" Height="40%"
                    AutoPostBack="True" OnSelectedIndexChanged="ddlcity_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlarea" runat="server" Height="40%">
                </asp:DropDownList>
                <br />
                <asp:TextBox ID="TextBox_Address" runat="server" Height="40%"
                    Width="85%"  ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style32">
                <asp:Label ID="Label_Email" runat="server"
                    Text="電子信箱" Style="font-weight: 700" ></asp:Label>
            </td>
            <td class="style33">
                <asp:TextBox ID="TextBox_Email" runat="server" Height="80%"
                    Width="85%" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style32">
                <asp:Label ID="Label_Phone" runat="server"
                    Text="連絡電話" Style="font-weight: 700" ></asp:Label>
            </td>
            <td class="style33">
                <asp:TextBox ID="TextBox_Phone" runat="server" Height="80%"
                    Width="85%" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style32">
                <asp:Label ID="Label_Birthday" runat="server"
                    Text="生日時間" Style="font-weight: 700"  ></asp:Label>
            </td>
            <td class="style33" style="text-align: left;">
                <asp:Label ID="Label_西元" runat="server" Text="西元"
                    Style="font-weight: 700; text-align: left;"  ></asp:Label>
                <asp:DropDownList ID="ddlBirthday" runat="server"
                    OnSelectedIndexChanged="ddlBirthday_SelectedIndexChanged" AutoPostBack="True"
                    Style="text-align: left"   >
                    <asp:ListItem Value="2015">請選擇</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label_年" runat="server" Text="年"
                    Style="font-weight: 700; text-align: left;"  ></asp:Label>
                <asp:TextBox ID="TextBox_Birthday" runat="server" Enabled="False"
                    Style="text-align: left" Width="39%"  ></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click"
                    ImageUrl="~/image/圖示/日曆.jpg" Width="20" Height="20" />
                <br />
                <asp:Panel ID="Panel5" runat="server" Visible="False">
                    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged1"></asp:Calendar>
                </asp:Panel>
            </td>
        </tr>
        <tr align="center">
            <td colspan="2" height="30px" class="style14">
                    <asp:Label ID="Label_Message" runat="server" Style="font-weight: 700; font-size: x-large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="style14">
                <table width="100%">
                    <tr align="center">
                        <td width="50%">
                                <asp:Button ID="Button_Rest" runat="server" Text="返回" CssClass=" "
                                    OnClick="Button_Rest_Click" PostBackUrl="~/FirstPage.aspx" Width="60px" />
                        </td>
                        <td width="50%">
                                <asp:Button ID="Button_save" runat="server" Text="儲存"
                                    OnClick="Button1_Click" CssClass=" " Width="60px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

