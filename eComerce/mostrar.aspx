<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mostrar.aspx.cs" Inherits="eComerce.mostrar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%
    if(this.Session["actual"] == "cliente")
    { 
%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="estilo.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <%
        mostrarProducto();
    %>
    <asp:Button ID="btnAgregarCarro" runat="server" Text="Agregar al carro" onclick="btnAgregarCarro_Click" Width="500px" Height="40px" />
    <div id="comentar">
        <asp:TextBox ID="txtComentar" runat="server" Height="50px" Width="490px" TextMode="MultiLine" ></asp:TextBox><br />
        <asp:Button ID="btnComentar" runat="server" Text="Comentar" onclick="btnComentar_Click" />
    </div>
    <%
        mostrarComentarios();
    %>
    </form>

</body>
</html>
<%
    }
    else
        Response.Redirect("index.aspx");
%>