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
    class Actions
    {

        public static int its_realy_annoying;


        public static bool forupdate = true;
        public static bool forDeckReOrder = true;
        public static bool cards_on_left_deck = false; // false == no cards
        public static int firstCardOnLeftDeck;


        public static char slot1_S = 'n'; public static char slot2_S = 'n'; public static char slot3_S = 'n'; public static char slot4_S = 'n';
        static Random rand = new Random();
        static int random;
        static bool slot1_B, slot2_B, slot3_B, slot4_B;
        static int num1, num2, num3, num4, num5, num6, num7, numLeftDeck;


        static bool color;
        static char symbol;
        static int number;
        static bool P_color;
        static char P_symbol;
        static int P_number;
        static int P_cardNum;

        
        static int moving_Card;
        static int num;
        static string moving_from;

        public static int n = 0;
        static int z, num_forDragM, l, p; // delete p somewhen
        public static int k = 1;
        static bool are_There_Multiple_Cards_Moving;
        public static int[] Multiple_Cards_Moving = new int[52];
        public static int b = 0;
        static int first_moving_card;

        #region bools
        static bool for_elseInCardRelease = false;
        static bool for_drag_card_Else_1;
        static bool for_drag_card_Else_2;
        static bool for_drag_card_Else_3;
        static bool for_drag_card_Else_4;
        static bool for_drag_card_Else_5;
        static bool for_drag_card_Else_6;
        static bool for_drag_card_Else_7;
        static bool for_drag_card_Else_8;
        static bool for_drag_card_Else_9;
        static bool for_drag_card_Else_10;
        static bool for_drag_card_Else_11;
        static bool for_drag_card_Else_12;

        static bool for_Turn_Card_2 = true;
        static bool for_Turn_Card_3 = true;
        static bool for_Turn_Card_4 = true;
        static bool for_Turn_Card_5 = true;
        static bool for_Turn_Card_6 = true;
        static bool for_Turn_Card_7 = true;

        //static bool cards_in_neutral_zone = false;
        #endregion


        public static void click_on_deck()
        {
            #region normal
            if (Background.number_of_cards_in_deck != 0)
            {
                if (Game1.mouseCurrentPos.LeftButton == ButtonState.Pressed && Game1.mousePreviousPos.LeftButton == ButtonState.Released)
                {
                    if ((Game1.mouseCurrentPos.X <= 672.0)
                            && (Game1.mouseCurrentPos.X >= 565.0)
                            && (Game1.mouseCurrentPos.Y <= 192.0)
                            && (Game1.mouseCurrentPos.Y >= 33.0))
                    {
                        if (forDeckReOrder == false)
                        {
                            int numOfCard = check_which_card_is_first(Background.number_of_cards_in_deck, "Deck", false);
                            redoCardsNumbersInPile(false, "left Deck", true);
                            CardsData.cardsData[numOfCard].cardPlace = "left Deck";
                            Background.number_of_cards_in_deck--;
                            CardsData.cardsData[numOfCard].cardPlaceInPile = 1;
                            CardsData.cardsData[numOfCard].isUp = true;

                            cards_on_left_deck = true;
                        }

                        if (forDeckReOrder == true)
                        {
                            int numOfCard = check_which_card_is_first(1, "Deck", false);
                            redoCardsNumbersInPile(false, "left Deck", true);
                            CardsData.cardsData[numOfCard].cardPlace = "left Deck";
                            Background.number_of_cards_in_deck--;
                            CardsData.cardsData[numOfCard].cardPlaceInPile = 1;
                            CardsData.cardsData[numOfCard].isUp = true;

                            cards_on_left_deck = true;

                            redoCardsNumbersInPile(false, "Deck", false); // maybe NEED TO WRITE THIS LINE IN THE OTHER 'IF'.
                        }

                        Background.number_of_cards_in_left_deck++;
                    }
                }
            }
            #endregion

            #region when no cards in deck
            if (Background.number_of_cards_in_deck == 0)
            {
                if (Game1.mouseCurrentPos.LeftButton == ButtonState.Pressed && Game1.mousePreviousPos.LeftButton == ButtonState.Released)
                {
                    if ((Game1.mouseCurrentPos.X <= 672.0)
                            && (Game1.mouseCurrentPos.X >= 565.0)
                            && (Game1.mouseCurrentPos.Y <= 192.0)
                            && (Game1.mouseCurrentPos.Y >= 33.0))
                    {
                        forupdate = !forupdate;


                        if (forupdate == true)
                        {
                            int x = 0;
                            for (int i = 0; i < 52; i++)
                            {
                                if (CardsData.cardsData[i].cardPlace == "left Deck")
                                {
                                    CardsData.cardsData[i].cardPlace = "Deck";
                                    x++;
                                    CardsData.cardsData[i].isUp = false;
                                }
                            }
                            Background.number_of_cards_in_deck = x;
                            Background.number_of_cards_in_left_deck = 0;
                            forDeckReOrder = false;
                            cards_on_left_deck = false;

                            Game1.score = Game1.score - 200;
                        }
                    }
                }
            }
            #endregion
        }

        public static void drag_Card()
        {
            if (are_There_Multiple_Cards_Moving == false)
            {
                #region press on card
                if (Game1.mouseCurrentPos.LeftButton == ButtonState.Pressed && Game1.mousePreviousPos.LeftButton == ButtonState.Released)
                {
                    #region left deck
                    if ((Game1.mouseCurrentPos.X <= 543)
                                    && (Game1.mouseCurrentPos.X >= 460)
                                    && (Game1.mouseCurrentPos.Y <= 180)
                                    && (Game1.mouseCurrentPos.Y >= 31))
                    {
                        firstCardOnLeftDeck = check_which_card_is_first(1, "left Deck", false);
                        if (firstCardOnLeftDeck != (-10))
                        {
                            CardsData.cardsData[firstCardOnLeftDeck].cardPlace = "Moving";
                            redoCardsNumbersInPile(false, "left Deck", false);
                            moving_Card = firstCardOnLeftDeck;
                            
                            moving_from = "left Deck";

                            Background.number_of_cards_in_left_deck--;
                        }
                    }
                    #endregion

                    //#region neutral zone
                    //if (cards_in_neutral_zone == true)
                    //{
                    //    for (int i = 0; i < 52; i++)
                    //    {
                    //        if (CardsData.cardsData[i].cardPlace == "neutral zone")
                    //        {
                    //            if ((Game1.mouseCurrentPos.X <= (CardsData.cardsData[i].cardPos.X + 60 + 84))
                    //                && (Game1.mouseCurrentPos.X >= (CardsData.cardsData[i].cardPos.X + 60))
                    //                && (Game1.mouseCurrentPos.Y <= (CardsData.cardsData[i].cardPos.Y + 35 + 146))
                    //                && (Game1.mouseCurrentPos.Y >= (CardsData.cardsData[i].cardPos.Y + 35)))
                    //            {
                    //                card_Prev_pos = CardsData.cardsData[i].cardPos;
                    //                CardsData.cardsData[i].cardPlace = "Moving";
                    //                moving_Card = i;
                    //                moving_from = "neutral zone";
                    //            }
                    //        }
                    //    }
                    //}
                    //#endregion

                    #region card slot1
                    if ((Game1.mouseCurrentPos.X <= 104)
                        && (Game1.mouseCurrentPos.X >= 20)
                        && (Game1.mouseCurrentPos.Y <= 180)
                        && (Game1.mouseCurrentPos.Y >= 34))
                    {
                        num = check_which_card_is_first(1, "card slot1", false);
                        if (num != (-10))
                        {
                            CardsData.cardsData[num].cardPlace = "Moving";
                            redoCardsNumbersInPile(false, "card slot1", false);
                            moving_Card = num;
                            if (Background.number_of_cards_in_card_slot1 != 0)
                                Background.number_of_cards_in_card_slot1--;
                            if (Background.number_of_cards_in_card_slot1 == 0)
                                slot1_S = 'n';
                            moving_from = "card slot1";
                        }
                    }
                    #endregion

                    #region card slot2
                    if ((Game1.mouseCurrentPos.X <= 200)
                        && (Game1.mouseCurrentPos.X >= 118)
                        && (Game1.mouseCurrentPos.Y <= 180)
                        && (Game1.mouseCurrentPos.Y >= 34))
                    {
                        num = check_which_card_is_first(1, "card slot2", false);
                        if (num != (-10))
                        {
                            CardsData.cardsData[num].cardPlace = "Moving";
                            redoCardsNumbersInPile(false, "card slot2", false);
                            moving_Card = num;
                            if (Background.number_of_cards_in_card_slot2 != 0)
                                Background.number_of_cards_in_card_slot2--;
                            if (Background.number_of_cards_in_card_slot2 == 0)
                                slot2_S = 'n';
                            moving_from = "card slot2";
                        }
                    }
                    #endregion

                    #region card slot3
                    if ((Game1.mouseCurrentPos.X <= 300)
                        && (Game1.mouseCurrentPos.X >= 215)
                        && (Game1.mouseCurrentPos.Y <= 180)
                        && (Game1.mouseCurrentPos.Y >= 34))
                    {
                        num = check_which_card_is_first(1, "card slot3", false);
                        if (num != (-10))
                        {
                            CardsData.cardsData[num].cardPlace = "Moving";
                            redoCardsNumbersInPile(false, "card slot3", false);
                            moving_Card = num;
                            if (Background.number_of_cards_in_card_slot3 != 0)
                                Background.number_of_cards_in_card_slot3--;
                            if (Background.number_of_cards_in_card_slot3 == 0)
                                slot3_S = 'n';
                            moving_from = "card slot3";
                        }
                    }
                    #endregion

                    #region card slot4
                    if ((Game1.mouseCurrentPos.X <= 395)
                        && (Game1.mouseCurrentPos.X >= 312)
                        && (Game1.mouseCurrentPos.Y <= 180)
                        && (Game1.mouseCurrentPos.Y >= 34))
                    {
                        num = check_which_card_is_first(1, "card slot4", false);
                        if (num != (-10))
                        {
                            CardsData.cardsData[num].cardPlace = "Moving";
                            redoCardsNumbersInPile(false, "card slot4", false);
                            moving_Card = num;
                            if (Background.number_of_cards_in_card_slot4 != 0)
                                Background.number_of_cards_in_card_slot4--;
                            if (Background.number_of_cards_in_card_slot4 == 0)
                                slot4_S = 'n';
                            moving_from = "card slot4";
                        }
                    }
                    #endregion

                    #region pile 1
                    if (Background.numberOfUpCards_pile1 != 0)
                    {
                        if ((Game1.mouseCurrentPos.X <= 104)
                                            && (Game1.mouseCurrentPos.X >= 20)
                                            && (Game1.mouseCurrentPos.Y <= (430 + Draw.plus_1) - 20)
                                            && (Game1.mouseCurrentPos.Y >= (284 + Draw.plus_1) - 20))
                        {
                            num = check_which_card_is_first(1, "pile 1", false);
                            if (num != (-10))
                            {
                                CardsData.cardsData[num].cardPlace = "Moving";
                                redoCardsNumbersInPile(false, "pile 1", false);
                                moving_Card = num;
                                if (Background.numberOfUpCards_pile1 != 0)
                                    Background.numberOfUpCards_pile1--;
                                moving_from = "pile 1";
                            }
                        }
                    }
                    #endregion

                    #region pile 2
                    if (Background.numberOfUpCards_pile2 != 0)
                    {
                        if ((Game1.mouseCurrentPos.X <= 200)
                                            && (Game1.mouseCurrentPos.X >= 117)
                                            && (Game1.mouseCurrentPos.Y <= (430 + Draw.plus_2) - 20)
                                            && (Game1.mouseCurrentPos.Y >= (284 + Draw.plus_2) - 20))
                        {
                            num = check_which_card_is_first(1, "pile 2", false);
                            if (num != (-10))
                            {
                                CardsData.cardsData[num].cardPlace = "Moving";
                                redoCardsNumbersInPile(false, "pile 2", false);
                                moving_Card = num;
                                if (Background.numberOfUpCards_pile2 != 0)
                                    Background.numberOfUpCards_pile2--;
                                moving_from = "pile 2";
                            }
                        }
                    }
                    #endregion

                    #region pile 3
                    if (Background.numberOfUpCards_pile3 != 0)
                    {
                        if ((Game1.mouseCurrentPos.X <= 299)
                                            && (Game1.mouseCurrentPos.X >= 215)
                                            && (Game1.mouseCurrentPos.Y <= (430 + Draw.plus_3) - 20)
                                            && (Game1.mouseCurrentPos.Y >= (284 + Draw.plus_3) - 20))
                        {
                            num = check_which_card_is_first(1, "pile 3", false);
                            if (num != (-10))
                            {
                                CardsData.cardsData[num].cardPlace = "Moving";
                                redoCardsNumbersInPile(false, "pile 3", false);
                                moving_Card = num;
                                if (Background.numberOfUpCards_pile3 != 0)
                                    Background.numberOfUpCards_pile3--;
                                moving_from = "pile 3";
                            }
                        }
                    }
                    #endregion

                    #region pile 4
                    if (Background.numberOfUpCards_pile4 != 0)
                    {
                        if ((Game1.mouseCurrentPos.X <= 396)
                                            && (Game1.mouseCurrentPos.X >= 311)
                                            && (Game1.mouseCurrentPos.Y <= (430 + Draw.plus_4) - 20)
                                            && (Game1.mouseCurrentPos.Y >= (284 + Draw.plus_4) - 20))
                        {
                            num = check_which_card_is_first(1, "pile 4", false);
                            if (num != (-10))
                            {
                                CardsData.cardsData[num].cardPlace = "Moving";
                                redoCardsNumbersInPile(false, "pile 4", false);
                                moving_Card = num;
                                if (Background.numberOfUpCards_pile4 != 0)
                                    Background.numberOfUpCards_pile4--;
                                moving_from = "pile 4";
                            }
                        }
                    }
                    #endregion

                    #region pile 5
                    if (Background.numberOfUpCards_pile5 != 0)
                    {
                        if ((Game1.mouseCurrentPos.X <= 492)
                                            && (Game1.mouseCurrentPos.X >= 407)
                                            && (Game1.mouseCurrentPos.Y <= (430 + Draw.plus_5) - 20)
                                            && (Game1.mouseCurrentPos.Y >= (284 + Draw.plus_5 - 20)))
                        {
                            num = check_which_card_is_first(1, "pile 5", false);
                            if (num != (-10))
                            {
                                CardsData.cardsData[num].cardPlace = "Moving";
                                redoCardsNumbersInPile(false, "pile 5", false);
                                moving_Card = num;
                                if (Background.numberOfUpCards_pile5 != 0)
                                    Background.numberOfUpCards_pile5--;
                                moving_from = "pile 5";
                            }
                        }
                    }
                    #endregion

                    #region pile 6
                    if (Background.numberOfUpCards_pile6 != 0)
                    {
                        if ((Game1.mouseCurrentPos.X <= 588)
                                            && (Game1.mouseCurrentPos.X >= 504)
                                            && (Game1.mouseCurrentPos.Y <= (430 + Draw.plus_6 - 20))
                                            && (Game1.mouseCurrentPos.Y >= (284 + Draw.plus_6 - 20)))
                        {
                            num = check_which_card_is_first(1, "pile 6", false);
                            if (num != (-10))
                            {
                                CardsData.cardsData[num].cardPlace = "Moving";
                                redoCardsNumbersInPile(false, "pile 6", false);
                                moving_Card = num;
                                if (Background.numberOfUpCards_pile6 != 0)
                                    Background.numberOfUpCards_pile6--;
                                moving_from = "pile 6";
                            }
                        }
                    }
                    #endregion

                    #region pile 7
                    if (Background.numberOfUpCards_pile7 != 0)
                    {
                        if ((Game1.mouseCurrentPos.X <= 686)
                                            && (Game1.mouseCurrentPos.X >= 601)
                                            && (Game1.mouseCurrentPos.Y <= (430 + Draw.plus_7 - 20))
                                            && (Game1.mouseCurrentPos.Y >= (284 + Draw.plus_7 - 20)))
                        {
                            num = check_which_card_is_first(1, "pile 7", false);
                            if (num != (-10))
                            {
                                CardsData.cardsData[num].cardPlace = "Moving";
                                redoCardsNumbersInPile(false, "pile 7", false);
                                moving_Card = num;
                                if (Background.numberOfUpCards_pile7 != 0)
                                    Background.numberOfUpCards_pile7--;
                                moving_from = "pile 7";
                            }
                        }
                    }
                    #endregion



                }
                #endregion


                #region release card

                if (moving_Card != -20)
                {
                    if (CardsData.cardsData[moving_Card].cardPlace == "Moving" &&
                                        Game1.mouseCurrentPos.LeftButton == ButtonState.Released && are_There_Multiple_Cards_Moving == false)
                    {
                        #region bools
                        for_drag_card_Else_1 = false;
                        for_drag_card_Else_2 = false;
                        for_drag_card_Else_3 = false;
                        for_drag_card_Else_4 = false;
                        for_drag_card_Else_5 = false;
                        for_drag_card_Else_6 = false;
                        for_drag_card_Else_7 = false;
                        for_drag_card_Else_8 = false;
                        for_drag_card_Else_9 = false;
                        for_drag_card_Else_10 = false;
                        for_drag_card_Else_11 = false;
                        for_drag_card_Else_12 = false;

                        for_elseInCardRelease = false;
                        #endregion




                        #region card slots
                        #region card slot 1
                        if ((Game1.mouseCurrentPos.X <= 104)
                            && (Game1.mouseCurrentPos.X >= 20)
                            && (Game1.mouseCurrentPos.Y <= 180)
                            && (Game1.mouseCurrentPos.Y >= 34))
                        {
                            if (check_if_card_fits(moving_Card, "card slot1", false) == true)
                            {
                                redoCardsNumbersInPile(false, "card slot1", true);
                                CardsData.cardsData[moving_Card].cardPlace = "card slot1";
                                CardsData.cardsData[moving_Card].cardPlaceInPile = 1;
                                Background.number_of_cards_in_card_slot1++;

                                slot1_S = CardsData.cardsData[moving_Card].cardSymbol;

                                for_drag_card_Else_1 = true;
                                for_elseInCardRelease = false;
                                moving_Card = -20;

                                if (moving_from != "card slot1") Game1.score = Game1.score + 20;
                            }
                        }
                        #endregion

                        #region card slot 2
                        if ((Game1.mouseCurrentPos.X <= 200)
                            && (Game1.mouseCurrentPos.X >= 118)
                            && (Game1.mouseCurrentPos.Y <= 180)
                            && (Game1.mouseCurrentPos.Y >= 34))
                        {
                            if (check_if_card_fits(moving_Card, "card slot2", false) == true)
                            {
                                redoCardsNumbersInPile(false, "card slot2", true);
                                CardsData.cardsData[moving_Card].cardPlace = "card slot2";
                                CardsData.cardsData[moving_Card].cardPlaceInPile = 1;
                                Background.number_of_cards_in_card_slot2++;
                                slot2_S = CardsData.cardsData[moving_Card].cardSymbol;

                                for_drag_card_Else_2 = true;
                                for_elseInCardRelease = false;
                                moving_Card = -20;

                                if (moving_from != "card slot2") Game1.score = Game1.score + 20;
                            }
                        }
                        #endregion

                        #region card slot 3
                        if ((Game1.mouseCurrentPos.X <= 300)
                            && (Game1.mouseCurrentPos.X >= 215)
                            && (Game1.mouseCurrentPos.Y <= 180)
                            && (Game1.mouseCurrentPos.Y >= 34))
                        {
                            if (check_if_card_fits(moving_Card, "card slot3", false) == true)
                            {
                                redoCardsNumbersInPile(false, "card slot3", true);
                                CardsData.cardsData[moving_Card].cardPlace = "card slot3";
                                CardsData.cardsData[moving_Card].cardPlaceInPile = 1;
                                Background.number_of_cards_in_card_slot3++;
                                slot3_S = CardsData.cardsData[moving_Card].cardSymbol;

                                for_drag_card_Else_3 = true;
                                for_elseInCardRelease = false;
                                moving_Card = -20;

                                if (moving_from != "card slot3") Game1.score = Game1.score + 20;
                            }
                        }
                        #endregion

                        #region card slot 4
                        if ((Game1.mouseCurrentPos.X <= 395)
                            && (Game1.mouseCurrentPos.X >= 312)
                            && (Game1.mouseCurrentPos.Y <= 180)
                            && (Game1.mouseCurrentPos.Y >= 34))
                        {
                            if (check_if_card_fits(moving_Card, "card slot4", false) == true)
                            {
                                redoCardsNumbersInPile(false, "card slot4", true);
                                CardsData.cardsData[moving_Card].cardPlace = "card slot4";
                                CardsData.cardsData[moving_Card].cardPlaceInPile = 1;
                                Background.number_of_cards_in_card_slot4++;
                                slot4_S = CardsData.cardsData[moving_Card].cardSymbol;

                                for_drag_card_Else_4 = true;
                                for_elseInCardRelease = false;
                                moving_Card = -20;

                                if (moving_from != "card slot4") Game1.score = Game1.score + 20;
                            }
                        }
                        #endregion
                        #endregion




                        #region piles
                        #region pile 1
                        if ((Game1.mouseCurrentPos.X <= 104)
                                                && (Game1.mouseCurrentPos.X >= 20)
                                                && (Game1.mouseCurrentPos.Y <= (430 + Draw.plus_1))
                                                && (Game1.mouseCurrentPos.Y >= (284 + Draw.plus_1)))
                        {
                            if (check_if_card_fits(moving_Card, "pile 1", true) == true)
                            {
                                redoCardsNumbersInPile(false, "pile 1", true);
                                CardsData.cardsData[moving_Card].cardPlace = "pile 1";
                                CardsData.cardsData[moving_Card].cardPlaceInPile = 1;
                                CardsData.cardsData[moving_Card].isUp = true;
                                Background.numberOfUpCards_pile1++;

                                for_drag_card_Else_5 = true;
                                for_elseInCardRelease = false;
                                moving_Card = -20;

                                if (moving_from != "pile 1") Game1.score += 10;
                            }
                        }
                        #endregion

                        #region pile 2
                        if ((Game1.mouseCurrentPos.X <= 200)
                                                && (Game1.mouseCurrentPos.X >= 117)
                                                && (Game1.mouseCurrentPos.Y <= (430 + Draw.plus_2))
                                                && (Game1.mouseCurrentPos.Y >= (284 + Draw.plus_2)))
                        {
                            if (check_if_card_fits(moving_Card, "pile 2", true) == true)
                            {
                                redoCardsNumbersInPile(false, "pile 2", true);
                                CardsData.cardsData[moving_Card].cardPlace = "pile 2";
                                CardsData.cardsData[moving_Card].cardPlaceInPile = 1;
                                CardsData.cardsData[moving_Card].isUp = true;
                                Background.numberOfUpCards_pile2++;

                                for_drag_card_Else_6 = true;
                                for_elseInCardRelease = false;
                                moving_Card = -20;

                                if (moving_from != "pile 2") Game1.score += 10;
                            }
                        }
                        #endregion

                        #region pile 3
                        if ((Game1.mouseCurrentPos.X <= 299)
                                                && (Game1.mouseCurrentPos.X >= 215)
                                                && (Game1.mouseCurrentPos.Y <= (430 + Draw.plus_3))
                                                && (Game1.mouseCurrentPos.Y >= (284 + Draw.plus_3)))
                        {
                            if (check_if_card_fits(moving_Card, "pile 3", true) == true)
                            {
                                redoCardsNumbersInPile(false, "pile 3", true);
                                CardsData.cardsData[moving_Card].cardPlace = "pile 3";
                                CardsData.cardsData[moving_Card].cardPlaceInPile = 1;
                                CardsData.cardsData[moving_Card].isUp = true;
                                Background.numberOfUpCards_pile3++;

                                for_drag_card_Else_7 = true;
                                for_elseInCardRelease = false;
                                moving_Card = -20;

                                if (moving_from != "pile 3") Game1.score += 10;
                            }
                        }
                        #endregion

                        #region pile 4
                        if ((Game1.mouseCurrentPos.X <= 396)
                                                && (Game1.mouseCurrentPos.X >= 311)
                                                && (Game1.mouseCurrentPos.Y <= (430 + Draw.plus_4))
                                                && (Game1.mouseCurrentPos.Y >= (284 + Draw.plus_4)))
                        {
                            if (check_if_card_fits(moving_Card, "pile 4", true) == true)
                            {
                                redoCardsNumbersInPile(false, "pile 4", true);
                                CardsData.cardsData[moving_Card].cardPlace = "pile 4";
                                CardsData.cardsData[moving_Card].cardPlaceInPile = 1;
                                CardsData.cardsData[moving_Card].isUp = true;
                                Background.numberOfUpCards_pile4++;

                                for_drag_card_Else_8 = true;
                                for_elseInCardRelease = false;
                                moving_Card = -20;

                                if (moving_from != "pile 4") Game1.score += 10;
                            }
                        }
                        #endregion

                        #region pile 5
                        if ((Game1.mouseCurrentPos.X <= 492)
                                                && (Game1.mouseCurrentPos.X >= 407)
                                                && (Game1.mouseCurrentPos.Y <= (430 + Draw.plus_5))
                                                && (Game1.mouseCurrentPos.Y >= (284 + Draw.plus_5)))
                        {
                            if (check_if_card_fits(moving_Card, "pile 5", true) == true)
                            {
                                redoCardsNumbersInPile(false, "pile 5", true);
                                CardsData.cardsData[moving_Card].cardPlace = "pile 5";
                                CardsData.cardsData[moving_Card].cardPlaceInPile = 1;
                                CardsData.cardsData[moving_Card].isUp = true;
                                Background.numberOfUpCards_pile5++;

                                for_drag_card_Else_9 = true;
                                for_elseInCardRelease = false;
                                moving_Card = -20;

                                if (moving_from != "pile 5") Game1.score += 10;
                            }
                        }
                        #endregion

                        #region pile 6
                        if ((Game1.mouseCurrentPos.X <= 588)
                                                && (Game1.mouseCurrentPos.X >= 504)
                                                && (Game1.mouseCurrentPos.Y <= (430 + Draw.plus_6))
                                                && (Game1.mouseCurrentPos.Y >= (284 + Draw.plus_6)))
                        {
                            if (check_if_card_fits(moving_Card, "pile 6", true) == true)
                            {
                                redoCardsNumbersInPile(false, "pile 6", true);
                                CardsData.cardsData[moving_Card].cardPlace = "pile 6";
                                CardsData.cardsData[moving_Card].cardPlaceInPile = 1;
                                CardsData.cardsData[moving_Card].isUp = true;
                                Background.numberOfUpCards_pile6++;

                                for_drag_card_Else_10 = true;
                                for_elseInCardRelease = false;
                                moving_Card = -20;

                                if (moving_from != "pile 6") Game1.score += 10;
                            }
                        }
                        #endregion

                        #region pile 7
                        if ((Game1.mouseCurrentPos.X <= 686)
                                                && (Game1.mouseCurrentPos.X >= 601)
                                                && (Game1.mouseCurrentPos.Y <= (430 + Draw.plus_7))
                                                && (Game1.mouseCurrentPos.Y >= (284 + Draw.plus_7)))
                        {
                            if (check_if_card_fits(moving_Card, "pile 7", true) == true)
                            {
                                redoCardsNumbersInPile(false, "pile 7", true);
                                CardsData.cardsData[moving_Card].cardPlace = "pile 7";
                                CardsData.cardsData[moving_Card].cardPlaceInPile = 1;
                                CardsData.cardsData[moving_Card].isUp = true;
                                Background.numberOfUpCards_pile7++;

                                for_drag_card_Else_11 = true;
                                for_elseInCardRelease = false;
                                moving_Card = -20;

                                if (moving_from != "pile 7") Game1.score += 10;
                            }
                        }
                        #endregion
                        #endregion




                        //#region neutral zone
                        //if ((Game1.mouseCurrentPos.X <= 900)
                        //                                && (Game1.mouseCurrentPos.X >= 735)
                        //                                && (Game1.mouseCurrentPos.Y <= 800)
                        //                                && (Game1.mouseCurrentPos.Y >= 0))
                        //{
                        //    CardsData.cardsData[moving_Card].cardPlace = "neutral zone";
                        //    for_elseInCardRelease = false;
                        //    for_drag_card_Else_12 = true;
                        //    CardsData.cardsData[moving_Card].cardPos = new Vector2(Game1.mouseCurrentPos.X - 100, Game1.mouseCurrentPos.Y - 100);
                        //    cards_in_neutral_zone = true;
                        //    moving_Card = -20;
                        //}
                        //#endregion




                        #region else
                        if (for_drag_card_Else_12 == false && for_drag_card_Else_1 == false && for_drag_card_Else_2 == false && for_drag_card_Else_3 == false && for_drag_card_Else_4 == false && for_drag_card_Else_5 == false && for_drag_card_Else_6 == false && for_drag_card_Else_7 == false && for_drag_card_Else_8 == false && for_drag_card_Else_9 == false && for_drag_card_Else_10 == false && for_drag_card_Else_11 == false)
                        {
                            if (for_elseInCardRelease == false)
                            {
                                if (moving_from != "neutral zone")
                                {
                                    redoCardsNumbersInPile(false, moving_from, true);
                                    CardsData.cardsData[moving_Card].cardPlaceInPile = 1;
                                    switch (moving_from)
                                    {
                                        case "left Deck": Background.number_of_cards_in_left_deck++; break;
                                        case "card slot1": Background.number_of_cards_in_card_slot1++; break;
                                        case "card slot2": Background.number_of_cards_in_card_slot2++; break;
                                        case "card slot3": Background.number_of_cards_in_card_slot3++; break;
                                        case "card slot4": Background.number_of_cards_in_card_slot4++; break;
                                    }
                                    CardsData.cardsData[moving_Card].cardPlace = moving_from;
                                }
                                if (moving_from == "neutral zone")
                                {
                                    CardsData.cardsData[moving_Card].cardPlace = moving_from;
                                }
                                for_elseInCardRelease = true;
                                moving_Card = -20;
                            }
                        }
                        #endregion
                    }
                }

                #endregion
            }
        }

        public static void turn_card()
        {
            if (check_if_card_moving() == false)
            {
                if (Game1.mouseCurrentPos.LeftButton == ButtonState.Pressed)
                {
                    #region pile 2
                    if ((Game1.mouseCurrentPos.X <= 200)
                                                && (Game1.mouseCurrentPos.X >= 117)
                                                && (Game1.mouseCurrentPos.Y <= (430 + Draw.plus_2))
                                                && (Game1.mouseCurrentPos.Y >= (284 + Draw.plus_2)))
                    {
                        if (Background.numberOfUpCards_pile2 == 0 && Background.numberOfDownCards_pile2 != 0)
                        {
                            for_Turn_Card_2 = !for_Turn_Card_2;

                            if (for_Turn_Card_2 == true)
                            {
                                num = check_which_card_is_first(1, "pile 2", false);
                                CardsData.cardsData[num].isUp = true;
                            }
                        }
                    }
                    #endregion

                    #region pile 3
                    if ((Game1.mouseCurrentPos.X <= 299)
                                                && (Game1.mouseCurrentPos.X >= 215)
                                                && (Game1.mouseCurrentPos.Y <= (430 + Draw.plus_3))
                                                && (Game1.mouseCurrentPos.Y >= (284 + Draw.plus_3)))
                    {
                        if (Background.numberOfUpCards_pile3 == 0 && Background.numberOfDownCards_pile3 != 0)
                        {
                            for_Turn_Card_3 = !for_Turn_Card_3;
                            if (for_Turn_Card_3 == true)
                            {
                                num = check_which_card_is_first(1, "pile 3", false);
                                CardsData.cardsData[num].isUp = true;
                            }
                        }
                    }
                    #endregion

                    #region pile 4
                    if ((Game1.mouseCurrentPos.X <= 396)
                                                && (Game1.mouseCurrentPos.X >= 311)
                                                && (Game1.mouseCurrentPos.Y <= (430 + Draw.plus_4))
                                                && (Game1.mouseCurrentPos.Y >= (284 + Draw.plus_4)))
                    {
                        if (Background.numberOfUpCards_pile4 == 0 && Background.numberOfDownCards_pile4 != 0)
                        {
                            for_Turn_Card_4 = !for_Turn_Card_4;
                            if (for_Turn_Card_4 == true)
                            {
                                num = check_which_card_is_first(1, "pile 4", false);
                                CardsData.cardsData[num].isUp = true;
                            }
                        }
                    }
                    #endregion

                    #region pile 5
                    if ((Game1.mouseCurrentPos.X <= 492)
                                                && (Game1.mouseCurrentPos.X >= 407)
                                                && (Game1.mouseCurrentPos.Y <= (430 + Draw.plus_5))
                                                && (Game1.mouseCurrentPos.Y >= (284 + Draw.plus_5)))
                    {
                        if (Background.numberOfUpCards_pile5 == 0 && Background.numberOfDownCards_pile5 != 0)
                        {
                            for_Turn_Card_5 = !for_Turn_Card_5;
                            if (for_Turn_Card_5 == true)
                            {
                                num = check_which_card_is_first(1, "pile 5", false);
                                CardsData.cardsData[num].isUp = true;
                            }
                        }
                    }
                    #endregion

                    #region pile 6
                    if ((Game1.mouseCurrentPos.X <= 588)
                                                && (Game1.mouseCurrentPos.X >= 504)
                                                && (Game1.mouseCurrentPos.Y <= (430 + Draw.plus_6))
                                                && (Game1.mouseCurrentPos.Y >= (284 + Draw.plus_6)))
                    {
                        if (Background.numberOfUpCards_pile6 == 0 && Background.numberOfDownCards_pile6 != 0)
                        {
                            for_Turn_Card_6 = !for_Turn_Card_6;
                            if (for_Turn_Card_6 == true)
                            {
                                num = check_which_card_is_first(1, "pile 6", false);
                                CardsData.cardsData[num].isUp = true;
                            }
                        }
                    }
                    #endregion

                    #region pile 7
                    if ((Game1.mouseCurrentPos.X <= 686)
                                                && (Game1.mouseCurrentPos.X >= 601)
                                                && (Game1.mouseCurrentPos.Y <= (430 + Draw.plus_7))
                                                && (Game1.mouseCurrentPos.Y >= (284 + Draw.plus_7)))
                    {
                        if (Background.numberOfUpCards_pile7 == 0 && Background.numberOfDownCards_pile7 != 0)
                        {
                            for_Turn_Card_7 = !for_Turn_Card_7;
                            if (for_Turn_Card_7 == true)
                            {
                                num = check_which_card_is_first(1, "pile 7", false);
                                CardsData.cardsData[num].isUp = true;
                            }
                        }
                    }
                    #endregion
                }
            }

        }

        public static void drag_multiple_cards()
        {
            if (are_There_Multiple_Cards_Moving == false && moving_Card == -20)
            {
                for (int i = 0; i < Multiple_Cards_Moving.Length; i++)
                {
                    Multiple_Cards_Moving[i] = -10;
                }

                #region pile 1
                n = 0; k = 0; l = 0;
                for (int i = Background.numberOfUpCards_pile1; i > 1; i--)
                {
                    if ((Game1.mouseCurrentPos.X <= 104)
                                                    && (Game1.mouseCurrentPos.X >= 20)
                                                    && (Game1.mouseCurrentPos.Y <= (284 + n + 23 + (Background.numberOfDownCards_pile1 * 5)))
                                                    && (Game1.mouseCurrentPos.Y >= (284 + n + (Background.numberOfDownCards_pile1 * 5)))
                                                    && (Game1.mouseCurrentPos.LeftButton == ButtonState.Pressed)
                                                    && (Game1.mousePreviousPos.LeftButton == ButtonState.Released))
                    {
                        l = i;
                        for (z = i; z > 0; z--)
                        {
                            num_forDragM = check_which_card_is_first(z, "pile 1", true);
                            CardsData.cardsData[num_forDragM].cardPlace = "M Moving";

                            CardsData.cardsData[num_forDragM].forMoving = k; // בשביל לדעת את מי לצייר הכי למעלה
                            CardsData.cardsData[num_forDragM].forMoving_numberOfCardsMoving = l;// בשביל לדעת מי שם

                            k++;
                            l--;
                            CardsData.cardsData[num_forDragM].cardPlaceInPile = z;

                            Multiple_Cards_Moving[z] = num_forDragM;
                            moving_from = "pile 1";

                            if (z == i) first_moving_card = num_forDragM;
                        }
                        for (int z = i; z > 0; z--)
                        {
                            redoCardsNumbersInPile(false, "pile 1", false);
                        }
                        are_There_Multiple_Cards_Moving = true;
                    }
                    if (i != 2)
                    {
                        n = n + 23;
                    }
                }
                #endregion

                #region pile 2
                n = 0; k = 0; l = 0;
                for (int i = Background.numberOfUpCards_pile2; i > 1; i--)
                {
                    if ((Game1.mouseCurrentPos.X <= 200)
                                            && (Game1.mouseCurrentPos.X >= 117)
                                            && (Game1.mouseCurrentPos.Y <= (284 + n + 23 + (Background.numberOfDownCards_pile2 * 5)))
                                            && (Game1.mouseCurrentPos.Y >= (284 + n + (Background.numberOfDownCards_pile2 * 5)))
                                            && (Game1.mouseCurrentPos.LeftButton == ButtonState.Pressed)
                                            && (Game1.mousePreviousPos.LeftButton == ButtonState.Released))
                    {
                        l = i;
                        for (z = i; z > 0; z--)
                        {
                            num_forDragM = check_which_card_is_first(z, "pile 2", true);
                            CardsData.cardsData[num_forDragM].cardPlace = "M Moving";
                            CardsData.cardsData[num_forDragM].forMoving = k; // בשביל לדעת את מי לצייר הכי למעלה
                            CardsData.cardsData[num_forDragM].forMoving_numberOfCardsMoving = l; // בשביל לדעת מי שם

                            k++;
                            l--;
                            CardsData.cardsData[num_forDragM].cardPlaceInPile = z;

                            Multiple_Cards_Moving[z] = num_forDragM;
                            moving_from = "pile 2";

                            if (z == i) first_moving_card = num_forDragM;
                        }
                        for (int z = i; z > 0; z--)
                        {
                            redoCardsNumbersInPile(false, "pile 2", false);
                        }
                        are_There_Multiple_Cards_Moving = true;
                    }
                    if (i != 2) n = n + 23;
                }
                #endregion

                #region pile 3
                n = 0; k = 0; l = 0;
                for (int i = Background.numberOfUpCards_pile3; i > 1; i--)
                {
                    if ((Game1.mouseCurrentPos.X <= 299)
                                                    && (Game1.mouseCurrentPos.X >= 212)
                                                    && (Game1.mouseCurrentPos.Y <= (284 + n + 23 + (Background.numberOfDownCards_pile3 * 5)))
                                                    && (Game1.mouseCurrentPos.Y >= (284 + n + (Background.numberOfDownCards_pile3 * 5)))
                                                    && (Game1.mouseCurrentPos.LeftButton == ButtonState.Pressed)
                                                    && (Game1.mousePreviousPos.LeftButton == ButtonState.Released))
                    {
                        l = i;
                        for (z = i; z > 0; z--)
                        {
                            num_forDragM = check_which_card_is_first(z, "pile 3", true);
                            CardsData.cardsData[num_forDragM].cardPlace = "M Moving";
                            CardsData.cardsData[num_forDragM].forMoving = k; // בשביל לדעת את מי לצייר הכי למעלה
                            CardsData.cardsData[num_forDragM].forMoving_numberOfCardsMoving = l; // בשביל לדעת מי שם

                            k++;
                            l--;
                            CardsData.cardsData[num_forDragM].cardPlaceInPile = z;

                            Multiple_Cards_Moving[z] = num_forDragM;
                            moving_from = "pile 3";

                            if (z == i) first_moving_card = num_forDragM;
                        }
                        for (int z = i; z > 0; z--)
                        {
                            redoCardsNumbersInPile(false, "pile 3", false);
                        }
                        are_There_Multiple_Cards_Moving = true;
                    }
                    if (i != 2) n = n + 23;
                }
                #endregion

                #region pile 4
                n = 0; k = 0; l = 0;
                for (int i = Background.numberOfUpCards_pile4; i > 1; i--)
                {
                    if ((Game1.mouseCurrentPos.X <= 396)
                                                     && (Game1.mouseCurrentPos.X >= 311)
                                                     && (Game1.mouseCurrentPos.Y <= (284 + n + 23 + (Background.numberOfDownCards_pile4 * 5)))
                                                     && (Game1.mouseCurrentPos.Y >= (284 + n + (Background.numberOfDownCards_pile4 * 5)))
                                                     && (Game1.mouseCurrentPos.LeftButton == ButtonState.Pressed)
                                                     && (Game1.mousePreviousPos.LeftButton == ButtonState.Released))
                    {
                        l = i;
                        for (z = i; z > 0; z--)
                        {
                            num_forDragM = check_which_card_is_first(z, "pile 4", true);
                            CardsData.cardsData[num_forDragM].cardPlace = "M Moving";
                            CardsData.cardsData[num_forDragM].forMoving = k; // בשביל לדעת את מי לצייר הכי למעלה
                            CardsData.cardsData[num_forDragM].forMoving_numberOfCardsMoving = l; // בשביל לדעת מי שם

                            k++;
                            l--;
                            CardsData.cardsData[num_forDragM].cardPlaceInPile = z;

                            Multiple_Cards_Moving[z] = num_forDragM;
                            moving_from = "pile 4";

                            if (z == i) first_moving_card = num_forDragM;
                        }
                        for (int z = i; z > 0; z--)
                        {
                            redoCardsNumbersInPile(false, "pile 4", false);
                        }

                        are_There_Multiple_Cards_Moving = true;
                    }
                    if (i != 2) n = n + 23;
                }
                #endregion

                #region pile 5
                n = 0; k = 0; l = 0;
                for (int i = Background.numberOfUpCards_pile5; i > 1; i--)
                {
                    if ((Game1.mouseCurrentPos.X <= 492)
                                                    && (Game1.mouseCurrentPos.X >= 407)
                                                    && (Game1.mouseCurrentPos.Y <= (284 + n + 23 + (Background.numberOfDownCards_pile5 * 5)))
                                                    && (Game1.mouseCurrentPos.Y >= (284 + n + (Background.numberOfDownCards_pile5 * 5)))
                                                    && (Game1.mouseCurrentPos.LeftButton == ButtonState.Pressed)
                                                    && (Game1.mousePreviousPos.LeftButton == ButtonState.Released))
                    {
                        l = i;
                        for (z = i; z > 0; z--)
                        {
                            num_forDragM = check_which_card_is_first(z, "pile 5", true);
                            CardsData.cardsData[num_forDragM].cardPlace = "M Moving";
                            CardsData.cardsData[num_forDragM].forMoving = k; // בשביל לדעת את מי לצייר הכי למעלה
                            CardsData.cardsData[num_forDragM].forMoving_numberOfCardsMoving = l; // בשביל לדעת מי שם

                            k++;
                            l--;
                            CardsData.cardsData[num_forDragM].cardPlaceInPile = z;

                            Multiple_Cards_Moving[z] = num_forDragM;
                            moving_from = "pile 5";

                            if (z == i) first_moving_card = num_forDragM;
                        }

                        for (int z = i; z > 0; z--)
                        {
                            redoCardsNumbersInPile(false, "pile 5", false);
                        }

                        are_There_Multiple_Cards_Moving = true;
                    }
                    if (i != 2) n = n + 23;
                }
                #endregion

                #region pile 6
                n = 0; k = 0; l = 0;
                for (int i = Background.numberOfUpCards_pile6; i > 1; i--)
                {
                    if ((Game1.mouseCurrentPos.X <= 588)
                                                    && (Game1.mouseCurrentPos.X >= 504)
                                                    && (Game1.mouseCurrentPos.Y <= (284 + n + 23 + (Background.numberOfDownCards_pile6 * 5)))
                                                    && (Game1.mouseCurrentPos.Y >= (284 + n + (Background.numberOfDownCards_pile6 * 5)))
                                                    && (Game1.mouseCurrentPos.LeftButton == ButtonState.Pressed)
                                                    && (Game1.mousePreviousPos.LeftButton == ButtonState.Released))
                    {
                        l = i;
                        for (z = i; z > 0; z--)
                        {
                            num_forDragM = check_which_card_is_first(z, "pile 6", true);
                            CardsData.cardsData[num_forDragM].cardPlace = "M Moving";
                            CardsData.cardsData[num_forDragM].forMoving = k; // בשביל לדעת את מי לצייר הכי למעלה
                            CardsData.cardsData[num_forDragM].forMoving_numberOfCardsMoving = l; // בשביל לדעת מי שם

                            k++;
                            l--;
                            CardsData.cardsData[num_forDragM].cardPlaceInPile = z;

                            Multiple_Cards_Moving[z] = num_forDragM;
                            moving_from = "pile 6";
                            if (z == i) first_moving_card = num_forDragM;
                        }

                        for (int z = i; z > 0; z--)
                        {
                            redoCardsNumbersInPile(false, "pile 6", false);
                        }

                        are_There_Multiple_Cards_Moving = true;
                    }
                    if (i != 2) n = n + 23;
                }
                #endregion

                #region pile 7
                n = 0; k = 0; l = 0;
                for (int i = Background.numberOfUpCards_pile7; i > 1; i--)
                {
                    if ((Game1.mouseCurrentPos.X <= 686)
                                                    && (Game1.mouseCurrentPos.X >= 601)
                                                    && (Game1.mouseCurrentPos.Y <= (284 + n + 23 + (Background.numberOfDownCards_pile7 * 5)))
                                                    && (Game1.mouseCurrentPos.Y >= (284 + n + (Background.numberOfDownCards_pile7 * 5)))
                                                    && (Game1.mouseCurrentPos.LeftButton == ButtonState.Pressed)
                                                    && (Game1.mousePreviousPos.LeftButton == ButtonState.Released))
                    {
                        l = i;
                        for (z = i; z > 0; z--)
                        {
                            num_forDragM = check_which_card_is_first(z, "pile 7", true);
                            CardsData.cardsData[num_forDragM].cardPlace = "M Moving";
                            CardsData.cardsData[num_forDragM].forMoving = k; // בשביל לדעת את מי לצייר הכי למעלה
                            CardsData.cardsData[num_forDragM].forMoving_numberOfCardsMoving = l; // בשביל לדעת מי שם

                            k++;
                            l--;
                            CardsData.cardsData[num_forDragM].cardPlaceInPile = z;

                            Multiple_Cards_Moving[z] = num_forDragM;
                            moving_from = "pile 7";
                            if (z == i) first_moving_card = num_forDragM;
                        }
                        for (int z = i; z > 0; z--)
                        {
                            redoCardsNumbersInPile(false, "pile 7", false);
                        }

                        are_There_Multiple_Cards_Moving = true;
                    }
                    if (i != 2) n = n + 23;
                }
                #endregion
            }

        }

        public static void realese_multiple_cards()
        {
            if (Game1.mouseCurrentPos.LeftButton == ButtonState.Released && are_There_Multiple_Cards_Moving == true)
            {
                #region bools
                for_drag_card_Else_1 = false;
                for_drag_card_Else_2 = false;
                for_drag_card_Else_3 = false;
                for_drag_card_Else_4 = false;
                for_drag_card_Else_5 = false;
                for_drag_card_Else_6 = false;
                for_drag_card_Else_7 = false;

                for_elseInCardRelease = false;
                #endregion
                b = 0;

                for (int i = 0; i < Multiple_Cards_Moving.Length; i++)
                {
                    if (Multiple_Cards_Moving[i] != -10)
                    {
                        b++;
                    }
                }


                #region piles

                #region pile 1
                p = 0;
                if ((Game1.mouseCurrentPos.X <= 104)
                                        && (Game1.mouseCurrentPos.X >= 20)
                                        && (Game1.mouseCurrentPos.Y <= (430 + Draw.plus_1))
                                        && (Game1.mouseCurrentPos.Y >= (284 + Draw.plus_1)))
                {
                    if (check_if_card_fits(first_moving_card, "pile 1", true) == true)
                    {
                        for (int i = 0; i < b; i++)
                        {
                            redoCardsNumbersInPile(false, "pile 1", true);
                        }
                        for (int v = 1; v < Multiple_Cards_Moving.Length; v++)
                        {
                            if (Multiple_Cards_Moving[v] != -10)
                            {
                                CardsData.cardsData[Multiple_Cards_Moving[v]].cardPlace = "pile 1";
                                CardsData.cardsData[Multiple_Cards_Moving[v]].cardPlaceInPile = v;
                                CardsData.cardsData[Multiple_Cards_Moving[v]].isUp = true;


                                if(moving_from != "pile 1") Game1.score += 10;
                                p++;
                            }
                        }
                        for_drag_card_Else_1 = true;
                        for_elseInCardRelease = false;
                        are_There_Multiple_Cards_Moving = false;
                    }
                }
                #endregion

                #region pile 2
                p = 0;
                if ((Game1.mouseCurrentPos.X <= 200)
                                        && (Game1.mouseCurrentPos.X >= 117)
                                        && (Game1.mouseCurrentPos.Y <= (430 + Draw.plus_2))
                                        && (Game1.mouseCurrentPos.Y >= (284 + Draw.plus_2)))
                {
                    if (check_if_card_fits(first_moving_card, "pile 2", true) == true)
                    {
                        for (int i = 0; i < b; i++)
                        {
                            redoCardsNumbersInPile(false, "pile 2", true);
                        }
                        for (int v = 1; v < Multiple_Cards_Moving.Length; v++)
                        {
                            if (Multiple_Cards_Moving[v] != -10)
                            {
                                CardsData.cardsData[Multiple_Cards_Moving[v]].cardPlace = "pile 2";
                                CardsData.cardsData[Multiple_Cards_Moving[v]].cardPlaceInPile = v;
                                CardsData.cardsData[Multiple_Cards_Moving[v]].isUp = true;

                                p++;


                                if (moving_from != "pile 2") Game1.score += 10;
                            }
                        }
                        for_drag_card_Else_2 = true;
                        for_elseInCardRelease = false;
                        are_There_Multiple_Cards_Moving = false;
                    }
                }
                #endregion

                #region pile 3
                p = 0;
                if ((Game1.mouseCurrentPos.X <= 299)
                                        && (Game1.mouseCurrentPos.X >= 215)
                                        && (Game1.mouseCurrentPos.Y <= (430 + Draw.plus_3))
                                        && (Game1.mouseCurrentPos.Y >= (284 + Draw.plus_3)))
                {
                    if (check_if_card_fits(first_moving_card, "pile 3", true) == true)
                    {
                        for (int i = 0; i < b; i++)
                        {
                            redoCardsNumbersInPile(false, "pile 3", true);
                        }
                        for (int v = 1; v < Multiple_Cards_Moving.Length; v++)
                        {
                            if (Multiple_Cards_Moving[v] != -10)
                            {
                                CardsData.cardsData[Multiple_Cards_Moving[v]].cardPlace = "pile 3";
                                CardsData.cardsData[Multiple_Cards_Moving[v]].cardPlaceInPile = v;
                                CardsData.cardsData[Multiple_Cards_Moving[v]].isUp = true;

                                p++;


                                if (moving_from != "pile 3") Game1.score += 10;
                            }
                        }
                        for_drag_card_Else_3 = true;
                        for_elseInCardRelease = false;
                        are_There_Multiple_Cards_Moving = false;
                    }
                }
                #endregion

                #region pile 4
                p = 0;
                if ((Game1.mouseCurrentPos.X <= 396)
                                        && (Game1.mouseCurrentPos.X >= 311)
                                        && (Game1.mouseCurrentPos.Y <= (430 + Draw.plus_4))
                                        && (Game1.mouseCurrentPos.Y >= (284 + Draw.plus_4)))
                {
                    if (check_if_card_fits(first_moving_card, "pile 4", true) == true)
                    {
                        for (int i = 0; i < b; i++)
                        {
                            redoCardsNumbersInPile(false, "pile 4", true);
                        }
                        for (int v = 1; v < Multiple_Cards_Moving.Length; v++)
                        {
                            if (Multiple_Cards_Moving[v] != -10)
                            {
                                CardsData.cardsData[Multiple_Cards_Moving[v]].cardPlace = "pile 4";
                                CardsData.cardsData[Multiple_Cards_Moving[v]].cardPlaceInPile = v;
                                CardsData.cardsData[Multiple_Cards_Moving[v]].isUp = true;

                                p++;


                                if (moving_from != "pile 4") Game1.score += 10;
                            }
                        }
                        for_drag_card_Else_4 = true;
                        for_elseInCardRelease = false;
                        are_There_Multiple_Cards_Moving = false;
                    }
                }
                #endregion

                #region pile 5
                p = 0;
                if ((Game1.mouseCurrentPos.X <= 492)
                                        && (Game1.mouseCurrentPos.X >= 407)
                                        && (Game1.mouseCurrentPos.Y <= (430 + Draw.plus_5))
                                        && (Game1.mouseCurrentPos.Y >= (284 + Draw.plus_5)))
                {
                    if (check_if_card_fits(first_moving_card, "pile 5", true) == true)
                    {
                        for (int i = 0; i < b; i++)
                        {
                            redoCardsNumbersInPile(false, "pile 5", true);
                        }
                        for (int v = 1; v < Multiple_Cards_Moving.Length; v++)
                        {
                            if (Multiple_Cards_Moving[v] != -10)
                            {
                                CardsData.cardsData[Multiple_Cards_Moving[v]].cardPlace = "pile 5";
                                CardsData.cardsData[Multiple_Cards_Moving[v]].cardPlaceInPile = v;
                                CardsData.cardsData[Multiple_Cards_Moving[v]].isUp = true;

                                p++;


                                if (moving_from != "pile 5") Game1.score += 10;
                            }
                        }
                        for_drag_card_Else_5 = true;
                        for_elseInCardRelease = false;
                        are_There_Multiple_Cards_Moving = false;
                    }
                }
                #endregion

                #region pile 6
                p = 0;
                if ((Game1.mouseCurrentPos.X <= 588)
                                        && (Game1.mouseCurrentPos.X >= 504)
                                        && (Game1.mouseCurrentPos.Y <= (430 + Draw.plus_6))
                                        && (Game1.mouseCurrentPos.Y >= (284 + Draw.plus_6)))
                {
                    if (check_if_card_fits(first_moving_card, "pile 6", true) == true)
                    {
                        for (int i = 0; i < b; i++)
                        {
                            redoCardsNumbersInPile(false, "pile 6", true);
                        }
                        for (int v = 1; v < Multiple_Cards_Moving.Length; v++)
                        {
                            if (Multiple_Cards_Moving[v] != -10)
                            {
                                CardsData.cardsData[Multiple_Cards_Moving[v]].cardPlace = "pile 6";
                                CardsData.cardsData[Multiple_Cards_Moving[v]].cardPlaceInPile = v;
                                CardsData.cardsData[Multiple_Cards_Moving[v]].isUp = true;

                                p++;


                                if (moving_from != "pile 6") Game1.score += 10;
                            }
                        }
                        for_drag_card_Else_6 = true;
                        for_elseInCardRelease = false;
                        are_There_Multiple_Cards_Moving = false;
                    }
                }
                #endregion

                #region pile 7
                p = 0;
                if ((Game1.mouseCurrentPos.X <= 686)
                                        && (Game1.mouseCurrentPos.X >= 601)
                                        && (Game1.mouseCurrentPos.Y <= (430 + Draw.plus_7))
                                        && (Game1.mouseCurrentPos.Y >= (284 + Draw.plus_7)))
                {
                    if (check_if_card_fits(first_moving_card, "pile 7", true) == true)
                    {
                        for (int i = 0; i < b; i++)
                        {
                            redoCardsNumbersInPile(false, "pile 7", true);
                        }
                        for (int v = 1; v < Multiple_Cards_Moving.Length; v++)
                        {
                            if (Multiple_Cards_Moving[v] != -10)
                            {
                                CardsData.cardsData[Multiple_Cards_Moving[v]].cardPlace = "pile 7";
                                CardsData.cardsData[Multiple_Cards_Moving[v]].cardPlaceInPile = v;
                                CardsData.cardsData[Multiple_Cards_Moving[v]].isUp = true;

                                p++;


                                if (moving_from != "pile 7") Game1.score += 10;
                            }
                        }
                        for_drag_card_Else_7 = true;
                        for_elseInCardRelease = false;
                        are_There_Multiple_Cards_Moving = false;
                    }
                }
                #endregion


                #endregion


                #region else
                if (for_drag_card_Else_1 == false && for_drag_card_Else_2 == false && for_drag_card_Else_3 == false && for_drag_card_Else_4 == false && for_drag_card_Else_5 == false && for_drag_card_Else_6 == false && for_drag_card_Else_7 == false)
                {
                    if (for_elseInCardRelease == false)
                    {
                        //if (moving_from != "neutral zone")
                        //{
                        for (int i = 0; i < b; i++)
                        {
                            redoCardsNumbersInPile(false, moving_from, true);
                        }
                        for (int v = 1; v < Multiple_Cards_Moving.Length; v++)
                        {
                            if (Multiple_Cards_Moving[v] != -10)
                            {
                                CardsData.cardsData[Multiple_Cards_Moving[v]].cardPlace = moving_from;
                                CardsData.cardsData[Multiple_Cards_Moving[v]].cardPlaceInPile = v;
                                CardsData.cardsData[Multiple_Cards_Moving[v]].isUp = true;
                                if (v == 1) its_realy_annoying = Multiple_Cards_Moving[v];
                                Multiple_Cards_Moving[v] = -10;

                                are_There_Multiple_Cards_Moving = false;
                            }
                        }

                            //first_card_num = Multiple_Cards_Moving[i + 1];
                            //CardsData.cardsData[first_card_num].cardPlace = moving_from;

                            //// הכי למטה זה מספר 1 בפייל

                            //CardsData.cardsData[first_card_num].cardPlaceInPile = i + 1;
                        
                        //}
                        //if (moving_from == "neutral zone")
                        //{
                        //    CardsData.cardsData[moving_Card].cardPlace = moving_from;
                        //    CardsData.cardsData[moving_Card].cardPos = card_Prev_pos;
                        //}
                        for_elseInCardRelease = true;
                    }
                }
                #endregion
            }
        }

        public static void right_click()
        {
            if (Game1.mouseCurrentPos.RightButton == ButtonState.Pressed)
            {
                num1 = check_which_card_is_first(1, "pile 1", true);
                num2 = check_which_card_is_first(1, "pile 2", true);
                num3 = check_which_card_is_first(1, "pile 3", true);
                num4 = check_which_card_is_first(1, "pile 4", true);
                num5 = check_which_card_is_first(1, "pile 5", true);
                num6 = check_which_card_is_first(1, "pile 6", true);
                num7 = check_which_card_is_first(1, "pile 7", true);
                numLeftDeck = check_which_card_is_first(1, "left Deck", true);

                #region pile1 (num1)
                if (num1 != -10)
                {
                    #region setup
                    slot1_B = false;
                    slot2_B = false;
                    slot3_B = false;
                    slot4_B = false;

                    if (CardsData.cardsData[num1].cardNumber == Background.number_of_cards_in_card_slot1 + 1)
                    {
                        slot1_B = true;
                    }
                    if (CardsData.cardsData[num1].cardNumber == Background.number_of_cards_in_card_slot2 + 1)
                    {
                        slot2_B = true;
                    }
                    if (CardsData.cardsData[num1].cardNumber == Background.number_of_cards_in_card_slot3 + 1)
                    {
                        slot3_B = true;
                    }
                    if (CardsData.cardsData[num1].cardNumber == Background.number_of_cards_in_card_slot4 + 1)
                    {
                        slot4_B = true;
                    }
                    #endregion


                    #region  if card must be in one slot (already are cards from his symbol and number-1;
                    if (CardsData.cardsData[num1].cardSymbol == slot1_S && slot1_B == true)
                    {
                        CardsData.cardsData[num1].cardPlace = "card slot1";
                        redoCardsNumbersInPile(false, "card slot1", true);
                        CardsData.cardsData[num1].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot1++;
                        redoCardsNumbersInPile(false, "pile 1", false);

                        Game1.score += 20;
                    }

                    if (CardsData.cardsData[num1].cardSymbol == slot2_S && slot2_B == true)
                    {
                        CardsData.cardsData[num1].cardPlace = "card slot2";
                        redoCardsNumbersInPile(false, "card slot2", true);
                        CardsData.cardsData[num1].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot2++;
                        redoCardsNumbersInPile(false, "pile 1", false);

                        Game1.score += 20;
                    }
                    if (CardsData.cardsData[num1].cardSymbol == slot3_S && slot3_B == true)
                    {
                        CardsData.cardsData[num1].cardPlace = "card slot3";
                        redoCardsNumbersInPile(false, "card slot3", true);
                        CardsData.cardsData[num1].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot3++;
                        redoCardsNumbersInPile(false, "pile 1", false);

                        Game1.score += 20;
                    }

                    if (CardsData.cardsData[num1].cardSymbol == slot4_S && slot4_B == true)
                    {
                        CardsData.cardsData[num1].cardPlace = "card slot4";
                        redoCardsNumbersInPile(false, "card slot4", true);
                        CardsData.cardsData[num1].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot4++;
                        redoCardsNumbersInPile(false, "pile 1", false);

                        Game1.score += 20;
                    }
                    #endregion


                    #region if card doesnt fit anywhere but is an A and there's an empty slot
                    if (CardsData.cardsData[num1].cardNumber == 1 && CardsData.cardsData[num1].cardSymbol != slot1_S && CardsData.cardsData[num1].cardSymbol != slot2_S && CardsData.cardsData[num1].cardSymbol != slot3_S && CardsData.cardsData[num1].cardSymbol != slot4_S)
                    {
                        //fits X slots means that the card doesnt fit in any non-0-cards-on slot, but has X 0 slots to go to.

                        #region 4 empty slots
                        if (slot1_B == true && slot2_B == true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(3);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num1].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num1].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num1].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;

                                case 4: CardsData.cardsData[num1].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 1", false);

                            Game1.score += 20;
                        }
                        #endregion

                        #region 3 empty slots

                        #region not 4th
                        if (slot1_B == true && slot2_B == true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num1].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num1].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num1].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 1", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 3ed
                        if (slot1_B == true && slot2_B == true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num1].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num1].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num1].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 1", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 2ed
                        if (slot1_B == true && slot2_B != true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num1].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num1].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;

                                case 3: CardsData.cardsData[num1].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 1", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 1st
                        if (slot1_B != true && slot2_B == true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num1].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;

                                case 2: CardsData.cardsData[num1].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num1].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 1", false);   Game1.score += 20;
                        }
                        #endregion

                        #endregion

                        #region 2 empty slots

                        #region not 1st and 2ed
                        if (slot1_B != true && slot2_B != true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num1].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;

                                case 2: CardsData.cardsData[num1].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 1", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 1st and 3ed
                        if (slot1_B != true && slot2_B == true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num1].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 2: CardsData.cardsData[num1].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 1", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 1st and 4th
                        if (slot1_B != true && slot2_B == true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num1].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 2: CardsData.cardsData[num1].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 1", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 2ed and 3ed
                        if (slot1_B == true && slot2_B != true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num1].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num1].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 1", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 2ed and 4th
                        if (slot1_B == true && slot2_B != true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num1].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num1].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 1", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 3ed and 4th
                        if (slot1_B == true && slot2_B == true && slot3_B != true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num1].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num1].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num1].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 1", false);   Game1.score += 20;
                        }
                        #endregion

                        #endregion

                        #region one empty

                        #region 1st empty
                        if (slot1_B == true && slot2_B != true && slot3_B != true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num1].cardPlace = "card slot1";
                            if (Background.number_of_cards_in_card_slot1 != 0)
                                redoCardsNumbersInPile(false, "card slot1", true);

                            CardsData.cardsData[num1].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot1++;
                            redoCardsNumbersInPile(false, "pile 1", false);   Game1.score += 20;
                        }

                        #endregion

                        #region 2ed empty
                        if (slot1_B != true && slot2_B == true && slot3_B != true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num1].cardPlace = "card slot2";
                            if (Background.number_of_cards_in_card_slot2 != 0)
                                redoCardsNumbersInPile(false, "card slot2", true);

                            CardsData.cardsData[num1].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot2++;
                            redoCardsNumbersInPile(false, "pile 1", false);   Game1.score += 20;
                        }
                        #endregion

                        #region 3ed empty
                        if (slot1_B != true && slot2_B != true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num1].cardPlace = "card slot3";
                            if (Background.number_of_cards_in_card_slot3 != 0)
                                redoCardsNumbersInPile(false, "card slot3", true);

                            CardsData.cardsData[num1].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot3++;
                            redoCardsNumbersInPile(false, "pile 1", false);   Game1.score += 20;
                        }
                        #endregion

                        #region 4th empty
                        if (slot1_B != true && slot2_B != true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num1].cardPlace = "card slot4";
                            if (Background.number_of_cards_in_card_slot4 != 0)
                                redoCardsNumbersInPile(false, "card slot4", true);

                            CardsData.cardsData[num1].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot4++;
                            redoCardsNumbersInPile(false, "pile 1", false);   Game1.score += 20;
                        }
                        #endregion

                        #endregion
                    }
                    #endregion
                }
                #endregion

                #region pile2 (num2)
                if (num2 != -10)
                {
                    #region setup
                    slot1_B = false;
                    slot2_B = false;
                    slot3_B = false;
                    slot4_B = false;

                    if (CardsData.cardsData[num2].cardNumber == Background.number_of_cards_in_card_slot1 + 1)
                    {
                        slot1_B = true;
                    }
                    if (CardsData.cardsData[num2].cardNumber == Background.number_of_cards_in_card_slot2 + 1)
                    {
                        slot2_B = true;
                    }
                    if (CardsData.cardsData[num2].cardNumber == Background.number_of_cards_in_card_slot3 + 1)
                    {
                        slot3_B = true;
                    }
                    if (CardsData.cardsData[num2].cardNumber == Background.number_of_cards_in_card_slot4 + 1)
                    {
                        slot4_B = true;
                    }
                    #endregion


                    #region  if card must be in one slot (already are cards from his symbol and number-1;
                    if (CardsData.cardsData[num2].cardSymbol == slot1_S && slot1_B == true)
                    {
                        CardsData.cardsData[num2].cardPlace = "card slot1";
                        redoCardsNumbersInPile(false, "card slot1", true);
                        CardsData.cardsData[num2].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot1++;
                        redoCardsNumbersInPile(false, "pile 2", false);   Game1.score += 20;
                    }

                    if (CardsData.cardsData[num2].cardSymbol == slot2_S && slot2_B == true)
                    {
                        CardsData.cardsData[num2].cardPlace = "card slot2";
                        redoCardsNumbersInPile(false, "card slot2", true);
                        CardsData.cardsData[num2].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot2++;
                        redoCardsNumbersInPile(false, "pile 2", false);   Game1.score += 20;
                    }
                    if (CardsData.cardsData[num2].cardSymbol == slot3_S && slot3_B == true)
                    {
                        CardsData.cardsData[num2].cardPlace = "card slot3";
                        redoCardsNumbersInPile(false, "card slot3", true);
                        CardsData.cardsData[num2].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot3++;
                        redoCardsNumbersInPile(false, "pile 2", false);   Game1.score += 20;
                    }

                    if (CardsData.cardsData[num2].cardSymbol == slot4_S && slot4_B == true)
                    {
                        CardsData.cardsData[num2].cardPlace = "card slot4";
                        redoCardsNumbersInPile(false, "card slot4", true);
                        CardsData.cardsData[num2].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot4++;
                        redoCardsNumbersInPile(false, "pile 2", false);   Game1.score += 20;
                    }
                    #endregion


                    #region if card doesnt fit anywhere but is an A and there's an empty slot
                    if (CardsData.cardsData[num2].cardNumber == 1 && CardsData.cardsData[num2].cardSymbol != slot1_S && CardsData.cardsData[num2].cardSymbol != slot2_S && CardsData.cardsData[num2].cardSymbol != slot3_S && CardsData.cardsData[num2].cardSymbol != slot4_S)
                    {
                        //fits X slots means that the card doesnt fit in any non-0-cards-on slot, but has X 0 slots to go to.

                        #region 4 empty slots
                        if (slot1_B == true && slot2_B == true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(3);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num2].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num2].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num2].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;

                                case 4: CardsData.cardsData[num2].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 2", false);   Game1.score += 20;
                        }
                        #endregion

                        #region 3 empty slots

                        #region not 4th
                        if (slot1_B == true && slot2_B == true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num2].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num2].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num2].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 2", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 3ed
                        if (slot1_B == true && slot2_B == true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num2].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num2].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num2].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 2", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 2ed
                        if (slot1_B == true && slot2_B != true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num2].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num2].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;

                                case 3: CardsData.cardsData[num2].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 2", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 1st
                        if (slot1_B != true && slot2_B == true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num2].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;

                                case 2: CardsData.cardsData[num2].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num2].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 2", false);   Game1.score += 20;
                        }
                        #endregion

                        #endregion

                        #region 2 empty slots

                        #region not 1st and 2ed
                        if (slot1_B != true && slot2_B != true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num2].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;

                                case 2: CardsData.cardsData[num2].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 2", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 1st and 3ed
                        if (slot1_B != true && slot2_B == true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num2].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 2: CardsData.cardsData[num2].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 2", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 1st and 4th
                        if (slot1_B != true && slot2_B == true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num2].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 2: CardsData.cardsData[num2].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 2", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 2ed and 3ed
                        if (slot1_B == true && slot2_B != true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num2].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num2].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 2", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 2ed and 4th
                        if (slot1_B == true && slot2_B != true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num2].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num2].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 2", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 3ed and 4th
                        if (slot1_B == true && slot2_B == true && slot3_B != true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num2].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num2].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num2].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 2", false);   Game1.score += 20;
                        }
                        #endregion

                        #endregion

                        #region one empty

                        #region 1st empty
                        if (slot1_B == true && slot2_B != true && slot3_B != true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num2].cardPlace = "card slot1";
                            if (Background.number_of_cards_in_card_slot1 != 0)
                                redoCardsNumbersInPile(false, "card slot1", true);

                            CardsData.cardsData[num2].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot1++;
                            redoCardsNumbersInPile(false, "pile 2", false);   Game1.score += 20;
                        }
                        #endregion

                        #region 2ed empty
                        if (slot1_B != true && slot2_B == true && slot3_B != true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num2].cardPlace = "card slot2";
                            if (Background.number_of_cards_in_card_slot2 != 0)
                                redoCardsNumbersInPile(false, "card slot2", true);

                            CardsData.cardsData[num2].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot2++;
                            redoCardsNumbersInPile(false, "pile 2", false);   Game1.score += 20;
                        }
                        #endregion

                        #region 3ed empty
                        if (slot1_B != true && slot2_B != true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num2].cardPlace = "card slot3";
                            if (Background.number_of_cards_in_card_slot3 != 0)
                                redoCardsNumbersInPile(false, "card slot3", true);

                            CardsData.cardsData[num2].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot3++;
                            redoCardsNumbersInPile(false, "pile 2", false);   Game1.score += 20;
                        }
                        #endregion

                        #region 4th empty
                        if (slot1_B != true && slot2_B != true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num2].cardPlace = "card slot4";
                            if (Background.number_of_cards_in_card_slot4 != 0)
                                redoCardsNumbersInPile(false, "card slot4", true);

                            CardsData.cardsData[num2].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot4++;
                            redoCardsNumbersInPile(false, "pile 2", false);   Game1.score += 20;
                        }
                        #endregion

                        #endregion
                    }
                    #endregion
                }
                #endregion

                #region pile3 (num3)
                if (num3 != -10)
                {
                    #region setup
                    slot1_B = false;
                    slot2_B = false;
                    slot3_B = false;
                    slot4_B = false;

                    if (CardsData.cardsData[num3].cardNumber == Background.number_of_cards_in_card_slot1 + 1)
                    {
                        slot1_B = true;
                    }
                    if (CardsData.cardsData[num3].cardNumber == Background.number_of_cards_in_card_slot2 + 1)
                    {
                        slot2_B = true;
                    }
                    if (CardsData.cardsData[num3].cardNumber == Background.number_of_cards_in_card_slot3 + 1)
                    {
                        slot3_B = true;
                    }
                    if (CardsData.cardsData[num3].cardNumber == Background.number_of_cards_in_card_slot4 + 1)
                    {
                        slot4_B = true;
                    }
                    #endregion


                    #region  if card must be in one slot (already are cards from his symbol and number-1;
                    if (CardsData.cardsData[num3].cardSymbol == slot1_S && slot1_B == true)
                    {
                        CardsData.cardsData[num3].cardPlace = "card slot1";
                        redoCardsNumbersInPile(false, "card slot1", true);
                        CardsData.cardsData[num3].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot1++;
                        redoCardsNumbersInPile(false, "pile 3", false);   Game1.score += 20;
                    }

                    if (CardsData.cardsData[num3].cardSymbol == slot2_S && slot2_B == true)
                    {
                        CardsData.cardsData[num3].cardPlace = "card slot2";
                        redoCardsNumbersInPile(false, "card slot2", true);
                        CardsData.cardsData[num3].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot2++;
                        redoCardsNumbersInPile(false, "pile 3", false);   Game1.score += 20;
                    }
                    if (CardsData.cardsData[num3].cardSymbol == slot3_S && slot3_B == true)
                    {
                        CardsData.cardsData[num3].cardPlace = "card slot3";
                        redoCardsNumbersInPile(false, "card slot3", true);
                        CardsData.cardsData[num3].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot3++;
                        redoCardsNumbersInPile(false, "pile 3", false);   Game1.score += 20;
                    }

                    if (CardsData.cardsData[num3].cardSymbol == slot4_S && slot4_B == true)
                    {
                        CardsData.cardsData[num3].cardPlace = "card slot4";
                        redoCardsNumbersInPile(false, "card slot4", true);
                        CardsData.cardsData[num3].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot4++;
                        redoCardsNumbersInPile(false, "pile 3", false);   Game1.score += 20;
                    }
                    #endregion


                    #region if card doesnt fit anywhere but is an A and there's an empty slot
                    if (CardsData.cardsData[num3].cardNumber == 1 && CardsData.cardsData[num3].cardSymbol != slot1_S && CardsData.cardsData[num3].cardSymbol != slot2_S && CardsData.cardsData[num3].cardSymbol != slot3_S && CardsData.cardsData[num3].cardSymbol != slot4_S)
                    {
                        //fits X slots means that the card doesnt fit in any non-0-cards-on slot, but has X 0 slots to go to.

                        #region 4 empty slots
                        if (slot1_B == true && slot2_B == true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(3);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num3].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num3].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num3].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;

                                case 4: CardsData.cardsData[num3].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 3", false);   Game1.score += 20;
                        }
                        #endregion

                        #region 3 empty slots

                        #region not 4th
                        if (slot1_B == true && slot2_B == true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num3].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num3].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num3].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 3", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 3ed
                        if (slot1_B == true && slot2_B == true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num3].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num3].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num3].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 3", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 2ed
                        if (slot1_B == true && slot2_B != true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num3].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num3].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;

                                case 3: CardsData.cardsData[num3].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 3", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 1st
                        if (slot1_B != true && slot2_B == true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num3].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;

                                case 2: CardsData.cardsData[num3].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num3].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 3", false);   Game1.score += 20;
                        }
                        #endregion

                        #endregion

                        #region 2 empty slots

                        #region not 1st and 2ed
                        if (slot1_B != true && slot2_B != true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num3].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;

                                case 2: CardsData.cardsData[num3].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 3", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 1st and 3ed
                        if (slot1_B != true && slot2_B == true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num3].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 2: CardsData.cardsData[num3].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 3", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 1st and 4th
                        if (slot1_B != true && slot2_B == true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num3].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 2: CardsData.cardsData[num3].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 3", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 2ed and 3ed
                        if (slot1_B == true && slot2_B != true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num3].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num3].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 3", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 2ed and 4th
                        if (slot1_B == true && slot2_B != true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num3].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num3].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 3", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 3ed and 4th
                        if (slot1_B == true && slot2_B == true && slot3_B != true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num3].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num3].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num3].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 3", false);   Game1.score += 20;
                        }
                        #endregion

                        #endregion

                        #region one empty

                        #region 1st empty
                        if (slot1_B == true && slot2_B != true && slot3_B != true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num3].cardPlace = "card slot1";
                            if (Background.number_of_cards_in_card_slot1 != 0)
                                redoCardsNumbersInPile(false, "card slot1", true);

                            CardsData.cardsData[num3].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot1++;
                            redoCardsNumbersInPile(false, "pile 3", false);   Game1.score += 20;
                        }
                        #endregion

                        #region 2ed empty
                        if (slot1_B != true && slot2_B == true && slot3_B != true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num3].cardPlace = "card slot2";
                            if (Background.number_of_cards_in_card_slot2 != 0)
                                redoCardsNumbersInPile(false, "card slot2", true);

                            CardsData.cardsData[num3].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot2++;
                            redoCardsNumbersInPile(false, "pile 3", false);   Game1.score += 20;
                        }
                        #endregion

                        #region 3ed empty
                        if (slot1_B != true && slot2_B != true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num3].cardPlace = "card slot3";
                            if (Background.number_of_cards_in_card_slot3 != 0)
                                redoCardsNumbersInPile(false, "card slot3", true);

                            CardsData.cardsData[num3].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot3++;
                            redoCardsNumbersInPile(false, "pile 3", false);   Game1.score += 20;
                        }
                        #endregion

                        #region 4th empty
                        if (slot1_B != true && slot2_B != true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num3].cardPlace = "card slot4";
                            if (Background.number_of_cards_in_card_slot4 != 0)
                                redoCardsNumbersInPile(false, "card slot4", true);

                            CardsData.cardsData[num3].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot4++;
                            redoCardsNumbersInPile(false, "pile 3", false);   Game1.score += 20;
                        }
                        #endregion

                        #endregion
                    }
                    #endregion
                }
                #endregion

                #region pile4 (num4)
                if (num4 != -10)
                {
                    #region setup
                    slot1_B = false;
                    slot2_B = false;
                    slot3_B = false;
                    slot4_B = false;

                    if (CardsData.cardsData[num4].cardNumber == Background.number_of_cards_in_card_slot1 + 1)
                    {
                        slot1_B = true;
                    }
                    if (CardsData.cardsData[num4].cardNumber == Background.number_of_cards_in_card_slot2 + 1)
                    {
                        slot2_B = true;
                    }
                    if (CardsData.cardsData[num4].cardNumber == Background.number_of_cards_in_card_slot3 + 1)
                    {
                        slot3_B = true;
                    }
                    if (CardsData.cardsData[num4].cardNumber == Background.number_of_cards_in_card_slot4 + 1)
                    {
                        slot4_B = true;
                    }
                    #endregion


                    #region  if card must be in one slot (already are cards from his symbol and number-1;
                    if (CardsData.cardsData[num4].cardSymbol == slot1_S && slot1_B == true)
                    {
                        CardsData.cardsData[num4].cardPlace = "card slot1";
                        redoCardsNumbersInPile(false, "card slot1", true);
                        CardsData.cardsData[num4].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot1++;
                        redoCardsNumbersInPile(false, "pile 4", false);   Game1.score += 20;
                    }

                    if (CardsData.cardsData[num4].cardSymbol == slot2_S && slot2_B == true)
                    {
                        CardsData.cardsData[num4].cardPlace = "card slot2";
                        redoCardsNumbersInPile(false, "card slot2", true);
                        CardsData.cardsData[num4].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot2++;
                        redoCardsNumbersInPile(false, "pile 4", false);   Game1.score += 20;
                    }
                    if (CardsData.cardsData[num4].cardSymbol == slot3_S && slot3_B == true)
                    {
                        CardsData.cardsData[num4].cardPlace = "card slot3";
                        redoCardsNumbersInPile(false, "card slot3", true);
                        CardsData.cardsData[num4].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot3++;
                        redoCardsNumbersInPile(false, "pile 4", false);   Game1.score += 20;
                    }

                    if (CardsData.cardsData[num4].cardSymbol == slot4_S && slot4_B == true)
                    {
                        CardsData.cardsData[num4].cardPlace = "card slot4";
                        redoCardsNumbersInPile(false, "card slot4", true);
                        CardsData.cardsData[num4].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot4++;
                        redoCardsNumbersInPile(false, "pile 4", false);   Game1.score += 20;
                    }
                    #endregion


                    #region if card doesnt fit anywhere but is an A and there's an empty slot
                    if (CardsData.cardsData[num4].cardNumber == 1 && CardsData.cardsData[num4].cardSymbol != slot1_S && CardsData.cardsData[num4].cardSymbol != slot2_S && CardsData.cardsData[num4].cardSymbol != slot3_S && CardsData.cardsData[num4].cardSymbol != slot4_S)
                    {
                        //fits X slots means that the card doesnt fit in any non-0-cards-on slot, but has X 0 slots to go to.

                        #region 4 empty slots
                        if (slot1_B == true && slot2_B == true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(3);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num4].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num4].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num4].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;

                                case 4: CardsData.cardsData[num4].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 4", false);   Game1.score += 20;
                        }
                        #endregion

                        #region 3 empty slots

                        #region not 4th
                        if (slot1_B == true && slot2_B == true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num4].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num4].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num4].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 4", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 3ed
                        if (slot1_B == true && slot2_B == true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num4].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num4].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num4].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 4", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 2ed
                        if (slot1_B == true && slot2_B != true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num4].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num4].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;

                                case 3: CardsData.cardsData[num4].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 4", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 1st
                        if (slot1_B != true && slot2_B == true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num4].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;

                                case 2: CardsData.cardsData[num4].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num4].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 4", false);   Game1.score += 20;
                        }
                        #endregion

                        #endregion

                        #region 2 empty slots

                        #region not 1st and 2ed
                        if (slot1_B != true && slot2_B != true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num4].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;

                                case 2: CardsData.cardsData[num4].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 4", false); Game1.score += 20;
                        }
                        #endregion

                        #region not 1st and 3ed
                        if (slot1_B != true && slot2_B == true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num4].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 2: CardsData.cardsData[num4].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 4", false); Game1.score += 20;
                        }
                        #endregion

                        #region not 1st and 4th
                        if (slot1_B != true && slot2_B == true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num4].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 2: CardsData.cardsData[num4].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 4", false); Game1.score += 20;
                        }
                        #endregion

                        #region not 2ed and 3ed
                        if (slot1_B == true && slot2_B != true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num4].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num4].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 4", false); Game1.score += 20;
                        }
                        #endregion

                        #region not 2ed and 4th
                        if (slot1_B == true && slot2_B != true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num4].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num4].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 4", false); Game1.score += 20;
                        }
                        #endregion

                        #region not 3ed and 4th
                        if (slot1_B == true && slot2_B == true && slot3_B != true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num4].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num4].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num4].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 4", false); Game1.score += 20;
                        }
                        #endregion

                        #endregion

                        #region one empty

                        #region 1st empty
                        if (slot1_B == true && slot2_B != true && slot3_B != true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num4].cardPlace = "card slot1";
                            if (Background.number_of_cards_in_card_slot1 != 0)
                                redoCardsNumbersInPile(false, "card slot1", true);

                            CardsData.cardsData[num4].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot1++;
                            redoCardsNumbersInPile(false, "pile 4", false);   Game1.score += 20;
                        }
                        #endregion

                        #region 2ed empty
                        if (slot1_B != true && slot2_B == true && slot3_B != true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num4].cardPlace = "card slot2";
                            if (Background.number_of_cards_in_card_slot2 != 0)
                                redoCardsNumbersInPile(false, "card slot2", true);

                            CardsData.cardsData[num4].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot2++;
                            redoCardsNumbersInPile(false, "pile 4", false);   Game1.score += 20;
                        }
                        #endregion

                        #region 3ed empty
                        if (slot1_B != true && slot2_B != true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num4].cardPlace = "card slot3";
                            if (Background.number_of_cards_in_card_slot3 != 0)
                                redoCardsNumbersInPile(false, "card slot3", true);

                            CardsData.cardsData[num4].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot3++;
                            redoCardsNumbersInPile(false, "pile 4", false);   Game1.score += 20;
                        }
                        #endregion

                        #region 4th empty
                        if (slot1_B != true && slot2_B != true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num4].cardPlace = "card slot4";
                            if (Background.number_of_cards_in_card_slot4 != 0)
                                redoCardsNumbersInPile(false, "card slot4", true);

                            CardsData.cardsData[num4].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot4++;
                            redoCardsNumbersInPile(false, "pile 4", false);   Game1.score += 20;
                        }
                        #endregion

                        #endregion
                    }
                    #endregion
                }
                #endregion

                #region pile5 (num5)
                if (num5 != -10)
                {
                    #region setup
                    slot1_B = false;
                    slot2_B = false;
                    slot3_B = false;
                    slot4_B = false;

                    if (CardsData.cardsData[num5].cardNumber == Background.number_of_cards_in_card_slot1 + 1)
                    {
                        slot1_B = true;
                    }
                    if (CardsData.cardsData[num5].cardNumber == Background.number_of_cards_in_card_slot2 + 1)
                    {
                        slot2_B = true;
                    }
                    if (CardsData.cardsData[num5].cardNumber == Background.number_of_cards_in_card_slot3 + 1)
                    {
                        slot3_B = true;
                    }
                    if (CardsData.cardsData[num5].cardNumber == Background.number_of_cards_in_card_slot4 + 1)
                    {
                        slot4_B = true;
                    }
                    #endregion


                    #region  if card must be in one slot (already are cards from his symbol and number-1;
                    if (CardsData.cardsData[num5].cardSymbol == slot1_S && slot1_B == true)
                    {
                        CardsData.cardsData[num5].cardPlace = "card slot1";
                        redoCardsNumbersInPile(false, "card slot1", true);
                        CardsData.cardsData[num5].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot1++;
                        redoCardsNumbersInPile(false, "pile 5", false);   Game1.score += 20;
                    }

                    if (CardsData.cardsData[num5].cardSymbol == slot2_S && slot2_B == true)
                    {
                        CardsData.cardsData[num5].cardPlace = "card slot2";
                        redoCardsNumbersInPile(false, "card slot2", true);
                        CardsData.cardsData[num5].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot2++;
                        redoCardsNumbersInPile(false, "pile 5", false);   Game1.score += 20;
                    }
                    if (CardsData.cardsData[num5].cardSymbol == slot3_S && slot3_B == true)
                    {
                        CardsData.cardsData[num5].cardPlace = "card slot3";
                        redoCardsNumbersInPile(false, "card slot3", true);
                        CardsData.cardsData[num5].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot3++;
                        redoCardsNumbersInPile(false, "pile 5", false);   Game1.score += 20;
                    }

                    if (CardsData.cardsData[num5].cardSymbol == slot4_S && slot4_B == true)
                    {
                        CardsData.cardsData[num5].cardPlace = "card slot4";
                        redoCardsNumbersInPile(false, "card slot4", true);
                        CardsData.cardsData[num5].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot4++;
                        redoCardsNumbersInPile(false, "pile 5", false);   Game1.score += 20;
                    }
                    #endregion


                    #region if card doesnt fit anywhere but is an A and there's an empty slot
                    if (CardsData.cardsData[num5].cardNumber == 1 && CardsData.cardsData[num5].cardSymbol != slot1_S && CardsData.cardsData[num5].cardSymbol != slot2_S && CardsData.cardsData[num5].cardSymbol != slot3_S && CardsData.cardsData[num5].cardSymbol != slot4_S)
                    {
                        //fits X slots means that the card doesnt fit in any non-0-cards-on slot, but has X 0 slots to go to.

                        #region 4 empty slots
                        if (slot1_B == true && slot2_B == true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(3);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num5].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num5].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num5].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;

                                case 4: CardsData.cardsData[num5].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 5", false);   Game1.score += 20;
                        }
                        #endregion

                        #region 3 empty slots

                        #region not 4th
                        if (slot1_B == true && slot2_B == true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num5].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num5].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num5].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 5", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 3ed
                        if (slot1_B == true && slot2_B == true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num5].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num5].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num5].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 5", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 2ed
                        if (slot1_B == true && slot2_B != true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num5].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num5].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;

                                case 3: CardsData.cardsData[num5].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 5", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 1st
                        if (slot1_B != true && slot2_B == true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num5].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;

                                case 2: CardsData.cardsData[num5].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num5].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 5", false);   Game1.score += 20;
                        }
                        #endregion

                        #endregion

                        #region 2 empty slots

                        #region not 1st and 2ed
                        if (slot1_B != true && slot2_B != true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num5].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;

                                case 2: CardsData.cardsData[num5].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 5", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 1st and 3ed
                        if (slot1_B != true && slot2_B == true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num5].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 2: CardsData.cardsData[num5].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 5", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 1st and 4th
                        if (slot1_B != true && slot2_B == true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num5].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 2: CardsData.cardsData[num5].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 5", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 2ed and 3ed
                        if (slot1_B == true && slot2_B != true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num5].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num5].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 5", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 2ed and 4th
                        if (slot1_B == true && slot2_B != true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num5].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num5].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 5", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 3ed and 4th
                        if (slot1_B == true && slot2_B == true && slot3_B != true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num5].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num5].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num5].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 5", false);   Game1.score += 20;
                        }
                        #endregion

                        #endregion

                        #region one empty

                        #region 1st empty
                        if (slot1_B == true && slot2_B != true && slot3_B != true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num5].cardPlace = "card slot1";
                            if (Background.number_of_cards_in_card_slot1 != 0)
                                redoCardsNumbersInPile(false, "card slot1", true);

                            CardsData.cardsData[num5].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot1++;
                            redoCardsNumbersInPile(false, "pile 5", false);   Game1.score += 20;
                        }
                        #endregion

                        #region 2ed empty
                        if (slot1_B != true && slot2_B == true && slot3_B != true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num5].cardPlace = "card slot2";
                            if (Background.number_of_cards_in_card_slot2 != 0)
                                redoCardsNumbersInPile(false, "card slot2", true);

                            CardsData.cardsData[num5].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot2++;
                            redoCardsNumbersInPile(false, "pile 5", false);   Game1.score += 20;
                        }
                        #endregion

                        #region 3ed empty
                        if (slot1_B != true && slot2_B != true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num5].cardPlace = "card slot3";
                            if (Background.number_of_cards_in_card_slot3 != 0)
                                redoCardsNumbersInPile(false, "card slot3", true);

                            CardsData.cardsData[num5].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot3++;
                            redoCardsNumbersInPile(false, "pile 5", false);   Game1.score += 20;
                        }
                        #endregion

                        #region 4th empty
                        if (slot1_B != true && slot2_B != true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num5].cardPlace = "card slot4";
                            if (Background.number_of_cards_in_card_slot4 != 0)
                                redoCardsNumbersInPile(false, "card slot4", true);

                            CardsData.cardsData[num5].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot4++;
                            redoCardsNumbersInPile(false, "pile 5", false);   Game1.score += 20;
                        }
                        #endregion

                        #endregion
                    }
                    #endregion
                }
                #endregion

                #region pile6 (num6)
                if (num6 != -10)
                {
                    #region setup
                    slot1_B = false;
                    slot2_B = false;
                    slot3_B = false;
                    slot4_B = false;

                    if (CardsData.cardsData[num6].cardNumber == Background.number_of_cards_in_card_slot1 + 1)
                    {
                        slot1_B = true;
                    }
                    if (CardsData.cardsData[num6].cardNumber == Background.number_of_cards_in_card_slot2 + 1)
                    {
                        slot2_B = true;
                    }
                    if (CardsData.cardsData[num6].cardNumber == Background.number_of_cards_in_card_slot3 + 1)
                    {
                        slot3_B = true;
                    }
                    if (CardsData.cardsData[num6].cardNumber == Background.number_of_cards_in_card_slot4 + 1)
                    {
                        slot4_B = true;
                    }
                    #endregion


                    #region  if card must be in one slot (already are cards from his symbol and number-1;
                    if (CardsData.cardsData[num6].cardSymbol == slot1_S && slot1_B == true)
                    {
                        CardsData.cardsData[num6].cardPlace = "card slot1";
                        redoCardsNumbersInPile(false, "card slot1", true);
                        CardsData.cardsData[num6].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot1++;
                        redoCardsNumbersInPile(false, "pile 6", false);   Game1.score += 20;
                    }

                    if (CardsData.cardsData[num6].cardSymbol == slot2_S && slot2_B == true)
                    {
                        CardsData.cardsData[num6].cardPlace = "card slot2";
                        redoCardsNumbersInPile(false, "card slot2", true);
                        CardsData.cardsData[num6].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot2++;
                        redoCardsNumbersInPile(false, "pile 6", false);   Game1.score += 20;
                    }
                    if (CardsData.cardsData[num6].cardSymbol == slot3_S && slot3_B == true)
                    {
                        CardsData.cardsData[num6].cardPlace = "card slot3";
                        redoCardsNumbersInPile(false, "card slot3", true);
                        CardsData.cardsData[num6].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot3++;
                        redoCardsNumbersInPile(false, "pile 6", false);   Game1.score += 20;
                    }

                    if (CardsData.cardsData[num6].cardSymbol == slot4_S && slot4_B == true)
                    {
                        CardsData.cardsData[num6].cardPlace = "card slot4";
                        redoCardsNumbersInPile(false, "card slot4", true);
                        CardsData.cardsData[num6].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot4++;
                        redoCardsNumbersInPile(false, "pile 6", false);   Game1.score += 20;
                    }
                    #endregion


                    #region if card doesnt fit anywhere but is an A and there's an empty slot
                    if (CardsData.cardsData[num6].cardNumber == 1 && CardsData.cardsData[num6].cardSymbol != slot1_S && CardsData.cardsData[num6].cardSymbol != slot2_S && CardsData.cardsData[num6].cardSymbol != slot3_S && CardsData.cardsData[num6].cardSymbol != slot4_S)
                    {
                        //fits X slots means that the card doesnt fit in any non-0-cards-on slot, but has X 0 slots to go to.

                        #region 4 empty slots
                        if (slot1_B == true && slot2_B == true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(3);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num6].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num6].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num6].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;

                                case 4: CardsData.cardsData[num6].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 6", false);   Game1.score += 20;
                        }
                        #endregion

                        #region 3 empty slots

                        #region not 4th
                        if (slot1_B == true && slot2_B == true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num6].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num6].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num6].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 6", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 3ed
                        if (slot1_B == true && slot2_B == true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num6].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num6].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num6].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 6", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 2ed
                        if (slot1_B == true && slot2_B != true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num6].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num6].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;

                                case 3: CardsData.cardsData[num6].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 6", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 1st
                        if (slot1_B != true && slot2_B == true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num6].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;

                                case 2: CardsData.cardsData[num6].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num6].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 6", false);   Game1.score += 20;
                        }
                        #endregion

                        #endregion

                        #region 2 empty slots

                        #region not 1st and 2ed
                        if (slot1_B != true && slot2_B != true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num6].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;

                                case 2: CardsData.cardsData[num6].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 6", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 1st and 3ed
                        if (slot1_B != true && slot2_B == true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num6].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 2: CardsData.cardsData[num6].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 6", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 1st and 4th
                        if (slot1_B != true && slot2_B == true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num6].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 2: CardsData.cardsData[num6].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 6", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 2ed and 3ed
                        if (slot1_B == true && slot2_B != true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num6].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num6].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 6", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 2ed and 4th
                        if (slot1_B == true && slot2_B != true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num6].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num6].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 6", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 3ed and 4th
                        if (slot1_B == true && slot2_B == true && slot3_B != true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num6].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num6].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num6].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 6", false);   Game1.score += 20;
                        }
                        #endregion

                        #endregion

                        #region one empty

                        #region 1st empty
                        if (slot1_B == true && slot2_B != true && slot3_B != true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num6].cardPlace = "card slot1";
                            if (Background.number_of_cards_in_card_slot1 != 0)
                                redoCardsNumbersInPile(false, "card slot1", true);

                            CardsData.cardsData[num6].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot1++;
                            redoCardsNumbersInPile(false, "pile 6", false);   Game1.score += 20;
                        }
                        #endregion

                        #region 2ed empty
                        if (slot1_B != true && slot2_B == true && slot3_B != true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num6].cardPlace = "card slot2";
                            if (Background.number_of_cards_in_card_slot2 != 0)
                                redoCardsNumbersInPile(false, "card slot2", true);

                            CardsData.cardsData[num6].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot2++;
                            redoCardsNumbersInPile(false, "pile 6", false);   Game1.score += 20;
                        }
                        #endregion

                        #region 3ed empty
                        if (slot1_B != true && slot2_B != true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num6].cardPlace = "card slot3";
                            if (Background.number_of_cards_in_card_slot3 != 0)
                                redoCardsNumbersInPile(false, "card slot3", true);

                            CardsData.cardsData[num6].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot3++;
                            redoCardsNumbersInPile(false, "pile 6", false);   Game1.score += 20;
                        }
                        #endregion

                        #region 4th empty
                        if (slot1_B != true && slot2_B != true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num6].cardPlace = "card slot4";
                            if (Background.number_of_cards_in_card_slot4 != 0)
                                redoCardsNumbersInPile(false, "card slot4", true);

                            CardsData.cardsData[num6].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot4++;
                            redoCardsNumbersInPile(false, "pile 6", false);   Game1.score += 20;

                        }
                        #endregion

                        #endregion
                    }
                    #endregion
                }
                #endregion

                #region pile7 (num7)
                if (num7 != -10)
                {
                    #region setup
                    slot1_B = false;
                    slot2_B = false;
                    slot3_B = false;
                    slot4_B = false;

                    if (CardsData.cardsData[num7].cardNumber == Background.number_of_cards_in_card_slot1 + 1)
                    {
                        slot1_B = true;
                    }
                    if (CardsData.cardsData[num7].cardNumber == Background.number_of_cards_in_card_slot2 + 1)
                    {
                        slot2_B = true;
                    }
                    if (CardsData.cardsData[num7].cardNumber == Background.number_of_cards_in_card_slot3 + 1)
                    {
                        slot3_B = true;
                    }
                    if (CardsData.cardsData[num7].cardNumber == Background.number_of_cards_in_card_slot4 + 1)
                    {
                        slot4_B = true;
                    }
                    #endregion


                    #region  if card must be in one slot (already are cards from his symbol and number-1;
                    if (CardsData.cardsData[num7].cardSymbol == slot1_S && slot1_B == true)
                    {
                        CardsData.cardsData[num7].cardPlace = "card slot1";
                        redoCardsNumbersInPile(false, "card slot1", true);
                        CardsData.cardsData[num7].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot1++;
                        redoCardsNumbersInPile(false, "pile 7", false);   Game1.score += 20;
                    }

                    if (CardsData.cardsData[num7].cardSymbol == slot2_S && slot2_B == true)
                    {
                        CardsData.cardsData[num7].cardPlace = "card slot2";
                        redoCardsNumbersInPile(false, "card slot2", true);
                        CardsData.cardsData[num7].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot2++;
                        redoCardsNumbersInPile(false, "pile 7", false);   Game1.score += 20;
                    }
                    if (CardsData.cardsData[num7].cardSymbol == slot3_S && slot3_B == true)
                    {
                        CardsData.cardsData[num7].cardPlace = "card slot3";
                        redoCardsNumbersInPile(false, "card slot3", true);
                        CardsData.cardsData[num7].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot3++;
                        redoCardsNumbersInPile(false, "pile 7", false);   Game1.score += 20;
                    }

                    if (CardsData.cardsData[num7].cardSymbol == slot4_S && slot4_B == true)
                    {
                        CardsData.cardsData[num7].cardPlace = "card slot4";
                        redoCardsNumbersInPile(false, "card slot4", true);
                        CardsData.cardsData[num7].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot4++;
                        redoCardsNumbersInPile(false, "pile 7", false);   Game1.score += 20;
                    }
                    #endregion


                    #region if card doesnt fit anywhere but is an A and there's an empty slot
                    if (CardsData.cardsData[num7].cardNumber == 1 && CardsData.cardsData[num7].cardSymbol != slot1_S && CardsData.cardsData[num7].cardSymbol != slot2_S && CardsData.cardsData[num7].cardSymbol != slot3_S && CardsData.cardsData[num7].cardSymbol != slot4_S)
                    {
                        //fits X slots means that the card doesnt fit in any non-0-cards-on slot, but has X 0 slots to go to.

                        #region 4 empty slots
                        if (slot1_B == true && slot2_B == true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(3);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num7].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num7].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num7].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;

                                case 4: CardsData.cardsData[num7].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 7", false);   Game1.score += 20;
                        }
                        #endregion

                        #region 3 empty slots

                        #region not 4th
                        if (slot1_B == true && slot2_B == true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num7].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num7].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num7].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 7", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 3ed
                        if (slot1_B == true && slot2_B == true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num7].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num7].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num7].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 7", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 2ed
                        if (slot1_B == true && slot2_B != true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num7].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num7].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;

                                case 3: CardsData.cardsData[num7].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 7", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 1st
                        if (slot1_B != true && slot2_B == true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num7].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;

                                case 2: CardsData.cardsData[num7].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[num7].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 7", false);   Game1.score += 20;
                        }
                        #endregion

                        #endregion

                        #region 2 empty slots

                        #region not 1st and 2ed
                        if (slot1_B != true && slot2_B != true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num7].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;

                                case 2: CardsData.cardsData[num7].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 7", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 1st and 3ed
                        if (slot1_B != true && slot2_B == true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num7].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 2: CardsData.cardsData[num7].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 7", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 1st and 4th
                        if (slot1_B != true && slot2_B == true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num7].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 2: CardsData.cardsData[num7].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 7", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 2ed and 3ed
                        if (slot1_B == true && slot2_B != true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num7].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num7].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 7", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 2ed and 4th
                        if (slot1_B == true && slot2_B != true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num7].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num7].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 7", false);   Game1.score += 20;
                        }
                        #endregion

                        #region not 3ed and 4th
                        if (slot1_B == true && slot2_B == true && slot3_B != true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[num7].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[num7].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[num7].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "pile 7", false);   Game1.score += 20;
                        }
                        #endregion

                        #endregion

                        #region one empty

                        #region 1st empty
                        if (slot1_B == true && slot2_B != true && slot3_B != true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num7].cardPlace = "card slot1";
                            if (Background.number_of_cards_in_card_slot1 != 0)
                                redoCardsNumbersInPile(false, "card slot1", true);

                            CardsData.cardsData[num7].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot1++;
                            redoCardsNumbersInPile(false, "pile 7", false);   Game1.score += 20;
                        }
                        #endregion

                        #region 2ed empty
                        if (slot1_B != true && slot2_B == true && slot3_B != true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num7].cardPlace = "card slot2";
                            if (Background.number_of_cards_in_card_slot2 != 0)
                                redoCardsNumbersInPile(false, "card slot2", true);

                            CardsData.cardsData[num7].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot2++;
                            redoCardsNumbersInPile(false, "pile 7", false);   Game1.score += 20;
                        }
                        #endregion

                        #region 3ed empty
                        if (slot1_B != true && slot2_B != true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num7].cardPlace = "card slot3";
                            if (Background.number_of_cards_in_card_slot3 != 0)
                                redoCardsNumbersInPile(false, "card slot3", true);

                            CardsData.cardsData[num7].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot3++;
                            redoCardsNumbersInPile(false, "pile 7", false);   Game1.score += 20;
                        }
                        #endregion

                        #region 4th empty
                        if (slot1_B != true && slot2_B != true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[num7].cardPlace = "card slot4";
                            if (Background.number_of_cards_in_card_slot4 != 0)
                                redoCardsNumbersInPile(false, "card slot4", true);

                            CardsData.cardsData[num7].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot4++;
                            redoCardsNumbersInPile(false, "pile 7", false);   Game1.score += 20;
                        }
                        #endregion

                        #endregion
                    }
                    #endregion
                }
                #endregion

                #region left Deck (numLeftDeck)
                if (numLeftDeck != -10)
                {
                    #region setup
                    slot1_B = false;
                    slot2_B = false;
                    slot3_B = false;
                    slot4_B = false;

                    if (CardsData.cardsData[numLeftDeck].cardNumber == Background.number_of_cards_in_card_slot1 + 1)
                    {
                        slot1_B = true;
                    }
                    if (CardsData.cardsData[numLeftDeck].cardNumber == Background.number_of_cards_in_card_slot2 + 1)
                    {
                        slot2_B = true;
                    }
                    if (CardsData.cardsData[numLeftDeck].cardNumber == Background.number_of_cards_in_card_slot3 + 1)
                    {
                        slot3_B = true;
                    }
                    if (CardsData.cardsData[numLeftDeck].cardNumber == Background.number_of_cards_in_card_slot4 + 1)
                    {
                        slot4_B = true;
                    }
                    #endregion


                    #region  if card must be in one slot (already are cards from his symbol and number-1;
                    if (CardsData.cardsData[numLeftDeck].cardSymbol == slot1_S && slot1_B == true)
                    {
                        CardsData.cardsData[numLeftDeck].cardPlace = "card slot1";
                        redoCardsNumbersInPile(false, "card slot1", true);
                        CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot1++;
                        redoCardsNumbersInPile(false, "left Deck", false); Background.number_of_cards_in_left_deck--;  Game1.score += 20;

                        Game1.score += 20;
                    }

                    if (CardsData.cardsData[numLeftDeck].cardSymbol == slot2_S && slot2_B == true)
                    {
                        CardsData.cardsData[numLeftDeck].cardPlace = "card slot2";
                        redoCardsNumbersInPile(false, "card slot2", true);
                        CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot2++;
                        redoCardsNumbersInPile(false, "left Deck", false); Background.number_of_cards_in_left_deck--;  Game1.score += 20;

                        Game1.score += 20;
                    }
                    if (CardsData.cardsData[numLeftDeck].cardSymbol == slot3_S && slot3_B == true)
                    {
                        CardsData.cardsData[numLeftDeck].cardPlace = "card slot3";
                        redoCardsNumbersInPile(false, "card slot3", true);
                        CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot3++;
                        redoCardsNumbersInPile(false, "left Deck", false); Background.number_of_cards_in_left_deck--;  Game1.score += 20;

                        Game1.score += 20;
                    }

                    if (CardsData.cardsData[numLeftDeck].cardSymbol == slot4_S && slot4_B == true)
                    {
                        CardsData.cardsData[numLeftDeck].cardPlace = "card slot4";
                        redoCardsNumbersInPile(false, "card slot4", true);
                        CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                        Background.number_of_cards_in_card_slot4++;
                        redoCardsNumbersInPile(false, "left Deck", false); Background.number_of_cards_in_left_deck--;  Game1.score += 20;

                        Game1.score += 20;
                    }
                    #endregion


                    #region if card doesnt fit anywhere but is an A and there's an empty slot
                    if (CardsData.cardsData[numLeftDeck].cardNumber == 1 && CardsData.cardsData[numLeftDeck].cardSymbol != slot1_S && CardsData.cardsData[numLeftDeck].cardSymbol != slot2_S && CardsData.cardsData[numLeftDeck].cardSymbol != slot3_S && CardsData.cardsData[numLeftDeck].cardSymbol != slot4_S)
                    {
                        //fits X slots means that the card doesnt fit in any non-0-cards-on slot, but has X 0 slots to go to.

                        #region 4 empty slots
                        if (slot1_B == true && slot2_B == true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(3);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[numLeftDeck].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[numLeftDeck].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[numLeftDeck].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;

                                case 4: CardsData.cardsData[numLeftDeck].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "left Deck", false); Background.number_of_cards_in_left_deck--;  Game1.score += 20;

                            Game1.score += 20;
                        }
                        #endregion

                        #region 3 empty slots

                        #region not 4th
                        if (slot1_B == true && slot2_B == true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[numLeftDeck].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[numLeftDeck].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[numLeftDeck].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "left Deck", false); Background.number_of_cards_in_left_deck--;  Game1.score += 20;
                        }
                        #endregion

                        #region not 3ed
                        if (slot1_B == true && slot2_B == true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[numLeftDeck].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[numLeftDeck].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[numLeftDeck].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "left Deck", false); Background.number_of_cards_in_left_deck--;  Game1.score += 20;
                        }
                        #endregion

                        #region not 2ed
                        if (slot1_B == true && slot2_B != true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[numLeftDeck].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[numLeftDeck].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;

                                case 3: CardsData.cardsData[numLeftDeck].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "left Deck", false); Background.number_of_cards_in_left_deck--;  Game1.score += 20;
                        }
                        #endregion

                        #region not 1st
                        if (slot1_B != true && slot2_B == true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(2);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[numLeftDeck].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;

                                case 2: CardsData.cardsData[numLeftDeck].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 3: CardsData.cardsData[numLeftDeck].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "left Deck", false); Background.number_of_cards_in_left_deck--;  Game1.score += 20;
                        }
                        #endregion

                        #endregion

                        #region 2 empty slots

                        #region not 1st and 2ed
                        if (slot1_B != true && slot2_B != true && slot3_B == true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[numLeftDeck].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;

                                case 2: CardsData.cardsData[numLeftDeck].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "left Deck", false); Background.number_of_cards_in_left_deck--;  Game1.score += 20;
                        }
                        #endregion

                        #region not 1st and 3ed
                        if (slot1_B != true && slot2_B == true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[numLeftDeck].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 2: CardsData.cardsData[numLeftDeck].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "left Deck", false); Background.number_of_cards_in_left_deck--;  Game1.score += 20;
                        }
                        #endregion

                        #region not 1st and 4th
                        if (slot1_B != true && slot2_B == true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[numLeftDeck].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;

                                case 2: CardsData.cardsData[numLeftDeck].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "left Deck", false); Background.number_of_cards_in_left_deck--;  Game1.score += 20;
                        }
                        #endregion

                        #region not 2ed and 3ed
                        if (slot1_B == true && slot2_B != true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[numLeftDeck].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[numLeftDeck].cardPlace = "card slot4";
                                    if (Background.number_of_cards_in_card_slot4 != 0)
                                        redoCardsNumbersInPile(false, "card slot4", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot4++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "left Deck", false); Background.number_of_cards_in_left_deck--;  Game1.score += 20;
                        }
                        #endregion

                        #region not 2ed and 4th
                        if (slot1_B == true && slot2_B != true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[numLeftDeck].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[numLeftDeck].cardPlace = "card slot3";
                                    if (Background.number_of_cards_in_card_slot3 != 0)
                                        redoCardsNumbersInPile(false, "card slot3", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot3++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "left Deck", false); Background.number_of_cards_in_left_deck--;  Game1.score += 20;
                        }
                        #endregion

                        #region not 3ed and 4th
                        if (slot1_B == true && slot2_B == true && slot3_B != true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;
                            switch (random)
                            {
                                case 1: CardsData.cardsData[numLeftDeck].cardPlace = "card slot1";
                                    if (Background.number_of_cards_in_card_slot1 != 0)
                                        redoCardsNumbersInPile(false, "card slot1", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot1++;
                                    break;

                                case 2: CardsData.cardsData[numLeftDeck].cardPlace = "card slot2";
                                    if (Background.number_of_cards_in_card_slot2 != 0)
                                        redoCardsNumbersInPile(false, "card slot2", true);

                                    CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                                    Background.number_of_cards_in_card_slot2++;
                                    break;
                            }
                            redoCardsNumbersInPile(false, "left Deck", false); Background.number_of_cards_in_left_deck--;  Game1.score += 20;
                        }
                        #endregion

                        #endregion

                        #region one empty

                        #region 1st empty
                        if (slot1_B == true && slot2_B != true && slot3_B != true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[numLeftDeck].cardPlace = "card slot1";
                            if (Background.number_of_cards_in_card_slot1 != 0)
                                redoCardsNumbersInPile(false, "card slot1", true);

                            CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot1++;
                            redoCardsNumbersInPile(false, "left Deck", false); Background.number_of_cards_in_left_deck--;  Game1.score += 20;
                        }
                        #endregion

                        #region 2ed empty
                        if (slot1_B != true && slot2_B == true && slot3_B != true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[numLeftDeck].cardPlace = "card slot2";
                            if (Background.number_of_cards_in_card_slot2 != 0)
                                redoCardsNumbersInPile(false, "card slot2", true);

                            CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot2++;
                            redoCardsNumbersInPile(false, "left Deck", false); Background.number_of_cards_in_left_deck--;  Game1.score += 20;
                        }
                        #endregion

                        #region 3ed empty
                        if (slot1_B != true && slot2_B != true && slot3_B == true && slot4_B != true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[numLeftDeck].cardPlace = "card slot3";
                            if (Background.number_of_cards_in_card_slot3 != 0)
                                redoCardsNumbersInPile(false, "card slot3", true);

                            CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot3++;
                            redoCardsNumbersInPile(false, "left Deck", false); Background.number_of_cards_in_left_deck--;  Game1.score += 20;
                        }
                        #endregion

                        #region 4th empty
                        if (slot1_B != true && slot2_B != true && slot3_B != true && slot4_B == true)
                        {
                            random = rand.Next(1);
                            random++;

                            CardsData.cardsData[numLeftDeck].cardPlace = "card slot4";
                            if (Background.number_of_cards_in_card_slot4 != 0)
                                redoCardsNumbersInPile(false, "card slot4", true);

                            CardsData.cardsData[numLeftDeck].cardPlaceInPile = 1;
                            Background.number_of_cards_in_card_slot4++;
                            redoCardsNumbersInPile(false, "left Deck", false); Background.number_of_cards_in_left_deck--;  Game1.score += 20;
                        }
                        #endregion

                        #endregion
                    }
                    #endregion
                }
                #endregion


            }
        }






        public static bool check_if_card_moving()
        {
            for (int i = 0; i < 52; i++)
            {
                if (CardsData.cardsData[i].cardPlace == "Moving" || CardsData.cardsData[i].cardPlace == "M Moving")
                {
                    return true;
                }
            }
            return false;
        }

        public static bool check_if_card_fits(int cardNum, string pile, bool pile_OR_slot) // false == slot
        {
            color = CardsData.cardsData[cardNum].cardColor;
            symbol = CardsData.cardsData[cardNum].cardSymbol;
            number = CardsData.cardsData[cardNum].cardNumber;

            P_cardNum = check_which_card_is_first(1, pile, true);
            if (P_cardNum != -10)
            {
                P_color = CardsData.cardsData[P_cardNum].cardColor;
                P_number = CardsData.cardsData[P_cardNum].cardNumber;
                P_symbol = CardsData.cardsData[P_cardNum].cardSymbol;

                if (pile_OR_slot == false)
                {
                    if (symbol == P_symbol)
                    {
                        if (number == (P_number + 1))
                        {
                            return true;
                        }
                    }
                }

                if (pile_OR_slot == true)
                {
                    if (color != P_color)
                    {
                        if (number == (P_number - 1))
                        {
                            return true;
                        }
                    }
                }
            }


            if (P_cardNum == -10)
            {
                if (number == 1 && pile_OR_slot == false)
                {
                    return true;
                }
                if (number == 13 && pile_OR_slot == true)
                {
                    return true;
                }
            }
            return false;
        }

        public static int check_which_card_is_first(int num, string movedFrom, bool for_fits)
        {
            //num == 1 [probably]
            int cardToReturn = (-10);
            if (for_fits == false)
            {
                for (int i = 0; i < 52; i++)
                {
                    if (CardsData.cardsData[i].cardPlace == movedFrom)
                    {
                        if (CardsData.cardsData[i].cardPlaceInPile == num)
                        {
                            cardToReturn = i;
                        }
                    }
                }
            }

            if (for_fits == true)
            {
                for (int i = 0; i < 52; i++)
                {
                    if (CardsData.cardsData[i].cardPlace == movedFrom)
                    {
                        if (CardsData.cardsData[i].cardPlaceInPile == num)
                        {
                            if (CardsData.cardsData[i].isUp == true)
                            {
                                cardToReturn = i;
                            }
                        }
                    }
                }
            }

            return cardToReturn;
        }

        public static void redoCardsNumbersInPile(bool deck, string pile, bool updown /*true=up*/)
        {
            for (int y = 0; y < 52; y++)
            {
                if (CardsData.cardsData[y].cardPlace == pile)
                {
                    switch (updown)
                    {
                        case true: CardsData.cardsData[y].cardPlaceInPile++; break;
                        case false: CardsData.cardsData[y].cardPlaceInPile--; break;
                    }
                }
            }
        }
    }
}