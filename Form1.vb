''' <summary>
''' The main form class for the poker game application.
''' Handles the game logic, user interactions, and UI updates.
''' </summary>
Public Class Form1
    ' Déclarer et initialiser les variables liées au jeu
    Dim gameManager As GameManager
    Dim bid As Integer = 10
    Dim winnings As Integer = 0
    Dim exchangeCount As Integer = 0
    Const maxExchanges As Integer = 1

    ''' <summary>
    ''' Handles the load event of the form. 
    ''' Initializes the NotificationManager and sets up initial values.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The event data.</param>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gameManager = New GameManager() ' Initialize the GameManager
        numBid.Value = bid
        lblWinnings.Text = winnings
    End Sub

    ''' <summary>
    ''' Initializes the game by checking credits, setting up the deck and hand,
    ''' updating the UI, and preparing for card exchanges.
    ''' </summary>
    Private Sub InitializeGame()
        If numCredits.Value < bid Then
            Generals.NegativeMessageBox("Crédits insuffisants. Veuillez réduire votre mise ou ajouter plus de crédits", "Crédits Insuffisants")
            Exit Sub
        End If

        numCredits.Value -= bid
        gameManager.InitializeDeckAndHand()

        AddHandler gameManager.CurrentHand.Win, AddressOf OnWin
        AddHandler gameManager.CurrentHand.Lose, AddressOf OnLose

        DisplayHandImages()
        ResetCheckBoxes(False)
        exchangeCount = 0
        btnContinue.Enabled = True
        btnContinue.Visible = True
        btnCheckHand.Visible = False
        btnCheckHand.Enabled = False
    End Sub

    ''' <summary>
    ''' Handles the Play button click event. 
    ''' Starts the game by setting the bid and initializing the game if the user has enough credits.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The event data.</param>
    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        bid = numBid.Value

        ' Vérification des crédits
        If numCredits.Value < bid Then
            Generals.NegativeMessageBox("Crédits insuffisants. Veuillez réduire votre mise ou ajouter plus de crédits", "Crédits Insuffisants")
            Exit Sub
        End If

        InitializeGame()
    End Sub


    ''' <summary>
    ''' Handles the Continue button click event.
    ''' Allows the player to exchange cards if they haven't reached the maximum exchange count.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The event data.</param>
    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        If gameManager.CurrentDeck Is Nothing OrElse gameManager.CurrentHand Is Nothing Then
            Generals.NegativeMessageBox("Il n'y a pas de partie en cours", "Aucune Partie en Cours")
            Return
        End If

        If exchangeCount >= maxExchanges Then
            Generals.NegativeMessageBox("Vous avez déjà échangé vos cartes.", "Échange Invalide")
            btnContinue.Enabled = False
            btnContinue.Visible = False
            btnCheckHand.Visible = True
            btnCheckHand.Enabled = True
            Exit Sub
        End If

        Dim cardsToKeep As List(Of Boolean) = getCheckedStatus()
        gameManager.ChangeCards(cardsToKeep)
        DisplayHandImages()
        ResetCheckBoxes()
        exchangeCount += 1

        If exchangeCount = maxExchanges Then
            btnContinue.Enabled = False
            btnContinue.Visible = False
            btnCheckHand.Visible = True
            btnCheckHand.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' Handles the Check Hand button click event.
    ''' Checks if the player's hand is a winning hand and updates the winnings accordingly.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The event data.</param>
    Private Async Sub btnCheckHand_Click(sender As Object, e As EventArgs) Handles btnCheckHand.Click
        gameManager.CheckForWin(Generals.handNameToMultiplier)

        Application.DoEvents()
        Await Task.Delay(500)

        btnCheckHand.Enabled = False
        btnCheckHand.Visible = False
        InitializeGame()
        pnlControls.Enabled = True
    End Sub

    ''' <summary>
    ''' Displays the images of the player's current hand on the UI.
    ''' Updates the picture boxes with the corresponding card images.
    ''' </summary>
    Private Sub DisplayHandImages()
        Dim handImages As List(Of String) = gameManager.GetHandImages()
        pbHand1.ImageLocation = handImages(0)
        pbHand2.ImageLocation = handImages(1)
        pbHand3.ImageLocation = handImages(2)
        pbHand4.ImageLocation = handImages(3)
        pbHand5.ImageLocation = handImages(4)
    End Sub

    ''' <summary>
    ''' Retrieves the checked status of the checkboxes that represent the cards to be kept.
    ''' </summary>
    ''' <returns>A list of Boolean values indicating the checked status of each card checkbox.</returns>
    Private Function getCheckedStatus() As List(Of Boolean)
        Return New List(Of Boolean) From {chkHand1.Checked, chkHand2.Checked, chkHand3.Checked, chkHand4.Checked, chkHand5.Checked}
    End Function

    ''' <summary>
    ''' Resets the checkboxes that represent the cards.
    ''' Can either reset all checkboxes or only those that are unchecked.
    ''' </summary>
    ''' <param name="onlyUnchecked">Indicates whether only unchecked boxes should be reset.</param>
    ''' <param name="cardsToKeep">Optional list of Boolean values indicating which cards to keep.</param>
    Private Sub ResetCheckBoxes(Optional onlyUnchecked As Boolean = False, Optional cardsToKeep As List(Of Boolean) = Nothing)
        If Not onlyUnchecked Then
            chkHand1.Checked = False
            chkHand2.Checked = False
            chkHand3.Checked = False
            chkHand4.Checked = False
            chkHand5.Checked = False
        ElseIf cardsToKeep IsNot Nothing AndAlso cardsToKeep.Count = 5 Then
            If Not cardsToKeep(0) Then chkHand1.Checked = False
            If Not cardsToKeep(1) Then chkHand2.Checked = False
            If Not cardsToKeep(2) Then chkHand3.Checked = False
            If Not cardsToKeep(3) Then chkHand4.Checked = False
            If Not cardsToKeep(4) Then chkHand5.Checked = False
        End If
    End Sub

    ''' <summary>
    ''' Handles the Exit button click event.
    ''' Exits the application and prompts the user to cash out any winnings before exiting.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The event data.</param>
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        If lblWinnings.Text > 0 Then

            Dim isExiting As DialogResult = MessageBox.Show($"Vous encaissez {lblWinnings.Text} de gains!", "Quitter l'application", MessageBoxButtons.YesNo)

            If isExiting = DialogResult.Yes Then
                Application.Exit()
            End If

        End If
    End Sub

    ''' <summary>
    ''' Updates the credits after a win or loss.
    ''' </summary>
    ''' <param name="multiplier">The multiplier to apply to the bid if it's a winning hand.</param>
    Public Sub UpdateCredits(multiplier As Integer)
        If multiplier > 0 Then
            winnings += bid * multiplier
            lblWinnings.Text = winnings.ToString()
        End If
    End Sub

    Private Sub OnWin()
        Generals.PositiveMessageBox("Félicitations! Vous avez gagné!", "Résultat")
    End Sub

    Private Sub OnLose()
        Generals.NegativeMessageBox("Désolé, vous avez perdu. Réessayez!", "Résultat")
    End Sub

End Class
