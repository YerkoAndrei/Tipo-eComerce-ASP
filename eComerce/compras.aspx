<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="compras.aspx.cs" Inherits="eComerce.compras" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%
    if(this.Session["actual"] == "cliente")
    { 
%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Compras</title>
    <link rel="Stylesheet" type="text/css" href="estilo.css"/>
    <script src="jquery.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            todos();
        });
        function busqueda() {
            $.get("busqueda.aspx?opcion=no&search=" + $("#txtBuscar").val(), function (data) {
                $("#centro").html(data);
            });
        }
        function todos() {
            $.get("busqueda.aspx?opcion=ok", function (data) {
                $("#centro").html(data);
            });
        }
    </script>
</head>
<body>
<a href="logout.aspx">Cerrar sesión</a>
    <form id="form1" runat="server">
    <center>
    <h1>Compras</h1>
    <div id="buscar">
        <asp:TextBox ID="txtBuscar" runat="server" Width="330px"></asp:TextBox>
        <input id="btnBuscar" type="button" value="Buscar" onclick="busqueda()"/>
        <input id="btnTodos" type="button" value="Todos" onclick="todos()"/>
    </div>
    <div id="centro">
        <%
            verProductos();
        %>
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