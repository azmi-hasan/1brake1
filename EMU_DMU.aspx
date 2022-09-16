<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EMU_DMU.aspx.vb" Inherits="EMU_DMU" title="EBD - EMU/DMU" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
    <asp:LinkButton ID="LinkButton1" runat="server">Home</asp:LinkButton>
      <br />
      <br />
      <table  border="1" style="background-color:#FFCCCC; border-color:#CCCCCC; border-width:thin; margin-left:100px" width="480px">
    <tr>
                <td colspan="2" style=" background-color:#FFFFCC">
                    <asp:Label ID="Label1" runat="server" Text="EMU/DMU"></asp:Label>
     </td> 
     </tr>
      <tr>
      
      <td colspan="2"><asp:Label ID="lblEMUCoachType" runat="server" Text="Coach Type:"></asp:Label>
     <asp:DropDownList ID="DDEMUCoachType" Width="200px" runat="server"></asp:DropDownList>
     <asp:Label ID="lblEMUCoaches" runat="server" Text="Coaches:"></asp:Label>
     <asp:DropDownList ID="DDEMUCoaches" Width="70px" runat="server"> 
                         <asp:ListItem Text="Select"></asp:ListItem>
                         <asp:ListItem Text="01" Value="01"></asp:ListItem><asp:ListItem Text="02" Value="02"></asp:ListItem><asp:ListItem Text="03" Value="03"></asp:ListItem><asp:ListItem Text="04" Value="04"></asp:ListItem>
                         <asp:ListItem Text="05" Value="05"></asp:ListItem><asp:ListItem Text="06" Value="06"></asp:ListItem><asp:ListItem Text="07" Value="07"></asp:ListItem><asp:ListItem Text="08" Value="08"></asp:ListItem>
                         <asp:ListItem Text="09" Value="09"></asp:ListItem><asp:ListItem Text="10" Value="10"></asp:ListItem><asp:ListItem Text="11" Value="11"></asp:ListItem><asp:ListItem Text="12" Value="12"></asp:ListItem>
                         <asp:ListItem Text="13" Value="13"></asp:ListItem><asp:ListItem Text="14" Value="14"></asp:ListItem><asp:ListItem Text="15" Value="15"></asp:ListItem><asp:ListItem Text="16" Value="16"></asp:ListItem></asp:DropDownList>
         <asp:Button ID="BtnEMUCoachType" runat="server" Text="OK" />
         <asp:TextBox ID="text3"  Visible="false" runat="server"></asp:TextBox>
         <asp:TextBox ID="Text4"  Visible="false" runat="server"></asp:TextBox>
         <asp:TextBox ID="Text6"  Visible="false" runat="server"></asp:TextBox>

    </td></tr> 
                                
      <tr><td style="width:320px"><asp:Label ID="Label16" runat="server" Text="Speed in kmph"></asp:Label>
     </td><td style="width:160px"><asp:DropDownList ID="DDEMUSpeed" Width="160px" runat="server" AutoPostBack="true">
              <asp:ListItem Text="Select"></asp:ListItem><asp:ListItem Text="Other"></asp:ListItem><asp:ListItem Text="5" Value="5"></asp:ListItem>
              <asp:ListItem Text="10" Value="10"></asp:ListItem><asp:ListItem Text="15" Value="15"></asp:ListItem>
              <asp:ListItem Text="20" Value="20"></asp:ListItem><asp:ListItem Text="25" Value="25"></asp:ListItem> 
              <asp:ListItem Text="30" Value="30"></asp:ListItem><asp:ListItem Text="35" Value="35"></asp:ListItem>
              <asp:ListItem Text="40" Value="40"></asp:ListItem><asp:ListItem Text="45" Value="45"></asp:ListItem>
              <asp:ListItem Text="50" Value="50"></asp:ListItem><asp:ListItem Text="55" Value="55"></asp:ListItem>
              <asp:ListItem Text="60" Value="60"></asp:ListItem><asp:ListItem Text="65" Value="65"></asp:ListItem>
              <asp:ListItem Text="70" Value="70"></asp:ListItem><asp:ListItem Text="75" Value="75"></asp:ListItem>
              <asp:ListItem Text="80" Value="80"></asp:ListItem><asp:ListItem Text="85" Value="85"></asp:ListItem>
              <asp:ListItem Text="90" Value="90"></asp:ListItem><asp:ListItem Text="95" Value="95"></asp:ListItem>
              <asp:ListItem Text="100" Value="100"></asp:ListItem><asp:ListItem Text="105" Value="105"></asp:ListItem>
              <asp:ListItem Text="110" Value="110"></asp:ListItem><asp:ListItem Text="115" Value="115"></asp:ListItem>
              <asp:ListItem Text="120" Value="120"></asp:ListItem><asp:ListItem Text="125" Value="125"></asp:ListItem>
              <asp:ListItem Text="130" Value="130"></asp:ListItem><asp:ListItem Text="135" Value="135"></asp:ListItem>
              <asp:ListItem Text="140" Value="140"></asp:ListItem><asp:ListItem Text="145" Value="145"></asp:ListItem>
              <asp:ListItem Text="150" Value="150"></asp:ListItem><asp:ListItem Text="155" Value="155"></asp:ListItem>
              <asp:ListItem Text="160" Value="160"></asp:ListItem><asp:ListItem Text="165" Value="165"></asp:ListItem>
              <asp:ListItem Text="170" Value="170"></asp:ListItem><asp:ListItem Text="175" Value="175"></asp:ListItem>
              <asp:ListItem Text="180" Value="180"></asp:ListItem><asp:ListItem Text="185" Value="185"></asp:ListItem>
              <asp:ListItem Text="190" Value="190"></asp:ListItem><asp:ListItem Text="195" Value="195"></asp:ListItem>
              <asp:ListItem Text="200" Value="200"></asp:ListItem>
     </asp:DropDownList><br /><asp:TextBox ID="txtEMUSpeed" runat="server" Visible="false"></asp:TextBox> </td></tr>
          <tr><td><asp:Label ID="Label17" runat="server" Text="Select Grade"></asp:Label>
     </td><td><asp:DropDownList ID="DDEMUGrade" Width="160px" runat="server" AutoPostBack="true">
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
 </asp:DropDownList><br /><asp:TextBox ID="txtEMUGrade" runat="server" Visible="false"></asp:TextBox></td></tr>
           
           <tr><td colspan="2" align="right">
          <asp:Button ID="BtnEMU" runat="server" Text="Calculate EBD" />
      </td></tr>
                     
     </table> 
 
 <%--  Panel Train Composition Started --%> 
   <asp:Panel ID="PanelTrComposition" runat="server" BorderStyle="Solid" BorderWidth="1px" Height="140px"
         Style="left: 610px; top:185px; position:absolute ; " Width="220px">
      <table  style="background-color:#FFCCCC; border-color:#CCCCCC; border-width:thin; margin-left:0%" width="100%">

