<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="AgregarCliente.aspx.cs" Inherits="Administracion_web.AgregarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .cliente-box {
            border: 1px solid #ccc;
            padding: 20px;
            margin: 20px auto;
            width: 400px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            border-radius: 10px;
        }

        .cliente-box h2 {
            background-color: white;
            color: black;
            padding: 10px;
            margin: -20px -20px 20px -20px; 
            border-radius: 10px 10px 0 0;  
            text-align: center;
        }

        .cliente-box .btn-primary {
            background-color: #007bff;
            border: none;
            width: 100%;
            padding: 10px;
            color: white;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
        }

        .cliente-box .btn-primary:hover {
            background-color: #0056b3;
        }

        .cliente-box .form-control {
            width: 100%;
            padding: 10px;
            border-radius: 5px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
        }

        .cliente-box {
            display: flex;
            flex-direction: column;
            align-items: center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align:center;"></h1>

    <div class="cliente-box">
        <h2>Formulario de Cliente</h2>
        
        <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control" placeholder="Documento" OnTextChanged="txtDocumento_TextChanged" AutoPostBack="true"></asp:TextBox>
        
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre" ></asp:TextBox>
        
        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Apellido"></asp:TextBox>
        
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
        
        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" placeholder="Dirección"></asp:TextBox>
        
        <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" placeholder="Ciudad"></asp:TextBox>
        
        <asp:TextBox ID="txtCP" runat="server" CssClass="form-control" placeholder="Código Postal"></asp:TextBox>

        <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Participar!" OnClick="btnGuardar_Click" />
        
        <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
    </div>

</asp:Content>

