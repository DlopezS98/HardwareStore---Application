<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="HardwareStore.Modules.Reports.Index" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="border-top: 1px solid #C82333" class="container p-4 card mt-4 shadow rounded">
        <div class="d-flex justify-content-center m-4">
            <h3>Reportes</h3>
        </div>
        <div class="dropdown-divider mb-5">
        </div>
        <div class="row mt-2 mb-5">
            <div class="col-lg-3">
                <div class="card shadow rounded py-2">
                    <div class="card-body">
                        <h5 class="card-title text-center">Ventas</h5>
                        <%--<p class="card-text">Puedes crear reportes de Puedes crear reportes de ventasentas</p>--%>
                        <a href="#" class="btn btn-primary d-flex justify-content-center">Crear Reporte</a>
                    </div>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="card shadow rounded py-2 ">
                    <div class="card-body">
                        <h5 class="card-title text-center">Compras</h5>
                        <%--<p class="card-text">Puedes crear reportes de Compras</p>--%>
                        <a href="#" class="btn btn-primary d-flex justify-content-center">Crear Reporte</a>
                    </div>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="card shadow rounded py-2">
                    <div class="card-body">
                        <h5 class="card-title text-center">Productos</h5>
                        <%--<p class="card-text">Puedes crear reportes de los productos del negocio</p>--%>
                        <a href="#" class="btn btn-primary d-flex justify-content-center">Crear Reporte</a>
                    </div>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="card shadow rounded py-2">
                    <div class="card-body">
                        <h5 class="card-title text-center">Existencias</h5>
                        <%--<p class="card-text">Puedes crear reportes de existencias de productos</p>--%>
                        <a href="#" class="btn btn-primary d-flex justify-content-center">Crear Reporte</a>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <h3>Lista de productos</h3>
    <div class="row">
        <asp:Button Text="Vista principal" runat="server" ID="btnGoToMainView" />
    </div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
        <LocalReport ReportPath="Data\ProductsReports\ProductsReport.rdlc">
        </LocalReport>
    </rsweb:ReportViewer>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
