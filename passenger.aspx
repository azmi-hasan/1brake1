<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" SmartNavigation="True" CodeFile="passenger.aspx.vb" Inherits="passenger" title="EBD - Passenger Train" %>

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
<%--      <table  border="1" style="background-color:#FFCCCC; border-color:#CCCCCC; border-width:thin; margin-left:100px" width="480">
--%>          <table  border="1" style="background-color:#FFCCCC; border-color:#CCCCCC; border-width:thin; margin-left:50px" width="530px">

    <tr>
                <td colspan="2" style=" background-color:#FFFFCC">
                    <asp:Label ID="Label3" runat="server" Text="Passenger Train"></asp:Label>
     </td> 
     </tr>
      <tr>
                <td style="width:320">
                    <asp:Label ID="Label4" runat="server" Text="Type of Locomotive"></asp:Label>
     </td> 
                     <td style="width:160">
                         <asp:DropDownList ID="DDPassengerLocoType" Width="160px" runat="server" 
                             AutoPostBack="True">
                         </asp:DropDownList>
                     </td> 
     </tr>

      <tr>
                <td>
                    <asp:Label ID="Label30" runat="server" Text="No.of Locomotive"></asp:Label>
     </td> 
                     <td>
                         <asp:DropDownList ID="DDPassengerNoOfLoco" Width="160px" runat="server">
                         <asp:ListItem Text="Select"></asp:ListItem>
                         <asp:ListItem Text="1" Value="1"></asp:ListItem><asp:ListItem Text="2" Value="2"></asp:ListItem>
                         <asp:ListItem Text="3" Value="3"></asp:ListItem><asp:ListItem Text="4" Value="4"></asp:ListItem>
                         <asp:ListItem Text="5" Value="5"></asp:ListItem><asp:ListItem Text="6" Value="6"></asp:ListItem>
 </asp:DropDownList></td></tr>

     <tr><td><asp:Label ID="Label31" runat="server" Text="Type of Loco Brake Block"></asp:Label>
     </td><td><asp:DropDownList ID="DDPassengerLocoBrakeBlock" Width="160px" runat="server">
<%--                         <asp:ListItem Text="Select"></asp:ListItem>
                         <asp:ListItem Text="Cast Iron" Value="1"></asp:ListItem>
                         <asp:ListItem Text="L Type Composition" Value="2"></asp:ListItem>
                         <asp:ListItem Text="High Friction" Value="3"></asp:ListItem>
--%>     </asp:DropDownList></td></tr>

