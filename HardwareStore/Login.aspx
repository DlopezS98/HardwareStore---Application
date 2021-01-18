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
</head>
<body>
    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100">
                <div class="login100-form-title" style="background-image: url(images/tools.jpg);">
                    <span class="login100-form-title-1">Ferretería Sánchez
                    </span>
                </div>

                <form class="login100-form validate-form">
                    <div class="wrap-input100 validate-input m-b-26" data-validate="Username is required">
                        <span class="label-input100">Usuario</span>
                        <input runat="server" class="input100" type="text" name="username" placeholder="Nombre de Usuario" />
                        <span class="focus-input100"></span>
                    </div>

                    <div class="wrap-input100 validate-input m-b-18" data-validate="Contraseña">
                        <span class="label-input100">Contraseña</span>
                        <input runat="server" class="input100" type="password" name="pass" placeholder="Enter password" />
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
                        <a class="btn btn-success" href="Default.aspx">Entrar</a>
<%--                        <button class="login100-form-btn">
                            Entrar
                        </button>--%>
                    </div>
                </form>
            </div>
        </div>
    </div>

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

</body>
</html>
