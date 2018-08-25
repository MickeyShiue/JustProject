<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MoviePage.aspx.cs" Inherits="MoviePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .backgroundRed{
            background-color:red
        }

         .backgrounddeepskyblue{
            background-color:darkblue
        }

        .backgroundGreen{
            background-color:forestgreen
        }


    </style>
    <link rel="stylesheet" type="text/css" href="Styles/Grid.css">


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <table align="center" style="width: 1200px">
        <tr>
            <td align="center">
    
                <span class="badge badge-danger backgroundRed">喜劇片</span>
                <asp:GridView ID="GridView_喜劇" runat="server" 
                    CssClass="mGrid"
                    AutoGenerateColumns="False"
                    CellPadding="3" 
                    GridLines="Vertical" 
                    Width="1100px" 
                    DataKeyNames="Id" 
                    OnRowDeleting="GridView_喜劇_RowDeleting"
                    AllowPaging="True" 
                    OnPageIndexChanging="GridView_喜劇_PageIndexChanging"
                    OnRowDataBound="GridView_喜劇_RowDataBound">
             
                    <Columns>
                        <asp:TemplateField HeaderText="標題">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Id", "Look.aspx?SuppNumb={0}") %>' Text='<%# Eval("title") %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="作者" SortExpression="暱稱">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="發文時間" SortExpression="時間">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("CreateTime") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("CreateTime") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="最後回覆" SortExpression="最後回覆">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("LastReplyTime") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("LastReplyTime") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" class="style17">
                <span class="badge badge-success backgroundGreen">動作片</span>
                <asp:GridView ID="GridView_動作" runat="server" 
                    CssClass="mGrid"
                    AutoGenerateColumns="False"
                    CellPadding="3" 
                    GridLines="Vertical" 
                    Width="1100px" 
                    DataKeyNames="Id" 
                    OnRowDeleting="GridView_動作_RowDeleting" 
                    AllowPaging="True"
                    OnPageIndexChanging="GridView_動作_PageIndexChanging"
                    OnRowDataBound="GridView_動作_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="標題">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server"
                                    NavigateUrl='<%# Eval("Id", "Look.aspx?SuppNumb={0}") %>'
                                    Text='<%# Eval("title") %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="作者" SortExpression="暱稱">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="發文時間" SortExpression="時間">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("CreateTime") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("CreateTime") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="最後回覆" SortExpression="最後回覆">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("LastReplyTime") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("LastReplyTime") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" class="style17">
                <span class="badge badge-primary backgrounddeepskyblue">愛情片</span>
                <asp:GridView ID="GridView_愛情" runat="server" 
                    CssClass="mGrid"
                    AutoGenerateColumns="False"
                    CellPadding="3"
                    GridLines="Vertical"
                    Width="1100px" 
                 
                    DataKeyNames="Id" 
                    OnRowDeleting="GridView_愛情_RowDeleting" AllowPaging="True"
                    OnPageIndexChanging="GridView_愛情_PageIndexChanging"
                    OnRowDataBound="GridView_愛情_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="標題">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server"
                                    NavigateUrl='<%# Eval("Id", "Look.aspx?SuppNumb={0}") %>'
                                    Text='<%# Eval("title") %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="作者" SortExpression="暱稱">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="發文時間" SortExpression="時間">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("CreateTime") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("CreateTime") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="最後回覆" SortExpression="最後回覆">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("LastReplyTime") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("LastReplyTime") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

