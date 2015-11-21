Public Class Multilevel_Encryption

    Shared Setting_List(99, 6) As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim k As Integer = 0
        For i As Integer = 1 To tb_Setting_List.TextLength / 6
            For j As Integer = 0 To 7
                Setting_List(i, j) = Convert.ToInt32(tb_Setting_List.Text(k))
                k = k + 1
            Next
        Next
    End Sub
End Class