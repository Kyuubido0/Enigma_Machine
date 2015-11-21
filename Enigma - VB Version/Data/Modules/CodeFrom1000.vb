'Module CodeFrom1000
'    'CONFIG:
'    Public Module Config
'        ' Global Variables
'        Public Rotors_Ref(27) As Integer    ' Vector made out of the position modifiers of the reflector wheel.
'        Public Rotors_RtL(27, 3) As Integer ' Matrix made out of the three rotors and their position modifiers when signal comes from Right to Left
'        Public Rotors_LtR(27, 3) As Integer ' Matrix made out of the three rotors and their position modifiers when signal comes from Left to Right
'        Public Turnover(3) As Integer       ' Stores how many times have the rotors been shifted.
'        Public Turnover_Notch(3) As Integer ' Stores at which position do the rotors shift the next one.

'        ' Sets the Machine to the default config: Rotors I, II, III, on positions A,A,A, Reflector B and no plugboard
'        Sub Use_Default_Config()

'            For i As Integer = 1 To 26
'                Rotors_Ref(i) = Reflector_B(i)

'                Rotors_RtL(i, 1) = Rotor_I(0, i)
'                Rotors_RtL(i, 2) = Rotor_II(0, i)
'                Rotors_RtL(i, 3) = Rotor_III(0, i)

'                Rotors_LtR(i, 1) = Rotor_I(1, i)
'                Rotors_LtR(i, 2) = Rotor_II(1, i)
'                Rotors_LtR(i, 3) = Rotor_III(1, i)
'            Next

'            Turnover_Notch(1) = NOTCH_R_I
'            Turnover_Notch(2) = NOTCH_R_II
'            Turnover_Notch(3) = NOTCH_R_III

'            Enigma.cb_Rotor_L.SelectedItem = "I"
'            Enigma.cb_Rotor_M.SelectedItem = "II"
'            Enigma.cb_Rotor_R.SelectedItem = "III"
'            Enigma.cb_Reflector.SelectedItem = "Reflector B"
'            Enigma.cb_Rotor_Start_L.SelectedItem = "A"
'            Enigma.cb_Rotor_Start_M.SelectedItem = "A"
'            Enigma.cb_Rotor_Start_R.SelectedItem = "A"

'            Turnover(1) = Asc(Enigma.cb_Rotor_Start_L.SelectedItem) - 65
'            Turnover(2) = Asc(Enigma.cb_Rotor_Start_M.SelectedItem) - 65
'            Turnover(3) = Asc(Enigma.cb_Rotor_Start_R.SelectedItem) - 65
'            Enigma.Update_Rotors_Pos()

'        End Sub

'        Sub Configure()
'            ' Rings are handled here.
'            Enigma.b_Reset.PerformClick()

'            ' Sets Left Rotor
'            If Enigma.cb_Rotor_L.SelectedItem = "I" Then
'                For i As Integer = 1 To 26
'                    Rotors_RtL(i, 1) = Rotor_I(0, i)
'                    Rotors_LtR(i, 1) = Rotor_I(1, i)
'                Next
'                Turnover_Notch(1) = NOTCH_R_I
'            ElseIf Enigma.cb_Rotor_L.SelectedItem = "II" Then
'                For i As Integer = 1 To 26
'                    Rotors_RtL(i, 1) = Rotor_II(0, i)
'                    Rotors_LtR(i, 1) = Rotor_II(1, i)
'                Next
'                Turnover_Notch(1) = NOTCH_R_II
'            ElseIf Enigma.cb_Rotor_L.SelectedItem = "III" Then
'                For i As Integer = 1 To 26
'                    Rotors_RtL(i, 1) = Rotor_III(0, i)
'                    Rotors_LtR(i, 1) = Rotor_III(1, i)
'                Next
'                Turnover_Notch(1) = NOTCH_R_III
'            ElseIf Enigma.cb_Rotor_L.SelectedItem = "IV" Then
'                For i As Integer = 1 To 26
'                    Rotors_RtL(i, 1) = Rotor_IV(0, i)
'                    Rotors_LtR(i, 1) = Rotor_IV(1, i)
'                Next
'                Turnover_Notch(1) = NOTCH_R_IV
'            ElseIf Enigma.cb_Rotor_L.SelectedItem = "V" Then
'                'For i As Integer = 1 To 26
'                '    Rotors_RtL(i, 1) = Rotor_V(0, i)
'                '    Rotors_LtR(i, 1) = Rotor_V(1, i)
'                'Next
'                'Turnover_Notch(1) = NOTCH_R_V
'            End If

