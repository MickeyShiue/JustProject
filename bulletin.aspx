<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="bulletin.aspx.cs" Inherits="bulletin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="background-image: url(image/公告table.jpg); width: 1000px; height: 600px; margin: 50px 450px 0px">
        <table style="margin: 0px 20px 0px; height: 250px;">
            <tr>
                <td>
                    <br />
                    <asp:GridView ID="GridView1" runat="server" Height="280px"
                        Style="text-align: left; font-family: 標楷體;" Width="964px">
                        <HeaderStyle BackColor="red" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

