<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HardwareStore.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>

    <link runat="server" type="text/css" href="https://netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" />
    <link href="Styles/util.css" rel="stylesheet" />
    <link href="Styles/main.css" rel="stylesheet" />
    <link href="vendor/daterangepicker/daterangepicker.css" rel="stylesheet" />
    <link href="vendor/select2/select2.min.css" rel="stylesheet" />
    <link href="vendor/animsition/css/animsition.min.css" rel="stylesheet" />
    <link href="vendor/css-hamburgers/hamburgers.min.css" rel="stylesheet" />
    <link href="vendor/animate/animate.css" rel="stylesheet" />
    <link runat="server" type="text/css" href="Styles/Spinner.css" rel="stylesheet" media="screen" />
    <link runat="server" type="text/css" href="Styles/Toast.css" rel="stylesheet" media="screen" />
</head>
<body>
    <form runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <%--<asp:ScriptReference Name="bootstrap" />--%>
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
            </Scripts>
        </asp:ScriptManager>

        <div id="spinner-loader" class="spinner-container d-flex justify-content-center align-items-center">
            <div class="spinner-border text-warning" style="width: 5rem; height: 5rem; border-width: 8px;" role="status">
                <span class="sr-only">Loading...</span>
            </div>
        </div>

        <asp:UpdatePanel runat="server" ID="updatepanelforuserloggin">
            <ContentTemplate>
                <div class="limiter">
                    <div class="container-login100">
                        <div class="wrap-login100">
                            <div class="login100-form-title" style="background-image: url(images/tools.jpg);">
                                <span class="login100-form-title-1">Ferretería Sánchez
                                </span>
                            </div>
                            <div class="p-4">
                            <div style="padding-left: 150px; padding-right: 50px">
                                <form class="login100-form validate-form">
                                    <div class="wrap-input100 validate-input m-b-26" data-validate="Username is required">
                                        <span class="label-input100">Usuario</span>
                                        <input runat="server" id="txtUserName" class="input100" type="text" name="username" placeholder="Nombre de Usuario" />
                                        <span class="focus-input100"></span>
                                    </div>

                                    <div class="wrap-input100 validate-input m-b-18" data-validate="Contraseña">
                                        <span class="label-input100">Contraseña</span>
                                        <input runat="server" id="txtPassword" class="input100" type="password" name="pass" placeholder="Enter password" />
                                        <span class="focus-input100"></span>
                                    </div>

                                    <div class="flex-sb-m w-full p-b-30">
                                        <div class="contact100-form-checkbox">
                                            <input runat="server" class="input-checkbox100" id="ckb1" type="checkbox" name="remember-me" />
                                            <label class="label-checkbox100" for="ckb1">
                                                Recordarme
                                            </label>
                                        </div>

                                        <div>
                                            <a href="#" class="txt1">Olvidaste tu contraseña?
                                            </a>
                                        </div>
                                    </div>

                                    <div class="container-login100-form-btn">
                                        <asp:Button Text="Entrar" runat="server" OnClientClick="ShowLoader(true)" ID="btnLoggin" OnClick="btnLoggin_Click" CssClass="btn btn-success" />
                                        <%--                        <button class="login100-form-btn">
                            Entrar
                        </button>--%>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <div id="Toast-Alert" class="toast">
            <div id="Toast-Image-Type" class="toast-img"><i class="fas fa-exclamation"></i></div>
            <div id="Toast-Body" class="toast-body">
                <p id="Toast-Content" style="text-align: justify;">
                    Producto agregado al detalle!
                </p>
            </div>
        </div>
    </form>

    <!--===============================================================================================-->
    <script src="vendor/animsition/js/animsition.min.js"></script>
    <!--===============================================================================================-->
    <script src="https://kit.fontawesome.com/51fc41aab1.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/select2/select2.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/daterangepicker/moment.min.js"></script>
    <script src="vendor/daterangepicker/daterangepicker.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/countdowntime/countdowntime.js"></script>
    <!--===============================================================================================-->
    <script src="js/main.js"></script>
    <script>
        function ShowToaster(message, CssClass) {
            var style = "toast-img-" + CssClass;

            var image = document.getElementById('Toast-Image-Type');
            image.classList.remove(style);
            image.classList.add(style);

            var alert = document.getElementById('Toast-Alert');
            alert.classList.add("show");

            var content = document.getElementById('Toast-Content');
            content.innerHTML = message;

            setTimeout(function () {
                alert.classList.remove("show");
                content.innerHTML = "";
                image.classList.remove(style);
            }, 3000);
        }

        function ShowLoader(status) {
            console.log(status);
            var spinner = document.getElementById('spinner-loader');
            if (status) {
                spinner.classList.remove("hide");
                spinner.classList.add('show');
            } else {
                spinner.classList.add("hide");
                //spinner.classList.remove("show");
            }
        }

        function LoggedIn(message, CssClass, user) {
            var data = JSON.parse(user);
            console.log(data);
            this.ShowLoader(false);
            this.ShowToaster(message, CssClass);
            localStorage.setItem('user', user);
            setTimeout(function () {
                window.location.href = "/";
            }, 3000)
        }
    </script>
</body>
</html>
