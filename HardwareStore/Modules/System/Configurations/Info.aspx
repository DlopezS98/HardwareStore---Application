<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="HardwareStore.Modules.System.Configurations.Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="containerConfig mx-5 my-4">
        <div class="d-none form-logo">
            <h2>Ferretería  <span style="color: #1DC4E7">Sánchez</span></h2>
        </div>
        <div style="border-top: 1px solid #F66762" class="shadow bg-white rounded p-3">
            <h3 style="font-weight: bold; text-align:center">Edita los Datos</h3>
            <div class="form-row p-3">
                
                <div class="col-md-6 mt-3">
                    <div style="display: flex">
                        <input placeholder="Nombre del Local" runat="server" type="text" name="Type" id="Text1" class="form-control" />
                    </div>
                </div>
                <div class="col-md-6 mt-3">
                    <div style="display: flex;">
                        <input placeholder="Número RUC" runat="server" type="text" name="Type" id="Text2" class="form-control" />
                    </div>
                </div>
                <div class="col-md-12 mt-3">
                    <div style="display: flex">
                        <input placeholder="Dirección" runat="server" type="text" name="Type" id="Text3" class="form-control" />
                    </div>
                </div>
                <div class="col-md-12 mt-3">
                    <div style="display: flex">
                        <input placeholder="Descripción" runat="server" type="text" name="Type" id="Text4" class="form-control" />
                    </div>
                </div>
                <div class="col-md-4 mt-3">
                    <div style="display: flex">
                        <asp:DropDownList Width="60%" runat="server" class="form-control">
                            <asp:ListItem Text="+505" />
                            <asp:ListItem Text="..." />
                            <asp:ListItem Text="..." />
                        </asp:DropDownList>
                        <input placeholder="Teléfono" runat="server" type="text" name="Type" id="Text6" class="form-control" />
                    </div>
                </div>
                <div class="col-md-4 mt-3">
                    <input placeholder="Correo Electrónico" runat="server" type="text" name="Type" id="Text5" class="form-control" />
                </div>
                <div class="col-md-4 mt-3">
                    <div style="display: flex">
                        <input placeholder="Línea Fija" runat="server" type="text" name="Type" id="Text7" class="form-control" />
                    </div>
                </div>
                <div class="col-md-6 mt-3">
                    <div style="display: flex">
                        <input placeholder="Nombre del Propietario" runat="server" type="text" name="Type" id="Text8" class="form-control" />
                    </div>
                </div>
                <div class="col-md-6 mt-3">
                    <div style="display: flex">
                        <input placeholder="Nombre Fiscal" runat="server" type="text" name="Type" id="Text9" class="form-control" />
                    </div>
                </div>
                <div class="col-md-6 mt-3">
                    <div style="display: flex">
                        <input placeholder="Descripción de impuestos" runat="server" type="text" name="Type" id="Text10" class="form-control" />
                    </div>
                </div>

                <div class="col-md-6 mt-3">
                    <div style="display: flex">
                        <input placeholder="Tasa de Impuesto" runat="server" type="text" name="Type" id="Text11" class="form-control" />
                    </div>
                </div>
                <div class="col-md-6 mt-3 d-none" style="margin: 0 auto;">
                    <h5 style="text-align: center">Logo</h5>
                    <input type="file" title="Seleccionar Imagen" class="form-control" />
                </div>
            </div>
            <div style="width: 100%; margin: 20px; min-width: 150px; text-align: center">
                <a runat="server" class="btn btn-danger" href="~/Modules/System/Info.aspx">Cancelar</a>
                <asp:Button Text="Guardar" runat="server" CssClass="btn btn-success" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
