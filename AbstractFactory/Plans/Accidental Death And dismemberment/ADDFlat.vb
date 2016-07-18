Public Class ADDFlat
    Inherits BasePlan
    Public Property coverageAmount As Decimal

    Public Sub New(_name As String, _title As String, _age As Integer, _salary As Decimal, _planName As String, _planType As Integer, _coverageAmount As Decimal)
        PeeOn = New Employee(_name, _title, _age, _salary)
        PlanName = _planName
        PlanType = _planType
        coverageAmount = _coverageAmount
    End Sub

    Public Overrides Function CalculateRate() As Decimal
        Return 1.8 * PeeOn.age
    End Function

    Public Overrides Function GetCoverage() As Decimal
        Return coverageAmount
    End Function


End Class
