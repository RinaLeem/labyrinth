using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Maze
{


    public class MazeGeneratorAldousBroder
    {


        private List<List<bool>> area;
        private bool hole = false;
        private bool wall = true;

        public List<List<bool>> Generate(int width, int height)
        {
            area = new List<List<bool>>(new List<bool>[height]);
            for (int i = 0; i < area.Count; i++)
            {
                area[i] = new List<bool>(Enumerable.Repeat(true,width));
            }

            int y = 0;
            int x = 0;

            int total_cells = (area.Count / 2) * (area[0].Count / 2);

            Random random_generator = new Random();

            int random_start_y = random_generator.Next(1, area.Count - 2);
            int random_start_x = random_generator.Next(1, area[0].Count - 2);

            int[] directions = { 0, 1, 2, 3 }; // north, south, west, east

            y = (random_start_y / 2 * 2 + 1);
            x = (random_start_x / 2 * 2 + 1);
            area[y][x] = hole;
            total_cells--;

            while (total_cells > 0)
            {
                int next_cell = directions[random_generator.Next(0, 4)];
                if (next_cell == 0) // north
                {
                    if (y >= 3)
                    {
                        y -= 2;
                        if (wall == area[y][x])
                        {
                            total_cells--;
                            area[y][x] = hole;
                            area[y + 1][x] = hole;
                        }
                    }
                }
                else if (next_cell == 1) // south
                {
                    if ((y + 2) <= area.Count - 2)
                    {
                        y += 2;
                        if (wall == area[y][x])
                        {
                            total_cells--;
                            area[y][x] = hole;
                            area[y - 1][x] = hole;
                        }
                    }
                }
                else if (next_cell == 2) // west
                {
                    if (x >= 3)
                    {
                        x -= 2;
                        if (wall == area[y][x])
                        {
                            total_cells--;
                            area[y][x] = hole;
                            area[y][x + 1] = hole;
                        }
                    }
                }
                else if (next_cell == 3) // east
                {
                    if ((x + 2) <= area[0].Count - 2)
                    {
                        x += 2;
                        if (wall == area[y][x])
                        {
                            total_cells--;
                            area[y][x] = hole;
                            area[y][x - 1] = hole;
                        }
                    }
                }
            }
            return area;
        }
    }

}



