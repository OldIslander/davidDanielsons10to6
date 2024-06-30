using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace davidDanielson10to6
{
    public class Box
    {
        private Texture2D texture;
        private Vector2 position;

        private Vector2 incrementor; //movement incrementor
        private Vector2 up = new Vector2(0, -2);
        private Vector2 down = new Vector2(0, 2);
        private Vector2 left = new Vector2(-2, 0);
        private Vector2 right = new Vector2(2, 0);

        public bool beingPushed = false;
        
        public Box(Texture2D BoxTexture, Vector2 Position)
        {
            texture = BoxTexture;
            position = Position;
        }

        public void Update()
        {
           
        }

        public void Draw()
        {

        }
    }
}
