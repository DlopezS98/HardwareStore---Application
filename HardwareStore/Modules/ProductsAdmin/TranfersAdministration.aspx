<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TranfersAdministration.aspx.cs" Inherits="HardwareStore.Modules.ProductsAdmin.TranfersAdministration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="section-alerts" class="section-alert">
    </div>
    <%-- End Section alert --%>

    <div id="spinner-loader" class="spinner-container d-flex justify-content-center align-items-center">
        <div class="spinner-border text-warning" style="width: 5rem; height: 5rem; border-width: 8px;" role="status">
            <span class="sr-only">Loading...</span>
        </div>
    </div>


    <div style="margin-top: 120px" class="modal fade" id="ConfirmDeletions" tabindex="-1" aria-labelledby="confirmDelete" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <asp:UpdatePanel runat="server" ID="UpdatePanelDeleteItem">
                    <ContentTemplate>
                        <div class="modal-header bg-info">
                            <h5 class="modal-title text-light" id="confirmDelete">Alerta!</h5>
                            <button type="button" class="close text-light" data-dismiss="modal" aria-label="Close">
                                <span class="text-light" aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div id="modal-body-content" class="modal-body">
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-primary" data-dismiss="modal">Cancelar</button>
                            <asp:Button Text="Eliminar" runat="server" OnClientClick="ShowLoader(true)" ID="btnConfirmDeleteProduct" OnClick="btnConfirmDeleteProduct_Click" CssClass="btn btn-warning" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
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
                                            <h4>Actualizar producto</h4>
                                        </div>
                                        <div class="card-body">
                                            <asp:TextBox runat="server" ID="txtStockCodeTransfer" ReadOnly="true" Visible="false" />
                                            <asp:TextBox runat="server" ID="txtEditPendingTransferCode" ReadOnly="true" Visible="false" />
                                            <div class="form-row">
                                                <div class="form-group col-lg-6">
                                                    <asp:Label Text="Código" runat="server" />
                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtProductDetailCodeTransfer" placeholder="Código" ReadOnly="true" />
                                                </div>
                                                <div class="form-group col-lg-6">
                                                    <asp:Label Text="Producto" runat="server" />
                                                    <asp:TextBox runat="server" ID="txtProductNameTransfer" CssClass="form-control" placeholder="Producto" ReadOnly="true" />
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
                                                    <asp:Button runat="server" ValidationGroup="TransferPorductForm" Text="Guardar" ID="btnConfirmProductTrasnfer" OnClick="btnConfirmProductTrasnfer_Click" CssClass="btn btn-success btn-block" />
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

    <div class="container mt-4">
        <div class="row">
            <div class="col-md-12 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <!-- Header of tabs -->
                        <ul class="nav nav-tabs" id="myTab" role="tablist">
                            <li class="nav-item" role="presentation">
                                <a class="nav-link" id="purchaselist-tab" data-toggle="tab" href="#purchaselist-content" role="tab" aria-controls="purchaselist-content" aria-selected="false">Trasnferencias pendientes</a>
                            </li>
                            <li class="nav-item" role="presentation">
                                <a class="nav-link active" id="newpurchase-tab" data-toggle="tab" href="#newpurchase-content" role="tab" aria-controls="newpurchase-content" aria-selected="true">Historial de transferencias</a>
                            </li>

                        </ul>

                        <div class="tab-content" id="myTabContent">
                            <%-- purchases list --%>
                            <div class="tab-pane fade" id="purchaselist-content" role="tabpanel" aria-labelledby="purchaselist-tab">
                                <asp:UpdatePanel runat="server" ID="UpdatePanelForInvoiceList">
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
                                                                            <div class="form-group col-lg-4">
                                                                                <asp:Label Text="Buscar" runat="server" />
                                                                                <asp:TextBox runat="server" ID="txtSearchTransferProductPending" CssClass="form-control" placeholder="Buscar..." />
                                                                            </div>
                                                                            <%--<div class="form-group col-lg-3">
                                                                                    <asp:Label Text="Fecha Inicio" runat="server" />
                                                                                    <asp:TextBox runat="server" CssClass="form-control" ID="PickerStartDateInvoceFilter" TextMode="Date" />
                                                                                </div>
                                                                                <div class="form-group col-lg-3">
                                                                                    <asp:Label Text="Fecha Final" runat="server" />
                                                                                    <asp:TextBox runat="server" CssClass="form-control" ID="PickerEndDateInvoiceFilter" TextMode="Date" />
                                                                                </div>--%>
                                                                            <div class="form-group col-lg-2">
                                                                                <br />
                                                                                <asp:Button Text="Filtrar" runat="server" ID="btnPendingTransferFilter" OnClick="btnPendingTransferFilter_Click" CssClass="btn btn-primary btn-block" />
                                                                            </div>
                                                                            <div class="form-group col text-right">
                                                                                <asp:Button Text="Transferir todo" runat="server" ID="SendAllProductsToGenerateTransfer" OnClick="SendAllProductsToGenerateTransfer_Click" CssClass="btn btn-primary" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row mt-4">
                                                            <div class="col">
                                                                <div class="card">
                                                                    <asp:TextBox runat="server" ID="txtPendingTransferCode" ReadOnly="true" Visible="false" />
                                                                    <div class="card-body table-responsive mt-3 mb-3">
                                                                        <asp:GridView runat="server" DataKeyNames="Code, StocksCode, ProductDetailCode" AutoGenerateColumns="false"
                                                                            ID="GridViewPendingTransfer" CssClass="mGrid table" CellPadding="5" OnRowCommand="GridViewPendingTransfer_RowCommand">
                                                                            <HeaderStyle CssClass="thead-dark" />
                                                                            <Columns>
                                                                                <asp:BoundField HeaderText="Id" DataField="Id" Visible="false" />
                                                                                <asp:BoundField HeaderText="Code" DataField="Code" Visible="false" />
                                                                                <asp:BoundField HeaderText="Lote" DataField="LotNumber" />
                                                                                <asp:BoundField HeaderText="Proveedor" DataField="SupplierName" />
                                                                                <asp:BoundField HeaderText="Codigo Producto" DataField="ProductDetailCode" />
                                                                                <asp:BoundField HeaderText="Producto" DataField="ProductName" />
                                                                                <asp:BoundField HeaderText="Bodega origen" DataField="SourceWarehouse" />
                                                                                <asp:BoundField HeaderText="Bodega Destion" DataField="TargetWarehouse" />
                                                                                <asp:BoundField HeaderText="Unidad Base" DataField="UnitBaseName" />
                                                                                <asp:BoundField HeaderText="Unidad trasnferencia" DataField="TargetUnitName" />
                                                                                <asp:BoundField HeaderText="Cantidad" DataField="UnitQuantity" />
                                                                                <asp:BoundField HeaderText="Fecha creación" DataField="CreatedAt" />
                                                                                <asp:BoundField HeaderText="Fecha actualzación" DataField="UpdatedAt" />
                                                                                <asp:BoundField HeaderText="Realizada por" DataField="CreatedBy" />
                                                                                <asp:BoundField HeaderText="Actualizada por" DataField="UpdatedBy" />
                                                                                <asp:TemplateField HeaderText="Opciones">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton Font-Size="11px" Height="28px" Width="80px"
                                                                                            CssClass="btn btn-primary btn-sm mb-3" ID="EditLink" ToolTip="Editar Producto"
                                                                                            CommandName="cmdEdit" runat="server">Editar</asp:LinkButton>
                                                                                        <asp:LinkButton Font-Size="11px" Height="28px" Width="80px"
                                                                                            CssClass="btn btn-danger btn-sm" ID="DeleteLink" ToolTip="Eliminar Producto"
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
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <%-- End list --%>

                            <%-- New Sale Section --%>
                            <div class="tab-pane fade show active" id="newpurchase-content" role="tabpanel" aria-labelledby="newpurchase-tab">
                                <asp:UpdatePanel runat="server" ID="UpdatePanelForTranfersMain">
                                    <ContentTemplate>
                                    </ContentTemplate>
                                    <Triggers>
                                        <%--<asp:PostBackTrigger ControlID="btnAddToPurchaseDetailList" />--%>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <%-- End Sale Section --%>
                        </div>
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
        function ShowAlertInfo(message) {
            let element = document.getElementById("modal-body-content");
            let content = document.createTextNode(message);
            element.appendChild(content);
            $('#ConfirmDeletions').modal('show');
        }

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
            }
        }

        function ShowAlert(title, message, CssClass) {
            setTimeout(function () {
                this.ShowLoader(false);
                $('#ModalWarehouses').modal('hide');

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
