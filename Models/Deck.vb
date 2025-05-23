''' <summary>
''' Represents a deck of playing cards for the poker game.
''' Manages the shuffling and dealing of cards.
''' </summary>
Public Class Deck
    Private _rand As New Random()
    Public Property Cards As List(Of Card)

    ''' <summary>
    ''' Initializes a new instance of the <see cref="Deck"/> class.
    ''' Creates a standard deck of 52 playing cards.
    ''' </summary>
    Public Sub New()
        Cards = New List(Of Card)()
        Dim suits As String() = {"Hearts", "Diamonds", "Clubs", "Spades"}
        Dim ranks As String() = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace"}
        For Each suit As String In suits
            For Each rank As String In ranks
                Cards.Add(New Card(suit, rank))
            Next
        Next
    End Sub

    ''' <summary>
    ''' Shuffles the deck by randomly reordering the cards.
    ''' Uses a random number generator to ensure a different order each time.
    ''' </summary>
    Public Sub Shuffle()
        Cards = Cards.OrderBy(Function(a) _rand.Next()).ToList()
    End Sub

    ''' <summary>
    ''' Draws a random card from the deck.
    ''' Removes the drawn card from the deck to prevent it from being drawn again.
    ''' </summary>
    ''' <returns>A <see cref="Card"/> object if the deck is not empty; otherwise, returns <c>Nothing</c>.</returns>
    Public Function DrawCard() As Card
        If Cards.Count = 0 Then
            Return Nothing
        End If
        Dim index As Integer = _rand.Next(Cards.Count)
        Dim card As Card = Cards(index)
        Cards.RemoveAt(index)
        Return card
    End Function
End Class
