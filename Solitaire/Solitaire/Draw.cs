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
    class Draw
    {
        SpriteBatch spriteBatch;
        GraphicsDevice device;
        GraphicsDeviceManager graphics;
        Vector2 drawdeckcardpos;
        private int a, b, c, d, e, x, z, f;
        static int plus;
        public static int plus_1, plus_2, plus_3, plus_4, plus_5, plus_6, plus_7;


        public Draw()
        {
            spriteBatch = Game1.spriteBatch;
            device = Game1.device;
            graphics = Game1.graphics;
        }

        public void draw_all()
        {
            draw_deck_slot();
            draw_Deck();
            draw_Cards();
            

            //draw_left_deck();
            //draw_Card_Moving();

        }

        public void draw_deck_slot()
        {
            spriteBatch.Draw(Textures.cardslot, Background.deckPos, Color.White);
        }

        public void draw_Deck()
        {
            if (Background.number_of_cards_in_deck != 0)
            {
                for (float i = 0; i <= Background.number_of_cards_in_deck + 1; i++)
                {
                    drawdeckcardpos = new Vector2((-i), (i / 2));
                    spriteBatch.Draw(Textures.backside, Background.deckPos + drawdeckcardpos, Color.White);
                }
            }
        }

        public void draw_Cards()
        {
            #region left deck
            x = Background.number_of_cards_in_left_deck;

            if (Actions.cards_on_left_deck == true)
            {
                for (int i = 0; i < Background.number_of_cards_in_left_deck; i++)
                {
                    z = Actions.check_which_card_is_first(x, "left Deck", false);
                    spriteBatch.Draw(CardsData.cardsData[z].cardTexture, new Vector2(400, 0), Color.White);
                    x--;
                }
            }
            #endregion

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

            #region pile 1
            plus = 0;
            for (int i = 0; i < Background.numberOfDownCards_pile1; i++)
            {
                spriteBatch.Draw(Textures.backside, new Vector2(Background.pile1.X, (Background.pile1.Y + plus)), Color.White);
                plus = plus + 5;
            }

            x = Background.numberOfUpCards_pile1;

            for (int i = 0; i < Background.numberOfUpCards_pile1; i++)
            {
                e = Actions.check_which_card_is_first(x, "pile 1", true);

                spriteBatch.Draw(CardsData.cardsData[e].cardTexture, new Vector2(Background.pile1.X, (Background.pile1.Y + plus)), Color.White);

                x--;
                plus = plus + 23;
            }

            plus_1 = plus;
            #endregion

            #region pile 2
            plus = 0;
            for (int i = 0; i < Background.numberOfDownCards_pile2; i++)
            {
                spriteBatch.Draw(Textures.backside, new Vector2(Background.pile2.X, (Background.pile2.Y + plus)), Color.White);
                plus = plus + 5;
            }


            x = Background.numberOfUpCards_pile2;

            for (int i = 0; i < Background.numberOfUpCards_pile2; i++)
            {
                e = Actions.check_which_card_is_first(x, "pile 2", true);

                spriteBatch.Draw(CardsData.cardsData[e].cardTexture, new Vector2(Background.pile2.X, (Background.pile2.Y + plus)), Color.White);

                x--;
                plus = plus + 23;
            }
            plus_2 = plus;
            #endregion

            #region pile 3
            plus = 0;
            for (int i = 0; i < Background.numberOfDownCards_pile3; i++)
            {
                spriteBatch.Draw(Textures.backside, new Vector2(Background.pile3.X, (Background.pile3.Y + plus)), Color.White);
                plus = plus + 5;
            }


            x = Background.numberOfUpCards_pile3;

            for (int i = 0; i < Background.numberOfUpCards_pile3; i++)
            {
                e = Actions.check_which_card_is_first(x, "pile 3", true);

                spriteBatch.Draw(CardsData.cardsData[e].cardTexture, new Vector2(Background.pile3.X, (Background.pile3.Y + plus)), Color.White);

                x--;
                plus = plus + 23;
            }
            plus_3 = plus;
            #endregion

            #region pile 4
            plus = 0;
            for (int i = 0; i < Background.numberOfDownCards_pile4; i++)
            {
                spriteBatch.Draw(Textures.backside, new Vector2(Background.pile4.X, (Background.pile4.Y + plus)), Color.White);
                plus = plus + 5;
            }

            x = Background.numberOfUpCards_pile4;

            for (int i = 0; i < Background.numberOfUpCards_pile4; i++)
            {
                e = Actions.check_which_card_is_first(x, "pile 4", true);

                spriteBatch.Draw(CardsData.cardsData[e].cardTexture, new Vector2(Background.pile4.X, (Background.pile4.Y + plus)), Color.White);

                x--;
                plus = plus + 23;
            }
            plus_4 = plus;
            #endregion

            #region pile 5
            plus = 0;
            for (int i = 0; i < Background.numberOfDownCards_pile5; i++)
            {
                spriteBatch.Draw(Textures.backside, new Vector2(Background.pile5.X, (Background.pile5.Y + plus)), Color.White);
                plus = plus + 5;
            }

            x = Background.numberOfUpCards_pile5;

            for (int i = 0; i < Background.numberOfUpCards_pile5; i++)
            {
                e = Actions.check_which_card_is_first(x, "pile 5", true);

                spriteBatch.Draw(CardsData.cardsData[e].cardTexture, new Vector2(Background.pile5.X, (Background.pile5.Y + plus)), Color.White);

                x--;
                plus = plus + 23;
            }
            plus_5 = plus;
            #endregion

            #region pile 6
            plus = 0;
            for (int i = 0; i < Background.numberOfDownCards_pile6; i++)
            {
                spriteBatch.Draw(Textures.backside, new Vector2(Background.pile6.X, (Background.pile6.Y + plus)), Color.White);
                plus = plus + 5;
            }

            x = Background.numberOfUpCards_pile6;

            for (int i = 0; i < Background.numberOfUpCards_pile6; i++)
            {
                e = Actions.check_which_card_is_first(x, "pile 6", true);

                spriteBatch.Draw(CardsData.cardsData[e].cardTexture, new Vector2(Background.pile6.X, (Background.pile6.Y + plus)), Color.White);

                x--;
                plus = plus + 23;
            }
            plus_6 = plus;
            #endregion

            #region pile 7
            plus = 0;
            for (int i = 0; i < Background.numberOfDownCards_pile7; i++)
            {
                spriteBatch.Draw(Textures.backside, new Vector2(Background.pile7.X, (Background.pile7.Y + plus)), Color.White);
                plus = plus + 5;
            }

            x = Background.numberOfUpCards_pile7;

            for (int i = 0; i < Background.numberOfUpCards_pile7; i++)
            {
                e = Actions.check_which_card_is_first(x, "pile 7", true);

                spriteBatch.Draw(CardsData.cardsData[e].cardTexture, new Vector2(Background.pile7.X, (Background.pile7.Y + plus)), Color.White);

                x--;
                plus = plus + 23;
            }
            plus_7 = plus;
            #endregion

            //draw_neutral_zone();


            f = 0;
            #region Moving
            for (int y = 0; y < Actions.Multiple_Cards_Moving.Length; y++)
            {
                if (Actions.Multiple_Cards_Moving[y] != -10)
                {
                    f++;
                }
            }

            for (int i = 0; i < 52; i++)
            {
                if (CardsData.cardsData[i].cardPlace == "M Moving")
                {
                    if (CardsData.cardsData[i].cardPlaceInPile == f)
                    {
                        spriteBatch.Draw(CardsData.cardsData[i].cardTexture, CardsData.cardsData[i].cardPos, null, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, ((0.1f) * CardsData.cardsData[i].cardPlaceInPile));
                        f--;
                        i = 0;
                    }
                }
            }

            for (int i = 0; i < 52; i++)
            {
                if (CardsData.cardsData[i].cardPlace == "Moving")
                {
                    spriteBatch.Draw(CardsData.cardsData[i].cardTexture, CardsData.cardsData[i].cardPos, null, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);
                }
            }
            #endregion
        }

        public void draw_neutral_zone()
        {
            for (int i = 0; i < 52; i++)
            {
                if (CardsData.cardsData[i].cardPlace == "neutral zone")
                {
                    spriteBatch.Draw(CardsData.cardsData[i].cardTexture, CardsData.cardsData[i].cardPos, Color.White);
                }
            }
        }




        public void draw_left_deck()
        {
            for (int i = 0; i < 52; i++)
            {
                spriteBatch.Draw(CardsData.cardsData[i].cardTexture, CardsData.cardsData[i].cardPos, Color.White);
            }
        }

        public void draw_Card_Moving()
        {
            for (int i = 0; i < 52; i++)
            {
                if (CardsData.cardsData[i].cardPlace == "Moving")
                {
                    spriteBatch.Draw(CardsData.cardsData[i].cardTexture, new Vector2(Game1.mouseCurrentPos.X - 100, Game1.mouseCurrentPos.Y - 100), null, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);
                }

                if (CardsData.cardsData[i].cardPlace == "card slot1" && CardsData.cardsData[i].cardPlaceInPile == 1)
                {
                    spriteBatch.Draw(CardsData.cardsData[i].cardTexture, new Vector2(20 - 62, 34 - 35), Color.White);
                }

                if (CardsData.cardsData[i].cardPlace == "card slot2" && CardsData.cardsData[i].cardPlaceInPile == 1)
                {
                    spriteBatch.Draw(CardsData.cardsData[i].cardTexture, new Vector2(118 - 62, 34 - 35), Color.White);
                }

                if (CardsData.cardsData[i].cardPlace == "card slot3" && CardsData.cardsData[i].cardPlaceInPile == 1)
                {
                    spriteBatch.Draw(CardsData.cardsData[i].cardTexture, new Vector2(215 - 62, 34 - 35), Color.White);
                }

                if (CardsData.cardsData[i].cardPlace == "card slot4" && CardsData.cardsData[i].cardPlaceInPile == 1)
                {
                    spriteBatch.Draw(CardsData.cardsData[i].cardTexture, new Vector2(312 - 62, 34 - 35), Color.White);
                }
            }
        }
    }
}
