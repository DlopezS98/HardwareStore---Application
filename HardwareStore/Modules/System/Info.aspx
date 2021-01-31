<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="HardwareStore.Modules.System.Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="containerConfig">
        <div class="form-logo d-none">
            <h2>Ferretería  <span style="color: #1DC4E7">Sánchez</span></h2>
        </div>
        <div style="border-top: 1px solid #F66762" class="form-principal p-4 shadow bg-white rounded m-4">
            <div class="d-none" style="text-align: center; margin: 10px">
                <h2>Configuración</h2>
            </div>
            <h3 style="text-align: center; font-weight: bold; color: #222A35">Datos del Negocio</h3>
            <div style="height: 0.5px; width: 100%; opacity: 0.3; background: #222A35" class="mt-4"></div>
            <div class="form-row mt-4 ">                
                <div class="col-md-6 p-2">
                    <b>Nombre del Local:</b> Ferretería Sánchez 
                </div>
                <div class="col-md-6 p-2">
                    <b>Número RUC:</b> 08418652
                </div>
                <div class="col-md-6 p-2">
                    <b>Dirección:</b> Lorem ipsum dolor sit amet, consectetur adipiscing elit 
                </div>
                <div class="col-md-6 p-2">
                    <b>Descripción:</b> Lorem ipsum dolor sit amet, consectetur adipiscing elit
                </div>
                <div class="col-md-6 p-2">
                    <b>Correo Electrónico:</b> ejemplo@ejemplo.com 
                </div>
                <div class="col-md-6 p-2">
                    <b>Teléfono:</b> +505 8888-8888
                </div>
                <div class="col-md-6 p-2">
                    <b>Linea Fija:</b> 2222-2222 
                </div>
                <div class="col-md-6 p-2">
                    <b>Nombre del Propietario:</b> Goku Uzumaki
                </div>
                <div class="col-md-6 p-2">
                    <b>Nombre Fiscal:</b> ... 
                </div>
                <div class="col-md-6 p-2">
                    <b>Decripción de Impuestos:</b> ...
                </div>
                <div class="col-md-6 p-2">
                    <b>Tasa de Impuestos</b> ... 
                </div>
                <div class="col-md-6 p-2">
                    <b>Creado en:</b> 01/01/2020 
                </div>
                <div class="col-md-6 p-2">
                    <b>Actualizado en:</b> 14/12/2020
                </div>
                <div class=" col-md-12 d-flex justify-content-center mt-5">
                    <a href="~/Modules/System/Configurations/Info.aspx" class="btn btn-success" runat="server" ID="btnEdit">Editar</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
