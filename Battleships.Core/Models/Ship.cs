using Battleships.Core.Interfaces;
using System.Collections.Generic;

namespace Battleships.Core.Models
{
    public static class Ship
    {
        public static List<IShip> Ships = new()
        {
            new Cruiser(),
            new Destroyer(),
            new Submarine(),
            new Warmachine(),
            new Fighter(),
        };
    }

    public class Cruiser : IShip
    {
        public int ShipNumber { get; set; } = 2;
        public ShipType ShipType { get; set; } = ShipType.Cruiser;
        public int Size { get; set; } = 1;
    }

    public class Submarine : IShip
    {
        public int ShipNumber { get; set; } = 2;
        public ShipType ShipType { get; set; } = ShipType.Submarine;
        public int Size { get; set; } = 2;
    }

    public class Destroyer : IShip
    {
        public int ShipNumber { get; set; } = 1;
        public ShipType ShipType { get; set; } = ShipType.Destroyer;
        public int Size { get; set; } = 3;
    }

    public class Warmachine : IShip
    {
        public int ShipNumber { get; set; } = 1;
        public ShipType ShipType { get; set; } = ShipType.Warmachine;
        public int Size { get; set; } = 4;
    }

    public class Fighter : IShip
    {
        public int ShipNumber { get; set; } = 1;
        public ShipType ShipType { get; set; } = ShipType.Fighter;
        public int Size { get; set; } = 5;
    }
}
