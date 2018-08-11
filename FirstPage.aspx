<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FirstPage.aspx.cs" Inherits="FirsrPage" %>

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
                                    <tr align="center">
                                        <td id="td_btnUpData" runat="server">
                                            <asp:Button ID="btnUpData" runat="server" Text="更新連結" OnClick="btnUpData_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="Panel_Update" runat="server">
                                <table border="2" width="80%">
                                    <tr>
                                        <td>
                                            <asp:Image ID="Image4" runat="server" ImageUrl="~/image/圖示/連結編號.jpg" />

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlnumber" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Image ID="Image5" runat="server" ImageUrl="~/image/圖示/標題.jpg" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBox_名稱" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Image ID="Image6" runat="server" ImageUrl="~/image/圖示/網址.jpg" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBox_路徑" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button ID="btninto" runat="server" Text="更新" OnClick="btninto_Click" />
                                            <asp:Button ID="btnend" runat="server" Text="結束" OnClick="btnend_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbl_Panel_Update_chang_tip" runat="server" Text="請貼上Youtube鑲入式影片連結中Src中的連結網址"></asp:Label><br />
                                            <a id="Panel_Update_chang_tip" runat="server" onclick="window.open ('https://support.google.com/youtube/answer/171780?hl=zh-Hant','設定教學',config='height=500,width=500');"
                                                style="color: #FF0000">連結參數設定請參照官網(點我)</a>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr align="center">
                        <td style="margin-left: 5%; width: 20%;">
                            <a id="Sug_web" runat="server" visible="true">
                                <asp:Image ID="Image7" runat="server" ImageUrl="~/image/圖示/好站推薦.jpg" /><%--<asp:Label ID="lblSugweb" runat="server" Text="好站推薦" Font-Size="18"></asp:Label>--%>
                                <asp:Table ID="SuggestWeb" runat="server" BorderWidth="1">
                                </asp:Table>
                                <br />
                                <asp:Button ID="Delete_SuggestWeb" runat="server" Text="移除連結" OnClick="Delete_SuggestWeb_Click" />
                                <asp:Button ID="Add_SuggestWeb" runat="server" Text="新增連結" OnClick="Add_SuggestWeb_Click" />
                            </a><a id="Add_Sug" runat="server" visible="false">
                                <asp:Label ID="lbladd_sug" runat="server" Text="新增網站" Font-Size="18"></asp:Label>
                                <br />
                                <br />
                                <asp:Image ID="Image8" runat="server" ImageUrl="~/image/圖示/網站名稱.jpg" /><%--<asp:Label ID="lbladd_title" runat="server" Text="網站名稱"></asp:Label>--%>
                                <asp:TextBox ID="TextBox_add_title" runat="server" Height="17px"></asp:TextBox>
                                <br />
                                <br />
                                <asp:Image ID="Image9" runat="server" ImageUrl="~/image/圖示/網站網址.jpg" /><%--<asp:Label ID="lbladd_src" runat="server" Text="網站網址"></asp:Label>--%>
                                <asp:TextBox ID="Text_add_src" runat="server"></asp:TextBox>
                                <br />
                                <br />
                                <asp:Button ID="add_ok" runat="server" Text="確定" OnClick="add_ok_Click" />
                                <asp:Button ID="add_end" runat="server" Text="離開" OnClick="add_end_Click" />
                            </a><a visible="false" id="Del_Sug" runat="server">
                                <asp:Label ID="lbldel_sug" runat="server" Text="選擇刪除項目" Font-Size="18"></asp:Label>
                                <asp:CheckBoxList ID="CheckBox_SuggestWeb" runat="server" BorderWidth="1">
                                </asp:CheckBoxList>
                                <br />
                                <asp:Button ID="Delete_ok_SuggestWeb" runat="server" Text="確定刪除" OnClick="Delete_ok_SuggestWeb_Click" />
                                <asp:Button ID="End_SuggestWeb" runat="server" Text="離開" OnClick="End_SuggestWeb_Click" />
                            </a>
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
                <asp:Image ID="Image10" runat="server" ImageUrl="~/image/圖示/站長推薦.jpg" /><%--<asp:Label ID="lol_mastersug" runat="server" Text="站長推薦" Font-Size="18"></asp:Label>--%>
                <asp:Table ID="tbl_mastersug" runat="server">
                </asp:Table>
                <br />
                <asp:Button ID="btn_mastersug" runat="server" Text="更改連結" OnClick="btn_mastersug_Click" />
            </td>
        </tr>
        <tr align="center">
            <td id="Change_mastersug" runat="server" visible="false" align="center" style="width: 100%">
                <table width="50%" style="border-style: groove">
                    <tr style="width: 100%">
                        <td colspan="2">
                            <asp:Label ID="lbl_mastersug_teach" runat="server" Text="請貼上Youtube鑲入式影片連結中Src中的連結網址"></asp:Label><br />
                            <a id="lk_btn_mastersug" runat="server" onclick="window.open ('https://support.google.com/youtube/answer/171780?hl=zh-Hant','設定教學',config='height=500,width=500');"
                                style="color: #FF0000">連結參數設定請參照官網(點我)</a>
                        </td>
                    </tr>
                    <tr style="width: 100%">
                        <td class="style14">
                            <asp:Label ID="lbl_mastersug_check_delete" runat="server" Text="選擇剔除連結:">
                            </asp:Label><asp:DropDownList ID="ddl_mastersug" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="lbl_mastersug_Add_title" runat="server" Text="標題名稱:"></asp:Label>
                            <asp:Label ID="lbl_mastersug_Add_title2" runat="server" Text="尚未選取內容"></asp:Label>
                        </td>
                    </tr>
                    <tr style="width: 100%">
                        <td class="style14">
                            <asp:FileUpload ID="FileUpload_img" runat="server" /><br />
                            <asp:Button ID="btn_ReFileUpload_img" runat="server" Text="重新選擇圖片" Visible="false"
                                OnClick="btn_ReFileUpload_img_Click" />
                            <asp:Button ID="btn_check_image" runat="server" OnClick="btn_check_image_Click" Text="預覽" />
                        </td>
                        <td>
                            <asp:Label ID="lbl_mastersug_Add_src" runat="server" Text="連結網址:"></asp:Label><br />
                            <asp:TextBox ID="tb_mastersug_Add_src" runat="server" TextMode="MultiLine" Width="210"></asp:TextBox><br />
                        </td>
                    </tr>
                    <tr style="width: 100%">
                        <td colspan="2">
                            <asp:Image ID="Image_mastersug_Add_image" runat="server" Width="200px" Height="200px" />
                        </td>
                    </tr>
                    <tr style="width: 100%">
                        <td class="style14">
                            <asp:Button ID="btn_mastersug_Add_ok" runat="server" Text="確定更改" OnClick="btn_mastersug_Add_ok_Click"
                                Visible="false" />
                            <asp:Label ID="lbl_mastersug_Add_tip" runat="server" Text="請預覽圖片後上傳" Style="color: #FF0000; font-size: 20px;"></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="btn_mastersug_Add_end" runat="server" Text="離開" OnClick="btn_mastersug_Add_end_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
