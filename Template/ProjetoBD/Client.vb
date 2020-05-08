Public Class Client
    Private _nif As String
    Private _address As String
    Private _name As String
    Private _phone As Integer

    Property NIF() As String
        Get
            Return _nif
        End Get
        Set(value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("NIF number field can't be empty")
                Exit Property
            End If
            _nif = value
        End Set
    End Property

    Property Address() As String
        Get
            Return _address
        End Get
        Set(value As String)
            value = _address
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

    Property Phone() As Integer
        Get
            Return _phone
        End Get
        Set(value As Integer)
            If value = 0 Then
                Throw New Exception("Phone number field can't be equal zero")
                Exit Property
            End If
            _phone = value
        End Set
    End Property

End Class