'            ' Sets Middle Rotor
'            If Enigma.cb_Rotor_M.SelectedItem = "I" Then
'                For i As Integer = 1 To 26
'                    Rotors_RtL(i, 2) = Rotor_I(0, i)
'                    Rotors_LtR(i, 2) = Rotor_I(1, i)
'                Next
'                Turnover_Notch(2) = NOTCH_R_I
'            ElseIf Enigma.cb_Rotor_M.SelectedItem = "II" Then
'                For i As Integer = 1 To 26
'                    Rotors_RtL(i, 2) = Rotor_II(0, i)
'                    Rotors_LtR(i, 2) = Rotor_II(1, i)
'                Next
'                Turnover_Notch(2) = NOTCH_R_II
'            ElseIf Enigma.cb_Rotor_M.SelectedItem = "III" Then
'                For i As Integer = 1 To 26
'                    Rotors_RtL(i, 2) = Rotor_III(0, i)
'                    Rotors_LtR(i, 2) = Rotor_III(1, i)
'                Next
'                Turnover_Notch(2) = NOTCH_R_III
'            ElseIf Enigma.cb_Rotor_M.SelectedItem = "IV" Then
'                For i As Integer = 1 To 26
'                    Rotors_RtL(i, 2) = Rotor_IV(0, i)
'                    Rotors_LtR(i, 2) = Rotor_IV(1, i)
'                Next
'                Turnover_Notch(2) = NOTCH_R_IV
'            ElseIf Enigma.cb_Rotor_M.SelectedItem = "V" Then
'                'For i As Integer = 1 To 26
'                '    Rotors_RtL(i, 2) = Rotor_V(0, i)
'                '    Rotors_LtR(i, 2) = Rotor_V(1, i)
'                'Next
'                'Turnover_Notch(2) = NOTCH_R_V
'            End If

'            ' Sets Right Rotor
'            If Enigma.cb_Rotor_R.SelectedItem = "I" Then
'                For i As Integer = 1 To 26
'                    Rotors_RtL(i, 3) = Rotor_I(0, i)
'                    Rotors_LtR(i, 3) = Rotor_I(1, i)
'                Next
'                Turnover_Notch(3) = NOTCH_R_I
'            ElseIf Enigma.cb_Rotor_R.SelectedItem = "II" Then
'                For i As Integer = 1 To 26
'                    Rotors_RtL(i, 3) = Rotor_II(0, i)
'                    Rotors_LtR(i, 3) = Rotor_II(1, i)
'                Next
'                Turnover_Notch(3) = NOTCH_R_II
'            ElseIf Enigma.cb_Rotor_R.SelectedItem = "III" Then
'                For i As Integer = 1 To 26
'                    Rotors_RtL(i, 3) = Rotor_III(0, i)
'                    Rotors_LtR(i, 3) = Rotor_III(1, i)
'                Next
'                Turnover_Notch(3) = NOTCH_R_III
'            ElseIf Enigma.cb_Rotor_R.SelectedItem = "IV" Then
'                For i As Integer = 1 To 26
'                    Rotors_RtL(i, 3) = Rotor_IV(0, i)
'                    Rotors_LtR(i, 3) = Rotor_IV(1, i)
'                Next
'                Turnover_Notch(3) = NOTCH_R_IV
'            ElseIf Enigma.cb_Rotor_R.SelectedItem = "V" Then
'                For i As Integer = 1 To 26
'                    Rotors_RtL(i, 3) = Rotor_V(0, i)
'                    Rotors_LtR(i, 3) = Rotor_V(1, i)
'                Next
'                Turnover_Notch(3) = NOTCH_R_V
'            End If

