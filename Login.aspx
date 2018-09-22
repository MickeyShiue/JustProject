<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        @media (min-width: 768px) {
            .omb_row-sm-offset-3 div:first-child[class*="col-"] {
                margin-left: 25%;
            }
        }

        .omb_login .omb_authTitle {
            text-align: center;
            line-height: 300%;
        }

        .omb_login .omb_socialButtons a {
            color: white;
        }

            .omb_login .omb_socialButtons a:hover {
                color: white;
                opacity: 1;
            }

        .omb_login .omb_socialButtons .omb_btn-facebook {
            background: #3b5998;
        }

        .omb_login .omb_socialButtons .omb_btn-twitter {
            background: #00aced;
        }

        .omb_login .omb_socialButtons .omb_btn-google {
            background: #c32f10;
        }

        .omb_login .omb_loginOr {
            position: relative;
            font-size: 1.5em;
            color: #aaa;
            margin-top: 1em;
            margin-bottom: 1em;
            padding-top: 0.5em;
            padding-bottom: 0.5em;
        }

            .omb_login .omb_loginOr .omb_hrOr {
                background-color: #cdcdcd;
                height: 1px;
                margin-top: 0px !important;
                margin-bottom: 0px !important;
            }

            .omb_login .omb_loginOr .omb_spanOr {
                display: block;
                position: absolute;
                left: 50%;
                top: -0.6em;
                margin-left: -1.5em;
                background-color: white;
                width: 3em;
                text-align: center;
            }

        .omb_login .omb_loginForm .input-group.i {
            width: 2em;
        }

        .omb_login .omb_loginForm .help-block {
            color: red;
        }


        @media (min-width: 768px) {
            .omb_login .omb_forgotPwd {
                text-align: right;
                margin-top: 10px;
            }
        }
    </style>

    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="omb_login">
            <h3 class="omb_authTitle">Login or <a href="#">Sign up</a></h3>
            <div class="row omb_row-sm-offset-3 omb_socialButtons">
                <div class="col-xs-4 col-sm-2">
                    <a href="~/FacebookLogin.aspx" class="btn btn-lg btn-block omb_btn-facebook" runat="server"  OnClick="FBLogin_Click">
                        <i class="fa fa-facebook visible-xs"></i>
                        <span class="hidden-xs">Facebook</span>
                    </a>
                </div>
                <div class="col-xs-4 col-sm-2">
                    <a href="#" class="btn btn-lg btn-block omb_btn-twitter">
                        <i class="fa fa-twitter visible-xs"></i>
                        <span class="hidden-xs">Twitter</span>
                    </a>
                </div>
                <div class="col-xs-4 col-sm-2">
                    <a href="GoogleLogin.aspx" class="btn btn-lg btn-block omb_btn-google">
                        <i class="fa fa-google-plus visible-xs"></i>
                        <span class="hidden-xs">Google+</span>
                    </a>
                  
                </div>
            </div>
            <div class="row omb_row-sm-offset-3 omb_loginOr">
                <div class="col-xs-12 col-sm-6">
                    <hr class="omb_hrOr">
                    <span class="omb_spanOr">or</span>
                </div>
            </div>
            <div class="row omb_row-sm-offset-3">
                <div class="col-xs-12 col-sm-6">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-user"></i></span>
                        <input id="Account" runat="server" type="text" class="form-control" autocomplete="off" name="Account" placeholder="email address" />
                    </div>
                    <span class="help-block"></span>
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                        <input id="Password" runat="server" type="password" class="form-control" autocomplete="off" name="Password" placeholder="Password" />
                    </div>
                    <span class="help-block"></span>
                    <asp:Button ID="btnLogin" class="btn btn-lg btn-primary btn-block" runat="server" Text="Login" OnClick="btnLogin_Click" />
                </div>
            </div>

            <div class="row omb_row-sm-offset-3">
                <div class="col-xs-12 col-sm-3">
                </div>
                <div class="col-xs-12 col-sm-3">
                    <p class="omb_forgotPwd">
                        <a href="#"></a>
                    </p>
                </div>
            </div>
        </div>
    </div>

    <input type="hidden" id="AlertTitle" value="" runat="server" />
    <input type="hidden" id="AlertContent" value="" runat="server" />
    <input type="hidden" id="AlertType" value="" runat="server" />

    <script>
        $(function () {
            let AlertTitle = $('#ContentPlaceHolder1_AlertTitle').val();
            let AlertContent = $('#ContentPlaceHolder1_AlertContent').val();
            let AlertType = $('#ContentPlaceHolder1_AlertType').val();
            //如果Alert 沒有資訊就不彈出視窗
            if (AlertTitle !== "" || AlertContent !== "" || AlertType !== "") {
                swal({
                    title: AlertTitle,
                    text: AlertContent,
                    type: AlertType
                }).then(function () {
                    if (AlertType === "success") {
                       window.location = "Index.aspx";
                    }
                });
            }
        })
    </script>
</asp:Content>

