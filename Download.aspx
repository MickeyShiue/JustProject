<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Download.aspx.cs" Inherits="Download" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        img{
            width:200px;
            height:200px;
            padding:10px;
        }
    </style>

    <script>
        $(function () {
           $(".imgclick").on("click", function(e)
           {                  
                   let id = this.id;
                   let FileName = id.split('_')[1];    
                   window.location = `Download.aspx?FileName=${FileName}`;
           });
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
         <div id="Mycontainer" runat="server" style="display:inline-block;padding-left:40px;">
          
         </div>
</asp:Content>

