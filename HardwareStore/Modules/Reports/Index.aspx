<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="HardwareStore.Modules.Reports.Index" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <asp:MultiView runat="server" ID="MultiviewReports" ActiveViewIndex="0">
                <%-- Vista Principal --%>
                <asp:View runat="server">
                    <div style="border-top: 2px solid #C82333" class="container p-4 card mt-4 shadow rounded">
                        <div class="d-flex justify-content-center m-4">
                            <h3>Reportes</h3>
                        </div>
                        <div class="dropdown-divider mb-5">
                        </div>
                        <div class="row mt-2 mb-5 flex-lg-wrap d-flex justify-content-center">
                            <div class="col-lg-3">
                                <div class="card shadow rounded m-2">
                                    <div class="card-body">
                                        <h5 class="card-title text-center">Ventas</h5>
                                        <%--<p class="card-text">Puedes crear reportes de Puedes crear reportes de ventasentas</p>--%>
                                        <div class="d-flex justify-content-center">
                                            <asp:Button ID="btnSaleReport" OnClick="btnSaleReport_Click" CssClass="btn btn-primary" Text="Crear Reporte" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="card shadow rounded m-2">
                                    <div class="card-body">
                                        <h5 class="card-title text-center">Compras</h5>
                                        <%--<p class="card-text">Puedes crear reportes de Compras</p>--%>
                                        <div class="d-flex justify-content-center">
                                            <asp:Button ID="btnPurchaseReport" OnClick="btnPurchaseReport_Click" CssClass="btn btn-primary" Text="Crear Reporte" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="card shadow rounded m-2">
                                    <div class="card-body">
                                        <h5 class="card-title text-center">Productos</h5>
                                        <%--<p class="card-text">Puedes crear reportes de los productos del negocio</p>--%>
                                        <div class="d-flex justify-content-center">
                                            <asp:Button ID="btnNewProductReport" OnClick="btnNewProductReport_Click" CssClass="btn btn-primary" Text="Crear Reporte" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="card shadow rounded m-2">
                                    <div class="card-body">
                                        <h5 class="card-title text-center">Existencias</h5>
                                        <%--<p class="card-text">Puedes crear reportes de existencias de productos</p>--%>
                                        <div class="d-flex justify-content-center">
                                            <asp:Button ID="btnNewReportExistencies" OnClick="btnNewReportExistencies_Click" CssClass="btn btn-primary" Text="Crear Reporte" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="card shadow rounded m-2 mt-4">
                                    <div class="card-body">
                                        <h5 class="card-title text-center">Productos Eliminados</h5>
                                        <%--<p class="card-text">Puedes crear reportes de existencias de productos</p>--%>
                                        <div class="d-flex justify-content-center">
                                            <asp:Button ID="btnDamagedProducts" OnClick="btnDamagedProducts_Click" CssClass="btn btn-primary" Text="Crear Reporte" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:View>
                <%-- Reporte Productos --%>
                <asp:View runat="server">
                    <div class="p-4">
                        <h3>Lista de productos</h3>
                        <div class="form-row">
