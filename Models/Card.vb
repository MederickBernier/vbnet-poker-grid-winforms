''' <summary>
''' Represents a single card in the poker game.
''' Contains information about the suit and rank of the card.
''' </summary>
Public Class Card
    Public Property Suit As String
    Public Property Value As String
    Public Property Image As String

    ''' <summary>
    ''' Initializes a new instance of the <see cref="Card"/> class.
    ''' </summary>
    ''' <param name="suit">The suit of the card (e.g., Hearts, Diamonds).</param>
    ''' <param name="rank">The rank of the card (e.g., Ace, 2, King).</param>
    Public Sub New(suit As String, value As String)
        Me.Suit = suit
        Me.Value = value
        Me.Image = $"{value}Of{suit}"
    End Sub
End Class
