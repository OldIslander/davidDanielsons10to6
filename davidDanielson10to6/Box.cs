using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Direct3D9;

namespace davidDanielson10to6
{
    public class Box
    {
        private Texture2D texture;
        public Vector2 position;
        private Vector2 offset; //For the pushing animation. When a box is being pushed, this offset will be added to the final resulting position until its position variable is updated. 
        private Vector2 incrementor; //movement incrementor
        
        private Vector2 up = new Vector2(0, -2);
        private Vector2 down = new Vector2(0, 2);
        private Vector2 left = new Vector2(-2, 0);
        private Vector2 right = new Vector2(2, 0);

        private int width = 54;
        private int height = 90;

        public bool beingPushed = false;
        
        public Box(Texture2D BoxTexture, Vector2 Position)
        {
            texture = BoxTexture;
            position = Position;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            
            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
            Rectangle destinationRectangle = new Rectangle(((int)position.X * 48) -1, ((int)position.Y * 48) -45, 54, 90);


            _spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }
}
