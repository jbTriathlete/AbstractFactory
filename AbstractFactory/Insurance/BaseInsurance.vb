Public MustInherit Class BasePlan

    Public PeeOn As Employee

    Public Sub New(ByVal _name As String, ByVal _title As String, ByVal _age As Integer, ByVal _salary As Decimal, ByVal _planName As String, ByVal _planType As Integer)
        PeeOn = New Employee(_name, _title, _age, _salary)
        PlanName = _planName
        plantype = _planType
    End Sub

    Public Property PlanName As String

    Public Property PlanType As Integer

    Public MustOverride Function CalculateRate() As Decimal

    Public MustOverride Function GetCoverage() As Decimal

End Class