'            ' Sets Reflector
'            If Enigma.cb_Reflector.SelectedItem = "Reflector A" Then
'                For i As Integer = 1 To 26
'                    Rotors_Ref(i) = Reflector_A(i)
'                Next
'            ElseIf Enigma.cb_Reflector.SelectedItem = "Reflector B" Then
'                For i As Integer = 1 To 26
'                    Rotors_Ref(i) = Reflector_B(i)
'                Next
'            ElseIf Enigma.cb_Reflector.SelectedItem = "Reflector C" Then
'                For i As Integer = 1 To 26
'                    Rotors_Ref(i) = Reflector_C(i)
'                Next
'            End If
'        End Sub

'    End Module

'    ' ENCODE
'    Public Module Encode
'        ' Functions TL;DR

'        ' Adjusts position to it's wrapp-around value to make sure it is always between [1, 26]
'        Function Adj(ByVal pos As Integer) As Integer
'            If (pos > 26) Then
'                Return pos Mod 26
'            ElseIf (pos <= 0) Then
'                Return pos + 26
'            Else
'                Return pos
'            End If
'        End Function

'        Function Plugboard(ByVal pos As Integer) As Integer
'            If Use_Plgbrd = False Then
'                Return pos
'            Else
'                Return Plgbrd_Stngs(pos)
'            End If
'        End Function

'        Function Rotor_Ref(ByVal pos As Integer) As Integer
'            Return Adj(pos + Rotors_Ref(pos))
'        End Function

'        Function Rotor_RtL(ByVal pos As Integer) As Integer
'            Dim j As Integer = 3

'            While j >= 1
'                pos = Adj(pos + Rotors_RtL(Adj(pos + Turnover(j)), j))
'                j = j - 1
'            End While

'            Return pos
'        End Function

'        Function Rotor_LtR(ByVal pos As Integer) As Integer
'            Dim j As Integer = 1

'            While j <= 3
'                pos = Adj(pos + Rotors_LtR(Adj(pos + Turnover(j)), j))
'                j = j + 1
'            End While

'            Return pos
'        End Function

'        Sub Rotors_Turnover()
'            Turnover(3) = (Turnover(3) + 1) Mod 26
'            If Turnover(3) = Turnover_Notch(3) Then
'                Turnover(2) = Adj(Turnover(2) + 1) Mod 26
'            End If

'            If Turnover(2) = Turnover_Notch(2) And Turnover(3) = Turnover_Notch(3) + 1 Then
'                Turnover(1) = Adj(Turnover(1) + 1) Mod 26
'            End If

'            Enigma.Update_Rotors_Pos()
'        End Sub

'        Public Sub Rotors_Turnover_Backwards()
'            Turnover(3) = (Turnover(3) + 25) Mod 26
'            If Turnover(3) = Turnover_Notch(3) Then
'                Turnover(2) = (Turnover(2) + 25) Mod 26
'            End If

'            If Turnover(2) = Turnover_Notch(2) And Turnover(3) = Turnover_Notch(3) Then
'                Turnover(1) = (Turnover(1) + 25) Mod 26
'            End If

'            Enigma.Update_Rotors_Pos()
'        End Sub
'        Function encode(ByVal x As Char) As Char
'            ' Convert the letter to it's position in the Aplhabet
'            Dim pos As Integer = Asc(x) - 64

'            ' Turnover Rotors
'            Rotors_Turnover()

'            ' Pass the signal through the machine and calculate its path

'            pos = Plugboard(pos)
'            pos = Rotor_RtL(pos)
'            pos = Rotor_Ref(pos)
'            pos = Rotor_LtR(pos)
'            pos = Plugboard(pos)

'            ' Convert the position in the Alphabet back to the letter
'            Return Alpha(pos)
'        End Function
'    End Module

