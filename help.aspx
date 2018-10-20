<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="help.aspx.cs" Inherits="help" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .textClass {
            color: red;
            font-size: 20px;           
        }

        .textpadding {
            padding-left: 10px;
            padding-top: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">   
        <div id="accordion">
            <div class="card">
                <div class="card-header" id="headingOne">
                    <h5 class="mb-0">
                        <button class="btn btn-link" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne" type="button">
                            <span class="textClass">用戶須知 (點我) </span>
                        </button>
                    </h5>
                </div>

                <div id="collapseOne" class="collapse" aria-labelledby="headingOne" data-parent="#accordion">
                    <div class="card-body">
                        <span class="textClass textpadding">我必須要註冊嗎?</span>
                        <div class="textClass textpadding">
                            註冊成正式用戶後才能有更多的操作功能，強烈建議您註冊，這樣會得到很多以遊客身份無法實現的功能
                        </div>
                    </div>
                </div>
            </div>        
        </div>
</asp:Content>


