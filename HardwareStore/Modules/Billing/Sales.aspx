<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sales.aspx.cs" Inherits="HardwareStore.Modules.Billing.Sales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%-- Modal section --%>
    <div class="modal fade" id="ModalStocksDetails" tabindex="-1" role="dialog" aria-labelledby="tituloVentana" aria-hidden="true">
        <div class="modal-dialog modal-xl modal-dialog-centered" role="document" style="min-width: 1300px;">
            <div class="modal-content">
                <div class="modal-header bg-dark">
                    <h4 class="text-light">Detalle de lote: </h4>
                    <div id="section_info"><strong id="strong_info_lotnumber"></strong></div>
                    <%--<label runat="server" id="getidFromtable"></label>--%>
                    <button class="close text-light" data-dismiss="modal" aria-label="cerrar">
                        <span class="text-light" aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel runat="server" ID="updatePanelStocksDetails">
                        <ContentTemplate>
                            <div class="row">
                                <asp:TextBox runat="server" ID="txtLotNumberForStockDetails" placeholder="LotNumber" CssClass="form-control" Visible="false" ReadOnly="true" />
                                <div class="col-md-6">
                                    <div class="form-row">
                                        <div class="form-group col">
                                            <asp:Label Text="Filtrar" runat="server" />
                                            <asp:TextBox CssClass="form-control" runat="server" ID="txtSearchStocksDetails" placeholder="Buscar..." />
                                        </div>
                                        <div class="form-group col">
                                            <asp:Label Text="Filtro por bodegas" runat="server" />
                                            <asp:DropDownList AutoPostBack="true" ID="DropDownListWarehousesFilter" OnSelectedIndexChanged="DropDownListWarehousesFilter_SelectedIndexChanged" CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Button CssClass="btn btn-primary" runat="server" Text="Buscar" ID="btnSearchStocksDetails" OnClick="btnSearchStocksDetails_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive mt-3">
                                <asp:GridView runat="server" DataKeyNames="LotNumber, StocksCode" AutoGenerateColumns="false"
                                    ID="GridViewStocksDetails" CssClass="table table-hover" CellPadding="5" OnRowCommand="GridViewStocksDetails_RowCommand">
                                    <HeaderStyle CssClass="thead-dark" />
                                    <Columns>
                                        <asp:BoundField HeaderText="Código" DataField="LotNumber" Visible="false" />
                                        <asp:BoundField HeaderText="Producto" DataField="StocksCode" Visible="false" />
                                        <asp:BoundField HeaderText="Bodega" DataField="WarehouseName" />
                                        <asp:BoundField HeaderText="Código producto" DataField="ProductDetailCode" />
                                        <asp:BoundField HeaderText="Producto" DataField="ProductName" />
                                        <asp:BoundField HeaderText="Marca" DataField="BrandName" />
                                        <asp:BoundField HeaderText="Categoría" DataField="CategoryName" />
                                        <asp:BoundField HeaderText="Dimensiones" DataField="Dimensions" />
                                        <asp:BoundField HeaderText="Material" DataField="MaterialName" />
                                        <asp:BoundField HeaderText="Unidades" DataField="StocksQuantity" />
                                        <asp:BoundField HeaderText="Unidad compra" DataField="PurchaseUnitName" />
                                        <asp:BoundField HeaderText="Unidad base" DataField="UnitBaseName" />
                                        <asp:BoundField HeaderText="Conversion" DataField="ConversionValue" />
                                        <asp:BoundField HeaderText="Precio unidad" DataField="SalePrice" />
                                        <asp:BoundField HeaderText="Fecha expiración" DataField="ExpirationDate" />
                                        <asp:BoundField HeaderText="Estado" DataField="Available" />
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
                            <asp:PostBackTrigger ControlID="GridViewStocksDetails" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <%-- End Modal section --%>

    <%-- Main Content Tabs --%>
    <div class="container mt-4">
        <div class="row">
            <div class="col mx-auto">
                <div class="card">
                    <div class="card-body">
                        <%-- Header Tabs --%>
                        <ul class="nav nav-tabs" id="SalesTabs" role="tablist">
                            <li class="nav-item" role="presentation">
                                <a class="nav-link" id="salelist-tab" data-toggle="tab" href="#salelist-content" role="tab" aria-controls="salelist-content" aria-selected="false">Historial de ventas</a>
                            </li>
                            <li class="nav-item" role="presentation">
                                <a class="nav-link" id="productstocks-tab" data-toggle="tab" href="#productstocks-content" role="tab" aria-controls="productstocks-content" aria-selected="false">Existencia productos</a>
                            </li>
                            <li class="nav-item" role="presentation">
                                <a class="nav-link active" id="newsale-tab" data-toggle="tab" href="#newsale-content" role="tab" aria-controls="newsale-content" aria-selected="true">Nueva venta</a>
                            </li>
                            <li class="nav-item" role="presentation">
                                <a class="nav-link" id="saledetails-tab" data-toggle="tab" href="#saledetails-content" role="tab" aria-controls="saledetails-content" aria-selected="false">Detalle de venta</a>
                            </li>
                        </ul>
                        <%-- End Header tabs --%>

                        <%-- Tab content --%>
                        <div class="tab-content" id="SalesContent">
                            <%-- Sale list --%>
                            <div class="tab-pane fade" id="salelist-content" role="tabpanel" aria-labelledby="salelist-tab">
                                <asp:UpdatePanel runat="server" ID="UpdatePanelForSalesList">
                                    <ContentTemplate>
                                        <div class="row mt-3">
                                            <div class="col">
                                                <div class="card card-shadow">
                                                    <div class="card-body">
                                                        <div class="row">
                                                            <div class="col">
                                                                <div class="card">
                                                                    <div class="card-body">
                                                                        <div class="form-row align-items-center">
                                                                            <div class="form-group col-md-4">
                                                                                <asp:Label Text="Buscar" runat="server" />
                                                                                <asp:TextBox runat="server" ID="txtSearchInvoiceRecords" CssClass="form-control" placeholder="Buscar..." />
                                                                            </div>
                                                                            <div class="form-group col-md-3">
                                                                                <asp:Label Text="Fecha Inicio" runat="server" />
                                                                                <asp:TextBox runat="server" CssClass="form-control" ID="PickerStartDateInvoceListFilter" TextMode="Date" />
                                                                            </div>
                                                                            <div class="form-group col-md-3">
                                                                                <asp:Label Text="Fecha Final" runat="server" />
                                                                                <asp:TextBox runat="server" CssClass="form-control" ID="PickerEndDateInvoiceListFilter" TextMode="Date" />
                                                                            </div>
                                                                            <div class="form-group col-md-2">
                                                                                <br />
                                                                                <asp:Button Text="Filtrar" runat="server" ID="btnInvoiceListFilter" CssClass="btn btn-primary btn-block" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row mt-4">
                                                            <div class="col">
                                                                <div class="card">
                                                                    <div class="card-body table-responsive mt-3 mb-3">
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <%-- End Sale list --%>

                            <%-- Product Stocks section --%>
                            <div class="tab-pane fade" id="productstocks-content" role="tabpanel" aria-labelledby="productstocks-tab">
                                <asp:UpdatePanel runat="server" ID="UpdatePanelForProductStocks">
                                    <ContentTemplate>
                                        <div class="row mt-3">
                                            <div class="col">
                                                <div class="card card-shadow">
                                                    <div class="card-body">
                                                        <div class="row">
                                                            <div class="col">
                                                                <div class="card">
                                                                    <div class="card-body">
                                                                        <div class="form-row align-items-center">
                                                                            <div class="form-group col-md-4">
                                                                                <asp:Label Text="Buscar" runat="server" />
                                                                                <asp:TextBox runat="server" ID="txtSearchProductStocks" CssClass="form-control" placeholder="Buscar..." />
                                                                            </div>
                                                                            <div class="form-group col-md-3">
                                                                                <asp:Label Text="Fecha Inicio" runat="server" />
                                                                                <asp:TextBox runat="server" CssClass="form-control" ID="PickerStartDateProductStocks" TextMode="Date" />
                                                                            </div>
                                                                            <div class="form-group col-md-3">
                                                                                <asp:Label Text="Fecha Final" runat="server" />
                                                                                <asp:TextBox runat="server" CssClass="form-control" ID="PickerEndDateProductStocks" TextMode="Date" />
                                                                            </div>
                                                                            <div class="form-group col-md-2">
                                                                                <br />
                                                                                <asp:Button Text="Filtrar" runat="server" ID="btnSearchProductStocks" OnClick="btnSearchProductStocks_Click" CssClass="btn btn-primary btn-block" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row mt-4">
                                                            <div class="col">
                                                                <div class="card">
                                                                    <div class="card-body table-responsive mt-3 mb-3">
                                                                        <asp:GridView runat="server" DataKeyNames="LotNumber" AutoGenerateColumns="false"
                                                                            ID="GridViewProductStocks" CssClass="table table-hover" CellPadding="5" OnRowCommand="GridViewProductStocks_RowCommand">
                                                                            <HeaderStyle CssClass="thead-dark" />
                                                                            <Columns>
                                                                                <asp:BoundField HeaderText="Código de lote" DataField="LotNumber" />
                                                                                <asp:BoundField HeaderText="Proveedor" DataField="SupplierName" />
                                                                                <asp:BoundField HeaderText="Cantidad productos" DataField="Quantity" />
                                                                                <asp:BoundField HeaderText="Total" DataField="TotalAmount" />
                                                                                <asp:BoundField HeaderText="Fecha" DataField="CreatedAt" />
                                                                                <asp:BoundField HeaderText="Realizada por" DataField="CreatedBy" />
                                                                                <asp:BoundField HeaderText="Ultima Actualización" DataField="UpdatedAt" />
                                                                                <asp:BoundField HeaderText="Actualizada por" DataField="UpdatedBy" />
                                                                                <asp:BoundField HeaderText="Estado" DataField="Available" />
                                                                                <asp:TemplateField HeaderText="Opciones">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton Font-Size="11px" Height="28px" Width="80px"
                                                                                            CssClass="btn btn-primary btn-sm" ID="LinkShowStocksDetails" ToolTip="Detalle de existencias"
                                                                                            CommandName="cmdShowStocksDetail" runat="server">Ver registros</asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <%-- End Product Stocks section --%>

                            <%-- new sale section --%>
                            <div class="tab-pane fade show active" id="newsale-content" role="tabpanel" aria-labelledby="newsale-tab">
                                <asp:UpdatePanel runat="server" ID="UpdatePanelForNewSale">
                                    <ContentTemplate>
                                        <div class="row mt-3">
                                            <div class="col-md-12">
                                                <div class="card card-shadow">
                                                    <div class="card-body">
                                                        <asp:TextBox runat="server" ID="txtMeasureUnitBaseId" ReadOnly="true" Visible="false" />
                                                        <asp:TextBox runat="server" ID="txtMeasureUnitPurchasedId" ReadOnly="true" Visible="false" />
                                                        <asp:TextBox runat="server" ID="txtMeasureUnitTypeId" ReadOnly="true" Visible="false" />
                                                        <asp:TextBox runat="server" ID="txtWarehouseId" ReadOnly="true" Visible="false" />
                                                        <asp:TextBox runat="server" ID="txtStocksCode" ReadOnly="true" Visible="false" />
                                                        <div class="form-row">
                                                            <div class="form-group col-lg-3">
                                                                <asp:Label Text="Producto" runat="server" />
                                                                <asp:TextBox ReadOnly="true" placeholder="Producto" runat="server" ID="txtProductName" CssClass="form-control" />
                                                            </div>
                                                            <div class="form-group col-lg-3">
                                                                <%--<div style="margin-bottom: .5rem;">--%>
                                                                <asp:Label Text="Codigo" runat="server" />
                                                                <%--</div>--%>
                                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtProductDetailCode" ReadOnly="true" placeholder="Código" />
                                                            </div>
                                                            <div class="form-group col-lg-3">
                                                                <%--<div style="margin-bottom: .5rem;">--%>
                                                                <asp:Label Text="Fecha expiración" runat="server" />
                                                                <%--</div>--%>
                                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtExpiryDate" ReadOnly="true" placeholder="Fecha expiración" />
                                                            </div>
                                                            <div class="form-group col-lg-3">
                                                                <asp:Label Text="Bodega" runat="server" />
                                                                <div class="input-group">
                                                                    <asp:TextBox runat="server" ReadOnly="true" CssClass="form-control" ID="txtWarehouseName" placeholder="Bodega" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-row">
                                                            <div class="form-group col-lg-3">
                                                                <asp:Label Text="Marca" runat="server" />
                                                                <div class="input-group">
                                                                    <asp:TextBox runat="server" ReadOnly="true" CssClass="form-control" ID="txtBrandName" placeholder="Marca" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group col-lg-3">
                                                                <asp:Label Text="Categoría" runat="server" />
                                                                <div class="input-group">
                                                                    <asp:TextBox runat="server" ReadOnly="true" CssClass="form-control" ID="txtCategoryName" placeholder="Categoría" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group col-lg-3">
                                                                <asp:Label Text="Material" runat="server" />
                                                                <div class="input-group">
                                                                    <asp:TextBox runat="server" ReadOnly="true" CssClass="form-control" ID="txtMaterialName" placeholder="Tipo de material" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group col-lg-3">
                                                                <asp:Label Text="Dimensiones" runat="server" />
                                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtDimensions" ReadOnly="true" placeholder="Dimensiones" />
                                                            </div>
                                                        </div>
                                                        <div class="form-row">
                                                            <div class="form-group col-lg-3">
                                                                <asp:Label Text="Existencia inicial" runat="server" />
                                                                <div class="input-group">
                                                                    <div class="input-group-append">
                                                                        <span runat="server" id="SpanForInitialsStocks" class="input-group-text"></span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" ReadOnly="true" CssClass="form-control" ID="txtInitialsStocks" placeholder="Cantidad" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group col-lg-3">
                                                                <asp:Label Text="Existencia actual" runat="server" />
                                                                <div class="input-group">
                                                                    <div class="input-group-append">
                                                                        <span runat="server" id="SpanForCurrentStocks" class="input-group-text"></span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" ReadOnly="true" CssClass="form-control" ID="txtCurrentStocks" placeholder="Cantidad" />
                                                                </div>
                                                            </div>
                                                            <%--<div class="form-group col-lg-2">
                                                                <div style="margin-bottom: .5rem;">
                                                                    <asp:Label Text="Unidad" runat="server" />
                                                                </div>
                                                                <div class="input-group">
                                                                    <asp:TextBox runat="server" ReadOnly="true" CssClass="form-control" ID="txtUnitMeasureName" placeholder="Unidad de medida" />
                                                                </div>
                                                            </div>--%>
                                                            <div class="form-group col-lg-4">
                                                                <asp:Label Text="Unidad venta" runat="server" />
                                                                <div class="input-group">
                                                                    <asp:DropDownList ID="ddlistMeasureUnits" CssClass="form-control" runat="server">
                                                                    </asp:DropDownList>
                                                                    <div class="input-group-append">
                                                                        <asp:Button runat="server" Text="+" ID="btnAddNewMeasureUnits" data-toggle="modal" data-target="#ModalMeasureUnits" CssClass="btn btn-info btn-sm" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-group col-lg-2">
                                                                <asp:Label Text="Cantidad" runat="server" />
                                                                <div class="input-group">
                                                                    <div class="input-group-append">
                                                                        <span class="input-group-text">#</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtQuantity" placeholder="Cantidad" />
                                                                </div>
                                                            </div>
                                                            
                                                        </div>
                                                        <div class="form-row">
                                                            <div class="form-group col-lg-4">
                                                                <asp:Label Text="Precio" runat="server" />
                                                                <div class="input-group">
                                                                    <div class="input-group-append">
                                                                        <span class="input-group-text">C$</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" ID="txtSalePrice" ReadOnly="true" placeholder="Precio" CssClass="form-control" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group col-lg-4">
                                                                <asp:Label Text="Impuesto" runat="server" />
                                                                <div class="input-group">
                                                                    <div class="input-group-append">
                                                                        <span class="input-group-text">C$</span>
                                                                    </div>
                                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtDetailTax" placeholder="Impuesto" />
                                                                </div>
                                                            </div>
                                                            <div class="form-group col-lg-4">
                                                                <asp:Label Text="Descuento" runat="server" />
                                                                <div class="input-group">
                                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtDetailDiscount" placeholder="Descuento" />
                                                                    <div class="input-group-append">
                                                                        <span class="input-group-text">%</span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="card-footer">
                                                        <div class="row justify-content-center">
                                                            <div class="col-md-2 p-1">
                                                                <asp:Button runat="server" Text="Agregar" ID="btnAddToSaleDetailsList" OnClick="btnAddToSaleDetailsList_Click" CssClass="btn btn-success btn-block" />
                                                            </div>
                                                            <div class="col-md-2 p-1">
                                                                <asp:Button runat="server" Text="Cancelar" ID="btnCancelOrClearDetailForm" OnClick="btnCancelOrClearDetailForm_Click" CssClass="btn btn-warning btn-block" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <%-- End of new sale section --%>

                            <%-- Sale Detail section --%>
                            <div class="tab-pane fade" id="saledetails-content" role="tabpanel" aria-labelledby="saledetails-tab">
                                <asp:UpdatePanel runat="server" ID="UpdatePanelForSaleDetails">
                                    <ContentTemplate>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <%-- End Sale Details --%>
                        </div>
                        <%-- End Tab content --%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- End content for tabs --%>

    <%-- Toast section --%>
    <%-- End toast section --%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptSection" runat="server">
    <script>
        function ShowModalStocksDetails(lotnumber) {
            document.getElementById("strong_info_lotnumber").remove();
            let div = document.getElementById("section_info");
            let strong_info = document.createElement("strong");
            let message = "#" + lotnumber;
            let inner_content = document.createTextNode(message);
            strong_info.style.marginLeft = "10px"; strong_info.classList.add("text-light"); strong_info.setAttribute("id", "strong_info_lotnumber");
            strong_info.appendChild(inner_content);
            div.appendChild(strong_info);
            setTimeout(function () { $('#ModalStocksDetails').modal('show') }, 350);
        }
    </script>
</asp:Content>
