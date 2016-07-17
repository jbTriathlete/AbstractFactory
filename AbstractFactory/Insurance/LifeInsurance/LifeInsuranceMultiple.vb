Public Class LifeInsuranceMultiple
    Inherits BasePlan
    Private Property multiple As Integer

    Public Sub New(_name As String, _title As String, _age As Integer, _salary As Decimal, _planName As String, _planType As Integer, _multiple As Integer)
        MyBase.New(_name, _title, _age, _salary, _planName, _planType)
        multiple = _multiple
    End Sub

    Public Overrides Function CalculateRate() As Decimal
        Return (multiple * PeeOn.salary) * 0.3 / 10000
    End Function

    Public Overrides Function GetCoverage() As Decimal
        Return (multiple * PeeOn.salary)
    End Function
End Class
