using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode
{
    class Day10
    {
        public static int Part1()
        {
            var inputVolt = 0;
            var adapters = InputData.Select(x => new Adapter(x)).ToList();
            adapters.Add(new Adapter(adapters.Select(x => x.MaxRating).Max() + 3));
            var voltageDifferences = new List<int>();
            for (int i = 0; i < adapters.Count; i++)
            {
                var nextAdapterRating = adapters
                    .Where(x => !x.InUse && x.AcceptedRatings.Contains(inputVolt))
                    .Select(x => x.MaxRating).Min();
                var nextAdapter = adapters.First(x => x.MaxRating == nextAdapterRating);
                nextAdapter.InUse = true;
                voltageDifferences.Add(nextAdapter.MaxRating - inputVolt);
                inputVolt = nextAdapter.MaxRating;
            }
            return voltageDifferences.Count(x => x == 1) * voltageDifferences.Count(x => x == 3);
        }

        public static int Part2()
        {
            var inputVolt = 0;
            var adapters = InputData.Select(x => new Adapter(x)).ToList();
            adapters.Add(new Adapter(adapters.Select(x => x.MaxRating).Max() + 3));
            for (int i = 0; i < adapters.Count; i++)
            {
                var possibleNextAdapters = adapters.Where(x => x.AcceptedRatings.Contains(inputVolt));
                foreach (var item in collection)
                {

                }
            }
        }

        private static int[] InputData = @"16
10
15
5
1
11
7
19
6
12
4".Split(Environment.NewLine).Select(x => int.Parse(x)).ToArray();
    }

    class Adapter
    {
        public bool InUse { get; set; } = false;
        public int MaxRating { get; set; }
        public int[] AcceptedRatings
        {
            get
            {
                return new int[] { MaxRating - 3, MaxRating - 2, MaxRating - 1, MaxRating }.Where(x => x >= 0).ToArray();
            }
        }

        public Adapter(int rating)
        {
            this.MaxRating = rating;
        }

        public override string ToString()
        {
            return this.MaxRating.ToString()+ " - "+this.InUse.ToString();
        }
    }
}
