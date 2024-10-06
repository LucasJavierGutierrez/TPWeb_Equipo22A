<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administracion_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
        .card-img-top {
            height: 300px; 
            width: 100%; 
            object-fit: cover; 
        }

        .card-body {
            height: 200px; 
            display: flex;
            flex-direction: column;
            justify-content: space-between;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <h1></h1>


 <div class="row">


    <% foreach (dominio.Articulo item in ListaArticulos) { %>
            <div class="col">
                <div class="card h-100">
                    
                    <div id="carousel<%= item.Id %>" class="carousel slide" data-bs-ride="carousel">
                        <div class="carousel-inner">
                            <% int imageIndex = 0; %>
                            <% foreach (string imagen in item.Imagenes.Select(img => img.ImagenUrl)) { %>
                                <div class="carousel-item <%= imageIndex == 0 ? "active" : "" %>">
                                    <img src="<%= imagen %>" class="d-block w-100 card-img-top" alt="..." onerror="this.src='https://assets.cdn-shop.com/mi-arte3-es/assets/img/backgrounds/placeholder-8b83e412a5.svg';">
                                </div>
                                <% imageIndex++; %>
                            <% } %>
                        </div>
             
                      
                        <button class="carousel-control-prev" type="button" data-bs-target="#carousel<%= item.Id %>" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Anterior</span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#carousel<%= item.Id %>" data-bs-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Siguiente</span>
                        </button>
                    </div>

   
                    <div class="card-body">
                        <h5 class="card-title"><%= item.Nombre %></h5>
                        <p class="card-text"><%= item.Descripcion %></p>
                   
                    <%--   <a href="AgregarCliente.aspx?id=<%= item.Id %>" class="btn btn-primary">QUIERO ESTE !</a>--%>
                        <a href="AgregarCliente.aspx?id=<%= item.Id %>&voucherId=<%= Request.QueryString["voucherId"] %>" class="btn btn-primary">QUIERO ESTE !</a>
                    </div>
         </div>
       </div>


 <%} %>
 </div>
</asp:Content>
