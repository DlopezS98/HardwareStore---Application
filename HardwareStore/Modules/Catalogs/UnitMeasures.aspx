<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UnitMeasures.aspx.cs" Inherits="HardwareStore.Modules.Catalogs.UnitMeasures" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-sm mt-4">
        <div class="row">
            <div class="col-lg-12 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <!-- Header of tabs -->
                        <ul class="nav nav-tabs" id="myTab" role="tablist">
                            <li class="nav-item" role="presentation">
                                <a class="nav-link" id="new-tab" data-toggle="tab" href="#new-content" role="tab" aria-controls="new-content" aria-selected="false">Nueva Unidad de Medida</a>
                            </li>
                            <li class="nav-item" role="presentation">
                                <a class="nav-link active" id="list-tab" data-toggle="tab" href="#list-content" role="tab" aria-controls="list-content" aria-selected="true">Lista de Unidades</a>
                            </li>
                        </ul>
                        <%-- End Headers of tabs --%>

                        <%-- Start tabs content --%>
                        <div class="tab-content" id="myTabContent">
                            <%-- New product section --%>
                            <div class="tab-pane fade" id="new-content" role="tabpanel" aria-labelledby="new-tab">
                                <asp:UpdatePanel runat="server" ID="UpdatePanelForNew">
                                    <ContentTemplate>
                                        <div class="row mt-3">
                                            <div class="col">
                                                <div class="card card-shadow">
                                                    <div class="card-body">
                                                        <div class="row d-flex justify-content-center">
                                                            <div class="col-lg-10">
                                                                <div class="card">
                                                                    <div class="card-body">
                                                                        <div class="d-flex justify-content-center">
                                                                            <div class="w-100 bg-white rounded">
                                                                                <div class="form-row">
                                                                                    <div class="col-lg-4">
                                                                                        <label style="float: left; margin-left: 5px;">Tipo de Unidad</label>
                                                                                        <div class="input-group">
                                                                                            <div style="display: inline-flex; float: left; width: 100%">
                                                                                                <asp:DropDownList CssClass="form-control" runat="server" ID="txtMeasureUnit">
                                                                                                    <asp:ListItem Text="Seleccionar--" />
                                                                                                    <asp:ListItem Text="..." />
                                                                                                    <asp:ListItem Text="..." />
                                                                                                </asp:DropDownList>
                                                                                            </div>
                                                                                            <asp:RequiredFieldValidator Font-Size="10" ForeColor="Red" runat="server" ID="RequiredFieldValidator1" ValidationGroup="DetailsGroup" ControlToValidate="txtMeasureUnit">
                                                                                                <div class="ctrlvalidate">
                                                                                                    <div style="color: #fff">
                                                                                                        Campo requerido  
                                                                                                     </div>
                                                                                                    <div class="fas fa-sort-down position-absolute"></div>
                                                                                                </div>                                                      
                                                                                            </asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="col-lg-6">
                                                                                        <label style="float: left; margin-left: 5px;">Nombre</label>
                                                                                        <div class="input-group">
                                                                                            <input runat="server" type="text" name="Type" id="txtLastNameUMeasures" class="form-control" />
                                                                                            <asp:RequiredFieldValidator Font-Size="10" ForeColor="Red" runat="server" ID="RequiredFieldValidator2" ValidationGroup="DetailsGroup" ControlToValidate="txtLastNameUMeasures">
                                                                                                <div class="ctrlvalidate">
                                                                                                    <div style="color: #fff">
                                                                                                        Campo requerido  
                                                                                                     </div>
                                                                                                    <div class="fas fa-sort-down position-absolute"></div>
                                                                                                </div>                                                      
                                                                                            </asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="col-lg-2">
                                                                                        <label style="float: left; margin-left: 5px;">Abreviación</label>
                                                                                        <div class="input-group">
                                                                                            <input runat="server" type="text" name="Type" id="txtAbreviation" class="form-control" />
                                                                                            <asp:RequiredFieldValidator Font-Size="10" ForeColor="Red" runat="server" ID="RequiredFieldValidator3" ValidationGroup="DetailsGroup" ControlToValidate="txtAbreviation">
                                                                                                <div class="ctrlvalidate">
                                                                                                    <div style="color: #fff">
                                                                                                        Campo requerido  
                                                                                                     </div>
                                                                                                    <div class="fas fa-sort-down position-absolute"></div>
                                                                                                </div>                                                      
                                                                                            </asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="col-lg-12">
                                                                                        <div class="form-group">
                                                                                            <label for="Address">Descripción</label>
                                                                                            <div class="input-group">
                                                                                                <textarea style="max-height: 100px; min-height: 50px" class="form-control" id="Address" rows="3"></textarea>
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
                                                    </div>
                                                    <div class="card-footer">
                                                        <div class="row justify-content-center">
                                                            <div class="col-lg-2 p-1">
                                                                <asp:Button ValidationGroup="DetailsGroup" runat="server" Text="Agregar" CssClass="btn btn-success btn-block" />
                                                            </div>
                                                            <div class="col-lg-2 p-1">
                                                                <asp:Button runat="server" Text="Cancelar" CssClass="btn btn-warning btn-block" />
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
                            <div class="tab-pane fade show active" id="list-content" role="tabpanel" aria-labelledby="list-tab">
                                <asp:UpdatePanel runat="server" ID="UpdatePanelList">
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
                                                                                <asp:TextBox runat="server" ID="txtSearchInvoiceRecords" CssClass="form-control" placeholder="Buscar..." />
                                                                            </div>
                                                                            <div class="form-group col-lg-3">
                                                                                <asp:Label Text="Fecha Inicio" runat="server" />
                                                                                <asp:TextBox runat="server" CssClass="form-control" ID="PickerStartDateFilter" TextMode="Date" />
                                                                            </div>
                                                                            <div class="form-group col-lg-3">
                                                                                <asp:Label Text="Fecha Final" runat="server" />
                                                                                <asp:TextBox runat="server" CssClass="form-control" ID="PickerEndDateFilter" TextMode="Date" />
                                                                            </div>
                                                                            <div class="form-group col-lg-2">
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
                                                                        <asp:GridView runat="server" DataKeyNames="Code" AutoGenerateColumns="false"
                                                                            ID="GridViewCategories" CssClass="table table-hover" CellPadding="5">
                                                                            <HeaderStyle CssClass="thead-dark" />
                                                                            <Columns>
                                                                                <asp:BoundField HeaderText="ID" />
                                                                                <asp:BoundField HeaderText="Tipo de Unidad" />
                                                                                <asp:BoundField HeaderText="Nombre" />
                                                                                <asp:BoundField HeaderText="Codigo" />
                                                                                <asp:BoundField HeaderText="Descripción" />
                                                                                <asp:BoundField HeaderText="Unidad Base" />
                                                                                <asp:BoundField HeaderText="Creado en" />
                                                                                <asp:BoundField HeaderText="Actualizado en" />
                                                                                <asp:BoundField HeaderText="Eliminado" />
                                                                                <asp:TemplateField HeaderText="Opciones">
                                                                                    <ItemTemplate>
                                                                                        <asp:Button Text="Editar" runat="server" CssClass="btn btn-primary" />
                                                                                        <asp:Button Text="Eliminar" runat="server" CssClass="btn btn-danger" />
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
