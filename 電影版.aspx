<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="電影版.aspx.cs" Inherits="文章列表" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style15
        {
            font-family: 標楷體;
            color: #3366FF;
        }
        .style17
        {
            height: 198px;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
  
  <table align="center" style="width: 1200px" >
  <tr>
  <td  align="center">
     <!-- <span class="style15"><strong>喜劇片</strong></span>--> 
        <asp:Button ID="btnMax" runat="server" PostBackUrl="~/發文.aspx" Text="管理者發文" 
          Visible="False" Width="95px" onclick="btnMax_Click" />
      <br />
      <span class="style15"><strong>喜劇片</strong></span><asp:GridView ID="GridView_喜劇" runat="server" AutoGenerateColumns="False" 
            CellPadding="3" GridLines="Vertical" Width="620px" BackColor="White" 
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            DataKeyNames="發文編號" onrowdeleting="GridView_喜劇_RowDeleting" 
          AllowPaging="True" onpageindexchanging="GridView_喜劇_PageIndexChanging" 
          onrowdatabound="GridView_喜劇_RowDataBound">
               <Columns>
                   <asp:TemplateField HeaderText="標題">
                       <ItemTemplate>
                           <asp:HyperLink ID="HyperLink1" runat="server" 
                               NavigateUrl='<%# Eval("發文編號", "Look.aspx?SuppNumb={0}") %>' 
                               Text='<%# Eval("主旨") %>'></asp:HyperLink>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="作者" SortExpression="暱稱">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("暱稱") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# Bind("暱稱") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="發文時間" SortExpression="時間">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("時間") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label2" runat="server" Text='<%# Bind("時間") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="最後回覆" SortExpression="最後回覆">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("最後回覆") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label3" runat="server" Text='<%# Bind("最後回覆") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
            </Columns>
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
        </asp:GridView>
      </td>
     </tr>
     <tr>
       <td align="center" class="style17">
           <span class="style15"><strong>動作片</strong></span>
        <asp:GridView ID="GridView_動作" runat="server" AutoGenerateColumns="False" 
            CellPadding="3" GridLines="Vertical" Width="620px" BackColor="White" 
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            DataKeyNames="發文編號" onrowdeleting="GridView_動作_RowDeleting" AllowPaging="True" 
               onpageindexchanging="GridView_動作_PageIndexChanging" 
               onrowdatabound="GridView_動作_RowDataBound">
               <Columns>
                   <asp:TemplateField HeaderText="標題">
                       <ItemTemplate>
                           <asp:HyperLink ID="HyperLink1" runat="server" 
                               NavigateUrl='<%# Eval("發文編號", "Look.aspx?SuppNumb={0}") %>' 
                               Text='<%# Eval("主旨") %>'></asp:HyperLink>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="作者" SortExpression="暱稱">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("暱稱") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# Bind("暱稱") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="發文時間" SortExpression="時間">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("時間") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label2" runat="server" Text='<%# Bind("時間") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="最後回覆" SortExpression="最後回覆">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("最後回覆") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label3" runat="server" Text='<%# Bind("最後回覆") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
            </Columns>
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
        </asp:GridView>
      </td>
        </tr>
        <tr>
         <td align="center" class="style17">
             <span class="style15"><strong>愛情片</strong></span>
        <asp:GridView ID="GridView_愛情" runat="server" AutoGenerateColumns="False" 
            CellPadding="3" GridLines="Vertical" Width="620px" BackColor="White" 
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            DataKeyNames="發文編號" onrowdeleting="GridView_愛情_RowDeleting" AllowPaging="True" 
               onpageindexchanging="GridView_愛情_PageIndexChanging" 
                 onrowdatabound="GridView_愛情_RowDataBound">
               <Columns>
                   <asp:TemplateField HeaderText="標題">
                       <ItemTemplate>
                           <asp:HyperLink ID="HyperLink1" runat="server" 
                               NavigateUrl='<%# Eval("發文編號", "Look.aspx?SuppNumb={0}") %>' 
                               Text='<%# Eval("主旨") %>'></asp:HyperLink>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="作者" SortExpression="暱稱">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("暱稱") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# Bind("暱稱") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="發文時間" SortExpression="時間">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("時間") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label2" runat="server" Text='<%# Bind("時間") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="最後回覆" SortExpression="最後回覆">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("最後回覆") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label3" runat="server" Text='<%# Bind("最後回覆") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
            </Columns>
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
        </asp:GridView>
      </td>
      </tr>
        </table>
</asp:Content>

