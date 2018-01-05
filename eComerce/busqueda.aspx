<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="busqueda.aspx.cs" Inherits="eComerce.busqueda" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%
    if(this.Session["actual"] == "cliente")
    { 
%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
<%
    }
    else
        Response.Redirect("index.aspx");
%>