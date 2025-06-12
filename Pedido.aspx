<%@ Page Title="Gestión de Pedidos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pedido.aspx.cs" Inherits="Heladeria_CRUD.Pedido1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        /* Estilos generales */
        .cliente-container {
            font-family: 'Poppins', sans-serif;
            max-width: 1200px;
            margin: 0 auto;
            padding: 30px;
            background-color: rgba(255, 255, 255, 0.9);
            border-radius: 15px;
            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
        }

        .cliente-title {
            color: #D35D6E;
            font-size: 1.8rem;
            text-align: center;
            margin-bottom: 30px;
            font-weight: 700;
        }

        /* Inputs redondeados */
        .rounded-input {
            border-radius: 20px;
            border: 2px solid #FFB6C1;
            padding: 10px 15px;
            font-family: 'Poppins', sans-serif;
            width: 100%;
            transition: all 0.3s;
        }

        .rounded-textarea {
            border-radius: 15px;
            border: 2px solid #FFB6C1;
            padding: 10px 15px;
            font-family: 'Poppins', sans-serif;
            width: 100%;
            min-height: 80px;
            transition: all 0.3s;
        }

        .rounded-input:focus, .rounded-textarea:focus {
            border-color: #D35D6E;
            box-shadow: 0 0 8px rgba(211, 93, 110, 0.3);
            outline: none;
        }

        /* Grupo de botones */
        .button-group {
            display: flex;
            gap: 15px;
            flex-wrap: wrap;
            margin: 20px 0;
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
            background-color: #D35D6E;
            color: white;
        }

        .secondary-button {
            background-color: #FFB6C1;
            color: white;
        }

        .danger-button {
            background-color: #ff6b6b;
            color: white;
        }
        
        .info-button {
            background-color: #6b8cff;
            color: white;
        }
        
        .rounded-button:hover {
            transform: translateY(-2px);
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.15);
        }

        .primary-button:hover {
            background-color: #b84d5c;
        }

        .secondary-button:hover {
            background-color: #e8a1ad;
        }

        .danger-button:hover {
            background-color: #e05a5a;
        }

        /* Mensajes */
        .message-label {
            display: block;
            margin: 15px 0;
            color: #D35D6E;
            font-weight: 500;
            text-align: center;
        }

        /* GridView estilizado */
        .grid-container {
            overflow-x: auto;
            margin-top: 30px;
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
            background-color: #D35D6E !important;
            color: white !important;
            padding: 12px 15px !important;
            text-align: left;
            font-weight: 600;
        }

        .grid-row, .grid-alternating-row {
            padding: 10px 15px !important;
            border-bottom: 1px solid #FFD1DC;
        }

        .grid-row {
            background-color: white;
        }

        .grid-alternating-row {
            background-color: #FFF5F7;
        }

        .styled-gridview tr:hover {
            background-color: #FFD1DC !important;
            cursor: pointer;
        }

        /* Secciones */
        .section {
            background-color: #FFF5F7;
            padding: 20px;
            border-radius: 12px;
            margin-bottom: 30px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.05);
        }

        /* Formulario de pedido */
        .pedido-form {
            display: grid;
            grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
            gap: 15px;
        }

        .form-group {
            margin-bottom: 15px;
        }

        .form-group label {
            display: block;
            margin-bottom: 5px;
            color: #D35D6E;
            font-weight: 600;
        }

        /* Dropdown estilizado */
        .styled-dropdown {
            border-radius: 20px;
            border: 2px solid #FFB6C1;
            padding: 8px 15px;
            font-family: 'Poppins', sans-serif;
            width: 100%;
            background-color: white;
            transition: all 0.3s;
        }

        .styled-dropdown:focus {
            border-color: #D35D6E;
            box-shadow: 0 0 8px rgba(211, 93, 110, 0.3);
            outline: none;
        }

        /* Búsqueda */
        .search-container {
            display: flex;
            gap: 10px;
            align-items: center;
            flex-wrap: wrap;
        }

        /* Responsive */
        @media (max-width: 768px) {
            .pedido-form {
                grid-template-columns: 1fr;
            }
            
            .search-container {
                flex-direction: column;
                align-items: stretch;
            }
            
            .button-group {
                flex-direction: column;
            }
            
            .rounded-button {
                width: 100%;
            }
        }
    </style>

    <div class="cliente-container">
        <h1 class="cliente-title">Gestión de Pedidos</h1>
        
        <!-- Sección de Formulario -->
        <div class="section">
            <div class="pedido-form">
                <div class="form-group">
                    <label for="txtPedidoID">ID Pedido:</label>
                    <asp:TextBox ID="txtPedidoID" runat="server" CssClass="rounded-input" />
                </div>
                
                <div class="form-group">
                    <label for="txtClienteID">Cliente ID (DNI):</label>
                    <asp:TextBox ID="txtClienteID" runat="server" CssClass="rounded-input" />
                </div>
                
                <div class="form-group">
                    <label for="txtEmpleadoID">Empleado ID:</label>
                    <asp:TextBox ID="txtEmpleadoID" runat="server" CssClass="rounded-input" />
                </div>
                
                <div class="form-group">
                    <label for="txtFechaPedido">Fecha Pedido:</label>
                    <asp:TextBox ID="txtFechaPedido" runat="server" CssClass="rounded-input" />
                </div>
                
                <div class="form-group">
                    <label for="ddlMetodoPago">Método Pago:</label>
                    <asp:DropDownList ID="ddlMetodoPago" runat="server" CssClass="styled-dropdown" />
                </div>
                
                <div class="form-group">
                    <label for="txtTotal">Total:</label>
                    <asp:TextBox ID="txtTotal" runat="server" CssClass="rounded-input" />
                </div>
                
                <div class="form-group">
                    <label for="txtEstado">Estado:</label>
                    <asp:TextBox ID="txtEstado" runat="server" CssClass="rounded-input" />
                </div>
                
                <div class="form-group">
                    <label for="txtObservaciones">Observaciones:</label>
                    <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" CssClass="rounded-textarea" />
                </div>
            </div>
            
            <div class="button-group">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CssClass="rounded-button primary-button" />
                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" CssClass="rounded-button secondary-button" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CssClass="rounded-button danger-button" />
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" CssClass="rounded-button info-button" />
            </div>
            
            <asp:Label ID="lblMensaje" runat="server" CssClass="message-label" />
        </div>
        
        <!-- Sección de Búsqueda -->
        <div class="section">
            <h3>Búsqueda de Pedidos</h3>
            
            <div class="search-container">
                <asp:DropDownList ID="ddlCriterio" runat="server" CssClass="styled-dropdown">
                    <asp:ListItem Text="ID" Value="id" />
                    <asp:ListItem Text="Cliente" Value="cliente" />
                    <asp:ListItem Text="Empleado" Value="empleado" />
                    <asp:ListItem Text="Fecha" Value="fecha" />
                    <asp:ListItem Text="Estado" Value="estado" />
                </asp:DropDownList>
                
                <asp:TextBox ID="txtBuscar" runat="server" CssClass="rounded-input" />
                
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="rounded-button primary-button" />
            </div>
        </div>
        
        <!-- GridView para mostrar resultados -->
        <div class="grid-container">
            <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="true"
                AutoGenerateSelectButton="true"
                OnSelectedIndexChanged="gvPedidos_SelectedIndexChanged"
                CssClass="styled-gridview">
                <HeaderStyle CssClass="grid-header" />
                <RowStyle CssClass="grid-row" />
                <AlternatingRowStyle CssClass="grid-alternating-row" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>