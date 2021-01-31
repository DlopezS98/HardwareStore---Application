<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TranfersAdministration.aspx.cs" Inherits="HardwareStore.Modules.ProductsAdmin.TranfersAdministration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel2">
        <ContentTemplate>
            <div class="p-3">
                <h3 style="color: #1F2126; text-align: center; margin-top: 35px">Historial de Transferencias</h3>
                <div class="form-row mt-4">
                    <div class="col-md-6">
                        <asp:TextBox placeholder="Buscar" runat="server" ID="txtOrdNumber" class="form-control" />
                    </div>
                    <div class="col-md-6 pl-4">
                        <asp:Button class="btn btn-primary" type="button" runat="server" Text="Buscar" />
                    </div>
                </div>
                <br />
                <%-- Tabla --%>
                <div style="max-width: 100%; overflow-x: scroll; display: inline-block; min-width: 30%; max-height: 250px; overflow-y: scroll" class="TableContainer mt-2 col-md-12">
                    <table class="table">
                        <asp:GridView runat="server" DataKeyNames="Code" AutoGenerateColumns="false"
                            ID="GridViewCategories" CssClass="table table-hover" CellPadding="5">
                            <HeaderStyle CssClass="thead-dark" />
                            <Columns>
                                <asp:BoundField HeaderText="ID" />
                                <asp:BoundField HeaderText="Nombre" />
                                <asp:BoundField HeaderText="Iniciales" />
                                <asp:BoundField HeaderText="Codigo" />
                                <asp:BoundField HeaderText="Cargo" />
                                <asp:BoundField HeaderText="Creado en" />
                                <asp:BoundField HeaderText="Creado por" />
                                <asp:BoundField HeaderText="Actualizado en" />
                                <asp:BoundField HeaderText="Actualizado por" />
                                <asp:BoundField HeaderText="Eliminado" />
                                <asp:TemplateField HeaderText="Opciones">
                                    <ItemTemplate>
                                        <asp:Button Text="Editar" runat="server" CssClass="btn btn-primary" />
                                        <asp:Button Text="Eliminar" runat="server" CssClass="btn btn-danger" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
