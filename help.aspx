<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="help.aspx.cs" Inherits="help" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="background-image:url(image/幫助table.jpg); width:1820px; height:920px; margin:25px 25px 0px;">
    <table style="margin:80px 50px 0px; width:1780px; height:800px; ">
        <tr>
            <td style="vertical-align:top;">
                <p>
                    <asp:LinkButton ID="LinkButton_須知" runat="server" OnClick="LinkButton1_Click"
                        Style="font-size: x-large; color: #FF3300;">用戶須知</asp:LinkButton>
                </p>
                <p>
                    <asp:LinkButton ID="LinkButton_註冊" runat="server" OnClick="LinkButton2_Click"
                        Visible="False"><asp:Image ID="Image1" runat="server" ImageUrl="image/圖示/Q.png" />我必須要註冊嗎?</asp:LinkButton>
                </p>
                <p>
                    <asp:Label ID="Label_註冊解答" runat="server" Text="必須要註冊成正式用戶後才能對帖子進行更多的操作，
        強烈建議您註冊，這樣會得到很多以遊客身份無法實現的功能。請"
                        Visible="False"></asp:Label>
                    <asp:LinkButton ID="LinkButton_導註冊" runat="server" PostBackUrl="~/Create Account.aspx"
                        Visible="False"><asp:Image ID="Image2" runat="server" ImageUrl="~/image/圖示/右.png" />點擊此處<asp:Image ID="Image3" runat="server" ImageUrl="~/image/圖示/左.png" /></asp:LinkButton>
                    <asp:Label ID="Label2" runat="server" Text="免費註冊成為我們的新用戶！" Visible="False"></asp:Label>
                </p>
                <p>
                    <asp:LinkButton ID="LinkButton_登入" runat="server" OnClick="LinkButton4_Click"
                        Visible="False"><asp:Image ID="Image4" runat="server" ImageUrl="image/圖示/Q.png" />我如何登錄論壇？</asp:LinkButton>
                </p>
                <p>
                    <asp:Label ID="Label_登入解答" runat="server" Text="如果您已經註冊成為該論壇的會員，可以經由首頁上方選單右側會員進行登入動作"
                        Visible="False"></asp:Label>
                </p>
                <br />
                <asp:LinkButton ID="LinkButton_帖子操作" runat="server"
                    OnClick="LinkButton5_Click" Style="font-size: x-large; color: #CC3300">帖子相關操作</asp:LinkButton>
                <p>
                    <asp:LinkButton ID="LinkButton_發文" runat="server" OnClick="LinkButton6_Click"
                        Visible="False">
                        <asp:Image ID="Image5" runat="server" ImageUrl="image/圖示/Q.png" />我如何發表文章?</asp:LinkButton>
                </p>
                <asp:Label ID="Label_發文解答" runat="server" Text="在論壇版塊中，點「發表文章」，或者登入會員後左方功能列中選擇「發表文章」"
                    Visible="False"></asp:Label>
                <p>
                    <asp:LinkButton ID="LinkButton_回復" runat="server" OnClick="LinkButton7_Click"
                        Visible="False">
                        <asp:Image ID="Image6" runat="server" ImageUrl="image/圖示/Q.png" />我如何發表回復?</asp:LinkButton>
                </p>
                <asp:Label ID="Label_回復解答" runat="server" Text="在文章版塊中文章下方點選「回復」"
                    Visible="False"></asp:Label>
                <p>
                    <asp:LinkButton ID="LinkButton_上傳" runat="server" OnClick="LinkButton8_Click"
                        Visible="False">
                        <asp:Image ID="Image7" runat="server" ImageUrl="image/圖示/Q.png" />我如何上傳物件?</asp:LinkButton>
                </p>
                <asp:Label ID="Label_上傳解答" runat="server" Text="發表新主題的時候上傳附件，步驟為：寫完帖子標題和內容後點上傳附件右方的瀏覽
，然後在本地選擇要上傳附件的具體文件名，最後點擊發表話題。"
                    Visible="False"></asp:Label>
                <br />
                <asp:LinkButton ID="LinkButton_功能操作" runat="server"
                    OnClick="LinkButton9_Click" Style="font-size: x-large; color: #CC3300">基本功能操作</asp:LinkButton>
                <p>
                    <asp:LinkButton ID="LinkButton_設好友" runat="server" OnClick="LinkButton10_Click"
                        Visible="False">
                        <asp:Image ID="Image8" runat="server" ImageUrl="image/圖示/Q.png" />如何將對方設為好友</asp:LinkButton>
                </p>
                <asp:Label ID="Label_好友解答" runat="server" Text="當您瀏覽某用戶的個人資料時，可以點擊下方的「加為好友」設置論壇好友。"
                    Visible="False"></asp:Label>
                <p>
                    <asp:LinkButton ID="LinkButton_設追蹤" runat="server" OnClick="LinkButton11_Click"
                        Visible="False">
                        <asp:Image ID="Image9" runat="server" ImageUrl="image/圖示/Q.png" />如何將對方設為追蹤</asp:LinkButton>
                    &nbsp;&nbsp;
                </p>
                <asp:Label ID="Label_追蹤解答" runat="server" Text="當您瀏覽某用戶的個人資料時，可以點擊下方的「設為」設置論壇好友。"
                    Visible="False"></asp:Label>
                <p>
                    <asp:LinkButton ID="LinkButton_舉報" runat="server" OnClick="LinkButton12_Click"
                        Visible="False">
                        <asp:Image ID="Image10" runat="server" ImageUrl="image/圖示/Q.png" />如何舉報</asp:LinkButton>
                </p>
                <asp:Label ID="Label_舉報解答" runat="server" Text="登入會員才可進行的動作，功能在左側"
                    Visible="False"></asp:Label>
                <p>
                    <asp:LinkButton ID="LinkButton_搜文" runat="server" OnClick="LinkButton13_Click"
                        Visible="False">
                        <asp:Image ID="Image11" runat="server" ImageUrl="image/圖示/Q.png" />如何搜尋文章</asp:LinkButton>
                </p>
                <asp:Label ID="Label_搜文解答" runat="server" Text="若要進行搜尋，點擊 論壇中 任一頁面上方的搜尋列，輸入要尋找的內容，
然後點擊放大鏡。"
                    Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
        </div>
</asp:Content>