<%--                            <div class="form-group col-lg-5">
                                <label>Filtrar por bodegas</label>
                                <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlistFilterByWarehousesModuleProduct" OnSelectedIndexChanged="ddlistFilterByWarehousesModuleProduct_SelectedIndexChanged" CssClass="form-control">
                                </asp:DropDownList>
                            </div>--%>
                            <div class="col-lg-4">
                                <asp:Label Text="Buscar: " runat="server" />
                                <div class="form-group">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtSearchProduct" />
                                </div>
                            </div>
                            <div class="col-lg-3 mt-4">
                                <asp:Button Text="Filtrar" ID="btnSearchProducts" OnClick="btnSearchProducts_Click" CssClass="btn btn-primary" runat="server" />
                            </div>
                        </div>

                        <%--                        <div class="row">
                            <asp:Button Text="Vista principal" runat="server" ID="btnGoToMainView" />
                        </div>--%>
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
                            <LocalReport ReportPath="Data\ProductsReports\ProductReport.rdlc">
                            </LocalReport>
                        </rsweb:ReportViewer>
                    </div>
                </asp:View>
                <%-- Reporte de Compras --%>
                <asp:View runat="server">
                    <div class="p-4">
                        <div class="m-2">
                            <h3 class="text-center">Compras</h3>
                        </div>
                        <div class="form-row col-lg-12 my-3">
                            <div class="col-lg-3">
                                <asp:Label Text="Desde: " runat="server" />
                                <div class="form-group">
                                    <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="PurchaseDateFrom" />
                                    <asp:RequiredFieldValidator Font-Size="10" ForeColor="Red" runat="server" ID="RequiredFieldValidator9" ValidationGroup="DetailsGroupDate" ControlToValidate="PurchaseDateFrom">
                                         <div class="ctrlvalidate">
                                              <div style="color: #fff">
                                                   Campo requerido  
                                               </div>
                                              <div class="fas fa-sort-down position-absolute"></div>
                                         </div>                                                      
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <asp:Label Text="Hasta: " runat="server" />
                                <div class="form-group">
                                    <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="PurchaseDateTo" />
                                    <asp:RequiredFieldValidator Font-Size="10" ForeColor="Red" runat="server" ID="RequiredFieldValidator1" ValidationGroup="DetailsGroupDate" ControlToValidate="PurchaseDateTo">
                                         <div class="ctrlvalidate">
                                              <div style="color: #fff">
                                                   Campo requerido  
                                               </div>
                                              <div class="fas fa-sort-down position-absolute"></div>
                                         </div>                                                      
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <asp:Label Text="Buscar: " runat="server" />
                                <div class="form-group">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="PurchaseSearch" />
                                </div>
                            </div>
                            <div class="col-lg-3 mt-4">
                                <asp:Button ValidationGroup="DetailsGroupDate" Text="Filtrar" ID="btnFilterPurchase" OnClick="btnFilterPurchase_Click" CssClass="btn btn-primary" runat="server" />
                            </div>
                        </div>
                        <rsweb:ReportViewer ID="ReportViewer2" runat="server" Width="100%">
                            <LocalReport ReportPath="Data\PurchaseReports\PurchaseReport.rdlc">
                            </LocalReport>
                        </rsweb:ReportViewer>
                    </div>
                </asp:View>
                <%-- Reporte de Ventas --%>
                <asp:View runat="server">
                    <div class="p-4">
                        <div class="m-2">
                            <h3 class="text-center">Ventas</h3>
                        </div>
                        <div class="form-row col-lg-12 my-3">
                            <div class="col-lg-3">
                                <asp:Label Text="Desde: " runat="server" />
                                <div class="form-group">
                                    <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="StartDateSale" />
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <asp:Label Text="Hasta: " runat="server" />
                                <div class="form-group">
                                    <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="EndDateSale" />
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <asp:Label Text="Buscar: " runat="server" />
                                <div class="form-group">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtSearchSale" />
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group mt-4">
                                    <asp:Button Text="Filtrar" ID="btnNewReportSale" OnClick="btnNewReportSale_Click" CssClass="btn btn-primary" runat="server" />
                                </div>
                            </div>
                        </div>
                        <rsweb:ReportViewer ID="ReportViewer3" runat="server" Width="100%">
                            <LocalReport ReportPath="Data\SalesReports\SalesReport.rdlc">
                            </LocalReport>
                        </rsweb:ReportViewer>
                    </div>
                </asp:View>
                <%-- Existencia de Productos --%>
                <asp:View runat="server">
                    <div class="p-4">
                        <div class="m-2">
                            <h3 class="text-center">Exientencia de Productos</h3>
                        </div>
                        <div class="form-row col-lg-12 my-3">
                            <%--                            <div class="col-lg-3">
                                <input runat="server" type="date" id="Date1" class="form-control" />
                            </div>
                            <div class="col-lg-3">
                                <input runat="server" type="date" id="Date2" class="form-control" />
                            </div>--%>
                            <div class="col-lg-3">
                                <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlistFilterByWarehouses" OnSelectedIndexChanged="ddlistFilterByWarehouses_SelectedIndexChanged" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-3">
                                <asp:Button Text="Filtrar" ID="Button1" CssClass="btn btn-primary" runat="server" />
                            </div>
                        </div>
                        <rsweb:ReportViewer ID="ReportViewer4" runat="server" Width="100%">
                            <LocalReport ReportPath="Data\ExistenciesReports\ExistenciesProducts.rdlc">
                            </LocalReport>
                        </rsweb:ReportViewer>
                    </div>
                </asp:View>
                <%-- Productos Dañados --%>
                <asp:View runat="server">
                    <div class="p-4">
                        <div class="m-2">
                            <h3 class="text-center">Productos Dañados</h3>
                        </div>
                        <div class="form-row col-lg-12 my-3">
                            <div class="col-lg-3">
                                <asp:Label Text="Desde: " runat="server" />
                                <div class="form-group">
                                    <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="txtStartDatePD" />
                                    <asp:RequiredFieldValidator Font-Size="10" ForeColor="Red" runat="server" ID="RequiredFieldValidator2" ValidationGroup="DetailsGroupDate" ControlToValidate="PurchaseDateFrom">
                                         <div class="ctrlvalidate">
                                              <div style="color: #fff">
                                                   Campo requerido  
                                               </div>
                                              <div class="fas fa-sort-down position-absolute"></div>
                                         </div>                                                      
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <asp:Label Text="Hasta: " runat="server" />
                                <div class="form-group">
                                    <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="txtEndDatePD" />
                                    <asp:RequiredFieldValidator Font-Size="10" ForeColor="Red" runat="server" ID="RequiredFieldValidator3" ValidationGroup="DetailsGroupDate" ControlToValidate="PurchaseDateTo">
                                         <div class="ctrlvalidate">
                                              <div style="color: #fff">
                                                   Campo requerido  
                                               </div>
                                              <div class="fas fa-sort-down position-absolute"></div>
                                         </div>                                                      
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <asp:Label Text="Buscar: " runat="server" />
                                <div class="form-group">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="TextBox3" />
                                </div>
                            </div>
                            <div class="col-lg-3 mt-4">
                                <asp:Button ValidationGroup="DetailsGroupDate" Text="Filtrar" ID="btnFilterDamagedProducts" OnClick="btnFilterDamagedProducts_Click" CssClass="btn btn-primary" runat="server" />
                            </div>
                        </div>
                        <rsweb:ReportViewer ID="ReportViewer5" runat="server" Width="100%">
                            <LocalReport ReportPath="Data\DamagedProductsReports\DamagedProductsReport.rdlc">
                            </LocalReport>
                        </rsweb:ReportViewer>
                    </div>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnNewProductReport" />
            <asp:PostBackTrigger ControlID="btnFilterPurchase" />
            <asp:PostBackTrigger ControlID="btnPurchaseReport" />
            <asp:PostBackTrigger ControlID="btnSaleReport" />
            <asp:PostBackTrigger ControlID="btnNewReportExistencies" />
            <asp:PostBackTrigger ControlID="btnDamagedProducts" />
        </Triggers>
    </asp:UpdatePanel>
    <div id="toastDate" class="toast">
        <div class="toast-img toast-img-danger"><i class="fas fa-exclamation"></i></div>
        <div class="toast-body">
            <p style="text-align: justify;">
                La fecha incio no debe<br />
                ser mayor a la fecha final!
            </p>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptSection" runat="server">
    <script>
        function ModalDate() {
            var el = document.getElementById("toastDate")
            el.classList.add("show");
            setTimeout(function () { el.classList.remove("show") }, 5000);
        }
    </script>
</asp:Content>
