<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logout.aspx.cs" Inherits="eComerce.logout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%
            this.Session.Clear();
            this.Session["actual"] = "null";
            this.Session["rutActual"] = "null";
            Response.Redirect("index.aspx");
        %>
    </div>
    </form>
</body>
</html>
