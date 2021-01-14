<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Purchases.aspx.cs" Inherits="HardwareStore.Modules.Billing.Purchases" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%-- Modals section... --%>
    <div class="modal fade" id="ventanaModal" tabindex="-1" role="dialog" aria-labelledby="tituloVentana" aria-hidden="true">
        <div class="modal-dialog modal-xl modal-dialog-centered" role="document" style="min-width: 1300px;">
            <div class="modal-content">
                <div class="modal-header bg-dark">
                    <h4 class="text-light">Existencias Productos</h4>
                    <%--<label runat="server" id="getidFromtable"></label>--%>
                    <button class="close text-light" data-dismiss="modal" aria-label="cerrar">
                        <span class="text-light" aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel runat="server" ID="updatePanelProductDetails">
                        <ContentTemplate>
                            <div class="form-row">
                                <div class="col-md-4 mt-3">
                                    <input class="form-control" runat="server" id="txtSearchProductDetails" placeholder="Buscar..." />
                                </div>
                                <div class="col-md-4 mt-3 pl-3">
                                    <asp:Button CssClass="btn btn-primary" runat="server" Text="Buscar" ID="btnSearchProductDetails" />
                                </div>
                            </div>
                            <div class="table-responsive mt-3">
                                <asp:GridView runat="server" DataKeyNames="Code" AutoGenerateColumns="false"
                                    ID="GridViewProductDetails" OnRowCommand="GridViewProductDetails_RowCommand" CssClass="table table-hover" CellPadding="5">
                                    <HeaderStyle CssClass="thead-dark" />
                                    <Columns>
                                        <asp:BoundField HeaderText="Código" DataField="Code" />
                                        <asp:BoundField HeaderText="Producto" DataField="ProductName" />
                                        <asp:BoundField HeaderText="Unidad de medida" DataField="MeasureUnit" />
                                        <asp:BoundField HeaderText="Categoría" DataField="CategoryName" />
                                        <asp:BoundField HeaderText="Material" DataField="MaterialName" />
                                        <asp:BoundField HeaderText="Marca" DataField="BrandName" />
                                        <asp:BoundField HeaderText="Dimensiones" DataField="Dimensions" />
                                        <asp:BoundField HeaderText="Material" DataField="MaterialName" />
                                        <asp:BoundField HeaderText="Codigo fabrica" DataField="DefaultCode" />
                                        <asp:BoundField HeaderText="Fecha registro" DataField="CreatedAt" />
                                        <asp:BoundField HeaderText="Creado por" DataField="CreatedBy" />
                                        <asp:BoundField HeaderText="Estado" DataField="Status" />
                                        <asp:TemplateField HeaderText="Opciones">
                                            <ItemTemplate>
                                                <asp:LinkButton Font-Size="11px" Height="28px" Width="80px"
                                                    CssClass="btn btn-primary btn-sm" ID="LinkSelect" ToolTip="Seleccionar Producto"
                                                    CommandName="cmdSelect" runat="server">Seleccionar</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="GridViewProductDetails" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <%-- End Modals section --%>

    <%-- Main container or main view --%>
    <div class="container mt-4">
        <div class="row">
            <div class="col-md-12 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <!-- Header of tabs -->
                        <ul class="nav nav-tabs" id="myTab" role="tablist">
                            <li class="nav-item" role="presentation">
                                <a class="nav-link" id="purchaselist-tab" data-toggle="tab" href="#purchaselist-content" role="tab" aria-controls="purchaselist-content" aria-selected="false">Historial de compras</a>
                            </li>
                            <li class="nav-item" role="presentation">
                                <a class="nav-link active" id="newpurchase-tab" data-toggle="tab" href="#newpurchase-content" role="tab" aria-controls="newpurchase-content" aria-selected="true">Nueva compra</a>
                            </li>
                            <li class="nav-item" role="presentation">
                                <a class="nav-link" id="purchasedetail-tab" data-toggle="tab" href="#purchasedetail-content" role="tab" aria-controls="purchasedetail-content" aria-selected="false">Detalle compra</a>
                            </li>
                        </ul>
                        <!-- end of headers (tabs) -->

                        <!-- Tabs content -->
                        <asp:UpdatePanel runat="server" ID="UpdatePanelForTabsContent">
                            <ContentTemplate>
                                <div class="tab-content" id="myTabContent">
                                    <%-- purchases list --%>
                                    <div class="tab-pane fade" id="purchaselist-content" role="tabpanel" aria-labelledby="purchaselist-tab">historial</div>
                                    <%-- End list --%>

                                    <%-- New Sale Section --%>
                                    <div class="tab-pane fade show active" id="newpurchase-content" role="tabpanel" aria-labelledby="newpurchase-tab">
                                        <div class="row mt-3">
                                            <div class="col-md-12">
                                                <div class="card card-shadow">
                                                    <div class="card-body">
                                                        <asp:TextBox runat="server" ID="txtMeasureUnitId" ReadOnly="true" Visible="false" />
                                                        <div class="form-row">
                                                            <div class="form-group col-md-4">
                                                                <asp:Label Text="Factura" runat="server" />
                                                                <div class="input-group">
                                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtSupplierInvoiceNumber" placeholder="Número de factura" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-row">
                                                            <div class="form-group col-md-4">
                                                                <div class="d-flex justify-content-start">
                                                                    <label>Producto</label>
                                                                </div>
                                                                <div class="input-group">
                                                                    <input type="text" readonly placeholder="Producto" runat="server" id="txtProductName" class="form-control form-disable">
                                                                    <div title="Elige un Producto" class="input-group-append">
                                                                        <button class="btn btn-info btn-sm" data-toggle="modal" data-target="#ventanaModal">...</button>
                                                                    </div>
                                                                    <div title="Crea un nuevo Producto" class="input-group-append">
                                                                        <button class="btn btn-success btn-sm" onclick="launch_Toast_ItemAddedToTempList()" data-toggle="modal" data-target="#ModalnewProduct">+</button>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-group col-md-4">
                                                                <div class="d-flex justify-content-start">
                                                                    <label>Bodega</label>
                                                                </div>
                                                                <div class="input-group">
                                                                    <asp:DropDownList ID="ddlstWarehouses" CssClass="form-control" runat="server">
                                                                    </asp:DropDownList>
                                                                    <div class="input-group-append">
                                                                        <button data-toggle="modal" data-target="#ModalWarehause" class="btn btn-info btn-sm" type="button">+</button>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-group col-md-4">
                                                                <div class="d-flex justify-content-start">
                                                                    <label for="txtCustomer">Proveedores</label>
                                                                </div>
                                                                <div class="input-group">
                                                                    <asp:DropDownList ID="ddlstSuppliers" CssClass="form-control" runat="server">
                                                                    </asp:DropDownList>
                                                                    <div class="input-group-append">
                                                                        <button data-toggle="modal" data-target="#ModalSuppliers" class="btn btn-info btn-sm" type="button">+</button>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="form-group col-md-3">
                                                                <asp:Label Text="Codigo" runat="server" />
                                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtProductDetailCode" ReadOnly="true" placeholder="Código" />
                                                            </div>
                                                            <div class="form-group col-md-3">
                                                                <asp:Label Text="Marca" runat="server" />
                                                                <div class="input-group">
                                                                    <asp:TextBox runat="server" ReadOnly="true" CssClass="form-control" ID="txtBrandName" placeholder="Marca" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group col-md-3">
                                                                <asp:Label Text="Categoría" runat="server" />
                                                                <div class="input-group">
                                                                    <asp:TextBox runat="server" ReadOnly="true" CssClass="form-control" ID="txtCategoryName" placeholder="Categoría" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group col-md-3">
                                                                <asp:Label Text="Material" runat="server" />
                                                                <div class="input-group">
                                                                    <asp:TextBox runat="server" ReadOnly="true" CssClass="form-control" ID="txtMaterialName" placeholder="Tipo de material" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-row">
                                                            <div class="form-group col-md-3">
                                                                <asp:Label Text="Dimensiones" runat="server" />
                                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtDimensions" ReadOnly="true" placeholder="Dimensiones" />
                                                            </div>
                                                            <div class="form-group col-md-2">
                                                                <asp:Label Text="Unidad base" runat="server" />
                                                                <div class="input-group">
                                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtUnitMeasureBase" ReadOnly="true" placeholder="Unidad" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group col-md-4">
                                                                <label>Unidad Compra</label>
                                                                <div class="input-group">
                                                                    <asp:DropDownList ID="ddlistMeasureUnits" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlistMeasureUnits_SelectedIndexChanged" CssClass="form-control" runat="server">
                                                                    </asp:DropDownList>
                                                                    <div class="input-group-append">
                                                                        <button data-toggle="modal" data-target="#MeasureUnits" class="btn btn-info btn-sm" type="button">+</button>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-group col-md-3">
                                                                <asp:Label Text="Conversión" runat="server" />
                                                                <div class="input-group">
                                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtUnitConversion" ReadOnly="true" placeholder="Conversión" />
                                                                    <div class="input-group-append">
                                                                        <span runat="server" id="SpanUnitMeasureAbbreviation" class="input-group-text">U</span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="form-group col-md-4">
                                                                <asp:Label Text="Codigo producto" runat="server" />
                                                                <div class="input-group">
                                                                    <asp:TextBox ReadOnly="true" runat="server" CssClass="form-control" ID="txtDefaultCode" placeholder="Codigo por defecto" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group col-md-3">
                                                                <asp:Label Text="Cantidad" runat="server" />
                                                                <div class="input-group">
                                                                    <asp:TextBox AutoPostBack="true" OnTextChanged="txtQuantity_TextChanged" runat="server" CssClass="form-control" ID="txtQuantity" TextMode="Number" step="1" placeholder="Cantidad" />
                                                                    <div class="input-group-append">
                                                                        <span class="input-group-text">#</span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-group col-md-2">
                                                                <asp:Label Text="Precio compra" runat="server" />
                                                                <div class="input-group">
                                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtPurchasePrice" TextMode="Number" step="0.001" placeholder="Precio" />
                                                                    <div class="input-group-append">
                                                                        <span class="input-group-text">C$</span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-group col-md-3">
                                                                <asp:Label Text="Impuesto" runat="server" />
                                                                <div class="input-group">
                                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtTaxDetail" TextMode="Number" step="0.001" placeholder="Impuesto" />
                                                                    <div class="input-group-append">
                                                                        <span class="input-group-text">IVA</span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-row">
                                                            <div class="form-group col-md-3">
                                                                <asp:Label Text="Descuento" runat="server" />
                                                                <div class="input-group">
                                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtDetailDiscount" TextMode="Number" step="1" placeholder="Descuento" />
                                                                    <div class="input-group-append">
                                                                        <span class="input-group-text">%</span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-group col-md-4">
                                                                <label>Precio compra</label>
                                                                <div class="input-group">
                                                                    <asp:DropDownList AutoPostBack="true" ID="ddlistValidateSalePrice" OnSelectedIndexChanged="ddlistValidateSalePrice_SelectedIndexChanged" CssClass="form-control" runat="server">
                                                                        <asp:ListItem Value="1" Text="Imponible por el sistema" />
                                                                        <asp:ListItem Value="2" Text="Digitado por el usuario" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="form-group col-md-3">
                                                                <asp:Label Text="Precio venta" runat="server" />
                                                                <div class="input-group">
                                                                    <asp:TextBox runat="server" ReadOnly="true" CssClass="form-control" ID="txtSalePrice" TextMode="Number" step="0.001" placeholder="Precio venta" />
                                                                    <div class="input-group-append">
                                                                        <span class="input-group-text">C$</span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="card-footer">
                                                        <div class="row justify-content-center">
                                                            <div class="col-md-2 p-1">
                                                                <asp:Button runat="server" Text="Agregar" ID="btnAddToPurchaseDetailList" OnClick="btnAddToPurchaseDetailList_Click" CssClass="btn btn-success btn-block" />
                                                            </div>
                                                            <div class="col-md-2 p-1">
                                                                <asp:Button runat="server" Text="Cancelar" ID="btnCancelOrClearDetailForm" OnClick="btnCancelOrClearDetailForm_Click" CssClass="btn btn-warning btn-block" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <%-- End Sale Section --%>

                                    <%-- Detail Sale Section --%>
                                    <div class="tab-pane fade" id="purchasedetail-content" role="tabpanel" aria-labelledby="purchasedetail-tab">
                                        <div class="row mt-3">
                                            <div class="col">
                                                <div class="card card-shadow pr-4 pl-4">
                                                    <div class="table-responsive mt-3 mb-3">
                                                        <asp:GridView runat="server" DataKeyNames="Code" AutoGenerateColumns="false"
                                                            ID="GridViewPurchaseDetails" CssClass="table" CellPadding="5" OnRowCommand="GridViewPurchaseDetails_RowCommand">
                                                            <HeaderStyle CssClass="thead-dark" />
                                                            <Columns>
                                                                <asp:BoundField HeaderText="Código" DataField="Code" />
                                                                <asp:BoundField HeaderText="Bodega" DataField="WarehouseName" />
                                                                <asp:BoundField HeaderText="Producto" DataField="ProductName" />
                                                                <asp:BoundField HeaderText="Marca" DataField="BrandName" />
                                                                <asp:BoundField HeaderText="Material" DataField="MaterialName" />
                                                                <asp:BoundField HeaderText="Dimensiones" DataField="Dimensions" />
                                                                <asp:BoundField HeaderText="Unidad base" DataField="MeasureUnitBase" />
                                                                <asp:BoundField HeaderText="Unidad compra" DataField="UnitPurchased" />
                                                                <asp:BoundField HeaderText="Cantidad" DataField="UnitsPurchasedString" />
                                                                <asp:BoundField HeaderText="Conversion" DataField="UnitsBaseConversion" />
                                                                <asp:BoundField HeaderText="Subtotal" DataField="Subtotal" />
                                                                <asp:BoundField HeaderText="Discount" DataField="Discount" />
                                                                <asp:BoundField HeaderText="IVA" DataField="Tax" />
                                                                <asp:BoundField HeaderText="Total" DataField="Total" />
                                                                <asp:TemplateField HeaderText="Opciones">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton Font-Size="11px" Height="28px" Width="80px"
                                                                            CssClass="LinkbtnPrimary" ID="EditLink" ToolTip="Editar Producto"
                                                                            CommandName="cmdEdit" runat="server">Editar</asp:LinkButton>
                                                                        <asp:LinkButton Font-Size="11px" Height="28px" Width="80px"
                                                                            CssClass="LinkbtnDanger" ID="DeleteLink" ToolTip="Eliminar Producto"
                                                                            CommandName="cmdDelete" runat="server">Eliminar</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mt-3">
                                            <div class="col">
                                                <div class="card card-shadow">
                                                    <div class="card-body">
                                                        <div class="form-row">
                                                            <div class="form-group col-md-3">
                                                                <label>Subtotal</label>
                                                                <div class="input-group">
                                                                    <input readonly runat="server" id="txtSubtotal" placeholder="Subtotal" class="form-control" />
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text">C$</span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-group col-md-2">
                                                                <label>Impuesto</label>
                                                                <div class="input-group">
                                                                    <asp:TextBox runat="server" TextMode="Number" step="0.01" ID="txtTotalTax" placeholder="Impuesto" CssClass="form-control" />
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text">IVA</span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-group col-md-3">
                                                                <label for="txtTotalDiscount">Descuento</label>
                                                                <div class="input-group">
                                                                    <asp:TextBox TextMode="Number" runat="server" step="1" ID="txtTotalDiscount" placeholder="Descuento" CssClass="form-control" />
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text">%</span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-group col-md-4">
                                                                <label>Total</label>
                                                                <div class="input-group">
                                                                    <asp:TextBox runat="server" ID="txtTotal" placeholder="Total" CssClass="form-control" />
                                                                    <%--<input required readonly placeholder="Total" runat="server" id="txtTotal" class="form-control" />--%>
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text">C$</span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="card-footer">
                                                        <div class="row justify-content-center">
                                                            <div class="col-md-2 p-1">
                                                                <asp:Button runat="server" Text="Calcular" ID="btnRecalculatePurchaseTotal" OnClick="btnRecalculatePurchaseTotal_Click" CssClass="btn btn-success btn-block" />
                                                            </div>
                                                            <div class="col-md-2 p-1">
                                                                <asp:Button runat="server" Text="Registrar Orden" ID="btnGeneratePurchase" OnClick="btnGeneratePurchase_Click" CssClass="btn btn-success btn-block" />
                                                            </div>
                                                            <div class="col-md-2 p-1">
                                                                <asp:Button runat="server" Text="Cancelar" ID="btnPurchaseCancel" OnClick="btnPurchaseCancel_Click" CssClass="btn btn-danger btn-block" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- End Detail Sale --%>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <%--<asp:PostBackTrigger ControlID="btnAddToPurchaseDetailList" />--%>
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- End of Main container --%>

    <%-- start Toaster section --%>
    <div id="Toast_ItemAddedToTempList" class="toast">
        <div class="toast-img toast-img-success"><i class="fas fa-exclamation"></i></div>
        <div class="toast-body">
            <p style="text-align: justify;">
                Producto agregado al detalle!
            </p>
        </div>
    </div>

    <div id="Toast_ItemAreadyExist" class="toast">
        <div class="toast-img toast-img-danger"><i class="fas fa-exclamation"></i></div>
        <div class="toast-body">
            <p style="text-align: justify;">
                El producto ya existe en la lista!
                <br />
                Edite el existente en su lugar
            </p>
        </div>
    </div>
    <%-- End toaster section --%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptSection" runat="server">
    <script>
        function launch_Toast_ItemAddedToTempList() {
            console.log("Hello World");
            var el = document.getElementById("Toast_ItemAddedToTempList")
            el.classList.add("show");
            setTimeout(function () { el.classList.remove("show") }, 5000);
        }

        function Toast_ItemAlreadyExists() {
            var el = document.getElementById("Toast_ItemAreadyExist")
            el.classList.add("show");
            setTimeout(function () { el.classList.remove("show") }, 5000);
        }
    </script>
</asp:Content>
