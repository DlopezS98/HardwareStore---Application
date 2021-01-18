<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="HardwareStore.Modules.Catalogs.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%-- Modal --%>
    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header  bg-dark">
                    <h5 class="modal-title text-light" id="exampleModalLabel">Nuevo Detalle producto</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span class="text-light" aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-row p-3">
                        <div class="col-md-12">
                            <label style="float: left; margin-left: 5px;">Nombre</label>
                            <br />
                            <br />
                            <input runat="server" type="text" name="Type" id="Text4" class="form-control" />
                        </div>

                        <div class="col-md-12">
                            <label style="float: left; margin-left: 5px;">Decripción</label>
                            <br />
                            <br />
                            <input runat="server" type="text" name="Type" id="Text5" class="form-control" />
                        </div>
                    </div>
                    <div style="width: 100%; margin: 20px; min-width: 150px; text-align: center">
                        <asp:Button Visible="false" OnClick="BtnAtras_Click" Text="Cancelar" runat="server" CssClass="btn btn-danger" />
                        <asp:Button Visible="false" Text="Guardar" runat="server" CssClass="btn btn-success" />
                    </div>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>
    <%-- Fin Modal --%>
    <asp:MultiView ID="mtvContenedor" runat="server" ActiveViewIndex="0">
        <%-- Vista Llenar Producto --%>
        <asp:View ID="vVista0" runat="server">
            <div class="d-flex justify-content-center">
                <div class="w-50 mt-5 shadow bg-white rounded p-2">
                    <div style="float: right">
                        <asp:Button CssClass="btn btn-primary mt-2 mr-2" runat="server" OnClick="BtnTodos_Click" Text="Ver Todos" ID="BtnTodos" />
                    </div>
                    <div style="text-align: center; margin: 0px">
                        <h4>Nuevo Producto</h4>
                    </div>

                    <div class="form-row mt-5">
                        <div class="col-md-4">
                            <label style="float: left; margin-left: 5px;">Producto</label>
                            <div class="input-group">
                                <asp:DropDownList CssClass="form-control" runat="server">
                                    <asp:ListItem Text="Seleccionar--" />
                                    <asp:ListItem Text="..." />
                                    <asp:ListItem Text="..." />
                                </asp:DropDownList>
                                <div class="input-group-append">
                                    <button data-toggle="modal" data-target="#exampleModal" class="btn btn-info" type="button">+</button>
                                    <asp:LinkButton Visible="false" OnClick="BtnAgregarPro_Click" Style="display: flex; margin-top: 5px" runat="server"><i class="fas fa-plus-circle" style="margin: 10px; color: #00A350"></i></asp:LinkButton>
                                </div>
                            </div>

                            <%--                            <div style="display: inline-flex; float: left; width: 100%">
                                <asp:DropDownList CssClass="form-control" runat="server">
                                    <asp:ListItem Text="Seleccionar--" />
                                    <asp:ListItem Text="..." />
                                    <asp:ListItem Text="..." />
                                </asp:DropDownList>
                                <asp:LinkButton OnClick="BtnAgregarPro_Click" Style="display: flex; margin-top: 5px" runat="server"><i class="fas fa-plus-circle" style="margin: 10px; color: #00A350"></i></asp:LinkButton>
                            </div>--%>
                        </div>
                        <div class="col-md-4">
                            <label style="float: left; margin-left: 5px;">Código</label>
                            <input runat="server" type="text" name="Type" id="Text2" class="form-control" />
                        </div>

                        <div class="col-md-4">
                            <label style="float: left; margin-left: 5px;">Marca</label>
                            <div style="display: inline-flex; float: left; width: 100%">
                                <asp:DropDownList CssClass="form-control" runat="server">
                                    <asp:ListItem Text="Seleccionar--" />
                                    <asp:ListItem Text="..." />
                                    <asp:ListItem Text="..." />
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                        <div class="col-md-4">
                            <label style="float: left; margin-left: 5px;">Categoría</label>
                            <div style="display: inline-flex; float: left; width: 100%">
                                <asp:DropDownList CssClass="form-control" runat="server">
                                    <asp:ListItem Text="Seleccionar--" />
                                    <asp:ListItem Text="..." />
                                    <asp:ListItem Text="..." />
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label style="float: left; margin-left: 5px;">Proveedor</label>
                            <div style="display: inline-flex; float: left; width: 100%">
                                <asp:DropDownList CssClass="form-control" runat="server">
                                    <asp:ListItem Text="Seleccionar--" />
                                    <asp:ListItem Text="..." />
                                    <asp:ListItem Text="..." />
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <label style="float: left; margin-left: 5px;">U. Medida</label>
                            <div style="display: inline-flex; float: left; width: 100%">
                                <asp:DropDownList CssClass="form-control" runat="server">
                                    <asp:ListItem Text="Seleccionar--" />
                                    <asp:ListItem Text="..." />
                                    <asp:ListItem Text="..." />
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                        <div class="col-md-4">
                            <label style="float: left; margin-left: 5px;">Dimensiones</label>
                            <input runat="server" type="text" name="Type" id="Text1" class="form-control" />
                        </div>

                        <div class="col-md-4">
                            <label style="float: left; margin-left: 5px;">Material</label>
                            <div style="display: inline-flex; float: left; width: 100%">
                                <asp:DropDownList CssClass="form-control" runat="server">
                                    <asp:ListItem Text="Seleccionar--" />
                                    <asp:ListItem Text="..." />
                                    <asp:ListItem Text="..." />
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div style="width: 100%; margin: 20px; min-width: 150px; text-align: center">
                        <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" Text="Cancelar" runat="server" CssClass="btn btn-danger" />
                        <asp:Button Text="Guardar" runat="server" CssClass="btn btn-success" />
                    </div>
                </div>
            </div>
        </asp:View>
        <%-- Vista Todos Producto --%>
        <asp:View ID="vVista1" runat="server">
            <div class="mt-4 p-3">
                <div class="d-flex justify-content-center">
                    <div class="w-75 mt-5 shadow bg-white rounded p-2">
                        <div style="text-align: center">
                            <h4>Todos los Productos</h4>
                        </div>
                        <div class="form-row mt-5">
                            <div class="col-md-6">
                                <asp:TextBox CssClass="form-control" runat="server" ID="txtSearch" placeholder="Buscar..." />
                            </div>
                            <div class="col-md-6 pl-3" style="margin-top: 0px">
                                <asp:Button CssClass="btn btn-primary" runat="server" Text="Buscar" ID="btnSearch" />
                            </div>
                        </div>
                        <%-- Tabla --%>
                        <div style="max-width: 820px; overflow-x: scroll; display: inline-block; min-width: 180px; max-height: 250px; overflow-y: scroll" class="TableContainer mt-2 col-md-12">
                            <table class="table">
                                <thead>
                                    <tr>
                                        <th>ID</th>
                                        <th>Nombre</th>
                                        <th>Categoría</th>
                                        <th>Descripción</th>
                                        <th>Marca</th>
                                        <th>Proveedor</th>
                                        <th>Medida</th>
                                        <th>Dimensiones</th>
                                        <th>Material</th>
                                        <th>Expiración</th>
                                        <th>Estado</th>
                                        <th>Acciones</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td data-label="ID">1</td>
                                        <td data-label="Nombre">Sin datos</td>
                                        <td data-label="Categoría">Sin datos</td>
                                        <td data-label="Descripción">Sin datos</td>
                                        <td data-label="Marca">Sin datos</td>
                                        <td data-label="Proveedor">Sin datos</td>
                                        <td data-label="Medida">Sin datos</td>
                                        <td data-label="Dimensiones">Sin datos</td>
                                        <td data-label="Tipo de Material">Sin datos</td>
                                        <td data-label="Expiración">Sin datos</td>
                                        <td data-label="Estado">Sin datos</td>
                                        <td data-label="Acciones">
                                            <a href="#"><i class="far fa-edit"></i></a>
                                            <a href="#"><i class="fas fa-trash"></i></a>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </asp:View>
        <asp:View ID="vView2" runat="server">
            <div class="containerCatalog mt-4">
                <div class="form-principal">
                    <div class="form-row mt-5 p-3">
                        <div class="col-md-6">
                            <h5 style="float: left; margin-left: 5px;">Nombre</h5>
                            <br />
                            <br />
                            <input runat="server" type="text" name="Type" id="Text3" class="form-control" />
                        </div>
                        <div class="col-md-6">
                            <h5 style="float: left; margin-left: 5px;">Categoría</h5>
                            <br />
                            <br />
                            <div style="display: inline-flex; float: left; width: 100%">
                                <asp:DropDownList CssClass="form-control" runat="server">
                                    <asp:ListItem Text="Seleccionar--" />
                                    <asp:ListItem Text="..." />
                                    <asp:ListItem Text="..." />
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-md-12">
                            <h5 style="float: left; margin-left: 5px;">Decripción</h5>
                            <br />
                            <br />
                            <input runat="server" type="text" name="Type" id="Txt" class="form-control" />
                        </div>
                    </div>
                    <div style="width: 100%; margin: 20px; min-width: 150px; text-align: center">
                        <asp:Button OnClick="BtnAtras_Click" Text="Cancelar" runat="server" CssClass="btn btn-danger" />
                        <asp:Button Text="Guardar" runat="server" CssClass="btn btn-success" />
                    </div>
                </div>
            </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
