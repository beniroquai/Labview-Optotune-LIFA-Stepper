Public Class Form1
    Dim _Step As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Emant3001.Open()
        Emant3001.ConfigDIO(&HF0)
        Label1.Text = Emant3001.HwId
        _Step = 0
        CheckBox1.Enabled = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Timer1.Enabled = False
        Emant3001.Close()
        Label1.Text = "HwId"
        CheckBox1.Enabled = False
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Timer1.Enabled = CheckBox1.Checked
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Dim _Home As Boolean
        _Home = Emant3001.ReadDigitalBit(6)
        If _Home Then
            PictureBox1.BackColor = Color.Green
            If CheckBox3.Checked Then
                CheckBox3.Checked = False
                CheckBox1.Checked = False
            End If
        Else
            PictureBox1.BackColor = Color.Red
        End If

        Select Case _Step
            Case 0
                Emant3001.WriteDigitalPort(&HF9)
                If CheckBox2.Checked Then
                    _Step = 1
                Else
                    _Step = 3
                End If
            Case 1
                Emant3001.WriteDigitalPort(&HFC)
                If CheckBox2.Checked Then
                    _Step = 2
                Else
                    _Step = 0
                End If
            Case 2
                Emant3001.WriteDigitalPort(&HF6)
                If CheckBox2.Checked Then
                    _Step = 3
                Else
                    _Step = 1
                End If
            Case 3
                Emant3001.WriteDigitalPort(&HF3)
                If CheckBox2.Checked Then
                    _Step = 0
                Else
                    _Step = 2
                End If
        End Select
        Timer1.Enabled = CheckBox1.Checked
    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        Timer1.Interval = TrackBar1.Value
    End Sub
End Class
