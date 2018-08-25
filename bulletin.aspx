<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="bulletin.aspx.cs" Inherits="bulletin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" type="text/css" href="Styles/Grid.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="text-center">
        <asp:GridView ID="GridView1" runat="server"
            CssClass="mGrid"
            PagerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt">
            <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <PagerStyle CssClass="pgr"></PagerStyle>
        </asp:GridView>
    </div>
</asp:Content>