<%--     <tr><td><asp:Label ID="Label32" runat="server" Text="Total no. of coaches "></asp:Label>
     </td><td><asp:DropDownList ID="DDPassengerNoOfCoaches" Width="160px" runat="server" 
                 AutoPostBack="True">
                         <asp:ListItem Text="Select"></asp:ListItem>
                         <asp:ListItem Text="1" Value="1"></asp:ListItem><asp:ListItem Text="2" Value="2"></asp:ListItem><asp:ListItem Text="3" Value="3"></asp:ListItem><asp:ListItem Text="4" Value="4"></asp:ListItem>
                         <asp:ListItem Text="5" Value="5"></asp:ListItem><asp:ListItem Text="6" Value="6"></asp:ListItem><asp:ListItem Text="7" Value="7"></asp:ListItem><asp:ListItem Text="8" Value="8"></asp:ListItem>
                         <asp:ListItem Text="9" Value="9"></asp:ListItem><asp:ListItem Text="10" Value="10"></asp:ListItem><asp:ListItem Text="11" Value="11"></asp:ListItem><asp:ListItem Text="12" Value="12"></asp:ListItem>
                         <asp:ListItem Text="13" Value="13"></asp:ListItem><asp:ListItem Text="14" Value="14"></asp:ListItem><asp:ListItem Text="15" Value="15"></asp:ListItem><asp:ListItem Text="16" Value="16"></asp:ListItem>
                         <asp:ListItem Text="17" Value="17"></asp:ListItem><asp:ListItem Text="18" Value="18"></asp:ListItem><asp:ListItem Text="19" Value="19"></asp:ListItem><asp:ListItem Text="20" Value="20"></asp:ListItem>
                         <asp:ListItem Text="21" Value="21"></asp:ListItem><asp:ListItem Text="22" Value="22"></asp:ListItem>
     </asp:DropDownList></td></tr>--%>

     <tr><td colspan="2"><asp:Label ID="lblPassengerCoachType" runat="server" Text="Coach Type:"></asp:Label>
     <asp:DropDownList ID="DDPassengerCoachType" Width="250px" runat="server" 
             AutoPostBack="True"></asp:DropDownList>
     <asp:Label ID="lblPassengerCoaches" runat="server" Text="Coaches:"></asp:Label>
     <asp:DropDownList ID="DDPassengerCoaches" Width="70px" runat="server"> 
                         <asp:ListItem Text="Select"></asp:ListItem>
                         <asp:ListItem Text="01" Value="01"></asp:ListItem><asp:ListItem Text="02" Value="02"></asp:ListItem><asp:ListItem Text="03" Value="03"></asp:ListItem><asp:ListItem Text="04" Value="04"></asp:ListItem>
                         <asp:ListItem Text="05" Value="05"></asp:ListItem><asp:ListItem Text="06" Value="06"></asp:ListItem><asp:ListItem Text="07" Value="07"></asp:ListItem><asp:ListItem Text="08" Value="08"></asp:ListItem>
                         <asp:ListItem Text="09" Value="09"></asp:ListItem><asp:ListItem Text="10" Value="10"></asp:ListItem><asp:ListItem Text="11" Value="11"></asp:ListItem><asp:ListItem Text="12" Value="12"></asp:ListItem>
                         <asp:ListItem Text="13" Value="13"></asp:ListItem><asp:ListItem Text="14" Value="14"></asp:ListItem><asp:ListItem Text="15" Value="15"></asp:ListItem><asp:ListItem Text="16" Value="16"></asp:ListItem>
                         <asp:ListItem Text="17" Value="17"></asp:ListItem><asp:ListItem Text="18" Value="18"></asp:ListItem><asp:ListItem Text="19" Value="19"></asp:ListItem><asp:ListItem Text="20" Value="20"></asp:ListItem>
                         <asp:ListItem Text="21" Value="21"></asp:ListItem><asp:ListItem Text="22" Value="22"></asp:ListItem><asp:ListItem Text="23" Value="23"></asp:ListItem><asp:ListItem Text="24" Value="24"></asp:ListItem>
                        
                         </asp:DropDownList>
         <asp:Button ID="BtnPassengerCoachType" runat="server" Text="OK" />
         <asp:TextBox ID="text1"  Visible="false" runat="server"></asp:TextBox>
         <asp:TextBox ID="text2"  Visible="false" runat="server"></asp:TextBox>
         <asp:TextBox ID="text5"  Visible="false" runat="server"></asp:TextBox>
         <asp:TextBox ID="Text6"  Visible="false" runat="server"></asp:TextBox>

    </td></tr>

     <tr><td><asp:Label ID="Label33" runat="server" Text="Type of Stock Brake Block "></asp:Label>
     </td><td><asp:DropDownList ID="DDPassengerStockBrakeBlock" Width="160px" runat="server">
<%--                         <asp:ListItem Text="Select"></asp:ListItem>
                         <asp:ListItem Text="Cast Iron" Value="1"></asp:ListItem>
                         <asp:ListItem Text="L Type Composition" Value="2"></asp:ListItem>
                         <asp:ListItem Text="K Type Composition" Value="3"></asp:ListItem>
