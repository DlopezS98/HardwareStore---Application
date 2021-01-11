<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HardwareStore._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="text-align: center; margin-top: 1%">
        <h1 class="Title1">Bienvenido!</h1>
        <h4 class="Title2">¿Qué quieres hacer?</h4>
    </div>
    <div style="margin-left: 0%; margin-top: 2%">
        <div class="container">
            <div class="row mx-md-n5">
                <div class="col px-md-5">
                    <div class="card" style="width: 18rem;">
                        <img runat="server" src="Images/clientes.png" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title">Nueva Venta</h5>
                            <p class="card-text">Haz una nueva venta</p>
                            <div style="margin-top: 15px">
                                <a href="/Modules/Sales.Module/MainSales.aspx" class="btn btn-primary">Vamos</a>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col px-md-5">
                    <div class="card" style="width: 18rem;">
                        <img runat="server" src="~/Images/lista-tareas.png" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title">Reporte</h5>
                            <p class="card-text">Crea un nuevo reporte</p>
                            <div style="margin-top: 15px">
                                <a href="/Modules/Reports.Module/MainReports.aspx" class="btn btn-primary">Vamos</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col px-md-5">
                    <div class="card" style="width: 18rem;">
                        <img runat="server" src="~/Images/mensajero-trabajando.png" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title">Nueva Compra</h5>
                            <p class="card-text">Haz una nueva compra</p>
                            <div style="margin-top: 15px">
                                <a href="/Modules/Orders.Module/OrdersPage.aspx" class="btn btn-primary">Vamos</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
