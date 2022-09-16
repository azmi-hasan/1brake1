Imports System.Data
Imports System.Data.Odbc
Partial Class goods
    Inherits System.Web.UI.Page
    Dim cmd As New OdbcCommand
    ''Dim con As OdbcConnection
    Dim con1 As OdbcConnection
    Dim cmd1 As New OdbcCommand
    Dim cmd2 As New OdbcCommand
    Dim adp As New OdbcDataAdapter
    Dim rd As OdbcDataReader
    Dim rd1 As OdbcDataReader
    Dim ds As New DataSet
    dim dr as datarow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
         con1 = New OdbcConnection("DRIVER={Microsoft Access Driver (*.mdb)};DBQ=c:\ebd_web_data\locodatabase.mdb;DefaultDir=;UID=;PWD=;")

        PanelGoods.Visible = False
        'BtnChart.Visible = False
        If Not IsPostBack Then

            cmd.Connection = con1
            cmd.CommandText = " Select locomotive from loco order by locomotive"  
            con1.Open()
            rd = cmd.ExecuteReader
            DDGoodsLocoType.Items.Add("Select")

            While rd.Read() = True
                DDGoodsLocoType.Items.Add(New ListItem(rd(0)))
            End While
            rd.Close()
            'arti
            'cmd.CommandText = " Select overloading,typeofwagon from wagon order by typeofwagon"
            cmd.CommandText = " Select typeofwagon from wagon order by typeofwagon"

            rd = cmd.ExecuteReader
            DDGoodsTypeOfStock.Items.Add("Select")

            While rd.Read() = True
                DDGoodsTypeOfStock.Items.Add(New ListItem(rd(0)))

                'DDGoodsTypeOfStock.Items.Add(New ListItem(rd(1), rd(0)))

                ' DDGoodsTypeOfStock.SelectedItem
            End While
            rd.Close()
            con1.Close()

        End If
    End Sub
    Protected Sub BtnGoods_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGoods.Click

        Dim LocoWeight As Double
        Dim LocoBrakePower As Double
        Dim LocoBrakeBlock As Double
        Dim LocoBrakeBlockArea As Double
        Dim LocoRRL1 As Double
        Dim LocoRRL2 As Double
        Dim LocoRRL3 As Double
        Dim LocoBCPressureForBP As Double
        Dim LocoNumber As Integer
        Dim SpecificShoePrLoco As Integer
        Dim StockWeight As Double
        Dim StockBrakePower As Double
        Dim StockRRL1 As Double
        Dim StockRRL2 As Double
        Dim StockRRL3 As Double
        Dim StockNumber As Integer
        Dim StockOverLoading As Integer
        Dim LocoBCPressure As Double
        Dim PercentageOperativeCylinder As Double
        Dim Speedkmph As Double
        Dim SKM As Double
        Dim DownGrade As Integer
        Dim EffectiveTrainWeight As Double
        Dim LocoBrakeDevTime As Integer
        Dim StockBrakeDevTime As Integer
        Dim LocoFriction As Double
        Dim StockFriction As Double
        Dim TimeLag1 As Integer
        Dim TimeLag2 As Integer
        Dim Velocity As Double
        Dim B1 As Double
        Dim B2 As Double
        Dim B3 As Double
        Dim Time As Integer
        Dim TL As Double
        Dim FL As Double
        Dim AKL As Double
        Dim TS As Double
        Dim FS As Double
        Dim AKS As Double
        Dim TotalBPloco As Double
        Dim BrakeEffortLoco As Double
        Dim TotalBPStock As Double
        Dim BrakeEffortStock As Double
        Dim RollingResistanceLoco As Double
        Dim RollingResistanceStock As Double
        Dim TotalBrakeEffort As Double
        Dim Retardation As Double
        Dim Distance As Double
        Dim TotalDistance As Double
        Dim FinalDistance As Integer
        Dim DownGradepull As Double
        If DDGoodsLocoType.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please Select Type of Locomotive');</script>")
        ElseIf DDGoodsNoOfLoco.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please Select No. of Locomotive');</script>")
        ElseIf DDGoodsLocoBrakeBlock.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please Loco Brake Block');</script>")
        ElseIf DDGoodsTypeOfStock.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please select Type of Stock');</script>")
        ElseIf DDGoodsNoOfStock.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please select Number of Stock');</script>")
        ElseIf DDGoodsCC.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please select Loading beyond CC');</script>")
        ElseIf DDGoodsBCPressure.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please select BC Pressure of Loco');</script>")
        ElseIf DDGoodsBrakePower.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please select Percentage Brake Power');</script>")
        ElseIf DDGoodsSpeed.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please select Speed');</script>")
        ElseIf DDGoodsGrade.Text = "Select" Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please Select Grade');</script>")
        ElseIf DDGoodsBCPressure.Text = "Other" And Val(txtGoodsBCPressure.Text) = 0 Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please select BC Pressure of Loco');</script>")
        ElseIf DDGoodsBrakePower.Text = "Other" And Val(txtGoodsBrakePower.Text) = 0 Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please select Percentage Brake Power');</script>")
        ElseIf DDGoodsSpeed.Text = "Other" And Val(txtGoodsSpeed.Text) = 0 Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please select Speed');</script>")
        ElseIf DDGoodsGrade.Text = "Other" And Val(txtGoodsGrade.Text) = 0 Then
            Page.RegisterStartupScript("onclick", "<Script language=javascript>alert('Please Select Grade');</script>")

        Else

            adp = New OdbcDataAdapter("Select Weight,Brakepower,numbrkblk,brkblkarea,X1,Y1,Z1,BCpressure from loco where locomotive='" + DDGoodsLocoType.Text + "'", con1)
            ds = New DataSet()
            adp.Fill(ds, "loco")

            If ds.Tables("loco").Rows.Count > 0 Then
                For Each dr In ds.Tables("loco").Rows
                    LocoWeight = dr("Weight")
                    LocoBrakePower = dr("Brakepower")
                    LocoBrakeBlock = dr("numbrkblk")
                    LocoBrakeBlockArea = dr("brkblkarea")
                    LocoRRL1 = dr("X1")
                    LocoRRL2 = dr("Y1")
                    LocoRRL3 = dr("Z1")
                    LocoBCPressureForBP = dr("BCpressure")
                Next
            End If
            LocoNumber = DDGoodsNoOfLoco.SelectedValue
            adp = New OdbcDataAdapter("Select Weight,Brakepower,X2,Y2,Z2 from wagon where typeofwagon='" + DDGoodsTypeOfStock.SelectedItem.Text + "'", con1)
            ds = New DataSet()
            adp.Fill(ds, "wagon")

            If ds.Tables("wagon").Rows.Count > 0 Then
                For Each dr In ds.Tables("wagon").Rows
                    StockWeight = dr("Weight")
                    StockBrakePower = dr("Brakepower")
                    StockRRL1 = dr("X2")
                    StockRRL2 = dr("Y2")
                    StockRRL3 = dr("Z2")
                Next
            End If
            StockNumber = DDGoodsNoOfStock.SelectedValue
            StockOverLoading = DDGoodsCC.SelectedValue
            If DDGoodsBCPressure.Text <> "Other" Then '010709
                LocoBCPressure = DDGoodsBCPressure.SelectedValue
            Else
                LocoBCPressure = Val(txtGoodsBCPressure.Text)
            End If

            If DDGoodsBrakePower.Text <> "Other" Then '010709
                PercentageOperativeCylinder = (DDGoodsBrakePower.SelectedValue) / 100
            Else
                PercentageOperativeCylinder = (Val(txtGoodsBrakePower.Text)) / 100
            End If

            If DDGoodsSpeed.Text <> "Other" Then '010709
                Speedkmph = DDGoodsSpeed.SelectedValue
            Else
                Speedkmph = Val(txtGoodsSpeed.Text)
            End If

            If DDGoodsGrade.Text <> "Other" Then '010709
                DownGrade = DDGoodsGrade.SelectedValue
            Else
                DownGrade = Val(txtGoodsGrade.Text)
            End If


            ' '' ''LocoBCPressure = DDGoodsBCPressure.SelectedValue
            ' '' ''PercentageOperativeCylinder = ((DDGoodsBrakePower.SelectedValue) / 100)
            ' '' ''Speedkmph = DDGoodsSpeed.SelectedValue
            ' '' ''DownGrade = (DDGoodsGrade.SelectedValue)

            'MsgBox("LocoNumber -" & LocoNumber & "  LocoBCPressure- " & LocoBCPressure & "  SpeedKmph -" & Speedkmph & "  DownGrade -" & DownGrade)

            'calculation of EBD
            StockWeight = StockWeight + (StockOverLoading * 1000)
            EffectiveTrainWeight = 1.05 * ((LocoWeight * LocoNumber) + (StockWeight * StockNumber))
            LocoBrakeDevTime = 20
            StockBrakeDevTime = 30
	    	if StockNumber > 62 then LocoBrakeDevTime = 9
            if StockNumber > 62 then StockBrakeDevTime = 41
		if StockNumber > 130 then StockBrakeDevTime = 53

            TimeLag1 = 1
            TimeLag2 = 3
            Velocity = Speedkmph / 3.6
            Do While Velocity > 0
                B1 = 0.16166666
                B2 = 0.0103125
                B3 = 0.0002865
                TL = Time - TimeLag1 + 2
                If TL < 0 Then TL = 0
                FL = TL * 13.5 / (LocoBrakeDevTime - TimeLag1)
                AKL = (B1 * FL - B2 * FL * FL + B3 * FL * FL * FL)
                If AKL > 1 Then AKL = 1
                TS = Time - TimeLag2 + 2
                If TS < 0 Then TS = 0
                FS = TS * 13.5 / (StockBrakeDevTime - TimeLag2)
                AKS = B1 * FS - B2 * FS * FS + B3 * FS * FS * FS
                If AKS > 1 Then AKS = 1
                'LocoFriction = 0.17
                If (DDGoodsLocoBrakeBlock.SelectedItem.Text) = "Cast Iron" Then GoTo 150
                If (DDGoodsLocoBrakeBlock.SelectedItem.Text) = "L Type Composition" Then LocoFriction = 0.17
                If (DDGoodsLocoBrakeBlock.SelectedItem.Text) = "High Friction" Then LocoFriction = 0.25
                GoTo 160
