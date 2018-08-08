<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Download.aspx.cs" Inherits="Download" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <center>
        <img
            onmouseout="UnTip()" style="width: 180px; height: 30px;"
            onmouseover="Tip('請先將檔案名稱完整複製後，<br>貼入文字方塊當中，<br>即可進行下載動作!!<br>', BALLOON, true, ABOVE, true, FONTFACE, '微軟正黑體', FONTSIZE, '16px')"
            alt=""
            src="image/圖示/影音下載.jpg" />
    </center>
    <br />
<table align="center">
<tr>
<td align="center">
    <asp:Label ID="FileName_Label" runat="server" Text="請輸入檔案名稱"></asp:Label>
    <asp:TextBox ID="FineName_TextBox"
        runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td align="right">
    <asp:Label ID="LabeMessage" runat="server" Text="Label" Visible="False"></asp:Label>
    <asp:Button ID="Button1" runat="server" Text="下載" onclick="Button1_Click" />
</td>
</tr>
</table>

<table align="center">
<tr>
<td align="center">
    <asp:GridView ID="GridView1" runat="server" BackColor="White" AutoGenerateColumns="False" 
        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        GridLines="Vertical">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
          <Columns>
                 
                   <asp:TemplateField HeaderText="檔案名稱" SortExpression="Name">
                       <EditItemTemplate>
                           <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                       </ItemTemplate>
                  </asp:TemplateField>
                    <asp:TemplateField HeaderText="上傳時間" SortExpression="CreationTime">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CreationTime") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# Bind("CreationTime") %>' Visible="True"></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>                       
















            </Columns>
    </asp:GridView>
</td>
</tr>
</table>
</asp:Content>

