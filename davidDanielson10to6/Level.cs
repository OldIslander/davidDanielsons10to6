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

        private Dictionary<Vector2, int> groundLayer; //mod 10
        private Dictionary<Vector2, int> brushLayer; //mod 8
        public Dictionary<Vector2, int> collision;

        public Level(string folder, Texture2D Ground, Texture2D Brush)
        {

            ground = Ground;
            brush = Brush;

            groundLayer = LoadLayer("../../../Content/" + folder + "/ground.csv");
            brushLayer = LoadLayer("../../../Content/" + folder + "/brush.csv");
            collision = LoadLayer("../../../Content/" + folder + "/collision.csv");
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

        //Identical algorithm to MapMaker, only this one creates a dictionary with the values and keys reversed.
        //This will make it easier to check collision
        private Dictionary<int, Vector2> LoadCollision(string file)
        {
            Dictionary<int, Vector2> collision = new();

            StreamReader reader = new(file);
            int y = 0;
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Split(',');

                for (int x = 0; x < items.Length; x++)
                {
                    if (int.TryParse(items[x], out int value))
                    {
                        collision[value] = new Vector2(x, y);
                    }
                }

                y++;
            }

            return collision;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
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
        }
    }
}
