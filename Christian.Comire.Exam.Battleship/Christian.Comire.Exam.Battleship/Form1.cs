using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Christian.Comire.Exam.Battleship
{
    public partial class Form : System.Windows.Forms.Form
    {
        #region Lists


        //Enemy ship List
        List<string> enemyShipNames = null;


        //All of the different Vertical lists
        List<Button> friendlyTilesVertical1 = null;
        List<Button> friendlyTilesVertical2 = null;
        List<Button> friendlyTilesVertical3 = null;
        List<Button> friendlyTilesVertical4 = null;
        List<Button> friendlyTilesVertical5 = null;
        List<Button> friendlyTilesVertical6 = null;
        List<Button> friendlyTilesVertical7 = null;
        List<Button> friendlyTilesVertical8 = null;
        List<Button> friendlyTilesVertical9 = null;
        List<Button> friendlyTilesVertical10 = null;

        //All of the different Horizontal Lists
        List<Button> friendlyTilesHorizontal1 = null;
        List<Button> friendlyTilesHorizontal2 = null;
        List<Button> friendlyTilesHorizontal3 = null;
        List<Button> friendlyTilesHorizontal4 = null;
        List<Button> friendlyTilesHorizontal5 = null;
        List<Button> friendlyTilesHorizontal6 = null;
        List<Button> friendlyTilesHorizontal7 = null;

        //All of the enemy Horizontal lists
        List<Button> enemyTilesHorizontal1 = null;
        List<Button> enemyTilesHorizontal2 = null;
        List<Button> enemyTilesHorizontal3 = null;
        List<Button> enemyTilesHorizontal4 = null;
        List<Button> enemyTilesHorizontal5 = null;
        List<Button> enemyTilesHorizontal6 = null;
        List<Button> enemyTilesHorizontal7 = null;

        //All of the enemy Vertical Lists
        List<Button> enemyTilesVertical1 = null;
        List<Button> enemyTilesVertical2 = null;
        List<Button> enemyTilesVertical3 = null;
        List<Button> enemyTilesVertical4 = null;
        List<Button> enemyTilesVertical5 = null;
        List<Button> enemyTilesVertical6 = null;
        List<Button> enemyTilesVertical7 = null;
        List<Button> enemyTilesVertical8 = null;
        List<Button> enemyTilesVertical9 = null;
        List<Button> enemyTilesVertical10 = null;

        //Lists of all the enemy lists
        List<List<Button>> enemyAllHorizontalTiles = null;
        List<List<Button>> enemyAllVerticalTiles = null;

        //Lists of all the different lists
        List<List<Button>> friendlyAllHorizontalTiles = null;
        List<List<Button>> friendlyAllVerticalTiles = null;

        //Lists of the lists that are holding lists of buttons
        List<List<List<Button>>> TheBigList = null;
        List<List<List<Button>>> enemyBigList = null;

        List<string> afterEnemyHit = null;
        #endregion


        #region variables

        //Used to check if the enemy grid gets enabled or not
        int enemyGridCounter = 0;

        int enemyHit = 0;
        int hitDistance = 1;
        #region failedAi
        int enemyVerticalShootingMemory = 0;
        int enemyHorizontalShootingMemory = 0;

        int hitDirectioncounter = 0;
        int hitDirectionMultiplecounter = 1;

        int notUp = 0;
        int notDown = 0;
        int notLeft = 0;
        int notRight = 0;

        #endregion

        int RandomVertical = 0;
        int Randomhorizontal = 0;

        //Used to check if the enemy ship is sank or not
        int Ship1Counter = 0;
        int Ship2Counter = 0;
        int Ship3Counter = 0;
        int Ship4Counter = 0;
        int Ship5Counter = 0;



        //Used to check if the friendly ship is sank or not
        int enemyShip1Counter = 0;
        int enemyShip2Counter = 0;
        int enemyShip3Counter = 0;
        int enemyShip4Counter = 0;
        int enemyShip5Counter = 0;

        string friendlyShipTag = "";
        string shipInput = "";
        string friendlyShipTagCheckIfHit = "";

        bool direction = false;
        int shipAmount = 0;
        //Utiliser pour spawn un bateau
        int horizontal = 0;
        int horizontalSlot = 0;
        int vertical = 0;
        int verticalSlot = 0;

        //Utiliser pour bouger le bateau
        int RightLeft = 0;
        int UpDown = 0;

        //Variable pour les bateau
        int frigate = 0;
        int CV = 0;
        int Battleship = 0;
        int Submarine = 0;
        int Destroyer = 0;

        //Checks to see if you sank all the enemy ships
        int Friendlywinner = 0;
        int winner = 0;
        #endregion


        #region form load
        /// <summary>
        /// Form
        /// </summary>
        public Form()
        {
            InitializeComponent();

            //Declares all of the lists right at the start
            DeclaringLists();

            //Allows all the ships and the horizontal/vertical buttons to be enabled
            //And all the arrow keys and confirm button is disabled
            EnableDisableStartingButtons();

            EnnemyShipPlacement();
        }

        /// <summary>
        /// Form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #endregion


        #region Buttons

        /// <summary>
        /// Placing selected ship onto the friendly board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FriendlyShipsClick(object sender, EventArgs e)
        {
            shipInput = (sender as Button).Text;
            friendlyShipTag = (sender as Button).Text;

            //Checks which ship you have selected(ex:Battleship or frigate)
            switch (shipInput)
            {
                //if Aircraft Carrier is selected
                case "Aircraft Carrier":
                    //Gives a length value for the ship
                    shipAmount = 5;

                    //Checks for if the button has been used already or not
                    CV++;

                    //Adds the ship to the grid
                    AddingGrayShip();

                    if (direction)
                    { UpDown = shipAmount - 1; }
                    else
                    {
                        RightLeft = shipAmount - 1;

                    }
                    //Enables and disables certain buttons
                    EnableAndDisableButtons();

                    //Resets the input name
                    shipInput = "";
                    break;

                //if Battleship is selected
                case "Battleship":
                    //Gives a length value for the ship
                    shipAmount = 4;

                    //Checks for if the button has been used already or not
                    Battleship++;

                    //Adds the ship to the grid
                    AddingGrayShip();

                    if (direction)
                    { UpDown = shipAmount - 1; }
                    else
                    {
                        RightLeft = shipAmount - 1;
                    }
                    //Enables and disables certain buttons
                    EnableAndDisableButtons();

                    //Resets the input name
                    shipInput = "";
                    break;

                //if Destroyer is selected
                case "Destroyer":
                    //Gives a length value for the ship
                    shipAmount = 3;

                    //Checks for if the button has been used already or not
                    Destroyer++;

                    //Adds the ship to the grid
                    AddingGrayShip();

                    if (direction)
                    {
                        UpDown = shipAmount - 1;
                    }
                    else
                    {
                        RightLeft = shipAmount - 1;
                    }
                    //Enables and disables certain buttons
                    EnableAndDisableButtons();

                    //Resets the input name
                    shipInput = "";
                    break;

                //if Submarine is selected
                case "Submarine":
                    //Gives a length value for the ship
                    shipAmount = 3;

                    //Checks for if the button has been used already or not
                    Submarine++;

                    //Adds the ship to the grid
                    AddingGrayShip();

                    if (direction)
                    { UpDown = shipAmount - 1; }
                    else
                    {
                        RightLeft = shipAmount - 1;
                    }
                    //Enables and disables certain buttons
                    EnableAndDisableButtons();

                    //Resets the input name
                    shipInput = "";
                    break;

                //if Frigate is selected
                case "Frigate":
                    //Gives a length value for the ship
                    shipAmount = 2;

                    //Checks for if the button has been used already or not
                    frigate++;

                    //Adds the ship to the grid
                    AddingGrayShip();

                    if (direction)
                    { UpDown = shipAmount - 1; }
                    else
                    {
                        RightLeft = shipAmount - 1;
                    }
                    //Enables and disables certain buttons
                    EnableAndDisableButtons();

                    //Resets the input name
                    shipInput = "";
                    break;


                default:
                    //If no ship has been selected
                    MessageBox.Show("No Ship Selected");
                    break;
            }

        }

        /// <summary>
        /// Changes the direction in which the ship is facing either horizontal or vertical
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShipDirectionClick(object sender, EventArgs e)
        {
            if ("Vertical" == (sender as Button).Text)
            {
                direction = true;
            }
            else
            {
                direction = false;
            }
        }

        /// <summary>
        /// The confirmation button to say that you want a ship where it is currently located
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            enemyGridCounter++;

            //Enables the vertical and horizontal click
            btnVertical.Enabled = true;
            btnHorizontal.Enabled = true;

            //disables direction buttons
            btnUp.Enabled = false;
            btnDown.Enabled = false;
            btnLeft.Enabled = false;
            btnRight.Enabled = false;

            //Disables the confirmation button
            btnConfirm.Enabled = false;

            //Resets the spawn location of the ship
            horizontal = 0;
            horizontalSlot = 0;
            vertical = 0;
            verticalSlot = 0;

            UpDown = 0;
            RightLeft = 0;

            //Re enables all of the ships that have not been placed yet
            if (CV == 0)
            { btnCV.Enabled = true; }
            if (Battleship == 0)
            { btnBattleship.Enabled = true; }
            if (Submarine == 0)
            { btnSubmarine.Enabled = true; }
            if (Destroyer == 0)
            { btnDestroyer.Enabled = true; }
            if (frigate == 0)
            { btnFrigate.Enabled = true; }

            switch (friendlyShipTag)
            {
                case "Aircraft Carrier":
                    for (int i = 0; i < 10; i++)
                    {
                        for (int o = 0; o < 7; o++)
                        {
                            if (TheBigList[1][i][o].BackColor == Color.Gray && TheBigList[1][i][o].Tag == null)
                            {
                                //Gives a tag the ship
                                TheBigList[1][i][o].Tag = "Ship1";
                                TheBigList[0][o][i].Tag = "Ship1";
                                //TheBigList[1][i][o].Text = "Ship1";
                                //TheBigList[0][o][i].Text = "Ship1";
                            }
                        }
                    }
                    break;
                case "Battleship":
                    for (int i = 0; i < 10; i++)
                    {
                        for (int o = 0; o < 7; o++)
                        {
                            if (TheBigList[1][i][o].BackColor == Color.Gray && TheBigList[1][i][o].Tag == null)
                            {
                                //Gives a tag the ship
                                TheBigList[1][i][o].Tag = "Ship2";
                                TheBigList[0][o][i].Tag = "Ship2";
                                //TheBigList[1][i][o].Text = "Ship2";
                                //TheBigList[0][o][i].Text = "Ship2";
                            }
                        }
                    }
                    break;
                case "Submarine":
                    for (int i = 0; i < 10; i++)
                    {
                        for (int o = 0; o < 7; o++)
                        {
                            if (TheBigList[1][i][o].BackColor == Color.Gray && TheBigList[1][i][o].Tag == null)
                            {
                                //Gives a tag the ship
                                TheBigList[1][i][o].Tag = "Ship3";
                                TheBigList[0][o][i].Tag = "Ship3";
                               //TheBigList[1][i][o].Text = "Ship3";
                                //TheBigList[0][o][i].Text = "Ship3";
                            }
                        }
                    }
                    break;
                case "Destroyer":
                    for (int i = 0; i < 10; i++)
                    {
                        for (int o = 0; o < 7; o++)
                        {
                            if (TheBigList[1][i][o].BackColor == Color.Gray && TheBigList[1][i][o].Tag == null)
                            {
                                //Gives a tag the ship
                                TheBigList[1][i][o].Tag = "Ship4";
                                TheBigList[0][o][i].Tag = "Ship4";
                                //TheBigList[1][i][o].Text = "Ship4";
                                //TheBigList[0][o][i].Text = "Ship4";
                            }
                        }
                    }
                    break;
                case "Frigate":
                    for (int i = 0; i < 10; i++)
                    {
                        for (int o = 0; o < 7; o++)
                        {
                            if (TheBigList[1][i][o].BackColor == Color.Gray && TheBigList[1][i][o].Tag == null)
                            {
                                //Gives a tag the ship
                                TheBigList[1][i][o].Tag = "Ship5";
                                TheBigList[0][o][i].Tag = "Ship5";
                                //TheBigList[1][i][o].Text = "Ship5";
                                //TheBigList[0][o][i].Text = "Ship5";
                            }
                        }
                    }
                    break;
            }
            if (enemyGridCounter == 5)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int o = 0; o < 7; o++)
                    {
                        //Enables the enemy grid
                        enemyBigList[0][o][i].Enabled = true;
                    }
                }
            }
            /*
            for (int i = 0; i < 10; i++)
            {
                for (int o = 0; o < 7; o++)
                {
                    if (TheBigList[1][i][o].BackColor == Color.Gray && TheBigList[1][i][o].Tag == null)
                    {
                        if (Submarine == 1)
                        {
                            Submarine++;
                            TheBigList[1][i][o].Tag = "Ship" + 3;
                            TheBigList[0][o][i].Tag = "Ship" + 3;
                        }
                        else if (Destroyer == 1)
                        {
                            Destroyer++;
                            TheBigList[0][o][i].Tag = "Ship" + 1;
                            TheBigList[0][o][i].Tag = "Ship" + 1;
                        }
                        //Gives a tag to each ship placed
                        TheBigList[1][i][o].Tag = "Ship" + shipAmount;
                        TheBigList[0][o][i].Tag = "Ship" + shipAmount;
                        TheBigList[1][i][o].Text = "Ship" + shipAmount;
                        TheBigList[0][o][i].Text = "Ship" + shipAmount;
                    }

                    //Checks if all the boats have been placed before enabling the enemy grid
                    if (enemyGridCounter == 5)
                    {
                        //Enables the enemy grid
                        enemyBigList[0][o][i].Enabled = true;
                    }
                }
            }*/


        }

        /// <summary>
        /// Shooting the enemy tiles 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void friendlyShooting(object sender, EventArgs e)
        {

            try
            {
                string ButtonTag = (sender as Button).Tag.ToString();
                Button Button = (sender as Button);
                if (ButtonTag != null)
                {
                    switch (ButtonTag)
                    {
                        case "Ship1":
                            Ship1Counter++;
                            Button.BackColor = Color.Red;
                            if (Ship1Counter == 5)
                            {
                                Friendlywinner++;
                                MessageBox.Show("You sank my Aircraft Carrier");

                                //Changes the Red tiles to a different color to show you what ship was sunk
                                for (int i = 0; i < 10; i++)
                                {
                                    for (int o = 0; o < 7; o++)
                                    {
                                        try
                                        {

                                            if (enemyBigList[0][o][i].Tag.ToString() == "Ship1")
                                            {
                                                enemyBigList[0][o][i].BackColor = Color.Purple;
                                            }
                                        }
                                        catch
                                        {

                                        }
                                    }
                                }
                            }
                            Button.Enabled = false;


                            break;

                        case "Ship2":
                            Ship2Counter++;
                            Button.BackColor = Color.Red;
                            if (Ship2Counter == 4)
                            {
                                Friendlywinner++;
                                MessageBox.Show("You sank my BattleShip");

                                //Changes the Red tiles to a different color to show you what ship was sunk
                                for (int i = 0; i < 10; i++)
                                {
                                    for (int o = 0; o < 7; o++)
                                    {
                                        try
                                        {

                                            if (enemyBigList[0][o][i].Tag.ToString() == "Ship2")
                                            {
                                                enemyBigList[0][o][i].BackColor = Color.Yellow;
                                            }
                                        }
                                        catch
                                        {

                                        }
                                    }
                                }
                            }
                            Button.Enabled = false;
                            break;

                        case "Ship3":
                            Ship3Counter++;
                            Button.BackColor = Color.Red;
                            if (Ship3Counter == 3)
                            {
                                Friendlywinner++;
                                MessageBox.Show("You sank my Destroyer");

                                //Changes the Red tiles to a different color to show you what ship was sunk
                                for (int i = 0; i < 10; i++)
                                {
                                    for (int o = 0; o < 7; o++)
                                    {
                                        try
                                        {

                                            if (enemyBigList[0][o][i].Tag.ToString() == "Ship3")
                                            {
                                                enemyBigList[0][o][i].BackColor = Color.Orange;
                                            }
                                        }
                                        catch
                                        {

                                        }
                                    }
                                }
                            }
                            Button.Enabled = false;
                            break;

                        case "Ship4":
                            Ship4Counter++;
                            Button.BackColor = Color.Red;
                            if (Ship4Counter == 3)
                            {
                                Friendlywinner++;
                                MessageBox.Show("You sank my Submarine");

                                //Changes the Red tiles to a different color to show you what ship was sunk
                                for (int i = 0; i < 10; i++)
                                {
                                    for (int o = 0; o < 7; o++)
                                    {
                                        try
                                        {

                                            if (enemyBigList[0][o][i].Tag.ToString() == "Ship4")
                                            {
                                                enemyBigList[0][o][i].BackColor = Color.Green;
                                            }
                                        }
                                        catch
                                        {

                                        }
                                    }
                                }
                            }
                            Button.Enabled = false;
                            break;

                        case "Ship5":
                            Ship5Counter++;
                            Button.BackColor = Color.Red;
                            if (Ship5Counter == 2)
                            {
                                Friendlywinner++;
                                MessageBox.Show("You sank my Frigate");

                                //Changes the Red tiles to a different color to show you what ship was sunk
                                for (int i = 0; i < 10; i++)
                                {
                                    for (int o = 0; o < 7; o++)
                                    {
                                        try
                                        {

                                            if (enemyBigList[0][o][i].Tag.ToString() == "Ship5")
                                            {
                                                enemyBigList[0][o][i].BackColor = Color.PaleVioletRed;
                                            }
                                        }
                                        catch
                                        {

                                        }
                                    }
                                }

                            }
                            Button.Enabled = false;
                            break;

                    }
                }
                if (Friendlywinner >= 5)
                {
                    MessageBox.Show("You are the winner");
                    Environment.Exit(0);
                }
            }
            catch
            {
                Button Button = (sender as Button);
                Button.BackColor = Color.White;
                Button.Enabled = false;
            }

            EnnemyShooting();
        }

        #endregion


        #region Methodes

        /// <summary>
        /// Moves the ship around on a click of the arrow keys
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Arrowkeysclick(object sender, EventArgs e)
        {
            //Checks the text on the button
            string arrowDirection = (sender as Button).Text;

            //checks what the string says and in which direction to go
            switch (arrowDirection)
            {
                //Moves the ship upwards
                case "Up":
                    btnConfirm.Enabled = true;
                    if (direction)
                    {
                        DeletingtheGray();
                        try
                        {
                            //Verticalment up
                            UpDown--;

                            //Fait certain que tu ne peut pas sortir de la grille
                            if (UpDown < shipAmount)
                            {
                                UpDown = shipAmount - 1;
                            }

                            for (int i = 0; i < shipAmount; i++)
                            {
                                friendlyAllVerticalTiles[RightLeft][UpDown - i].BackColor = Color.Gray;

                                //Check si le bateau qui est entrai d'etre placé est sur une autre bateau, if yes, disabled.
                                if (friendlyAllVerticalTiles[RightLeft][UpDown - i].Tag != null)
                                {
                                    btnConfirm.Enabled = false;
                                }
                            }
                        }
                        catch
                        {

                        }

                    }
                    else
                    {
                        DeletingtheGray();
                        try
                        {
                            //Horizontalement Up
                            UpDown--;

                            //Fait certain que tu ne peut pas sortir de la grille
                            if (UpDown < 0)
                            {
                                UpDown = 0;
                            }

                            for (int i = 0; i < shipAmount; i++)
                            {
                                friendlyAllHorizontalTiles[UpDown][RightLeft - i].BackColor = Color.Gray;

                                //Check si le bateau qui est entrai d'etre placé est sur une autre bateau, if yes, disabled.
                                if (friendlyAllHorizontalTiles[UpDown][RightLeft - i].Tag != null)
                                {
                                    btnConfirm.Enabled = false;
                                }
                            }
                        }
                        catch
                        {

                        }
                    }
                    break;
                //moves the ship downwards
                case "Down":
                    btnConfirm.Enabled = true;
                    if (direction)
                    {
                        DeletingtheGray();
                        try
                        {
                            //Verticalement down
                            UpDown++;

                            //Fait certain que tu ne peut pas sortir de la grille
                            if (UpDown > 6)
                            {
                                UpDown = 6;
                            }

                            for (int i = 0; i < shipAmount; i++)
                            {
                                friendlyAllVerticalTiles[RightLeft][UpDown - i].BackColor = Color.Gray;

                                //Check si le bateau qui est entrai d'etre placé est sur une autre bateau, if yes, disabled.
                                if (friendlyAllVerticalTiles[RightLeft][UpDown - i].Tag != null)
                                {
                                    btnConfirm.Enabled = false;
                                }
                            }
                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        DeletingtheGray();
                        try
                        {
                            //Horizontalement down
                            UpDown++;

                            //Fait certain que tu ne peut pas sortir de la grille
                            if (UpDown > 6)
                            {
                                UpDown = 6;
                            }

                            for (int i = 0; i < shipAmount; i++)
                            {
                                friendlyAllHorizontalTiles[UpDown][RightLeft - i].BackColor = Color.Gray;

                                //Check si le bateau qui est entrai d'etre placé est sur une autre bateau, if yes, disabled.
                                if (friendlyAllHorizontalTiles[UpDown][RightLeft - i].Tag != null)
                                {
                                    btnConfirm.Enabled = false;
                                }
                            }
                        }
                        catch
                        {

                        }
                    }
                    break;
                //moves the ship to the left
                case "Left":
                    btnConfirm.Enabled = true;
                    if (direction)
                    {
                        DeletingtheGray();
                        try
                        {
                            //Verticalement gauche
                            RightLeft--;

                            //Fait certain que tu ne peut pas sortir de la grille
                            if (RightLeft < 0)
                            {
                                RightLeft = 0;
                            }
                            for (int i = 0; i < shipAmount; i++)
                            {
                                friendlyAllVerticalTiles[RightLeft][UpDown - i].BackColor = Color.Gray;

                                //Check si le bateau qui est entrai d'etre placé est sur une autre bateau, if yes, disabled.
                                if (friendlyAllVerticalTiles[RightLeft][UpDown - i].Tag != null)
                                {
                                    btnConfirm.Enabled = false;
                                }
                            }
                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        DeletingtheGray();
                        try
                        {
                            //Horizontalement gauche
                            RightLeft--;

                            if (RightLeft < shipAmount)
                            {
                                RightLeft = shipAmount - 1;
                            }

                            for (int i = 0; i < shipAmount; i++)
                            {
                                friendlyAllHorizontalTiles[UpDown][RightLeft - i].BackColor = Color.Gray;

                                //Check si le bateau qui est entrai d'etre placé est sur une autre bateau, if yes, disabled.
                                if (friendlyAllHorizontalTiles[UpDown][RightLeft - i].Tag != null)
                                {
                                    btnConfirm.Enabled = false;
                                }
                            }
                        }
                        catch
                        {

                        }
                    }
                    break;
                //Moves the ship to the right
                case "Right":
                    btnConfirm.Enabled = true;
                    if (direction)
                    {
                        DeletingtheGray();
                        try
                        {
                            //Verticalement droite
                            RightLeft++;

                            if (RightLeft > 9)
                            {
                                RightLeft = 9;
                            }

                            for (int i = 0; i < shipAmount; i++)
                            {
                                friendlyAllVerticalTiles[RightLeft][UpDown - i].BackColor = Color.Gray;

                                //Check si le bateau qui est entrai d'etre placé est sur une autre bateau, if yes, disabled.
                                if (friendlyAllVerticalTiles[RightLeft][UpDown - i].Tag != null)
                                {
                                    btnConfirm.Enabled = false;
                                }
                            }
                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        DeletingtheGray();
                        try
                        {
                            //Horizontalement droite
                            RightLeft++;

                            if (RightLeft > 9)
                            {
                                RightLeft = 9;
                            }

                            for (int i = 0; i < shipAmount; i++)
                            {
                                friendlyAllHorizontalTiles[UpDown][RightLeft - i].BackColor = Color.Gray;

                                //Check si le bateau qui est entrai d'etre placé est sur une autre bateau, if yes, disabled.
                                if (friendlyAllHorizontalTiles[UpDown][RightLeft - i].Tag != null)
                                {
                                    btnConfirm.Enabled = false;
                                }
                            }
                        }
                        catch
                        {

                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Methode to declare all of the Lists needed
        /// </summary>
        private void DeclaringLists()
        {
            //Declaring all of the horizontal Lists
            friendlyTilesHorizontal1 = new List<Button> { btnFriendly1, btnFriendly2, btnFriendly3, btnFriendly4, btnFriendly5, btnFriendly6, btnFriendly7, btnFriendly8, btnFriendly9, btnFriendly10 };
            friendlyTilesHorizontal2 = new List<Button> { btnFriendly11, btnFriendly12, btnFriendly13, btnFriendly14, btnFriendly15, btnFriendly16, btnFriendly17, btnFriendly18, btnFriendly19, btnFriendly20 };
            friendlyTilesHorizontal3 = new List<Button> { btnFriendly21, btnFriendly22, btnFriendly23, btnFriendly24, btnFriendly25, btnFriendly26, btnFriendly27, btnFriendly28, btnFriendly29, btnFriendly30 };
            friendlyTilesHorizontal4 = new List<Button> { btnFriendly31, btnFriendly32, btnFriendly33, btnFriendly34, btnFriendly35, btnFriendly36, btnFriendly37, btnFriendly38, btnFriendly39, btnFriendly40 };
            friendlyTilesHorizontal5 = new List<Button> { btnFriendly41, btnFriendly42, btnFriendly43, btnFriendly44, btnFriendly45, btnFriendly46, btnFriendly47, btnFriendly48, btnFriendly49, btnFriendly50 };
            friendlyTilesHorizontal6 = new List<Button> { btnFriendly51, btnFriendly52, btnFriendly53, btnFriendly54, btnFriendly55, btnFriendly56, btnFriendly57, btnFriendly58, btnFriendly59, btnFriendly60 };
            friendlyTilesHorizontal7 = new List<Button> { btnFriendly61, btnFriendly62, btnFriendly63, btnFriendly64, btnFriendly65, btnFriendly66, btnFriendly67, btnFriendly68, btnFriendly69, btnFriendly70 };

            //Declaring all of the Vertical Lists
            friendlyTilesVertical1 = new List<Button> { btnFriendly1, btnFriendly11, btnFriendly21, btnFriendly31, btnFriendly41, btnFriendly51, btnFriendly61 };
            friendlyTilesVertical2 = new List<Button> { btnFriendly2, btnFriendly12, btnFriendly22, btnFriendly32, btnFriendly42, btnFriendly52, btnFriendly62 };
            friendlyTilesVertical3 = new List<Button> { btnFriendly3, btnFriendly13, btnFriendly23, btnFriendly33, btnFriendly43, btnFriendly53, btnFriendly63 };
            friendlyTilesVertical4 = new List<Button> { btnFriendly4, btnFriendly14, btnFriendly24, btnFriendly34, btnFriendly44, btnFriendly54, btnFriendly64 };
            friendlyTilesVertical5 = new List<Button> { btnFriendly5, btnFriendly15, btnFriendly25, btnFriendly35, btnFriendly45, btnFriendly55, btnFriendly65 };
            friendlyTilesVertical6 = new List<Button> { btnFriendly6, btnFriendly16, btnFriendly26, btnFriendly36, btnFriendly46, btnFriendly56, btnFriendly66 };
            friendlyTilesVertical7 = new List<Button> { btnFriendly7, btnFriendly17, btnFriendly27, btnFriendly37, btnFriendly47, btnFriendly57, btnFriendly67 };
            friendlyTilesVertical8 = new List<Button> { btnFriendly8, btnFriendly18, btnFriendly28, btnFriendly38, btnFriendly48, btnFriendly58, btnFriendly68 };
            friendlyTilesVertical9 = new List<Button> { btnFriendly9, btnFriendly19, btnFriendly29, btnFriendly39, btnFriendly49, btnFriendly59, btnFriendly69 };
            friendlyTilesVertical10 = new List<Button> { btnFriendly10, btnFriendly20, btnFriendly30, btnFriendly40, btnFriendly50, btnFriendly60, btnFriendly70 };

            //Puts the horizontal lists into one list
            friendlyAllHorizontalTiles = new List<List<Button>> { friendlyTilesHorizontal1, friendlyTilesHorizontal2, friendlyTilesHorizontal3, friendlyTilesHorizontal4,
                                                                  friendlyTilesHorizontal5, friendlyTilesHorizontal6, friendlyTilesHorizontal7};

            //Puts all vertical Lists into one list
            friendlyAllVerticalTiles = new List<List<Button>> { friendlyTilesVertical1, friendlyTilesVertical2, friendlyTilesVertical3, friendlyTilesVertical4, friendlyTilesVertical5,
                                                                friendlyTilesVertical6, friendlyTilesVertical7, friendlyTilesVertical8, friendlyTilesVertical9, friendlyTilesVertical10};

            //Puts the finale lists into a bigger list
            TheBigList = new List<List<List<Button>>> { friendlyAllHorizontalTiles, friendlyAllVerticalTiles };

            //Enemy ship list
            enemyShipNames = new List<string> { "Battleship", "Aircraft Carrier", "Frigate", "Submarine", "Destroyer" };

            //Declaring all the horizontal lists
            enemyTilesHorizontal1 = new List<Button> { btnEnemy1, btnEnemy2, btnEnemy3, btnEnemy4, btnEnemy5, btnEnemy6, btnEnemy7, btnEnemy8, btnEnemy9, btnEnemy10 };
            enemyTilesHorizontal2 = new List<Button> { btnEnemy11, btnEnemy12, btnEnemy13, btnEnemy14, btnEnemy15, btnEnemy16, btnEnemy17, btnEnemy18, btnEnemy19, btnEnemy20 };
            enemyTilesHorizontal3 = new List<Button> { btnEnemy21, btnEnemy22, btnEnemy23, btnEnemy24, btnEnemy25, btnEnemy26, btnEnemy27, btnEnemy28, btnEnemy29, btnEnemy30 };
            enemyTilesHorizontal4 = new List<Button> { btnEnemy31, btnEnemy32, btnEnemy33, btnEnemy34, btnEnemy35, btnEnemy36, btnEnemy37, btnEnemy38, btnEnemy39, btnEnemy40 };
            enemyTilesHorizontal5 = new List<Button> { btnEnemy41, btnEnemy42, btnEnemy43, btnEnemy44, btnEnemy45, btnEnemy46, btnEnemy47, btnEnemy48, btnEnemy49, btnEnemy50 };
            enemyTilesHorizontal6 = new List<Button> { btnEnemy51, btnEnemy52, btnEnemy53, btnEnemy54, btnEnemy55, btnEnemy56, btnEnemy57, btnEnemy58, btnEnemy59, btnEnemy60 };
            enemyTilesHorizontal7 = new List<Button> { btnEnemy61, btnEnemy62, btnEnemy63, btnEnemy64, btnEnemy65, btnEnemy66, btnEnemy67, btnEnemy68, btnEnemy69, btnEnemy70 };

            //Declaring all the vertical list
            enemyTilesVertical1 = new List<Button> { btnEnemy1, btnEnemy11, btnEnemy21, btnEnemy31, btnEnemy41, btnEnemy51, btnEnemy61 };
            enemyTilesVertical2 = new List<Button> { btnEnemy2, btnEnemy12, btnEnemy22, btnEnemy32, btnEnemy42, btnEnemy52, btnEnemy62 };
            enemyTilesVertical3 = new List<Button> { btnEnemy3, btnEnemy13, btnEnemy23, btnEnemy33, btnEnemy43, btnEnemy53, btnEnemy63 };
            enemyTilesVertical4 = new List<Button> { btnEnemy4, btnEnemy14, btnEnemy24, btnEnemy34, btnEnemy44, btnEnemy54, btnEnemy64 };
            enemyTilesVertical5 = new List<Button> { btnEnemy5, btnEnemy15, btnEnemy25, btnEnemy35, btnEnemy45, btnEnemy55, btnEnemy65 };
            enemyTilesVertical6 = new List<Button> { btnEnemy6, btnEnemy16, btnEnemy26, btnEnemy36, btnEnemy46, btnEnemy56, btnEnemy66 };
            enemyTilesVertical7 = new List<Button> { btnEnemy7, btnEnemy17, btnEnemy27, btnEnemy37, btnEnemy47, btnEnemy57, btnEnemy67 };
            enemyTilesVertical8 = new List<Button> { btnEnemy8, btnEnemy18, btnEnemy28, btnEnemy38, btnEnemy48, btnEnemy58, btnEnemy68 };
            enemyTilesVertical9 = new List<Button> { btnEnemy9, btnEnemy19, btnEnemy29, btnEnemy39, btnEnemy49, btnEnemy59, btnEnemy69 };
            enemyTilesVertical10 = new List<Button> { btnEnemy10, btnEnemy20, btnEnemy30, btnEnemy40, btnEnemy50, btnEnemy60, btnEnemy70 };

            //Puts all the horizontal lists into one list
            enemyAllHorizontalTiles = new List<List<Button>> { enemyTilesHorizontal1, enemyTilesHorizontal2, enemyTilesHorizontal3, enemyTilesHorizontal4, enemyTilesHorizontal5, enemyTilesHorizontal6, enemyTilesHorizontal7 };

            //Puts all the vertical lists into one list
            enemyAllVerticalTiles = new List<List<Button>> { enemyTilesVertical1, enemyTilesVertical2, enemyTilesVertical3, enemyTilesVertical4, enemyTilesVertical5, enemyTilesVertical6, enemyTilesVertical7, enemyTilesVertical8, enemyTilesVertical9, enemyTilesVertical10 };

            //Makes a big list of the enemy tiles
            enemyBigList = new List<List<List<Button>>> { enemyAllHorizontalTiles, enemyAllVerticalTiles };

            afterEnemyHit = new List<string> { "Up", "Down", "Left", "Right" };
        }

        /// <summary>
        /// Adds a ship to the top left corner of the friendly side
        /// </summary>
        private void AddingGrayShip()
        {
            btnConfirm.Enabled = true;
            //adds the gray tiles onto the grid
            for (int i = 0; i < shipAmount; i++)
            {
                //places the gray in the proper slots
                friendlyAllHorizontalTiles[horizontal][horizontalSlot].BackColor = Color.Gray;
                friendlyAllVerticalTiles[vertical][verticalSlot].BackColor = Color.Gray;

                //checks if the the user wanted to place the ship vertically or horizontally
                if (direction)
                {
                    //if its vertical adds 1 to the vertical modifier
                    verticalSlot++;
                }
                else
                {
                    //if its horizontal adds 1 to the horizontal modifier
                    horizontalSlot++;
                }
            }
            //Because it adds to many so its a simple remove 1 right after its added on
            verticalSlot = 0;
            horizontalSlot = 0;

        }

        /// <summary>
        /// Enables and disables certain buttons so you cant use them when ships are being placed
        /// </summary>
        private void EnableAndDisableButtons()
        {
            //Enable Confirmation button
            btnConfirm.Enabled = true;

            //Check si le bateau dans le spawn est sur une autre bateau au tout debut
            for (int i = 0; i < shipAmount; i++)
            {
                //Check si le bateau qui est entrai d'etre placé est sur une autre bateau, if yes, disabled.
                if (friendlyAllHorizontalTiles[horizontal][horizontalSlot].Tag != null || friendlyAllVerticalTiles[vertical][verticalSlot].Tag != null)
                {
                    btnConfirm.Enabled = false;
                }

                if (direction)
                {
                    //if its vertical adds 1 to the vertical modifier
                    verticalSlot++;
                }
                else
                {
                    //if its horizontal adds 1 to the horizontal modifier
                    horizontalSlot++;
                }
            }
            //Disables the horizontal and vertical button so you cant changed its direction onced placed
            btnHorizontal.Enabled = false;
            btnVertical.Enabled = false;

            //Enables all the direction buttons
            btnUp.Enabled = true;
            btnRight.Enabled = true;
            btnDown.Enabled = true;
            btnLeft.Enabled = true;

            //Disables all the ship buttons
            btnFrigate.Enabled = false;
            btnSubmarine.Enabled = false;
            btnDestroyer.Enabled = false;
            btnBattleship.Enabled = false;
            btnCV.Enabled = false;
        }

        /// <summary>
        /// Deletes all the gray tiles on the board that are still in the list
        /// </summary>
        private void DeletingtheGray()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int o = 0; o < 7; o++)
                {
                    if (TheBigList[1][i][o].Tag == null)
                    {
                        TheBigList[1][i][o].BackColor = Color.Navy;
                        TheBigList[0][o][i].BackColor = Color.Navy;
                    }
                }
            }

        }

        /// <summary>
        /// disables the arrow keys and confirm button at the start 
        /// </summary>
        private void EnableDisableStartingButtons()
        {
            //Disables all the arrow keys
            btnLeft.Enabled = false;
            btnRight.Enabled = false;
            btnUp.Enabled = false;
            btnDown.Enabled = false;

            //disables the confirm button
            btnConfirm.Enabled = false;
        }

        #endregion


        #region AiEnemy

        /// <summary>
        /// Used to place the ennemy ships
        /// </summary>
        private void EnnemyShipPlacement()
        {
            #region Tags
            string Ship1 = "Ship1";
            string Ship2 = "Ship2";
            string Ship3 = "Ship3";
            string Ship4 = "Ship4";
            string Ship5 = "Ship5";
            #endregion

            #region variables
            bool verticalDirection = true;
            Random rnd = new Random();
            int enemyShipLength = 0;
            string name = "";
            int originalEnemyVerticalSlot = 0;
            int originalEnemyHorizontalSlot = 0;
            int enemyVertical = 0;
            int enemyHorizontal = 0;
            int enemyVerticalSlot = 0;
            int enemyHorizontalSlot = 0;
            int direction = 0;
            int restartWhile = 0;
            #endregion

            for (int i = 0; i < 5; i++)
            {
                //Goes through a list and gets each name of each ship
                name = enemyShipNames[i].ToString();
                switch (name)
                {
                    #region Aircraft Carrier
                    case "Aircraft Carrier":
                        enemyShipLength = 5;

                        direction = rnd.Next(0, 2);
                        //if direction == 0 direction is vertical, if not it is horizontal
                        if (direction == 0)
                        {
                            verticalDirection = true;
                        }
                        else
                        {
                            verticalDirection = false;
                        }

                        while (true)
                        {
                            restartWhile = 0;
                            //Randomly selects a number to pick a location in which the ship can be placed
                            enemyVertical = rnd.Next(0, 10);
                            enemyHorizontal = rnd.Next(0, 7);
                            enemyVerticalSlot = rnd.Next(0, 3);
                            enemyHorizontalSlot = rnd.Next(0, 6);

                            //Remebers the original numbers
                            originalEnemyHorizontalSlot = enemyHorizontalSlot;
                            originalEnemyVerticalSlot = enemyVerticalSlot;


                            //Checks if the slots are available to be used
                            for (int o = 0; o < enemyShipLength; o++)
                            {
                                if (verticalDirection)
                                {
                                    //Checks the vertical slots when its being placed vertically
                                    if (enemyAllVerticalTiles[enemyVertical][enemyVerticalSlot].Tag != null)
                                    {
                                        restartWhile++;
                                        //breaks out of loop
                                        break;
                                    }
                                    else
                                    {
                                        enemyVerticalSlot++;
                                    }
                                }
                                else
                                {
                                    //Checks the horizontal slots when its being placed horizontally
                                    if (enemyAllHorizontalTiles[enemyHorizontal][enemyHorizontalSlot].Tag != null)
                                    {
                                        restartWhile++;
                                        //breaks out of loop
                                        break;
                                    }
                                    else
                                    {
                                        enemyHorizontalSlot++;
                                    }
                                }
                            }
                            if (verticalDirection)
                            {
                                //Checks the last tile again 
                                if (restartWhile != 0)
                                {
                                    //restarts the while loop
                                    continue;
                                }
                            }
                            else
                            {
                                if (restartWhile != 0)
                                {
                                    //restarts the while loop
                                    continue;
                                }
                            }
                            //gets the variables ready
                            enemyVerticalSlot = originalEnemyVerticalSlot;
                            enemyHorizontalSlot = originalEnemyHorizontalSlot;

                            if (verticalDirection)
                            {
                                for (int o = 0; o < enemyShipLength; o++)
                                {
                                    //Randomly places the ship in the right slots and gives it the tag ship1(vertically placed)
                                    enemyAllVerticalTiles[enemyVertical][enemyVerticalSlot].Tag = Ship1;

                                    //enemyAllVerticalTiles[enemyVertical][enemyVerticalSlot].Text = Ship1;
                                    //enemyAllVerticalTiles[enemyVertical][enemyVerticalSlot].BackColor = Color.Gray;
                                    enemyVerticalSlot++;
                                }
                            }
                            else
                            {
                                for (int o = 0; o < enemyShipLength; o++)
                                {
                                    //Randomly places the ship in the right slots and gives it the tag ship1(horizontally placed)
                                    enemyAllHorizontalTiles[enemyHorizontal][enemyHorizontalSlot].Tag = Ship1;

                                    //enemyAllHorizontalTiles[enemyHorizontal][enemyHorizontalSlot].Text = Ship1;
                                    //enemyAllHorizontalTiles[enemyHorizontal][enemyHorizontalSlot].BackColor = Color.Gray;
                                    enemyHorizontalSlot++;
                                }
                            }
                            break;
                        }
                        break;
                    #endregion
                    #region Battleship
                    case "Battleship":
                        enemyShipLength = 4;

                        direction = rnd.Next(0, 2);
                        //if direction == 0 direction is vertical, if not it is horizontal
                        if (direction == 0)
                        {
                            verticalDirection = true;
                        }
                        else
                        {
                            verticalDirection = false;
                        }

                        while (true)
                        {
                            restartWhile = 0;
                            //Randomly selects a number to pick a location in which the ship can be placed
                            enemyVertical = rnd.Next(0, 10);
                            enemyHorizontal = rnd.Next(0, 7);
                            enemyVerticalSlot = rnd.Next(0, 4);
                            enemyHorizontalSlot = rnd.Next(0, 7);

                            //Remebers the original numbers
                            originalEnemyHorizontalSlot = enemyHorizontalSlot;
                            originalEnemyVerticalSlot = enemyVerticalSlot;

                            //Checks if the slots are available to be used
                            for (int o = 0; o < enemyShipLength; o++)
                            {
                                if (verticalDirection)
                                {
                                    //Checks the vertical slots when its being placed vertically
                                    if (enemyAllVerticalTiles[enemyVertical][enemyVerticalSlot].Tag != null)
                                    {
                                        restartWhile++;
                                        //breaks out of loop
                                        break;
                                    }
                                    else
                                    {
                                        enemyVerticalSlot++;
                                    }
                                }
                                else
                                {
                                    //Checks the horizontal slots when its being placed horizontally
                                    if (enemyAllHorizontalTiles[enemyHorizontal][enemyHorizontalSlot].Tag != null)
                                    {
                                        restartWhile++;
                                        //breaks out of loop
                                        break;
                                    }
                                    else
                                    {
                                        enemyHorizontalSlot++;
                                    }
                                }
                            }
                            if (verticalDirection)
                            {
                                //Checks the last tile again 
                                if (restartWhile != 0)
                                {
                                    //restarts the while loop
                                    continue;
                                }
                            }
                            else
                            {
                                if (restartWhile != 0)
                                {
                                    //restarts the while loop
                                    continue;
                                }
                            }
                            //gets the variables ready
                            enemyVerticalSlot = originalEnemyVerticalSlot;
                            enemyHorizontalSlot = originalEnemyHorizontalSlot;

                            if (verticalDirection)
                            {
                                for (int o = 0; o < enemyShipLength; o++)
                                {
                                    //Randomly places the ship in the right slots and gives it the tag ship1(vertically placed)
                                    enemyAllVerticalTiles[enemyVertical][enemyVerticalSlot].Tag = Ship2;

                                    //enemyAllVerticalTiles[enemyVertical][enemyVerticalSlot].Text = Ship2;
                                    //enemyAllVerticalTiles[enemyVertical][enemyVerticalSlot].BackColor = Color.Gray;
                                    enemyVerticalSlot++;
                                }
                            }
                            else
                            {
                                for (int o = 0; o < enemyShipLength; o++)
                                {
                                    //Randomly places the ship in the right slots and gives it the tag ship1(horizontally placed)
                                    enemyAllHorizontalTiles[enemyHorizontal][enemyHorizontalSlot].Tag = Ship2;

                                    //enemyAllHorizontalTiles[enemyHorizontal][enemyHorizontalSlot].Text = Ship2;
                                    //enemyAllHorizontalTiles[enemyHorizontal][enemyHorizontalSlot].BackColor = Color.Gray;
                                    enemyHorizontalSlot++;
                                }
                            }
                            break;
                        }
                        break;
                    #endregion
                    #region Destroyer
                    case "Destroyer":
                        enemyShipLength = 3;


                        direction = rnd.Next(0, 2);
                        //if direction == 0 direction is vertical, if not it is horizontal
                        if (direction == 0)
                        {
                            verticalDirection = true;
                        }
                        else
                        {
                            verticalDirection = false;
                        }

                        while (true)
                        {
                            restartWhile = 0;
                            //Randomly selects a number to pick a location in which the ship can be placed
                            enemyVertical = rnd.Next(0, 10);
                            enemyHorizontal = rnd.Next(0, 7);
                            enemyVerticalSlot = rnd.Next(0, 5);
                            enemyHorizontalSlot = rnd.Next(0, 8);

                            //Remebers the original numbers
                            originalEnemyHorizontalSlot = enemyHorizontalSlot;
                            originalEnemyVerticalSlot = enemyVerticalSlot;

                            //Checks if the slots are available to be used
                            for (int o = 0; o < enemyShipLength; o++)
                            {
                                if (verticalDirection)
                                {
                                    //Checks the vertical slots when its being placed vertically
                                    if (enemyAllVerticalTiles[enemyVertical][enemyVerticalSlot].Tag != null)
                                    {
                                        restartWhile++;
                                        //breaks out of loop
                                        break;
                                    }
                                    else
                                    {
                                        enemyVerticalSlot++;
                                    }
                                }
                                else
                                {
                                    //Checks the horizontal slots when its being placed horizontally
                                    if (enemyAllHorizontalTiles[enemyHorizontal][enemyHorizontalSlot].Tag != null)
                                    {
                                        restartWhile++;
                                        //breaks out of loop
                                        break;
                                    }
                                    else
                                    {
                                        enemyHorizontalSlot++;
                                    }
                                }
                            }
                            if (verticalDirection)
                            {
                                //Checks the last tile again 
                                if (restartWhile != 0)
                                {
                                    //restarts the while loop
                                    continue;
                                }
                            }
                            else
                            {
                                if (restartWhile != 0)
                                {
                                    //restarts the while loop
                                    continue;
                                }
                            }
                            //gets the variables ready
                            enemyVerticalSlot = originalEnemyVerticalSlot;
                            enemyHorizontalSlot = originalEnemyHorizontalSlot;

                            if (verticalDirection)
                            {
                                for (int o = 0; o < enemyShipLength; o++)
                                {
                                    //Randomly places the ship in the right slots and gives it the tag ship1(vertically placed)
                                    enemyAllVerticalTiles[enemyVertical][enemyVerticalSlot].Tag = Ship3;

                                    //enemyAllVerticalTiles[enemyVertical][enemyVerticalSlot].Text = Ship3;
                                    //enemyAllVerticalTiles[enemyVertical][enemyVerticalSlot].BackColor = Color.Gray;
                                    enemyVerticalSlot++;
                                }
                            }
                            else
                            {
                                for (int o = 0; o < enemyShipLength; o++)
                                {
                                    //Randomly places the ship in the right slots and gives it the tag ship1(horizontally placed)
                                    enemyAllHorizontalTiles[enemyHorizontal][enemyHorizontalSlot].Tag = Ship3;

                                    //enemyAllHorizontalTiles[enemyHorizontal][enemyHorizontalSlot].BackColor = Color.Gray;
                                    //enemyAllHorizontalTiles[enemyHorizontal][enemyHorizontalSlot].Text = Ship3;
                                    enemyHorizontalSlot++;
                                }
                            }
                            break;
                        }
                        break;
                    #endregion
                    #region Submarine
                    case "Submarine":
                        enemyShipLength = 3;

                        direction = rnd.Next(0, 2);
                        //if direction == 0 direction is vertical, if not it is horizontal
                        if (direction == 0)
                        {
                            verticalDirection = true;
                        }
                        else
                        {
                            verticalDirection = false;
                        }

                        while (true)
                        {
                            restartWhile = 0;
                            //Randomly selects a number to pick a location in which the ship can be placed
                            enemyVertical = rnd.Next(0, 10);
                            enemyHorizontal = rnd.Next(0, 7);
                            enemyVerticalSlot = rnd.Next(0, 5);
                            enemyHorizontalSlot = rnd.Next(0, 8);

                            //Remebers the original numbers
                            originalEnemyHorizontalSlot = enemyHorizontalSlot;
                            originalEnemyVerticalSlot = enemyVerticalSlot;

                            //Checks if the slots are available to be used
                            for (int o = 0; o < enemyShipLength; o++)
                            {
                                if (verticalDirection)
                                {
                                    //Checks the vertical slots when its being placed vertically
                                    if (enemyAllVerticalTiles[enemyVertical][enemyVerticalSlot].Tag != null)
                                    {
                                        restartWhile++;
                                        //breaks out of loop
                                        break;
                                    }
                                    else
                                    {
                                        enemyVerticalSlot++;
                                    }
                                }
                                else
                                {
                                    //Checks the horizontal slots when its being placed horizontally
                                    if (enemyAllHorizontalTiles[enemyHorizontal][enemyHorizontalSlot].Tag != null)
                                    {
                                        restartWhile++;
                                        //breaks out of loop
                                        break;
                                    }
                                    else
                                    {
                                        enemyHorizontalSlot++;
                                    }
                                }
                            }
                            if (verticalDirection)
                            {
                                //Checks the last tile again 
                                if (restartWhile != 0)
                                {
                                    //restarts the while loop
                                    continue;
                                }
                            }
                            else
                            {
                                if (restartWhile != 0)
                                {
                                    //restarts the while loop
                                    continue;
                                }
                            }
                            //gets the variables ready
                            enemyVerticalSlot = originalEnemyVerticalSlot;
                            enemyHorizontalSlot = originalEnemyHorizontalSlot;

                            if (verticalDirection)
                            {
                                for (int o = 0; o < enemyShipLength; o++)
                                {
                                    //Randomly places the ship in the right slots and gives it the tag ship1(vertically placed)
                                    enemyAllVerticalTiles[enemyVertical][enemyVerticalSlot].Tag = Ship4;

                                    //enemyAllVerticalTiles[enemyVertical][enemyVerticalSlot].Text = Ship4;
                                    //enemyAllVerticalTiles[enemyVertical][enemyVerticalSlot].BackColor = Color.Gray;
                                    enemyVerticalSlot++;
                                }
                            }
                            else
                            {
                                for (int o = 0; o < enemyShipLength; o++)
                                {
                                    //Randomly places the ship in the right slots and gives it the tag ship1(horizontally placed)
                                    enemyAllHorizontalTiles[enemyHorizontal][enemyHorizontalSlot].Tag = Ship4;

                                    //enemyAllHorizontalTiles[enemyHorizontal][enemyHorizontalSlot].Text = Ship4;
                                    //enemyAllHorizontalTiles[enemyHorizontal][enemyHorizontalSlot].BackColor = Color.Gray;
                                    enemyHorizontalSlot++;
                                }
                            }
                            break;
                        }
                        break;
                    #endregion
                    #region Frigate
                    case "Frigate":
                        enemyShipLength = 2;

                        direction = rnd.Next(0, 2);
                        //if direction == 0 direction is vertical, if not it is horizontal
                        if (direction == 0)
                        {
                            verticalDirection = true;
                        }
                        else
                        {
                            verticalDirection = false;
                        }

                        while (true)
                        {
                            restartWhile = 0;
                            //Randomly selects a number to pick a location in which the ship can be placed
                            enemyVertical = rnd.Next(0, 10);
                            enemyHorizontal = rnd.Next(0, 7);
                            enemyVerticalSlot = rnd.Next(0, 6);
                            enemyHorizontalSlot = rnd.Next(0, 9);

                            //Remebers the original numbers
                            originalEnemyHorizontalSlot = enemyHorizontalSlot;
                            originalEnemyVerticalSlot = enemyVerticalSlot;

                            //Checks if the slots are available to be used
                            for (int o = 0; o < enemyShipLength; o++)
                            {
                                if (verticalDirection)
                                {
                                    //Checks the vertical slots when its being placed vertically
                                    if (enemyAllVerticalTiles[enemyVertical][enemyVerticalSlot].Tag != null)
                                    {
                                        restartWhile++;
                                        //breaks out of loop
                                        break;
                                    }
                                    else
                                    {
                                        enemyVerticalSlot++;
                                    }
                                }
                                else
                                {
                                    //Checks the horizontal slots when its being placed horizontally
                                    if (enemyAllHorizontalTiles[enemyHorizontal][enemyHorizontalSlot].Tag != null)
                                    {
                                        restartWhile++;
                                        //breaks out of loop
                                        break;
                                    }
                                    else
                                    {
                                        enemyHorizontalSlot++;
                                    }
                                }
                            }
                            if (verticalDirection)
                            {
                                //Checks the last tile again 
                                if (restartWhile != 0)
                                {
                                    //restarts the while loop
                                    continue;
                                }
                            }
                            else
                            {
                                if (restartWhile != 0)
                                {
                                    //restarts the while loop
                                    continue;
                                }
                            }
                            //gets the variables ready
                            enemyVerticalSlot = originalEnemyVerticalSlot;
                            enemyHorizontalSlot = originalEnemyHorizontalSlot;

                            if (verticalDirection)
                            {
                                for (int o = 0; o < enemyShipLength; o++)
                                {
                                    //Randomly places the ship in the right slots and gives it the tag ship1(vertically placed)
                                    enemyAllVerticalTiles[enemyVertical][enemyVerticalSlot].Tag = Ship5;

                                    //enemyAllVerticalTiles[enemyVertical][enemyVerticalSlot].Text = Ship5;
                                    //enemyAllVerticalTiles[enemyVertical][enemyVerticalSlot].BackColor = Color.Gray;
                                    enemyVerticalSlot++;
                                }
                            }
                            else
                            {
                                for (int o = 0; o < enemyShipLength; o++)
                                {
                                    //Randomly places the ship in the right slots and gives it the tag ship1(horizontally placed)
                                    enemyAllHorizontalTiles[enemyHorizontal][enemyHorizontalSlot].Tag = Ship5;

                                    //enemyAllHorizontalTiles[enemyHorizontal][enemyHorizontalSlot].Text = Ship5;
                                    //enemyAllHorizontalTiles[enemyHorizontal][enemyHorizontalSlot].BackColor = Color.Gray;
                                    enemyHorizontalSlot++;
                                }
                            }
                            break;
                        }
                        break;
                        #endregion
                }

            }
        }

        /// <summary>
        /// enemy Ai shooting after each player turn
        /// </summary>
        private void EnnemyShooting()
        {
            #region Failed Ai
            //Random rnd = new Random();
            //bool TrueorFalse = true;
            //if (enemyHit == 0)
            //{
            //  RandomVertical = rnd.Next(0, 10);
            //  Randomhorizontal = rnd.Next(0, 7);
            //}
            //int numberRandomDirection = rnd.Next(0, 4);
            //string randomDirectionShot = "";
            //randomDirectionShot = afterEnemyHit[numberRandomDirection];

            //if (enemyHit != 0)
            //{
            //    TrueorFalse = false;
            //    switch (randomDirectionShot)
            //    {
            //        case "Up":
            //            if (TheBigList[0][enemyHorizontalShootingMemory - hitDirectionMultiplecounter][enemyVerticalShootingMemory].Tag != null)
            //            {
            //                TheBigList[0][enemyHorizontalShootingMemory - hitDirectionMultiplecounter][enemyVerticalShootingMemory].BackColor = Color.Red;
            //                hitDirectionMultiplecounter++;
            //                hitDirectioncounter = 1;
            //            }
            //            else
            //            {
            //                TheBigList[0][enemyHorizontalShootingMemory - hitDirectionMultiplecounter][enemyVerticalShootingMemory].BackColor = Color.White;
            //                notUp++;
            //            }
            //            break;
            //        case "Down":
            //            if (TheBigList[0][enemyHorizontalShootingMemory + hitDirectionMultiplecounter][enemyVerticalShootingMemory].Tag != null)
            //            {
            //                TheBigList[0][enemyHorizontalShootingMemory + hitDirectionMultiplecounter][enemyVerticalShootingMemory].BackColor = Color.Red;
            //                hitDirectionMultiplecounter++;
            //                hitDirectioncounter = 2;
            //            }
            //            else
            //            {
            //                TheBigList[0][enemyHorizontalShootingMemory + hitDirectionMultiplecounter][enemyVerticalShootingMemory].BackColor = Color.White;
            //                notDown++;
            //            }
            //            break;
            //        case "Left":
            //            if (TheBigList[0][enemyHorizontalShootingMemory][enemyVerticalShootingMemory + hitDirectionMultiplecounter].Tag != null)
            //            {
            //                TheBigList[0][enemyHorizontalShootingMemory][enemyVerticalShootingMemory + hitDirectionMultiplecounter].BackColor = Color.Red;
            //                hitDirectionMultiplecounter++;
            //                hitDirectioncounter = 3;
            //            }
            //            else
            //            {
            //                TheBigList[0][enemyHorizontalShootingMemory][enemyVerticalShootingMemory + hitDirectionMultiplecounter].BackColor = Color.White;
            //                notLeft++;
            //            }
            //            break;
            //        case "Right":
            //            if (TheBigList[0][enemyHorizontalShootingMemory][enemyVerticalShootingMemory - hitDirectionMultiplecounter].Tag != null)
            //            {
            //                TheBigList[0][enemyHorizontalShootingMemory][enemyVerticalShootingMemory - hitDirectionMultiplecounter].BackColor = Color.Red;
            //                hitDirectionMultiplecounter++;
            //                hitDirectioncounter = 4;
            //            }
            //            else
            //            {
            //                TheBigList[0][enemyHorizontalShootingMemory][enemyVerticalShootingMemory - hitDirectionMultiplecounter].BackColor = Color.White;
            //                notRight++;
            //            }
            //            break;
            //    }
            //}
            //while (TrueorFalse)
            //{
            //    if (TheBigList[0][Randomhorizontal][RandomVertical].Tag != null)
            //    {
            //        if (TheBigList[0][Randomhorizontal][RandomVertical].BackColor == Color.Red)
            //        {
            //            RandomVertical = rnd.Next(0, 10);
            //            Randomhorizontal = rnd.Next(0, 7);
            //            continue;
            //        }
            //        else
            //        {
            //            TheBigList[0][Randomhorizontal][RandomVertical].BackColor = Color.Red;
            //            enemyHit++;
            //        }
            //        break;
            //    }
            //    else
            //    {
            //        if(TheBigList[0][Randomhorizontal][RandomVertical].BackColor == Color.White)
            //        {
            //            RandomVertical = rnd.Next(0, 10);
            //            Randomhorizontal = rnd.Next(0, 7);
            //            continue;
            //        }
            //        else
            //        {
            //            TheBigList[0][Randomhorizontal][RandomVertical].BackColor = Color.White;
            //        }
            //        break;
            //    }

            //}

            //TrueorFalse = true;
            //enemyHorizontalShootingMemory = Randomhorizontal;
            //enemyVerticalShootingMemory = RandomVertical;
            #endregion

            #region AI Shooting
            //checks for if something was already hit or not
            //if yes then it shoots the the right of the inital hit, then the left, then up and down 
            //until it finds the direction the ship is going
            if (enemyHit != 0)
            {
                //checks the right tile of the initial hit
                if (enemyHit == 1)
                {
                    while (true)
                    {
                        //checks the right to see if its agaisnt the wall
                        if (RandomVertical + hitDistance <= 9)
                        {
                            //checks to see if the tile to the right is a ship or not
                            if (TheBigList[0][Randomhorizontal][RandomVertical + hitDistance].Tag != null)
                            {
                                if (TheBigList[0][Randomhorizontal][RandomVertical + hitDistance].BackColor == Color.Red)
                                {
                                    hitDistance++;
                                    continue;
                                }
                                else if (TheBigList[0][Randomhorizontal][RandomVertical + hitDistance].BackColor == Color.White)
                                {
                                    hitDistance = 1;
                                    break;
                                }
                                else if (TheBigList[0][Randomhorizontal][RandomVertical + hitDistance].BackColor == Color.Gray)
                                {
                                    friendlyShipTagCheckIfHit = TheBigList[0][Randomhorizontal][RandomVertical + hitDistance].Tag.ToString();
                                    TheBigList[0][Randomhorizontal][RandomVertical + hitDistance].BackColor = Color.Red;
                                    hitDistance++;
                                    break;
                                }
                            }
                            else
                            {
                                if (TheBigList[0][Randomhorizontal][RandomVertical + hitDistance].BackColor == Color.White)
                                {
                                    hitDistance = 1;
                                    enemyHit++;
                                }
                                else
                                {
                                    TheBigList[0][Randomhorizontal][RandomVertical + hitDistance].BackColor = Color.White;
                                    hitDistance = 1;
                                }

                                break;
                            }
                        }
                        else
                        {
                            hitDistance = 1;
                            enemyHit++;
                            break;
                        }
                    }
                   
                }
                //checks the left tile of the initial hit
                if (enemyHit == 2)
                {
                    while (true)
                    {
                        //checks the left to see if its agaisnt the wall
                        if (RandomVertical - hitDistance >= 0)
                        {
                            //checks to see if the tile to the right is a ship or not
                            if (TheBigList[0][Randomhorizontal][RandomVertical - hitDistance].Tag != null)
                            {
                                if (TheBigList[0][Randomhorizontal][RandomVertical - hitDistance].BackColor == Color.Red)
                                {

                                    //increases how far away from the initial hit you are
                                    hitDistance++;
                                    continue;
                                }
                                else if (TheBigList[0][Randomhorizontal][RandomVertical - hitDistance].BackColor == Color.White)
                                {
                                    hitDistance = 1;
                                    break;
                                }
                                else if (TheBigList[0][Randomhorizontal][RandomVertical - hitDistance].BackColor == Color.Gray)
                                {
                                    friendlyShipTagCheckIfHit = TheBigList[0][Randomhorizontal][RandomVertical - hitDistance].Tag.ToString();
                                    TheBigList[0][Randomhorizontal][RandomVertical - hitDistance].BackColor = Color.Red;
                                    hitDistance++;
                                    break;
                                }
                            }
                            else
                            {
                                if (TheBigList[0][Randomhorizontal][RandomVertical - hitDistance].BackColor == Color.White)
                                {
                                    hitDistance = 1;
                                    enemyHit++;
                                }
                                else
                                {
                                    TheBigList[0][Randomhorizontal][RandomVertical - hitDistance].BackColor = Color.White;
                                    hitDistance = 1;
                                }

                                break;
                            }
                        }
                        else
                        {
                            hitDistance = 1;
                            enemyHit++;
                            break;
                        }
                    }
                    
                }
                //checks above the initial hit tile
                if (enemyHit == 3)
                {
                    while (true)
                    {
                        //checks up to see if its agaisnt the wall
                        if (Randomhorizontal - hitDistance >= 0)
                        {
                            //checks to see if the tile to the right is a ship or not
                            if (TheBigList[0][Randomhorizontal - hitDistance][RandomVertical].Tag != null)
                            {
                                if (TheBigList[0][Randomhorizontal - hitDistance][RandomVertical].BackColor == Color.Red)
                                {

                                    //increases how far away from the initial hit you are
                                    hitDistance++;
                                    continue;
                                }
                                else if (TheBigList[0][Randomhorizontal - hitDistance][RandomVertical].BackColor == Color.White)
                                {
                                    hitDistance = 1;
                                    break;
                                }
                                else if (TheBigList[0][Randomhorizontal - hitDistance][RandomVertical].BackColor == Color.Gray)
                                {
                                    friendlyShipTagCheckIfHit = TheBigList[0][Randomhorizontal - hitDistance][RandomVertical].Tag.ToString();
                                    TheBigList[0][Randomhorizontal - hitDistance][RandomVertical].BackColor = Color.Red;
                                    hitDistance++;
                                    break;
                                }
                            }
                            else
                            {
                                if (TheBigList[0][Randomhorizontal - hitDistance][RandomVertical].BackColor == Color.White)
                                {
                                    hitDistance = 1;
                                    enemyHit++;
                                }
                                else
                                {
                                    TheBigList[0][Randomhorizontal - hitDistance][RandomVertical].BackColor = Color.White;
                                    hitDistance = 1;
                                }

                                break;
                            }
                        }
                        else
                        {
                            hitDistance = 1;
                            enemyHit++;
                            break;
                        }
                    }
                    
                }
                //checks below the initial hit tile
                if (enemyHit == 4)
                {
                    while (true)
                    {
                        //checks down to see if its agaisnt the wall
                        if (Randomhorizontal + hitDistance <= 6)
                        {
                            //checks to see if the tile to the right is a ship or not
                            if (TheBigList[0][Randomhorizontal + hitDistance][RandomVertical].Tag != null)
                            {
                                if (TheBigList[0][Randomhorizontal + hitDistance][RandomVertical].BackColor == Color.Red)
                                {
                                    //increases how far away from the initial hit you are
                                    hitDistance++;
                                    continue;
                                }
                                else if (TheBigList[0][Randomhorizontal + hitDistance][RandomVertical].BackColor == Color.White)
                                {
                                    hitDistance = 1;
                                    break;
                                }
                                else if (TheBigList[0][Randomhorizontal + hitDistance][RandomVertical].BackColor == Color.Gray)
                                {
                                    friendlyShipTagCheckIfHit = TheBigList[0][Randomhorizontal + hitDistance][RandomVertical].Tag.ToString();
                                    TheBigList[0][Randomhorizontal + hitDistance][RandomVertical].BackColor = Color.Red;
                                    hitDistance++;
                                    break;
                                }
                            }
                            else
                            {
                                if(TheBigList[0][Randomhorizontal + hitDistance][RandomVertical].BackColor == Color.White)
                                {
                                    hitDistance = 1;
                                    enemyHit++;
                                }
                                else
                                {
                                    TheBigList[0][Randomhorizontal + hitDistance][RandomVertical].BackColor = Color.White;
                                    hitDistance = 1;
                                }
                               
                                break;
                            }
                        }
                        else
                        {
                            hitDistance = 1;
                            enemyHit++;
                            break;
                        }
                    }
                    
                }
                //resets the tile 
                if(enemyHit == 5)
                {
                    enemyHit = 0;
                    hitDistance = 1;
                }
                if (hitDistance == 1)
                {
                    enemyHit++;
                }
               
            }
            #endregion

            #region Actual AI number 1

            if (enemyHit == 0)
            {
                Random rnd = new Random();
                RandomVertical = rnd.Next(0, 10);
                Randomhorizontal = rnd.Next(0, 7);
                int numberRandomDirection = rnd.Next(0, 4);
                string randomDirectionShot = "";

                randomDirectionShot = afterEnemyHit[numberRandomDirection];
                while (true)
                {
                    if (TheBigList[0][Randomhorizontal][RandomVertical].Tag != null)
                    {
                        if (TheBigList[0][Randomhorizontal][RandomVertical].BackColor == Color.Red)
                        {
                            RandomVertical = rnd.Next(0, 10);
                            Randomhorizontal = rnd.Next(0, 7);
                            continue;
                        }
                        else
                        {
                            TheBigList[0][Randomhorizontal][RandomVertical].BackColor = Color.Red;
                            friendlyShipTagCheckIfHit = TheBigList[0][Randomhorizontal][RandomVertical].Tag.ToString();
                            enemyHit++;
                            break;
                        }
                    }
                    else
                    {
                        if (TheBigList[0][Randomhorizontal][RandomVertical].BackColor == Color.White)
                        {
                            RandomVertical = rnd.Next(0, 10);
                            Randomhorizontal = rnd.Next(0, 7);
                            continue;
                        }
                        else
                        {
                            TheBigList[0][Randomhorizontal][RandomVertical].BackColor = Color.White;
                            break;
                        }
                    }
                }
            }

            EnemyShipHit();
            #endregion
        }

        /// <summary>
        /// checks to see if the friendly ship is sank or not
        /// </summary>
        private void EnemyShipHit()
        {
            switch (friendlyShipTagCheckIfHit)
            {
                case "Ship1":
                    enemyShip1Counter++;

                    if (enemyShip1Counter == 5)
                    {
                        MessageBox.Show("They sank your Aircraft Carrier");
                        hitDistance = 1;
                        enemyHit = 0;
                        winner++;
                    }
                    break;
                case "Ship2":
                    enemyShip2Counter++;

                    if (enemyShip2Counter == 4)
                    {
                        MessageBox.Show("They sank your Battleship");
                        hitDistance = 1;
                        enemyHit = 0;
                        winner++;
                    }
                    break;
                case "Ship3":
                    enemyShip3Counter++;

                    if (enemyShip3Counter == 3)
                    {
                        MessageBox.Show("They sank your Destroyer");
                        hitDistance = 1;
                        enemyHit = 0;
                        winner++;
                    }
                    break;
                case "Ship4":
                    enemyShip4Counter++;

                    if (enemyShip4Counter == 3)
                    {
                        MessageBox.Show("They sank your Submarine");
                        hitDistance = 1;
                        enemyHit = 0;
                        winner++;
                    }
                    break;
                case "Ship5":
                    enemyShip5Counter++;

                    if(enemyShip5Counter == 2)
                    {
                        MessageBox.Show("They sank your Frigate");
                        hitDistance = 1;
                        enemyHit = 0;
                        winner++;
                    }
                    break;
            }
            if (winner >= 5)
            {   
                MessageBox.Show("You lost");
                Environment.Exit(0);
            }
            friendlyShipTagCheckIfHit = "";
        }
        #endregion
    }
}
