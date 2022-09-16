<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"  SmartNavigation="True" CodeFile="goods.aspx.vb" Inherits="goods" title="EBD - Goods Train" %>

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
      <br />
      <table  border="1" style="background-color:#FFCCCC; border-color:#CCCCCC; border-width:thin; margin-left:100px" width="410px">
    <tr>
                <td colspan="2" style=" background-color:#FFFFCC">
                    <asp:Label ID="Label1" runat="server" Text="Goods Train"></asp:Label>
     </td> 
     </tr>
      <tr>
                <td style="width:250px">
                    <asp:Label ID="Label2" runat="server" Text="Type of Locomotive"></asp:Label>
     </td> 
                     <td style="width:160px">
                         <asp:DropDownList ID="DDGoodsLocoType" Width="160px" runat="server" 
                             AutoPostBack="True">
                         </asp:DropDownList>
                     </td> 
     </tr>

      <tr>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="No.of Locomotive"></asp:Label>
     </td> 
                     <td>
                         <asp:DropDownList ID="DDGoodsNoOfLoco" Width="160px" runat="server">
                         <asp:ListItem Text="Select"></asp:ListItem>
                         <asp:ListItem Text="1" Value="1"></asp:ListItem>
                         <asp:ListItem Text="2" Value="2"></asp:ListItem>
                         <asp:ListItem Text="3" Value="3"></asp:ListItem>
                         <asp:ListItem Text="4" Value="4"></asp:ListItem>
                         <asp:ListItem Text="5" Value="5"></asp:ListItem>
                         <asp:ListItem Text="6" Value="6"></asp:ListItem>
 </asp:DropDownList></td></tr>

     <tr><td><asp:Label ID="Label9" runat="server" Text="Type of Loco Brake Block"></asp:Label>
     </td><td><asp:DropDownList ID="DDGoodsLocoBrakeBlock" Width="160px" runat="server" 
                 AutoPostBack="False">
<%--                         <asp:ListItem Text="Select"></asp:ListItem>
                         <asp:ListItem Text="Cast Iron" Value="1"></asp:ListItem>
                         <asp:ListItem Text="L Type Composition" Value="2"></asp:ListItem>
                         <asp:ListItem Text="High Friction" Value="3"></asp:ListItem>
