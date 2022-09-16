<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Light_Engine.aspx.vb" Inherits="Light_Engine" title="EBD - Light Engine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <br />
      <br />
      <br />
<br />
<br />
<br />
<br />
<br />
<asp:LinkButton ID="LinkButton1" runat="server" >Home</asp:LinkButton>

<br />
      <table  border="1" style="background-color:#FFCCCC; border-color:#CCCCCC; border-width:thin; margin-left:100px" width="410px">
    <tr>
                <td colspan="2" style=" background-color:#FFFFCC">
                    <asp:Label ID="Label1" runat="server" Text="Light Engine"></asp:Label>
     </td> 
     </tr>
      <tr>
                <td style="width:250px">
                    <asp:Label ID="Label2" runat="server" Text="Type of Locomotive"></asp:Label>
     </td> 
                     <td style="width:160px">
                         <asp:DropDownList ID="DDLightEngineLocoType" Width="160px" runat="server" 
                             AutoPostBack="True">
                         </asp:DropDownList>
                     </td> 
     </tr>

      <tr>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="No.of Locomotive"></asp:Label>
     </td> 
                     <td>
                         <asp:DropDownList ID="DDLightEngineNoOfLoco" Width="160px" runat="server">
                         <asp:ListItem Text="Select"></asp:ListItem>
                         <asp:ListItem Text="1" Value="1"></asp:ListItem>
                         <asp:ListItem Text="2" Value="2"></asp:ListItem>
                         <asp:ListItem Text="3" Value="3"></asp:ListItem>
                         <asp:ListItem Text="4" Value="4"></asp:ListItem>
                         <asp:ListItem Text="5" Value="5"></asp:ListItem>
                         <asp:ListItem Text="6" Value="6"></asp:ListItem>
 </asp:DropDownList></td></tr>

     <tr><td><asp:Label ID="Label9" runat="server" Text="Type of Loco Brake Block"></asp:Label>
     </td><td><asp:DropDownList ID="DDLightEngineLocoBrakeBlock" Width="160px" runat="server" 
                 AutoPostBack="False">
<%--                         <asp:ListItem Text="Select"></asp:ListItem>
                         <asp:ListItem Text="Cast Iron" Value="1"></asp:ListItem>
                         <asp:ListItem Text="L Type Composition" Value="2"></asp:ListItem>
                         <asp:ListItem Text="High Friction" Value="3"></asp:ListItem>
