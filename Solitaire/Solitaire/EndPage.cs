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

namespace Solitaire
{
    class EndPage
    {
        static SpriteBatch spriteBatch;
        GraphicsDevice device;
        static GraphicsDeviceManager graphics;

        private static int a, b, c, d, x;
        private static int F_score, F_time;

        static Texture2D finish, MainMenuE, NewGameE;
        static SpriteFont font;
        static bool wasFirstTime = false;

        public EndPage(ContentManager content)
        {
            spriteBatch = Game1.spriteBatch;
            device = Game1.device;
            graphics = Game1.graphics;

            finish = content.Load<Texture2D>("finish");
            font = content.Load<SpriteFont>("Font1");

            MainMenuE = content.Load<Texture2D>("mainMenu_END");
            NewGameE = content.Load<Texture2D>("New_Game_END");
        }


        public static void draw_EndPage()
        {
            if (Game1.is_End_Page == true)
            {
                draw_Cards_COPY();

                spriteBatch.Draw(startPage.black, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
                spriteBatch.Draw(finish, new Vector2(350, 200), null, Color.White, 0, new Vector2(350, 175), 1, SpriteEffects.None, 0);

                if (wasFirstTime == false) { whatToWrite(); wasFirstTime = true; }

                if (startPage.score == true) spriteBatch.DrawString(font, "Score:  " + F_score, new Vector2(270, 350), Color.White, 0, Vector2.Zero, 0.8f, SpriteEffects.None, 0);
                if (startPage.time == true) spriteBatch.DrawString(font, "time:  " + F_time, new Vector2(300, 400), Color.White, 0, Vector2.Zero, 0.8f, SpriteEffects.None, 0);

                #region main menu
                if ((Game1.mouseCurrentPos.X <= 341)
                                                && (Game1.mouseCurrentPos.X >= 224)
                                                && (Game1.mouseCurrentPos.Y <= 524)
                                                && (Game1.mouseCurrentPos.Y >= 506))
                {
                    spriteBatch.Draw(MainMenuE, new Vector2(270, 514), null, Color.White, 0, new Vector2(62, 12), 0.8f, SpriteEffects.None, 0);

                    if (Game1.mouseCurrentPos.LeftButton == ButtonState.Pressed)
                    {
                        Game1.is_End_Page = false;
                        Game1.is_Start_Page = true;
                    }
                }
                else spriteBatch.Draw(MainMenuE, new Vector2(270, 514), null, Color.White, 0, new Vector2(62, 12), 0.6f, SpriteEffects.None, 0); 
                #endregion

                #region new game
                if ((Game1.mouseCurrentPos.X <= 485)
                                                && (Game1.mouseCurrentPos.X >= 370)
                                                && (Game1.mouseCurrentPos.Y <= 530)
                                                && (Game1.mouseCurrentPos.Y >= 507))
                {
                    spriteBatch.Draw(NewGameE, new Vector2(420, 514), null, Color.White, 0, new Vector2(62, 12), 0.8f, SpriteEffects.None, 0);

                    if (Game1.mouseCurrentPos.LeftButton == ButtonState.Pressed)
                    {
                        Game1.is_End_Page = false;
                        Game1.restart_game();
                    }

                }
                else spriteBatch.Draw(NewGameE, new Vector2(420, 514), null, Color.White, 0, new Vector2(62, 12), 0.6f, SpriteEffects.None, 0);
                #endregion

                #region exit
                if ((Game1.mouseCurrentPos.X <= 372)
                                                && (Game1.mouseCurrentPos.X >= 334)
                                                && (Game1.mouseCurrentPos.Y <= 561)
                                                && (Game1.mouseCurrentPos.Y >= 543))
                {
                    spriteBatch.Draw(startPage.exit_Tex, new Vector2(350, 550), null, Color.White, 0, new Vector2(21, 13), 0.8f, SpriteEffects.None, 0);
                    if (Game1.mouseCurrentPos.LeftButton == ButtonState.Pressed)
                    {
                        startPage.isExit = true;
                    }
                }
                else spriteBatch.Draw(startPage.exit_Tex, new Vector2(350, 550), null, Color.White, 0, new Vector2(21, 13), 0.6f, SpriteEffects.None, 0);
                #endregion


                
            }
        }



        public static void check_if_game_ended()
        {
            if (Background.number_of_cards_in_card_slot1 == 13 && Background.number_of_cards_in_card_slot2 == 13 && Background.number_of_cards_in_card_slot3 == 13 && Background.number_of_cards_in_card_slot4 == 13)
            {
                Game1.is_End_Page = true;
            }
        }

        public static void draw_Cards_COPY()
        {
            spriteBatch.Draw(Textures.cardslot, Background.deckPos, Color.White);

            #region card slot2
            x = Background.number_of_cards_in_card_slot2;

            for (int i = 0; i < Background.number_of_cards_in_card_slot2; i++)
            {
                b = Actions.check_which_card_is_first(x, "card slot2", false);
                spriteBatch.Draw(CardsData.cardsData[b].cardTexture, Background.card_slot2, Color.White);
                x--;
            }
            #endregion

            #region card slot3
            x = Background.number_of_cards_in_card_slot3;

            for (int i = 0; i < Background.number_of_cards_in_card_slot3; i++)
            {
                c = Actions.check_which_card_is_first(x, "card slot3", false);
                spriteBatch.Draw(CardsData.cardsData[c].cardTexture, Background.card_slot3, Color.White);
                x--;
            }
            #endregion

            #region card slot4
            x = Background.number_of_cards_in_card_slot4;

            for (int i = 0; i < Background.number_of_cards_in_card_slot4; i++)
            {
                d = Actions.check_which_card_is_first(x, "card slot4", false);
                spriteBatch.Draw(CardsData.cardsData[d].cardTexture, Background.card_slot4, Color.White);
                x--;
            }
            #endregion

            #region card slot1
            x = Background.number_of_cards_in_card_slot1;

            for (int i = 0; i < Background.number_of_cards_in_card_slot1; i++)
            {
                a = Actions.check_which_card_is_first(x, "card slot1", false);
                spriteBatch.Draw(CardsData.cardsData[a].cardTexture, Background.card_slot1, Color.White);
                x--;
            }
            #endregion

        }

        public static void whatToWrite()
        {
            if (startPage.score == true)
                F_score = Game1.score;

            if (startPage.time == true)
                F_time = (int)Game1.sec;

            if (startPage.time == true && startPage.score == true && startPage.timeToScoreBOOL == true)
                F_score += 10000 - (F_time * 25);
        }
    }
}
