Public MustInherit Class BasePlan
    Public PeeOn As IEmployee
    Public Property PlanName As String
    Public Property PlanType As Integer
    Public MustOverride Function CalculateRate() As Decimal
    Public MustOverride Function GetCoverage() As Decimal
End Class
