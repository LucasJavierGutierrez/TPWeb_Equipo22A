<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="Promo.aspx.cs" Inherits="Administracion_web.Promo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    
        .promo-box {
            border: 1px solid #ccc;
            padding: 20px;
            margin: 20px auto;
            width: 300px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            border-radius: 10px;
        }

        .promo-box h2 {
            background-color: #333;
            color: white;
            padding: 10px;
            margin: -20px -20px 20px -20px; 
            border-radius: 10px 10px 0 0;  
            text-align: center;
        }


        .promo-box .btn-primary {
            background-color: #007bff;
            border: none;
            width: 100%;
            padding: 10px;
            color: white;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
        }

 
        .promo-box .btn-primary:hover {
            background-color: #0056b3;
        }

   
        .promo-box .form-control {
            width: 100%;
            padding: 10px;
            border-radius: 5px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
        }

        .promo-box {
            display: flex;
            flex-direction: column;
            align-items: center;
        }

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align:center;"></h1>

   
    <div class="promo-box">
        <h2>¡Promo para ganar!</h2>
        
        <p>Ingresa el código del voucher:</p>
        
        <asp:TextBox ID="txtVoucherCode" runat="server" CssClass="form-control" placeholder="Código del voucher"></asp:TextBox>
    
   
        <asp:Button ID="btnSiguiente" runat="server" CssClass="btn btn-primary" Text="Siguiente" OnClick="btnSiguiente_Click" />
    

        <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" Visible="false"></asp:Label>



    </div>
</asp:Content>
