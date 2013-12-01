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
    public struct cards
    {
        public int cardNumber;
        public bool cardColor; //red=true, black=false
        public char cardSymbol;
        public Texture2D cardTexture;
        public bool isUp;
        public string cardPlace;
        public int cardPlaceInPile;
        public int forMoving;
        public int forMoving_numberOfCardsMoving;

        public Vector2 cardPos;
        public float cardLayer;
    }

    class CardsData
    {
        static Vector2 mousePos;
        static Vector2 cardslot1Pos;
        static Vector2 cardslot2Pos;
        static Vector2 cardslot3Pos;
        static Vector2 cardslot4Pos;

        static int a = 0;
        static int b = 0;

        static int c = 1;
        static int num;

        static bool some_name;

        public static cards[] cardsData;

        public CardsData()
        {
            setUpCards();
            setUpCardsInDeck();
            set_up_cards_in_piles();
        }

        public static void setUpCards()
        {
            cardsData = new cards[52];

            c = 1;
            for (int i = 0; i < 13; i++)
            {
                cardsData[i].cardNumber = (c);
                cardsData[i].cardColor = true;
                #region switch texture
                switch (i)
                {
                    case 0: cardsData[i].cardTexture = Solitaire.Textures.h1;
                        break;
                    case 1: cardsData[i].cardTexture = Solitaire.Textures.h2;
                        break;
                    case 2: cardsData[i].cardTexture = Solitaire.Textures.h3;
                        break;
                    case 3: cardsData[i].cardTexture = Solitaire.Textures.h4;
                        break;
                    case 4: cardsData[i].cardTexture = Solitaire.Textures.h5;
                        break;
                    case 5: cardsData[i].cardTexture = Solitaire.Textures.h6;
                        break;
                    case 6: cardsData[i].cardTexture = Solitaire.Textures.h7;
                        break;
                    case 7: cardsData[i].cardTexture = Solitaire.Textures.h8;
                        break;
                    case 8: cardsData[i].cardTexture = Solitaire.Textures.h9;
                        break;
                    case 9: cardsData[i].cardTexture = Solitaire.Textures.h10;
                        break;
                    case 10: cardsData[i].cardTexture = Solitaire.Textures.hJ;
                        break;
                    case 11: cardsData[i].cardTexture = Solitaire.Textures.hQ;
                        break;
                    case 12: cardsData[i].cardTexture = Solitaire.Textures.hK;
                        break;
                }
                #endregion
                cardsData[i].cardSymbol = 'h';
                cardsData[i].isUp = false;
                
                c++;
            }
            c = 1;
            for (int i = 13; i < 26; i++)
            {
                cardsData[i].cardNumber = (c);
                cardsData[i].cardColor = false;
                #region switch texture
                switch (i)
                {
                    case 13: cardsData[i].cardTexture = Solitaire.Textures.s1;
                        break;
                    case 14: cardsData[i].cardTexture = Solitaire.Textures.s2;
                        break;
                    case 15: cardsData[i].cardTexture = Solitaire.Textures.s3;
                        break;
                    case 16: cardsData[i].cardTexture = Solitaire.Textures.s4;
                        break;
                    case 17: cardsData[i].cardTexture = Solitaire.Textures.s5;
                        break;
                    case 18: cardsData[i].cardTexture = Solitaire.Textures.s6;
                        break;
                    case 19: cardsData[i].cardTexture = Solitaire.Textures.s7;
                        break;
                    case 20: cardsData[i].cardTexture = Solitaire.Textures.s8;
                        break;
                    case 21: cardsData[i].cardTexture = Solitaire.Textures.s9;
                        break;
                    case 22: cardsData[i].cardTexture = Solitaire.Textures.s10;
                        break;
                    case 23: cardsData[i].cardTexture = Solitaire.Textures.sJ;
                        break;
                    case 24: cardsData[i].cardTexture = Solitaire.Textures.sQ;
                        break;
                    case 25: cardsData[i].cardTexture = Solitaire.Textures.sK;
                        break;
                }
                #endregion
                cardsData[i].cardSymbol = 's';
                cardsData[i].isUp = false;

                c++;
            }
            c = 1;
            for (int i = 26; i < 39; i++)
            {
                cardsData[i].cardNumber = (c);
                cardsData[i].cardColor = false;
                #region switch texture
                switch (i)
                {
                    case 26: cardsData[i].cardTexture = Solitaire.Textures.c1;
                        break;
                    case 27: cardsData[i].cardTexture = Solitaire.Textures.c2;
                        break;
                    case 28: cardsData[i].cardTexture = Solitaire.Textures.c3;
                        break;
                    case 29: cardsData[i].cardTexture = Solitaire.Textures.c4;
                        break;
                    case 30: cardsData[i].cardTexture = Solitaire.Textures.c5;
                        break;
                    case 31: cardsData[i].cardTexture = Solitaire.Textures.c6;
                        break;
                    case 32: cardsData[i].cardTexture = Solitaire.Textures.c7;
                        break;
                    case 33: cardsData[i].cardTexture = Solitaire.Textures.c8;
                        break;
                    case 34: cardsData[i].cardTexture = Solitaire.Textures.c9;
                        break;
                    case 35: cardsData[i].cardTexture = Solitaire.Textures.c10;
                        break;
                    case 36: cardsData[i].cardTexture = Solitaire.Textures.cJ;
                        break;
                    case 37: cardsData[i].cardTexture = Solitaire.Textures.cQ;
                        break;
                    case 38: cardsData[i].cardTexture = Solitaire.Textures.cK;
                        break;
                }
                #endregion
                cardsData[i].cardSymbol = 'c';
                cardsData[i].isUp = false;

                c++;
            }
            c = 1;
            for (int i = 39; i < 52; i++)
            {
                cardsData[i].cardNumber = (c);
                cardsData[i].cardColor = true;
                #region switch texture
                switch (i)
                {
                    case 39: cardsData[i].cardTexture = Solitaire.Textures.d1;
                        break;
                    case 40: cardsData[i].cardTexture = Solitaire.Textures.d2;
                        break;
                    case 41: cardsData[i].cardTexture = Solitaire.Textures.d3;
                        break;
                    case 42: cardsData[i].cardTexture = Solitaire.Textures.d4;
                        break;
                    case 43: cardsData[i].cardTexture = Solitaire.Textures.d5;
                        break;
                    case 44: cardsData[i].cardTexture = Solitaire.Textures.d6;
                        break;
                    case 45: cardsData[i].cardTexture = Solitaire.Textures.d7;
                        break;
                    case 46: cardsData[i].cardTexture = Solitaire.Textures.d8;
                        break;
                    case 47: cardsData[i].cardTexture = Solitaire.Textures.d9;
                        break;
                    case 48: cardsData[i].cardTexture = Solitaire.Textures.d10;
                        break;
                    case 49: cardsData[i].cardTexture = Solitaire.Textures.dJ;
                        break;
                    case 50: cardsData[i].cardTexture = Solitaire.Textures.dQ;
                        break;
                    case 51: cardsData[i].cardTexture = Solitaire.Textures.dK;
                        break;
                }
                #endregion
                cardsData[i].cardSymbol = 'd';
                cardsData[i].isUp = false;

                c++;
            }
        }

        public static void setUpCardsInDeck()
        {
            Random cardsInDeck = new Random();
            int num, numX, numY;
            int TheNumberOfCardInPile = 1;
            bool sw = true;

            for (int i = 0; i < 24; i++)
            {
                numX = cardsInDeck.Next(52);
                numY = cardsInDeck.Next(52);

                switch (sw)
                {
                    case true: num = numX;
                        break;
                    case false: num = numY;
                        break;
                    default: num = numY; break;
                }


                if (cardsData[num].cardPlace != "Deck")
                {
                    cardsData[num].cardPlace = "Deck";
                    cardsData[num].cardPlaceInPile = TheNumberOfCardInPile;

                    TheNumberOfCardInPile++;
                }

                else
                {
                    i--;
                }
            }
        }

        public static void set_up_cards_in_piles()
        {
            Random card = new Random();
            int num;

            #region pile 7
            for (int i = 0; i < 7; i++)
            {
                num = card.Next(52);

                if (cardsData[num].cardPlace == null)
                {
                    cardsData[num].cardPlace = "pile 7";
                    cardsData[num].cardPlaceInPile = i + 1;
                    
                    if (i == 0)
                    {
                        cardsData[num].isUp = true;
                        Background.numberOfUpCards_pile7++;
                    }
                    else
                    {
                        cardsData[num].isUp = false;
                        Background.numberOfDownCards_pile7++;
                    }
                }
                else
                    i--;
            }
            #endregion

            #region pile 6
            for (int i = 0; i < 6; i++)
            {
                num = card.Next(52);

                if (cardsData[num].cardPlace == null)
                {
                    cardsData[num].cardPlace = "pile 6";
                    cardsData[num].cardPlaceInPile = i + 1;
                    
                    if (i == 0)
                    {
                        cardsData[num].isUp = true;
                        Background.numberOfUpCards_pile6++;
                    }
                    else
                    {
                        cardsData[num].isUp = false;
                        Background.numberOfDownCards_pile6++;
                    }
                }
                else
                    i--;
            }
            #endregion

            #region pile 5
            for (int i = 0; i < 5; i++)
            {
                num = card.Next(52);

                if (cardsData[num].cardPlace == null)
                {
                    cardsData[num].cardPlace = "pile 5";
                    cardsData[num].cardPlaceInPile = i + 1;
                    
                    if (i == 0)
                    {
                        cardsData[num].isUp = true;
                        Background.numberOfUpCards_pile5++;
                    }
                    else
                    {
                        cardsData[num].isUp = false;
                        Background.numberOfDownCards_pile5++;
                    }
                }
                else
                    i--;
            }
            #endregion

            #region pile 4
            for (int i = 0; i < 4; i++)
            {
                num = card.Next(52);

                if (cardsData[num].cardPlace == null)
                {
                    cardsData[num].cardPlace = "pile 4";
                    cardsData[num].cardPlaceInPile = i + 1;
                    
                    if (i == 0)
                    {
                        cardsData[num].isUp = true;
                        Background.numberOfUpCards_pile4++;
                    }
                    else
                    {
                        cardsData[num].isUp = false;
                        Background.numberOfDownCards_pile4++;
                    }
                }
                else
                    i--;
            }
            #endregion

            #region pile 3
            for (int i = 0; i < 3; i++)
            {
                num = card.Next(52);

                if (cardsData[num].cardPlace == null)
                {
                    cardsData[num].cardPlace = "pile 3";
                    cardsData[num].cardPlaceInPile = i + 1;
                    
                    if (i == 0)
                    {
                        cardsData[num].isUp = true;
                        Background.numberOfUpCards_pile3++;
                    }
                    else
                    {
                        cardsData[num].isUp = false;
                        Background.numberOfDownCards_pile3++;
                    }
                }
                else
                    i--;
            }
            #endregion

            #region pile 2
            for (int i = 0; i < 2; i++)
            {
                num = card.Next(52);

                if (cardsData[num].cardPlace == null)
                {
                    cardsData[num].cardPlace = "pile 2";
                    cardsData[num].cardPlaceInPile = i + 1;
                   
                    if (i == 0)
                    {
                        cardsData[num].isUp = true;
                        Background.numberOfUpCards_pile2++;
                    }
                    else
                    {
                        cardsData[num].isUp = false;
                        Background.numberOfDownCards_pile2++;
                    }
                }
                else
                    i--;
            }
            #endregion

            #region pile 1
            for (int i = 0; i < 1; i++)
            {
                num = card.Next(52);

                if (cardsData[num].cardPlace == null)
                {
                    cardsData[num].cardPlace = "pile 1";
                    cardsData[num].cardPlaceInPile = 1;
                    
                    if (i == 0)
                    {
                        cardsData[num].isUp = true;
                        Background.numberOfUpCards_pile1++;
                    }
                    else
                    {
                        cardsData[num].isUp = false;
                        Background.numberOfDownCards_pile1++;
                    }
                }
                else
                    i--;
            }
            #endregion




        }




        public static void updateCardPos()
        {
            cardslot1Pos = new Vector2(20 - 62, 34 - 35);
            cardslot2Pos = new Vector2(118 - 62, 34 - 35);
            cardslot3Pos = new Vector2(215 - 62, 34 - 35);
            cardslot4Pos = new Vector2(312 - 62, 34 - 35);

            for (int i = 0; i < 52; i++)
            {
                some_name = false;
                mousePos = new Vector2(Game1.mouseCurrentPos.X - 100, Game1.mouseCurrentPos.Y - 100);

                switch (cardsData[i].cardPlace)
                {
                    case "Deck": cardsData[i].cardPos = Background.deckPos; cardsData[i].cardLayer = 1;
                        break;
                    case "left Deck": cardsData[i].cardPos = Background.leftDeckPos; cardsData[i].cardLayer = 1;
                        break;
                    case "card slot1": cardsData[i].cardPos = cardslot1Pos; cardsData[i].cardLayer = 1;
                        break;
                    case "card slot2": cardsData[i].cardPos = cardslot2Pos; cardsData[i].cardLayer = 1;
                        break;
                    case "card slot3": cardsData[i].cardPos = cardslot3Pos; cardsData[i].cardLayer = 1;
                        break;
                    case "card slot4": cardsData[i].cardPos = cardslot4Pos; cardsData[i].cardLayer = 1;
                        break;
                }

                if (cardsData[i].cardPlace != "M Moving" && cardsData[i].cardPlace != "Moving")
                {
                    switch (cardsData[i].cardPlaceInPile)
                    {
                        case 1: cardsData[i].cardLayer = 0;
                            break;
                        default: cardsData[i].cardLayer = 1;
                            break;
                    } 
                }

                if (cardsData[i].cardPlace == "M Moving" && cardsData[i].forMoving_numberOfCardsMoving > 0)
                {
                    cardsData[i].cardPos = new Vector2(mousePos.X, (mousePos.Y + (cardsData[i].forMoving * 23)) );
                    //cardsData[i].cardLayer = ((0.1f) * cardsData[i].cardPlaceInPile);
                    some_name = true;
                }

                if (some_name == false && cardsData[i].cardPlace == "Moving")
                {
                    cardsData[i].cardPos = mousePos;
                    cardsData[i].cardLayer = 0;
                }


            }
        }

        public static void updatePiles()
        {
            #region pile 1
            a = 0; b = 0;
            for (int i = 0; i < 52; i++)
            {
                if (cardsData[i].cardPlace == "pile 1")
                {
                    if (cardsData[i].isUp == false)
                    {
                        a++;
                    }
                    else
                    {
                        b++;
                    }
                }
            }
            Background.numberOfDownCards_pile1 = a;
            Background.numberOfUpCards_pile1 = b;
            #endregion

            #region pile 2
            a = 0;
            b = 0;
            for (int i = 0; i < 52; i++)
            {
                if (cardsData[i].cardPlace == "pile 2")
                {
                    if (cardsData[i].isUp == false)
                    {
                        a++;
                    }
                    else
                    {
                        b++;
                    }
                }
            }
            Background.numberOfDownCards_pile2 = a;
            Background.numberOfUpCards_pile2 = b;
            #endregion

            #region pile 3
            a = 0;
            b = 0;
            for (int i = 0; i < 52; i++)
            {
                if (cardsData[i].cardPlace == "pile 3")
                {
                    if (cardsData[i].isUp == false)
                    {
                        a++;
                    }
                    else
                    {
                        b++;
                    }
                }
            }
            Background.numberOfDownCards_pile3 = a;
            Background.numberOfUpCards_pile3 = b;
            #endregion

            #region pile 4
            a = 0; b = 0;
            for (int i = 0; i < 52; i++)
            {
                if (cardsData[i].cardPlace == "pile 4")
                {
                    if (cardsData[i].isUp == false)
                    {
                        a++;
                    }
                    else
                    {
                        b++;
                    }
                }
            }
            Background.numberOfDownCards_pile4 = a;
            Background.numberOfUpCards_pile4 = b;
            #endregion

            #region pile 5
            a = 0; b = 0;
            for (int i = 0; i < 52; i++)
            {
                if (cardsData[i].cardPlace == "pile 5")
                {
                    if (cardsData[i].isUp == false)
                    {
                        a++;
                    }
                    else
                    {
                        b++;
                    }
                }
            }
            Background.numberOfDownCards_pile5 = a;
            Background.numberOfUpCards_pile5 = b;
            #endregion

            #region pile 6
            a = 0; b = 0;
            for (int i = 0; i < 52; i++)
            {
                if (cardsData[i].cardPlace == "pile 6")
                {
                    if (cardsData[i].isUp == false)
                    {
                        a++;
                    }
                    else
                    {
                        b++;
                    }
                }
            }
            Background.numberOfDownCards_pile6 = a;
            Background.numberOfUpCards_pile6 = b;
            #endregion

            #region pile 7
            a = 0; b = 0;
            for (int i = 0; i < 52; i++)
            {
                if (cardsData[i].cardPlace == "pile 7")
                {
                    if (cardsData[i].isUp == false)
                    {
                        a++;
                    }
                    else
                    {
                        b++;
                    }
                }
            }
            Background.numberOfDownCards_pile7 = a;
            Background.numberOfUpCards_pile7 = b;
            #endregion
        }

        public static void update_slot_symbols()
        {
            num = Actions.check_which_card_is_first(1, "card slot1", false);
            if (num != -10) Actions.slot1_S = cardsData[num].cardSymbol;

            num = Actions.check_which_card_is_first(1, "card slot2", false);
            if (num != -10) Actions.slot2_S = cardsData[num].cardSymbol;

            num = Actions.check_which_card_is_first(1, "card slot3", false);
            if (num != -10) Actions.slot3_S = cardsData[num].cardSymbol;

            num = Actions.check_which_card_is_first(1, "card slot4", false);
            if (num != -10) Actions.slot4_S = cardsData[num].cardSymbol;
        }

    }
}