<tr>
<td valign="top" colspan="2" align="center" style="width: 220px">
                <asp:ListBox ID="ListBoxTrComposition" runat="server" width="100%" Height="100px"   
                    SelectionMode="Multiple"></asp:ListBox>
       </td ></tr>
    <tr>
<td valign="top" align="center" style="width: 50%">
          <asp:Button Width="80px" ID="BtnRemove" runat="server" Text="<< Remove" />
  </td >
  <td valign="top" align="center" style="width: 50%">
          <asp:Button ID="btnTrComposition" runat="server" Width="70px" Text="Finish" />
  </td>
  </tr>  
    </table>
</asp:Panel> 
 
 
 
 <%--  Panel EMU Started --%>     
 
<asp:Panel ID="PanelEMU" runat="server" BorderStyle="Solid" BorderWidth="1px" Height="160px"
         Style="left: 610px; top:185px; position:absolute ; " Width="420px">
      <table  cellspacing="4" style="background-color:#FFCCCC; border-color:#CCCCCC; border-width:thin; margin-left:0%" width="100%">
    <tr>
                <td colspan="2" style=" background-color:#FFFFCC">
                    <asp:Label ID="Label18" runat="server" Text="Emergency Brake Distance (EBD)"></asp:Label>
     </td> 
     </tr>
      <tr>
                <td style="width:60%" valign="top">
                    <asp:Label ID="Label2" runat="server" Text="Total No.of Stock"></asp:Label>
     </td> 
                     <td style="width:40%">
                    <asp:Label ID="LblEMUNoOfStock" runat="server" Text=""></asp:Label>
                     </td> 
     </tr>
      
     <tr><td >
                    <asp:Label ID="Label27" runat="server" Text="Speed in kmph"></asp:Label>
     </td><td >
                    <asp:Label ID="LblEMUSpeed" runat="server" Text=""></asp:Label>
     </td></tr>
     <tr><td >
                    <asp:Label ID="Label28" runat="server" Text="Grade"></asp:Label>
     </td><td >
                    <asp:Label ID="LblEMUGrade" runat="server" Text=""></asp:Label>
     </td></tr>
     <tr><td style=" background-color:#FFFFCC" >
                    <asp:Label ID="Label29" runat="server" Text="Simulated EBD in meter"></asp:Label>
     </td><td style=" background-color:#FFFFCC" >
                    <asp:Label ID="LblEMUEBD" runat="server" Text=""></asp:Label>
     </td></tr>
<tr><td colspan="2" align="right">
       <asp:TextBox ID="txtTotalDistance" runat="server" Visible="false"></asp:TextBox>        
        <asp:TextBox ID="txtTime" runat="server" Visible="false"></asp:TextBox>        
          <asp:Button ID="BtnPrintEMUEBD" runat="server" Text="Print View" 
           Visible="False" />
    <asp:Button ID="BtnChart" runat="server" Text="Chart" Visible="False" />
      </td></tr>

     </table>
     

</asp:Panel>

 
</asp:Content>
 

