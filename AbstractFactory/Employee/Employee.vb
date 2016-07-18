Public Class Employee
    Implements IEmployee

    Private _name As String
    Private _title As String
    Private _age As Integer
    Private _salary As Decimal
    Public Sub New(ByVal _name As String, ByVal _title As String, ByVal _age As Integer, ByVal _salary As Decimal)
        name = _name
        title = _title
        age = _age
        salary = _salary
    End Sub

    Public Property name As String Implements IEmployee.name
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Public Property title As String Implements IEmployee.title
        Get
            Return _title
        End Get
        Set(value As String)
            _title = value
        End Set
    End Property
    Public Property salary As Decimal Implements IEmployee.salary
        Get
            Return _salary
        End Get
        Set(value As Decimal)
            _salary = value
        End Set
    End Property
    Public Property age As Integer Implements IEmployee.age
        Get
            Return _age
        End Get
        Set(value As Integer)
            _age = value
        End Set
    End Property
End Class