150:            Speedkmph = Velocity * 3.6
                SKM = Speedkmph
                SpecificShoePrLoco = (LocoBrakePower * 0.85) / (LocoBrakeBlock * LocoBrakeBlockArea)
                If SpecificShoePrLoco < 6 Then SpecificShoePrLoco = 6
                If SpecificShoePrLoco > 12 Then SpecificShoePrLoco = 12
                If SpecificShoePrLoco = 6 Then GoTo 200
                If SpecificShoePrLoco = 7 Then GoTo 210
                If SpecificShoePrLoco = 8 Then GoTo 220
                If SpecificShoePrLoco = 9 Then GoTo 230
                If SpecificShoePrLoco = 10 Then GoTo 240
                If SpecificShoePrLoco = 11 Then GoTo 250
                If SpecificShoePrLoco = 12 Then GoTo 260
200:            If SKM >= 75 Then GoTo 2003
                If SKM >= 35 Then GoTo 2001
                If SKM < 35 Then GoTo 2002
2003:           LocoFriction = 1.04
                GoTo 160
2001:           LocoFriction = (0.3 + 1.70597654345651 * SKM - 0.217999971250967 * SKM * SKM + _
          0.0117817847707845 * SKM * SKM * SKM - 0.0003503704351204 * SKM * SKM * SKM * SKM + _
          0.0000061966868687 * SKM * SKM * SKM * SKM * SKM - 0.0000000652052836 * SKM * SKM * SKM * _
          SKM * SKM * SKM + 0.0000000003781108 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000009324 _
          * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                GoTo 160
2002:           LocoFriction = (0.3 - 0.0141178325123153 * SKM + 0.0004007290640394 * SKM * _
          SKM + 0.0000090214559387 * SKM * SKM * SKM - 0.0000009777011494 * SKM * SKM * SKM * SKM + _
          0.0000000155708812 * SKM * SKM * SKM * SKM * SKM + 0.0000000004229885 * SKM * SKM * SKM * SKM * _
          SKM * SKM - 0.0000000000124357 * SKM * SKM * SKM * SKM * SKM * SKM * SKM + 0.0000000000000525 * SKM * _
          SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                GoTo 160
210:            If SKM >= 75 Then GoTo 2103
                If SKM >= 35 Then GoTo 2101
                If SKM < 35 Then GoTo 2102
2103:           LocoFriction = 0.098
                GoTo 160
2101:           LocoFriction = (0.3 + 1.70510609723624 * SKM - 0.217945068720181 * SKM * SKM _
          + 0.0117798181248387 * SKM * SKM * SKM - 0.0003503266726237 * SKM * SKM * SKM * SKM _
          + 0.0000061960673401 * SKM * SKM * SKM * SKM * SKM - 0.0000000651998342 * SKM * SKM * SKM * _
          SKM * SKM * SKM + 0.0000000003780835 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000009323 * _
          SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                GoTo 160
2102:           LocoFriction = (0.3 - 0.021561330049261 * SKM + 0.0026047495894909 * SKM * SKM - _
          0.0002787030651341 * SKM * SKM * SKM + 0.0000181953065134 * SKM * SKM * SKM * SKM - _
          0.000000642605364 * SKM * SKM * SKM * SKM * SKM + 0.0000000105363985 * SKM * SKM * SKM * _
          SKM * SKM * SKM - 0.000000000031965 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - _
          0.0000000000006787 * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                GoTo 160
220:            If SKM >= 75 Then GoTo 2203
                If SKM >= 35 Then GoTo 2201
                If SKM < 35 Then GoTo 2202
2203:           LocoFriction = 0.092
                GoTo 160
2201:           LocoFriction = (0.3 + 1.70423565101564 * SKM - 0.217890166189369 * SKM * SKM + _
          0.0117778514788917 * SKM * SKM * SKM - 0.0003502829101269 * SKM * SKM * SKM * SKM + _
          0.0000061954478114 * SKM * SKM * SKM * SKM * SKM - 0.0000000651943849 * SKM * SKM * SKM * SKM _
          * SKM * SKM + 0.0000000003780563 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000009323 * SKM _
          * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                GoTo 160
2202:           LocoFriction = (0.3 - 0.0261124137931033 * SKM + 0.0032766469622331 * SKM * _
          SKM - 0.0003122137931034 * SKM * SKM * SKM + 0.0000182213793103 * SKM * SKM * SKM _
          * SKM - 0.0000005943908046 * SKM * SKM * SKM * SKM * SKM + 0.0000000092137931 * SKM * _
          SKM * SKM * SKM * SKM * SKM - 0.0000000000257471 * SKM * SKM * SKM * SKM * SKM * SKM _
          * SKM - 0.000000000000578 * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                GoTo 160
230:            If SKM >= 75 Then GoTo 2303
                If SKM >= 35 Then GoTo 2301
                If SKM < 35 Then GoTo 2302
2303:           LocoFriction = 0.086
                GoTo 160
2301:           LocoFriction = (0.3 + 1.70336520479522 * SKM - 0.217835263658568 * SKM * SKM _
          + 0.0117758848329451 * SKM * SKM * SKM - 0.0003502391476302 * SKM * SKM * SKM * _
          SKM + 0.0000061948282828 * SKM * SKM * SKM * SKM * SKM - 0.0000000651889355 * SKM * SKM * _
          SKM * SKM * SKM * SKM + 0.0000000003780291 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - _
          0.0000000000009322 * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                GoTo 160
2302:           LocoFriction = (0.3 - 0.0350428078817735 * SKM + 0.0061845295566502 * SKM * _
          SKM - 0.0007227459770115 * SKM * SKM * SKM + 0.0000476529310345 * SKM * SKM * SKM * SKM _
          - 0.0000016844137931 * SKM * SKM * SKM * SKM * SKM + 0.000000027645977 * SKM * SKM * SKM _
          * SKM * SKM * SKM - 0.0000000000832841 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000017997 _
          * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                GoTo 160
240:            If SKM >= 75 Then GoTo 2403
                If SKM >= 35 Then GoTo 2401
                If SKM < 35 Then GoTo 2402
2403:           LocoFriction = 0.08
                GoTo 160
2401:           LocoFriction = (0.3 - 5.84726968586961 * SKM + 0.747139572205568 * SKM * SKM _
          - 0.0406393079858413 * SKM * SKM * SKM + 0.0012185038988172 * SKM * SKM * SKM * _
          SKM - 0.0000217490011223 * SKM * SKM * SKM * SKM * SKM + 0.0000002311108348 * SKM * SKM _
          * SKM * SKM * SKM * SKM - 0.0000000013539488 * SKM * SKM * SKM * SKM * SKM * SKM * SKM + _
          0.000000000003374 * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                GoTo 160
2402:           LocoFriction = (0.3 - 0.0395938916256153 * SKM + 0.0068564269293924 * SKM * _
          SKM - 0.0007562567049808 * SKM * SKM * SKM + 0.0000476790038314 * SKM * SKM * SKM * SKM _
          - 0.0000016361992337 * SKM * SKM * SKM * SKM * SKM + 0.0000000263233716 * SKM * SKM * SKM * _
          SKM * SKM * SKM - 0.0000000000770662 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - _
          0.000000000001699 * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                GoTo 160
250:            If SKM >= 75 Then GoTo 2503
                If SKM > 35 Then GoTo 2501
                If SKM < 35 Then GoTo 2502
2503:           LocoFriction = 0.076
                GoTo 160
2501:           LocoFriction = (0.3 - 0.199231560661529 * SKM + 0.0203851445776407 * SKM * SKM _
          - 0.0008760435206766 * SKM * SKM * SKM + 0.0000192389946473 * SKM * SKM * SKM * SKM - _
          0.0000002145095398 * SKM * SKM * SKM * SKM * SKM + 0.0000000008762842 * SKM * SKM * SKM * SKM * _
          SKM * SKM + 0.0000000000032303 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000000291 * SKM * SKM _
          * SKM * SKM * SKM * SKM * SKM * SKM)
                GoTo 160
2502:           LocoFriction = (0.3 - 0.0426580788177338 * SKM + 0.0068244622331691 * SKM * _
          SKM - 0.0006669597701149 * SKM * SKM * SKM + 0.0000374465325671 * SKM * SKM * SKM * SKM _
          - 0.000001156137931 * SKM * SKM * SKM * SKM * SKM + 0.0000000166819923 * SKM * SKM * SKM * _
          SKM * SKM * SKM - 0.0000000000328407 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000011078 * _
          SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                GoTo 160
260:            If SKM >= 75 Then GoTo 2603
                If SKM >= 35 Then GoTo 2601
                If SKM < 35 Then GoTo 2602
2603:           LocoFriction = 0.07
                GoTo 160
2601:           LocoFriction = (0.3 - 0.200102006881999 * SKM + 0.0204400471084461 * SKM * SKM _
          - 0.0008780101666234 * SKM * SKM * SKM + 0.0000192827571441 * SKM * SKM * SKM * SKM - _
          0.0000002151290685 * SKM * SKM * SKM * SKM * SKM + 0.0000000008817336 * SKM * SKM * SKM * SKM * _
          SKM * SKM + 0.0000000000032031 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.000000000000029 * _
          SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                GoTo 160
2602:           LocoFriction = (0.3 - 0.0472091625615763 * SKM + 0.0074963596059113 * SKM * _
          SKM - 0.0007004704980843 * SKM * SKM * SKM + 0.000037472605364 * SKM * SKM * SKM * SKM _
          - 0.0000011079233716 * SKM * SKM * SKM * SKM * SKM + 0.000000015359387 * SKM * SKM * SKM _
          * SKM * SKM * SKM - 0.0000000000266229 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000010071 _
          * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
                GoTo 160
160:            TotalBPloco = (LocoBrakePower * LocoNumber * 0.85 * LocoFriction * LocoBCPressure) / LocoBCPressureForBP
                BrakeEffortLoco = TotalBPloco
                StockFriction = 0.17
                If (DDGoodsTypeOfStock.Text) = "BOXNHLCONVEMPTY" Then GoTo 80
                If (DDGoodsTypeOfStock.Text) = "BOXNHLCONVLOADED" Then GoTo 80
                If (DDGoodsTypeOfStock.Text) = "BCNHLEMPTY" Then GoTo 80 'new
                If (DDGoodsTypeOfStock.Text) = "BCNHLLOADED" Then GoTo 80 'new
                If (DDGoodsTypeOfStock.Text) = "BCNAHSM1EMPTYBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BCNAHSM1LOADEDBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOSTHSM2EMPTYBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOSTHSM2LOADEDBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOXNHLMBSEMPTY" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOXNHLMBSLOADED" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BTPNEMPTYBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BTPNLOADEDBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BTPGLNEMPTYBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BTPGLNLOADEDBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOBYNEMPTYBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOBYNLOADEDBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOBRNHSM1EMPTYBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOBRNHSM1LOADEDBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BRN22.9EMPTYBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BRN22.9LOADEDBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BRNNEHSEMPTYBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BRNNEHSLOADEDBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOYEMPTYBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOYLOADEDBMBS" Then GoTo 80 'new
	      If (DDGoodsTypeOfStock.Text) = "BOXN25MEMPTY" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BOXN25MLOADED" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BCFCEMPTY" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BCFCLOADED" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BLC25MEMPTY" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BLC25MLOADED" Then GoTo 80 'new
                If (DDGoodsTypeOfStock.Text) = "BCNHLEMPTYLOADED" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BTFLNEMPTY" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BTFLNLOADED" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "GONDOLA25TEMPTY" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "GONDOLA25TLOADED" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BCLHLOADED" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BAFRDREMPTY" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BAFRDRLOADED" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BOXNHL25TEMPTY" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BOXNHL25TLOADED" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BOXN25TEMPTY" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BOXN25TLOADED" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BOXNS25TEMPTY" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BOXNS25TLOADED" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BFNSM22.9EMPTY" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BFNSM22.9LOADED" Then GoTo 80 'new
                If (DDGoodsTypeOfStock.Text) = "BCFCMEMPTY" Then GoTo 80 'new      
                If (DDGoodsTypeOfStock.Text) = "BCFCMLOADED" Then GoTo 80 'new
                If (DDGoodsTypeOfStock.Text) = "BOXNS22.9EMPTY" Then GoTo 80 'new      
                If (DDGoodsTypeOfStock.Text) = "BOXNS22.9LOADED" Then GoTo 80 'new
                If (DDGoodsTypeOfStock.Text) = "BOYEL25TEMPTY" Then GoTo 80 'new      
                If (DDGoodsTypeOfStock.Text) = "BOYEL25TLOADED" Then GoTo 80 'new
                If (DDGoodsTypeOfStock.Text) = "BOSTHSM3EMPTY" Then GoTo 80 'new      
                If (DDGoodsTypeOfStock.Text) = "BOSTHSM3LOADED" Then GoTo 80 'new
                If (DDGoodsTypeOfStock.Text) = "BOBSNS22.9EMPTY" Then GoTo 80 'new      
                If (DDGoodsTypeOfStock.Text) = "BOBSNS22.9LOADED" Then GoTo 80 'new
                If (DDGoodsTypeOfStock.Text) = "BOBSNS25TEMPTY" Then GoTo 80 'new      
                If (DDGoodsTypeOfStock.Text) = "BOBSNS25TLOADED" Then GoTo 80 'new
                If (DDGoodsTypeOfStock.Text) = "BRN22.9M1EMPTY" Then GoTo 80 'new      
                If (DDGoodsTypeOfStock.Text) = "BRN22.9M1LOADED" Then GoTo 80 'new
                If (DDGoodsTypeOfStock.Text) = "BOBYNHSM1EMPTY" Then GoTo 80 'new      
                If (DDGoodsTypeOfStock.Text) = "BOBYNHSM1LOADED" Then GoTo 80 'new
                If (DDGoodsTypeOfStock.Text) = "BTFLNM1EMPTY" Then GoTo 80 'new      
                If (DDGoodsTypeOfStock.Text) = "BTFLNM1LOADED" Then GoTo 80 'new
                If (DDGoodsTypeOfStock.Text) = "BTFLNM1EMPTY" Then GoTo 80 'new    
                If (DDGoodsTypeOfStock.Text) = "BTFLNM1LOADED" Then GoTo 80 'new
                If (DDGoodsTypeOfStock.Text) = "BOBSNDBEMPTY" Then GoTo 80 'new      
                If (DDGoodsTypeOfStock.Text) = "BOBSNDBLOADED" Then GoTo 80 'new
                If (DDGoodsTypeOfStock.Text) = "BFNVEMPTY" Then GoTo 80 'new      
                If (DDGoodsTypeOfStock.Text) = "BFNVLOADED" Then GoTo 80 'new
                If (DDGoodsTypeOfStock.Text) = "BOBRNHSM2EMPTY" Then GoTo 80 'new      
                If (DDGoodsTypeOfStock.Text) = "BOBRNHSM2LOADED" Then GoTo 80 'new
                If (DDGoodsTypeOfStock.Text) = "BTFLNM1EMPTY" Then GoTo 80 'new      
                If (DDGoodsTypeOfStock.Text) = "BTFLNM1LOADED" Then GoTo 80 'new
                If (DDGoodsTypeOfStock.Text) = "BFNSM1EMPTY" Then GoTo 80 'new      
                If (DDGoodsTypeOfStock.Text) = "BFNSM1LOADED" Then GoTo 80 'new
                If (DDGoodsTypeOfStock.Text) = "BCDSEMPTY" Then GoTo 80 'new      
                If (DDGoodsTypeOfStock.Text) = "BCDSLOADED" Then GoTo 80 'new
                If (DDGoodsTypeOfStock.Text) = "BTFCEMPTY" Then GoTo 80 'new      
                If (DDGoodsTypeOfStock.Text) = "BTFCLOADED" Then GoTo 80 'new
                If (DDGoodsTypeOfStock.Text) = "BCPVNEMPTY" Then GoTo 80 'new      
                If (DDGoodsTypeOfStock.Text) = "BCPVNLOADED" Then GoTo 80 'new
                If (DDGoodsTypeOfStock.Text) = "BCNAHSM1KEMPTY" Then GoTo 80 'new      
                If (DDGoodsTypeOfStock.Text) = "BCNAHSM1KLOADED" Then GoTo 80 'new
                If (DDGoodsTypeOfStock.Text) = "BCATICEMPTY" Then GoTo 80 'new      
                If (DDGoodsTypeOfStock.Text) = "BCATICLOADED" Then GoTo 80 'new

                GoTo 90
80: 		    Speedkmph = Velocity * 3.6
                If Speedkmph < 40 Then StockFriction = 0.27
                If Speedkmph > 40 Then StockFriction = 0.23
                GoTo 90
90:             TotalBPStock = StockBrakePower * StockNumber * 0.72 * StockFriction * PercentageOperativeCylinder
                BrakeEffortStock = TotalBPStock
                If Time <= LocoBrakeDevTime Then GoTo 30
                GoTo 40
30:             BrakeEffortLoco = TotalBPloco * AKL
40:             If Time <= StockBrakeDevTime Then GoTo 50
                GoTo 60
50:             BrakeEffortStock = TotalBPStock * AKS
60:             RollingResistanceLoco = ((LocoRRL1 + LocoRRL2 * Speedkmph + LocoRRL3 * Speedkmph * Speedkmph) * LocoWeight * LocoNumber) / 1000
                RollingResistanceStock = ((StockRRL1 + StockRRL2 * Speedkmph + StockRRL3 * Speedkmph * Speedkmph) * StockWeight * StockNumber) / 1000
                DownGradepull = EffectiveTrainWeight / (DownGrade * 1.05)
                If DownGrade >= 500 Then DownGradepull = 0
                TotalBrakeEffort = BrakeEffortLoco + BrakeEffortStock + RollingResistanceLoco + RollingResistanceStock + DownGradepull 'new
                Retardation = TotalBrakeEffort * 9.81 / EffectiveTrainWeight
                Distance = Velocity - 0.5 * Retardation
                TotalDistance = TotalDistance + Distance
                Velocity = Velocity - Retardation
                Time = Time + 1
                Speedkmph = Velocity * 3.6
                'List1.AddItem("SPEED " + Str(Speedkmph) + " time " + Str(Speedkmph) + " distance " + Str(LocoFriction))


            Loop

            '            If dist > 3000 Then MsgBox("EBD is more than 3000 m")
            '            If dist < 3000 Then GoTo 70
            '            End
            '70:         EBD.Text = TotalDistance
            txtTime.Text = Time
            txtTotalDistance.Text = TotalDistance
            FinalDistance = Val(TotalDistance)

            PanelGoods.Visible = True
            LblGoodsLocoType.Text = DDGoodsLocoType.Text
            LblGoodsNoOfLoco.Text = DDGoodsNoOfLoco.Text
            LblGoodsLocoBrakeBlock.Text = DDGoodsLocoBrakeBlock.SelectedItem.Text
            LblGoodsTypeOfStock.Text = DDGoodsTypeOfStock.SelectedItem.Text
            LblGoodsNoOfStock.Text = DDGoodsNoOfStock.Text
            LblGoodsCC.Text = DDGoodsCC.SelectedItem.Text
            If DDGoodsBCPressure.Text <> "Other" Then '010709
                LblGoodsBCPressure.Text = DDGoodsBCPressure.Text
            Else
                LblGoodsBCPressure.Text = Val(txtGoodsBCPressure.Text)
            End If
            If DDGoodsBrakePower.Text <> "Other" Then '010709
                LblGoodsBrakePower.Text = DDGoodsBrakePower.Text
            Else
                LblGoodsBrakePower.Text = Val(txtGoodsBrakePower.Text)
            End If

            If DDGoodsSpeed.Text <> "Other" Then '010709
                LblGoodsSpeed.Text = DDGoodsSpeed.Text
            Else
                LblGoodsSpeed.Text = Val(txtGoodsSpeed.Text)
            End If

            If DDGoodsGrade.Text <> "Other" Then '010709
                LblGoodsGrade.Text = DDGoodsGrade.Text
            Else
                LblGoodsGrade.Text = Val(txtGoodsGrade.Text)
            End If

            LblGoodsEBD.Text = FinalDistance
        End If
    End Sub

    Protected Sub DDGoodsLocoType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDGoodsLocoType.SelectedIndexChanged
        If DDGoodsLocoType.SelectedItem.Text = "WDG4" Or DDGoodsLocoType.SelectedItem.Text = "WDP4" Or DDGoodsLocoType.SelectedItem.Text = "WDAP5" Or DDGoodsLocoType.SelectedItem.Text = "WAG12B" Or DDGoodsLocoType.SelectedItem.Text = "WAP5" _
          Or DDGoodsLocoType.SelectedItem.Text = "WDP4B" Or DDGoodsLocoType.SelectedItem.Text = "WDG4G" Or DDGoodsLocoType.SelectedItem.Text = "WAG11" Or DDGoodsLocoType.SelectedItem.Text = "WDG6G" Or DDGoodsLocoType.SelectedItem.Text = "WDP4DD" Or DDGoodsLocoType.SelectedItem.Text = "WDG5" Or DDGoodsLocoType.SelectedItem.Text = "WDG4D" Or DDGoodsLocoType.SelectedItem.Text = "WDAP5" Then
            DDGoodsLocoBrakeBlock.Items.Clear()
            DDGoodsLocoBrakeBlock.Items.Add("Select")
            DDGoodsLocoBrakeBlock.Items.Add(New ListItem("High Friction", "3"))
        ElseIf DDGoodsLocoType.SelectedItem.Text = "WAG9" Or DDGoodsLocoType.SelectedItem.Text = "WAG9H" Or DDGoodsLocoType.SelectedItem.Text = "WAP7" Or DDGoodsLocoType.SelectedItem.Text = "WAP7HS" Or DDGoodsLocoType.SelectedItem.Text = "WAP7CONV" Then
            DDGoodsLocoBrakeBlock.Items.Clear()
            DDGoodsLocoBrakeBlock.Items.Add("Select")
            DDGoodsLocoBrakeBlock.Items.Add(New ListItem("Cast Iron", "1"))
            DDGoodsLocoBrakeBlock.Items.Remove("Cast Iron")
        Else
            DDGoodsLocoBrakeBlock.Items.Clear()
            DDGoodsLocoBrakeBlock.Items.Add("Select")
            DDGoodsLocoBrakeBlock.Items.Add(New ListItem("Cast Iron", "1"))
            DDGoodsLocoBrakeBlock.Items.Add(New ListItem("L Type Composition", "2"))
        End If
    End Sub
    Protected Sub BtnPrintGoodsEBD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPrintGoodsEBD.Click
        Response.Redirect("goods_Report.aspx?RptGoodsLocoType=" + LblGoodsLocoType.Text + "&RptGoodsNoOfLoco=" + LblGoodsNoOfLoco.Text + "&RptGoodsLocoBrakeBlock=" + LblGoodsLocoBrakeBlock.Text + "&RptGoodsTypeOfStock=" + LblGoodsTypeOfStock.Text + "&RptGoodsNoOfStock=" + LblGoodsNoOfStock.Text + "&RptGoodsCC=" + LblGoodsCC.Text + "&RptGoodsBCPressure=" + LblGoodsBCPressure.Text + "&RptGoodsBrakePower=" + LblGoodsBrakePower.Text + "&RptGoodsSpeed=" + LblGoodsSpeed.Text + "&RptGoodsGrade=" + LblGoodsGrade.Text + "&RptGoodsEBD=" + LblGoodsEBD.Text)
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("menu.aspx")
    End Sub

    'arti
    Protected Sub DDGoodsTypeOfStock_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDGoodsTypeOfStock.SelectedIndexChanged
        Dim overloading1 As Integer
        adp = New OdbcDataAdapter("Select overloading from wagon where typeofwagon='" + DDGoodsTypeOfStock.SelectedItem.Text + "'", con1)
        ds = New DataSet()
        adp.Fill(ds, "wagon")

        If ds.Tables("wagon").Rows.Count > 0 Then
            For Each dr In ds.Tables("wagon").Rows
                overloading1 = dr("overloading")
            Next
        End If
        If overloading1 = "1" Then

             DDGoodsCC.Items.Clear()
            DDGoodsCC.Items.Add("Select")
            DDGoodsCC.Items.Add(New ListItem("0", "0"))
         ElseIf overloading1 = "0" Then

            DDGoodsCC.Items.Clear()
            DDGoodsCC.Items.Add("Select")
            DDGoodsCC.Items.Add(New ListItem("0", "0"))
            DDGoodsCC.Items.Add(New ListItem("2", "2"))
            DDGoodsCC.Items.Add(New ListItem("4", "4"))
            DDGoodsCC.Items.Add(New ListItem("6", "6"))
            DDGoodsCC.Items.Add(New ListItem("8", "8"))
            DDGoodsCC.Items.Add(New ListItem("10", "10"))
            DDGoodsCC.Items.Add(New ListItem("12", "12"))
            DDGoodsCC.Items.Add(New ListItem("14", "14"))
            DDGoodsCC.Items.Add(New ListItem("16", "16"))
            DDGoodsCC.Items.Add(New ListItem("18", "18"))
            DDGoodsCC.Items.Add(New ListItem("20", "20"))
         End If

    End Sub

    Protected Sub BtnChart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnchart.Click
        Dim LocoWeight As Double
        Dim LocoBrakePower As Double
        Dim LocoBrakeBlock As Double
        Dim LocoBrakeBlockArea As Double
        Dim LocoRRL1 As Double
        Dim LocoRRL2 As Double
        Dim LocoRRL3 As Double
        Dim LocoBCPressureForBP As Double
        Dim LocoNumber As Integer
        Dim SpecificShoePrLoco As Integer
        Dim StockWeight As Double
        Dim StockBrakePower As Double
        Dim StockRRL1 As Double
        Dim StockRRL2 As Double
        Dim StockRRL3 As Double
        Dim StockNumber As Integer
        Dim StockOverLoading As Integer
        Dim LocoBCPressure As Double
        Dim PercentageOperativeCylinder As Double
        Dim Speedkmph As Double
        Dim SKM As Double
        Dim DownGrade As Integer
        Dim EffectiveTrainWeight As Double
        Dim LocoBrakeDevTime As Integer
        Dim StockBrakeDevTime As Integer
        Dim LocoFriction As Double
        Dim StockFriction As Double
        Dim TimeLag1 As Integer
        Dim TimeLag2 As Integer
        Dim Velocity As Double
        Dim B1 As Double
        Dim B2 As Double
        Dim B3 As Double
        Dim Time As Integer
        Dim TL As Double
        Dim FL As Double
        Dim AKL As Double
        Dim TS As Double
        Dim FS As Double
        Dim AKS As Double
        Dim TotalBPloco As Double
        Dim BrakeEffortLoco As Double
        Dim TotalBPStock As Double
        Dim BrakeEffortStock As Double
        Dim RollingResistanceLoco As Double
        Dim RollingResistanceStock As Double
        Dim TotalBrakeEffort As Double
        Dim Retardation As Double
        Dim Distance As Double
        Dim TotalDistance As Double
        Dim DownGradepull As Double
        adp = New OdbcDataAdapter("Select Weight,Brakepower,numbrkblk,brkblkarea,X1,Y1,Z1,BCpressure from loco where locomotive='" + DDGoodsLocoType.Text + "'", con1)
        ds = New DataSet()
        adp.Fill(ds, "loco")

        If ds.Tables("loco").Rows.Count > 0 Then
            For Each dr In ds.Tables("loco").Rows
                LocoWeight = dr("Weight")
                LocoBrakePower = dr("Brakepower")
                LocoBrakeBlock = dr("numbrkblk")
                LocoBrakeBlockArea = dr("brkblkarea")
                LocoRRL1 = dr("X1")
                LocoRRL2 = dr("Y1")
                LocoRRL3 = dr("Z1")
                LocoBCPressureForBP = dr("BCpressure")
            Next
        End If
        LocoNumber = DDGoodsNoOfLoco.SelectedValue
        adp = New OdbcDataAdapter("Select Weight,Brakepower,X2,Y2,Z2 from wagon where typeofwagon='" + DDGoodsTypeOfStock.SelectedItem.Text + "'", con1)
        ds = New DataSet()
        adp.Fill(ds, "wagon")

        If ds.Tables("wagon").Rows.Count > 0 Then
            For Each dr In ds.Tables("wagon").Rows
                StockWeight = dr("Weight")
                StockBrakePower = dr("Brakepower")
                StockRRL1 = dr("X2")
                StockRRL2 = dr("Y2")
                StockRRL3 = dr("Z2")
            Next
        End If
        StockNumber = DDGoodsNoOfStock.SelectedValue
        StockOverLoading = DDGoodsCC.SelectedValue
        If DDGoodsBCPressure.Text <> "Other" Then '010709
            LocoBCPressure = DDGoodsBCPressure.SelectedValue
        Else
            LocoBCPressure = Val(txtGoodsBCPressure.Text)
        End If

        If DDGoodsBrakePower.Text <> "Other" Then '010709
            PercentageOperativeCylinder = (DDGoodsBrakePower.SelectedValue) / 100
        Else
            PercentageOperativeCylinder = (Val(txtGoodsBrakePower.Text)) / 100
        End If

        If DDGoodsSpeed.Text <> "Other" Then '010709
            Speedkmph = DDGoodsSpeed.SelectedValue
        Else
            Speedkmph = Val(txtGoodsSpeed.Text)
        End If

        If DDGoodsGrade.Text <> "Other" Then '010709
            DownGrade = DDGoodsGrade.SelectedValue
        Else
            DownGrade = Val(txtGoodsGrade.Text)
        End If



        ' '' ''LocoBCPressure = DDGoodsBCPressure.SelectedValue
        ' '' ''PercentageOperativeCylinder = ((DDGoodsBrakePower.SelectedValue) / 100)
        ' '' ''Speedkmph = DDGoodsSpeed.SelectedValue
        ' '' ''DownGrade = (DDGoodsGrade.SelectedValue)

        'MsgBox("LocoNumber -" & LocoNumber & "  LocoBCPressure- " & LocoBCPressure & "  SpeedKmph -" & Speedkmph & "  DownGrade -" & DownGrade)

        'calculation of EBD
        StockWeight = StockWeight + (StockOverLoading * 1000)
        EffectiveTrainWeight = 1.05 * ((LocoWeight * LocoNumber) + (StockWeight * StockNumber))
        LocoBrakeDevTime = 20
        StockBrakeDevTime = 30
	if StockNumber > 62 then LocoBrakeDevTime = 9
        if StockNumber > 62 then StockBrakeDevTime = 41
	if StockNumber > 130 then StockBrakeDevTime = 53
        TimeLag1 = 1
        TimeLag2 = 3
        Velocity = Speedkmph / 3.6

        Dim table_name As String = "temp_goods"
        cmd1.Connection = con1
        cmd2.Connection = con1
        cmd1.CommandText = "SELECT name FROM MSysObjects WHERE (MSysObjects.Name='" + table_name + "') AND (MSysObjects.Type=1)"
        con1.Open()
        rd1 = cmd1.ExecuteReader()
        If rd1.Read = True Then
            cmd2.CommandText = "drop table temp_goods"
            cmd2.ExecuteNonQuery()

            cmd2.CommandText = " Create TABLE [temp_goods] (fieldSpeedkmph double,fieldTime long,fieldDistance double)"

            cmd2.ExecuteNonQuery()

        Else
            cmd2.CommandText = " Create TABLE [temp_goods] (fieldSpeedkmph double,fieldTime long,fieldDistance double)"

            cmd2.ExecuteNonQuery()
        End If
        con1.Close()
        

        ''''Dim ChartCounter1 As Integer = 0
        ''''Dim ChartCounter2 As Integer = 3
        Do While Velocity > 0
            ''''ChartCounter1 = ChartCounter1 + 1


            B1 = 0.16166666
            B2 = 0.0103125
            B3 = 0.0002865
            TL = Time - TimeLag1 + 2
            If TL < 0 Then TL = 0
            FL = TL * 13.5 / (LocoBrakeDevTime - TimeLag1)
            AKL = (B1 * FL - B2 * FL * FL + B3 * FL * FL * FL)
            If AKL > 1 Then AKL = 1
            TS = Time - TimeLag2 + 2
            If TS < 0 Then TS = 0
            FS = TS * 13.5 / (StockBrakeDevTime - TimeLag2)
            AKS = B1 * FS - B2 * FS * FS + B3 * FS * FS * FS
            If AKS > 1 Then AKS = 1
            'LocoFriction = 0.17
            If (DDGoodsLocoBrakeBlock.SelectedItem.Text) = "Cast Iron" Then GoTo 150
            If (DDGoodsLocoBrakeBlock.SelectedItem.Text) = "L Type Composition" Then LocoFriction = 0.17
            If (DDGoodsLocoBrakeBlock.SelectedItem.Text) = "High Friction" Then LocoFriction = 0.25
            GoTo 160
150:        Speedkmph = Velocity * 3.6
            SKM = Speedkmph
            SpecificShoePrLoco = (LocoBrakePower * 0.85) / (LocoBrakeBlock * LocoBrakeBlockArea)
            If SpecificShoePrLoco < 6 Then SpecificShoePrLoco = 6
            If SpecificShoePrLoco > 12 Then SpecificShoePrLoco = 12
            If SpecificShoePrLoco = 6 Then GoTo 200
            If SpecificShoePrLoco = 7 Then GoTo 210
            If SpecificShoePrLoco = 8 Then GoTo 220
            If SpecificShoePrLoco = 9 Then GoTo 230
            If SpecificShoePrLoco = 10 Then GoTo 240
            If SpecificShoePrLoco = 11 Then GoTo 250
            If SpecificShoePrLoco = 12 Then GoTo 260
200:        If SKM >= 75 Then GoTo 2003
            If SKM >= 35 Then GoTo 2001
            If SKM < 35 Then GoTo 2002
2003:       LocoFriction = 1.04
            GoTo 160
2001:       LocoFriction = (0.3 + 1.70597654345651 * SKM - 0.217999971250967 * SKM * SKM + _
      0.0117817847707845 * SKM * SKM * SKM - 0.0003503704351204 * SKM * SKM * SKM * SKM + _
      0.0000061966868687 * SKM * SKM * SKM * SKM * SKM - 0.0000000652052836 * SKM * SKM * SKM * _
      SKM * SKM * SKM + 0.0000000003781108 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000009324 _
      * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
2002:       LocoFriction = (0.3 - 0.0141178325123153 * SKM + 0.0004007290640394 * SKM * _
      SKM + 0.0000090214559387 * SKM * SKM * SKM - 0.0000009777011494 * SKM * SKM * SKM * SKM + _
      0.0000000155708812 * SKM * SKM * SKM * SKM * SKM + 0.0000000004229885 * SKM * SKM * SKM * SKM * _
      SKM * SKM - 0.0000000000124357 * SKM * SKM * SKM * SKM * SKM * SKM * SKM + 0.0000000000000525 * SKM * _
      SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
210:        If SKM >= 75 Then GoTo 2103
            If SKM >= 35 Then GoTo 2101
            If SKM < 35 Then GoTo 2102
2103:       LocoFriction = 0.098
            GoTo 160
2101:       LocoFriction = (0.3 + 1.70510609723624 * SKM - 0.217945068720181 * SKM * SKM _
      + 0.0117798181248387 * SKM * SKM * SKM - 0.0003503266726237 * SKM * SKM * SKM * SKM _
      + 0.0000061960673401 * SKM * SKM * SKM * SKM * SKM - 0.0000000651998342 * SKM * SKM * SKM * _
      SKM * SKM * SKM + 0.0000000003780835 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000009323 * _
      SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
2102:       LocoFriction = (0.3 - 0.021561330049261 * SKM + 0.0026047495894909 * SKM * SKM - _
      0.0002787030651341 * SKM * SKM * SKM + 0.0000181953065134 * SKM * SKM * SKM * SKM - _
      0.000000642605364 * SKM * SKM * SKM * SKM * SKM + 0.0000000105363985 * SKM * SKM * SKM * _
      SKM * SKM * SKM - 0.000000000031965 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - _
      0.0000000000006787 * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
220:        If SKM >= 75 Then GoTo 2203
            If SKM >= 35 Then GoTo 2201
            If SKM < 35 Then GoTo 2202
2203:       LocoFriction = 0.092
            GoTo 160
2201:       LocoFriction = (0.3 + 1.70423565101564 * SKM - 0.217890166189369 * SKM * SKM + _
      0.0117778514788917 * SKM * SKM * SKM - 0.0003502829101269 * SKM * SKM * SKM * SKM + _
      0.0000061954478114 * SKM * SKM * SKM * SKM * SKM - 0.0000000651943849 * SKM * SKM * SKM * SKM _
      * SKM * SKM + 0.0000000003780563 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000009323 * SKM _
      * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
2202:       LocoFriction = (0.3 - 0.0261124137931033 * SKM + 0.0032766469622331 * SKM * _
      SKM - 0.0003122137931034 * SKM * SKM * SKM + 0.0000182213793103 * SKM * SKM * SKM _
      * SKM - 0.0000005943908046 * SKM * SKM * SKM * SKM * SKM + 0.0000000092137931 * SKM * _
      SKM * SKM * SKM * SKM * SKM - 0.0000000000257471 * SKM * SKM * SKM * SKM * SKM * SKM _
      * SKM - 0.000000000000578 * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
230:        If SKM >= 75 Then GoTo 2303
            If SKM >= 35 Then GoTo 2301
            If SKM < 35 Then GoTo 2302
2303:       LocoFriction = 0.086
            GoTo 160
2301:       LocoFriction = (0.3 + 1.70336520479522 * SKM - 0.217835263658568 * SKM * SKM _
      + 0.0117758848329451 * SKM * SKM * SKM - 0.0003502391476302 * SKM * SKM * SKM * _
      SKM + 0.0000061948282828 * SKM * SKM * SKM * SKM * SKM - 0.0000000651889355 * SKM * SKM * _
      SKM * SKM * SKM * SKM + 0.0000000003780291 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - _
      0.0000000000009322 * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
2302:       LocoFriction = (0.3 - 0.0350428078817735 * SKM + 0.0061845295566502 * SKM * _
      SKM - 0.0007227459770115 * SKM * SKM * SKM + 0.0000476529310345 * SKM * SKM * SKM * SKM _
      - 0.0000016844137931 * SKM * SKM * SKM * SKM * SKM + 0.000000027645977 * SKM * SKM * SKM _
      * SKM * SKM * SKM - 0.0000000000832841 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000017997 _
      * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
240:        If SKM >= 75 Then GoTo 2403
            If SKM >= 35 Then GoTo 2401
            If SKM < 35 Then GoTo 2402
2403:       LocoFriction = 0.08
            GoTo 160
2401:       LocoFriction = (0.3 - 5.84726968586961 * SKM + 0.747139572205568 * SKM * SKM _
      - 0.0406393079858413 * SKM * SKM * SKM + 0.0012185038988172 * SKM * SKM * SKM * _
      SKM - 0.0000217490011223 * SKM * SKM * SKM * SKM * SKM + 0.0000002311108348 * SKM * SKM _
      * SKM * SKM * SKM * SKM - 0.0000000013539488 * SKM * SKM * SKM * SKM * SKM * SKM * SKM + _
      0.000000000003374 * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
2402:       LocoFriction = (0.3 - 0.0395938916256153 * SKM + 0.0068564269293924 * SKM * _
      SKM - 0.0007562567049808 * SKM * SKM * SKM + 0.0000476790038314 * SKM * SKM * SKM * SKM _
      - 0.0000016361992337 * SKM * SKM * SKM * SKM * SKM + 0.0000000263233716 * SKM * SKM * SKM * _
      SKM * SKM * SKM - 0.0000000000770662 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - _
      0.000000000001699 * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
250:        If SKM >= 75 Then GoTo 2503
            If SKM > 35 Then GoTo 2501
            If SKM < 35 Then GoTo 2502
2503:       LocoFriction = 0.076
            GoTo 160
2501:       LocoFriction = (0.3 - 0.199231560661529 * SKM + 0.0203851445776407 * SKM * SKM _
      - 0.0008760435206766 * SKM * SKM * SKM + 0.0000192389946473 * SKM * SKM * SKM * SKM - _
      0.0000002145095398 * SKM * SKM * SKM * SKM * SKM + 0.0000000008762842 * SKM * SKM * SKM * SKM * _
      SKM * SKM + 0.0000000000032303 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000000291 * SKM * SKM _
      * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
2502:       LocoFriction = (0.3 - 0.0426580788177338 * SKM + 0.0068244622331691 * SKM * _
      SKM - 0.0006669597701149 * SKM * SKM * SKM + 0.0000374465325671 * SKM * SKM * SKM * SKM _
      - 0.000001156137931 * SKM * SKM * SKM * SKM * SKM + 0.0000000166819923 * SKM * SKM * SKM * _
      SKM * SKM * SKM - 0.0000000000328407 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000011078 * _
      SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
260:        If SKM >= 75 Then GoTo 2603
            If SKM >= 35 Then GoTo 2601
            If SKM < 35 Then GoTo 2602
2603:       LocoFriction = 0.07
            GoTo 160
2601:       LocoFriction = (0.3 - 0.200102006881999 * SKM + 0.0204400471084461 * SKM * SKM _
      - 0.0008780101666234 * SKM * SKM * SKM + 0.0000192827571441 * SKM * SKM * SKM * SKM - _
      0.0000002151290685 * SKM * SKM * SKM * SKM * SKM + 0.0000000008817336 * SKM * SKM * SKM * SKM * _
      SKM * SKM + 0.0000000000032031 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.000000000000029 * _
      SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
2602:       LocoFriction = (0.3 - 0.0472091625615763 * SKM + 0.0074963596059113 * SKM * _
      SKM - 0.0007004704980843 * SKM * SKM * SKM + 0.000037472605364 * SKM * SKM * SKM * SKM _
      - 0.0000011079233716 * SKM * SKM * SKM * SKM * SKM + 0.000000015359387 * SKM * SKM * SKM _
      * SKM * SKM * SKM - 0.0000000000266229 * SKM * SKM * SKM * SKM * SKM * SKM * SKM - 0.0000000000010071 _
      * SKM * SKM * SKM * SKM * SKM * SKM * SKM * SKM)
            GoTo 160
160:        TotalBPloco = (LocoBrakePower * LocoNumber * 0.85 * LocoFriction * LocoBCPressure) / LocoBCPressureForBP
            BrakeEffortLoco = TotalBPloco
            StockFriction = 0.17
            If (DDGoodsTypeOfStock.Text) = "BOXNHLCONVEMPTY" Then GoTo 80
            If (DDGoodsTypeOfStock.Text) = "BOXNHLCONVLOADED" Then GoTo 80
            If (DDGoodsTypeOfStock.Text) = "BCNHLEMPTY" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BCNHLLOADED" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BCNAHSM1EMPTYBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BCNAHSM1LOADEDBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOSTHSM2EMPTYBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOSTHSM2LOADEDBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOXNHLMBSEMPTY" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOXNHLMBSLOADED" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BTPNEMPTYBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BTPNLOADEDBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BTPGLNEMPTYBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BTPGLNLOADEDBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOBYNEMPTYBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOBYNLOADEDBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOBRNHSM1EMPTYBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOBRNHSM1LOADEDBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BRNEMPTYBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BRNLOADEDBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BRNNEHSEMPTYBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BRNNEHSLOADEDBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOYEMPTYBMBS" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOYLOADEDBMBS" Then GoTo 80 'new
             If (DDGoodsTypeOfStock.Text) = "BCFCEMPTY" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BCFCLOADED" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BOXN25MEMPTY" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BOXN25MLOADED" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BLC25MEMPTY" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BLC25MLOADED" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BCNHLEMPTYLOADED" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BTFLNEMPTY" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BTFLNLOADED" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "GONDOLA25TEMPTY" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "GONDOLA25TLOADED" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BCLHLOADED" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BAFRDREMPTY" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BAFRDRLOADED" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BOXNHL25TEMPTY" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BOXNHL25TLOADED" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BOXN25TEMPTY" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BOXN25TLOADED" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BOXNS25TEMPTY" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BOXNS25TLOADED" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BFNSM22.9EMPTY" Then GoTo 80 'new
		If (DDGoodsTypeOfStock.Text) = "BFNSM22.9LOADED" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BCFCMEMPTY" Then GoTo 80 'new      
            If (DDGoodsTypeOfStock.Text) = "BCFCMLOADED" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOXNS22.9EMPTY" Then GoTo 80 'new      
            If (DDGoodsTypeOfStock.Text) = "BOXNS22.9LOADED" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOYEL25TEMPTY" Then GoTo 80 'new      
            If (DDGoodsTypeOfStock.Text) = "BOYEL25TLOADED" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOSTHSM3EMPTY" Then GoTo 80 'new      
            If (DDGoodsTypeOfStock.Text) = "BOSTHSM3LOADED" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOBSNS22.9EMPTY" Then GoTo 80 'new      
            If (DDGoodsTypeOfStock.Text) = "BOBSNS22.9LOADED" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOBSNS25TEMPTY" Then GoTo 80 'new      
            If (DDGoodsTypeOfStock.Text) = "BOBSNS25TLOADED" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BRN22.9M1EMPTY" Then GoTo 80 'new      
            If (DDGoodsTypeOfStock.Text) = "BRN22.9M1LOADED" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOBYNHSM1EMPTY" Then GoTo 80 'new      
            If (DDGoodsTypeOfStock.Text) = "BOBYNHSM1LOADED" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BTFLNM1EMPTY" Then GoTo 80 'new      
            If (DDGoodsTypeOfStock.Text) = "BTFLNM1LOADED" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOBSNDBEMPTY" Then GoTo 80 'new      
            If (DDGoodsTypeOfStock.Text) = "BOBSNDBLOADED" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BFNVEMPTY" Then GoTo 80 'new      
            If (DDGoodsTypeOfStock.Text) = "BFNVLOADED" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BOBRNHSM2EMPTY" Then GoTo 80 'new      
            If (DDGoodsTypeOfStock.Text) = "BOBRNHSM2LOADED" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BTFLNM1EMPTY" Then GoTo 80 'new      
            If (DDGoodsTypeOfStock.Text) = "BTFLNM1LOADED" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BFNSM1EMPTY" Then GoTo 80 'new      
            If (DDGoodsTypeOfStock.Text) = "BFNSM1LOADED" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BCDSEMPTY" Then GoTo 80 'new      
            If (DDGoodsTypeOfStock.Text) = "BCDSLOADED" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BTFCEMPTY" Then GoTo 80 'new      
            If (DDGoodsTypeOfStock.Text) = "BTFCLOADED" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BCPVNEMPTY" Then GoTo 80 'new      
            If (DDGoodsTypeOfStock.Text) = "BCPVNLOADED" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BCNAHSM1KEMPTY" Then GoTo 80 'new      
            If (DDGoodsTypeOfStock.Text) = "BCNAHSM1KLOADED" Then GoTo 80 'new
            If (DDGoodsTypeOfStock.Text) = "BCATICEMPTY" Then GoTo 80 'new      
            If (DDGoodsTypeOfStock.Text) = "BCATICLOADED" Then GoTo 80 'new

            GoTo 90
80:         Speedkmph = Velocity * 3.6
            If Speedkmph < 40 Then StockFriction = 0.27
            If Speedkmph > 40 Then StockFriction = 0.23
            GoTo 90
90:         TotalBPStock = StockBrakePower * StockNumber * 0.72 * StockFriction * PercentageOperativeCylinder
            BrakeEffortStock = TotalBPStock
            If Time <= LocoBrakeDevTime Then GoTo 30
            GoTo 40
30:         BrakeEffortLoco = TotalBPloco * AKL
40:         If Time <= StockBrakeDevTime Then GoTo 50
            GoTo 60
50:         BrakeEffortStock = TotalBPStock * AKS
60:         RollingResistanceLoco = ((LocoRRL1 + LocoRRL2 * Speedkmph + LocoRRL3 * Speedkmph * Speedkmph) * LocoWeight * LocoNumber) / 1000
            RollingResistanceStock = ((StockRRL1 + StockRRL2 * Speedkmph + StockRRL3 * Speedkmph * Speedkmph) * StockWeight * StockNumber) / 1000
            DownGradepull = EffectiveTrainWeight / (DownGrade * 1.05)
            If DownGrade >= 500 Then DownGradepull = 0
            TotalBrakeEffort = BrakeEffortLoco + BrakeEffortStock + RollingResistanceLoco + RollingResistanceStock + DownGradepull
            Retardation = TotalBrakeEffort * 9.81 / EffectiveTrainWeight
            Distance = Velocity - 0.5 * Retardation
            TotalDistance = TotalDistance + Distance
            Velocity = Velocity - Retardation
            Time = Time + 1
            Speedkmph = Velocity * 3.6
            If Speedkmph < 0 Then
                Speedkmph = 0
            End If
            '' ''If ChartCounter2 = ChartCounter1 + 2 Then
            cmd1.Connection = con1
            cmd1.CommandText = "Insert Into temp_goods (fieldSpeedkmph,fieldTime,fieldDistance) values ('" & Speedkmph & "','" & Time & "','" & TotalDistance & "')" 'dhs
            con1.Open()
            cmd1.ExecuteNonQuery()
            con1.Close()
            '' ''    ChartCounter2 = ChartCounter2 + 2
            '' ''End If
        Loop
        'MsgBox(FinalDistance)

        'Response.Redirect("GoodsChart.aspx")

        Response.Redirect("GoodsChart.aspx?RptQry_distance=" + txtTotalDistance.Text + "&RptQry_time=" + txtTime.Text)

    End Sub


    Protected Sub DDGoodsBCPressure_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDGoodsBCPressure.SelectedIndexChanged
        If DDGoodsBCPressure.Text = "Other" Then
            txtGoodsBCPressure.Visible = True
        Else
            txtGoodsBCPressure.Visible = False
        End If
    End Sub

    Protected Sub DDGoodsBrakePower_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDGoodsBrakePower.SelectedIndexChanged
        If DDGoodsBrakePower.Text = "Other" Then
            txtGoodsBrakePower.Visible = True
        Else
            txtGoodsBrakePower.Visible = False
        End If
    End Sub

    Protected Sub DDGoodsSpeed_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDGoodsSpeed.SelectedIndexChanged
        If DDGoodsSpeed.Text = "Other" Then
            txtGoodsSpeed.Visible = True
        Else
            txtGoodsSpeed.Visible = False
        End If
    End Sub

    Protected Sub DDGoodsGrade_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDGoodsGrade.SelectedIndexChanged
        If DDGoodsGrade.Text = "Other" Then
            txtGoodsGrade.Visible = True
        Else
            txtGoodsGrade.Visible = False
        End If
    End Sub
End Class
