<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WarehouseProducts.aspx.cs" Inherits="HardwareStore.Modules.ProductsAdmin.WarehouseProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        
    </style>

    <%-- Start Seccion alert --%>
    <div id="section-alerts" class="section-alert">
    </div>
    <%-- End Section alert --%>

    <div id="spinner-loader" class="spinner-container d-flex justify-content-center align-items-center">
        <div class="spinner-border text-warning" style="width: 5rem; height: 5rem; border-width: 8px;" role="status">
            <span class="sr-only">Loading...</span>
        </div>
    </div>
    <%-- Modal section --%>

    <div class="modal fade" id="ModalDeleteProduct" tabindex="-1" role="dialog" aria-labelledby="tituloVentana" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-xl" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <asp:UpdatePanel runat="server" ID="UpdatePanelFormDeleteProduct">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col">
                                    <div class="card card-shadow">
                                        <div class="card-header text-center">
                                            <h4>Eliminar producto</h4>
                                        </div>
                                        <div class="card-body">
                                            <div class="row mt-3">
                                                <div class="col-md-5">
                                                    <div class="card">
                                                        <div class="card-body">
                                                            <ul class="list-group list-group-flush">
                                                                <li class="list-group-item text-center"><strong>Código:</strong> <span id="ProductDetailCode"></span></li>
                                                                <li class="list-group-item"><strong>Producto:</strong>  <span id="ProductName"></span></li>
                                                                <li class="list-group-item"><strong>Categoría:</strong> <span id="CategoryName"></span></li>
                                                                <li class="list-group-item"><strong>Marca:</strong> <span id="BrandName"></span></li>
                                                                <li class="list-group-item"><strong>Dimensiones:</strong>   <span id="Dimensions"></span></li>
                                                                <li class="list-group-item"><strong>Material:</strong>  <span id="MaterialName"></span></li>
                                                                <li class="list-group-item"><strong>Unidades:</strong>  <span id="StocksQuantity"></span></li>
                                                            </ul>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-7">
                                                    <div class="card">
                                                        <div class="card-body">
                                                            <asp:TextBox runat="server" ID="txtStocksQuantity" ReadOnly="true" Visible="false" />
                                                            <asp:TextBox runat="server" ID="txtMeasureUnitBaseId" ReadOnly="true" Visible="false" />
                                                            <asp:TextBox runat="server" ID="txtMeasureUnitPurchasedId" ReadOnly="true" Visible="false" />
                                                            <asp:TextBox runat="server" ID="txtMeasureUnitTypeId" ReadOnly="true" Visible="false" />
                                                            <asp:TextBox runat="server" ID="txtProductStockId" ReadOnly="true" Visible="false" />
                                                            <asp:TextBox runat="server" ID="txtLotNumber" ReadOnly="true" Visible="false" />
                                                            <asp:TextBox runat="server" ID="txtStocksDetailCode" ReadOnly="true" Visible="false" />
                                                            <asp:TextBox runat="server" ID="txtCurrentStocks" ReadOnly="true" Visible="false" />
                                                            <div class="form-row">
                                                                <div class="form-group col">
                                                                    <asp:Label Text="Titulo" runat="server" />
                                                                    <asp:TextBox runat="server" ID="txtDeleteTitle" placeholder="Titulo" CssClass="form-control" />
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="form-group col-md-8">
                                                                    <asp:Label Text="Unidad" runat="server" />
                                                                    <asp:DropDownList ID="DropDownListUnitsMeasure" CssClass="form-control" runat="server">
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="form-group col-md-4">
                                                                    <asp:Label Text="Cantidad" runat="server" />
                                                                    <asp:TextBox runat="server" TextMode="Number" ID="txtDeleteQuantity" placeholder="Cantidad" CssClass="form-control" />
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="form-group col">
                                                                    <asp:Label Text="Descripción" runat="server" />
                                                                    <asp:TextBox runat="server" ID="txtDeleteDescription" placeholder="Descripcion" CssClass="form-control" />
                                                                </div>
                                                            </div>
                                                            <div class="row justify-content-center">
                                                                <div class="col-md-3 p-1">
                                                                    <asp:Button runat="server" Text="Cancelar" CssClass="btn btn-warning btn-block" data-dismiss="modal" aria-label="cerrar" />
                                                                </div>
                                                                <div class="col-md-3 p-1">
                                                                    <asp:Button runat="server" Text="Eliminar" OnClientClick="ShowLoader(true)" OnClick="btnDeleteProductFromStocks_Click" ID="btnDeleteProductFromStocks" CssClass="btn btn-danger btn-block" />
                                                                </div>
                                                            </div>
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
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>


    <div class="modal fade" id="TransferModal" tabindex="-1" role="dialog" aria-labelledby="tituloVentana" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <asp:UpdatePanel runat="server" ID="UpdatePanelForTransferModal">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col">
                                    <div class="card card-shadow">
                                        <div class="card-header text-center">
                                            <h4>Transferir producto</h4>
                                        </div>
                                        <div class="card-body">
                                            <asp:TextBox runat="server" ID="txtStockCodeTransfer" ReadOnly="true" Visible="false" />
                                            <div class="form-row">
                                                <div class="form-group col-lg-6">
                                                    <asp:Label Text="Código" runat="server" />
                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtProductDetailCodeTransfer" placeholder="Código" ReadOnly="true" />
                                                </div>
                                                <div class="form-group col-lg-6">
                                                    <asp:Label Text="Producto" runat="server" />
                                                    <asp:TextBox runat="server" ID="txtProductNameTransfer" CssClass="form-control" placeholder="Producto" ReadOnly="true"/>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label Text="Bodega destino" runat="server" />
                                                <div class="input-group">
                                                    <asp:DropDownList ID="DropDownListTargetWarehouse" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator Font-Size="10" ForeColor="Red" runat="server" ID="RequiredFieldValidator9" ValidationGroup="TransferPorductForm" ControlToValidate="DropDownListTargetWarehouse">
                                                         <div class="ctrlvalidate">
                                                              <div style="color: #fff">
                                                                   Campo requerido  
                                                              </div>
                                                              <div class="fas fa-sort-down position-absolute"></div>
                                                          </div>                                                      
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label Text="Unidad a transferir" runat="server" />
                                                <div class="input-group">
                                                    <asp:DropDownList ID="DropDownListMeasureUnitsToTransfer" CssClass="form-control" runat="server">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator Font-Size="10" ForeColor="Red" runat="server" ID="RequiredFieldValidator1" ValidationGroup="TransferPorductForm" ControlToValidate="DropDownListMeasureUnitsToTransfer">
                                                         <div class="ctrlvalidate">
                                                              <div style="color: #fff">
                                                                   Campo requerido  
                                                              </div>
                                                              <div class="fas fa-sort-down position-absolute"></div>
                                                          </div>                                                      
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label Text="Unidades" runat="server" />
                                                <div class="input-group">
                                                    <asp:TextBox runat="server" ID="txtUnitQuantityToTransfer" TextMode="Number" placeholder="Cantidad" CssClass="form-control" />
                                                    <asp:RequiredFieldValidator Font-Size="10" ForeColor="Red" runat="server" ID="RequiredFieldValidator2" ValidationGroup="TransferPorductForm" ControlToValidate="txtUnitQuantityToTransfer">
                                                         <div class="ctrlvalidate">
                                                              <div style="color: #fff">
                                                                   Campo requerido  
                                                              </div>
                                                              <div class="fas fa-sort-down position-absolute"></div>
                                                          </div>
                                                    </asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="row justify-content-center">
                                                <div class="col-lg-3 p-1">
                                                    <asp:Button runat="server" Text="Cancelar" CssClass="btn btn-warning btn-block" data-dismiss="modal" aria-label="cerrar" />
                                                </div>
                                                <div class="col-lg-3 p-1">
                                                    <asp:Button runat="server" ValidationGroup="TransferPorductForm" Text="Transferir" ID="btnConfirmProductTrasnfer" OnClick="btnConfirmProductTrasnfer_Click" CssClass="btn btn-success btn-block" />
                                                </div>
                                            </div>
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
    </div>
    <%-- End Modal section --%>

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
                                                                                        <asp:LinkButton Font-Size="11px" OnClientClick="ShowLoader(true)" Height="28px" Width="80px"
                                                                                            CssClass="btn btn-primary btn-sm" ID="LinkSelect" ToolTip="Transferir Producto"
                                                                                            CommandName="cmdTransfer" runat="server">Transferir</asp:LinkButton>
                                                                                        <asp:LinkButton Font-Size="11px" OnClientClick="ShowLoader(true)" Height="28px" Width="80px"
                                                                                            CssClass="btn btn-danger btn-sm" ID="LinkDelete" ToolTip="Eliminar Producto"
                                                                                            CommandName="cmdDelete" runat="server">Eliminar</asp:LinkButton>
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

        //(function () {
        //    this.ShowLoader(true);
        //    $('#ModalDeleteProduct').modal('show');
        //}())
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

        function ShowLoader(status) {
            console.log(status);
            var spinner = document.getElementById('spinner-loader');
            if (status) {
                spinner.classList.remove("hide");
                spinner.classList.add('show');
            } else {
                spinner.classList.add("hide");
                //spinner.classList.remove("show");
            }
        }

        function ShowModalDeleteProduct(StringStock) {
            var Stock = JSON.parse(StringStock);
            var ProductDetailCode = document.getElementById('ProductDetailCode');
            var ProductName = document.getElementById('ProductName');
            var CategoryName = document.getElementById('CategoryName');
            var BrandName = document.getElementById('BrandName');
            var Dimensions = document.getElementById('Dimensions');
            var MaterialName = document.getElementById('MaterialName');
            var StocksQuantity = document.getElementById('StocksQuantity');
            ProductDetailCode.innerText = "#" + Stock.ProductDetailCode;
            ProductName.innerText = Stock.ProductName;
            CategoryName.innerText = Stock.CategoryName;
            BrandName.innerText = Stock.BrandName;
            Dimensions.innerText = Stock.Dimensions;
            MaterialName.innerText = Stock.MaterialName;
            StocksQuantity.innerText = Stock.StocksQuantity + " " + Stock.PurchaseUnitName;
            setTimeout(function () { this.ShowLoader(false); $('#ModalDeleteProduct').modal('show') }, 350);
        }

        function ShowAlert(title, message, CssClass) {
            setTimeout(function () {
                this.ShowLoader(false);
                $('#ModalWarehouses').modal('hide');
                $('#ModalSuppliers').modal('hide');
                const div = document.getElementById("section-alerts");
                const divalert = document.createElement('div');
                div.style.display = "block"
                divalert.className = `alert alert-${CssClass} m-2 alert-dismissible fade show`;
                const contentMessage = document.createTextNode(message);
                const strong = document.createElement('strong');
                strong.style.marginRight = "10px";
                const contentTitle = document.createTextNode(title);
                strong.appendChild(contentTitle);
                divalert.appendChild(strong);
                divalert.appendChild(contentMessage);
                div.appendChild(divalert);
                setTimeout(function () {
                    $('.alert').alert('close')
                    div.style.display = "none";
                    divalert.remove();
                }, 5000);
            }, 1500);
        }
    </script>
</asp:Content>
