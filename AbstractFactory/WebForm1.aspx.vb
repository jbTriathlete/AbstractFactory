Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub GetFlatRate_Click(sender As Object, e As EventArgs) Handles GetFlatRate.Click
        Dim flat As New LifeInsuranceFlat(txtName.Text, txtTitle.Text, txtAge.Text, txtSalary.Text, "Life Insurance", 6, 100000)
        DisplayFlatRate.InnerText = "Here is your Flat rate Life Insurance quote for  " & flat.PeeOn.name & " = " & flat.CalculateRate() & vbCrLf &
            "You will have a coverage amount of " & flat.GetCoverage
    End Sub

    Private Sub GetMultiple_Click(sender As Object, e As EventArgs) Handles GetMultiple.Click
        Dim multi As New LifeInsuranceMultiple(txtName.Text, txtTitle.Text, txtAge.Text, txtSalary.Text, "Life Insurance", 6, txtMultiple.Text)
        DisplayFlatRate.InnerText = "Here is your Multiple of Salary rate for  " & multi.PeeOn.name & " = " & multi.CalculateRate() & vbCrLf &
            "You will have a coverage amount of " & multi.GetCoverage
    End Sub
End Class