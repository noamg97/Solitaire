using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;


namespace Solitaire
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        public static GraphicsDevice device;

        public static MouseState mouseCurrentPos, mousePreviousPos;
        public static KeyboardState keybstate, prevKeybstate;

        Textures textures_Class;
        Background create_background_Class;
        CardsData cards_Data_Class;
        Draw draw_decks_Class;
        startPage startPage_class;
        midGame_menu midGameMenu_Class;
        EndPage endPage_Class;

        public static Stopwatch stopWatch;

        public static bool is_Start_Page = true;
        public static bool is_End_Page = false;

        public static int score = 0;
        static public double milisec, sec;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferHeight = 650;
            graphics.PreferredBackBufferWidth = 700;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            this.IsMouseVisible = true;


            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            device = graphics.GraphicsDevice;

            textures_Class = new Textures(Content);
            cards_Data_Class = new CardsData();
            create_background_Class = new Background();
            draw_decks_Class = new Draw();
            startPage_class = new startPage(Content);
            midGameMenu_Class = new midGame_menu(Content);
            endPage_Class = new EndPage(Content);

            stopWatch = new Stopwatch();
        }

        protected override void Update(GameTime gameTime)
        {
            mouseCurrentPos = Mouse.GetState();
            keybstate = Keyboard.GetState();

            milisec = Math.Round((float)stopWatch.ElapsedMilliseconds);
            
            sec = Math.Round((milisec / 1000));


            exit_game();

            

            #region start Page

            if (is_Start_Page == true && is_End_Page == false)
            {
                startPage.get_mousestate();

                Window.Title = "Solitaire by Noam Gal                                                                                      " + "X: " + mouseCurrentPos.X + " Y: " + mouseCurrentPos.Y;
            }

            #endregion

           

            #region Game
            if (is_Start_Page == false && is_End_Page == false)
            {
                if (midGame_menu.for_mid_menu == false)
                {
                    CardsData.updateCardPos();
                    Actions.click_on_deck();
                    Actions.turn_card();
                    CardsData.updatePiles();
                    Actions.drag_Card();
                    CardsData.updatePiles();
                    Actions.drag_multiple_cards();
                    CardsData.updatePiles();
                    Actions.realese_multiple_cards();
                    CardsData.updatePiles();
                    CardsData.update_slot_symbols();
                    Actions.right_click();
                    CardsData.updatePiles();
                }


                if (startPage.time == true && startPage.score == true)
                    Window.Title = "Solitaire by Noam Gal                   " + "time: " + /*stopWatch.Elapsed*/ sec + "        score: " + score + "                      X: " + mouseCurrentPos.X + " Y: " + mouseCurrentPos.Y + "       ";
                if (startPage.time == true && startPage.score == false)
                    Window.Title = "Solitaire by Noam Gal                   " + "time: " + /*stopWatch.Elapsed*/ sec + "                      X: " + mouseCurrentPos.X + " Y: " + mouseCurrentPos.Y + "       ";
                if (startPage.time == false && startPage.score == true)
                    Window.Title = "Solitaire by Noam Gal                   " + "        score: " + score + "                      X: " + mouseCurrentPos.X + " Y: " + mouseCurrentPos.Y + "       ";
                if (startPage.time == false && startPage.score == false)
                    Window.Title = "Solitaire by Noam Gal                   " + "                      X: " + mouseCurrentPos.X + " Y: " + mouseCurrentPos.Y + "       ";



                midGameMenu_Class.check_if_Esc();
                midGame_menu.get_mouse_state();
                EndPage.check_if_game_ended();
            }
            #endregion


            if (is_End_Page == true && is_Start_Page == false)
            {
                Window.Title = "Solitaire by Noam Gal                   " + "                      X: " + mouseCurrentPos.X + " Y: " + mouseCurrentPos.Y + "       ";
            }




            prevKeybstate = keybstate;
            mousePreviousPos = mouseCurrentPos;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();


          


            create_background_Class.drawBackground();


            if (is_Start_Page == true && is_End_Page == false)
            {
                startPage_class.draw_StartPage();
            }


           


            if (is_Start_Page == false && is_End_Page == false)
            {
                draw_decks_Class.draw_all();
                midGameMenu_Class.draw_midMenu();
                
            }




        



            if (is_Start_Page == false && is_End_Page == true)
            {
                EndPage.draw_EndPage();
            }


            spriteBatch.End();


            base.Draw(gameTime);
            
        }





        public void exit_game()
        {
            if (startPage.isExit == true) this.Exit();
        }

        public static void restart_game()
        {
            Background.number_of_cards_in_deck = 24;
            Background.number_of_cards_in_left_deck = 0;
            Background.number_of_cards_in_card_slot1 = 0;
            Background.number_of_cards_in_card_slot2 = 0;
            Background.number_of_cards_in_card_slot3 = 0;
            Background.number_of_cards_in_card_slot4 = 0;
            Background.numberOfUpCards_pile1 = 0;
            Background.numberOfUpCards_pile2 = 0;
            Background.numberOfUpCards_pile3 = 0;
            Background.numberOfUpCards_pile4 = 0;
            Background.numberOfUpCards_pile5 = 0;
            Background.numberOfUpCards_pile6 = 0;
            Background.numberOfUpCards_pile7 = 0;
            Background.numberOfDownCards_pile1 = 0;
            Background.numberOfDownCards_pile2 = 1;
            Background.numberOfDownCards_pile3 = 2;
            Background.numberOfDownCards_pile4 = 3;
            Background.numberOfDownCards_pile5 = 4;
            Background.numberOfDownCards_pile6 = 5;
            Background.numberOfDownCards_pile7 = 6;


            CardsData.setUpCards();
            CardsData.setUpCardsInDeck();
            CardsData.set_up_cards_in_piles();



            Actions.forupdate = true;
            Actions.forDeckReOrder = true;
            Actions.cards_on_left_deck = false;
            Actions.slot1_S = 'n'; Actions.slot2_S = 'n'; Actions.slot3_S = 'n'; Actions.slot4_S = 'n';




        }

    }
}
