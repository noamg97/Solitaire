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
    class Background
    {
        SpriteBatch spriteBatch;
        GraphicsDeviceManager graphics;
        GraphicsDevice device;

        public static Vector2 card_slot1, card_slot2, card_slot3, card_slot4;
        public static Vector2 pile1, pile2, pile3, pile4, pile5, pile6, pile7;
        public static Vector2 deckPos, leftDeckPos;
        
        public static int number_of_cards_in_deck = 24;
        public static int number_of_cards_in_left_deck = 0;

        public static int number_of_cards_in_card_slot1 = 0;
        public static int number_of_cards_in_card_slot2 = 0;
        public static int number_of_cards_in_card_slot3 = 0;
        public static int number_of_cards_in_card_slot4 = 0;

        public static int numberOfUpCards_pile1 = 0;
        public static int numberOfUpCards_pile2 = 0;
        public static int numberOfUpCards_pile3 = 0;
        public static int numberOfUpCards_pile4 = 0;
        public static int numberOfUpCards_pile5 = 0;
        public static int numberOfUpCards_pile6 = 0;
        public static int numberOfUpCards_pile7 = 0;

        public static int numberOfDownCards_pile1 = 0;
        public static int numberOfDownCards_pile2 = 1;
        public static int numberOfDownCards_pile3 = 2;
        public static int numberOfDownCards_pile4 = 3;
        public static int numberOfDownCards_pile5 = 4;
        public static int numberOfDownCards_pile6 = 5;
        public static int numberOfDownCards_pile7 = 6;

        Rectangle screenRectangle;


        public Background()
        {
            spriteBatch = Game1.spriteBatch;
            device = Game1.device;
            graphics = Game1.graphics;

            background_Data();
          
        }


        public void drawBackground()
        {
            screenRectangle = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);


            spriteBatch.Draw(Solitaire.Textures.backgroundTex, screenRectangle, Color.White);

            if (Game1.is_End_Page == false && Game1.is_Start_Page == false)
            {
                spriteBatch.Draw(Solitaire.Textures.cardslot, card_slot1, null, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);
                spriteBatch.Draw(Solitaire.Textures.cardslot, card_slot2, null, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);
                spriteBatch.Draw(Solitaire.Textures.cardslot, card_slot3, null, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);
                spriteBatch.Draw(Solitaire.Textures.cardslot, card_slot4, null, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);
                
            }
            //spriteBatch.Draw(Textures.line, new Vector2(725, 0), Color.White);
        }


        public void background_Data()
        {
            card_slot1 = new Vector2(-40, 0);
            card_slot2 = new Vector2(57, 0);
            card_slot3 = new Vector2(154, 0);
            card_slot4 = new Vector2(251, 0);

            pile1 = new Vector2(-40, 250);
            pile2 = new Vector2(57, 250);
            pile3 = new Vector2(154, 250);
            pile4 = new Vector2(251, 250);
            pile5 = new Vector2(347, 250);
            pile6 = new Vector2(444, 250);
            pile7 = new Vector2(541, 250);

            deckPos = new Vector2(530, 0);
            leftDeckPos = new Vector2(400, 0);
        }
    }
}
