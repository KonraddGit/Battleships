﻿using System;
using System.Collections.Generic;

namespace Battleships.Core.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int[,] GameBoard { get; set; } = new int[10, 10];
        public List<Cell> PlacedShips { get; set; } = new List<Cell>();
        public int HitPoints
        {
            get { return PlacedShips.Count; }
            set
            {
                if (value < 0 || value > 18)
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} badly generated ships");
            }
        }
    }
}