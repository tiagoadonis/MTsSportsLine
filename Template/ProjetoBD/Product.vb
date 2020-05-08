Public Class Product
    Private _code As Integer
    Private _price As Integer
    Private _name As String
    Private _category As String

    Property Code() As Integer
        Get
            Return _code
        End Get
        Set(value As Integer)
            If value = 0 Then
                Throw New Exception("Code field can't be equal zero")
                Exit Property
            End If
            _code = value
        End Set
    End Property

    Property Price() As Integer
        Get
            Return _price
        End Get
        Set(value As Integer)
            If value = 0 Then
                Throw New Exception("Price field can't be equal zero")
                Exit Property
            End If
            _price = value
        End Set
    End Property

    Property Name() As String
        Get
            Return _name
        End Get
        Set(value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("Name field can't be empty")
                Exit Property
            End If
            _name = value
        End Set
    End Property

    Property Category() As String
        Get
            Return _category
        End Get
        Set(value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("Category field can't be empty")
                Exit Property
            End If
            _category = value
        End Set
    End Property

End Class
