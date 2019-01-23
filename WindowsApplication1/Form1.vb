Public Class Form1
    Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click
        Dim sr As IO.StreamReader = IO.File.OpenText("C:\Users\junk\Documents\Visual Studio 2015\Projects\WindowsApplication1\PRICE&TAXDATA.txt")
        Dim name, addr, invoiceNum, firstName, lastName, CSZ As String
        Dim numChairs, numSofa, cost, tax, totalCost, costChair, costSofa, taxRate, zip As Double

        getfileInfo(sr, costChair, costSofa, taxRate)
        getuserInfo(name, addr, CSZ, numChairs, numSofa)
        splitName(name, firstName, lastName)
        splitCSZ(CSZ, zip)
    End Sub

    Sub getfileInfo(ByVal sr As IO.StreamReader, ByRef costChair As Double, ByRef costSofa As Double, ByRef taxRate As Double)
        costChair = CDbl(sr.ReadLine)
        costSofa = CDbl(sr.ReadLine)
        taxRate = CDbl(sr.ReadLine)
    End Sub

    Sub getuserInfo(ByRef name As String, ByRef addr As String, ByRef CSZ As String, ByRef numChair As Double, ByRef numSofa As Double)
        name = txtName.Text
        addr = txtAddress.Text
        CSZ = txtCSZ.Text
        numChair = CDbl(txtChairs.Text) 'chris said to check for bad user input maybe
        numSofa = CDbl(txtSofa.Text)    'same here. casting "" to double is no good
    End Sub

    Sub splitName(ByVal name As String, ByRef firstName As String, ByRef lastName As String)
        Dim words As String() = Split(name, ",")
        firstName = words(1).Trim
        lastName = words(0).Trim
        lstOutput.Items.Add(firstName & " " & lastName)
    End Sub
    Sub splitCSZ(ByVal CSZ, ByRef zip)
        Dim words As String() = Split(CSZ, " ")
        words(2).Trim.Substring(1, 4)
        zip = CDbl(words(2).Trim.Substring(1, 4))
        lstOutput.Items.Add(zip)
    End Sub
End Class
