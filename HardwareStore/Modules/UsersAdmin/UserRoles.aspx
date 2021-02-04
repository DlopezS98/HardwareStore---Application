<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserRoles.aspx.cs" Inherits="HardwareStore.Modules.Catalogs.UserRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%-- Modal Alert --%>
    <div style="margin-top: 120px" class="modal fade" id="ModalAlert" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-dark">
                    <h5 class="modal-title text-light" id="exampleModalLabel">Advertencia!</h5>
                    <button type="button" class="close text-light" data-dismiss="modal" aria-label="Close">
                        <span class="text-light" aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    Estás seguro que quieres eliminar el usuario?
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                    <asp:Button ID="btnDelete" Text="Confirmar" runat="server" CssClass="btn btn-success" />
                </div>
            </div>
        </div>
    </div>

    <%-- Fin Modal Alert --%>

    <div class="container p-4">
        <div class="row">
            <div class="col-lg-12 mx-auto">
                <asp:UpdatePanel runat="server" ID="UpdatePanel">
                    <ContentTemplate>
                        <div class="Container_Seguridad">
                            <div class="row">
                                <div class="Button_Group pl-3">
                                    <a class="btn btn-success" href="Users.aspx">Nuevo Usuario</a>
                                </div>
                                <div class="col-lg-12 my-2">
                                    <table class="table">
                                        <thead class="thead-dark">
                                            <tr>
                                                <th scope="col">ID</th>
                                                <th scope="col">Nombre completo</th>
                                                <th scope="col">Rol</th>
                                                <th scope="col">Nombre de Usuario</th>
                                                <th scope="col">Estado</th>
                                                <th scope="col">Acciones</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <th scope="row">2</th>
                                                <td>Carlos Aguirre</td>
                                                <td>Administrador de Ventas</td>
                                                <td>CarlosAP</td>
                                                <td>Activo</td>
                                                <td>
                                                    <asp:Button Text="Editar" runat="server" CssClass="btn btn-primary" />
                                                    <button data-toggle="modal" data-target="#ModalAlert" class="btn btn-danger">Eliminar</button>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
