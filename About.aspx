<%@ Page Title="Acerca del Sistema" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Heladeria_CRUD.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        /* About Page Styles */
        .about-container {
            max-width: 1000px;
            margin: 0 auto;
            padding: 20px;
            font-family: 'Poppins', sans-serif;
            background-color: rgba(255, 255, 255, 0.9);
            border-radius: 15px;
            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
        }

        .about-title {
            color: #4A8BDF;
            text-align: center;
            margin-bottom: 30px;
            font-size: 1.8rem;
            font-weight: 700;
        }

        .about-section {
            background-color: #F0F8FF;
            padding: 20px;
            border-radius: 12px;
            margin-bottom: 20px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.05);
        }

        .about-description {
            line-height: 1.6;
            color: #333;
        }

        .about-features {
            padding-left: 20px;
        }

        .about-features li {
            margin-bottom: 10px;
        }

        .tech-badges {
            display: flex;
            flex-wrap: wrap;
            gap: 10px;
        }

        .badge {
            background-color: #4A8BDF;
            color: white;
            padding: 5px 15px;
            border-radius: 20px;
            font-size: 0.9rem;
            font-weight: 600;
        }

        .about-footer {
            text-align: center;
            margin-top: 40px;
            color: #666;
            font-size: 0.9rem;
        }
        
        /* Responsive */
        @media (max-width: 768px) {
            .about-container {
                padding: 15px;
            }
            
            .about-title {
                font-size: 1.5rem;
            }
            
            .tech-badges {
                justify-content: center;
            }
        }
    </style>

    <div class="about-container">
        <h1 class="about-title"><%: Title %></h1>
        
        <div class="about-section">
            <h3>Sistema de Gestión para Heladería Amorino</h3>
            <p class="about-description">
                Este sistema es una aplicación web CRUD (Create, Read, Update, Delete) desarrollada para la gestión integral 
                de una heladería, utilizando procedimientos almacenados en SQL Server para todas las operaciones de base de datos.
                La arquitectura sigue el patrón de diseño tradicional con lógica de negocio implementada en procedimientos almacenados.
            </p>
        </div>
        
        <div class="about-section">
            <h3>Características principales:</h3>
            <ul class="about-features">
                <li><strong>Gestión completa:</strong> Clientes, productos, promociones, ingredientes y pedidos</li>
                <li><strong>Operaciones CRUD:</strong> Mediante procedimientos almacenados (SPs) en SQL Server</li>
                <li><strong>Validaciones:</strong> Reglas de negocio implementadas directamente en la base de datos</li>
                <li><strong>Búsquedas avanzadas:</strong> Múltiples criterios de filtrado para cada módulo</li>
                <li><strong>Seguridad:</strong> Validación de datos tanto en frontend como en backend</li>
            </ul>
        </div>
        
        <div class="about-section">
            <h3>Tecnologías utilizadas:</h3>
            <div class="tech-badges">
                <span class="badge">ASP.NET Web Forms</span>
                <span class="badge">C#</span>
                <span class="badge">SQL Server</span>
                <span class="badge">Stored Procedures</span>
                <span class="badge">ADO.NET</span>
                <span class="badge">HTML5</span>
                <span class="badge">CSS3</span>
                <span class="badge">JavaScript</span>
            </div>
        </div>
        
        <div class="about-footer">
            <p>© 2025 - Heladería Amorino - Todos los derechos reservados</p>
            <p>Sistema desarrollado con procedimientos almacenados para garantizar integridad y seguridad de los datos</p>
        </div>
    </div>
</asp:Content>

