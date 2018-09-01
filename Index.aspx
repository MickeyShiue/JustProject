<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="https://www.youtube.com/iframe_api"></script>
    <script type="text/javascript">      
        window.onload = function () {
            var linkbtnArray = document.querySelectorAll('.a-hot');
            for (let i = 0; i < linkbtnArray.length; i++) {
                document.getElementById(`ContentPlaceHolder1_linkbtn${i + 1}`).onclick = function (e) {
                    e.preventDefault();
                    let src = document.getElementById(`ContentPlaceHolder1_linkbtn${i + 1}`).title;
                    let elmv = document.getElementById('ContentPlaceHolder1_MoviePlay');
                    elmv.setAttribute('src', src);
                };
            }
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="1600px" border="1" align="center">
        <tr>
            <td width="25%">
                <asp:Image Width="100%" ID="Image1" runat="server" ImageUrl="~/image/環太平洋gif.gif" />
            </td>
            <td align="center" width="50%">
               <%-- <iframe runat="server" id="MoviePlay" width="834" height="595" src="https://www.youtube.com/embed/0CmsVuvtqSM?autoplay=1" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>--%>
                 <iframe runat="server" id="MoviePlay" width="834" height="595" src="https://www.youtube.com/embed/0CmsVuvtqSM" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>
            </td>
            <td width="25%">
                <asp:Image Width="100%" ID="Image2" runat="server" ImageUrl="~/image/復仇者聯盟2gif.gif" />
            </td>
        </tr>
    </table>
    <table width="80%" border="1" align="center" style="background-image: url(image/test.jpg)">
        <tr>
            <td style="width: 20%; border: 5;">
                <table>
                    <tr align="center">
                        <td>
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/image/圖示/熱門影片預告.jpg" />
                            <br />
                            <asp:Panel ID="Panel_link" runat="server">
                                <table border="1" width="80%" align="center">
                                    <tr align="center">
                                        <td>
                                            <asp:LinkButton ID="linkbtn1" runat="server" class="a-hot"></asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td>
                                            <asp:LinkButton ID="linkbtn2" runat="server" class="a-hot"></asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td>
                                            <asp:LinkButton ID="linkbtn3" runat="server" class="a-hot"></asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td>
                                            <asp:LinkButton ID="linkbtn4" runat="server" class="a-hot"></asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td>
                                            <asp:LinkButton ID="linkbtn5" runat="server" class="a-hot"></asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td>
                                            <asp:LinkButton ID="linkbtn6" runat="server" class="a-hot"></asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td>
                                            <asp:LinkButton ID="linkbtn7" runat="server" class="a-hot"></asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td>
                                            <asp:LinkButton ID="linkbtn8" runat="server" class="a-hot"></asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td>
                                            <asp:LinkButton ID="linkbtn9" runat="server" class="a-hot"></asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td>
                                            <asp:LinkButton ID="linkbtn10" runat="server" class="a-hot"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="center" width="80%">
                <table width="100%">
                    <tr style="width: 100%">
                        <td align="center">
                            <br />
                            <asp:Label ID="lbl_mov_top10" runat="server" Text="最新發表" Font-Size="18"></asp:Label><br />
                            <br />
                            <asp:Table ID="TB_mov_top10" runat="server">
                            </asp:Table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <hr />
    <table width="65%" border="1" align="center" style="background-image: url(image/環太平洋table1.jpg)">
        <tr align="center" style="width: 100%">
            <td id="mastersuggest" runat="server">
                <asp:Image ID="Image10" runat="server" ImageUrl="~/image/圖示/站長推薦.jpg" />
                <asp:Table ID="tbl_mastersug" runat="server">
                </asp:Table>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