'    ' ROTORS
'    Public Module Rotors
'        ' Alphabet:
'        Public Alpha = {"_"c, "A"c, "B"c, "C"c, "D"c, "E"c, "F"c, "G"c, "H"c, "I"c, "J"c, "K"c, "L"c, "M"c, "N"c, "O"c, "P"c, "Q"c, "R"c, "S"c, "T"c, "U"c, "V"c, "W"c, "X"c, "Y"c, "Z"c}
'        ' Rotors:
'        ' First number is 0 to skip the 0 position in the vector. Other values are as follows:
'        ' Top Row - How many positions does the rotor shift the signal when it comes from left to right for each letter. Positive for going downwards and negative for upwards.
'        ' Bot Row - How many positions does the rotor shift the signal when it comes from right to left for each letter. Positive for going downwards and negative for upwards.

'        Public Rotor_I = {{0, 4, 9, 10, 2, 7, 1, -3, 9, 13, -10, 3, 8, 2, 9, 10, -8, 7, 3, 0, -4, 6, -13, 5, -6, 4, 10},
'                       {0, -6, -5, -4, 3, -4, -2, -1, 8, 13, -10, -9, -7, -10, -3, -2, 4, -9, 6, 0, -8, -3, -13, -9, -7, -10, 10}}
'        Public Rotor_II = {{0, 0, 8, 1, 7, 14, 3, 11, 13, -11, -8, 1, -4, 10, 6, -2, 13, 0, -11, 7, -6, -5, 3, 9, -2, -10, 5},
'                        {0, 0, 8, 13, -1, -5, -9, 11, 4, -3, -8, -7, -1, 2, 6, 10, 5, 0, -11, 12, -6, -13, 2, -10, 11, -3, -7}}
'        Public Rotor_III = {{0, 1, 2, 3, 4, 5, 6, -4, 8, 9, 10, 13, 10, 13, 0, 10, -11, -8, 5, -12, 7, -10, -9, -2, -5, -8, -11},
'                         {0, -7, -1, 4, -2, 11, -3, 12, -4, 8, -5, 10, -6, 9, 0, 11, -8, 8, -9, 5, -10, 2, -10, -5, 13, -10, 13}}
'        Public Rotor_IV = {{0, 4, -9, 12, -8, 11, -6, 3, -7, -10, 7, 10, -3, 5, -6, 9, -4, -3, -12, 1, 13, -10, 8, 6, -11, -2, 2},
'                        {0, 7, -2, -6, -8, -4, 2, 13, 6, 3, -3, 10, 4, 12, 3, -12, -11, -7, -5, 9, -1, -10, -8, 2, -9, 10, 6}}
'        Public Rotor_V = {{0, -5, -2, -1, -12, 2, 3, 13, -9, 12, 6, 8, -8, 1, -6, -3, 8, 10, 5, -7, -10, -4, -7, 9, 7, 4, 11},
'                          {0, -10, 1, -4, 8, -7, -9, -2, 6, -3, 10, -11, 3, 6, -1, 7, -6, 4, 12, -8, -13, -12, 5, -5, -8, 9, 2}}

'        ' Turnover Notches:
'        ' Each rotor has a turnover letter that, when reached shifts the left rotor by one position. The number represents the nth letter in the alphabet

'        Public Const NOTCH_R_I As Integer = 17   ' Turn at Q
'        Public Const NOTCH_R_II As Integer = 5   ' Turn at E
'        Public Const NOTCH_R_III As Integer = 22 ' Turn at V
'        Public Const NOTCH_R_IV As Integer = 10  ' Turn at J
'        Public Const NOTCH_R_V As Integer = 26   ' Turn at Z 

'        ' Reflectors:
'        ' How many positions does the reflector shift the signal when it returns the signal for each letter. Positive for going downwards and negative for upwards.

