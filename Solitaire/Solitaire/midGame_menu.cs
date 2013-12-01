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
    class midGame_menu
    {
        static SpriteBatch spriteBatch;
        GraphicsDevice device;
        GraphicsDeviceManager graphics;

        Texture2D midGame_menu_Tex, mainMenu_Tex, exit_Tex_1, Options_Tex_1, NewGame_Tex_1;
        public static bool for_mid_menu = false;
        static bool is_mainMenu_Pressed = false;
        static public bool isNewGame_Pressed_M = false;

        public midGame_menu(ContentManager content)
        {
            spriteBatch = Game1.spriteBatch;
            device = Game1.device;
            graphics = Game1.graphics;

            midGame_menu_Tex = content.Load<Texture2D>("midGameMenu/menuTab");
            mainMenu_Tex = content.Load<Texture2D>("midGameMenu/mainMenu");
            exit_Tex_1 = content.Load<Texture2D>("midGameMenu/exit");
            Options_Tex_1 = content.Load<Texture2D>("midGameMenu/options_menu");
            NewGame_Tex_1 = content.Load<Texture2D>("midGameMenu/New-Game_menu");

        }

        public void check_if_Esc()
        {
            if (Game1.is_Start_Page == false && Game1.is_End_Page == false)
            {
                if (Game1.keybstate.IsKeyDown(Keys.Escape) && Game1.prevKeybstate.IsKeyUp(Keys.Escape))
                {
                    for_mid_menu = !for_mid_menu;

                    switch (for_mid_menu)
                    {
                        case true: Game1.stopWatch.Stop();
                            break;
                        case false: Game1.stopWatch.Start();
                            break;
                    }

                    //Game1.firstTime = true;
                    //Game1.didclose = true;
                }
            }
        }

        public void draw_midMenu()
        {
            if (for_mid_menu == true)
            {
                #region the menu itself
                spriteBatch.Draw(startPage.black, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
                spriteBatch.Draw(midGame_menu_Tex, new Vector2(350, 400), null, Color.White, 0, new Vector2(100, 143), 1, SpriteEffects.None, 0);
                #endregion


                #region main menu

                if ((Game1.mouseCurrentPos.X <= 395)
                                    && (Game1.mouseCurrentPos.X >= 297)
                                    && (Game1.mouseCurrentPos.Y <= 377)
                                    && (Game1.mouseCurrentPos.Y >= 361))
                {
                    spriteBatch.Draw(mainMenu_Tex, new Vector2(345, 370), null, Color.White, 0, new Vector2(56, 12), 1, SpriteEffects.None, 0);

                    if (is_mainMenu_Pressed == true)
                    {
                        for_mid_menu = false;
                        startPage.was_NewGamePressed = true;
                        startPage.isContinue_Pressed = false;
                        Game1.is_Start_Page = true;

                        is_mainMenu_Pressed = false;

                    }
                }

                else spriteBatch.Draw(mainMenu_Tex, new Vector2(345, 370), null, Color.White, 0, new Vector2(56, 12), 0.8f, SpriteEffects.None, 0);

                #endregion


                #region New Game

                if ((Game1.mouseCurrentPos.X <= 385)
                                        && (Game1.mouseCurrentPos.X >= 308)
                                        && (Game1.mouseCurrentPos.Y <= 407)
                                        && (Game1.mouseCurrentPos.Y >= 394))
                {
                    spriteBatch.Draw(NewGame_Tex_1, new Vector2(348, 400), null, Color.White, 0, new Vector2(53, 12), 1, SpriteEffects.None, 0);

                    if (isNewGame_Pressed_M == true)
                    {
                        for_mid_menu = false;
                        Game1.restart_game();
                        isNewGame_Pressed_M = false;
                    }
                }

                else spriteBatch.Draw(NewGame_Tex_1, new Vector2(348, 400), null, Color.White, 0, new Vector2(53, 12), 0.85f, SpriteEffects.None, 0);

                #endregion


                #region exit
                if ((Game1.mouseCurrentPos.X <= 380)
                                            && (Game1.mouseCurrentPos.X >= 311)
                                            && (Game1.mouseCurrentPos.Y <= 507)
                                            && (Game1.mouseCurrentPos.Y >= 491))
                {
                    spriteBatch.Draw(exit_Tex_1, new Vector2(345, 500), null, Color.White, 0, new Vector2(45, 15), 1, SpriteEffects.None, 0);

                    if (Game1.mouseCurrentPos.LeftButton == ButtonState.Pressed)
                    {
                        startPage.isExit = true;
                    }
                }

                else spriteBatch.Draw(exit_Tex_1, new Vector2(345, 500), null, Color.White, 0, new Vector2(45, 15), 0.8f, SpriteEffects.None, 0);
                #endregion


            }
        }

        public static void get_mouse_state()
        {
            if (Game1.mouseCurrentPos.LeftButton == ButtonState.Pressed && Game1.mousePreviousPos.LeftButton == ButtonState.Released)
            {
                if ((Game1.mouseCurrentPos.X <= 395)
                                    && (Game1.mouseCurrentPos.X >= 297)
                                    && (Game1.mouseCurrentPos.Y <= 377)
                                    && (Game1.mouseCurrentPos.Y >= 361))
                {
                    is_mainMenu_Pressed = true;
                }


                if ((Game1.mouseCurrentPos.X <= 385)
                                        && (Game1.mouseCurrentPos.X >= 308)
                                        && (Game1.mouseCurrentPos.Y <= 407)
                                        && (Game1.mouseCurrentPos.Y >= 394))
                {
                    isNewGame_Pressed_M = true; Game1.stopWatch.Restart();
                }
            }
        }
    }
}
