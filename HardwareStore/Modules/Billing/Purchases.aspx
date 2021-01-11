<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Purchases.aspx.cs" Inherits="HardwareStore.Modules.Billing.Purchases" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://unpkg.com/materialize-stepper@3.1.0/dist/css/mstepper.min.css">
    <div class="container mt-3" style="display: none;">
        <asp:GridView runat="server" DataKeyNames="Code" AutoGenerateColumns="false"
            ID="GridViewProductDetails" CssClass="table" CellPadding="5">
            <Columns>
                <asp:BoundField HeaderText="Código" DataField="Code" />
                <asp:BoundField HeaderText="Producto" DataField="ProductName" />
                <asp:BoundField HeaderText="Unidad de medida" DataField="MeasureUnit" />
                <asp:BoundField HeaderText="Categoría" DataField="CategoryName" />
                <asp:BoundField HeaderText="Material" DataField="MaterialName" />
                <asp:BoundField HeaderText="Dimensiones" DataField="Dimensions" />
                <asp:BoundField HeaderText="Expiración" DataField="ExpirationDate" />
                <asp:BoundField HeaderText="Fecha registro" DataField="CreatedAt" />
                <asp:BoundField HeaderText="Creado por" DataField="CreatedBy" />
                <asp:BoundField HeaderText="Estado" DataField="Status" />
            </Columns>
        </asp:GridView>
    </div>

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
                                    <%--  --%>
                                    <div class="tab-pane fade" id="purchaselist-content" role="tabpanel" aria-labelledby="purchaselist-tab">historial</div>

                                    <%-- New Sale Section --%>
                                    <div class="tab-pane fade show active" id="newpurchase-content" role="tabpanel" aria-labelledby="newpurchase-tab">
                                        <div class="row mt-3">
                                            <div class="col-md-12">
                                                <div class="card card-shadow">
                                                    <div class="card-body">
                                                        <div class="form-row">
                                                            <div class="form-group col-md-4">
                                                                <div class="d-flex justify-content-start">
                                                                    <label>Producto</label>
                                                                </div>
                                                                <div class="input-group">
                                                                    <input type="text" readonly placeholder="Producto" runat="server" id="txtProductName" class="form-control form-disable">
                                                                    <div title="Elige un Producto" class="input-group-append">
                                                                        <button class="btn btn-info" data-toggle="modal" data-target="#ventanaModal">...</button>
                                                                    </div>
                                                                    <div title="Crea un nuevo Producto" class="input-group-append">
                                                                        <button class="btn btn-success" data-toggle="modal" data-target="#ModalnewProduct">+</button>
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
                                                                        <button data-toggle="modal" data-target="#ModalWarehause" class="btn btn-info" type="button">+</button>
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
                                                                        <button data-toggle="modal" data-target="#ModalSuppliers" class="btn btn-info" type="button">+</button>
                                                                    </div>
                                                                </div>
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
                                        
                                    </div>
                                    <%-- End Detail Sale --%>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptSection" runat="server">
    <script src="https://unpkg.com/materialize-stepper@3.1.0/dist/js/mstepper.min.js"></script>
</asp:Content>
