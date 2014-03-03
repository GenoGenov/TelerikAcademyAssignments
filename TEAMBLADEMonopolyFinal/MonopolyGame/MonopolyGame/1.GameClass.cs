#region Using Statements

using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

#endregion

namespace MonopolyGame
{
    public class GameClass : Game
    {
        private static Dictionary<int, TileOwnNotifications> notifications = new Dictionary<int, TileOwnNotifications>();
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        
        private Texture2D mainBoard;
        private Rectangle mainBoardRect; //changed the name of the mainboard rectangle
        
        //RollButton stuff
        private Texture2D rollActive;
        private Texture2D rollClicked;
        private Texture2D rollHover;
        private static bool isRollActive = true;
        private static bool isRollClicked = false;
        private static bool isRollHover = false;
        // All will use the same Rectangle, so no reason for different Rectangles for each texture
        private Rectangle rollRect;
        
        //BuyButtonStuff
        private Texture2D buyActive;
        private Texture2D buyHover;
        private Texture2D buyClicked;
        private static bool isBuyActive = true;
        private static bool isBuyClicked = false;
        private static bool isBuyHover = false;
        private Rectangle buyRect;
        
        //DicePictureStuff
        private Texture2D dice1;
        private Texture2D dice2;
        private Texture2D dice3;
        private Texture2D dice4;
        private Texture2D dice5;
        private Texture2D dice6;
        private Rectangle dicePos1;
        private Rectangle dicePos2;
        
        //SpritefontLoaded
        private SpriteFont font;
        
        private Dies dies;
        private static int xIncrement = 57;
        private static int WINDOW_WIDTH = 700;
        private static int WINDOW_HEIGHT = 700;
        public static Rectangle bottom = new Rectangle(50, 610, WINDOW_WIDTH, WINDOW_HEIGHT - 610);
        public static Rectangle left = new Rectangle(0, 100, 100, WINDOW_HEIGHT - 100);
        public static Rectangle top = new Rectangle(0, 0, WINDOW_WIDTH - 60, 90);
        public static Rectangle right = new Rectangle(607, 93 + 2 * xIncrement, 93, xIncrement);
        private static Dictionary<int, Player> AllPlayers = new Dictionary<int, Player>();
        public static int Turn;
        public static int noTurn;
        private int endPos = 0;
        private static bool eventNotifier = false;
        private Texture2D t;
        private static int roll = 0;
        private static int rollDraw;
        private static bool flag2 = false;
        private static int jailCounter = 0;
        private static bool buyFlag = false;
        private static bool mouseOverBuy;
        
        //static Dictionary<int, Rectangle> notification = new Dictionary<int, Rectangle>();  // not needed for now
        
        private static string player1Money = "1500$";
        private static string player2Money = "1500$";
        private static string message = "";
        private static double last = 0;
        
        //prevButtonState saves the default left mouse button state - which is Released
        //so we can use that when we implement the logic for the mouse drag&drop of the pawn
        private static ButtonState prevButtonState = ButtonState.Released;
        
        private bool flag = false;
        
        public GameClass() : base()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.Components.Add(new GamerServicesComponent(this));
            
            //setting up the resolution
            this.graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            this.graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
        }
        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            //notification.Add()
            
            #region Notifications
            
