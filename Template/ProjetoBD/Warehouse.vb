Public Class Warehouse
    Private _id As Integer
    Private _capacity As Integer
    Private _numStore As Integer

    Property ID() As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            If value = 0 Then
                Throw New Exception("Warehouse's ID field can't be equals zero")
                Exit Property
            End If
            _id = value
        End Set
    End Property

    Property Capacity() As Integer
        Get
            Return _capacity
        End Get
        Set(value As Integer)
            If value = 0 Then
                Throw New Exception("Warehouse's capacity field can't be equals zero")
                Exit Property
            End If
            _capacity = value
        End Set
    End Property

    Property NumStore() As Integer
        Get
            Return _numStore
        End Get
        Set(value As Integer)
            If value = 0 Then
                Throw New Exception("Warehouse's store number field can't be equals zero")
                Exit Property
            End If
            _numStore = value
        End Set
    End Property

End Class