--%>     </asp:DropDownList></td></tr>
   
     <tr><td><asp:Label ID="Label14" runat="server" Text="BC Pressure of Loco in kg/sq.cm"></asp:Label>
     </td><td><asp:DropDownList ID="DDLightEngineBCPressure" Width="160px" runat="server" AutoPostBack="true" >
              <asp:ListItem Text="Select"></asp:ListItem><asp:ListItem Text="Other"></asp:ListItem><asp:ListItem Text="0.5" Value="0.5"></asp:ListItem>
              <asp:ListItem Text="1.0" Value="1.0"></asp:ListItem><asp:ListItem Text="1.2" Value="1.2"></asp:ListItem>
              <asp:ListItem Text="1.4" Value="1.4"></asp:ListItem><asp:ListItem Text="1.6" Value="1.6"></asp:ListItem> 
              <asp:ListItem Text="1.8" Value="1.8"></asp:ListItem><asp:ListItem Text="2.0" Value="2.0"></asp:ListItem>
              <asp:ListItem Text="2.5" Value="2.5"></asp:ListItem><asp:ListItem Text="3.0" Value="3.0"></asp:ListItem> 
              <asp:ListItem Text="3.5" Value="3.5"></asp:ListItem><asp:ListItem Text="4.0" Value="4.0"></asp:ListItem> 
              <asp:ListItem Text="4.4" Value="4.4"></asp:ListItem><asp:ListItem Text="4.5" Value="4.5"></asp:ListItem> 
              <asp:ListItem Text="5.0" Value="5.0"></asp:ListItem><asp:ListItem Text="5.2" Value="5.2"></asp:ListItem>
     </asp:DropDownList><br /><asp:TextBox ID="txtLightEngineBCPressure" runat="server" Visible="false"></asp:TextBox></td></tr>


 <tr><td><asp:Label ID="Label16" runat="server" Text="Speed in kmph"></asp:Label>
     </td><td><asp:DropDownList ID="DDLightEngineSpeed" Width="160px" runat="server" AutoPostBack="true">
              <asp:ListItem Text="Select"></asp:ListItem><asp:ListItem Text="Other"></asp:ListItem><asp:ListItem Text="5" Value="5"></asp:ListItem>
              <asp:ListItem Text="10" Value="10"></asp:ListItem><asp:ListItem Text="15" Value="15"></asp:ListItem><asp:ListItem Text="20" Value="20"></asp:ListItem><asp:ListItem Text="25" Value="25"></asp:ListItem> 
              <asp:ListItem Text="30" Value="30"></asp:ListItem><asp:ListItem Text="35" Value="35"></asp:ListItem><asp:ListItem Text="40" Value="40"></asp:ListItem><asp:ListItem Text="45" Value="45"></asp:ListItem>
              <asp:ListItem Text="50" Value="50"></asp:ListItem><asp:ListItem Text="55" Value="55"></asp:ListItem><asp:ListItem Text="60" Value="60"></asp:ListItem><asp:ListItem Text="65" Value="65"></asp:ListItem>
              <asp:ListItem Text="70" Value="70"></asp:ListItem><asp:ListItem Text="75" Value="75"></asp:ListItem><asp:ListItem Text="80" Value="80"></asp:ListItem><asp:ListItem Text="85" Value="85"></asp:ListItem>
              <asp:ListItem Text="90" Value="90"></asp:ListItem><asp:ListItem Text="95" Value="95"></asp:ListItem><asp:ListItem Text="100" Value="100"></asp:ListItem><asp:ListItem Text="105" Value="105"></asp:ListItem>
              <asp:ListItem Text="110" Value="110"></asp:ListItem><asp:ListItem Text="115" Value="115"></asp:ListItem><asp:ListItem Text="120" Value="120"></asp:ListItem><asp:ListItem Text="125" Value="125"></asp:ListItem>
              <asp:ListItem Text="130" Value="130"></asp:ListItem><asp:ListItem Text="135" Value="135"></asp:ListItem><asp:ListItem Text="140" Value="140"></asp:ListItem><asp:ListItem Text="145" Value="145"></asp:ListItem>
              <asp:ListItem Text="150" Value="150"></asp:ListItem><asp:ListItem Text="155" Value="155"></asp:ListItem><asp:ListItem Text="160" Value="160"></asp:ListItem><asp:ListItem Text="165" Value="165"></asp:ListItem>
              <asp:ListItem Text="170" Value="170"></asp:ListItem><asp:ListItem Text="175" Value="175"></asp:ListItem><asp:ListItem Text="180" Value="180"></asp:ListItem><asp:ListItem Text="185" Value="185"></asp:ListItem>
              <asp:ListItem Text="190" Value="190"></asp:ListItem><asp:ListItem Text="200" Value="200"></asp:ListItem>

     </asp:DropDownList><br /><asp:TextBox ID="txtLightEngineSpeed" runat="server" Visible="false"></asp:TextBox></td></tr>

     <tr><td><asp:Label ID="Label17" runat="server" Text="Select Grade"></asp:Label>
     </td><td><asp:DropDownList ID="DDLightEngineGrade" Width="160px" runat="server" AutoPostBack="true">
  
               <asp:ListItem Text="Select"></asp:ListItem><asp:ListItem Text="Other"></asp:ListItem><asp:ListItem Text="37" Value="37"></asp:ListItem><asp:ListItem Text="40" Value="40"></asp:ListItem> 
               <asp:ListItem Text="50" Value="50"></asp:ListItem><asp:ListItem Text="60" Value="60"></asp:ListItem><asp:ListItem Text="70" Value="70"></asp:ListItem> 
               <asp:ListItem Text="80" Value="80"></asp:ListItem><asp:ListItem Text="90" Value="90"></asp:ListItem><asp:ListItem Text="100" Value="100"></asp:ListItem>
               <asp:ListItem Text="150" Value="150"></asp:ListItem><asp:ListItem Text="200" Value="200"></asp:ListItem><asp:ListItem Text="250" Value="250"></asp:ListItem>
               <asp:ListItem Text="300" Value="300"></asp:ListItem><asp:ListItem Text="350" Value="350"></asp:ListItem><asp:ListItem Text="400" Value="400"></asp:ListItem>
               <asp:ListItem Text="450" Value="450"></asp:ListItem><asp:ListItem Text="500" Value="500"></asp:ListItem><asp:ListItem Text="1000" Value="1000"></asp:ListItem>
               <asp:ListItem Text="-500" Value="-500"></asp:ListItem><asp:ListItem Text="-450" Value="-450"></asp:ListItem><asp:ListItem Text="-400" Value="-400"></asp:ListItem>
               <asp:ListItem Text="-350" Value="-350"></asp:ListItem><asp:ListItem Text="-300" Value="-300"></asp:ListItem><asp:ListItem Text="-250" Value="-250"></asp:ListItem>
               <asp:ListItem Text="-200" Value="-200"></asp:ListItem><asp:ListItem Text="-150" Value="-150"></asp:ListItem><asp:ListItem Text="-100" Value="-100"></asp:ListItem>
               <asp:ListItem Text="-90" Value="-90"></asp:ListItem><asp:ListItem Text="-80" Value="-80"></asp:ListItem><asp:ListItem Text="-70" Value="-70"></asp:ListItem> 
               <asp:ListItem Text="-60" Value="-60"></asp:ListItem><asp:ListItem Text="-50" Value="-50"></asp:ListItem><asp:ListItem Text="-40" Value="-40"></asp:ListItem>
               <asp:ListItem Text="-37" Value="-37"></asp:ListItem>
      
  </asp:DropDownList><br /><asp:TextBox ID="txtLightEngineGrade" runat="server" Visible="false"></asp:TextBox></td></tr>
              
      <tr><td colspan="2" align="right">
          <asp:Button ID="BtnLightEngine" runat="server" Text="Calculate EBD" />
      </td></tr>

   </table> 

