''' <summary>
''' A module that contains general utility functions and constants for the poker game.
''' Includes suit and value arrays, a method for checking game status, 
''' a utility function for retrieving dictionary values, and a dictionary of hand multipliers.
''' </summary>
Module Generals

    ''' <summary>
    ''' An array of strings representing the four suits in a standard deck of cards.
    ''' </summary>
    Public suits As String() = {"Hearts", "Diamonds", "Clubs", "Spades"}

    ''' <summary>
    ''' An array of strings representing the values of cards in a standard deck.
    ''' Ranges from "2" to "Ace".
    ''' </summary>
    Public values As String() = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace"}

    ''' <summary>
    ''' Displays a message box indicating that there is no game currently in session.
    ''' </summary>
    Public Sub gameIsNotInSession()
        MessageBox.Show("Il n'y as pas de partie en cours", "Erreur Partie en Cours", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    ''' <summary>
    ''' Retrieves a value from a dictionary based on the specified key.
    ''' If the key does not exist, returns the default value for the type.
    ''' </summary>
    ''' <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    ''' <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    ''' <param name="keyToSearch">The key to search for in the dictionary.</param>
    ''' <param name="dict">The dictionary to search in.</param>
    ''' <returns>The value associated with the specified key, or the default value if the key is not found.</returns>
    Public Function GetValueFromDictionary(Of TKey, TValue)(ByVal keyToSearch As TKey, ByVal dict As Dictionary(Of TKey, TValue)) As TValue
        Dim value As TValue
        If dict.TryGetValue(keyToSearch, value) Then
            Return value
        Else
            If GetType(TValue) Is GetType(String) Then
                Return CType(CObj(String.Empty), TValue)
            Else
                Return Nothing
            End If
        End If
    End Function

    ''' <summary>
    ''' A dictionary that maps hand names to their corresponding multipliers.
    ''' Used to calculate the winnings based on the type of hand.
    ''' </summary>
    Public handNameToMultiplier As New Dictionary(Of String, Integer) From {
        {"HighCard", 0}, ' Generally not a winning hand
        {"Pair", 1},
        {"TwoPair", 3},
        {"ThreeOfAKind", 5},
        {"Straight", 10},
        {"Flush", 15},
        {"FullHouse", 20},
        {"FourOfAKind", 25},
        {"StraightFlush", 50},
        {"RoyalFlush", 100}
    }

    Public Sub NegativeMessageBox(message As String, title As String)
        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Public Sub PositiveMessageBox(message As String, title As String)
        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Module
