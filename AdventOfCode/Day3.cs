﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace AdventOfCode
{
    class Day3
    {
        public static int Part1()
        {
            var map = new Map(InputData);
            return map.GetTreesOnSlope(3, 1).Count();
        }

        public static long Part2()
        {
            var map = new Map(InputData);
            long slope1 = map.GetTreesOnSlope(1, 1).Count();
            long slope2 = map.GetTreesOnSlope(3, 1).Count();
            long slope3 = map.GetTreesOnSlope(5, 1).Count();
            long slope4 = map.GetTreesOnSlope(7, 1).Count();
            long slope5 = map.GetTreesOnSlope(1, 2).Count();

            return slope1 * slope2 * slope3 * slope4 * slope5;


        }

        class Map
        {
            public List<Tree> Trees { get; set; } = new List<Tree>();

            private int MapHeight { get; set; }

            public Map(string input)
            {
                string[][] mapArr = input.Split(Environment.NewLine).Select(x => x.ToArray().Select(y => y.ToString()).ToArray()).ToArray();

                MapHeight = mapArr.Length;

                for (int y = 0; y < mapArr.Length; y++)
                {
                    for (int x = 0; x < mapArr[y].Length; x++)
                    {
                        if (mapArr[y][x] == "#")
                        {
                            for (int i = 0; i < 100; i++)
                            {
                                var xCoord = x + (mapArr[y].Length * i);
                                Trees.Add(new Tree(xCoord, y));
                            }
                        }

                    }
                }
            }

            public Tree[] GetTreesOnSlope(int right, int down)
            {
                int x = 0;
                int y = 0;
                var coordinates = new List<string>();
                for (int i = 0; i < this.MapHeight; i += down)
                {
                    x += right;
                    y += down;
                    coordinates.Add($"{x},{y}");
                }
                var trees = this.Trees.Where(t => coordinates.Contains(t.Name)).ToArray();

                return trees;
            }
        }

        class Tree
        {
            public int X { get; set; }
            public int Y { get; set; }

            public string Name { get { return $"{this.X},{this.Y}"; } }

            public Tree(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public override string ToString()
            {
                return this.Name;
            }

        }

        private static string InputData = @".....#.##......#..##..........#
##.#.##..#............##....#..
......###...#..............#.##
.....#..##.#..#......#.#.#..#..
..#.......###..#..........#.#..
..#..#.##.......##.....#....#..
.##....##....##.###.....###..#.
..##....#...##..#....#.#.#.....
.....##..###.##...............#
#.....#..#....#.##...####..#...
#......#.#....#..#.##....#..#.#
##.#...#.#............#......#.
.#####.......#..#.#....#......#
..#.#....#.#.##...#.##...##....
.....#.#...#..####.##..#.......
#....#...##.#.#.##.#..##.....#.
##.##...#....#...#......#..##..
....##...#..#.#...#.#.#.....##.
..#....##......##....#.#....#..
#..#....#....###..#.##....#.#.#
..#.#####..##....#....#.....##.
.#...##.......#...#....#.#...##
#.#.#.##.......#.....#.#.#....#
.#.#.....#.......#.......##....
.#......#....#....#.......##...
#......#.....#......#..#..#....
#.#...#...#....##....#.#...#..#
....#.....##...#...#..#.#......
..#......#..........#...#.#....
..#..#......####..##...###.....
.#.....#...##...#.##........###
#.#....#..#....#..#.....#.#..#.
...##.##.#.#.##...#.....#......
##....#.#.#...####.#.#.#.#.....
.##.........#..#..###..........
..##.###.#..#..#....##.....#...
##........#..###....#.#..#..#..
....#.#.......##..#.#.#.#......
....##.....#.........##.......#
..#........##.#.........###..##
....#..................##..#...
#...#.#..###..#.....#..#..#...#
..#..#.##..#..#.......#.......#
.....#..##..#....##...........#
..##...#........#...#.#.......#
.........#.#..#.#..#.##.#.###..
....#...#..#..#......##....#.#.
..#..#.#....#....#..#.####..##.
##....#.....#......##.###.#..#.
#..#..##..###......#.#.#.#...#.
.......#..##..##...#...#..#....
..#.###.#...#....#.##.#.....##.
.#.#.......##...##...##....#...
#...#.#.#...#.####..#..##......
###..#.##..#..........#...#....
##.#.........#..##......####...
..##.#..#....#.##..............
...#....#.......###............
...#.....##....#.#.#.#.......##
###.###...#...#...###.##...##..
#.#....#.##..#.....#.....##.#..
...#....#....#.........#....#.#
##.#....#........#..#..##.#....
.#.#..#.......#...##.......#...
.##...##........#....#.#..#....
....#..#.##.###.....#.#........
.#.#...#.#..#.....#.........#..
.......#.#.#..##....#.........#
.##...#....#..#...#........#..#
....#....#..#.#..#.#.#....##.##
..##....#.....##..#.#...#...#..
#.##.........#.....#.......#.##
...#...##.#.#..........#......#
###...#.....#..#.......#####..#
#.####...##.#.#..#...#.........
.##.....#.....##..#...##.##....
.........###...#......##....###
.#....##...###.#..#...##..#.#.#
.......#.......#.#...##.#......
.....#.#........#..##.....##...
....#.#.........##.#...##..#.#.
#..#..#.##..#.##.##.....##.###.
..##.........###...#....#....#.
.###...#..#.##...........#.....
#..##..........#..........#....
.....#.#....#..##..#...#.#....#
..#.....#.#....#...##.##.......
##.....##........#....#..##....
.#..#.#.........#..#..#........
.............##....#....#..#...
....##....#..#.#.##....###.##.#
.###..#.....#..#..##..#..##..#.
...#..###.......#.#....#..###..
#.#..#.....#...#......#........
#..#..............###.#......#.
..#....##.#....#.##.#.#...#....
.........##..#...#.#.......#...
........#...#.#....#.....##..#.
...#.##..#..#..###..#..#......#
.....####......#...#....#...#.#
...###.#.#......#....#.......#.
#...##.#....#....##....##.###..
.......##...##.....#.##.#..#..#
.....#.#............##...#.####
.##..#.#.#.#..#.#.#.....#.##...
.#..####...#.#....#.....#..#...
....##..#.#...#..#....#.#......
...#......###..#..###..#.....#.
.#.#.#..##....#...##..#.....#..
###....#....#...##.....#...#...
#.##....#......#...###.........
.#..#.#...#..#....#....#....#..
...............##...####..#..#.
#.#...........####..#...##.....
##.#....#........#......#...##.
......#...#...#....#....#.....#
#......#.............#....###..
.#...#...##.....#...##.##..#...
..#.#......#.#........#........
.......#..#.#...##..#.#.#......
..##...#.##........#....#.#...#
.....#..#..#........#.#......##
....#.#...##............##....#
.#.#....#.#.#...#...#.##.....#.
#.#.##...#....#.#.#..#.##..#.#.
.........####..#...#...#.......
#..#..####......#..##..#...#...
.........##..................#.
.....##.#..##.#.#...#......##..
...#....#....#.#.....#...#..#.#
#...##.#...##...........#..#...
#..........#.#..#..#.##..#..#.#
.#...#.##...#.#.#..#.......##..
.........#...........#..#..#...
.##...##....#.#......#........#
#.#...........#....#.......#...
##.#.#.......#...###......##..#
...###..#.##..##.#.#.......#...
.#...#..##.#...#........#.....#
...#.......#..#..........#.#...
..#.#.#.#.....#.#.......#..#..#
#.##.....#..##...#..###.#....#.
.......#...........#...#....###
.......#..#...#.............#..
#.....###.......#...#........#.
.#..#..#..#...........#........
....#.#...#.#.##.#.#....#.##..#
.......#..##...##...#...#......
...#.....##.###...#.#...##....#
#..#....#...##......#....##....
#.#.......#....#.###.##..#..#..
..##...........#...#....#......
.#........#.....#..#..#...#..##
.....#.#.#..#.......#....#.....
#..#.#......#......##....#.....
##.....................##......
.##........###..#.........#...#
........#.........#..#.........
.#.##....#.....#...#.........##
....##......#.........#........
...#.#..#...##.##.#.#..####....
..##...........##.#.#....#.....
.#.....#.#...#..#.......#....#.
....#...#......##...#...##.#..#
....#..##....#..#.........##.#.
..##...##.##....#....##.###...#
..#....##..##.#.#.#...#......#.
##...#.........#...........#...
.##....##.#.....#...#.......#..
..........##.###.##....###....#
..........#..##..#....#.#.##.##
........##.#...#.#.#.#...###.#.
.#......#.#.#...###.#.#.#......
.........#......#......#...#..#
......#.....#.##....##.#####..#
..#..##...###.#..........#.#.#.
.#..#....###.#...#..#....#...##
...................#..........#
....###.....#...##......#.....#
#.....#..##.....#.#..........#.
..#.......##.#....#..#.##.#...#
........##.#..###..#......##...
#...........##.#...###..#....#.
....#...........#.....#.#...#..
.##..#.#...#...#.##...#..#.....
#........#.#.#.#.#.#...........
#..#.....#..#..#.##....#....#.#
..#............##....#.#.##...#
.....###.#....#.#......#.###...
...#.....#.#.................#.
..#...##..#.#...#...#...#.....#
.##.#........#..#....##..#..##.
.#..........#...#.#..#..#.#....
#.......##.........#.##..#.####
.#..............#.......##.....
#......#.##..........#..#......
..##...#...#.#...#............#
.##.##..##..##........##.....#.
.....#..#.....##...............
.#..#...##...#...#.....#.......
#......#...#.......#..##.###.##
###..##......##......###....#..
....#..........#...#.##.#.....#
.........#....#..#..#.#..##....
.....#.....#...........#......#
.#.......#...#....##...#.##...#
..##.#..............#..#...#.#.
.#..####.#.........#....#....#.
..###.#...#..#......#.......###
.#.#..##...###...#...#.#...#.#.
...#..##..###.#..#.....#.##....
#...###.#...##.....####.....#..
.#.##...#..#.#..##.....#.......
...#.##.....##.....#....#......
.#...##.....#..###..#..........
..........#...#.....#....##.#..
.......#...#...#...#........#..
#....##..#...#..##.#.#.....#...
.#.#..............#..#....#....
.####.#.#.###......#...#.#....#
.#...#...##.#...............#.#
...#.......##...#...#....##....
#..........###.##..........##.#
.......#...#....#.#..#.#....#..
....#.##.#...###..#..##.##.....
..#.#.#......#.#.......###.....
#..................#.##....#...
#.....#..#.#.#..#...#.........#
..#..#...#.#.##........#.......
#..#.#..#..........###...#.#...
.......#.##....#........##.#...
.####.#.#...#.#...##.##.....###
........#.#...#.#..##...##.....
....##.##......#.##.........#..
.#..#...#.#...........#........
.......#..........#....#...#...
..###.#.###..#..#.....#..##....
.#..........#.......##...#.....
.#.....#...#........#...#.##..#
.#..#.......#..#.......#.#.#...
....#..##.#...##...#.#....#....
.....#.........#..#..#....#....
..#.#..##....#..#..##.#.#.....#
........#.#...###....#.#.#.....
.#.....#.......#..###.#........
.......#...#.#...#...##........
##.............#.#.....#.#..#..
.#....#.......#.#.......#..##..
#.....#........#..##..##.......
...........#.........###......#
....#.##...#.#...#...#....#..##
......#..##......#......#.##.#.
......##....####...###...#.....
#....#..........#.#.##.....#..#
....#.#...........#.#.#.#.#...#
....####.....##...#..##..#...#.
#....#.###..###.....#..###.....
..##.........#......#...##.#...
..#.....#.#...#.##.#...#..###.#
..#.##..##........#.......#.###
.....#..........#.....#....#...
.......##..##..###.......#####.
..###......#.#....###....##...#
#..##.....#..###...#.....##.##.
#..#..##.##.###.####.##.#......
.#.#......#.##......#..#......#
..###.....#.#......#.#.####....
#..............#..#.#...#.###..
...#..#.##..........##.#...#.##
.#.#.#.........#....#.#..#.....
..#.##..#...#..#...#......#....
.......#...#.##.#.#..#...##..#.
..........#.####...#........#.#
....#...#....##.#.........#.#..
##.#..#.......###....#..#..#.#.
..##.....#..#.#.#.####......#..
.#.....#..........#..#..#.#....
......#.#.......#.#...#..#..#..
...#...............#....#...#..
##.......#.........#.......#...
...#.......###...#.#...#.......
#...###....#....##....#....#...
...#....##..#.#.............##.
.....#.#.#..#......#...#.#..#..
.##....#..##..#####..##.....##.
....##.#.#..#.....#.#...#......
...#.....##.#.#..##..#.#.......
.......#..#..#..........#......
.......#...#..#.........#.##...
..#..#..#...##..#.#....#......#
..#....#...#.#......#........#.
.#...#..#...#.#..........#.....
#..#...####..#......##.##.#.#..
.#...#.#...#.#.....#..##.#.....
..#.##.#......#.........##...#.
###..............#.............
...#...###....#..#.............
.##....#......#..#.....#..#..#.
.#..........#.....##...#..#....
....##..#.#......###.##......#.
.#..##.#.##.#...##.#......###.#
#..###.#...###..#........#.#...
#..#.#.#..#...###.##.##..#..#..
#.#..#....#.........##......#..
....###.....###....#...........
....#..##.##....##..#.....#....
.#.....#....####...#..##.#..###
.........##..#......#.#...##...
.##.......#.....#.###.#..#.#..#
.....#.#...###.....#......####.
##.#...#......#.#.#..#.####...#
.#.##.....#..#..#.............#
.#..###..#..#......#..##......#
.......#.#........##.....#.#...
#....#...#..###..#.#.....#.##..
.##.....#.#....###..#.....##...
...##....#....#...#....#.#.#...
#####..#...........###....#...#
.#.......##.##.....#....#......
.#..#.#...#..#......#...#..#.#.
....#.....##...#####..#...#...#
###.##...#.#............#....#.
.....#...#........##.........#.";
    }
}