'        Public Reflector_A = {0, 4, 8, 10, 22, -4, 6, 18, 16, 13, -8, 12, -6, -10, 4, 2, 5, -2, -4, 1, -1, -5, -13, -12, -16, -18, -22}
'        Public Reflector_B = {0, -2, -10, -8, 4, 12, 13, 5, -4, 7, -12, 3, -5, 2, -3, -2, -7, -12, 10, 13, 6, 8, 1, -1, 12, 2, -6}
'        Public Reflector_C = {0, 5, -6, 13, 6, 4, -5, 8, -9, -4, -6, 7, -12, 11, 9, -8, 13, 3, -7, 2, -3, -2, 6, -9, -11, 9, 12}

'        ' Plugboard:

'        Public Use_Plgbrd As Boolean = False
'        Public Plgbrd_Stngs(27) As Integer

'    End Module

'    'ENIGMA

'    Public Class Enigma
'        ' Variables
'        Dim InputTextLenght_Old As Integer
'        Dim SpacingCounter As Integer

'        ' PROGRAM STARTS HERE
'        Private Sub Enigma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'            Use_Default_Config()
'            'Decode.Show()
'        End Sub

'        ' Updates the UI with the Rotor Ring Positions
'        Public Sub Update_Rotors_Pos()
'            tb_RotorL_pos.Text = Alpha(Turnover(1) + 1)
'            tb_RotorM_pos.Text = Alpha(Turnover(2) + 1)
'            tb_RotorR_pos.Text = Alpha(Turnover(3) + 1)
'        End Sub

'        Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Input.KeyPress

'            If Char.IsLower(e.KeyChar) Then

'                'Convert to uppercase, and put at the caret position in the TextBox.
'                Input.SelectedText = Char.ToUpper(e.KeyChar)

'                e.Handled = True
'            End If

'            If Not (Asc(e.KeyChar) = 8) Then
'                If Not ((Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90)) Then

'                    e.KeyChar = ChrW(0)
'                    e.Handled = True
'                End If
'            End If

'        End Sub

'        ' Reads input and handles output generation based on it
'        Private Sub Input_TextChanged(sender As Object, e As EventArgs) Handles Input.TextChanged

'            If Input.TextLength > 0 Then
'                Dim x As Char = UCase(Input.Text(Input.TextLength - 1))

'                ' If change happened in middle of text
'                If Input.SelectionStart < Input.TextLength Or Input.TextLength = InputTextLenght_Old Then
'                    ' Reset and Encode
'                    Output.Clear()
'                    Turnover(1) = Asc(cb_Rotor_Start_L.SelectedItem) - 65
'                    Turnover(2) = Asc(cb_Rotor_Start_M.SelectedItem) - 65
'                    Turnover(3) = Asc(cb_Rotor_Start_R.SelectedItem) - 65
'                    Update_Rotors_Pos()

'                    For i As Integer = 0 To Input.TextLength - 1
'                        x = Input.Text(i)
'                        Output.Text += Encode.encode(x)
'                    Next

'                    InputTextLenght_Old = Input.TextLength
'                    ' If change happened at the end of text
'                ElseIf Input.TextLength > InputTextLenght_Old Then
'                    ' If characters have been aded:
'                    Dim encodelist As String = Microsoft.VisualBasic.Right(Input.Text, Input.TextLength - InputTextLenght_Old)

'                    For i As Integer = 0 To encodelist.Length - 1
'                        x = encodelist(i)
'                        Output.Text += Encode.encode(x)
'                    Next

'                    InputTextLenght_Old = Input.TextLength

'                ElseIf Input.TextLength < InputTextLenght_Old Then
'                    ' If characters have been removed:
'                    For i As Integer = Input.TextLength To InputTextLenght_Old - 1
'                        Rotors_Turnover_Backwards()
'                        Output.Text = Microsoft.VisualBasic.Left(Output.Text, Len(Output.Text) - 1)
'                    Next

'                    Update_Rotors_Pos()
'                    InputTextLenght_Old = Input.TextLength

'                End If
'            Else
'                b_Reset.PerformClick()
'            End If
'        End Sub

'        ' Resets the UI and the machine to the state it was after being configured.
'        Private Sub b_Reset_Click(sender As Object, e As EventArgs) Handles b_Reset.Click

