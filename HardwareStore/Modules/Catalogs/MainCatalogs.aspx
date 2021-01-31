<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainCatalogs.aspx.cs" Inherits="HardwareStore.Modules.Catalogs.Module.MainCatalogs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="text-align: center; margin: 5px; margin-top: 35px">
        <h2>Administrador de Catálogos</h2>
    </div>
    <div style="margin-left: 0px" class="rowcardcss">
<%--        <div class="d-flex justify-content-center">
            <div class="col-md-7 col-lg-7 col-sm-6 col-xl-10 position-absolute">
                <div style="z-index: 10; width: 100%; margin-right: 50%" class="alert alert-danger mr-3" role="alert">
                    A simple danger alert—check it out!
                </div>
            </div>
        </div>--%>
        <div class="columncss">
            <div class="cardcss">
                <h5 class="mt-2">Productos</h5>
                <p>(50 items)</p>
                <div style="align-items: center">
                    <asp:Image Height="50px" Width="50px" ImageUrl="~/Images/product.png" runat="server" />
                </div>
                <div style="margin-top: 10px">
                    <a href="Products.aspx" class="btn btn-outline-primary">Administrar</a>
                </div>
            </div>
        </div>
        <div class="columncss">
            <div class="cardcss">
                <h5 class="mt-2">Categorías</h5>
                <p>(50 items)</p>
                <div style="align-items: center">
                    <asp:Image Height="50px" Width="50px" ImageUrl="~/Images/Categorias.png" runat="server" />
                </div>
                <div style="margin-top: 10px">
                    <a href="Categories.aspx" class="btn btn-outline-primary">Administrar</a>
                </div>
            </div>
        </div>
        <div class="columncss">
            <div class="cardcss">
                <h5 class="mt-2">Empleados</h5>
                <p>(50 items)</p>
                <div style="align-items: center">
                    <asp:Image Height="50px" Width="50px" ImageUrl="~/Images/Empleados.png" runat="server" />
                </div>
                <div style="margin-top: 10px">
                    <a href="Employees.aspx" class="btn btn-outline-primary">Administrar</a>
                </div>
            </div>
        </div>
        <div class="columncss">
            <div class="cardcss">
                <h5 class="mt-2">Marcas</h5>
                <p>(50 items)</p>
                <div style="align-items: center">
                    <asp:Image Height="50px" Width="50px" ImageUrl="~/Images/Marcas.png" runat="server" />
                </div>
                <div style="margin-top: 10px">
                    <a href="Brands.aspx" class="btn btn-outline-primary">Administrar</a>
                </div>
            </div>
        </div>
        <div class="columncss">
            <div class="cardcss">
                <h5 class="mt-2">Medidas</h5>
                <p>(50 items)</p>
                <div style="align-items: center">
                    <asp:Image Height="50px" Width="50px" ImageUrl="~/Images/UMedidas.png" runat="server" />
                </div>
                <div style="margin-top: 10px">
                    <a href="UnitMeasures.aspx" class="btn btn-outline-primary">Administrar</a>
                </div>
            </div>
        </div>
        <div class="columncss">
            <div class="cardcss">
                <h5 class="mt-2">Bodegas</h5>
                <p>(50 items)</p>
                <div style="align-items: center">
                    <asp:Image Height="50px" Width="50px" ImageUrl="~/Images/Bodegas.png" runat="server" />
                </div>
                <div style="margin-top: 10px">
                    <a href="Warehouses.aspx" class="btn btn-outline-primary">Administrar</a>
                </div>
            </div>
        </div>
        <div class="columncss">
            <div class="cardcss">
                <h5 class="mt-2">Clientes</h5>
                <p>(50 items)</p>
                <div style="align-items: center">
                    <asp:Image Height="50px" Width="50px" ImageUrl="~/Images/CatClientes.png" runat="server" />
                </div>
                <div style="margin-top: 10px">
                    <a href="Customers.aspx" class="btn btn-outline-primary">Administrar</a>
                </div>
            </div>
        </div>
        <div class="columncss">
            <div class="cardcss">
                <h5 class="mt-2">Proveedores</h5>
                <p>(50 items)</p>
                <div style="align-items: center">
                    <asp:Image Height="50px" Width="50px" ImageUrl="~/Images/Proveedores.png" runat="server" />
                </div>
                <div style="margin-top: 10px">
                    <a href="Suppliers.aspx" class="btn btn-outline-primary">Administrar</a>
                </div>
            </div>
        </div>
        <div class="columncss">
            <div class="cardcss">
                <h5 class="mt-2">Roles</h5>
                <p>(50 items)</p>
                <div style="align-items: center">
                    <asp:Image Height="50px" Width="50px" ImageUrl="~/Images/Roles.png" runat="server" />
                </div>
                <div style="margin-top: 10px">
                    <a href="Privileges.aspx" class="btn btn-outline-primary">Administrar</a>
                </div>
            </div>
        </div>
        <div class="columncss">
            <div class="cardcss">
                <h5 class="mt-2">Materiales</h5>
                <p>(50 items)</p>
                <div style="align-items: center">
                    <asp:Image Height="50px" Width="50px" ImageUrl="~/Images/Roles.png" runat="server" />
                </div>
                <div style="margin-top: 10px">
                    <a href="MaterialsTypes.aspx" class="btn btn-outline-primary">Administrar</a>
                </div>
            </div>
        </div>
        <div class="columncss">
            <div class="cardcss">
                <h5 class="mt-2">Conversión</h5>
                <p>(50 items)</p>
                <div style="align-items: center">
                    <asp:Image Height="50px" Width="50px" ImageUrl="~/Images/Roles.png" runat="server" />
                </div>
                <div style="margin-top: 10px">
                    <a href="MaterialsTypes.aspx" class="btn btn-outline-primary">Administrar</a>
                </div>
            </div>
        </div>
        <div class="columncss">
            <div class="cardcss">
                <h5 class="mt-2">Unidades</h5>
                <p>(50 items)</p>
                <div style="align-items: center">
                    <asp:Image Height="50px" Width="50px" ImageUrl="~/Images/Roles.png" runat="server" />
                </div>
                <div style="margin-top: 10px">
                    <a href="UnitTypes.aspx" class="btn btn-outline-primary">Administrar</a>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
