<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Decode
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tb_Decode_Input = New System.Windows.Forms.TextBox()
        Me.tb_Decode_Output = New System.Windows.Forms.TextBox()
        Me.b_Decode = New System.Windows.Forms.Button()
        Me.tb_Solution = New System.Windows.Forms.RichTextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'tb_Decode_Input
        '
        Me.tb_Decode_Input.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_Decode_Input.Location = New System.Drawing.Point(13, 13)
        Me.tb_Decode_Input.Name = "tb_Decode_Input"
        Me.tb_Decode_Input.Size = New System.Drawing.Size(259, 20)
        Me.tb_Decode_Input.TabIndex = 0
        '
        'tb_Decode_Output
        '
        Me.tb_Decode_Output.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_Decode_Output.Location = New System.Drawing.Point(13, 40)
        Me.tb_Decode_Output.Name = "tb_Decode_Output"
        Me.tb_Decode_Output.Size = New System.Drawing.Size(259, 20)
        Me.tb_Decode_Output.TabIndex = 1
        '
        'b_Decode
        '
        Me.b_Decode.Location = New System.Drawing.Point(13, 67)
        Me.b_Decode.Name = "b_Decode"
        Me.b_Decode.Size = New System.Drawing.Size(259, 23)
        Me.b_Decode.TabIndex = 2
        Me.b_Decode.Text = "Brute Force Attack"
        Me.b_Decode.UseVisualStyleBackColor = True
        '
        'tb_Solution
        '
        Me.tb_Solution.Location = New System.Drawing.Point(13, 97)
        Me.tb_Solution.Name = "tb_Solution"
        Me.tb_Solution.Size = New System.Drawing.Size(259, 96)
        Me.tb_Solution.TabIndex = 3
        Me.tb_Solution.Text = ""
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(13, 200)
        Me.ProgressBar1.Maximum = 15
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(259, 23)
        Me.ProgressBar1.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 229)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(259, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Brute Force Attack"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Decode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.tb_Solution)
        Me.Controls.Add(Me.b_Decode)
        Me.Controls.Add(Me.tb_Decode_Output)
        Me.Controls.Add(Me.tb_Decode_Input)
        Me.Name = "Decode"
        Me.Text = "Decode"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tb_Decode_Input As System.Windows.Forms.TextBox
    Friend WithEvents tb_Decode_Output As System.Windows.Forms.TextBox
    Friend WithEvents b_Decode As System.Windows.Forms.Button
    Friend WithEvents tb_Solution As System.Windows.Forms.RichTextBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