--%>     </asp:DropDownList></td></tr>
     
     <tr><td><asp:Label ID="Label11" runat="server" Text="Type of Stock"></asp:Label>
     </td><td><asp:DropDownList ID="DDGoodsTypeOfStock" Width="160px" runat="server" AutoPostBack="true">
     </asp:DropDownList></td></tr>

     <tr><td><asp:Label ID="Label12" runat="server" Text="Number of Stock"></asp:Label>
     </td><td><asp:DropDownList ID="DDGoodsNoOfStock" Width="160px" runat="server">
              <asp:ListItem Text="Select"></asp:ListItem><asp:ListItem Text="1" Value="1"></asp:ListItem>
              <asp:ListItem Text="2" Value="2"></asp:ListItem><asp:ListItem Text="3" Value="3"></asp:ListItem>
              <asp:ListItem Value="4">4</asp:ListItem><asp:ListItem Value="5">5</asp:ListItem>
              <asp:ListItem Value="6">6</asp:ListItem><asp:ListItem Value="7">7</asp:ListItem>
              <asp:ListItem Value="8">8</asp:ListItem><asp:ListItem Value="9">9</asp:ListItem>
              <asp:ListItem Value="10">10</asp:ListItem><asp:ListItem Value="11">11</asp:ListItem>
              <asp:ListItem Value="12">12</asp:ListItem><asp:ListItem Value="13">13</asp:ListItem>
              <asp:ListItem Value="14">14</asp:ListItem><asp:ListItem Value="15">15</asp:ListItem>
              <asp:ListItem Value="16">16</asp:ListItem><asp:ListItem Value="17">17</asp:ListItem>
              <asp:ListItem Value="18">18</asp:ListItem><asp:ListItem Value="19">19</asp:ListItem>
              <asp:ListItem Value="20">20</asp:ListItem><asp:ListItem Value="21">21</asp:ListItem>
              <asp:ListItem Value="22">22</asp:ListItem><asp:ListItem Value="23">23</asp:ListItem>
              <asp:ListItem Value="24">24</asp:ListItem><asp:ListItem Value="25">25</asp:ListItem>
              <asp:ListItem Value="26">26</asp:ListItem><asp:ListItem Value="27">27</asp:ListItem>
              <asp:ListItem Value="28">28</asp:ListItem><asp:ListItem Value="29">29</asp:ListItem>
              <asp:ListItem Value="30">30</asp:ListItem><asp:ListItem Value="31">31</asp:ListItem>
              <asp:ListItem Value="32">32</asp:ListItem><asp:ListItem Value="33">33</asp:ListItem>
              <asp:ListItem Value="34">34</asp:ListItem><asp:ListItem Value="35">35</asp:ListItem>
              <asp:ListItem Value="36">36</asp:ListItem><asp:ListItem Value="37">37</asp:ListItem>
              <asp:ListItem Value="38">38</asp:ListItem><asp:ListItem Value="39">39</asp:ListItem>
              <asp:ListItem Value="40">40</asp:ListItem><asp:ListItem Value="41">41</asp:ListItem>
              <asp:ListItem Value="42">42</asp:ListItem> <asp:ListItem Value="43">43</asp:ListItem>
              <asp:ListItem Value="44">44</asp:ListItem><asp:ListItem Value="45">45</asp:ListItem>
              <asp:ListItem Value="46">46</asp:ListItem> <asp:ListItem Value="47">47</asp:ListItem>
              <asp:ListItem Value="48">48</asp:ListItem><asp:ListItem Value="49">49</asp:ListItem>
              <asp:ListItem Value="50">50</asp:ListItem> <asp:ListItem Value="51">51</asp:ListItem>
              <asp:ListItem Value="52">52</asp:ListItem><asp:ListItem Value="53">53</asp:ListItem>
              <asp:ListItem Value="54">54</asp:ListItem> <asp:ListItem Value="55">55</asp:ListItem>
              <asp:ListItem Value="56">56</asp:ListItem><asp:ListItem Value="57">57</asp:ListItem>
              <asp:ListItem Value="58">58</asp:ListItem> <asp:ListItem Value="59">59</asp:ListItem>
              <asp:ListItem Value="60">60</asp:ListItem> <asp:ListItem Value="62">62</asp:ListItem>
           
	      <asp:ListItem Value="64">64</asp:ListItem> <asp:ListItem Value="66">66</asp:ListItem>
              <asp:ListItem Value="68">68</asp:ListItem> <asp:ListItem Value="70">70</asp:ListItem>
              <asp:ListItem Value="72">72</asp:ListItem> <asp:ListItem Value="74">74</asp:ListItem>
              <asp:ListItem Value="76">76</asp:ListItem> <asp:ListItem Value="78">78</asp:ListItem>
              <asp:ListItem Value="80">80</asp:ListItem> <asp:ListItem Value="82">82</asp:ListItem>
              <asp:ListItem Value="84">84</asp:ListItem> <asp:ListItem Value="86">86</asp:ListItem> 
              <asp:ListItem Value="88">88</asp:ListItem> <asp:ListItem Value="90">90</asp:ListItem> 
              <asp:ListItem Value="92">92</asp:ListItem> <asp:ListItem Value="94">94</asp:ListItem>
              <asp:ListItem Value="96">96</asp:ListItem> <asp:ListItem Value="98">98</asp:ListItem>
              <asp:ListItem Value="100">100</asp:ListItem> <asp:ListItem Value="102">102</asp:ListItem> 
              <asp:ListItem Value="104">104</asp:ListItem> <asp:ListItem Value="106">106</asp:ListItem> 
              <asp:ListItem Value="108">108</asp:ListItem> <asp:ListItem Value="110">110</asp:ListItem> 
              <asp:ListItem Value="112">112</asp:ListItem> <asp:ListItem Value="114">114</asp:ListItem> 
              <asp:ListItem Value="116">116</asp:ListItem> <asp:ListItem Value="118">118</asp:ListItem> 
              <asp:ListItem Value="120">120</asp:ListItem> <asp:ListItem Value="135">135</asp:ListItem> 
	      <asp:ListItem Value="136">136</asp:ListItem>  <asp:ListItem Value="180">180</asp:ListItem> 
              
              </asp:DropDownList></td></tr>
     
     <tr><td><asp:Label ID="Label13" runat="server" Text="Loading beyond CC in ton"></asp:Label>
     </td><td><asp:DropDownList ID="DDGoodsCC" Width="160px" runat="server">
              <asp:ListItem Text="Select"></asp:ListItem>
            <%--  arti--%>
