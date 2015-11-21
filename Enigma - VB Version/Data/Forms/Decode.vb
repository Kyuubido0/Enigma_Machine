Public Class Decode
    
    Private Sub b_Decode_Click(sender As Object, e As EventArgs) Handles b_Decode.Click
        Dim Input As String = tb_Decode_Input.Text
        Dim Output As String = tb_Decode_Output.Text
        Dim Match As Integer

        'Output = Output.Substring(Possible_Loc(), Input.Length)
        Use_Default_Config()

        For R_Left As Integer = 1 To 5
            For R_Mid As Integer = 1 To 5
                For R_Right As Integer = 1 To 5

                    ProgressBar1.Value = R_Left + R_Mid + R_Right
                    Config(1) = R_Left
                    Config(2) = R_Mid
                    Config(3) = R_Right

                    For rotor As Integer = 0 To 2
                        Config(0) = rotor

                        For l As Integer = 0 To 25
                            For m As Integer = 0 To 25
                                For r As Integer = 0 To 25

                                    Turnover(1) = l
                                    Turnover(2) = m
                                    Turnover(3) = r

                                    Match = 0

                                    For i As Integer = 0 To Input.Length - 1
                                        If Output(i) <> Encode.encode(Input(i)) Then
                                            Exit For
                                        Else
                                            Match += 1
                                        End If
                                    Next

                                    If Match = Output.Length Then
                                        tb_Solution.AppendText(R_Left.ToString() + R_Mid.ToString() + R_Right.ToString() + " " + Alpha(l + 1) + Alpha(m + 1) + Alpha(r + 1) + " " + rotor.ToString() + vbCrLf)

                                        Config = {rotor, R_Left, R_Mid, R_Right, l, m, r}
                                        Dim Temp_Decode As String = vbNullString
                                        Dim Temp_Char As Char
                                        For i As Integer = 0 To tb_Decode_Output.TextLength - 1
                                            Temp_Char = tb_Decode_Output.Text(i)
                                            Temp_Decode += Encode.encode(Temp_Char)
                                        Next

                                        Dim Response = MsgBox("The decoder found a possible match. Here is what the decoded string looks like. Is this ok?" + vbCrLf + Temp_Decode, MsgBoxStyle.YesNo)

                                        If Response = MsgBoxResult.Yes Then
                                            Exit Sub
                                        End If

                                    End If

                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

    End Sub

    Private Function Possible_Loc()
        Dim i As Integer = 0
        Dim ok As Boolean = False

        While Not ok And i < tb_Decode_Output.TextLength
            ok = True
            For j As Integer = 0 To tb_Decode_Input.TextLength - 1
                If tb_Decode_Input.Text(j) = tb_Decode_Output.Text(i + j) Then
                    ok = False
                    Exit For
                End If
            Next
            i = i + 1
        End While

        Return i - 1
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Input As String = tb_Decode_Input.Text
        Dim Output As String = tb_Decode_Output.Text

        Output = Output.Substring(Possible_Loc(), Input.Length)
        MsgBox(Output)
    End Sub
End Class