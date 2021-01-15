Public Class Level1

    ' John Zhang
    ' Programming 11
    ' January 6, 2020
    ' PacMan Project
    ' To do: Add all 4 ghosts 4 level 1, then load level 2 and 3

    ' Attributes to describe Pacman
#Region "Dims"
    Dim pacman(5) As Image
    Dim PacDirection As String = "Stop"
    Dim NextPacDirection As String = ""
    Dim PacSpeed As Short = 10 ' Factors of 50

    ' Attributes to describe ghosts
    Dim Ghost1(4) As Image
    Dim Ghost1Direction As String = "D"
    Dim NextGhost1Direction As String = ""
    Dim Ghost1Speed As Short = 5

    Dim Ghost2(4) As Image
    Dim Ghost2Direction As String = "D"
    Dim NextGhost2Direction As String = ""
    Dim Ghost2Speed As Short = 5

    Dim Ghost3(4) As Image
    Dim Ghost3Direction As String = "D"
    Dim nextGhost3Direction As String = ""
    Dim Ghost3Speed As Short = 5

    Dim Ghost4(4) As Image
    Dim Ghost4Direction As String = "D"
    Dim NextGhost4Direction As String = ""
    Dim Ghost4Speed As Short = 5

    ' Various Other Variables
    Dim Counter As Long = 0
    Dim Wall(-1) As PictureBox
    Dim Edible(-1) As PictureBox
    Dim Score As Short = 0
    Dim MazeCompletion As Short
    Dim PowerUpClock As Short
    Dim WallX(-1), WallY(-1) As Short
    Dim DotX(-1), DotY(-1) As Short

    ' Dim Heart
    Dim Heart As Image
    Dim life As Integer = 3
