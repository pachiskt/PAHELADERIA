<%@ Page Title="Gestión de Toppings" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Topping.aspx.cs" Inherits="Heladeria_CRUD.Topping1" %>

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

        /* Sección de búsqueda */
        .search-section {
            background-color: #FFF5F7;
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
            width: 124px;
            color: #D35D6E;
            font-weight: 600;
        }

        /* Inputs redondeados */
        .rounded-input {
            border-radius: 20px;
            border: 2px solid #FFB6C1;
            padding: 10px 15px;
            font-family: 'Poppins', sans-serif;
            width: 100%;
            max-width: 300px;
            transition: all 0.3s;
        }

        .rounded-input:focus {
            border-color: #D35D6E;
            box-shadow: 0 0 8px rgba(211, 93, 110, 0.3);
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
        
        .third-button {
            background-color: #FFB6C1;
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
            margin-top: 15px;
            color: #D35D6E;
            font-weight: 500;
        }

        /* GridView estilizado */
        .grid-container {
            overflow-x: auto;
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

        /* Checkbox personalizado */
        .custom-checkbox {
            position: relative;
            padding-left: 30px;
            cursor: pointer;
            display: inline-block;
        }
        
        .custom-checkbox input {
            position: absolute;
            opacity: 0;
            cursor: pointer;
        }
        
        .checkmark {
            position: absolute;
            top: 0;
            left: 0;
            height: 20px;
            width: 20px;
            background-color: #fff;
            border: 2px solid #FFB6C1;
            border-radius: 5px;
        }
        
        .custom-checkbox:hover input ~ .checkmark {
            background-color: #FFD1DC;
        }
        
        .custom-checkbox input:checked ~ .checkmark {
            background-color: #D35D6E;
            border-color: #D35D6E;
        }
        
        .checkmark:after {
            content: "";
            position: absolute;
            display: none;
        }
        
        .custom-checkbox input:checked ~ .checkmark:after {
            display: block;
        }
        
        .custom-checkbox .checkmark:after {
            left: 6px;
            top: 2px;
            width: 5px;
            height: 10px;
            border: solid white;
            border-width: 0 2px 2px 0;
            transform: rotate(45deg);
        }

        /* Responsive */
        @media (max-width: 768px) {
            .input-group label {
                width: 100%;
                margin-bottom: 5px;
            }
            
            .rounded-input {
                width: 100%;
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
        <h1 class="cliente-title">Gestión de Toppings</h1>
        
        <!-- Sección de Listado -->
        <div class="section">
            <h3>Listado de Toppings</h3>
            <div class="button-group">
                <asp:Button ID="btnListar" runat="server" Text="Listar Toppings" OnClick="btnListar_Click" CssClass="rounded-button primary-button" />
            </div>
        </div>
        
        <!-- Sección de Agregar/Actualizar -->
        <div class="section">
            <h3>Agregar / Actualizar Topping</h3>
            <asp:Label ID="lblMensaje" runat="server" CssClass="message-label" />
            
            <div class="input-group">
                <label for="txtId">ID Topping:</label>
                <asp:TextBox ID="txtId" runat="server" CssClass="rounded-input" />
            </div>
            
            <div class="input-group">
                <label for="txtNombre">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="rounded-input" />
            </div>
            
            <div class="input-group">
                <label for="txtPrecio">Precio:</label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="rounded-input" />
            </div>
            
            <div class="input-group">
                <label for="txtStock">Stock:</label>
                <asp:TextBox ID="txtStock" runat="server" CssClass="rounded-input" />
            </div>
            
            <div class="input-group">
                <label for="chkActivo">Activo:</label>
                <label class="custom-checkbox">
                    <asp:CheckBox ID="chkActivo" runat="server" />
                    <span class="checkmark"></span>
                </label>
            </div>
            
            <div class="button-group">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar Topping" OnClick="btnAgregar_Click" CssClass="rounded-button primary-button" />
                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar Topping" OnClick="btnActualizar_Click" CssClass="rounded-button secondary-button" />
            </div>
        </div>
        
        <!-- Sección de Búsqueda -->
        <div class="section">
            <h3>Buscar Topping</h3>
            
            <div class="input-group">
                <label for="ddlCriterio">Criterio:</label>
                <asp:DropDownList ID="ddlCriterio" runat="server" CssClass="rounded-input">
                    <asp:ListItem Value="topping_id" Text="ID" />
                    <asp:ListItem Value="nombre" Text="Nombre" />
                    <asp:ListItem Value="activo" Text="¿Activo?" />
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
            <h3>Eliminar Topping</h3>
            <asp:Label ID="lblMensajeEliminar" runat="server" CssClass="message-label" />
            
            <div class="input-group">
                <label for="txtEliminar">ID Topping:</label>
                <asp:TextBox ID="txtEliminar" runat="server" CssClass="rounded-input" />
            </div>
            
            <div class="button-group">
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Topping" OnClick="btnEliminar_Click" CssClass="rounded-button danger-button" />
            </div>
        </div>
        
        <!-- GridView para mostrar resultados -->
        <div class="grid-container">
            <asp:GridView ID="gvToppings" runat="server" AutoGenerateColumns="true" 
                Visible="false" OnSelectedIndexChanged="gvToppings_SelectedIndexChanged" 
                CssClass="styled-gridview">
                <HeaderStyle CssClass="grid-header" />
                <RowStyle CssClass="grid-row" />
                <AlternatingRowStyle CssClass="grid-alternating-row" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>