            notifications.Add(1, new TileOwnNotifications(this.Content, "OwnerBlue.png", 607 - xIncrement, 607, false));
            notifications.Add(3, new TileOwnNotifications(this.Content, "OwnerBlue.png", 607 - 3 * xIncrement, 607, false));
            notifications.Add(5, new TileOwnNotifications(this.Content, "OwnerBlue.png", 607 - 5 * xIncrement, 607, false));
            notifications.Add(6, new TileOwnNotifications(this.Content, "OwnerBlue.png", 607 - 6 * xIncrement, 607, false));
            notifications.Add(8, new TileOwnNotifications(this.Content, "OwnerBlue.png", 607 - 8 * xIncrement, 607, false));
            notifications.Add(9, new TileOwnNotifications(this.Content, "OwnerBlue.png", 607 - 9 * xIncrement, 607, false));
            notifications.Add(11, new TileOwnNotifications(this.Content, "OwnerBlue.png", 0, 607 - xIncrement, false));
            notifications.Add(12, new TileOwnNotifications(this.Content, "OwnerBlue.png", 0, 607 - 2 * xIncrement, false));
            notifications.Add(13, new TileOwnNotifications(this.Content, "OwnerBlue.png", 0, 607 - 3 * xIncrement, false));
            notifications.Add(14, new TileOwnNotifications(this.Content, "OwnerBlue.png", 0, 607 - 4 * xIncrement, false));
            notifications.Add(15, new TileOwnNotifications(this.Content, "OwnerBlue.png", 0, 607 - 5 * xIncrement, false));
            notifications.Add(16, new TileOwnNotifications(this.Content, "OwnerBlue.png", 0, 607 - 6 * xIncrement, false));
            notifications.Add(18, new TileOwnNotifications(this.Content, "OwnerBlue.png", 0, 607 - 8 * xIncrement, false));
            notifications.Add(19, new TileOwnNotifications(this.Content, "OwnerBlue.png", 0, 607 - 9 * xIncrement, false));
            notifications.Add(21, new TileOwnNotifications(this.Content, "OwnerBlue.png", 93, 0, false));
            notifications.Add(23, new TileOwnNotifications(this.Content, "OwnerBlue.png", 93 + 2 * xIncrement, 0, false));
            notifications.Add(24, new TileOwnNotifications(this.Content, "OwnerBlue.png", 93 + 3 * xIncrement, 0, false));
            notifications.Add(25, new TileOwnNotifications(this.Content, "OwnerBlue.png", 93 + 4 * xIncrement, 0, false));
            notifications.Add(26, new TileOwnNotifications(this.Content, "OwnerBlue.png", 93 + 5 * xIncrement, 0, false));
            notifications.Add(27, new TileOwnNotifications(this.Content, "OwnerBlue.png", 93 + 6 * xIncrement, 0, false));
            notifications.Add(28, new TileOwnNotifications(this.Content, "OwnerBlue.png", 93 + 7 * xIncrement, 0, false));
            notifications.Add(29, new TileOwnNotifications(this.Content, "OwnerBlue.png", 93 + 8 * xIncrement, 0, false));
            notifications.Add(31, new TileOwnNotifications(this.Content, "OwnerBlue.png", 607, 93, false));
            notifications.Add(32, new TileOwnNotifications(this.Content, "OwnerBlue.png", 607, 93 + xIncrement, false));
            notifications.Add(34, new TileOwnNotifications(this.Content, "OwnerBlue.png", 607, 93 + 3 * xIncrement, false));
            notifications.Add(35, new TileOwnNotifications(this.Content, "OwnerBlue.png", 607, 93 + 4 * xIncrement, false));
            notifications.Add(37, new TileOwnNotifications(this.Content, "OwnerBlue.png", 607, 93 + 6 * xIncrement, false));
            notifications.Add(39, new TileOwnNotifications(this.Content, "OwnerBlue.png", 607, 93 + 8 * xIncrement, false));
            
            #endregion
            
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            //Create the mainboard Texture which we will use as the game background
            this.mainBoard = this.Content.Load<Texture2D>("FinalBoard.png");
            //Create the rectangle to hold the mainboard texture
            this.mainBoardRect = new Rectangle(0, 0, this.graphics.PreferredBackBufferWidth, this.graphics.PreferredBackBufferHeight);
            
            //Create the texture for the Roll Button
            this.rollActive = this.Content.Load<Texture2D>("Active.png");
            this.rollClicked = this.Content.Load<Texture2D>("Clicked.png");
            this.rollHover = this.Content.Load<Texture2D>("Hover.png");
            //Create the rectangle to hold the roll texture
            this.rollRect = new Rectangle(300, 450, 120, 120);
            
            //Rectangle for the blue owned notification
            
            //Create the texture for the Buy Button
            this.buyActive = this.Content.Load<Texture2D>("Buy");
            this.buyClicked = this.Content.Load<Texture2D>("BuyClicked");
            this.buyHover = this.Content.Load<Texture2D>("Hoverbuy");
            //create the rectangle to hold the buy texture
            
            this.buyRect = new Rectangle(450, 450, 80, 80);
            //DicePicture
            this.dice1 = this.Content.Load<Texture2D>("1");
            this.dice2 = this.Content.Load<Texture2D>("2");
            this.dice3 = this.Content.Load<Texture2D>("3");
            this.dice4 = this.Content.Load<Texture2D>("4");
            this.dice5 = this.Content.Load<Texture2D>("5");
            this.dice6 = this.Content.Load<Texture2D>("6");
            
