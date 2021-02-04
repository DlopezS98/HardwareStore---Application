<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HardwareStore._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="text-align: center; margin-top: 1%">
        <h1 class="Title1 font-weight-bold">Bienvenido!</h1>
        <h4 class="Title2">¿Qué quieres hacer?</h4>
    </div>
    <div style="margin-left: 0%; margin-top: 2%">
        <div class="container">
            <div class="row d-flex justify-content-center">
                <div class="mx-3">
                    <div class="card shadow bg-white rounded" style="width: 18rem;">
                        <img runat="server" src="~/Images/ventas.png" class="card-img-top mt-4 mb-5" alt="...">
                        <div class="card-body">
                            <h5 class="card-title">Nueva Venta</h5>
                            <p class="card-text">Haz una nueva venta</p>
                            <div style="margin-top: 15px">
                                <a href="/Modules/Billing/Sales.aspx" class="btn btn-primary">Vamos</a>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="mx-3">
                    <div class="card shadow bg-white rounded" style="width: 18rem;">
                        <img runat="server" src="~/Images/reportes.png" class="card-img-top mt-2 mb-1 px-1" alt="...">
                        <div class="card-body">
                            <h5 class="card-title">Reporte</h5>
                            <p class="card-text">Crea un nuevo reporte</p>
                            <div style="margin-top: 15px">
                                <a href="/Modules/Reports/Index.aspx" class="btn btn-primary">Vamos</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="mx-3">
                    <div class="card shadow bg-white rounded" style="width: 18rem;">
                        <img runat="server" src="~/Images/compra.png" class="card-img-top mt-4 mb-5" alt="...">
                        <div class="card-body">
                            <h5 class="card-title">Nueva Compra</h5>
                            <p class="card-text">Haz una nueva compra</p>
                            <div style="margin-top: 15px">
                                <a href="/Modules/Billing/Purchases.aspx" class="btn btn-primary">Vamos</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
