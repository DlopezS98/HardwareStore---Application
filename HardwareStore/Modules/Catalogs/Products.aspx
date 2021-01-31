<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="HardwareStore.Modules.Catalogs.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-sm mt-4">
        <div class="row">
            <div class="col-md-12 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <!-- Header of tabs -->
                        <ul class="nav nav-tabs" id="myTab" role="tablist">
                            <li class="nav-item" role="presentation">
                                <a class="nav-link" id="newproducts-tab" data-toggle="tab" href="#newproducts-content" role="tab" aria-controls="newproducts-content" aria-selected="false">Nuevo producto</a>
                            </li>
                            <li class="nav-item" role="presentation">
                                <a class="nav-link active" id="productlist-tab" data-toggle="tab" href="#productlist-content" role="tab" aria-controls="productlist-content" aria-selected="true">Lista de productos</a>
                            </li>
                        </ul>
                        <%-- End Headers of tabs --%>

                        <%-- Start tabs content --%>
                        <div class="tab-content" id="myTabContent">
                            <%-- New product section --%>
                            <div class="tab-pane fade" id="newproducts-content" role="tabpanel" aria-labelledby="newproducts-tab">
                                <asp:UpdatePanel runat="server" ID="UpdatePanelForNewProducts">
                                    <ContentTemplate>
                                        <div class="row mt-3">
                                            <div class="col">
                                                <div class="card card-shadow">
                                                    <div class="card-body">
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="card">
                                                                    <div class="card-body">
                                                                        <div class="form-group">
                                                                            <asp:Label Text="Código del producto" runat="server" />
                                                                            <asp:TextBox runat="server" ReadOnly="true" placeholder="Código" ID="txtDefaultProductCode" CssClass="form-control" />
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label Text="Nombre del producto" runat="server" />
                                                                            <asp:TextBox runat="server" ID="txtProductName" CssClass="form-control" placeholder="Nombre producto" />
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label Text="Unidad de medida base" runat="server" />
                                                                            <div class="input-group">
                                                                                <asp:DropDownList ID="DropDownListUnitMeasure" CssClass="form-control" runat="server">
                                                                                </asp:DropDownList>
                                                                                <div class="input-group-append">
                                                                                    <asp:Button runat="server" Text="+" ID="btnAddNewMeasureUnit" data-toggle="modal" data-target="#ModalMeasureUnits" CssClass="btn btn-info btn-sm" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <asp:Label Text="Descripción" runat="server" />
                                                                            <asp:TextBox runat="server" ID="txtProductDescription" CssClass="form-control" placeholder="Descripción" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="card">
                                                                    <div class="card-body">
                                                                        <asp:TextBox runat="server" ID="txtMeasureUnitId" ReadOnly="true" Visible="false" />
                                                                        <asp:TextBox runat="server" ID="txtWarehouseId" ReadOnly="true" Visible="false" />

                                                                        <%--<div class="form-row">--%>
                                                                        <%--<div class="form-group col-lg-6">--%>
                                                                        <div class="form-group">
                                                                            <%--<div style="margin-bottom: .5rem;">--%>
                                                                            <asp:Label Text="Marcas" runat="server" />
                                                                            <%--</div>--%>
                                                                            <div class="input-group">
                                                                                <asp:DropDownList ID="DropDownListBrands" CssClass="form-control" runat="server">
                                                                                </asp:DropDownList>
                                                                                <div class="input-group-append">
                                                                                    <asp:Button runat="server" Text="+" ID="btnAddNewBrand" data-toggle="modal" data-target="#ModalBrands" CssClass="btn btn-info btn-sm" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <%--</div>--%>
                                                                        <%--<div class="form-row">--%>
                                                                            <div class="form-group">
                                                                                <%--<div style="margin-bottom: .5rem;">--%>
                                                                                <asp:Label Text="Tipo de material" runat="server" />
                                                                                <%--</div>--%>
                                                                                <div class="input-group">
                                                                                    <asp:DropDownList ID="DropDownListMaterialTypes" CssClass="form-control" runat="server">
                                                                                    </asp:DropDownList>
                                                                                    <div class="input-group-append">
                                                                                        <asp:Button runat="server" Text="+" ID="btnAddNewMaterialType" data-toggle="modal" data-target="#ModalMaterialTypes" CssClass="btn btn-info btn-sm" />
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group">
                                                                                <asp:Label Text="Categorías" runat="server" />
                                                                                <div class="input-group">
                                                                                    <asp:DropDownList ID="DropDownListCategories" CssClass="form-control" runat="server">
                                                                                    </asp:DropDownList>
                                                                                    <div class="input-group-append">
                                                                                        <asp:Button runat="server" Text="+" ID="btnAddNewCategory" data-toggle="modal" data-target="#ModalCategories" CssClass="btn btn-info btn-sm" />
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        <%--</div>--%>
                                                                        <div class="form-group">
                                                                            <asp:Label Text="Dimensiones" runat="server" />
                                                                            <div class="input-group">
                                                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtBrandName" placeholder="Dimensiones..." />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="card-footer">
                                                        <div class="row justify-content-center">
                                                            <div class="col-md-2 p-1">
                                                                <asp:Button runat="server" Text="Agregar" ID="btnAddToPurchaseDetailList" CssClass="btn btn-success btn-block" />
                                                            </div>
                                                            <div class="col-md-2 p-1">
                                                                <asp:Button runat="server" Text="Cancelar" ID="btnCancelOrClearDetailForm" CssClass="btn btn-warning btn-block" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <%--<asp:PostBackTrigger ControlID="btnAddToPurchaseDetailList" />--%>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <%-- End new product section --%>

                            <%-- Product list --%>
                            <div class="tab-pane fade show active" id="productlist-content" role="tabpanel" aria-labelledby="productlist-tab">
                                <asp:UpdatePanel runat="server" ID="UpdatePanelForProductsList">
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
                                                                                <asp:TextBox runat="server" CssClass="form-control" ID="PickerStartDateFilter" TextMode="Date" />
                                                                            </div>
                                                                            <div class="form-group col-md-3">
                                                                                <asp:Label Text="Fecha Final" runat="server" />
                                                                                <asp:TextBox runat="server" CssClass="form-control" ID="PickerEndDateFilter" TextMode="Date" />
                                                                            </div>
                                                                            <div class="form-group col-md-2">
                                                                                <br />
                                                                                <asp:Button Text="Filtrar" runat="server" ID="btnProductFilter" CssClass="btn btn-primary btn-block" />
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
                                                                        <%--<asp:GridView runat="server" DataKeyNames="Id, InvoiceNumber" AutoGenerateColumns="false"
                                                                                ID="GridViewInvoices" CssClass="table" CellPadding="5" OnRowCommand="GridViewInvoices_RowCommand">
                                                                                <HeaderStyle CssClass="thead-dark" />
                                                                                <Columns>
                                                                                    <asp:BoundField HeaderText="Id" DataField="Id" Visible="false" />
                                                                                    <asp:BoundField HeaderText="No. Factura" DataField="InvoiceNumber" />
                                                                                    <asp:BoundField HeaderText="Proveedor" DataField="SupplierName" />
                                                                                    <asp:BoundField HeaderText="Factura proveedor" DataField="SupplierInvoiceNumber" />
                                                                                    <asp:BoundField HeaderText="Subtotal" DataField="Subtotal" />
                                                                                    <asp:BoundField HeaderText="IVA" DataField="Tax" />
                                                                                    <asp:BoundField HeaderText="Descuento" DataField="Discount" />
                                                                                    <asp:BoundField HeaderText="Total" DataField="TotalAmount" />
                                                                                    <asp:BoundField HeaderText="Fecha creación" DataField="CreationDate" />
                                                                                    <asp:BoundField HeaderText="Fecha actualización" DataField="UpdateDate" />
                                                                                    <asp:BoundField HeaderText="Realizada por" DataField="CreatedBy" />
                                                                                    <asp:TemplateField HeaderText="Opciones">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton Font-Size="11px" Height="28px" Width="80px"
                                                                                                CssClass="btn btn-primary btn-sm mb-3" ID="DetailsLink" ToolTip="Detalle de compra"
                                                                                                CommandName="cmdDetails" runat="server">Detalles</asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>--%>
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
                            <%-- End product list --%>
                        </div>
                        <%-- End tabs content --%>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