<%--              
<asp:ListItem Text="0" Value="0"></asp:ListItem>
<asp:ListItem Text="2" Value="2"></asp:ListItem><asp:ListItem Text="4" Value="4"></asp:ListItem>
              <asp:ListItem Text="6" Value="6"></asp:ListItem><asp:ListItem Text="8" Value="8"></asp:ListItem> 
              <asp:ListItem Text="10" Value="10"></asp:ListItem><asp:ListItem Text="12" Value="12"></asp:ListItem>
              <asp:ListItem Text="14" Value="14"></asp:ListItem><asp:ListItem Text="16" Value="16"></asp:ListItem> 
              <asp:ListItem Text="18" Value="18"></asp:ListItem><asp:ListItem Text="20" Value="20"></asp:ListItem> 
 --%>  </asp:DropDownList></td></tr>
   
     <tr><td><asp:Label ID="Label14" runat="server" Text="BC Pressure of Loco in kg/sq.cm"></asp:Label>
     </td><td><asp:DropDownList ID="DDGoodsBCPressure" Width="160px" runat="server" AutoPostBack="True">
              <asp:ListItem Text="Select"></asp:ListItem><asp:ListItem Text="Other"></asp:ListItem><asp:ListItem Text="0.5" Value="0.5"></asp:ListItem>
              <asp:ListItem Text="1.0" Value="1.0"></asp:ListItem><asp:ListItem Text="1.2" Value="1.2"></asp:ListItem>
              <asp:ListItem Text="1.4" Value="1.4"></asp:ListItem><asp:ListItem Text="1.6" Value="1.6"></asp:ListItem> 
              <asp:ListItem Text="1.8" Value="1.8"></asp:ListItem><asp:ListItem Text="2.0" Value="2.0"></asp:ListItem>
              <asp:ListItem Text="2.5" Value="2.5"></asp:ListItem><asp:ListItem Text="3.0" Value="3.0"></asp:ListItem> 
              <asp:ListItem Text="3.5" Value="3.5"></asp:ListItem><asp:ListItem Text="4.0" Value="4.0"></asp:ListItem> 
              <asp:ListItem Text="4.4" Value="4.4"></asp:ListItem><asp:ListItem Text="4.5" Value="4.5"></asp:ListItem> 
              <asp:ListItem Text="5.0" Value="5.0"></asp:ListItem>
     </asp:DropDownList><br /> <asp:TextBox ID="txtGoodsBCPressure" runat="server" Visible="False"></asp:TextBox></td></tr>
     
    

     <tr><td><asp:Label ID="Label15" runat="server" Text="Percentage Brake Power"></asp:Label>
     </td><td><asp:DropDownList ID="DDGoodsBrakePower" Width="160px" runat="server" AutoPostBack="True" >
              <asp:ListItem Text="Select"></asp:ListItem><asp:ListItem Text="Other"></asp:ListItem><asp:ListItem Text="100" Value="100"></asp:ListItem>
              <asp:ListItem Text="95" Value="95"></asp:ListItem><asp:ListItem Text="90" Value="90"></asp:ListItem>
              <asp:ListItem Text="85" Value="85"></asp:ListItem><asp:ListItem Text="80" Value="80"></asp:ListItem> 
              <asp:ListItem Text="75" Value="75"></asp:ListItem>
     </asp:DropDownList><br /> <asp:TextBox ID="txtGoodsBrakePower" runat="server" Visible="False"></asp:TextBox></td></tr>

 <tr><td><asp:Label ID="Label16" runat="server" Text="Speed in kmph"></asp:Label>
     </td><td><asp:DropDownList ID="DDGoodsSpeed" Width="160px" runat="server" AutoPostBack="True">
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
              <asp:ListItem Text="100" Value="100"></asp:ListItem>
     </asp:DropDownList><br /> <asp:TextBox ID="txtGoodsSpeed" runat="server" Visible="False"></asp:TextBox></td></tr>

     <tr><td><asp:Label ID="Label17" runat="server" Text="Grade"></asp:Label>
     </td><td><asp:DropDownList ID="DDGoodsGrade" Width="160px" runat="server" AutoPostBack="True">
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
            </asp:DropDownList><br /> <asp:TextBox ID="txtGoodsGrade" runat="server" Visible="False"></asp:TextBox></td></tr>
              
      <tr><td colspan="2" align="right">
          <asp:Button ID="BtnGoods" runat="server" Text="Calculate EBD" />
              

          </td></tr>

   </table> 

