using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SharpDX.Direct3D9;

namespace davidDanielson10to6
{
    public class Level
    {
        Texture2D ground;
        Texture2D brush;

        List<Box> boxes;

        Player david;

        WaterTile water;

        private Dictionary<Vector2, int> groundLayer; //mod 10
        private Dictionary<Vector2, int> brushLayer; //mod 8
        public Dictionary<Vector2, int> collision;
        public Dictionary<Vector2, int> boxLayer;



        public Level(string folder, Texture2D Ground, Texture2D Brush, Texture2D playerTexture, Texture2D waterTexture)
        {
            david = new Player(playerTexture);
            water = new WaterTile(waterTexture, 24);
            ground = Ground;
            brush = Brush;

            groundLayer = LoadLayer("../../../Content/" + folder + "/_ground.csv");
            brushLayer = LoadLayer("../../../Content/" + folder + "/_brush.csv");
            collision = LoadLayer("../../../Content/" + folder + "/_collision.csv");
            boxLayer = LoadLayer("../../../Content/" + folder + "/_boxes.csv");
        }

        private Dictionary<Vector2, int> LoadLayer(string file)
        {
            Dictionary<Vector2, int> map = new();

            StreamReader reader = new(file); //Using this to read in csv file
            int y = 0;
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Split(',');

                for (int x = 0; x < items.Length; x++)
                {
                    if (int.TryParse(items[x], out int value))
                    {
                        map[new Vector2(x, y)] = value;
                    }
                }

                y++;
            }

            return map;


        }

        public void Update()
        {

            water.Update();

            //Collision checking for our main man David Danielson

            if (collision[david.positionCoordinates] % 4 == 1 || collision[david.positionCoordinates] % 4 == 3)
            {
                david.collision.Y = 1;
            }

            else
            {
                david.collision.Y = 0;
            }

            if ((collision[david.positionCoordinates] / 4 == 1 || collision[david.positionCoordinates] / 4 == 3) && collision[david.positionCoordinates] != -1)
            {
                david.collision.X = 1;
            }

            else
            {
                david.collision.X = 0;
            }

            if (collision[david.positionCoordinates] % 4 == 2 || collision[david.positionCoordinates] % 4 == 3)
            {
                david.collision.Z = 1;
            }

            else
            {
                david.collision.Z = 0;
            }

            if ((collision[david.positionCoordinates] / 4 == 2 || collision[david.positionCoordinates] / 4 == 3) && collision[david.positionCoordinates] != -1)
            {
                david.collision.W = 1;
            }

            else
            {
                david.collision.W = 0;
            }

            david.Update();
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            water.Draw(_spriteBatch);

            _spriteBatch.Begin();

            for(int x = 0; x < 27; x++)
            {
                for (int y = 0; y < 18; y++)
                {
                    Vector2 position = new Vector2(x, y);
                    if(groundLayer[position] != -1)
                    {
                        Rectangle sourceRectangle = new Rectangle(48 * (groundLayer[position] % 10), 48* (groundLayer[position] / 10), 48, 48);

                        _spriteBatch.Draw(ground, new Rectangle(48 * x, 48 * y, 48, 48), sourceRectangle, Color.White);
                    }

                    if (brushLayer[position] != -1)
                    {
                        Rectangle sourceRectangle = new Rectangle(54 * (brushLayer[position] % 8), 54 * (brushLayer[position] / 8), 54, 54);

                        _spriteBatch.Draw(brush, new Rectangle(48 * x - 3, 48 * y - 3, 54, 54), sourceRectangle, Color.White);
                    }
                }
            }

            _spriteBatch.End();

            david.Draw(_spriteBatch);
        }
    }
}
