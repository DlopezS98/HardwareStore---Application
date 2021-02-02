<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RemovedProducts.aspx.cs" Inherits="HardwareStore.Modules.ProductsAdmin.RemovedProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
                        <%--<asp:MultiView ActiveViewIndex="0" runat="server" ID="MultiViewProductStocks">
                            <asp:View runat="server">--%>
                                <asp:UpdatePanel runat="server" ID="UpdatePanelForRemovedProducts">
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
                                                                                <asp:TextBox runat="server" ID="txtSearchRemovedProducts" CssClass="form-control" placeholder="Buscar..." />
                                                                            </div>
                                                                            <div class="form-group col-md-3">
                                                                                <asp:Label Text="Fecha Inicio" runat="server" />
                                                                                <asp:TextBox runat="server" CssClass="form-control" ID="PickerStartDateRemovedProducts" TextMode="Date" />
                                                                            </div>
                                                                            <div class="form-group col-md-3">
                                                                                <asp:Label Text="Fecha Final" runat="server" />
                                                                                <asp:TextBox runat="server" CssClass="form-control" ID="PickerEndDateRemovedProducts" TextMode="Date" />
                                                                            </div>
                                                                            <div class="form-group col-md-2">
                                                                                <br />
                                                                                <asp:Button Text="Filtrar" runat="server" ID="btnSearchRemovedProducts" OnClick="btnSearchRemovedProducts_Click" CssClass="btn btn-primary btn-block" />
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
                                                                        <asp:GridView runat="server" DataKeyNames="Id, LotNumber, ProductStocksId, ProductDetailCode" AutoGenerateColumns="false"
                                                                            ID="GridViewRemovedProducts" CssClass="table table-hover" CellPadding="5" OnRowCommand="GridViewRemovedProducts_RowCommand">
                                                                            <HeaderStyle CssClass="thead-dark" />
                                                                            <Columns>
                                                                                <asp:BoundField HeaderText="Id" DataField="Id" Visible="false" />
                                                                                <asp:BoundField HeaderText="Stock id" DataField="ProductStocksId" Visible="false" />
                                                                                <asp:BoundField HeaderText="Codigo producto" DataField="ProductDetailCode" Visible="false" />
                                                                                <asp:BoundField HeaderText="Código de lote" DataField="LotNumber" />
                                                                                <asp:BoundField HeaderText="Bodega" DataField="WarehouseName" />
                                                                                <asp:BoundField HeaderText="Titulo" DataField="Title" />
                                                                                <asp:BoundField HeaderText="Descripción" DataField="Description" />
                                                                                <asp:BoundField HeaderText="Unidad" DataField="MeasureUnitName" />
                                                                                <asp:BoundField HeaderText="Cantidad" DataField="UnitQuantity" />
                                                                                <asp:BoundField HeaderText="Unidad base" DataField="UnitBaseName" />
                                                                                <asp:BoundField HeaderText="Unidades" DataField="ConversionQuantity" />
                                                                                <asp:BoundField HeaderText="Fecha" DataField="DisplayDate" />
                                                                                <asp:BoundField HeaderText="Realizada por" DataField="CreatedBy" />
                                                                                <asp:TemplateField HeaderText="Opciones">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton Font-Size="11px" Height="28px" Width="80px"
                                                                                            CssClass="btn btn-primary btn-sm" ID="LinkRemovedProducts" ToolTip="Detalles"
                                                                                            CommandName="cmdShowDetails" runat="server">Producto</asp:LinkButton>
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
                                        <%--<asp:PostBackTrigger ControlID="GridViewProductStocks" />--%>
                                    </Triggers>
                                </asp:UpdatePanel>
                        <%--</asp:MultiView>--%>
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