--%>    </asp:DropDownList></td></tr>

      <tr><td><asp:Label ID="Label14" runat="server" Text="BC Pressure of Loco in kg/sq.cm"></asp:Label>
     </td><td><asp:DropDownList ID="DDPassengerBCPressure" Width="160px" runat="server" AutoPostBack="true">
              <asp:ListItem Text="Select"></asp:ListItem><asp:ListItem Text="Other"></asp:ListItem><asp:ListItem Text="0.5" Value="0.5"></asp:ListItem>
              <asp:ListItem Text="1.0" Value="1.0"></asp:ListItem><asp:ListItem Text="1.2" Value="1.2"></asp:ListItem>
              <asp:ListItem Text="1.4" Value="1.4"></asp:ListItem><asp:ListItem Text="1.6" Value="1.6"></asp:ListItem> 
              <asp:ListItem Text="1.8" Value="1.8"></asp:ListItem><asp:ListItem Text="2.0" Value="2.0"></asp:ListItem>
              <asp:ListItem Text="2.5" Value="2.5"></asp:ListItem><asp:ListItem Text="3.0" Value="3.0"></asp:ListItem> 
              <asp:ListItem Text="3.5" Value="3.5"></asp:ListItem><asp:ListItem Text="4.0" Value="4.0"></asp:ListItem> 
              <asp:ListItem Text="4.4" Value="4.4"></asp:ListItem><asp:ListItem Text="4.5" Value="4.5"></asp:ListItem> 
              <asp:ListItem Text="5.0" Value="5.0"></asp:ListItem>
     </asp:DropDownList><br /> <asp:TextBox ID="txtPassengerBCPressure" runat="server" Visible="False"></asp:TextBox></td></tr>

      <tr><td><asp:Label ID="Label15" runat="server" Text="Percentage Brake Power"></asp:Label>
     </td><td><asp:DropDownList ID="DDPassengerBrakePower" Width="160px" runat="server" AutoPostBack="true">
              <asp:ListItem Text="Select"></asp:ListItem><asp:ListItem Text="Other"></asp:ListItem><asp:ListItem Text="100" Value="100"></asp:ListItem>
              <asp:ListItem Text="95" Value="95"></asp:ListItem><asp:ListItem Text="90" Value="90"></asp:ListItem>
              <asp:ListItem Text="85" Value="85"></asp:ListItem><asp:ListItem Text="80" Value="80"></asp:ListItem> 
              <asp:ListItem Text="75" Value="75"></asp:ListItem>
     </asp:DropDownList><br /> <asp:TextBox ID="txtPassengerBrakePower" runat="server" Visible="False"></asp:TextBox></td></tr></td></tr>

 <tr><td><asp:Label ID="Label16" runat="server" Text="Speed in kmph"></asp:Label>
     </td><td><asp:DropDownList ID="DDPassengerSpeed" Width="160px" runat="server" AutoPostBack="true">
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
              <asp:ListItem Text="120" Value="120"></asp:ListItem><asp:ListItem Text="120" Value="125"></asp:ListItem>
              <asp:ListItem Text="130" Value="130"></asp:ListItem> <asp:ListItem Text="135" Value="135"></asp:ListItem><asp:ListItem Text="140" Value="140"></asp:ListItem>
              <asp:ListItem Text="145" Value="145"></asp:ListItem><asp:ListItem Text="150" Value="150"></asp:ListItem>
              <asp:ListItem Text="155" Value="155"></asp:ListItem><asp:ListItem Text="160" Value="160"></asp:ListItem>
              <asp:ListItem Text="165" Value="165"></asp:ListItem><asp:ListItem Text="170" Value="170"></asp:ListItem>
              <asp:ListItem Text="175" Value="175"></asp:ListItem><asp:ListItem Text="180" Value="180"></asp:ListItem>
              <asp:ListItem Text="185" Value="185"></asp:ListItem><asp:ListItem Text="190" Value="190"></asp:ListItem>
              <asp:ListItem Text="195" Value="195"></asp:ListItem><asp:ListItem Text="200" Value="200"></asp:ListItem>

     </asp:DropDownList><br /> <asp:TextBox ID="txtPassengerSpeed" runat="server" Visible="False"></asp:TextBox></td></tr>
     <tr><td><asp:Label ID="Label17" runat="server" Text="Grade"></asp:Label>
     </td><td><asp:DropDownList ID="DDPassengerGrade" Width="160px" runat="server" AutoPostBack="true">
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
             </asp:DropDownList><br /> <asp:TextBox ID="txtPassengerGrade" runat="server" Visible="False"></asp:TextBox></td></tr>
     
      <tr><td colspan="2" align="right">
          <asp:Button ID="BtnPassenger" runat="server" Text="Calculate EBD" />
      </td></tr>


    </table> 
  <asp:Panel ID="PanelTrComposition" runat="server" BorderStyle="Solid" BorderWidth="1px" Height="175px"
         Style="left: 610px; top:180px; position:absolute ; " Width="220px">
      <table  style="background-color:#FFCCCC; border-color:#CCCCCC; border-width:thin; margin-left:0%" width="100%">

