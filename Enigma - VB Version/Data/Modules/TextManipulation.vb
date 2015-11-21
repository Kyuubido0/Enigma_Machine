' Script Dependancies
Imports System
Imports System.IO
Imports System.Text
Imports System.Collections.Generic

Public Module TextManipulation

    ' Exports current text in output in a txt file
    Public Sub Export()
        Dim FilePath As String = vbEmpty

        If VisualUI.ExportDialog.ShowDialog = DialogResult.OK Then
            FilePath = VisualUI.ExportDialog.FileName
        End If

        Dim fs As FileStream = File.Create(FilePath)
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(VisualUI.Output.Text)
        fs.Write(info, 0, info.Length)
        fs.Close()

    End Sub

    ' Imports text from a file into the input.
    Public Sub Import()
        Dim FilePath As String = vbEmpty
        Dim FileContent As String

        If VisualUI.ImportDialog.ShowDialog = DialogResult.OK Then
            FilePath = VisualUI.ImportDialog.FileName
        End If

        FileContent = My.Computer.FileSystem.ReadAllText(FilePath)

        For i As Integer = 0 To FileContent.Length - 1
            If (Asc(FileContent(i)) >= 97 And Asc(FileContent(i)) <= 122) Or (Asc(FileContent(i)) >= 65 And Asc(FileContent(i)) <= 90) Then
                VisualUI.Input.Text += FileContent(i)
            End If
        Next
    End Sub


End Module