<%--  Panel LightEngine Started --%> 

<asp:Panel ID="PanelLightEngine" runat="server" BorderStyle="Solid" BorderWidth="1px" Height="234px"
         Style="left: 560px; top:168px; position:absolute ; " Width="420px">
      <table  cellspacing="4" style="background-color:#FFCCCC; border-color:#CCCCCC; border-width:thin; margin-left:0%" width="100%">
    <tr>
                <td colspan="2" style=" background-color:#FFFFCC">
                    <asp:Label ID="Label18" runat="server" Text="Emergency Brake Distance (EBD)"></asp:Label>
     </td> 
     </tr>
      <tr>
                <td style="width:250px">
                    <asp:Label ID="Label19" runat="server" Text="Type of Locomotive"></asp:Label>
     </td> 
                     <td style="width:160px">
                         <asp:Label ID="LblLightEngineLocoType" runat="server" Text=""></asp:Label>
                     </td> 
     </tr>
     <tr>
                    <td>
                    <asp:Label ID="Label20" runat="server" Text="No. of Locomotive"></asp:Label>
     </td> 
                     <td >
                         <asp:Label ID="LblLightEngineNoOfLoco" runat="server" Text=""></asp:Label>
                     </td> 
     </tr>
     <tr>
                    <td >
                    <asp:Label ID="Label21" runat="server" Text="Type of Locomotive Brake Block"></asp:Label>
     </td> 
                     <td >
                         <asp:Label ID="LblLightEngineLocoBrakeBlock" runat="server" Text=""></asp:Label>
                     </td> 
     </tr>
     <tr><td >
                    <asp:Label ID="Label25" runat="server" Text="BC Pressure of Locomotive in kg/sq.cm"></asp:Label>
     </td><td >
                    <asp:Label ID="LblLightEngineBCPressure" runat="server" Text=""></asp:Label>
     </td></tr>
     <tr><td >
                    <asp:Label ID="Label27" runat="server" Text="Speed in kmph"></asp:Label>
     </td><td >
                    <asp:Label ID="LblLightEngineSpeed" runat="server" Text=""></asp:Label>
     </td></tr>
     <tr><td >
                    <asp:Label ID="Label28" runat="server" Text="Grade"></asp:Label>
     </td><td >
                    <asp:Label ID="LblLightEngineGrade" runat="server" Text=""></asp:Label>
     </td></tr>
     <tr><td style=" background-color:#FFFFCC" >
                    <asp:Label ID="Label29" runat="server" Text="Simulated EBD in meter"></asp:Label>
     </td><td style=" background-color:#FFFFCC" >
                    <asp:Label ID="LblLightEngineEBD" runat="server" Text=""></asp:Label>
     </td></tr>
<tr><td colspan="2" align="right">
      <asp:TextBox ID="txtTotalDistance" runat="server" Visible="false"></asp:TextBox>        
        <asp:TextBox ID="txtTime" runat="server" Visible="false"></asp:TextBox>        
          <asp:Button ID="BtnPrintLightEngineEBD" runat="server" Text="Print View" 
          Visible="False" />
          <asp:Button ID="BtnChart" runat="server" Text="Chart" Visible="False" />

      </td></tr>

     </table>
     

</asp:Panel>
         
  
<%--  End of LightEngine View --%>    

</asp:Content>

