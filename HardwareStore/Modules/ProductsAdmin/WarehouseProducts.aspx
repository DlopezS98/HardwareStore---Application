<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WarehouseProducts.aspx.cs" Inherits="HardwareStore.Modules.ProductsAdmin.WarehouseProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../../Styles/Toast.css" rel="stylesheet" />
    <div id="toast" class="toast">
        <div class="toast-img toast-img-success"><i class="fas fa-exclamation"></i></div>
        <div class="toast-body">
            <div style="text-align: center;">
                Producto Agregado!
                <br />
                <asp:Button ID="btnGo" Text="Ir" runat="server" CssClass="btn btn-success" />
            </div>
        </div>
    </div>

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
                    Estás seguro que quieres eliminar el producto?
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                    <asp:Button ID="btnDelete" OnClick="btnDelete_Click" Text="Confirmar" runat="server" CssClass="btn btn-success" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="ModalAlertError" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-body">
                    <ul class="d-flex justify-content-center">
                        <li><a><i style="color: #C82333" class="fa fa-times fa-2x fa-lg"></i></a></li>
                    </ul>
                    <div class="d-flex justify-content-center">
                        <div>
                            <h4>¡Error al Registrar la Compra!</h4>
                        </div>
                    </div>
                </div>
                <div class="modal-footer d-flex justify-content-center">
                    <asp:Button ID="btnsuccessful" Text="Aceptar" runat="server" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>

    <%-- Fin Modal Alert --%>
    <%-- Sección del modal --%>
    <div class="modal fade" id="ventanaModal" tabindex="-1" role="dialog" aria-labelledby="tituloVentana" aria-hidden="true">
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
                <div class="modal-header bg-dark">
                    <h4 class="text-light" style="text-align: center">Transferencia de Productos</h4>
                    <button class="close" data-dismiss="modal" aria-label="cerrar">
                        <span class="text-light" aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                        <ContentTemplate>
                            <div>
                                <h4 style="text-align: center">Datos del Producto a Transferir</h4>
                                <hr class="my-4">
                                <div class="form-row">
                                    <div class="col-md-4 p-2">
                                        <b>Nombre del Producto:</b> ... 
                                    </div>
                                    <div class="col-md-4 p-2">
                                        <b>Código Producto:</b> 08418652
                                    </div>
                                    <div class="col-md-4 p-2">
                                        <b>Dirección:</b> Lorem ipsum dolor sit amet, consectetur adipiscing elit 
                                    </div>
                                    <div class="col-md-4 p-2">
                                        <b>Marca:</b> ...
                                    </div>
                                    <div class="col-md-4 p-2">
                                        <b>Producto:</b> ...
                                    </div>

                                    <div class="col-md-4 p-2">
                                        <b>U. Medida:</b> ...
                                    </div>
                                    <div class="col-md-4 p-2">
                                        <b>Dimensiones:</b> ... 
                                    </div>

                                    <div class="col-md-4 p-2">
                                        <b>Material:</b> Goku Uzumaki
                                    </div>

                                    <div class="col-md-4 p-2">
                                        <b>Categoría</b> ... 
                                    </div>
                                    <div class="col-md-4 p-2">
                                        <b>Decripción:</b> ...
                                    </div>
                                    <div>
                                        <h4 style="text-align: center; margin-top: 40px; color: #73B7FE">Llena los siguientes campos para confirmar</h4>
                                    </div>


                                    <asp:TextBox Visible="false" TextMode="Number" placeholder="Id Bodega" runat="server" ID="TextBox4" class="form-control" />
                                    <asp:TextBox Visible="false" TextMode="Number" placeholder="Id Producto" runat="server" ID="TextBox5" class="form-control" />
                                    <asp:TextBox Visible="false" TextMode="Number" placeholder="Id Precio Compra" runat="server" ID="TextBox6" class="form-control" />
                                    <asp:TextBox Visible="false" placeholder="Bodega" runat="server" ID="TextBox7" class="form-control" />

                                    <div class="col-md-6 p-2">
                                        <h6 style="margin-left: 10px">Cantidad a Transferir</h6>
                                        <div style="display: flex; margin-left: 10px">
                                            <asp:TextBox placeholder="Cantidad" runat="server" ID="TextBox8" class="form-control" />
                                        </div>
                                    </div>

                                    <div class="col-md-6 p-2">
                                        <h6 style="margin-left: 10px">Bodega de Destino</h6>
                                        <div style="display: flex; margin-left: 10px">
                                            <asp:DropDownList CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div style="width: 100%; margin: 20px; min-width: 150px; text-align: center">
                                        <asp:Button runat="server" Text="Confirmar" CssClass="btn btn-success" Style="margin-left: 10px" />
                                        <asp:Button ID="Button2" runat="server" Text="Cancelar" CssClass="btn btn-danger" Style="margin-left: 10px" />
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>

    <%-- Fin Sección del modal --%>
    <div class="ml-2 p-3">
        <asp:MultiView ID="ProductWaresause" ActiveViewIndex="0" runat="server">
            <asp:View runat="server">
                <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                    <ContentTemplate>
                        <div class="d-flex justify-content-end">
                            <asp:Button ID="Listmove" OnClick="Listmove_Click" class="btn btn-primary" type="button" runat="server" Text="Pendientes" />
                        </div>
                        <h1 style="color: #1F2126; text-align: center;">Existencias en Bodega</h1>
                        <div class="form-row">
                            <div class="col-md-4">
                                <asp:TextBox placeholder="Buscar" runat="server" ID="txtOrdNumber" class="form-control" />
                            </div>
                            <div class="col-md-4">
                                <asp:Button class="btn btn-primary" type="button" runat="server" Text="Buscar" />
                            </div>
                            <div class="col-md-4">
                                <div style="margin-right: 15px; width: 100%; display: flex;">
                                    <asp:DropDownList CssClass="form-control" Width="100%" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <br />
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
                                                <button type="button" class="btn btn-danger" data-toggle="modal" data-target="#ModalAlertError">
                                                    Eliminar
                                                </button>
                                                <%--<button id="btnToasts" class="btn btn-success">Ver toasts</button>--%>
                                                <asp:Button ID="btnMove" OnClick="btnMove_Click" Text="Transferir" runat="server" CssClass="btn btn-success" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </table>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnDelete" />
                        <asp:PostBackTrigger ControlID="Listmove" />
                    </Triggers>
                </asp:UpdatePanel>
            </asp:View>

            <asp:View runat="server">
                <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                    <ContentTemplate>
                        <div style="border: 1px solid #e4e4e4; padding: 8px; border-radius: 5px; background-color: #fff; margin-top: 15px">
                            <div class="form-row p-3">
                                <div class="d-flex justify-content-center">
                                    <h4>Datos del Producto a Eliminar</h4>
                                </div>
                                <hr class="my-4">
                                <div class="form-row">
                                    <div class="col-md-4 p-2">
                                        <b>Nombre del Producto:</b> ... 
                                    </div>
                                    <div class="col-md-4 p-2">
                                        <b>Código Producto:</b> 08418652
                                    </div>
                                    <div class="col-md-4 p-2">
                                        <b>Dirección:</b> Lorem ipsum dolor sit amet, consectetur adipiscing elit 
                                    </div>
                                    <div class="col-md-4 p-2">
                                        <b>Marca:</b> ...
                                    </div>
                                    <div class="col-md-4 p-2">
                                        <b>Producto:</b> ...
                                    </div>

                                    <div class="col-md-4 p-2">
                                        <b>U. Medida:</b> ...
                                    </div>
                                    <div class="col-md-4 p-2">
                                        <b>Dimensiones:</b> ... 
                                    </div>

                                    <div class="col-md-4 p-2">
                                        <b>Material:</b> Goku Uzumaki
                                    </div>

                                    <div class="col-md-4 p-2">
                                        <b>Categoría</b> ... 
                                    </div>
                                    <div class="col-md-4 p-2">
                                        <b>Decripción:</b> ...
                                    </div>
                                </div>

                                <div class="d-flex justify-content-center">
                                    <h4 style="margin-top: 40px; color: #73B7FE">Llena los siguientes campos para confirmar</h4>
                                </div>
                                <asp:TextBox Visible="false" TextMode="Number" placeholder="Id Bodega" runat="server" ID="txtWarehouseId" class="form-control" />
                                <asp:TextBox Visible="false" TextMode="Number" placeholder="Id Producto" runat="server" ID="txtProductId" class="form-control" />
                                <asp:TextBox Visible="false" TextMode="Number" placeholder="Id Precio Compra" runat="server" ID="txtPriceOrders" class="form-control" />
                                <asp:TextBox Visible="false" placeholder="Bodega" runat="server" ID="txtExistences" class="form-control" />
                                <div class="col-md-12">
                                    <h6 style="margin-left: 10px">Título</h6>
                                    <div style="display: flex; margin-left: 10px">
                                        <asp:TextBox placeholder="Título" runat="server" ID="TextBox2" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <h6 style="margin-left: 10px">Cantidad a restar</h6>
                                    <div style="display: flex; margin-left: 10px">
                                        <asp:TextBox placeholder="Cantidad" runat="server" ID="TextBox1" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <h6 style="margin-left: 10px">Descripción</h6>
                                    <div style="display: flex; margin-left: 10px">
                                        <asp:TextBox placeholder="Descripción" runat="server" ID="TextBox3" class="form-control" />
                                    </div>
                                </div>
                                <div style="width: 100%; margin: 20px; min-width: 150px; text-align: center">
                                    <asp:Button runat="server" Text="Confirmar" CssClass="btn btn-success" Style="margin-left: 10px" />
                                    <asp:Button ID="btnCancel" OnClick="btnCancel_Click" runat="server" Text="Cancelar" CssClass="btn btn-danger" Style="margin-left: 10px" />
                                </div>
                            </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnCancel" />
                    </Triggers>
                </asp:UpdatePanel>
            </asp:View>

            <asp:View runat="server">
                <asp:UpdatePanel runat="server" ID="UpdatePanel4">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-lg-12">
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
                                            <th scope="row">1</th>
                                            <td>Danny López</td>
                                            <td>Root</td>
                                            <td>DlopezS98</td>
                                            <td>Activo</td>
                                            <td>
                                                <asp:Button Text="Eliminar" runat="server" CssClass="btn btn-danger" />
                                                <button data-toggle="modal" data-target="#ventanaModal" class="btn btn-primary">Editar</button>
                                                <%--<asp:Button data-open="odmodal" ID="Button1" OnClientClick="ShowModalDetail()" Text="Editar" runat="server" CssClass="btnPrimary" />--%>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:View>
        </asp:MultiView>
    </div>

    <%--    <div class="d-flex align-items-end flex-column bd-highlight mb-1" style="height: 200px;">
        <div class="mt-auto p-2 bd-highlight">
            <div id="toast1" class="toast" role="alert" aria-live="assertive" aria-atomic="true">
                <div class="toast-header">
                    <svg class="bd-placeholder-img rounded mr-2" width="20" height="20" xmlns="http://www.w3.org/2000/svg" preserveAspectRatio="xMidYMid slice">
                    </svg>
                    <ul class="mt-3">
                        <li><a><i style="width: 100%; height: 100%;" class="fas fa-info mr-4 text-warning"></i></a></li>
                    </ul>
                    <strong class="mr-auto">Mensaje</strong>
                    <small>Justo ahora</small>
                </div>
                <div class="toast-body">
                    Producto agregado a la tabla de tranferencias
                    <div class="d-flex justify-content-end mt-3">
                        <asp:Button CssClass="btn btn-success" Text="Vamos" runat="server" ID="btnList" OnClick="btnList_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptSection" runat="server">
    <script>
        //function launch_toast() {
        //    $("#btnMove").click(function () {
        //        $("#toast1").toast('show');
        //    });
        //}
        function launch_toast() {
            var el = document.getElementById("toast")
            el.classList.add("show");
            setTimeout(function () { el.classList.remove("show") }, 5000);
        }
    </script>
</asp:Content>
