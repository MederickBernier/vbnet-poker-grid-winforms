Imports System.IO

''' <summary>
''' Represents a player's hand of cards in the poker game.
''' Manages the current hand, allows card changes, generates hand identifiers, and checks for winning hands.
''' </summary>
Public Class Hand

    ''' <summary>
    ''' Stores the list of cards that have been retired from the current hand.
    ''' </summary>
    ''' <value>A list of <see cref="Card"/> objects representing the retired cards.</value>
    Private Property _retiredCards As List(Of Card)

    ''' <summary>
    ''' Holds an instance of the <see cref="Random"/> class for generating random numbers.
    ''' </summary>
    ''' <value>A private instance of <see cref="Random"/>.</value>
    Private Property _rand As Random

    ''' <summary>
    ''' Stores the current hand of cards held by the player.
    ''' </summary>
    ''' <value>A list of <see cref="Card"/> objects representing the current hand.</value>
    Public Property _currentHand As List(Of Card)

    ''' <summary>
    ''' Stores the list of image paths representing the current hand of cards.
    ''' </summary>
    ''' <value>A list of strings representing the image paths of the current hand.</value>
    Public Property _listOfImages As List(Of String)

    ''' <summary>
    ''' Occurs when the player has a winning hand.
    ''' </summary>
    Public Event Win()

    ''' <summary>
    ''' Occurs when the player does not have a winning hand.
    ''' </summary>
    Public Event Lose()

    ''' <summary>
    ''' Initializes a new instance of the <see cref="Hand"/> class.
    ''' Draws a hand of five cards from the provided deck.
    ''' </summary>
    ''' <param name="deck">The deck from which to draw the initial hand of cards.</param>
    Public Sub New(deck As Deck)
        _retiredCards = New List(Of Card)
        _currentHand = New List(Of Card)
        _rand = New Random()

        For i As Integer = 1 To 5
            Dim c As Card = deck.DrawCard()
            _currentHand.Add(c)
        Next
        _currentHand = GetSortedHand()
        getImagesHand()
    End Sub

    ''' <summary>
    ''' Retrieves the image paths for the current hand of cards and stores them in the <see cref="_listOfImages"/> property.
    ''' </summary>
    Public Sub getImagesHand()
        _listOfImages = New List(Of String)
        Dim imageDirectory As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images")

        For Each c As Card In _currentHand
            Dim s As String = Path.Combine(imageDirectory, $"{c.Image}.gif")
            _listOfImages.Add(s)
        Next
    End Sub

    ''' <summary>
    ''' Changes the cards in the current hand based on the player's choices of which cards to keep.
    ''' The replaced cards are added to the retired cards list.
    ''' </summary>
    ''' <param name="deck">The deck from which to draw new cards.</param>
    ''' <param name="cardsToKeep">A list of Boolean values indicating which cards to keep.</param>
    Public Sub changeCards(deck As Deck, cardsToKeep As List(Of Boolean))
        For i As Integer = 0 To 4
            If Not cardsToKeep(i) Then
                Dim cardToChange = _currentHand(i)
                _retiredCards.Add(cardToChange)
                _currentHand(i) = deck.DrawCard()
            End If
        Next
        _currentHand = GetSortedHand()
        getImagesHand()
    End Sub

    ''' <summary>
    ''' Generates an identifier for the current hand based on its rank and suits.
    ''' The identifier can be used to determine the hand's rank or type.
    ''' </summary>
    ''' <returns>A string representing the identifier of the current hand.</returns>
    Public Function GenerateHandIdentifier() As String
        Dim sortedHand = GetSortedHand()
        Dim handCategory As String = ClassifyHand(sortedHand)

        ' Return only the hand category to match the dictionary keys
        Return handCategory
    End Function

    ''' <summary>
    ''' Returns a sorted list of cards based on their value.
    ''' </summary>
    ''' <returns>A sorted List of Card objects.</returns>
    Private Function GetSortedHand() As List(Of Card)
        ' Create a copy of the current hand to sort
        Dim sortedHand As List(Of Card) = _currentHand.ToList()

        ' Sort the copied list
        sortedHand.Sort(Function(card1, card2) GetCardValue(card1.Value).CompareTo(GetCardValue(card2.Value)))

        ' Return the sorted list
        Return sortedHand
    End Function

    ''' <summary>
    ''' Classifies the current hand into a specific hand category (e.g., "Pair", "Flush").
    ''' </summary>
    ''' <param name="sortedHand">A sorted list of cards in the current hand.</param>
    ''' <returns>A string representing the category of the current hand.</returns>
    Private Function ClassifyHand(sortedHand As List(Of Card)) As String
        Dim rankGroups = sortedHand.GroupBy(Function(card) card.Value).OrderByDescending(Function(group) group.Count()).ThenByDescending(Function(group) GetCardValue(group.Key)).ToList()
        Dim suits = sortedHand.Select(Function(card) card.Suit).Distinct().ToList()

        ' Check for Four of a Kind, Full House, Three of a Kind, Two Pair, Pair
        Select Case rankGroups.Count
            Case 2
                If rankGroups(0).Count() = 4 Then
                    Return "FourOfAKind"
                Else
                    Return "FullHouse"
                End If
            Case 3
                If rankGroups(0).Count() = 3 Then
                    Return "ThreeOfAKind"
                Else
                    Return "TwoPair"
                End If
            Case 4
                Return "Pair"
        End Select

        ' Check for Flush
        If suits.Count = 1 Then
            ' Check for Straight Flush and Royal Flush
            If IsStraight(sortedHand) Then
                If sortedHand.Last().Value = "Ace" Then
                    Return "RoyalFlush"
                End If
                Return "StraightFlush"
            End If
            Return "Flush"
        End If

        ' Check for Straight
        If IsStraight(sortedHand) Then
            Return "Straight"
        End If

        ' If none of the above, it's a High Card
        Return "HighCard"
    End Function

    ''' <summary>
    ''' Converts a card's rank to its corresponding integer value.
    ''' </summary>
    ''' <param name="rank">The rank of the card as a string.</param>
    ''' <returns>An integer representing the value of the card's rank.</returns>
    Private Function GetCardValue(rank As String) As Integer
        Select Case rank
            Case "2" : Return 2
            Case "3" : Return 3
            Case "4" : Return 4
            Case "5" : Return 5
            Case "6" : Return 6
            Case "7" : Return 7
            Case "8" : Return 8
            Case "9" : Return 9
            Case "10" : Return 10
            Case "Jack" : Return 11
            Case "Queen" : Return 12
            Case "King" : Return 13
            Case "Ace" : Return 14
            Case Else : Return 0
        End Select
    End Function

    ''' <summary>
    ''' Checks if the current hand is a winning hand based on the provided multipliers.
    ''' </summary>
    ''' <param name="handNameToMultiplier">A dictionary mapping hand names to their corresponding multipliers.</param>
    ''' <returns>An integer representing the multiplier for the winning hand; 0 if not a winning hand.</returns>
    Public Function CheckHandForWin(handNameToMultiplier As Dictionary(Of String, Integer)) As Integer
        Dim handIdentifier As String = GenerateHandIdentifier()
        Debug.WriteLine($"Hand Identifier: {handIdentifier}")

        ' Si la main est un HighCard, traiter comme une défaite
        If handIdentifier = "HighCard" Then
            RaiseEvent Lose()
            Return 0
        End If

        ' Pour toutes les autres mains, vérifier si c'est une victoire
        If handNameToMultiplier.ContainsKey(handIdentifier) Then
            RaiseEvent Win()
            Return handNameToMultiplier(handIdentifier)
        Else
            RaiseEvent Lose()
            Return 0
        End If
    End Function



    ''' <summary>
    ''' Determines if the current hand is a straight (consecutive values).
    ''' </summary>
    ''' <param name="sortedHand">A sorted list of cards in the current hand.</param>
    ''' <returns><c>True</c> if the hand is a straight; otherwise, <c>False</c>.</returns>
    Private Function IsStraight(sortedHand As List(Of Card)) As Boolean
        For i As Integer = 0 To sortedHand.Count - 2
            If GetCardValue(sortedHand(i + 1).Value) - GetCardValue(sortedHand(i).Value) <> 1 Then
                ' Special case for Ace being low in a 5-high straight (e.g., A-2-3-4-5)
                If i = 3 AndAlso sortedHand(i + 1).Value = "Ace" AndAlso sortedHand(0).Value = "2" Then
                    Continue For
                End If
                Return False
            End If
        Next
        Return True
    End Function
End Class
