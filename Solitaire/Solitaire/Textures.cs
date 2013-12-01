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
    class Textures
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;

        public static Texture2D h1, h2, h3, h4, h5, h6, h7, h8, h9, h10, hJ, hQ, hK;
        public static Texture2D s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, sJ, sQ, sK;
        public static Texture2D c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, cJ, cQ, cK;
        public static Texture2D d1, d2, d3, d4, d5, d6, d7, d8, d9, d10, dJ, dQ, dK;
        public static Texture2D cardslot, backgroundTex, cardslot_2;
        public static Texture2D backside, backside_Black, backside_White, backside_Blue;

        public Textures(ContentManager content)
        {
            graphics = Game1.graphics;
            spriteBatch = Game1.spriteBatch;
            device = graphics.GraphicsDevice;

            cards_Texs(content);
            background_Texs(content);
        }

        public void cards_Texs(ContentManager content)
        {
            h1 = content.Load<Texture2D>("cards/hearts/h1"); h2 = content.Load<Texture2D>("cards/hearts/h2"); h3 = content.Load<Texture2D>("cards/hearts/h3"); h4 = content.Load<Texture2D>("cards/hearts/h4"); h5 = content.Load<Texture2D>("cards/hearts/h5"); h6 = content.Load<Texture2D>("cards/hearts/h6"); h7 = content.Load<Texture2D>("cards/hearts/h7"); h8 = content.Load<Texture2D>("cards/hearts/h8"); h9 = content.Load<Texture2D>("cards/hearts/h9"); h10 = content.Load<Texture2D>("cards/hearts/h10"); hJ = content.Load<Texture2D>("cards/hearts/hJ"); hQ = content.Load<Texture2D>("cards/hearts/hQ"); hK = content.Load<Texture2D>("cards/hearts/hK");
            c1 = content.Load<Texture2D>("cards/clubs/c1"); c2 = content.Load<Texture2D>("cards/clubs/c2"); c3 = content.Load<Texture2D>("cards/clubs/c3"); c4 = content.Load<Texture2D>("cards/clubs/c4"); c5 = content.Load<Texture2D>("cards/clubs/c5"); c6 = content.Load<Texture2D>("cards/clubs/c6"); c7 = content.Load<Texture2D>("cards/clubs/c7"); c8 = content.Load<Texture2D>("cards/clubs/c8"); c9 = content.Load<Texture2D>("cards/clubs/c9"); c10 = content.Load<Texture2D>("cards/clubs/c10"); cJ = content.Load<Texture2D>("cards/clubs/cJ"); cQ = content.Load<Texture2D>("cards/clubs/cQ"); cK = content.Load<Texture2D>("cards/clubs/cK");
            s1 = content.Load<Texture2D>("cards/spades/s1"); s2 = content.Load<Texture2D>("cards/spades/s2"); s3 = content.Load<Texture2D>("cards/spades/s3"); s4 = content.Load<Texture2D>("cards/spades/s4"); s5 = content.Load<Texture2D>("cards/spades/s5"); s6 = content.Load<Texture2D>("cards/spades/s6"); s7 = content.Load<Texture2D>("cards/spades/s7"); s8 = content.Load<Texture2D>("cards/spades/s8"); s9 = content.Load<Texture2D>("cards/spades/s9"); s10 = content.Load<Texture2D>("cards/spades/s10"); sJ = content.Load<Texture2D>("cards/spades/sJ"); sQ = content.Load<Texture2D>("cards/spades/sQ"); sK = content.Load<Texture2D>("cards/spades/sK");
            d1 = content.Load<Texture2D>("cards/diamonds/d1"); d2 = content.Load<Texture2D>("cards/diamonds/d2"); d3 = content.Load<Texture2D>("cards/diamonds/d3"); d4 = content.Load<Texture2D>("cards/diamonds/d4"); d5 = content.Load<Texture2D>("cards/diamonds/d5"); d6 = content.Load<Texture2D>("cards/diamonds/d6"); d7 = content.Load<Texture2D>("cards/diamonds/d7"); d8 = content.Load<Texture2D>("cards/diamonds/d8"); d9 = content.Load<Texture2D>("cards/diamonds/d9"); d10 = content.Load<Texture2D>("cards/diamonds/d10"); dJ = content.Load<Texture2D>("cards/diamonds/dJ"); dQ = content.Load<Texture2D>("cards/diamonds/dQ"); dK = content.Load<Texture2D>("cards/diamonds/dK");

            backside_Blue = content.Load<Texture2D>("backside");
            backside_Black = content.Load<Texture2D>("backside_Black");
            backside_White = content.Load<Texture2D>("backside_White");

            backside = backside_Blue;
        }

        public void background_Texs(ContentManager content)
        {
            backgroundTex = content.Load<Texture2D>("solitair-background");
            cardslot = content.Load<Texture2D>("card----");
            cardslot_2 = content.Load<Texture2D>("card---2");
        }
    }
}
