<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="HardwareStore.Modules.UsersAdmin.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container p-4">
        <div class="row">
            <div class="col-lg-12">
                <asp:UpdatePanel runat="server" ID="UpdatePanel">
                    <ContentTemplate>
                        <div class="d-flex justify-content-center"> 
                            <div class="row d-flex justify-content-center col-lg-8 card-shadow">
                                <div style="text-align: center">
                                    <h2 class="mt-2 text-center">Crear Nuevo Usuario</h2>
                                </div>
                                <div class="formSection form-row mt-5">
                                    <asp:TextBox Visible="false" ReadOnly="true" runat="server" placeholder="Codigo Usuario" CssClass="form-control" />
                                    <div class="col-md-6">
                                        <label runat="server">Empleado</label>
                                        <asp:DropDownList runat="server" class="form-control">
                                            <asp:ListItem>Empleados</asp:ListItem>
                                            <asp:ListItem>Danny López</asp:ListItem>
                                            <asp:ListItem>Rubén Parrales</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6">
                                        <label runat="server">Privilegio</label>
                                        <asp:DropDownList runat="server" class="form-control">
                                            <asp:ListItem>Seleccione el rol</asp:ListItem>
                                            <asp:ListItem>Administrador del sistema</asp:ListItem>
                                            <asp:ListItem>Administrador de ventas</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6">
                                        <label runat="server">Contraseña</label>
                                        <asp:TextBox runat="server" placeholder="Contraseña" CssClass="form-control" />
                                    </div>
                                    <div class="col-md-6">
                                        <label runat="server">Foto</label>
                                        <input type="file" title="Seleccionar Imagen" class="form-control" />
                                    </div>
                                    <div style="width: 100%; margin: 20px; min-width: 150px; text-align: center">
                                        <asp:Button runat="server" Text="Agregar" CssClass="btn btn-success" Style="margin-left: 10px" />
                                        <asp:Button runat="server" Text="Cancelar" CssClass="btn btn-danger" Style="margin-left: 10px" />
                                    </div>
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
