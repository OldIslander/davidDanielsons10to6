using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace davidDanielson10to6
{
    public class Level
    {
        Texture2D ground;
        Texture2D brush;

        private Dictionary<Vector2, int> groundLayer;
        private Dictionary<Vector2, int> brushLayer;
        private Dictionary<int, Vector2> collision;

        public Level(string folder, Texture2D Ground, Texture2D Brush)
        {
            ground = Ground;
            brush = Brush;

            groundLayer = LoadLayer(folder + "/ground.csv");
            brushLayer = LoadLayer(folder + "/brush.csv");
            collision = LoadCollision(folder + "/collision.csv");
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

        }
    }
}
