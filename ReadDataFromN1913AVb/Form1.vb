Imports Ivi.Visa.Interop



Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Dim N1913A As Agilent.CommandExpert.ScpiNet.AgN191x_EPM_A_01_03.AgN191x_EPM = New Agilent.CommandExpert.ScpiNet.AgN191x_EPM_A_01_03.AgN191x_EPM("USB0::0x2A8D::0x5418::MY57190050::0::INSTR")
        'N1913A.SCPI.DISPlay.ENABle.Command(False)
        'N1913A.SCPI.DISPlay.ENABle.Command(True)

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim rm As ResourceManager = New ResourceManager()
        Dim addresses = rm.FindRsrc("USB?*INSTR")
    End Sub
End Class
