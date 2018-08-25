<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="bulletin.aspx.cs" Inherits="bulletin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .mGrid {
            width: 100%;
            background-color: #fff;
            margin: 5px 0 10px 0;
            border: solid 1px #525252;
            border-collapse: collapse;
        }

            .mGrid td {
                padding: 2px;
                border: solid 1px #c1c1c1;
                color: #717171;
            }

            .mGrid th {
                padding: 4px 2px;
                color: #fff;
                background: #424242 repeat-x top;
                border-left: solid 1px #525252;
                font-size: 0.9em;
                text-align:center
            }

            .mGrid .pgr table {
                margin: 5px 0;
            }

            .mGrid .pgr td {
                border-width: 0;
                padding: 0 6px;
                border-left: solid 1px #666;
                font-weight: bold;
                color: #fff;
                line-height: 12px;
            }

            .mGrid .pgr a {
                color: #666;
                text-decoration: none;
            }

            .mGrid .pgr a:hover {
                    color: #000;
                    text-decoration: none;
            }
    </style>
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