#End Region


    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        ' Key value to set nextpacdirection
        ' when it is set then we use it to see if the move is valid
        If e.KeyValue = Keys.Up Then
            NextPacDirection = "U"
        ElseIf e.KeyValue = Keys.Down Then
            NextPacDirection = "D"
        ElseIf e.KeyValue = Keys.Right Then
            NextPacDirection = "R"
        ElseIf e.KeyValue = Keys.Left Then
            NextPacDirection = "L"
        Else
            NextPacDirection = "Stop"
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Day 1 and 2
        ' 1) Pre load all the ghost and pacman images
        ' 2) Call LoadLevel and tell it to load level 1

        ' Pre load the ghost Image
        Ghost1(0) = Image.FromFile("Inky.png")
        Ghost1(1) = Image.FromFile("InkyVulnerable.png")
        Ghost2(0) = Image.FromFile("Pinky.png")
        Ghost2(1) = Image.FromFile("PinkyVulnerable.png")
        Ghost3(0) = Image.FromFile("Blinky.png")
        Ghost3(1) = Image.FromFile("BlinkyVulnerable.png")
        Ghost4(0) = Image.FromFile("Clyde.png")
        Ghost4(1) = Image.FromFile("ClydeVulnerable.png")

        'PbxGhost1.Image = Ghosts(0)

        ' Pre load all the PacMan image
        pacman(0) = Image.FromFile("B.png") ' Base Pac
        pacman(1) = Image.FromFile("U.png") ' Up
        pacman(2) = Image.FromFile("D.png") ' Down
        pacman(3) = Image.FromFile("L.png") ' Left
        pacman(4) = Image.FromFile("R.png") ' Right
        'MyPac.Image = pacman(0)

        ' Preload the Heart image
        Heart = Image.FromFile("Heart.png")
        Heart1.Image = Heart
        Heart2.Image = Heart
        Heart3.Image = Heart
        Heart4.Image = Heart

        LoadLevel(1)

    End Sub

    Private Sub LoadLevel(ByVal shtLevel As Short)
        ' For every maze level we load we need to do each of the following
        ' 1. Load up the x and y coordinates for each wall piece
        ' 2. Load up the x and y coordinates for each edible (dots, powerpellets, fruit)
        ' 3. Place our Pacman at his start location
        ' 4. Place our ghosts at thie start locations
        ' 5. Then place all of the wall tiles and edibles on the form based on the .left,

        If shtLevel = 1 Then
            ' Level 1
            WallX = {0, 50, 100, 150, 200, 250, 250, 250, 300, 350, 400, 450, 500, 550, 600, 650, 700, 750, 750, 750, 750, 750, 750, 750, 700, 700, 700, 700, 700, 650, 600, 550, 500, 450, 400, 350, 300, 250, 250, 250, 200, 150, 100, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 100, 150, 150, 100, 100, 150, 100, 150, 100, 150, 150, 100, 100, 150, 150, 100, 250, 250, 250, 300, 400, 450, 500, 600, 600, 600, 650, 650, 650, 500, 350, 400, 450, 250, 300, 350, 400, 450, 500, 550, 250, 300, 350, 400, 450, 500, 550, 600}
            WallY = {0, 0, 0, 0, 0, 0, 50, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 150, 200, 250, 300, 350, 400, 400, 450, 500, 550, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 650, 700, 700, 700, 700, 700, 700, 50, 100, 150, 200, 250, 300, 350, 400, 450, 500, 550, 600, 650, 100, 100, 150, 150, 250, 250, 350, 350, 450, 450, 500, 500, 550, 550, 600, 600, 300, 350, 400, 400, 400, 400, 400, 400, 350, 300, 300, 250, 200, 300, 300, 300, 300, 200, 200, 200, 200, 200, 200, 200, 500, 500, 500, 500, 500, 500, 500, 500}
            DotX = {461, 111, 63, 113, 163, 213, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 113, 163, 213, 213, 213, 213, 213, 213, 113, 163, 113, 163, 213, 213, 163, 213, 213, 213, 213, 263, 313, 263, 313, 313, 313, 363, 363, 363, 313, 263, 263, 313, 363, 413, 463, 513, 563, 663, 613, 663, 663, 613, 563, 513, 463, 413, 413, 513, 563, 563, 563, 563, 613, 363, 413, 463, 513, 563, 613, 613, 363, 413, 463, 513, 663, 713, 713, 713, 713, 713, 663, 663}
            DotY = {361, 211, 63, 63, 63, 63, 113, 163, 213, 263, 313, 363, 413, 463, 513, 563, 613, 663, 663, 663, 663, 413, 463, 513, 563, 613, 413, 413, 313, 313, 313, 363, 213, 113, 163, 213, 263, 163, 163, 263, 263, 313, 363, 363, 413, 463, 463, 463, 563, 563, 563, 563, 563, 563, 563, 563, 563, 513, 463, 463, 463, 463, 463, 463, 363, 363, 363, 413, 313, 263, 263, 163, 163, 163, 163, 163, 163, 213, 263, 263, 263, 263, 163, 163, 213, 263, 313, 363, 363, 413}

            MyPac.Image = pacman(4)
            MyPac.Left = 200
            MyPac.Top = 100

            PbxGhost1.Image = Ghost1(0)
            PbxGhost1.Left = 50
            PbxGhost1.Top = 50

            pbxGhost2.Image = Ghost2(0)
            pbxGhost2.Left = 700
            pbxGhost2.Top = 150

            pbxGhost3.Image = Ghost3(0)
            pbxGhost3.Left = 650
            pbxGhost3.Top = 400

            pbxGhost4.Image = Ghost4(0)
            pbxGhost4.Left = 200
            pbxGhost4.Top = 550

            ' Use what's below on the level 2 form

        ElseIf shtLevel = 2 Then

            WallX = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 100, 150, 200, 250, 300, 350, 400, 450, 500, 550, 650, 700, 750, 800, 850, 900, 950, 1000, 1050, 1100, 1150, 550, 650, 1150, 1150, 1150, 1150, 1150, 1150, 1150, 1150, 1150, 700, 750, 850, 800, 900, 950, 1000, 1050, 1100, 1150, 1150, 1150, 1150, 1150, 50, 100, 150, 200, 250, 300, 350, 400, 450, 500, 100, 100, 150, 200, 100, 100, 150, 200, 200, 200, 250, 250, 350, 350, 350, 350, 300, 100, 150, 200, 300, 350, 200, 300, 100, 100, 150, 200, 250, 300, 350, 400, 400, 450, 450, 450, 450, 450, 450, 450, 450, 100, 150, 300, 200, 250, 350, 450, 400, 500, 500, 600, 600, 650, 700, 700, 750, 800, 800, 800, 700, 700, 750, 800, 800, 850, 600, 550, 650, 550, 550, 550, 550, 600, 650, 650, 700, 800, 850, 900, 900, 1000, 1000, 1000, 950, 950, 950, 900, 900, 900, 950, 950, 1050, 1050, 1050, 1100, 1100, 550, 500, 550, 500, 650, 650, 700, 750, 700, 750, 750, 850, 850, 850, 900, 950, 1050, 1050, 1050, 1050, 950, 1000, 1000}
            WallY = {0, 50, 100, 150, 200, 250, 300, 350, 750, 700, 650, 600, 550, 500, 450, 750, 750, 750, 750, 750, 750, 750, 750, 750, 750, 750, 750, 750, 750, 750, 750, 750, 750, 750, 750, 750, 750, 0, 0, 700, 650, 500, 550, 600, 450, 350, 300, 250, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 100, 150, 200, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 100, 150, 100, 100, 200, 300, 300, 300, 250, 200, 200, 100, 100, 150, 200, 300, 300, 400, 400, 400, 400, 400, 450, 450, 500, 550, 550, 550, 550, 550, 550, 550, 500, 500, 450, 400, 350, 300, 200, 150, 100, 650, 650, 650, 650, 650, 650, 650, 650, 650, 600, 600, 650, 650, 650, 550, 550, 550, 600, 650, 500, 400, 400, 400, 450, 450, 500, 500, 400, 450, 400, 350, 250, 250, 250, 300, 300, 300, 300, 300, 350, 350, 400, 450, 450, 500, 550, 550, 600, 650, 650, 600, 650, 600, 550, 450, 350, 100, 100, 150, 150, 100, 150, 150, 150, 100, 100, 200, 200, 150, 100, 100, 100, 100, 150, 200, 250, 200, 250, 200}
            DotX = {63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 163, 213, 263, 313, 363, 513, 563, 613, 663, 713, 563, 563, 563, 563, 163, 213, 263, 363, 313, 413, 463, 663, 713, 763, 813, 863, 913, 963, 1013, 1063, 1113, 1113, 1113, 1013, 1013, 1013, 1063, 1063, 1063, 1113, 1113, 1113, 1113, 1113, 813, 813, 813, 413, 413, 413, 313, 313, 313, 363, 413, 463, 313, 413, 413, 413, 413, 113, 163, 213, 263, 313, 363, 613, 663, 713, 763, 813, 863, 863, 913, 963, 963, 963, 963, 1013, 1063, 1113, 113, 163, 213, 263, 313, 363, 413, 463, 513, 613, 563, 663, 713, 763, 813, 863, 913, 1013, 1063, 1113, 963, 913, 963, 1013, 763, 813, 863, 613, 663, 713, 763, 863, 863, 863, 863, 113, 163, 213, 263, 313, 363, 413, 463, 513, 513, 513, 513, 513, 513, 613, 613, 513, 463, 363, 263, 263, 263, 263, 113, 163, 113, 561, 1111, 113, 163, 163, 163, 213, 263, 513, 613, 613, 613, 613, 613, 663, 663, 663, 713, 763, 763, 763, 813, 713, 763, 913, 913, 1013, 913, 913, 1013, 1063, 1113}
            DotY = {63, 113, 163, 213, 313, 263, 363, 413, 463, 513, 563, 613, 663, 713, 513, 513, 513, 513, 513, 213, 213, 213, 213, 213, 563, 613, 663, 713, 713, 713, 713, 713, 713, 713, 713, 713, 713, 713, 713, 713, 713, 713, 713, 713, 613, 663, 563, 563, 613, 663, 363, 413, 463, 413, 113, 163, 213, 263, 113, 163, 213, 113, 163, 213, 113, 163, 213, 263, 263, 263, 263, 313, 363, 413, 463, 363, 363, 363, 363, 363, 363, 363, 363, 363, 363, 363, 363, 413, 413, 413, 263, 313, 363, 313, 313, 313, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 163, 163, 163, 263, 263, 263, 463, 463, 463, 463, 513, 563, 613, 663, 613, 613, 613, 613, 613, 613, 613, 613, 313, 363, 463, 413, 513, 563, 563, 713, 713, 563, 463, 263, 313, 413, 463, 463, 463, 713, 311, 711, 263, 163, 213, 263, 163, 163, 263, 113, 163, 313, 413, 763, 513, 563, 613, 613, 613, 663, 513, 513, 263, 313, 213, 263, 113, 463, 513, 513, 513, 513}

            MyPac.Image = pacman(4)
            MyPac.Left = 100
            MyPac.Top = 50

            PbxGhost1.Image = Ghost1(0)
            PbxGhost1.Left = 50
            PbxGhost1.Top = 50

            'pbxGhost2.Image = Ghost2(0)
            'pbxGhost2.Left = 
            'pbxGhost2.Top = 

            'pbxGhost3.Image = Ghost3(0)
            'pbxGhost3.Left =
            'PbxGhost3.Top = 

            'pbxGhost4.Image = Ghost4(0)
            'PbxGhost4.Left =
            'PbxGhost4.Top = 

        ElseIf shtLevel = 3 Then
            ' level(3)
            WallX = {0, 50, 100, 150, 200, 250, 300, 350, 400, 450, 500, 550, 650, 700, 750, 800, 850, 900, 950, 1000, 1050, 1100, 1150, 1150, 1150, 1150, 1150, 1150, 1150, 1150, 1150, 1150, 1150, 1150, 1150, 1150, 1150, 650, 750, 700, 800, 850, 900, 950, 1000, 1050, 1100, 550, 0, 50, 100, 150, 200, 250, 300, 350, 400, 450, 500, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 100, 100, 100, 150, 200, 100, 100, 100, 250, 300, 350, 400, 450, 500, 550, 100, 100, 100, 100, 100, 150, 200, 250, 300, 350, 400, 450, 500, 550, 650, 700, 750, 800, 850, 900, 950, 1000, 1050, 1050, 1050, 1050, 1050, 1050, 650, 700, 750, 800, 850, 900, 950, 1000, 1050, 1050, 1050, 1050, 1050, 200, 200, 200, 200, 250, 300, 400, 450, 500, 600, 600, 600, 700, 750, 800, 900, 900, 950, 950, 950, 900, 850, 750, 750, 750, 650, 700, 850, 850, 600, 550, 300, 350, 400, 450, 500, 300, 300, 300, 200, 250, 200, 250, 300, 400, 450, 500, 400, 400, 500, 500, 600, 600, 650, 700, 750, 650, 700, 750, 850, 850, 850, 950, 950, 950}
            WallY = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 100, 150, 200, 250, 300, 350, 450, 500, 550, 600, 650, 700, 750, 750, 750, 750, 750, 750, 750, 750, 750, 750, 750, 750, 750, 750, 750, 750, 750, 750, 750, 750, 750, 750, 750, 450, 500, 550, 600, 650, 700, 350, 50, 100, 150, 200, 250, 300, 100, 150, 200, 100, 100, 250, 300, 350, 100, 100, 100, 100, 100, 100, 100, 450, 500, 550, 600, 650, 650, 650, 650, 650, 650, 650, 650, 650, 650, 650, 650, 650, 650, 650, 650, 650, 650, 650, 450, 500, 600, 550, 350, 100, 100, 100, 100, 100, 100, 100, 100, 100, 150, 200, 250, 300, 400, 350, 300, 200, 200, 200, 200, 200, 200, 200, 250, 300, 200, 200, 200, 200, 250, 200, 350, 250, 350, 350, 300, 350, 400, 400, 300, 200, 250, 400, 400, 300, 300, 300, 300, 300, 400, 450, 500, 500, 500, 550, 550, 550, 550, 550, 550, 450, 400, 400, 450, 500, 550, 500, 500, 500, 550, 550, 550, 450, 500, 550, 450, 500, 550}
            DotX = {63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 113, 163, 213, 263, 313, 363, 413, 463, 513, 563, 613, 663, 713, 763, 813, 863, 913, 963, 1013, 1063, 1113, 1113, 1113, 1113, 1113, 1113, 1113, 1113, 1113, 1113, 1113, 1113, 1113, 1113, 1063, 1013, 963, 913, 863, 813, 763, 713, 663, 613, 113, 163, 213, 263, 313, 363, 413, 463, 513, 563, 613, 613, 563, 563, 563, 563, 663, 663, 663, 663, 611, 611, 363, 513, 463, 413, 363, 263, 313, 213, 163, 163, 163, 163, 163, 163, 163, 163, 163, 163, 213, 263, 313, 363, 413, 463, 513, 563, 663, 713, 763, 813, 863, 913, 963, 1013, 713, 763, 813, 863, 913, 963, 1013, 1013, 1013, 1013, 1013, 1013, 1013, 1013, 1013, 863, 913, 913, 913, 913, 813, 813, 813, 713, 763, 813, 813, 813, 813, 663, 713, 713, 713, 563, 613, 663, 363, 463, 413, 513, 563, 263, 313, 363, 413, 463, 513, 563, 363, 363, 263, 213, 363, 313, 413, 463, 513, 863, 913, 963, 763, 463, 463, 363, 563, 213, 263, 263, 263, 963, 113, 1063, 613}
            DotY = {63, 113, 163, 213, 263, 313, 363, 413, 463, 513, 563, 613, 663, 713, 713, 713, 713, 713, 713, 713, 713, 713, 713, 713, 713, 713, 713, 713, 713, 713, 713, 713, 713, 713, 713, 613, 663, 563, 513, 463, 413, 363, 313, 263, 213, 163, 63, 113, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 113, 163, 163, 213, 263, 313, 163, 213, 263, 313, 361, 611, 213, 163, 163, 163, 163, 163, 163, 163, 163, 213, 263, 313, 363, 413, 463, 513, 563, 613, 613, 613, 613, 613, 613, 613, 613, 613, 613, 613, 613, 613, 613, 613, 613, 613, 163, 163, 163, 163, 163, 163, 213, 163, 263, 313, 363, 413, 463, 513, 563, 413, 413, 463, 513, 563, 563, 513, 463, 263, 263, 263, 313, 363, 413, 363, 363, 463, 413, 463, 463, 463, 513, 513, 513, 513, 513, 363, 363, 363, 363, 363, 363, 363, 413, 463, 263, 263, 263, 263, 263, 263, 263, 313, 313, 313, 463, 413, 463, 563, 563, 463, 463, 413, 313, 413, 413, 413, 663}


        ElseIf shtLevel = 4 Then
            ' level 4

        End If

        ' The following loop is run once for every wall piece you need
        ' Create a new wall piece with all the properties of a wall piece 
        ' Give it a location, color, size and so on
        ' Place it on the screen based on the coordinates above in WallX() and WallY()

        For index = 0 To WallX.Length() - 1
            Dim NewWallPiece As New PictureBox
            NewWallPiece.Width = 50
            NewWallPiece.Height = 50
            NewWallPiece.Left = WallX(index)
            NewWallPiece.Top = WallY(index)
            NewWallPiece.BackColor = Color.CadetBlue
            ReDim Preserve Wall(Wall.Length())
            Wall(index) = NewWallPiece
            Me.Controls.Add(Wall(index))
        Next

        For index = 0 To DotX.Length() - 1
            Dim NewDot As New PictureBox
            If index <> 9 And index <> 20 Then
                ' Regular Dots
                NewDot.BackColor = Color.White
                NewDot.Name = "Dot"
                NewDot.Width = 5
                NewDot.Height = 5
                NewDot.Top = DotY(index) + 12
                NewDot.Left = DotX(index) + 12
            ElseIf index = 9 Then
                ' Power Pellet
                NewDot.BackColor = Color.AliceBlue
                NewDot.Name = "PowerPellet"
                NewDot.Width = 20
                NewDot.Height = 20
                NewDot.Top = DotY(index) + 6
                NewDot.Left = DotX(index) + 6
            ElseIf index = 20 Then
                NewDot.BackColor = Color.Red
                NewDot.Name = "Fruit"
                NewDot.Width = 20
                NewDot.Height = 20
                NewDot.Top = DotY(index) + 12
                NewDot.Left = DotX(index) + 12
            End If

            ReDim Preserve Edible(Edible.Length())
            Edible(index) = NewDot
            Me.Controls.Add(Edible(index))

        Next

    End Sub

    Private Sub DisplayLives(ByRef Hearts As Short)
        If life = 4 Then
            Me.Heart1.Visible = True
            Me.Heart2.Visible = True
            Me.Heart3.Visible = True
            Me.Heart4.Visible = True
        ElseIf life = 3 Then

            Me.Heart1.Visible = True
            Me.Heart2.Visible = True
            Me.Heart3.Visible = True
            Me.Heart4.Visible = False
        ElseIf life = 2 Then
            Me.Heart1.Visible = True
            Me.Heart2.Visible = True
            Me.Heart3.Visible = False
            Me.Heart4.Visible = False
        ElseIf life = 1 Then
            Me.Heart1.Visible = True
            Me.Heart2.Visible = False
            Me.Heart3.Visible = False
            Me.Heart4.Visible = False
        ElseIf life = 0 Then
            Me.Heart1.Visible = False
            Me.Heart2.Visible = False
            Me.Heart3.Visible = False
            Me.Heart4.Visible = False
        End If
    End Sub

    Private Sub PacClock_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PacClock.Tick
        ' This function deals with all the Pacman move staff
        '    it does all of the following
        ' 1) Updates Counter so we can animate our Pacman from open mouth to close
        ' Mouth to make him "Munch". Odd is open and even is closed
        ' 2) Use HitWalls to see if next move will be a collision. If it is 
        '   set PacmanDirection to Stop. If it isnt make NextPacDirection and PacDirection the same.
        ' 3) Check to see what edibles Pacman has collided with and update score and 
        '   play sound files accordingly
        ' 4) Check to see if Pacman has moved through the sevret passage and move 
        '   him to the other side of the maze

        ' Check for collisio with walls then move or stop pacman accordingly
        Counter += 1

        ' Next position is a collision with walls
        If HitWalls(MyPac, NextPacDirection, PacSpeed) = True Then
            If NextPacDirection = PacDirection Or HitWalls(MyPac, PacDirection, PacSpeed) Then
                PacDirection = "Stop"
            End If
        Else
            PacDirection = NextPacDirection
        End If

        MovePac(PacDirection, Counter)

        'Check to see if pacman is going through the tunnels and teleport him to other side of map if so

        ' How to do for each indivisual level? 
        If MyPac.Left > 1200 Then        ' Customize
            MyPac.Left = 0
        ElseIf MyPac.Left < 0 Then
            MyPac.Left = 1200
        End If

        If MyPac.Top < 0 Then
            MyPac.Top = 750
        ElseIf MyPac.Top > 750 Then
            MyPac.Top = 0
        End If

        If HitGhost(MyPac, PbxGhost1) = "Dead" Then
            My.Computer.Audio.Play(My.Resources.pacman_death, AudioPlayMode.Background)
            PbxGhost1.Left = 50
            PbxGhost1.Top = 50

            If life = 4 Then
                Heart1.Visible = True
            ElseIf life = 3 Then
                Heart2.Visible = False
            ElseIf life = 2 Then
                Heart3.Visible = False
            ElseIf life = 1 Then
                Heart4.Visible = False
            ElseIf life = 0 Then
                Heart1.Visible = False
                Heart2.Visible = False
                Heart3.Visible = False
                Heart4.Visible = False
                MessageBox.Show("You're Dead")
                Ghost1MoveClock.Enabled = False
                Ghost2MoveClock.Enabled = False
                Ghost3MoveClock.Enabled = False
                Ghost4MoveClock.Enabled = False
                PacClock.Enabled = False
            End If
            life -= 1
        ElseIf (HitGhost(MyPac, PbxGhost1) = "Ghost Score") Then
        Score += 200
        My.Computer.Audio.Play(My.Resources.pacman_eatghost, AudioPlayMode.Background)
        Ghost1MoveClock.Enabled = False
        PbxGhost1.Left = -100
        PbxGhost1.Top = -100

        End If

        If HitGhost1(MyPac, pbxGhost2) = "Dead" Then
            My.Computer.Audio.Play(My.Resources.pacman_death, AudioPlayMode.Background)
            pbxGhost2.Left = 700
            pbxGhost2.Top = 150
            If life = 4 Then
                Heart1.Visible = True
            ElseIf life = 3 Then
                Heart2.Visible = False
            ElseIf life = 2 Then
                Heart3.Visible = False
            ElseIf life = 1 Then
                Heart4.Visible = False
            ElseIf life = 0 Then
                Heart1.Visible = False
                Heart2.Visible = False
                Heart3.Visible = False
                Heart4.Visible = False
                MessageBox.Show("You're Dead")
                Ghost1MoveClock.Enabled = False
                Ghost2MoveClock.Enabled = False
                Ghost3MoveClock.Enabled = False
                Ghost4MoveClock.Enabled = False
                PacClock.Enabled = False
            End If
            life -= 1
        ElseIf (HitGhost1(MyPac, pbxGhost2) = "Ghost Score") Then
            Score += 200
            My.Computer.Audio.Play(My.Resources.pacman_eatghost, AudioPlayMode.Background)
            Ghost2MoveClock.Enabled = False
            pbxGhost2.Left = -100
            pbxGhost2.Top = -100
        End If


        If HitGhost2(MyPac, pbxGhost3) = "Dead" Then
            My.Computer.Audio.Play(My.Resources.pacman_death, AudioPlayMode.Background)
            pbxGhost3.Left = 650
            pbxGhost3.Top = 400
            If life = 4 Then
                Heart1.Visible = True
            ElseIf life = 3 Then
                Heart2.Visible = False
            ElseIf life = 2 Then
                Heart3.Visible = False
            ElseIf life = 1 Then
                Heart4.Visible = False
            ElseIf life = 0 Then
                Heart1.Visible = False
                Heart2.Visible = False
                Heart3.Visible = False
                Heart4.Visible = False
                MessageBox.Show("You're Dead")
                Ghost1MoveClock.Enabled = False
                Ghost2MoveClock.Enabled = False
                Ghost3MoveClock.Enabled = False
                Ghost4MoveClock.Enabled = False
                PacClock.Enabled = False
                life -= 1
                Me.Close()
            End If

        ElseIf (HitGhost2(MyPac, pbxGhost3) = "Ghost Score") Then
            Score += 200
            My.Computer.Audio.Play(My.Resources.pacman_eatghost, AudioPlayMode.Background)
            Ghost3MoveClock.Enabled = False
            pbxGhost3.Left = -100
            pbxGhost3.Top = -100
        End If

        If HitGhost3(MyPac, pbxGhost4) = "Dead" Then
            My.Computer.Audio.Play(My.Resources.pacman_death, AudioPlayMode.Background)
            pbxGhost4.Left = 200
            pbxGhost4.Top = 550
            If life = 4 Then
                Heart1.Visible = True
            ElseIf life = 3 Then
                Heart2.Visible = False
            ElseIf life = 2 Then
                Heart3.Visible = False
            ElseIf life = 1 Then
                Heart4.Visible = False
            ElseIf life = 0 Then
                Heart1.Visible = False
                Heart2.Visible = False
                Heart3.Visible = False
                Heart4.Visible = False
                MessageBox.Show("You're Dead")
                Ghost1MoveClock.Enabled = False
                Ghost2MoveClock.Enabled = False
                Ghost3MoveClock.Enabled = False
                Ghost4MoveClock.Enabled = False
                PacClock.Enabled = False
                life -= 1
            End If

        ElseIf (HitGhost3(MyPac, pbxGhost4) = "Ghost Score") Then
            Score += 200
            My.Computer.Audio.Play(My.Resources.pacman_eatghost, AudioPlayMode.Background)
            Ghost4MoveClock.Enabled = False
            pbxGhost4.Left = -100
            pbxGhost4.Top = -100
        End If

        ' See what edibles Pacman has collided with and play correct sounds and update score
        Dim Eatable As String = Eats(MyPac)

        If Eatable = "Dot" Then
            Score += 10
            My.Computer.Audio.Play(My.Resources.pacman_chomp, AudioPlayMode.Background)
        ElseIf Eatable = "PowerPellet" Then
            Me.PowerPelletClock.Enabled = True
            Score += 100
            My.Computer.Audio.Play(My.Resources.pacman_eatfruit, AudioPlayMode.Background)
        ElseIf Eatable = "Fruit" Then
            Score += 100
            life += 1
            If Heart1.Visible = False Then
                If Heart2.Visible = False Then
                    If Heart3.Visible = False Then
                        If Heart4.Visible = False Then
                            Heart4.Visible = True
                        End If
                        Heart3.Visible = True
                    End If
                    Heart2.Visible = True
                End If
                Heart1.Visible = True
            End If
            My.Computer.Audio.Play(My.Resources.pacman_eatfruit, AudioPlayMode.Background)
        ElseIf Eatable = "Complete" Then
            Me.PacClock.Enabled = False
            Me.Ghost1MoveClock.Enabled = False
            ' Load up next game board
            MessageBox.Show("Level Complete")
            btnNext.Visible = True
            btnShow.Visible = True
        End If

        Me.lblScores.Text = "Score: " + Score.ToString

    End Sub

    Private Function HitGhost(ByVal Pacman As PictureBox, ByVal Ghost1 As PictureBox)
        ' Create a loop for each ghost
        ' This one only hits one ghost
        ' Function that checks which ghost has been hit

        Dim DistanceApart As Short = Math.Sqrt((MyPac.Left - PbxGhost1.Left) ^ 2 _
                                     + (MyPac.Top - PbxGhost1.Top) ^ 2)
        If DistanceApart <= 45 And Me.PowerPelletClock.Enabled = False Then
            Return "Dead"
        ElseIf DistanceApart <= 45 And Me.PowerPelletClock.Enabled = True Then
            Return "Ghost Score"
        Else
            Return ""
        End If



        'DistanceApart = Math.Sqrt((MyPac.Left - pbxGhost2.Left) ^ 2 _
        '                             + (MyPac.Top - pbxGhost2.Top) ^ 2)
        'If DistanceApart <= 45 And Me.PowerPelletClock.Enabled = False Then
        '    Return "Dead"
        'ElseIf DistanceApart <= 45 And Me.PowerPelletClock.Enabled = True Then
        '    Return "Ghost Score"
        'Else
        '    Return ""
        'End If

    End Function

    Private Function HitGhost1(ByVal Pacman As PictureBox, ByVal Ghost2 As PictureBox)

        Dim DistanceApart As Short = Math.Sqrt((MyPac.Left - pbxGhost2.Left) ^ 2 _
                                     + (MyPac.Top - pbxGhost2.Top) ^ 2)
        If DistanceApart <= 45 And Me.PowerPelletClock.Enabled = False Then
            Return "Dead"
        ElseIf DistanceApart <= 45 And Me.PowerPelletClock.Enabled = True Then
            Return "Ghost Score"
        Else
            Return ""
        End If
    End Function

    Private Function HitGhost2(ByVal Pacman As PictureBox, ByVal Ghost3 As PictureBox)

        Dim DistanceApart As Short = Math.Sqrt((MyPac.Left - pbxGhost3.Left) ^ 2 _
                                     + (MyPac.Top - pbxGhost3.Top) ^ 2)
        If DistanceApart <= 45 And Me.PowerPelletClock.Enabled = False Then
            Return "Dead"
        ElseIf DistanceApart <= 45 And Me.PowerPelletClock.Enabled = True Then
            Return "Ghost Score"
        Else
            Return ""
        End If
    End Function

    Private Function HitGhost3(ByVal Pacman As PictureBox, ByVal Ghost4 As PictureBox)

        Dim DistanceApart As Short = Math.Sqrt((MyPac.Left - pbxGhost4.Left) ^ 2 _
                                     + (MyPac.Top - pbxGhost4.Top) ^ 2)
        If DistanceApart <= 45 And Me.PowerPelletClock.Enabled = False Then
            Return "Dead"
        ElseIf DistanceApart <= 45 And Me.PowerPelletClock.Enabled = True Then
            Return "Ghost Score"
        Else
            Return ""
        End If

    End Function

    Private Function Eats(ByVal PacMan As PictureBox)
        ' loop through all the dots to see if pacman has hit it
        ' the pacman picturebox
        ' touches the bounds of the dot or other object return its name
        ' So if this function returns a "Dot" pac has hit a dot. If it returns
        ' a "Pellet" pacman has hit a pellet
        ' and if it returns a "Fruit" Pacman has eaten a special. If it returns
        ' nothing then no collision has occured
        ' We also move the dots off screen to make it look like they disappeared
        ' We also count up the eaten items to see if maze is complete
        For index = 0 To Edible.Length - 1
            If MazeCompletion = Edible.Length Then
                Return "Complete"
            ElseIf PacMan.Bounds.IntersectsWith(Edible(index).Bounds) Then
                MazeCompletion += 1
                Edible(index).Left = -1000
                Return Edible(index).Name
            End If
        Next
        Return ""
    End Function

    Private Sub MovePac(ByVal PacDirection As String, ByVal Counter As Long)
        ' This simply moves our pacman in the direction stored in 
        ' PacDirection and animates the comping motion based on the # stored in the counter
        ' if counter is an even# it will load the open mouth image for the correct direction
        ' if counter is odd it will load the closed mouth pacman

        If PacDirection = "R" Then
            Me.MyPac.Left += PacSpeed
            If Counter Mod 2 = 0 Then
                MyPac.Image = pacman(4)
            Else
                MyPac.Image = pacman(0)
            End If
        ElseIf PacDirection = "L" Then
            Me.MyPac.Left -= PacSpeed
            If Counter Mod 2 = 0 Then
                MyPac.Image = pacman(3)
            Else
                MyPac.Image = pacman(0)
            End If
        ElseIf PacDirection = "D" Then
            Me.MyPac.Top += PacSpeed
            If Counter Mod 2 = 0 Then
                MyPac.Image = pacman(2)
            Else
                MyPac.Image = pacman(0)
            End If
        ElseIf PacDirection = "U" Then
            Me.MyPac.Top -= PacSpeed
            If Counter Mod 2 = 0 Then
                MyPac.Image = pacman(1)
            Else
                MyPac.Image = pacman(0)
            End If

        End If

    End Sub

    Private Function HitWalls(ByVal Sprite As PictureBox, ByVal NextDirection As String, ByVal Speed As Short)
        ' We use this function to check to see if our Pacman or Ghost's current direction
        ' will make him crash into a wall on the next move
        ' We do this by creating a copy of the sprite (either Pacman or Ghost) and copying
        ' over its .left, .top, .height, and width properties
        ' to our SpriteCopy. Then we update the Sprite copy with next direction values
        ' if the new position of the spritecopy is detected as a collision we return TRUE otheriwse
        ' So in easy speak, ifthe next move of he sprite will be a collision this function will say
        ' so in the calling function we can move the sprite if Hitwalls - FALSE and not move

        ' Create replica of this sprite
        Dim SpriteCopy = New PictureBox()
        Dim XVal, YVal, Width, Height As Short
        XVal = Sprite.Left
        YVal = Sprite.Top
        Width = Sprite.Width
        Height = Sprite.Height
        SpriteCopy.Left = XVal
        SpriteCopy.Top = YVal
        SpriteCopy.Width = Width
        SpriteCopy.Height = Height

        If NextDirection = "R" Then
            SpriteCopy.Left += Speed
        ElseIf NextDirection = "L" Then
            SpriteCopy.Left -= Speed
        ElseIf NextDirection = "U" Then
            SpriteCopy.Top -= Speed
        ElseIf NextDirection = "D" Then
            SpriteCopy.Top += Speed
        End If

        'Me.label1.text = WallX.Length() - 1
        ' Check for collision based on the location of this temporary sprite and return either TRUE
        For index = 0 To Wall.Length() - 1
            If SpriteCopy.Bounds.IntersectsWith(Wall(index).Bounds) Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub Ghost1MoveClock_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ghost1MoveClock.Tick
        Ghost1ChooseDirection()

        If Ghost1Direction = "L" Then
            PbxGhost1.Left -= Ghost1Speed
        ElseIf Ghost1Direction = "R" Then
            PbxGhost1.Left += Ghost1Speed
        ElseIf Ghost1Direction = "U" Then
            PbxGhost1.Top -= Ghost1Speed
        ElseIf Ghost1Direction = "D" Then
            PbxGhost1.Top += Ghost1Speed
        End If

        'If PbxGhost1.Left > 390 Then
        '    PbxGhost1.Left = -40
        'ElseIf PbxGhost1.Left < -40 Then
        '    PbxGhost1.Left = 390
        'End If

        If PbxGhost1.Left > 1200 Then        ' Customize
            PbxGhost1.Left = 0
        ElseIf PbxGhost1.Left < 0 Then
            PbxGhost1.Left = 1200
        End If

        If PbxGhost1.Top < 0 Then
            PbxGhost1.Top = 750
        ElseIf PbxGhost1.Top > 750 Then
            PbxGhost1.Top = 0
        End If

    End Sub

    Private Sub Ghost1ChooseDirection()
        Dim DirectionAvailable As String = ""
        Dim AbovePac As Boolean = Nothing
        Dim LeftOfPac As Boolean = Nothing

        If HitWalls(PbxGhost1, "U", Ghost1Speed) = False And Ghost1Direction <> "D" Then
            DirectionAvailable += "U"
        End If
        If HitWalls(PbxGhost1, "D", Ghost1Speed) = False And Ghost1Direction <> "U" Then
            DirectionAvailable += "D"
        End If
        If HitWalls(PbxGhost1, "L", Ghost1Speed) = False And Ghost1Direction <> "R" Then
            DirectionAvailable += "L"
        End If
        If HitWalls(PbxGhost1, "R", Ghost1Speed) = False And Ghost1Direction <> "L" Then
            DirectionAvailable += "R"
        End If

        Randomize()
        ' Me.lblScores.Text = HitWalls(PbxGhost1, "R", GhostSpeed).ToString
        Ghost1Direction = DirectionAvailable.Substring(Int(Rnd() * DirectionAvailable.Length), 1)

        If Me.Left > Me.MyPac.Left Then
            LeftOfPac = False
        Else
            LeftOfPac = True
        End If
        If Me.PbxGhost1.Top > Me.MyPac.Top Then
            AbovePac = False
        Else
            AbovePac = True
        End If
        ' Create different methods for each ghost

    End Sub

    Private Sub Ghost2ChooseDirection()
        Dim DirectionAvailable As String = ""
        Dim AbovePac As Boolean = Nothing
        Dim LeftOfPac As Boolean = Nothing

        If HitWalls(pbxGhost2, "U", Ghost2Speed) = False And Ghost2Direction <> "D" Then
            DirectionAvailable += "U"
        End If
        If HitWalls(pbxGhost2, "D", Ghost2Speed) = False And Ghost2Direction <> "U" Then
            DirectionAvailable += "D"
        End If
        If HitWalls(pbxGhost2, "L", Ghost2Speed) = False And Ghost2Direction <> "R" Then
            DirectionAvailable += "L"
        End If
        If HitWalls(pbxGhost2, "R", Ghost2Speed) = False And Ghost2Direction <> "L" Then
            DirectionAvailable += "R"
        End If

        Randomize()
        ' Me.lblScores.Text = HitWalls(PbxGhost1, "R", GhostSpeed).ToString
        Ghost2Direction = DirectionAvailable.Substring(Int(Rnd() * DirectionAvailable.Length), 1)

        If Me.Left > Me.MyPac.Left Then
            LeftOfPac = False
        Else
            LeftOfPac = True
        End If
        If Me.pbxGhost2.Top > Me.MyPac.Top Then
            AbovePac = False
        Else
            AbovePac = True
        End If
    End Sub

    Private Sub Ghost4ChooseDirection()
        Dim DirectionAvailable As String = ""
        Dim AbovePac As Boolean = Nothing
        Dim LeftOfPac As Boolean = Nothing

        If HitWalls(pbxGhost4, "U", Ghost3Speed) = False And Ghost4Direction <> "D" Then
            DirectionAvailable += "U"
        End If
        If HitWalls(pbxGhost4, "D", Ghost3Speed) = False And Ghost4Direction <> "U" Then
            DirectionAvailable += "D"
        End If
        If HitWalls(pbxGhost4, "L", Ghost3Speed) = False And Ghost4Direction <> "R" Then
            DirectionAvailable += "L"
        End If
        If HitWalls(pbxGhost4, "R", Ghost3Speed) = False And Ghost4Direction <> "L" Then
            DirectionAvailable += "R"
        End If

        Randomize()
        ' Me.lblScores.Text = HitWalls(PbxGhost1, "R", GhostSpeed).ToString
        Ghost4Direction = DirectionAvailable.Substring(Int(Rnd() * DirectionAvailable.Length), 1)

        If Me.Left > Me.MyPac.Left Then
            LeftOfPac = False
        Else
            LeftOfPac = True
        End If
        If Me.pbxGhost4.Top > Me.MyPac.Top Then
            AbovePac = False
        Else
            AbovePac = True
        End If
    End Sub

    Private Sub PowerPelletClock_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PowerPelletClock.Tick

        ' Tweak for 4 ghost, same power clock
        PowerUpClock += 1
        If PowerUpClock Mod 2 = 1 Then
            Me.PbxGhost1.Image = Ghost1(1)
            Me.pbxGhost2.Image = Ghost2(1)
            Me.pbxGhost3.Image = Ghost3(1)
            Me.pbxGhost4.Image = Ghost4(1)
            ' Put all 4 images here
        Else
            Me.PbxGhost1.Image = Ghost1(0)
            Me.pbxGhost2.Image = Ghost2(0)
            Me.pbxGhost3.Image = Ghost3(0)
            Me.pbxGhost4.Image = Ghost4(0)
        End If
        If PowerUpClock = 50 Then
            Me.PowerPelletClock.Enabled = False
            PowerUpClock = 0
        End If

    End Sub

    Private Sub Ghost3ChooseDirection()
        Dim DirectionAvailable As String = ""
        Dim AbovePac As Boolean = Nothing
        Dim LeftOfPac As Boolean = Nothing

        If HitWalls(pbxGhost3, "U", Ghost3Speed) = False And Ghost3Direction <> "D" Then
            DirectionAvailable += "U"
        End If
        If HitWalls(pbxGhost3, "D", Ghost3Speed) = False And Ghost3Direction <> "U" Then
            DirectionAvailable += "D"
        End If
        If HitWalls(pbxGhost3, "L", Ghost3Speed) = False And Ghost3Direction <> "R" Then
            DirectionAvailable += "L"
        End If
        If HitWalls(pbxGhost3, "R", Ghost3Speed) = False And Ghost3Direction <> "L" Then
            DirectionAvailable += "R"
        End If

        Randomize()
        ' Me.lblScores.Text = HitWalls(PbxGhost1, "R", GhostSpeed).ToString
        Ghost3Direction = DirectionAvailable.Substring(Int(Rnd() * DirectionAvailable.Length), 1)

        If Me.Left > Me.MyPac.Left Then
            LeftOfPac = False
        Else
            LeftOfPac = True
        End If
        If Me.pbxGhost3.Top > Me.MyPac.Top Then
            AbovePac = False
        Else
            AbovePac = True
        End If
    End Sub

    Private Sub Ghost3MoveClock_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ghost3MoveClock.Tick

        Ghost3ChooseDirection()

        If Ghost3Direction = "L" Then
            pbxGhost3.Left -= Ghost3Speed
        ElseIf Ghost3Direction = "R" Then
            pbxGhost3.Left += Ghost3Speed
        ElseIf Ghost3Direction = "U" Then
            pbxGhost3.Top -= Ghost3Speed
        ElseIf Ghost3Direction = "D" Then
            pbxGhost3.Top += Ghost3Speed
        End If

        If pbxGhost3.Left > 1200 Then        ' Customize
            pbxGhost3.Left = 0
        ElseIf pbxGhost3.Left < 0 Then
            pbxGhost3.Left = 1200
        End If

        If pbxGhost3.Top < 0 Then
            pbxGhost3.Top = 750
        ElseIf pbxGhost3.Top > 750 Then
            pbxGhost3.Top = 0
        End If
    End Sub

    Private Sub Ghost2MoveClock_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ghost2MoveClock.Tick

        Ghost2ChooseDirection()

        If Ghost2Direction = "L" Then
            pbxGhost2.Left -= Ghost2Speed
        ElseIf Ghost2Direction = "R" Then
            pbxGhost2.Left += Ghost2Speed
        ElseIf Ghost2Direction = "U" Then
            pbxGhost2.Top -= Ghost2Speed
        ElseIf Ghost2Direction = "D" Then
            pbxGhost2.Top += Ghost2Speed
        End If

        If pbxGhost2.Left > 1200 Then        ' Customize
            pbxGhost2.Left = 0
        ElseIf pbxGhost2.Left < 0 Then
            pbxGhost2.Left = 1200
        End If

        If pbxGhost2.Top < 0 Then
            pbxGhost2.Top = 750
        ElseIf pbxGhost2.Top > 750 Then
            pbxGhost2.Top = 0
        End If
    End Sub

    Private Sub Ghost4MoveClock_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ghost4MoveClock.Tick

        Ghost4ChooseDirection()

        If Ghost4Direction = "L" Then
            pbxGhost4.Left -= Ghost3Speed
        ElseIf Ghost4Direction = "R" Then
            pbxGhost4.Left += Ghost3Speed
        ElseIf Ghost4Direction = "U" Then
            pbxGhost4.Top -= Ghost3Speed
        ElseIf Ghost4Direction = "D" Then
            pbxGhost4.Top += Ghost3Speed
        End If

        If pbxGhost3.Left > 1200 Then        ' Customize
            pbxGhost3.Left = 0
        ElseIf pbxGhost3.Left < 0 Then
            pbxGhost3.Left = 1200
        End If

        If pbxGhost3.Top < 0 Then
            pbxGhost3.Top = 750
        ElseIf pbxGhost3.Top > 750 Then
            pbxGhost3.Top = 0
        End If
    End Sub

    Private Sub StartClock_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartClock.Tick

        Counter += 1
        If Counter = 1 Then
            My.Computer.Audio.Play(My.Resources.pacman_beginning, AudioPlayMode.Background)
        End If
        If Counter < 30 Then
            If Counter Mod 7 = 1 Then
                Me.lblStart.Text = ""
            Else
                Me.lblStart.Text = "Ready"
            End If
        ElseIf Counter = 35 Then
            Me.lblStart.Text = "Start"
        ElseIf Counter = 40 Then
            Me.lblStart.Visible = False
            Me.PacClock.Enabled = True
            Me.Ghost1MoveClock.Enabled = True
            Me.Ghost2MoveClock.Enabled = True
            Me.Ghost3MoveClock.Enabled = True
            Me.Ghost4MoveClock.Enabled = True
            Me.StartClock.Enabled = False
            Counter = 0
        End If
    End Sub

    Private Sub btnNext_Click(sender As System.Object, e As System.EventArgs) Handles btnNext.Click
        Dim LevelNum2 = Level2
        Me.Hide()
        LevelNum2.Show()
        Level2.lblScores.Text = Score.ToString
        Me.StartClock.Enabled = False
        Me.Ghost1MoveClock.Enabled = False
        Me.Ghost2MoveClock.Enabled = False
        Me.Ghost3MoveClock.Enabled = False
        Me.Ghost4MoveClock.Enabled = False
        Me.PacClock.Enabled = False
    End Sub

    Private Sub btnShow_Click(sender As System.Object, e As System.EventArgs) Handles btnShow.Click
        MessageBox.Show("Your Current Score is " + Score.ToString)
    End Sub
End Class