<%--  Panel Goods Started --%> 

<asp:Panel ID="PanelGoods" runat="server" BorderStyle="Solid" BorderWidth="1px" Height="335px"
         Style="left: 560px; top:178px; position:absolute ; " Width="430px">
      <table  cellspacing="4" style="background-color:#FFCCCC; border-color:#CCCCCC; border-width:thin; margin-left:0%" width="100%">
    <tr>
                <td colspan="2" style=" background-color:#FFFFCC">
                    <asp:Label ID="Label18" runat="server" Text="Emergency Brake Distance (EBD)"></asp:Label>
     </td> 
     </tr>
      <tr>
                <td style="width:260px">
                    <asp:Label ID="Label19" runat="server" Text="Type of Locomotive"></asp:Label>
     </td> 
                     <td style="width:160px">
                         <asp:Label ID="LblGoodsLocoType" runat="server" Text=""></asp:Label>
                     </td> 
     </tr>
     <tr>
                    <td>
                    <asp:Label ID="Label20" runat="server" Text="No. of Locomotive"></asp:Label>
     </td> 
                     <td >
                         <asp:Label ID="LblGoodsNoOfLoco" runat="server" Text=""></asp:Label>
                     </td> 
     </tr>
     <tr>
                    <td >
                    <asp:Label ID="Label21" runat="server" Text="Type of Locomotive Brake Block"></asp:Label>
     </td> 
                     <td >
                         <asp:Label ID="LblGoodsLocoBrakeBlock" runat="server" Text=""></asp:Label>
                     </td> 
     </tr>
     <tr><td >
                    <asp:Label ID="Label22" runat="server" Text="Type of Stock"></asp:Label>
     </td><td >
                    <asp:Label ID="LblGoodsTypeOfStock" runat="server" Text=""></asp:Label>
     </td></tr>
     <tr><td >
                    <asp:Label ID="Label23" runat="server" Text="No.of Stock"></asp:Label>
     </td><td >
                    <asp:Label ID="LblGoodsNoOfStock" runat="server" Text=""></asp:Label>
     </td></tr>
     <tr><td >
                    <asp:Label ID="Label24" runat="server" Text="Loading Beyond CC in Tons"></asp:Label>
     </td><td >
                    <asp:Label ID="LblGoodsCC" runat="server" Text=""></asp:Label>
     </td></tr>
     <tr><td >
                    <asp:Label ID="Label25" runat="server" Text="BC Pressure of Locomotive"></asp:Label>
                    &nbsp;in kg/sq.cm</td><td >
                    <asp:Label ID="LblGoodsBCPressure" runat="server" Text=""></asp:Label>
     </td></tr>
     <tr><td >
                    <asp:Label ID="Label26" runat="server" Text="Percentage Brake Power"></asp:Label>
     </td><td >
                    <asp:Label ID="LblGoodsBrakePower" runat="server" Text=""></asp:Label>
     </td></tr>
     <tr><td >
                    <asp:Label ID="Label27" runat="server" Text="Speed"></asp:Label>
                    &nbsp;in kmph</td><td >
                    <asp:Label ID="LblGoodsSpeed" runat="server" Text=""></asp:Label>
     </td></tr>
     <tr><td >
                    <asp:Label ID="Label28" runat="server" Text="Grade"></asp:Label>
     </td><td >
                    <asp:Label ID="LblGoodsGrade" runat="server" Text=""></asp:Label>
     </td></tr>
     <tr><td style=" background-color:#FFFFCC" >
                    <asp:Label ID="Label29" runat="server" Text="Simulated EBD"></asp:Label>
                    &nbsp;in meter</td><td style=" background-color:#FFFFCC" >
                    <asp:Label ID="LblGoodsEBD" runat="server" Text=""></asp:Label>
     </td></tr>
<tr><td colspan="2" align="right">
    <asp:TextBox ID="txtTotalDistance" runat="server" Visible="false"></asp:TextBox>        
        <asp:TextBox ID="txtTime" runat="server" Visible="false"></asp:TextBox>        

          <asp:Button ID="BtnPrintGoodsEBD" runat="server" Text="Print View" 
        Visible="False" />
<asp:Button ID="BtnChart" runat="server" Text="Chart" Visible="False" />      </td></tr>

     </table>
     

</asp:Panel>
         
  
<%--  End of Goods View --%>    

</asp:Content>

