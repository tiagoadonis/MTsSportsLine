Public Class Store
    Private _name As String
    Private _location As String
    Private _numStore As Integer

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

    Property Location() As String
        Get
            Return _location
        End Get
        Set(value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("Location field can't be empty")
                Exit Property
            End If
            _location = value
        End Set
    End Property

    Property NumStore() As Integer
        Get
            Return _numStore
        End Get
        Set(value As Integer)
            If value = 0 Then
                Throw New Exception("Store's number field can't be equal zero")
                Exit Property
            End If
            _numStore = value
        End Set
    End Property

End Class
