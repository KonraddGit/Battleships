using Battleships.Core.Interfaces;
using Battleships.Core.Models;
using System;

namespace Battleships.Logic.BoardLogic
{
    public class ShootingMechanism : IShootingMechanism
    {
        public static ICell Cell;
        private static readonly Random rnd = new();

        public ShootingMechanism(Player player) 
            => Cell = new CellLogic(player);


        public void ShotMechanism()
        {
            throw new NotImplementedException();
        }

        public void ShotOrMiss()
        {
            throw new NotImplementedException();
        }

        public void ShottingPatter()
        {
            throw new NotImplementedException();
        }
    }
}
