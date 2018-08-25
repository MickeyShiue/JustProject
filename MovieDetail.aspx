<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"CodeFile="MovieDetail.aspx.cs" Inherits="MovieDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style13 {
            width: 700px;
        }

        .style14 {
            font-size: x-large;
            color:black;
        }

        .style15 {
            color: black;
            font-size: large;
        }

        .style16 {
            width: 180px;
        }

        .style22 {
            height: 49px;
        }

        .style23 {
            font-size: x-large;
        }

        .style24 {
            font-size: large;
        }
    </style>
    <script type="text/javascript" src="https://www.youtube.com/iframe_api"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table align="center" border="2">
        <tr>
            <td>
                <table align="center">
                    <tr>
                        <td>
                            <span class="style14"><strong>文章 </strong></span>
                            <table style="width: 200" align="center">
                                <tr>
                                    <td align="center" style="background: #F0FFFF" class="style13" height="250">
                                        <asp:Image ID="Image2" Width="700" Height="300" runat="server" OnLoad="Image2_Load" />
                                    </td>
                                    <td align="left" style="background: #F0FFFF" class="style13" height="250">
                                        <span class="style23">暱稱:</span><asp:Label ID="Label_Nickname" runat="server" Text="Label"
                                            CssClass="style23"></asp:Label>
                                        <br />
                                        <span class="style23">類型:</span><asp:Label ID="Label_title" runat="server" Text="Label"
                                            CssClass="style23"></asp:Label>
                                        <br />
                                        <span class="style23">片名:</span><asp:Label ID="Label_Keynote" runat="server" Text="Label"
                                            CssClass="style23"></asp:Label>
                                        <br />
                                        <span class="style23">投稿時間:</span><asp:Label ID="Label_time" runat="server" Text="Label"
                                            CssClass="style23"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td align="center" style="background: #F0FFFF" class="style13">
                                        <iframe runat="server" id="MoviePlay" width="700" height="315" src="https://www.youtube.com/embed/R-zql-bTcrM" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>
                                    </td>
                                    <td align="left" style="background: #F0FFFF" class="style13">
                                        <span class="style23">電影簡介:<br />
                                        </span>
                                        <asp:Label ID="Label_Contents" runat="server" Text="Label" CssClass="style23"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <strong><span class="style14">留言板 </span></strong>
                                    <table style="width: 200" align="center">
                                        <tr>
                                            <td align="center">
                                                <asp:DataList ID="DataList1" runat="server" BackColor="White" BorderColor="#3366CC"
                                                    BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource2" Height="400px"
                                                    Width="703px" BorderStyle="None" GridLines="Both"
                                                    OnItemCommand="Item_Command" DataKeyField="回文編號"
                                                    OnItemDataBound="DataList1_ItemDataBound">

                                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                    <ItemStyle BackColor="White" ForeColor="#003399" />
                                                    <ItemTemplate>
                                                        <table class="style1">
                                                            <tr>
                                                                <td class="style16" rowspan="3" align="center">
                                                                    <asp:Label ID="lblnum" runat="server" Text='<%# Eval("回文編號") %>' Visible="false" />
                                                                    <asp:LinkButton ID="DeleteButton" Text="Delete" CommandName="Item_Command" runat="server" />
                                                                    <p>
                                                                        <asp:Image ID="Image1" runat="server" Height="80px" ImageUrl="~/image/msn.jpg" Width="78px" />
                                                                        <br />
                                                                        暱稱:
                                                                        <asp:Label ID="暱稱Label" runat="server" Text='<%# Eval("暱稱") %>' />
                                                                        <br />
                                                                </td>
                                                                <td>
                                                                    <br class="style24" />
                                                                    <br class="style24" />
                                                                </td>
                                                                <td align="right" valign="top">
                                                                    <span class="style24">回復時間: </span>
                                                                    <asp:Label ID="時間Label" runat="server" Text='<%# Eval("時間") %>' CssClass="style24" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style22" colspan="2" align="left" valign="top">
                                                                    <span class="style23">回覆內容:</span><asp:Label ID="內容Label" runat="server" Text='<%# Eval("內容") %>'
                                                                        CssClass="style23" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style20" colspan="2">&nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br />
                                                    </ItemTemplate>
                                                    <SelectedItemStyle BackColor="#009999" ForeColor="#CCFF99" Font-Bold="True" />
                                                </asp:DataList>
                                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:JustConnectionString %>"
                                                    SelectCommand="SELECT [回文編號], [暱稱], [內容], [時間] FROM [回文資料表] WHERE ([編號] = @編號)">
                                                    <SelectParameters>
                                                        <asp:SessionParameter Name="編號" SessionField="Number" Type="Int32" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </td>
                                        </tr>
                                        <asp:Timer ID="Timer1" runat="server" Interval="30000">
                                        </asp:Timer>
                                    </table>
                                    <td></tr> </table>
                                        <table style="width: 200" align="center">
                                            <tr>
                                                <td align="left">
                                                    <span class="style14"><strong>回文區塊</strong></span>
                                                    <br />
                                                    <asp:TextBox ID="TextBox_Contents" runat="server" Height="294px" Width="676px" AutoPostBack="True"
                                                        TextMode="MultiLine"></asp:TextBox>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <br />
                                                    <asp:Label ID="Label_Message" runat="server" Style="font-size: large; font-weight: 700; color: #FF0000"
                                                        Text="Label" Visible="False"></asp:Label>
                                                    <br />
                                                    <asp:Button ID="Button_black" runat="server" Height="27px" Text="返回" Width="68px"
                                                        PostBackUrl="~/電影版.aspx" />
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
                            </asp:UpdatePanel>
</asp:Content>
