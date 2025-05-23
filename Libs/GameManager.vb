''' <summary>
''' Manages the overall game logic, including the deck and hand of cards.
''' Responsible for initializing the deck, handling card changes, and checking for winning hands.
''' </summary>
Public Class GameManager

    Public Property CurrentDeck As Deck
    Public Property CurrentHand As Hand

    ''' <summary>
    ''' Initializes the deck and hand for a new game.
    ''' Shuffles the deck and deals a new hand to the player.
    ''' </summary>
    Public Sub InitializeDeckAndHand()
        CurrentDeck = New Deck()
        CurrentDeck.Shuffle()
        CurrentHand = New Hand(CurrentDeck)
    End Sub

    ''' <summary>
    ''' Changes the cards in the player's hand based on which cards the player chooses to keep.
    ''' </summary>
    ''' <param name="cardsToKeep">A list of Boolean values indicating which cards to keep.</param>
    Public Sub ChangeCards(cardsToKeep As List(Of Boolean))
        CurrentHand.changeCards(CurrentDeck, cardsToKeep)
    End Sub

    ''' <summary>
    ''' Checks if the current hand is a winning hand based on the provided multipliers.
    ''' </summary>
    ''' <param name="handNameToMultiplier">A dictionary mapping hand names to their corresponding multipliers.</param>
    ''' <returns><c>True</c> if the hand is a winning hand; otherwise, <c>False</c>.</returns>
    Public Function CheckForWin(handNameToMultiplier As Dictionary(Of String, Integer)) As Boolean
        Dim multiplier As Integer = CurrentHand.CheckHandForWin(handNameToMultiplier)
        Form1.UpdateCredits(multiplier)
        Return multiplier > 0
    End Function

    ''' <summary>
    ''' Retrieves the images representing the cards in the player's current hand.
    ''' </summary>
    ''' <returns>A list of strings representing the image paths or identifiers for the current hand.</returns>
    Public Function GetHandImages() As List(Of String)
        CurrentHand.getImagesHand()
        Return CurrentHand._listOfImages
    End Function

    ''' <summary>
    ''' Generates an identifier for the player's current hand.
    ''' The identifier can be used to determine the hand's rank or type.
    ''' </summary>
    ''' <returns>A string representing the identifier of the current hand.</returns>
    Public Function GetHandIdentifier() As String
        Return CurrentHand.GenerateHandIdentifier()
    End Function
End Class
