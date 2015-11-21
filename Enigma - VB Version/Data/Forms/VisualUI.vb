Public Class VisualUI
    ' Variables
    Dim InputTextLength_Old As Integer ' Memorises the length of the input text before being modified.
    Dim SpacingCounter As Integer      ' Determines in groups of how many characters are the textboxes organised
    Dim keyIsDown As Boolean           ' True while a letter is being pressed down.

    ' PROGRAM STARTS HERE
    Private Sub Enigma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ts_cb_TextGroup.SelectedIndex = 2
        Configuration.Use_Default_Config()
    End Sub

    ' Congfigures the Machine
    Private Sub b_Config_Click(sender As Object, e As EventArgs) Handles b_Config.Click
        Configuration.Configure()
    End Sub

    ' Resets the UI and the machine to the state it was after being configured.
    Private Sub b_Reset_Click(sender As Object, e As EventArgs) Handles b_Reset.Click

        InputTextLength_Old = 0
        Input.Clear()
        Output.Clear()
        Turnover(1) = Asc(cb_Rotor_Start_L.SelectedItem) - 65
        Turnover(2) = Asc(cb_Rotor_Start_M.SelectedItem) - 65
        Turnover(3) = Asc(cb_Rotor_Start_R.SelectedItem) - 65
        Update_Rotors_Pos()

    End Sub

    ' Updates the UI with the Rotor Ring Positions
    Public Sub Update_Rotors_Pos()
        lb_RotorL_Pos.Text = Alpha(Turnover(1) + 1)
        lb_RotorM_Pos.Text = Alpha(Turnover(2) + 1)
        lb_RotorR_Pos.Text = Alpha(Turnover(3) + 1)
    End Sub

    ' Reads input and handles output generation based on it
    Private Sub Input_TextChanged(sender As Object, e As EventArgs) Handles Input.TextChanged
        My.Computer.Audio.Play(My.Resources.Keystroke1, AudioPlayMode.Background)

        If Input.TextLength > 0 Then
            Dim x As Char = UCase(Input.Text(Input.TextLength - 1))

            ' If change happened in middle of text
            If Input.SelectionStart < Input.TextLength Or Input.TextLength = InputTextLength_Old Then
                ' Reset and Encode
                Output.Clear()
                Turnover(1) = Asc(cb_Rotor_Start_L.SelectedItem) - 65
                Turnover(2) = Asc(cb_Rotor_Start_M.SelectedItem) - 65
                Turnover(3) = Asc(cb_Rotor_Start_R.SelectedItem) - 65
                Update_Rotors_Pos()

                For i As Integer = 0 To Input.TextLength - 1
                    x = Input.Text(i)
                    Output.Text += Encode.encode(x)
                Next

                InputTextLength_Old = Input.TextLength
                ' If change happened at the end of text
            ElseIf Input.TextLength > InputTextLength_Old Then
                ' If characters have been aded:

                Dim encodelist As String = Microsoft.VisualBasic.Right(Input.Text, Input.TextLength - InputTextLength_Old)

                For i As Integer = 0 To encodelist.Length - 1
                    x = encodelist(i)
                    Output.Text += Encode.encode(x)
                Next

                ' Lightboard Bulbs
                LightBoard()
                Update_Rotors_Pos()
                InputTextLength_Old = Input.TextLength

            ElseIf Input.TextLength < InputTextLength_Old Then
                ' If characters have been removed:
                For i As Integer = InputTextLength_Old - 1 To Input.TextLength Step -1
                    If Input.Text(i - 1) = " " Then
                        Rotors_Turnover()
                    End If

                    Rotors_Turnover_Backwards()
                    Output.Text = Microsoft.VisualBasic.Left(Output.Text, Len(Output.Text) - 1)
                Next

                Update_Rotors_Pos()
                InputTextLength_Old = Input.TextLength

            End If
        Else
            b_Reset.PerformClick()
        End If

    End Sub

    
    ' KEYS =======================================================================================
    ' Prevents any non-alphabetical letters from being typed.
    Private Sub Input_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Input.KeyPress

        If Char.IsLower(e.KeyChar) Then

            'Convert to uppercase, and put at the caret position in the TextBox.
            Input.SelectedText = Char.ToUpper(e.KeyChar)
            e.Handled = True

        End If

        If Not (Asc(e.KeyChar) = Keys.Back Or Asc(e.KeyChar) = Keys.Space) Then
            If Not ((Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90)) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

    End Sub

    ' Negates 'ENTER' and colors the keyboard
    Private Sub Input_KeyDown(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles Input.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
        End If

        If e.KeyCode = Keys.Space And PreserveSpacing.Checked = False Then
            e.SuppressKeyPress = True
        End If

    End Sub

    ' Makes sure only one key is registered per keypress
    Private Sub Input_UniquePress_Down(sender As Object, e As KeyEventArgs) Handles Input.KeyDown

        If e.KeyCode = Keys.Back Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Then Exit Sub
        If keyIsDown Then 'if key is already down abort
            e.SuppressKeyPress = True
            Exit Sub
        End If

        keyIsDown = True 'if key was not already down mark it as down now   
    End Sub
    Private Sub Input_UniquePress_Up(sender As Object, e As KeyEventArgs) Handles Input.KeyUp
        keyIsDown = False 'key has traveled up clear the marker
    End Sub

    ' Handles the on-screen keyboard animations.
    Private Sub tb_Plugboard_KeyDown(sender As Object, e As KeyEventArgs) Handles Input.KeyDown

        ' Typewriter Keyboard Keypress:
        Select Case e.KeyCode
            Case Keys.A
                KeyBoard_A.Image = My.Resources.A_Pressed
            Case Keys.B
                KeyBoard_B.Image = My.Resources.B_Pressed
            Case Keys.C
                KeyBoard_C.Image = My.Resources.C_Pressed
            Case Keys.D
                KeyBoard_D.Image = My.Resources.D_Pressed
            Case Keys.E
                KeyBoard_E.Image = My.Resources.E_Pressed
            Case Keys.F
                KeyBoard_F.Image = My.Resources.F_Pressed
            Case Keys.G
                KeyBoard_G.Image = My.Resources.G_Pressed
            Case Keys.H
                KeyBoard_H.Image = My.Resources.H_Pressed
            Case Keys.I
                KeyBoard_I.Image = My.Resources.I_Pressed
            Case Keys.J
                KeyBoard_J.Image = My.Resources.J_Pressed
            Case Keys.K
                KeyBoard_K.Image = My.Resources.K_Pressed
            Case Keys.L
                KeyBoard_L.Image = My.Resources.L_Pressed
            Case Keys.M
                KeyBoard_M.Image = My.Resources.M_Pressed
            Case Keys.N
                KeyBoard_N.Image = My.Resources.N_Pressed
            Case Keys.O
                KeyBoard_O.Image = My.Resources.O_Pressed
            Case Keys.P
                KeyBoard_P.Image = My.Resources.P_Pressed
            Case Keys.Q
                KeyBoard_Q.Image = My.Resources.Q_Pressed
            Case Keys.R
                KeyBoard_R.Image = My.Resources.R_Pressed
            Case Keys.S
                KeyBoard_S.Image = My.Resources.S_Pressed
            Case Keys.T
                KeyBoard_T.Image = My.Resources.T_Pressed
            Case Keys.U
                KeyBoard_U.Image = My.Resources.U_Pressed
            Case Keys.V
                KeyBoard_V.Image = My.Resources.V_Pressed
            Case Keys.W
                KeyBoard_W.Image = My.Resources.W_Pressed
            Case Keys.X
                KeyBoard_X.Image = My.Resources.X_Pressed
            Case Keys.Y
                KeyBoard_Y.Image = My.Resources.Y_Pressed
            Case Keys.Z
                KeyBoard_Z.Image = My.Resources.Z_Pressed
        End Select

    End Sub

    ' Resets the visual keyboard to normal
    Private Sub tb_Plugboard_KeyUp(sender As Object, e As KeyEventArgs) Handles Input.KeyUp

        KeyBoard_A.Image = My.Resources.A_Unpressed
        KeyBoard_B.Image = My.Resources.B_Unpressed
        KeyBoard_C.Image = My.Resources.C_Unpressed
        KeyBoard_D.Image = My.Resources.D_Unpressed
        KeyBoard_E.Image = My.Resources.E_Unpressed
        KeyBoard_F.Image = My.Resources.F_Unpressed
        KeyBoard_G.Image = My.Resources.G_Unpressed
        KeyBoard_H.Image = My.Resources.H_Unpressed
        KeyBoard_I.Image = My.Resources.I_Unpressed
        KeyBoard_J.Image = My.Resources.J_Unpressed
        KeyBoard_K.Image = My.Resources.K_Unpressed
        KeyBoard_L.Image = My.Resources.L_Unpressed
        KeyBoard_M.Image = My.Resources.M_Unpressed
        KeyBoard_N.Image = My.Resources.N_Unpressed
        KeyBoard_O.Image = My.Resources.O_Unpressed
        KeyBoard_P.Image = My.Resources.P_Unpressed
        KeyBoard_Q.Image = My.Resources.Q_Unpressed
        KeyBoard_R.Image = My.Resources.R_Unpressed
        KeyBoard_S.Image = My.Resources.S_Unpressed
        KeyBoard_T.Image = My.Resources.T_Unpressed
        KeyBoard_U.Image = My.Resources.U_Unpressed
        KeyBoard_V.Image = My.Resources.V_Unpressed
        KeyBoard_W.Image = My.Resources.W_Unpressed
        KeyBoard_X.Image = My.Resources.X_Unpressed
        KeyBoard_Y.Image = My.Resources.Y_Unpressed
        KeyBoard_Z.Image = My.Resources.Z_Unpressed
        LightBoard_A.BackColor = Color.LightGray
        LightBoard_B.BackColor = Color.LightGray
        LightBoard_C.BackColor = Color.LightGray
        LightBoard_D.BackColor = Color.LightGray
        LightBoard_E.BackColor = Color.LightGray
        LightBoard_F.BackColor = Color.LightGray
        LightBoard_G.BackColor = Color.LightGray
        LightBoard_H.BackColor = Color.LightGray
        LightBoard_I.BackColor = Color.LightGray
        LightBoard_J.BackColor = Color.LightGray
        LightBoard_K.BackColor = Color.LightGray
        LightBoard_L.BackColor = Color.LightGray
        LightBoard_M.BackColor = Color.LightGray
        LightBoard_N.BackColor = Color.LightGray
        LightBoard_O.BackColor = Color.LightGray
        LightBoard_P.BackColor = Color.LightGray
        LightBoard_Q.BackColor = Color.LightGray
        LightBoard_R.BackColor = Color.LightGray
        LightBoard_S.BackColor = Color.LightGray
        LightBoard_T.BackColor = Color.LightGray
        LightBoard_U.BackColor = Color.LightGray
        LightBoard_V.BackColor = Color.LightGray
        LightBoard_W.BackColor = Color.LightGray
        LightBoard_X.BackColor = Color.LightGray
        LightBoard_Y.BackColor = Color.LightGray
        LightBoard_Z.BackColor = Color.LightGray

    End Sub

    ' Handles the Lightboard bulb lighting
    Private Sub LightBoard()

        ' Lightboard Key Light-Up
        Dim key As Integer = Asc(Output.Text(Output.TextLength - 1))

        Select Case key
            Case Keys.A
                LightBoard_A.BackColor = Color.Yellow
            Case Keys.B
                LightBoard_B.BackColor = Color.Yellow
            Case Keys.C
                LightBoard_C.BackColor = Color.Yellow
            Case Keys.D
                LightBoard_D.BackColor = Color.Yellow
            Case Keys.E
                LightBoard_E.BackColor = Color.Yellow
            Case Keys.F
                LightBoard_F.BackColor = Color.Yellow
            Case Keys.G
                LightBoard_G.BackColor = Color.Yellow
            Case Keys.H
                LightBoard_H.BackColor = Color.Yellow
            Case Keys.I
                LightBoard_I.BackColor = Color.Yellow
            Case Keys.J
                LightBoard_J.BackColor = Color.Yellow
            Case Keys.K
                LightBoard_K.BackColor = Color.Yellow
            Case Keys.L
                LightBoard_L.BackColor = Color.Yellow
            Case Keys.M
                LightBoard_M.BackColor = Color.Yellow
            Case Keys.N
                LightBoard_N.BackColor = Color.Yellow
            Case Keys.O
                LightBoard_O.BackColor = Color.Yellow
            Case Keys.P
                LightBoard_P.BackColor = Color.Yellow
            Case Keys.Q
                LightBoard_Q.BackColor = Color.Yellow
            Case Keys.R
                LightBoard_R.BackColor = Color.Yellow
            Case Keys.S
                LightBoard_S.BackColor = Color.Yellow
            Case Keys.T
                LightBoard_T.BackColor = Color.Yellow
            Case Keys.U
                LightBoard_U.BackColor = Color.Yellow
            Case Keys.V
                LightBoard_V.BackColor = Color.Yellow
            Case Keys.W
                LightBoard_W.BackColor = Color.Yellow
            Case Keys.X
                LightBoard_X.BackColor = Color.Yellow
            Case Keys.Y
                LightBoard_Y.BackColor = Color.Yellow
            Case Keys.Z
                LightBoard_Z.BackColor = Color.Yellow
        End Select

    End Sub

    
    ' MENU ITEMS =================================================================================
    ' Exit - Quits the application - Alt + F4
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    ' Export - Saves the encoded message in a txt file - Ctrl + S
    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        TextManipulation.Export()
    End Sub

    ' Import - Opens an encoded message in a text file - Ctrl + O
    Private Sub ImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportToolStripMenuItem.Click
        TextManipulation.Import()
    End Sub

    ' Reset - Returns all settings to default states - Ctrl + Shift + R
    Private Sub ResetToDefaultToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetToDefaultToolStripMenuItem.Click
        Configuration.Reset_to_Default()
    End Sub

End Class