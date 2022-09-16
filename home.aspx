<%@ Page Language="VB" AutoEventWireup="false" CodeFile="home.aspx.vb" Inherits="home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <br /> 
  <br />
          <table  align="center" style="width: 50%;">
                <tr>
                <td align= "center">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Large"
         ForeColor="#004000" Text="Research Design & Standard Organisation"></asp:Label>
                  
                </td>
      </tr> 
          
</table>
    <br /> 
  <br />

        <table cellpadding="1" border="2"   align="center" style="width: 30%;">
            <tr>
                <td align="left" style="width:10%">
                    User Name :
                </td>
                <td style="width:15%">
                    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox> 
                </td>
            </tr>
            <tr>
                <td style="width:10%">
                    Password :
                </td>
                <td style="width:15%">
              <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox> 
   
                </td>
            </tr>
  
              <tr>
                <td align="right" colspan="2"">
                    <asp:Button ID="btnOK" runat="server" Text="Log In" />
                </td>
            </tr>
 
  
        </table>
 <br />
     <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Italic="True" Font-Size= "Medium"
         ForeColor="Blue" Visible="False"></asp:Label>
    </div>
    </form>
</body>
</html>
