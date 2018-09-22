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

    <style>
        .MovieMenu{
            padding-top:25px;
            padding-left:80px;
            padding-bottom:25px;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="1600px" border="1" align="center">
        <tr>
            <td width="25%">
                <asp:Image Width="100%" ID="Image1" runat="server" ImageUrl="~/image/環太平洋gif.gif" />
            </td>
            <td align="center" width="50%">
                <iframe runat="server" id="MoviePlay" width="834" height="595" src="https://www.youtube.com/embed/0CmsVuvtqSM?autoplay=1" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>
             <%--    <iframe runat="server" id="MoviePlay" width="834" height="595" src="https://www.youtube.com/embed/0CmsVuvtqSM" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>--%>
            </td>
            <td width="25%">
                <asp:Image Width="100%" ID="Image2" runat="server" ImageUrl="~/image/復仇者聯盟2gif.gif" />
            </td>
        </tr>
            <tr>
            <td style="width: 25%; border:1px">
                <table>
                    <tr align="center">
                        <td class="MovieMenu">
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
            <td width="50%">
               
            </td>
            <td width="25%">

            </td>
        </tr>
    </table>  
</asp:Content>
