<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WarehouseProducts.aspx.cs" Inherits="HardwareStore.Modules.ProductsAdmin.WarehouseProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../../Styles/Toast.css" rel="stylesheet" />

    <div class="container mt-4">
        <div class="row">
            <div class="col">
                <div class="card">
                    <div class="card-body">
                        <h4 class="text-center">Existencias en bodegas</h4>
                    </div>
                </div>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col mx-auto">
                <div class="card">
                    <div class="card-body">
                        <asp:MultiView ActiveViewIndex="0" runat="server" ID="MultiViewProductStocks">
                            <asp:View runat="server">
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
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="GridViewProductStocks" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </asp:View>
                            <asp:View runat="server">
                                <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                    <ContentTemplate>
                                        <div class="row mt-3">
                                            <div class="col">
                                                <div class="card card-shadow">
                                                    <div class="card-body">
                                                        <div class="row">
                                                            <div class="col">
                                                                <div class="card">
                                                                    <div class="card-body">
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
                                                                            <div class="col-md-3">
                                                                                <div class="form-group">
                                                                                    <br />
                                                                                    <asp:Button CssClass="btn btn-primary btn-block" runat="server" Text="Buscar" ID="btnSearchStocksDetails" OnClick="btnSearchStocksDetails_Click" />
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-3 text-right">
                                                                                <div class="form-group">
                                                                                    <asp:Button CssClass="btn btn-primary" runat="server" Text="Regresar" ID="btnGoBackToMainView" OnClick="btnGoBackToMainView_Click" />
                                                                                </div>
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
                                                                                <asp:BoundField HeaderText="Unidad compra" DataField="PurchaseUnitName" />
                                                                                <asp:BoundField HeaderText="Compra Unidad inicial" DataField="OriginalQuantity" />
                                                                                <asp:BoundField HeaderText="Unidad actual" DataField="StocksQuantityStr" />
                                                                                <asp:BoundField HeaderText="Unidad base" DataField="UnitBaseName" />
                                                                                <asp:BoundField HeaderText="Conversion" DataField="ConversionValueStr" />
                                                                                <asp:BoundField HeaderText="Precio unidad compra" DataField="SalePriceStr" />
                                                                                <asp:BoundField HeaderText="Precio unidad base" DataField="SalePriceByUnitBaseStr" />
                                                                                <asp:BoundField HeaderText="Fecha expiración" DataField="ExpirationDate" />
                                                                                <asp:BoundField HeaderText="Estado" DataField="Available" />
                                                                                <asp:TemplateField HeaderText="Opciones">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton Font-Size="11px" Height="28px" Width="80px"
                                                                                            CssClass="btn btn-primary btn-sm" ID="LinkSelect" ToolTip="Seleccionar Producto"
                                                                                            CommandName="cmdSelect" runat="server">Transferir</asp:LinkButton>
                                                                                        <asp:LinkButton Font-Size="11px" Height="28px" Width="80px"
                                                                                            CssClass="btn btn-danger btn-sm" ID="LinkButton1" ToolTip="Seleccionar Producto"
                                                                                            CommandName="cmdSelect" runat="server">Eliminar</asp:LinkButton>
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
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnGoBackToMainView" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </asp:View>
                        </asp:MultiView>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="Toast-Alert" class="toast">
        <div id="Toast-Image-Type" class="toast-img"><i class="fas fa-exclamation"></i></div>
        <div id="Toast-Body" class="toast-body">
            <p id="Toast-Content" style="text-align: justify;">
            </p>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptSection" runat="server">
    <script>
        function ShowToaster(message, CssClass) {
            var style = "toast-img-" + CssClass;

            var image = document.getElementById('Toast-Image-Type');
            image.classList.remove(style);
            image.classList.add(style);

            var alert = document.getElementById('Toast-Alert');
            alert.classList.add("show");

            var content = document.getElementById('Toast-Content');
            content.innerHTML = message;

            setTimeout(function () {
                alert.classList.remove("show");
                content.innerHTML = "";
                image.classList.remove(style);
            }, 5000);
        }
    </script>
</asp:Content>
