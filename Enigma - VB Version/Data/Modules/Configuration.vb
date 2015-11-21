Public Module Configuration
    ' Global Variables
    Public Config = {2, 1, 2, 3, 0, 0, 0} ' Current Enigma Setting
    Public Plugboard = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ' Current Plugboard Setting
    Public Turnover(3) As Integer       ' Stores how many times have the rotors been shifted.
    Public Turnover_Notch(3) As Integer ' Stores at which position do the rotors shift the next one.

    ' Sets the Machine to the default config: Rotors I, II, III, on positions A,A,A, Reflector B and no plugboard
    Sub Use_Default_Config()

        Config = {2, 1, 2, 3, 0, 0, 0}
        VisualUI.cb_Reflector.SelectedIndex = 1
        VisualUI.cb_Rotor_L.SelectedIndex = 0
        VisualUI.cb_Rotor_M.SelectedIndex = 1
        VisualUI.cb_Rotor_R.SelectedIndex = 2
        VisualUI.cb_Rotor_Start_L.SelectedIndex = 0
        VisualUI.cb_Rotor_Start_M.SelectedIndex = 0
        VisualUI.cb_Rotor_Start_R.SelectedIndex = 0
        VisualUI.tb_Plugboard.Text = vbNullString
        Set_Plugboard()
        VisualUI.Update_Rotors_Pos()

    End Sub

    ' Gets the desired settings and configures the enigma
    Sub Configure()
        ' Rings are handled here.
        VisualUI.b_Reset.PerformClick()

        Config(0) = VisualUI.cb_Reflector.SelectedIndex + 1
        Config(1) = VisualUI.cb_Rotor_L.SelectedIndex + 1
        Config(2) = VisualUI.cb_Rotor_M.SelectedIndex + 1
        Config(3) = VisualUI.cb_Rotor_R.SelectedIndex + 1
        Config(4) = VisualUI.cb_Rotor_Start_L.SelectedIndex + 1
        Config(5) = VisualUI.cb_Rotor_Start_M.SelectedIndex + 1
        Config(6) = VisualUI.cb_Rotor_Start_R.SelectedIndex + 1

        Set_Plugboard()

    End Sub

    ' Used by the computer when generating configuration settings and applying them.
    Public Sub Configure(ByVal ReflectorID As UInteger, ByVal RotorLftID As UInteger, ByVal RotorMidID As UInteger, ByVal RotorRgtID As UInteger, ByVal RotorLftPos As UInteger, ByVal RotorMidPos As UInteger, ByVal RotorRgtPos As UInteger)
        Config = {ReflectorID, RotorLftID, RotorMidID, RotorRgtID, RotorLftPos, RotorMidPos, RotorRgtPos}
    End Sub
    ' Returns all settings to default states.
    Public Sub Reset_to_Default()

        VisualUI.SpacebarToXToolStripMenuItem.Checked = False
        VisualUI.ts_cb_TextGroup.SelectedIndex = 0
        Use_Default_Config()
        VisualUI.b_Reset.PerformClick()

    End Sub

    ' Generate plugboard settings based on text entered.
    Public Sub Set_Plugboard()
        ReDim Plugboard(27)
        If VisualUI.tb_Plugboard.TextLength Mod 2 = 0 Then
            For i = 1 To VisualUI.tb_Plugboard.TextLength Step 2
                ' Get the position in the alphabet of the pair of letters
                Dim X As Integer = Asc(VisualUI.tb_Plugboard.Text(i - 1)) - 64
                Dim Y As Integer = Asc(VisualUI.tb_Plugboard.Text(i)) - 64

                ' Assign the Plugboard Shift
                Plugboard(X) = (Y - X)
                Plugboard(Y) = (X - Y)
            Next
        End If
    End Sub

End Module
