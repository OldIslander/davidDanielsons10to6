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
        private int delay = 6;
        
        const int block = 48; // Length/height of 1 tile
        int cur = 0; //Keeps track of how many pixels have been traversed in a move
        private bool moving;
        private bool pushing;

        private Vector2 position = new Vector2(240, 115); // David Starts here
        public Vector2 positionCoordinates = new Vector2(5, 3);

        public Vector4 collision = new Vector4(0,0,0,0);

        private Vector2 incrementor; //movement incrementor
        private Vector2 up = new Vector2(0, -2);
        private Vector2 down = new Vector2(0, 2);
        private Vector2 left = new Vector2(-2, 0);
        private Vector2 right = new Vector2(2, 0);

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
            //Checking for collisions first

            //if not moving and movement keys are pressed, start moving in the given direction
            if (!moving && ArrowKeyDown())
            {
             
                moving = true;

                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    positionCoordinates.Y++;
                    if (collision.X == 1)
                    {
                        positionCoordinates.Y--;
                        moving = false;
                    }

                    incrementor = down;
                    direction = 0;

                }

                else if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    positionCoordinates.Y--;
                    if (collision.Y == 1)
                    {
                        positionCoordinates.Y++;
                        moving = false;
                    }

                    incrementor = up;
                    direction = 1;

                }

                else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    positionCoordinates.X++;
                    if (collision.Z == 1)
                    {
                        positionCoordinates.X--;
                        moving = false;
                    }

                    incrementor = right;
                    direction = 2;

                }

                else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    positionCoordinates.X--;
                    if (collision.W == 1)
                    {
                        positionCoordinates.X++;
                        moving = false;
                    }

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

               
                position += incrementor;
                cur += 2;

                if (cur == block)
                {
                    incrementor = new Vector2(0, 0);
                    cur = 0;
                    moving = false;

                }
                
            }

            else
            {
                currentFrame = 0;
            }

        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(width * currentFrame, height * direction, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 54, 66);


            _spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

        }


    }
}