<tr>
<td valign="top" colspan="2" align="center" style="width: 100%">
                <asp:ListBox ID="ListBoxTrComposition" runat="server" width="100%" Height="140px"   
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
  
  <%--  Panel Passenger Started --%> 

<asp:Panel ID="PanelPassenger" runat="server" BorderStyle="Solid" BorderWidth="1px" Height="335px"
         Style="left: 610px; top:180px; position:absolute ; " Width="420px">
      <table  cellspacing="4" style="background-color:#FFCCCC; border-color:#CCCCCC; border-width:thin; margin-left:0%" width="100%">
    <tr>
                <td colspan="2" style=" background-color:#FFFFCC">
                    <asp:Label ID="Label18" runat="server" Text="Emergency Brake Distance (EBD)"></asp:Label>
     </td> 
     </tr>
      <tr>
                <td style="width:60%">
                    <asp:Label ID="Label19" runat="server" Text="Type of Locomotive"></asp:Label>
     </td> 
                     <td style="width:40%">
                         <asp:Label ID="LblPassengerLocoType" runat="server" Text=""></asp:Label>
                     </td> 
     </tr>
     <tr>
                    <td>
                    <asp:Label ID="Label20" runat="server" Text="No. of Locomotive"></asp:Label>
     </td> 
                     <td >
                         <asp:Label ID="LblPassengerNoOfLoco" runat="server" Text=""></asp:Label>
                     </td> 
     </tr>
     <tr>
                    <td >
                    <asp:Label ID="Label21" runat="server" Text="Type of Locomotive Brake Block"></asp:Label>
     </td> 
                     <td >
                         <asp:Label ID="LblPassengerLocoBrakeBlock" runat="server" Text=""></asp:Label>
                     </td> 
     </tr>
          <tr><td  valign="top">
                    <asp:Label ID="Label23" runat="server" Text="Total No.of Stock"></asp:Label>
     </td><td valign="top" >
                    <asp:Label ID="LblPassengerNoOfStock" runat="server" Text=""></asp:Label>
     </td></tr>

     
     <tr><td >
                    <asp:Label ID="Label22" runat="server" Text="Type of Stock Brake Block"></asp:Label>
     </td><td >
                    <asp:Label ID="LblPassengerStockBrakeBlock" runat="server" Text=""></asp:Label>
     </td></tr>
      <tr><td >
                    <asp:Label ID="Label25" runat="server" Text="BC Pressure of Locomotive in kg/sq.cm"></asp:Label>
     </td><td >
                    <asp:Label ID="LblPassengerBCPressure" runat="server" Text=""></asp:Label>
     </td></tr>
     <tr><td >
                    <asp:Label ID="Label26" runat="server" Text="Percentage Brake Power"></asp:Label>
     </td><td >
                    <asp:Label ID="LblPassengerBrakePower" runat="server" Text=""></asp:Label>
     </td></tr>
     <tr><td >
                    <asp:Label ID="Label27" runat="server" Text="Speed in kmph"></asp:Label>
     </td><td >
                    <asp:Label ID="LblPassengerSpeed" runat="server" Text=""></asp:Label>
     </td></tr>
     <tr><td >
                    <asp:Label ID="Label28" runat="server" Text="Grade"></asp:Label>
     </td><td >
                    <asp:Label ID="LblPassengerGrade" runat="server" Text=""></asp:Label>
     </td></tr>
     <tr><td style=" background-color:#FFFFCC" >
                    <asp:Label ID="Label29" runat="server" Text="Simulated EBD in meter"></asp:Label>
     </td><td style=" background-color:#FFFFCC" >
                    <asp:Label ID="LblPassengerEBD" runat="server" Text=""></asp:Label>
     </td></tr>
<tr><td colspan="2" align="right">
     <asp:TextBox ID="txtTotalDistance" runat="server" Visible="false"></asp:TextBox>        
        <asp:TextBox ID="txtTime" runat="server" Visible="false"></asp:TextBox>        
          <asp:Button ID="BtnPrintPassengerEBD" runat="server" Text="Print View" 
         Visible="False" />
     <asp:Button ID="BtnChart" runat="server" Text="Chart" Visible="False" />
     
      </td></tr>

     </table>
     

</asp:Panel>

  
  
</asp:Content>

