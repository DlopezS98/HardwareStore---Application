<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrationIndex.aspx.cs" Inherits="HardwareStore.Modules.ProductsAdmin.AdministrationIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:MultiView ID="SalesView" ActiveViewIndex="0" runat="server">
        <asp:View runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                <ContentTemplate>
                    <h3 style="color: #1F2126; text-align: center; margin-top: 20px">Existencias Productos</h3>
                    <div class="container mt-5">
                        <div class="row d-flex justify-content-center">
                            <div class="mx-3">
                                <div class="card shadow bg-white rounded" style="width: 18rem;">
                                    <div class="d-flex justify-content-center mt-2">
                                        <img style="height: 200px; width: 170px" runat="server" src="~/Images/img1.png" class="card-img-top" alt="...">
                                    </div>
                                    <div class="card-body">

                                        <h5 class="card-title">Existencias en bodegas</h5>
                                        <p class="card-text">Gestiona Movimientos de Productos</p>
                                        <asp:Button CssClass="btn btn-primary" runat="server" Text="Ver" ID="btnProductWarehouse" OnClick="btnProductWarehouse_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="mx-3">
                                <div class="card shadow bg-white rounded" style="width: 18rem;">
                                    <div class="d-flex justify-content-center mt-2">
                                        <img style="height: 200px; width: 170px" runat="server" src="~/Images/img3.png" class="card-img-top" alt="...">
                                    </div>
                                    <div class="card-body">
                                        <h5 class="card-title">Transferencias</h5>
                                        <p class="card-text">Historial de Movimientos de Productos</p>
                                        <div style="margin-top: 15px">
                                            <asp:Button CssClass="btn btn-primary" runat="server" Text="Ver" ID="btntransferencies" OnClick="btntransferencies_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="mx-3">
                                <div class="card shadow bg-white rounded" style="width: 18rem;">
                                    <div class="d-flex justify-content-center mt-2">
                                        <img style="height: 200px; width: 170px" runat="server" src="~/Images/devoluciones.png" class="card-img-top mt-4" alt="...">
                                    </div>
                                    <div class="card-body">
                                        <h5 class="card-title">Productos dañados</h5>
                                        <p class="card-text">Historial de Productos dañados</p>
                                        <div style="margin-top: 15px">
                                            <asp:Button CssClass="btn btn-primary" runat="server" Text="Ver" ID="btnDamage" OnClick="btnDamage_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:View>
    </asp:MultiView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
