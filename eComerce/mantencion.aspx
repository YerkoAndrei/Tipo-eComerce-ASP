<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mantencion.aspx.cs" Inherits="eComerce.Mantencion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%
    if(this.Session["actual"] == "admin")
    { 
%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mantencion</title>
    <link rel="Stylesheet" type="text/css" href="estilo.css"/>
</head>
<body>
<a href="logout.aspx">Cerrar sesión</a>
    <form id="form1" runat="server">
    <center>
    <h1>Mantención</h1>
    <div id="productos">
        <h2>Productos</h2>
        <asp:GridView ID="dgvTodosProductos" runat="server" CssClass="dgv"></asp:GridView>
    </div>
    
    <div id="crear" class="mant">
        <h2>Crear</h2>
        <table>
            <tr>
                <td>Nombre</td>
                <td><asp:TextBox ID="txtCrearNombre" runat="server" MaxLength="30"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Descripción</td>
                <td><asp:TextBox ID="txtCrearDescripcion" runat="server" MaxLength="30" TextMode="MultiLine" ></asp:TextBox></td>
            </tr>
            <tr>
                <td>Precio</td>
                <td><asp:TextBox ID="txtCrearPrecio" runat="server" MaxLength="11" TextMode="Number"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Image ID="crearImagen" runat="server" width="100" Height="100"/></td>
                <td><input type="file" id="fileCrear"/></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnCrear" runat="server" Text="Crear" onclick="btnCrear_Click" /></td>
            </tr>
        </table>
    </div>
    <div id="modificar" class="mant">
        <h2>Modificar</h2>
        <table>
            <tr>
                <td>Id</td>
                <td><asp:TextBox ID="txtModId" runat="server" MaxLength="30"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Nuevo nombre</td>
                <td><asp:TextBox ID="txtModNombreNuevo" runat="server" MaxLength="30"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Nueva descripción</td>
                <td><asp:TextBox ID="txtModDescripcion" runat="server" MaxLength="30"
                        TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Nuevo precio</td>
                <td><asp:TextBox ID="txtModPrecio" runat="server" MaxLength="11" TextMode="Number" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Image ID="modImagen" runat="server" width="100" Height="100"/></td>
                <td><asp:FileUpload ID="fuMod" runat="server" /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnModificar" runat="server" Text="Modificar" onclick="btnModificar_Click" /></td>
            </tr>
        </table>
    </div>
    <div id="eliminar" class="mant">
        <h2>Eliminar</h2>
        <table>
            <tr>
                <td>Id</td>
                <td><asp:TextBox ID="txtDelId" runat="server" MaxLength="30" TextMode="Number"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnEliminar" runat="server" Text="Eliminar" 
                        onclick="btnEliminar_Click" /></td>
            </tr>
        </table>
    </div>
    <div id="ver" class="mant">
        <h2>Ver</h2>
        <table>
            <tr>
                <td>Nombre</td>
                <td><asp:TextBox ID="txtVerNombre" runat="server" MaxLength="30"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnVer" runat="server" Text="Ver" 
                         onclick="btnVer_Click" /></td>
            </tr>
        </table>
        <asp:GridView ID="dgvProducto" runat="server" CssClass="dgv"></asp:GridView>
    </div>
    </center>
    </form>
</body>
</html>
<%
    }
    else
        Response.Redirect("index.aspx");
%>