            this.dicePos1 = new Rectangle(330, 560, 30, 30);
            this.dicePos2 = new Rectangle(362, 560, 30, 30);
            //makes the mouse cursor visible
            this.IsMouseVisible = true;
            
            Street.InitializeStreets(xIncrement, WINDOW_WIDTH, WINDOW_HEIGHT);
            Taxes.InitializeTaxes(xIncrement, WINDOW_WIDTH, WINDOW_HEIGHT);
            ChanceCards.InitializeChanceCards(xIncrement, WINDOW_WIDTH, WINDOW_HEIGHT);
            SimpleCards.InitializeSimpleCards(WINDOW_WIDTH, WINDOW_HEIGHT);
            //Load an instance of the Player's pawn

            this.dies = new Dies();
            
            AllPlayers.Add(1, new Player(this.Content, "pawn_blue.png", 620, 650, new Vector2(5, 5), 0, 1500, false));
            AllPlayers.Add(2, new Player(this.Content, "pawn_red.png", 620, 650, new Vector2(5, 5), 0, 1500, false));

            //notification.Add()
            
            Turn = 1;
            noTurn = 2;
            
            this.font = this.Content.Load<SpriteFont>("Arial");
            
            //testing 
            
            this.t = new Texture2D(this.GraphicsDevice, 1, 1);
            this.t.SetData(new[] { Color.White });
        }
        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        
        protected override void Update(GameTime gameTime)
        {
            //LOGIC STARTS HERE!
            if (roll == 0)
            {
                if (AllPlayers[Turn].money < 0)
                {
                    try
                    {
                        StreamWriter wrt = new StreamWriter("Winner.txt");
                        wrt.WriteLine("Player {0} is winner!", noTurn);
                        wrt.Close();
                    }
                    catch (UnauthorizedAccessException)
                    {
                    }
                    finally
                    {
                        this.Exit();
                    }
                }
                
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    this.Exit();
                }
                
                //Checks if the mouse is currently over the rectangle of the pawn
                bool mouseOver = AllPlayers[Turn].rect.Contains(Mouse.GetState().X, Mouse.GetState().Y);
                
                //Check if the mouse is currecntly over the roll button and draws the corresponding rollHover;
                bool mouseOverRoll = this.rollRect.Contains(Mouse.GetState().X, Mouse.GetState().Y);
                RollButtonLogic(mouseOverRoll);
                BuyButtonLogic(mouseOverBuy);
                
                //Sets the rectangle's position to follow the mouse until the left mouse button's state is "released"
                // if (Mouse.GetState().LeftButton == ButtonState.Pressed && prevButtonState == ButtonState.Released && mouseOver)
                
                //Checks if the roll button is pressed
                if (Mouse.GetState().LeftButton == ButtonState.Pressed && prevButtonState == ButtonState.Released && mouseOverRoll)
                {
                    roll = this.dies.Roll();
                    rollDraw = roll;
                    
                    this.endPos = AllPlayers[Turn].currPosition + roll;
                    if (this.endPos >= 40)
                    {
                        this.endPos -= 40;
                        flag2 = true;
                    }
                    buyFlag = false;
                    isBuyHover = false; //REMOVE HERE!
                    //   isBuyActive = true; //REMOVE HERE!
                }
                // enlarges the pawn's texture a bit when the mouse is hovering over it
                if (mouseOver && !this.flag)
                {
                    this.flag = true;
                    AllPlayers[Turn].rect.Width += 10;
                    AllPlayers[Turn].rect.Height += 10;
                }
                if (!mouseOver && this.flag)
                {
                    this.flag = false;
                    AllPlayers[Turn].rect.Width -= 10;
                    AllPlayers[Turn].rect.Height -= 10;
                }
            }
            if (roll != 0)
            {
                if (Street.AllStreets.ContainsKey(this.endPos))
                {
                    AllPlayers[Turn].Update(ref roll, Street.AllStreets[this.endPos].Rect, AllPlayers[Turn]);
                }
                else if (SimpleCards.AllSimpleCards.ContainsKey(this.endPos))
                {
                    AllPlayers[Turn].Update(ref roll, SimpleCards.AllSimpleCards[this.endPos].rect, AllPlayers[Turn]);
                }
                else if (Taxes.AllTaxes.ContainsKey(this.endPos))
                {
                    AllPlayers[Turn].Update(ref roll, Taxes.AllTaxes[this.endPos].Rect, AllPlayers[Turn]);
                }
                else if (ChanceCards.AllChanceCards.ContainsKey(this.endPos))
                {
                    AllPlayers[Turn].Update(ref roll, ChanceCards.AllChanceCards[this.endPos].Rect, AllPlayers[Turn]);
                }
                eventNotifier = true;
            }
            else if (buyFlag)
            {
                mouseOverBuy = this.buyRect.Contains(Mouse.GetState().X, Mouse.GetState().Y);
                if (Mouse.GetState().LeftButton == ButtonState.Pressed && prevButtonState == ButtonState.Released && mouseOverBuy && buyFlag)
                {
                    if (AllPlayers[noTurn].isInJail)
                    {
                        int currPosition = AllPlayers[Turn].currPosition;
                        Street.AllStreets[currPosition].BoughtBy = Turn;                  //The street becomes bought by the player
                        AllPlayers[Turn].money -= Street.AllStreets[currPosition].Cost;
                        notifications[currPosition].Active = true;
                        if (Turn != 1)
                        {
                            notifications[currPosition].SetSprite(this.Content, "OwnerRed.png");
                        }
                    }
                    else
                    {
                        int currPosition = AllPlayers[noTurn].currPosition;
                        Street.AllStreets[currPosition].BoughtBy = noTurn;                  //The street becomes bought by the player
                        AllPlayers[noTurn].money -= Street.AllStreets[currPosition].Cost;
                        notifications[currPosition].Active = true;
                        if (noTurn != 1)
                        {
                            notifications[currPosition].SetSprite(this.Content, "OwnerRed.png");
                        }
                    }
                    player1Money = string.Format("{0}$", AllPlayers[1].money.ToString());
                    player2Money = string.Format("{0}$", AllPlayers[2].money.ToString());                //remove money from the player
                    message = "Property bought!";
                    buyFlag = false;
                }
            }
            else if (eventNotifier)
            {
                AllPlayers[Turn].currPosition = this.endPos;
                CheckForCircle(ref flag2);
                buyFlag = CheckLandedOnStreet();
                CheckLandedOnTax();
                CheckLandedOnSimple();
                CheckLandedOnChance();
                
                eventNotifier = false;
                if (!AllPlayers[noTurn].isInJail || (AllPlayers[noTurn].isInJail && jailCounter == 2))
                {
                    int buffer = Turn;
                    Turn = noTurn;
                    noTurn = buffer;
                    jailCounter = 0;
                    AllPlayers[Turn].isInJail = false;
                }
                else
                {
                    jailCounter++;
                }
            }
            
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.CornflowerBlue);
            
            //begin the spritebatch transaction
            this.spriteBatch.Begin();
            
            //Draw the main board
            this.spriteBatch.Draw(this.mainBoard, this.mainBoardRect, Color.White);
            
            //Draw the pawn
            AllPlayers[1].Draw(this.spriteBatch);
            AllPlayers[2].Draw(this.spriteBatch);
            //Draw the roll button
            if (isRollActive)
            {
                this.spriteBatch.Draw(this.rollActive, this.rollRect, Color.White);
            }
            else if (isRollClicked)
            {
                this.spriteBatch.Draw(this.rollClicked, this.rollRect, Color.White);
            }
            else if (isRollHover)
            {
                this.spriteBatch.Draw(this.rollHover, this.rollRect, Color.White);
            }
            //Draw the buy button
            if (isBuyActive)
            {
                this.spriteBatch.Draw(this.buyActive, this.buyRect, Color.White);
            }
            else if (isBuyClicked)
            {
                this.spriteBatch.Draw(this.buyClicked, this.buyRect, Color.White);
            }
            else if (isBuyHover)
            {
                this.spriteBatch.Draw(this.buyHover, this.buyRect, Color.White);
            }
            
            this.spriteBatch.DrawString(this.font, player1Money, new Vector2(150, 525), Color.Blue);
            this.spriteBatch.DrawString(this.font, player2Money, new Vector2(150, 560), Color.Red);
            if (gameTime.TotalGameTime.TotalSeconds - last > 1)
            {
                if (Turn == 1)
                {
                    this.spriteBatch.DrawString(this.font, message, new Vector2(105, 105), Color.Red);
                }
                else
                {
                    this.spriteBatch.DrawString(this.font, message, new Vector2(105, 105), Color.Blue);
                }
                if (gameTime.TotalGameTime.TotalSeconds - last > 5)
                {
                    last = gameTime.TotalGameTime.TotalSeconds;
                    message = "";
                }
            }
            //spriteBatch.DrawString(font, rollDraw.ToString(), new Vector2(355, 560), Color.DarkGreen);
            switch (this.dies.result1)
            {
                case 1:
                    this.spriteBatch.Draw(this.dice1, this.dicePos1, Color.White);
                    break;
                case 2:
                    this.spriteBatch.Draw(this.dice2, this.dicePos1, Color.White);
                    break;
                case 3:
                    this.spriteBatch.Draw(this.dice3, this.dicePos1, Color.White);
                    break;
                case 4:
                    this.spriteBatch.Draw(this.dice4, this.dicePos1, Color.White);
                    break;
                case 5:
                    this.spriteBatch.Draw(this.dice5, this.dicePos1, Color.White);
                    break;
                case 6:
                    this.spriteBatch.Draw(this.dice6, this.dicePos1, Color.White);
                    break;
            }
            switch (this.dies.result2)
            {
                case 1:
                    this.spriteBatch.Draw(this.dice1, this.dicePos2, Color.White);
                    break;
                case 2:
                    this.spriteBatch.Draw(this.dice2, this.dicePos2, Color.White);
                    break;
                case 3:
                    this.spriteBatch.Draw(this.dice3, this.dicePos2, Color.White);
                    break;
                case 4:
                    this.spriteBatch.Draw(this.dice4, this.dicePos2, Color.White);
                    break;
                case 5:
                    this.spriteBatch.Draw(this.dice5, this.dicePos2, Color.White);
                    break;
                case 6:
                    this.spriteBatch.Draw(this.dice6, this.dicePos2, Color.White);
                    break;
            }
            
            //End spritebatch transaction
            foreach (var item in notifications)
            {
                item.Value.Draw(this.spriteBatch);
            }
            this.spriteBatch.End();
            base.Draw(gameTime);
        }
        
        public static void CheckLandedOnChance()
        {
            int currPosition = AllPlayers[Turn].currPosition;
            
            if (ChanceCards.AllChanceCards.ContainsKey(AllPlayers[Turn].currPosition))
            { // here we have different ChanceCards
                if (ChanceCards.AllChanceCards[currPosition].Number == 1)                       // first chance Card - Go To GO!
                {
                    AllPlayers[Turn].currPosition = 0;
                    currPosition = AllPlayers[Turn].currPosition;
                    AllPlayers[Turn].money += 200;
                    player1Money = string.Format("{0}$", AllPlayers[1].money.ToString());
                    player2Money = string.Format("{0}$", AllPlayers[2].money.ToString());
                    Rectangle rectangle = SimpleCards.AllSimpleCards[0].rect;
                    AllPlayers[Turn].rect.X = rectangle.X + rectangle.Width / 2 - AllPlayers[Turn].rect.Width / 2;
                    AllPlayers[Turn].rect.Y = rectangle.Y + rectangle.Height / 2 - AllPlayers[Turn].rect.Height / 2;
                    message = "Chance card - Go to \"Go\"";
                }
                else if (ChanceCards.AllChanceCards[currPosition].Number == 2)                 // Bank is giving you money
                {
                    AllPlayers[Turn].money += 100;
                    player1Money = string.Format("{0}$", AllPlayers[1].money.ToString());
                    player2Money = string.Format("{0}$", AllPlayers[2].money.ToString());
                    message = "You are a true ninja and the bank rewards you with 100$ !";
                }
                else if (ChanceCards.AllChanceCards[currPosition].Number == 3)                  // Give50ToTheOtherPlayer
                {
                    AllPlayers[Turn].money -= 50;
                    AllPlayers[noTurn].money += 50;
                    player1Money = string.Format("{0}$", AllPlayers[1].money.ToString());
                    player2Money = string.Format("{0}$", AllPlayers[2].money.ToString());
                    message = "Its the other player's birthday,you give him 50$";
                }
                else if (ChanceCards.AllChanceCards[currPosition].Number == 4)                 // Go Back 3 squares
                {
                    AllPlayers[Turn].currPosition -= 3;
                    currPosition = AllPlayers[Turn].currPosition;
                    if (CheckLandedOnStreet())
                    {
                        if (AllPlayers[Turn].currPosition < 0)
                        {
                            Rectangle rectangle = Street.AllStreets[39].Rect;
                            AllPlayers[Turn].rect.X = rectangle.X + rectangle.Width / 2 - AllPlayers[Turn].rect.Width / 2;
                            AllPlayers[Turn].rect.Y = rectangle.Y + rectangle.Height / 2 - AllPlayers[Turn].rect.Height / 2;
                        }
                        else
                        {
                            Rectangle rectangle = Street.AllStreets[currPosition].Rect;
                            AllPlayers[Turn].rect.X = rectangle.X + rectangle.Width / 2 - AllPlayers[Turn].rect.Width / 2;
                            AllPlayers[Turn].rect.Y = rectangle.Y + rectangle.Height / 2 - AllPlayers[Turn].rect.Height / 2;
                        }
                    }
                    if (CheckLandedOnSimple())
                    {
                        Rectangle rectangle = SimpleCards.AllSimpleCards[currPosition].rect;
                        AllPlayers[Turn].rect.X = rectangle.X + rectangle.Width / 2 - AllPlayers[Turn].rect.Width / 2;
                        AllPlayers[Turn].rect.Y = rectangle.Y + rectangle.Height / 2 - AllPlayers[Turn].rect.Height / 2;
                    }
                    if (CheckLandedOnTax())
                    {
                        Rectangle rectangle = Taxes.AllTaxes[currPosition].Rect;
                        AllPlayers[Turn].rect.X = rectangle.X + rectangle.Width / 2 - AllPlayers[Turn].rect.Width / 2;
                        AllPlayers[Turn].rect.Y = rectangle.Y + rectangle.Height / 2 - AllPlayers[Turn].rect.Height / 2;
                    }
                    CheckLandedOnChance();
                    message = "Go back 3 squares";
                }
                else if (ChanceCards.AllChanceCards[currPosition].Number == 5)              // GoToMayfair
                {
                    AllPlayers[Turn].currPosition = 39;
                    currPosition = AllPlayers[Turn].currPosition;
                    CheckLandedOnStreet();
                    Rectangle rectangle = Street.AllStreets[39].Rect;
                    AllPlayers[Turn].rect.X = rectangle.X + rectangle.Width / 2 - AllPlayers[Turn].rect.Width / 2;
                    AllPlayers[Turn].rect.Y = rectangle.Y + rectangle.Height / 2 - AllPlayers[Turn].rect.Height / 2;
                    message = "Go to MayFair";
                }
                else if (ChanceCards.AllChanceCards[currPosition].Number == 6)            //GoToTrafalgarSquare
                {
                    AllPlayers[Turn].currPosition = 24;
                    currPosition = AllPlayers[Turn].currPosition;
                    CheckLandedOnStreet();
                    Rectangle rectangle = Street.AllStreets[24].Rect;
                    AllPlayers[Turn].rect.X = rectangle.X + rectangle.Width / 2 - AllPlayers[Turn].rect.Width / 2;
                    AllPlayers[Turn].rect.Y = rectangle.Y + rectangle.Height / 2 - AllPlayers[Turn].rect.Height / 2;
                    message = "Go to TrafalgarSquare";
                }
            }
        }
        
        public static void CheckForCircle(ref bool flag)
        {
            if (flag)                                                           // if we have made a circle around the map
            {
                if (AllPlayers[Turn].currPosition >= 40)
                {
                    AllPlayers[Turn].currPosition -= 40;
                }// take to normal position
                AllPlayers[Turn].money += 200;
                player1Money = string.Format("{0}$", AllPlayers[1].money.ToString());
                player2Money = string.Format("{0}$", AllPlayers[2].money.ToString());// add 200 money.
                message = "Passed \"Go\",collect 200$";
            }
            flag = false;
        }
        
        public static bool CheckLandedOnStreet()
        {
            int currPosition = AllPlayers[Turn].currPosition;
            if (Street.AllStreets.ContainsKey(AllPlayers[Turn].currPosition))       //if the current position of the player is a street
            {
                if (Street.AllStreets[currPosition].BoughtBy == 0 && AllPlayers[Turn].money >= Street.AllStreets[currPosition].Cost)                  //if it is not bought by anyone and the player has money
                {
                    return true;
                }
                else if (Street.AllStreets[currPosition].BoughtBy == noTurn)          // if it is bought by the other player
                {
                    AllPlayers[Turn].money -= Street.AllStreets[currPosition].Rent;   // We subtract rent from current player
                    AllPlayers[noTurn].money += Street.AllStreets[currPosition].Rent;
                    player1Money = string.Format("{0}$", AllPlayers[1].money.ToString());
                    player2Money = string.Format("{0}$", AllPlayers[2].money.ToString());            // We add rent to the other player
                    message = string.Format("Tile owned by the other player! Pay rent - {0}$", Street.AllStreets[currPosition].Rent.ToString());
                }
            }
            return false;
        }
        
        public static bool CheckLandedOnTax()
        {
            int currPosition = AllPlayers[Turn].currPosition;
            if (Taxes.AllTaxes.ContainsKey(AllPlayers[Turn].currPosition))
            {
                AllPlayers[Turn].money += Taxes.AllTaxes[currPosition].Tax;         // if player falls on a tax, remove money (taxes have negative values)
                player1Money = string.Format("{0}$", AllPlayers[1].money.ToString());
                player2Money = string.Format("{0}$", AllPlayers[2].money.ToString());
                message = string.Format("The police caught you smoking weed! pay fine - {0}$", Taxes.AllTaxes[currPosition].Tax.ToString());
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public static bool CheckLandedOnSimple()
        {
            int currPosition = AllPlayers[Turn].currPosition;
            if (SimpleCards.AllSimpleCards.ContainsKey(AllPlayers[Turn].currPosition)) //if the current position of the player is on an angle
            {
                if (currPosition == 0)                                                 // If player is on GO nothing happens
                {
                }
                else if (currPosition == 10)                                           // if we are in "Jail" nothing happens
                {
                }
                else if (currPosition == 20)                                        // if we are in "Parking", nothing happens
                {
                }
                else if (currPosition == 30)                                        // if we are in "Go To Jail"
                {
                    AllPlayers[Turn].currPosition = 10;                           // we go to jail
                    currPosition = AllPlayers[Turn].currPosition;
                    Rectangle rectangle = SimpleCards.AllSimpleCards[10].rect;
                    AllPlayers[Turn].rect.X = rectangle.X + rectangle.Width / 2 - AllPlayers[Turn].rect.Width / 2;
                    AllPlayers[Turn].rect.Y = rectangle.Y + rectangle.Height / 2 - AllPlayers[Turn].rect.Height / 2;
                    AllPlayers[Turn].isInJail = true;
                    message = "Uh oh! Looks like someone's gonna get....\"loved\" in prison";
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public static void RollButtonLogic(bool mouseOverRoll)
        {
            if (mouseOverRoll)
            {
                isRollActive = false;
                isRollHover = true;
            }
            else
            {
                isRollActive = true;
                isRollHover = false;
            }
            //Checks if clicked but not released
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && mouseOverRoll)
            {
                isRollActive = false;
                isRollClicked = true;
            }
            else if (Mouse.GetState().LeftButton != ButtonState.Pressed && mouseOverRoll)
            {
                isRollHover = true;
                isRollActive = false;
                isRollClicked = false;
            }
        }
        
        public static void BuyButtonLogic(bool mouseOverRoll)
        {
            if (mouseOverRoll)
            {
                isBuyActive = false;
                isBuyHover = true;
            }
            else
            {
                isBuyActive = true;
                isBuyHover = false;
            }
            //Checks if clicked but not released
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && mouseOverBuy)
            {
                isBuyActive = false;
                isBuyClicked = true;
            }
            else if (Mouse.GetState().LeftButton != ButtonState.Pressed && mouseOverBuy)
            {
                isBuyHover = true;
                isBuyActive = false;
                isBuyClicked = false;
            }
        }
    }
}