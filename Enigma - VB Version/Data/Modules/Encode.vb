Public Module Encode

    ' Adjusts position to it's wrapp-around value to make sure it is always between [1, 26]
    Function Adj(ByVal pos As Integer) As Integer

        If (pos > 26) Then
            Return pos Mod 26
        ElseIf (pos <= 0) Then
            Return pos + 26
        Else
            Return pos
        End If

    End Function

    ' Adjust signal after going through the reflector.
    Function Rotor_Ref(ByVal pos As UInteger) As Integer

        Return Adj(pos + Reflector(Config(0), pos))

    End Function

    ' Calculates on what position will the signal enter the reflector.
    Function Rotor_RtL(ByVal pos As Integer) As Integer

        For j As Integer = 3 To 1 Step -1
            pos = Adj(pos + Rotor(Config(j), 0, Adj(pos + Turnover(j))))
        Next

        Return pos

    End Function

    ' Calculates on what position will the signal enter the plugboard / lightboard.
    Function Rotor_LtR(ByVal pos As Integer) As Integer

        For j As Integer = 1 To 3
            pos = Adj(pos + Rotor(Config(j), 1, Adj(pos + Turnover(j))))
        Next

        Return pos

    End Function

    ' Turns the right rotor once and the other rotors if a turnover notch is in place.
    Sub Rotors_Turnover()

        Turnover(3) = Adj(Turnover(3) + 1) Mod 26
        If Turnover(3) = TurnNotch(Config(3)) Then
            Turnover(2) = Adj(Turnover(2) + 1) Mod 26
        End If

        If Turnover(2) = TurnNotch(Config(2)) And Turnover(3) = TurnNotch(Config(3)) + 1 Then
            Turnover(1) = Adj(Turnover(1) + 1) Mod 26
        End If

        VisualUI.Update_Rotors_Pos()

    End Sub

    ' Reverts the last turnover.
    Public Sub Rotors_Turnover_Backwards()

        Turnover(3) = (Turnover(3) + 25) Mod 26
        If Turnover(3) = TurnNotch(3) Then
            Turnover(2) = (Turnover(2) + 25) Mod 26
        End If

        If Turnover(2) = TurnNotch(2) And Turnover(3) = TurnNotch(3) Then
            Turnover(1) = (Turnover(1) + 25) Mod 26
        End If

        VisualUI.Update_Rotors_Pos()

    End Sub

    ' Gets a character and encodes it.
    Function encode(ByVal x As Char) As Char

        ' Space prezervation
        If x = " " And VisualUI.PreserveSpacing.Checked Then Return Alpha(0)

        ' Convert the letter to it's position in the Aplhabet
        Dim pos As Integer = Asc(x) - 64

        ' Turnover Rotors
        Rotors_Turnover()

        ' Pass the signal through the machine and calculate its path
        pos = Adj(pos + Plugboard(pos))
        pos = Rotor_RtL(pos)
        pos = Rotor_Ref(pos)
        pos = Rotor_LtR(pos)
        pos = Adj(pos + Plugboard(pos))

        ' Convert the position in the Alphabet back to the letter
        Return Alpha(pos)

    End Function

End Module
