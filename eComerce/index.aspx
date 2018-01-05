<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="eComerce.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inicio</title>
    <link rel="Stylesheet" type="text/css" href="estilo.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div id="registrar" class="inicio">
        <h2>Registro</h2>
        <table>
            <tr>
                <td>Rut</td>
                <td><asp:TextBox ID="txtRut" runat="server" MaxLength="12"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Nombre</td>
                <td><asp:TextBox ID="txtNombre" runat="server" MaxLength="30"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Apellido</td>
                <td><asp:TextBox ID="txtApellido" runat="server" MaxLength="30"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Correo</td>
                <td><asp:TextBox ID="txtCorreo" runat="server" TextMode="Email" MaxLength="50"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Direccion</td>
                <td><asp:TextBox ID="txtDireccion" runat="server" MaxLength="30"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Contraseña</td>
                <td><asp:TextBox ID="txtPass" runat="server" TextMode="Password" MaxLength="30"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Repita Contraseña</td>
                <td><asp:TextBox ID="txtPass2" runat="server" TextMode="Password" MaxLength="30"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" onclick="Button1_Click" /></td>
            </tr>
        </table>
    </div>
    <div id="ingreso" class="inicio">
        <h2>Ingreso</h2>
        <table>
            <tr>
                <td>Rut</td>
                <td><asp:TextBox ID="txtLogin" runat="server" MaxLength="50"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Clave</td>
                <td><asp:TextBox ID="txtLoginPass" runat="server" TextMode="Password" MaxLength="30"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnIngresar" runat="server" Text="Ingresar" onclick="Button2_Click" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
