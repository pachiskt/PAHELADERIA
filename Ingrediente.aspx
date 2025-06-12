<%@ Page Title="Gestión de Ingredientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ingrediente.aspx.cs" Inherits="Heladeria_CRUD.Ingrediente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        /* Estilos generales */
        .ingrediente-container {
            font-family: 'Poppins', sans-serif;
            max-width: 1200px;
            margin: 0 auto;
            padding: 30px;
            background-color: rgba(255, 255, 255, 0.9);
            border-radius: 15px;
            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
        }

        .ingrediente-title {
            color: #4A8BDF;
            font-size: 1.8rem;
            text-align: center;
            margin-bottom: 30px;
            font-weight: 700;
        }

        /* Sección de búsqueda */
        .search-section {
            background-color: #F0F8FF;
            padding: 20px;
            border-radius: 12px;
            margin-bottom: 30px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.05);
        }

        .input-group {
            display: flex;
            align-items: center;
            margin-bottom: 15px;
        }

        .input-group label {
            width: 150px;
            color: #4A8BDF;
            font-weight: 600;
        }

        /* Inputs redondeados */
        .rounded-input {
            border-radius: 20px;
            border: 2px solid #A5C7FF;
            padding: 10px 15px;
            font-family: 'Poppins', sans-serif;
            width: 100%;
            max-width: 300px;
            transition: all 0.3s;
        }

        .rounded-input:focus {
            border-color: #4A8BDF;
            box-shadow: 0 0 8px rgba(74, 139, 223, 0.3);
            outline: none;
        }

        /* Grupo de botones */
        .button-group {
            display: flex;
            gap: 15px;
            flex-wrap: wrap;
            margin-top: 20px;
        }

        /* Botones redondeados */
        .rounded-button {
            border-radius: 20px;
            border: none;
            padding: 10px 25px;
            font-family: 'Poppins', sans-serif;
            font-weight: 600;
            cursor: pointer;
            transition: all 0.3s;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
        }

        .primary-button {
            background-color: #4A8BDF;
            color: white;
        }

        .secondary-button {
            background-color: #A5C7FF;
            color: white;
        }

        .danger-button {
            background-color: #ff6b6b;
            color: white;
        }

        .rounded-button:hover {
            transform: translateY(-2px);
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.15);
        }

        .primary-button:hover {
            background-color: #3A7BC8;
        }

        .secondary-button:hover {
            background-color: #8FB6FF;
        }

        .danger-button:hover {
            background-color: #e05a5a;
        }

        /* Mensajes */
        .message-label {
            display: block;
            margin-top: 15px;
            color: #4A8BDF;
            font-weight: 500;
        }

        /* GridView estilizado */
        .grid-container {
            overflow-x: auto;
            margin-top: 20px;
        }

        .styled-gridview {
            width: 100%;
            border-collapse: separate;
            border-spacing: 0;
            border-radius: 12px;
            overflow: hidden;
            box-shadow: 0 4px 15px rgba(0, 0, 0, 0.08);
        }

        .grid-header {
            background-color: #4A8BDF !important;
            color: white !important;
            padding: 12px 15px !important;
            text-align: left;
            font-weight: 600;
        }

        .grid-row, .grid-alternating-row {
            padding: 10px 15px !important;
            border-bottom: 1px solid #D1E3FF;
        }

        .grid-row {
            background-color: white;
        }

        .grid-alternating-row {
            background-color: #F0F8FF;
        }

        .styled-gridview tr:hover {
            background-color: #D1E3FF !important;
            cursor: pointer;
        }

        /* Secciones */
        .section {
            background-color: #F0F8FF;
            padding: 20px;
            border-radius: 12px;
            margin-bottom: 30px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.05);
        }

        /* Responsive */
        @media (max-width: 768px) {
            .input-group {
                flex-direction: column;
                align-items: flex-start;
            }
            
            .input-group label {
                width: 100%;
                margin-bottom: 5px;
            }
            
            .rounded-input {
                width: 100%;
                max-width: 100%;
            }
            
            .button-group {
                flex-direction: column;
            }
            
            .rounded-button {
                width: 100%;
            }
        }
    </style>

    <div class="ingrediente-container">
        <h1 class="ingrediente-title">Gestión de Ingredientes</h1>
        
        <!-- Sección de Listado -->
        <div class="section">
            <h3>Listado de Ingredientes</h3>
            <div class="button-group">
                <asp:Button ID="btnListar" runat="server" Text="Listar Ingredientes" OnClick="btnListar_Click" CssClass="rounded-button primary-button" />
            </div>
        </div>
        
        <!-- Sección de Agregar/Actualizar -->
        <div class="section">
            <h3>Agregar / Actualizar Ingrediente</h3>
            <asp:Label ID="lblMensaje" runat="server" CssClass="message-label" />
            
            <div class="input-group">
                <label for="txtId">ID:</label>
                <asp:TextBox ID="txtId" runat="server" CssClass="rounded-input" />
            </div>
            
            <div class="input-group">
                <label for="txtNombre">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="rounded-input" />
            </div>
            
            <div class="input-group">
                <label for="txtProveedorId">Proveedor ID:</label>
                <asp:TextBox ID="txtProveedorId" runat="server" CssClass="rounded-input" />
            </div>
            
            <div class="input-group">
                <label for="txtHeladoId">Helado ID:</label>
                <asp:TextBox ID="txtHeladoId" runat="server" CssClass="rounded-input" />
            </div>
            
            <div class="input-group">
                <label for="txtUnidadMedida">Unidad de Medida:</label>
                <asp:TextBox ID="txtUnidadMedida" runat="server" CssClass="rounded-input" />
            </div>
            
            <div class="input-group">
                <label for="txtPrecioUnidad">Precio por Unidad:</label>
                <asp:TextBox ID="txtPrecioUnidad" runat="server" CssClass="rounded-input" />
            </div>
            
            <div class="input-group">
                <label for="txtDescripcion">Descripción:</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="rounded-input" TextMode="MultiLine" Rows="3" />
            </div>
            
            <div class="button-group">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar Ingrediente" OnClick="btnAgregar_Click" CssClass="rounded-button primary-button" />
                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar Ingrediente" OnClick="btnActualizar_Click" CssClass="rounded-button secondary-button" />
            </div>
        </div>
        
        <!-- Sección de Búsqueda -->
        <div class="section">
            <h3>Buscar Ingrediente</h3>
            
            <div class="input-group">
                <label for="ddlCriterio">Criterio:</label>
                <asp:DropDownList ID="ddlCriterio" runat="server" CssClass="rounded-input">
                    <asp:ListItem Value="id">ID</asp:ListItem>
                    <asp:ListItem Value="nombre">Nombre</asp:ListItem>
                    <asp:ListItem Value="proveedor">Proveedor</asp:ListItem>
                    <asp:ListItem Value="helado">Helado</asp:ListItem>
                </asp:DropDownList>
            </div>
            
            <div class="input-group">
                <label for="txtBuscar">Texto:</label>
                <asp:TextBox ID="txtBuscar" runat="server" CssClass="rounded-input" />
            </div>
            
            <div class="button-group">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="rounded-button primary-button" />
                <asp:Button ID="btnListarTodo" runat="server" Text="Listar Todo" OnClick="btnListar_Click" CssClass="rounded-button secondary-button" />
            </div>
        </div>
        
        <!-- Sección de Eliminar -->
        <div class="section">
            <h3>Eliminar Ingrediente</h3>
            <asp:Label ID="lblMensaje1" runat="server" CssClass="message-label" />
            
            <div class="input-group">
                <label for="txtEliminar">ID:</label>
                <asp:TextBox ID="txtEliminar" runat="server" CssClass="rounded-input" />
            </div>
            
            <div class="button-group">
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CssClass="rounded-button danger-button" />
            </div>
        </div>
        
        <!-- GridView para mostrar resultados -->
        <div class="grid-container">
            <asp:GridView ID="gvIngredientes" runat="server" AutoGenerateColumns="true" 
                Visible="false" CssClass="styled-gridview">
                <HeaderStyle CssClass="grid-header" />
                <RowStyle CssClass="grid-row" />
                <AlternatingRowStyle CssClass="grid-alternating-row" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>