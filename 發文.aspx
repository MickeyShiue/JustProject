<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="發文.aspx.cs" Inherits="發文" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style13
        {
            width: 143px;
        }
        .style14
        {
            font-size: medium;
            color: #0066FF;
        }
        .style15
        {
            font-size: large;
        }
        .style16
        {
            width: 522px;
        }
        .style17
        {
            width: 219px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <center><asp:Image ID="Image1" runat="server" ImageUrl="~/image/圖示/發表文章.jpg" /></center>
            <br />
            <table align="center" border="1">
                <tr>
                    <td>
                        <table style="width: 534px; height: 40px" align="center">
                            <tr>
                                <td align="left" class="style17">
                                    <strong><span class="style14">類別<br /> </span></strong>
                                    <asp:DropDownList ID="ddl_title" runat="server" Height="25px" Width="83px" AutoPostBack="False">
                                        <asp:ListItem Value="Movie">動作片</asp:ListItem>
                                        <asp:ListItem Value="Movie">愛情片</asp:ListItem>
                                        <asp:ListItem Value="Movie">喜劇片</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="left">
                                    <span class="style14"><strong>電影名稱<br /> </strong></span><asp:TextBox ID="TextBox_title" runat="server"
                                        Width="133px" Height="22px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                            <td class="style17">
                                <span class="style14"><strong>影片連結<asp:TextBox ID="txt_src" runat="server" 
                                    Height="22px" Width="209px"></asp:TextBox>
                                </strong></span>
                            </td>
                            <td>
                                <span class="style14"><strong>上傳圖片</strong></span><br />
                                  <br />
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </td>
                            </tr>
                        </table>
                        <table style="width: 200" align="center">
                            <tr>
                                <td align="left" class="style16">
                                    <span class="style14"><strong>電影簡介</strong></span>
                                    <br />
                                    <asp:TextBox ID="TextBox_post" runat="server" Height="201px" Width="508px" AutoPostBack="False"
                                        TextMode="MultiLine"></asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <br />
                                    <asp:Label ID="Label_Message" runat="server" Style="font-size: large; font-weight: 700;
                                        color: #FF0000" Text="Label" Visible="False"></asp:Label>
                                    <br />
                                    <asp:Button ID="Button_black" runat="server" Height="27px" Text="返回" Width="68px"
                                        PostBackUrl="~/FirstPage.aspx" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button_into" runat="server" Height="27px" Text="送出" Width="68px"
                                        OnClick="Button_into_Click1" />
                                    &nbsp;<span class="style15"><strong>現在時間:&nbsp;</strong></span><strong><asp:Label
                                        ID="Label_nowtime" runat="server" CssClass="style15" Text="Label"></asp:Label>
                                    </strong>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Button_into" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