'            InputTextLenght_Old = 0
'            Input.Clear()
'            Output.Clear()
'            Turnover(1) = Asc(cb_Rotor_Start_L.SelectedItem) - 65
'            Turnover(2) = Asc(cb_Rotor_Start_M.SelectedItem) - 65
'            Turnover(3) = Asc(cb_Rotor_Start_R.SelectedItem) - 65
'            Update_Rotors_Pos()

'        End Sub

'        ' Congfigures the Machine
'        Private Sub b_Config_Click(sender As Object, e As EventArgs) Handles b_Config.Click
'            Config.Configure()
'        End Sub
'    End Class

'    'DECODE
'    Public Class Decode

'        Private Sub b_Decode_Click(sender As Object, e As EventArgs) Handles b_Decode.Click
'            Dim Input As String = tb_Decode_Input.Text
'            Dim Output As String = tb_Decode_Output.Text
'            Dim Match As Integer
'            Use_Default_Config()

'            For R_Left As Integer = 1 To 5
'                For R_Mid As Integer = 1 To 5
'                    For R_Right As Integer = 1 To 5

'                        If R_Left = 1 Then Enigma.cb_Rotor_L.SelectedItem = "I"
'                        If R_Left = 2 Then Enigma.cb_Rotor_L.SelectedItem = "II"
'                        If R_Left = 3 Then Enigma.cb_Rotor_L.SelectedItem = "III"
'                        If R_Left = 4 Then Enigma.cb_Rotor_L.SelectedItem = "IV"
'                        If R_Left = 5 Then Enigma.cb_Rotor_L.SelectedItem = "V"

'                        If R_Mid = 1 Then Enigma.cb_Rotor_M.SelectedItem = "I"
'                        If R_Mid = 2 Then Enigma.cb_Rotor_M.SelectedItem = "II"
'                        If R_Mid = 3 Then Enigma.cb_Rotor_M.SelectedItem = "III"
'                        If R_Mid = 4 Then Enigma.cb_Rotor_M.SelectedItem = "IV"
'                        If R_Mid = 5 Then Enigma.cb_Rotor_M.SelectedItem = "V"

'                        If R_Right = 1 Then Enigma.cb_Rotor_R.SelectedItem = "I"
'                        If R_Right = 2 Then Enigma.cb_Rotor_R.SelectedItem = "II"
'                        If R_Right = 3 Then Enigma.cb_Rotor_R.SelectedItem = "III"
'                        If R_Right = 4 Then Enigma.cb_Rotor_R.SelectedItem = "IV"
'                        If R_Right = 5 Then Enigma.cb_Rotor_R.SelectedItem = "V"

'                        Config.Configure()

'                        For rotor As Integer = 0 To 2
'                            If rotor = 0 Then Enigma.cb_Reflector.SelectedItem = "Reflector A"
'                            If rotor = 1 Then Enigma.cb_Reflector.SelectedItem = "Reflector B"
'                            If rotor = 2 Then Enigma.cb_Reflector.SelectedItem = "Reflector C"
'                            Config.Configure()

'                            For l As Integer = 0 To 25
'                                For m As Integer = 0 To 25
'                                    For r As Integer = 0 To 25

'                                        Turnover(1) = l
'                                        Turnover(2) = m
'                                        Turnover(3) = r

'                                        Match = 0

'                                        For i As Integer = 0 To Input.Length - 1
'                                            If Output(i) <> Encode.encode(Input(i)) Then
'                                                Exit For
'                                            Else
'                                                Match += 1
'                                            End If
'                                        Next

'                                        If Match = Output.Length Then
'                                            tb_Solution.AppendText(R_Left.ToString() + R_Mid.ToString() + R_Right.ToString() + " " + Alpha(l + 1) + Alpha(m + 1) + Alpha(r + 1) + " " + rotor.ToString() + vbCrLf)
'                                        End If

'                                    Next
'                                Next
'                            Next
'                        Next
'                    Next
'                Next
'            Next

'        End Sub
'    End Class
'End Module
