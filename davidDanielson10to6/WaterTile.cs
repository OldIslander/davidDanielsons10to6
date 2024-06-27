using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace davidDanielson10to6
{
    public class WaterTile
    {
        public Texture2D waterTexture;
        private int delay;
        private int step = 0;
        public int frame = 0;
        const int maxFrames = 7;

        public WaterTile(Texture2D texture, int Delay)
        {
            waterTexture = texture;
            delay = Delay;
        }

        public void Update()
        {
            //increments step each loop until it meets delay, at which point it advances the animation by one frame and resets thew steps
            step++;
            if (step == delay)
            {
                step = 0;
                frame++;
                if (frame > maxFrames)
                {
                    frame = 0;
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, Microsoft.Xna.Framework.Graphics.SamplerState.PointClamp, null, null, null, null);

            Rectangle sourceRectangle = new Rectangle(32 * frame, 0, 16, 16);


            for (int x = 0; x < 35; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    spriteBatch.Draw(waterTexture, new Rectangle((48 * x), (48 * y), 48, 48), sourceRectangle, Color.White);
                }
            }






            spriteBatch.End();
        }
    }
}
