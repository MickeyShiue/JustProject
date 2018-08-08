<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Select.aspx.cs" Inherits="Select" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <center>
        <img
            onmouseout="UnTip()" style="width: 180px; height: 30px;"
            onmouseover="Tip('請將您要搜尋的項目，<br>完整的輸入文字方塊，<br>即可進行搜尋動作!!<br>', BALLOON, true, ABOVE, true, FONTFACE, '微軟正黑體', FONTSIZE, '16px')"
            alt=""
            src="image/圖示/文章搜尋.jpg" />
    </center>
    <br />
    <table align="center">
<tr>
<td align="left">
    <asp:TextBox ID="TextBox_Search" runat="server"></asp:TextBox>
    <asp:Button ID="Button_Search" runat="server" Text="搜尋" 
        onclick="Button_Search_Click" />
</td>
</tr>
</table>
<table align="center">
<tr>
<td align="center">
    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <asp:GridView ID="GridView1" runat="server" Width="693px" BackColor="White" 
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            GridLines="Vertical" AutoGenerateColumns="false" >
              <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="發文編號" 
                    DataNavigateUrlFormatString="Look.aspx?SuppNumb={0}" DataTextField="主旨" 
                    HeaderText="主旨" />
                     <asp:BoundField DataField="暱稱" HeaderText="暱稱" SortExpression="暱稱" />
                <asp:BoundField DataField="時間" HeaderText="時間" SortExpression="時間" />
                <asp:BoundField DataField="最後回覆" HeaderText="最後回覆" SortExpression="最後回覆" />
              </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>
    </asp:Panel>
</td>
</tr>
</table>
</asp:Content>

