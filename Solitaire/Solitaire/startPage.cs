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
    class startPage
    {
        static SpriteBatch spriteBatch;
        GraphicsDevice device;
        GraphicsDeviceManager graphics;
        public static Texture2D newGame_Tex, exit_Tex, title_Tex, options_Tex, black, optionTab_Tex, continue_Tex, color_Black, color_White, color_Blue;
        public static Texture2D timeYES, timeNO, scoreYES, scoreNO, timeToScore, timeNotToScore;
        static Texture2D optionTab_Tex_b;

        public static bool isExit = false;
        public static bool isOptionsTab = false;
        public static bool was_NewGamePressed = false;  // so it can be changed to 'continue'

        public static bool isNewGame_Presses = false;
        public static bool isContinue_Pressed = false;


        static bool banana_B;
        static bool banana_a;
        static bool banana_n;
        static bool banana_a2;
        static bool banana_n2;
        static bool banana_a3;
        static bool isOption_tab_real = false;
        static int color = 1; // 1:blue, 2:black, 3:white
        public static bool time = true;
        public static bool score = true;
        public static bool timeToScoreBOOL = true;



        public startPage(ContentManager content)
        {
            spriteBatch = Game1.spriteBatch;
            device = Game1.device;
            graphics = Game1.graphics;
            newGame_Tex = content.Load<Texture2D>("startPage/New-Game_BIG");
            exit_Tex = content.Load<Texture2D>("startPage/Exit_BIG");
            title_Tex = content.Load<Texture2D>("startPage/koteret");
            options_Tex = content.Load<Texture2D>("startPage/options");
            black = content.Load<Texture2D>("black");
            optionTab_Tex = content.Load<Texture2D>("startPage/optionTab");
            optionTab_Tex_b = content.Load<Texture2D>("startPage/optionTab_B");
            continue_Tex = content.Load<Texture2D>("startPage/continue");
            color_Black = content.Load<Texture2D>("startPage/color_Black");
            color_Blue = content.Load<Texture2D>("startPage/color_Blue");
            color_White = content.Load<Texture2D>("startPage/color_White");
            timeYES = content.Load<Texture2D>("startPage/time_YES");
            timeNO = content.Load<Texture2D>("startPage/Time_NO");
            scoreYES = content.Load<Texture2D>("startPage/score_YES");
            scoreNO = content.Load<Texture2D>("startPage/score_NO");
            timeToScore = content.Load<Texture2D>("startPage/TimeToScore");
            timeNotToScore = content.Load<Texture2D>("startPage/TimeNotToScore");
        }

        public void draw_StartPage()
        {
            #region New Game
            #region big or small
            if ((Game1.mouseCurrentPos.X <= 446)
                                    && (Game1.mouseCurrentPos.X >= 249)
                                    && (Game1.mouseCurrentPos.Y <= 381)
                                    && (Game1.mouseCurrentPos.Y >= 360))
            {
                spriteBatch.Draw(newGame_Tex, new Vector2(345, 370), null, Color.White, 0, new Vector2(86, 20), 0.9f, SpriteEffects.None, 1);
            }

            else
            {
                spriteBatch.Draw(newGame_Tex, new Vector2(345, 370), null, Color.White, 0, new Vector2(86, 20), 0.7f, SpriteEffects.None, 1);
            }
            #endregion

            #region press
            if (isNewGame_Presses == true)
            {
                Game1.is_Start_Page = false;


                if (was_NewGamePressed == true)
                {
                    Game1.restart_game();
                    Game1.stopWatch.Restart();
                }
                else Game1.stopWatch.Start();

                isNewGame_Presses = false;
            }
            #endregion

            #endregion

            #region continue
            if (was_NewGamePressed == true)
            {
                if ((Game1.mouseCurrentPos.X <= 410)
                                        && (Game1.mouseCurrentPos.X >= 290)
                                        && (Game1.mouseCurrentPos.Y <= 450)
                                        && (Game1.mouseCurrentPos.Y >= 430))
                {
                    spriteBatch.Draw(continue_Tex, new Vector2(350, 440), null, Color.White, 0, new Vector2(70, 15), 1.1f, SpriteEffects.None, 1);
                }
                else
                    spriteBatch.Draw(continue_Tex, new Vector2(350, 440), null, Color.White, 0, new Vector2(70, 15), 0.9f, SpriteEffects.None, 1);


                if (isContinue_Pressed == true)
                {
                    Game1.is_Start_Page = false;
                    isNewGame_Presses = false;
                }
            }
            #endregion

            #region Exit
            if ((Game1.mouseCurrentPos.X <= 374)
                                    && (Game1.mouseCurrentPos.X >= 326)
                                    && (Game1.mouseCurrentPos.Y <= 612)
                                    && (Game1.mouseCurrentPos.Y >= 587))
            {
                spriteBatch.Draw(exit_Tex, new Vector2(350, 600), null, Color.White, 0, new Vector2(26, 16), 1, SpriteEffects.None, 1);

                if (Game1.mouseCurrentPos.LeftButton == ButtonState.Pressed)
                {
                    isExit = true;
                }
            }
            else
            {
                spriteBatch.Draw(exit_Tex, new Vector2(350, 600), null, Color.White, 0, new Vector2(26, 16), 0.8f, SpriteEffects.None, 1);
            }
            #endregion

            #region title
            spriteBatch.Draw(title_Tex, new Vector2(350, 190), null, Color.White, 0, new Vector2(140, 40), 1, SpriteEffects.None, 1);
            #endregion

            #region options
            if ((Game1.mouseCurrentPos.X <= 404)
                                && (Game1.mouseCurrentPos.X >= 297)
                                && (Game1.mouseCurrentPos.Y <= 550)
                                && (Game1.mouseCurrentPos.Y >= 536))
            {
                spriteBatch.Draw(options_Tex, new Vector2(350, 550), null, Color.White, 0, new Vector2(59, 18), 1, SpriteEffects.None, 1);

                if (Game1.mouseCurrentPos.LeftButton == ButtonState.Pressed)
                {
                    isOptionsTab = true;
                }
            }
            else
            {
                spriteBatch.Draw(options_Tex, new Vector2(350, 550), null, Color.White, 0, new Vector2(59, 18), 0.8f, SpriteEffects.None, 1);
            }


            #endregion

            draw_options_tab();
        }

        public void draw_options_tab()
        {
            if (isOptionsTab == true)
            {
                spriteBatch.Draw(black, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);


                #region monkey
                if (isOption_tab_real == false)
                {
                    spriteBatch.Draw(optionTab_Tex_b, new Vector2(350, 400), null, Color.White, 0, new Vector2(100, 143), 1, SpriteEffects.None, 0);

                    if (Game1.keybstate.IsKeyDown(Keys.Escape))
                    {
                        isOptionsTab = false;
                    }

                }
                #endregion


                #region banana
                if (Game1.keybstate.IsKeyDown(Keys.B))
                {
                    banana_B = true;
                }
                if (banana_B == true && Game1.keybstate.IsKeyDown(Keys.A))
                {
                    banana_a = true;
                }
                if (banana_a == true && Game1.keybstate.IsKeyDown(Keys.N))
                {
                    banana_n = true;
                }
                if (banana_n == true && Game1.keybstate.IsKeyDown(Keys.A))
                {
                    banana_a2 = true;
                }
                if (banana_a2 == true && Game1.keybstate.IsKeyDown(Keys.N))
                {
                    banana_n2 = true;
                }
                if (banana_n2 == true && Game1.keybstate.IsKeyDown(Keys.A))
                {
                    banana_a3 = true;
                }



                if (banana_a3 == true)
                {
                    isOption_tab_real = true;
                }
                #endregion


                #region real

                if (isOption_tab_real == true)
                {
                    spriteBatch.Draw(optionTab_Tex, new Vector2(350, 400), null, Color.White, 0, new Vector2(100, 143), 1, SpriteEffects.None, 0);

                    #region color
                    switch (color)
                    {
                        case 1: spriteBatch.Draw(color_Blue, new Vector2(350, 350), null, Color.White, 0, new Vector2(50, 12), 1, SpriteEffects.None, 0); Textures.backside = Textures.backside_Blue; break;
                        case 2: spriteBatch.Draw(color_Black, new Vector2(350, 350), null, Color.White, 0, new Vector2(50, 12), 1, SpriteEffects.None, 0); Textures.backside = Textures.backside_Black; break;
                        case 3: spriteBatch.Draw(color_White, new Vector2(350, 350), null, Color.White, 0, new Vector2(50, 12), 1, SpriteEffects.None, 0); Textures.backside = Textures.backside_White; break;
                    }
                    #endregion


                    #region time
                    switch (time)
                    {
                        case true: spriteBatch.Draw(timeYES, new Vector2(350, 430), null, Color.White, 0, new Vector2(48, 15), 0.9f, SpriteEffects.None, 0); break;
                        case false: spriteBatch.Draw(timeNO, new Vector2(350, 430), null, Color.White, 0, new Vector2(48, 15), 0.9f, SpriteEffects.None, 0); break;
                    }
                    #endregion


                    #region score
                    switch (score)
                    {
                        case true: spriteBatch.Draw(scoreYES, new Vector2(350, 400), null, Color.White, 0, new Vector2(47, 16), 0.9f, SpriteEffects.None, 0); break;
                        case false: spriteBatch.Draw(scoreNO, new Vector2(350, 400), null, Color.White, 0, new Vector2(47, 16), 0.9f, SpriteEffects.None, 0); break;
                    }
                    #endregion


                    #region time && score

                    if (time == true && score == true)
                    {
                        switch (timeToScoreBOOL)
                        {
                            case true: spriteBatch.Draw(timeToScore, new Vector2(350, 460), null, Color.White, 0, new Vector2(71, 21), 0.9f, SpriteEffects.None, 0); break;
                            case false: spriteBatch.Draw(timeNotToScore, new Vector2(350, 460), null, Color.White, 0, new Vector2(71, 21), 0.9f, SpriteEffects.None, 0); break;
                        }
                    }

                    #endregion


                    #region exit key
                    if (Game1.keybstate.IsKeyDown(Keys.Escape))
                    {
                        isOption_tab_real = false;
                    }
                    #endregion
                }
                #endregion
            }
        }



        public static void get_mousestate()
        {
            if (Game1.mouseCurrentPos.LeftButton == ButtonState.Pressed && Game1.mousePreviousPos.LeftButton == ButtonState.Released)
            {
                #region new game
                if ((Game1.mouseCurrentPos.X <= 446)
                                        && (Game1.mouseCurrentPos.X >= 249)
                                        && (Game1.mouseCurrentPos.Y <= 381)
                                        && (Game1.mouseCurrentPos.Y >= 360))
                {
                    if (isOptionsTab == false && isOption_tab_real == false) { isNewGame_Presses = true; }
                }
                #endregion

                #region continue
                if ((Game1.mouseCurrentPos.X <= 410)
                                           && (Game1.mouseCurrentPos.X >= 290)
                                           && (Game1.mouseCurrentPos.Y <= 450)
                                           && (Game1.mouseCurrentPos.Y >= 430))
                {
                    if (isOptionsTab == false && isOption_tab_real == false) { isContinue_Pressed = true; Game1.stopWatch.Start(); }
                }
                #endregion





                if (isOption_tab_real == true)
                {
                    #region color
                    if ((Game1.mouseCurrentPos.X <= 395)
                                               && (Game1.mouseCurrentPos.X >= 305)
                                               && (Game1.mouseCurrentPos.Y <= 356)
                                               && (Game1.mouseCurrentPos.Y >= 344))
                    {
                        switch (color)
                        {
                            case 1: color = 2; break;
                            case 2: color = 3; break;
                            case 3: color = 1; break;
                        }

                    }
                    #endregion

                    #region time
                    if ((Game1.mouseCurrentPos.X <= 390)
                                                && (Game1.mouseCurrentPos.X >= 310)
                                                && (Game1.mouseCurrentPos.Y <= 437)
                                                && (Game1.mouseCurrentPos.Y >= 422))
                    {
                        switch (time)
                        {
                            case true: time = false; break;
                            case false: time = true; break;
                        }
                    }
                    #endregion

                    #region score
                    if ((Game1.mouseCurrentPos.X <= 392)
                                                && (Game1.mouseCurrentPos.X >= 308)
                                                && (Game1.mouseCurrentPos.Y <= 406)
                                                && (Game1.mouseCurrentPos.Y >= 391))
                    {
                        switch (score)
                        {
                            case true: score = false; break;
                            case false: score = true; break;
                        }
                    }
                    #endregion

                    #region time && score
                    if (time == true && score == true)
                    {
                        if ((Game1.mouseCurrentPos.X <= 408)
                                                            && (Game1.mouseCurrentPos.X >= 292)
                                                            && (Game1.mouseCurrentPos.Y <= 466)
                                                            && (Game1.mouseCurrentPos.Y >= 451))
                        {
                            switch (timeToScoreBOOL)
                            {
                                case true: timeToScoreBOOL = false; break;
                                case false: timeToScoreBOOL = true; break;
                            }
                        }
                    }
                    #endregion 
                }
            }
        }

    }
}
