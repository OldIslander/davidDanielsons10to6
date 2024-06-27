using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Net;


namespace davidDanielson10to6
{
    internal class Player
    {
        private Texture2D Texture { get; set; }
        private int height = 66;// David is big; he stands taller than a tile
        private int width = 54;
        private int totalFrames = 4; // David's walk cycle is 4 frames in any direction
        private int currentFrame = 0;
        private int direction = 0; // Stores the last direction walked in. Used for animation
        private int currentDelay = 0; //Animation Delay
        private int delay = 8;
        const int block = 48; // Length/height of 1 tile
        int cur = 0; //Keeps track of how many pixels have been traversed in a move
        private bool moving;
        private bool blipBlop = false;

        private Vector2 position = new Vector2(96, 106); // David Starts here
        private Vector2 incrementor; //movement incrementor

        private Vector2 up = new Vector2(0, -3);
        private Vector2 down = new Vector2(0, 3);
        private Vector2 left = new Vector2(-3, 0);
        private Vector2 right = new Vector2(3, 0);

        public Player(Texture2D texture)
        {
            Texture = texture;
        }

        private bool ArrowKeyDown() //This function checks if any of the arrow keys are being pressed. Cleans up other functions which use this logic =)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Down) || 
                Keyboard.GetState().IsKeyDown(Keys.Up) ||
                Keyboard.GetState().IsKeyDown(Keys.Left) || 
                Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                return true;
            }

            return false;
        }

        public void Update()
        {
            //if not moving and movement keys are pressed, start moving in the given direction
            if (!moving && ArrowKeyDown())
            {
                moving = true;

                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    incrementor = down;
                    direction = 0;

                }

                else if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    incrementor = up;
                    direction = 1;

                }

                else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    incrementor = right;
                    direction = 2;

                }

                else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    incrementor = left;
                    direction = 3;

                }
            }

            if (moving)
            {
                currentDelay++;
                if (currentDelay > delay)
                {
                    currentDelay = 0;
                    currentFrame++;
                }

                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
                blipBlop = !blipBlop;
                if (blipBlop)
                {
                    position += incrementor;
                    cur += 3;

                    if (cur == block)
                    {
                        cur = 0;
                        moving = false;

                    }
                }
            }

            else
            {
                currentFrame = 0;
            }

        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, Microsoft.Xna.Framework.Graphics.SamplerState.PointClamp, null, null, null, null);
            Rectangle sourceRectangle = new Rectangle(width * currentFrame, height * direction, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 54, 66);


            _spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

            _spriteBatch.End();
        }


    }
}
