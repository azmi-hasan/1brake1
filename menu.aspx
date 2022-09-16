<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" SmartNavigation="True" CodeFile="menu.aspx.vb" Inherits="menu" title="Home Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
<br />
<br />
<br />
<br />
<br />
<br />
<div align="center"> 
   <table width="80%">
    
<%--                <td  align="left" style="width:25%; text-align:center">
--%>
      <tr><td>
      <br />
          <asp:HyperLink ID="HyperLink1" NavigateUrl="~/goods.aspx" runat="server" BackColor="#993300" Font-Bold="true" Font-Size="14pt" ForeColor="white">Goods Train</asp:HyperLink>
      <br />
      </td></tr> 
     
      <tr><td>
       <br />
          <asp:HyperLink ID="HyperLink2" NavigateUrl="~/passenger.aspx" runat="server" BackColor="#FFCC99" Font-Bold="true" Font-Size="14pt"  ForeColor="Black" >Passenger Train</asp:HyperLink>
      <br />
      </td></tr>           
   <tr><td>
      <br />
          <asp:HyperLink ID="HyperLink3" NavigateUrl="~/Light_Engine.aspx" runat="server" BackColor="#993300" Font-Bold="true" Font-Size="14pt" ForeColor="white">Light Engine</asp:HyperLink>
      <br />
      </td></tr> 
        <tr><td>
       <br />
          <asp:HyperLink ID="HyperLink4" NavigateUrl="~/EMU_DMU.aspx" runat="server" BackColor="#FFCC99" Font-Bold="true" Font-Size="14pt"  ForeColor="Black" >EMU/DMU</asp:HyperLink>
      <br />
      </td></tr>           

         <tr><td align="Right">
                  <asp:HyperLink ID="HyperLink5" 
                      NavigateUrl="~/MP-IB-BK-04-14-07 rev-2.pdf" runat="server" 
                      Font-Bold="True" Font-Size="14pt"  ForeColor="Black" >Instructions for Use</asp:HyperLink>
      <br />
      </td></tr>           

   
   </table>
   </div>
<br />

</asp:Content>

