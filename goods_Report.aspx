<%@ Page Language="VB" AutoEventWireup="false" CodeFile="goods_Report.aspx.vb" Inherits="goods_Report" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Goods EBD</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <asp:LinkButton ID="LinkButton1" runat="server">Previous Page</asp:LinkButton>
        <br />
        
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
    
    
    </div>
    </form>
</body>
</html>
