﻿<%@ Page Title="Categorías de Helado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoriaHelado.aspx.cs" Inherits="Heladeria_CRUD.CategoriaHelado" %>

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
        <h1 class="cliente-title">Categorías de Helado</h1>
        
        <!-- Sección de Listado -->
        <div class="section">
            <h3>Listado de Categorías</h3>
            <div class="button-group">
                <asp:Button ID="btnListarTodo" runat="server" Text="Listar Todo" OnClick="btnListarTodo_Click" CssClass="rounded-button primary-button" />
            </div>
        </div>
        
        <!-- Sección de Agregar/Actualizar -->
        <div class="section">
            <h3>Agregar / Actualizar Categoría</h3>
            <asp:Label ID="lblMensaje" runat="server" CssClass="message-label" />
            
            <div class="input-group">
                <label for="txtId">ID Categoría:</label>
                <asp:TextBox ID="txtId" runat="server" CssClass="rounded-input" OnTextChanged="txtId_TextChanged" />
            </div>
            
            <div class="input-group">
                <label for="txtNombre">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="rounded-input" OnTextChanged="txtNombre_TextChanged" />
            </div>
            
            <div class="input-group">
                <label for="txtDescripcion">Descripción:</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="rounded-input" OnTextChanged="txtDescripcion_TextChanged" />
            </div>
            
            <div class="button-group">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar Categoría" OnClick="btnAgregar_Click" CssClass="rounded-button primary-button" />
                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar Categoría" OnClick="btnActualizar_Click" CssClass="rounded-button secondary-button" />
            </div>
        </div>
        
        <!-- Sección de Búsqueda -->
        <div class="section">
            <h3>Buscar Categoría</h3>
            
            <div class="input-group">
                <label for="ddlCriterio">Criterio:</label>
                <asp:DropDownList ID="ddlCriterio" runat="server" CssClass="rounded-input" OnSelectedIndexChanged="ddlCriterio_SelectedIndexChanged">
                    <asp:ListItem Value="categoria_id" Text="ID" />
                    <asp:ListItem Value="nombre" Text="Nombre" />
                    <asp:ListItem Value="descripcion" Text="Descripción" />
                </asp:DropDownList>
            </div>
            
            <div class="input-group">
                <label for="txtBuscar">Texto:</label>
                <asp:TextBox ID="txtBuscar" runat="server" CssClass="rounded-input" OnTextChanged="txtBuscar_TextChanged" />
            </div>
            
            <div class="button-group">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="rounded-button primary-button" />
                <asp:Button ID="Button1" runat="server" Text="Listar Todo" OnClick="btnListarTodo_Click" CssClass="rounded-button secondary-button" />
            </div>
        </div>
        
        <!-- Sección de Eliminar -->
        <div class="section">
            <h3>Eliminar Categoría</h3>
            <asp:Label ID="lblMensaje1" runat="server" CssClass="message-label" />
            
            <div class="input-group">
                <label for="txtIdEliminar">ID Categoría:</label>
                <asp:TextBox ID="txtIdEliminar" runat="server" CssClass="rounded-input" OnTextChanged="txtIdEliminar_TextChanged" />
            </div>
            
            <div class="button-group">
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CssClass="rounded-button danger-button" />
            </div>
        </div>
        
        <!-- GridView para mostrar resultados -->
        <div class="grid-container">
            <asp:GridView ID="gvCRUD" runat="server" AutoGenerateColumns="true" OnSelectedIndexChanged="gvCRUC_SelectedIndexChanged" 
                Visible="false" CssClass="styled-gridview">
                <HeaderStyle CssClass="grid-header" />
                <RowStyle CssClass="grid-row" />
                <AlternatingRowStyle CssClass="grid-alternating-row" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>