<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Share.aspx.cs" Inherits="share" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <ContentTemplate>
          <br />
          <center><asp:Image ID="Image1" runat="server" ImageUrl="~/image/圖示/影音上傳.jpg" /></center>
          <br />
<table align="center" >
<tr>
<td align="center">
            <asp:FileUpload ID="FileUpload1" runat="server" />
</td>
</tr>
<tr>
<td align="left">
    <asp:Button ID="UploadButton" runat="server" Text="上傳檔案" 
        onclick="UploadButton_Click" />
    <br />
    <asp:Label ID="UploadStatusLabel" runat="server"></asp:Label>
</td>
</tr>
</table>
    </ContentTemplate>
          <Triggers>
              <asp:PostBackTrigger ControlID="UploadButton" />
          </Triggers>
    </asp:UpdatePanel>
</asp:Content>

