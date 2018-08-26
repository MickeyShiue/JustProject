<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MovieDetail.aspx.cs" Inherits="MovieDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="https://www.youtube.com/iframe_api"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="text-center">
        <div>
            <asp:Image ID="Images" Width="700" Height="300" runat="server" OnLoad="Images_Load" />
        </div>
        <div>
            <iframe runat="server" id="MoviePlay" width="700" height="315" src="" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>
        </div>
        <div>
            <div class="row">
                <div class="col-md-4">
                </div>
                <div class="col-md-4">
                    <span style="color: White">電影簡介: </span>
                    <br />
                    <div class="pull-left">
                        <asp:Label ID="Label_Contents" runat="server" Text="Label" ForeColor="White"></asp:Label>
                    </div>
                </div>
                <div class="col-md-4">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
