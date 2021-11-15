using Battleships.Core.Interfaces;
using Battleships.Core.Models;
using Battleships.Logic.Helpers;
using System;
using System.Collections.Generic;

namespace Battleships.Logic.BoardLogic
{
    public class ShootingGenerator
    {
        public static ICell Cell;

        public void ShotEnemy(Player player)
        {
            if (player is null)
                throw new ArgumentNullException(nameof(player));

            Cell = new CellLogic(player);

            ShotLogic(player);
        }

        private Cell ShotLogic(Player player, Cell cell = null)
        {
            if (cell == null)
                cell = FirstShoot();

            var type = ShotType(cell, player);

            return type switch
            {
                0 => Miss(cell),
                1 => Hit(cell, player),
                2 or 3 => ShotLogic(player),
                _ => throw new NotImplementedException("There is no number like this implemented yet"),
            };
        }

        private void MarkAroundHit(Cell cell, Player player)
        {
            foreach (var item in Extensions.IterateAroundCell(cell))
            {
                if (!Extensions.TargetOutOfMap(item))
                    continue;

                if (player.GameBoard[item.X, item.Y] == 0)
                    Cell.PointTypeDraw(DrawType.Miss, item);
            }
        }

        private Cell Hit(Cell cell, Player player)
        {
            IEnumerable<Cell> shipCells = new List<Cell>();

            if (FinishGame(player))
                return cell;

            player.HitPoints--;
            Console.WriteLine($"{player.Name} GOT HIT!");

            if (ShipSinked(cell, player))
            {
                Console.WriteLine($"{player.Name} GOT SINKING SHIP!");
                MarkAroundHit(cell, player);
                ShotLogic(player);
            }
            else
                TargetCheck(player, cell);

            return cell;
        }

        private void TargetCheck(Player player, Cell cell = null)
        {
            var tmp = Direction(cell);
            if (!Extensions.TargetOutOfMap(tmp))
                ShotLogic(player, tmp);
            else
                TargetCheck(player, cell);
        }

        private Cell Direction(Cell cell)
        {
            var direction = Extensions.RandomDirection();

            return direction switch
            {
                0 => new Cell { X = cell.X - 1, Y = cell.Y },
                1 => new Cell { X = cell.X, Y = cell.Y + 1 },
                2 => new Cell { X = cell.X + 1, Y = cell.Y },
                3 => new Cell { X = cell.X, Y = cell.Y - 1 },
                _ => throw new NotImplementedException()
            };
        }

        private bool FinishGame(Player player)
        {
            if (player.HitPoints < 1)
            {
                Console.WriteLine($"{player.Name} LOST!");
                return true;
            }

            return false;
        }

        private bool ShipSinked(Cell cell, Player player)
            => Cell.PointTypeDraw(DrawType.Hit, cell).CheckForFreeSpace(player);

        private Cell Miss(Cell cell)
            => Cell.PointTypeDraw(DrawType.Miss, cell);

        private Cell FirstShoot()
            => Cell.FirstPosition();

        private int ShotType(Cell cell, Player player)
            => player.GameBoard[cell.X, cell.Y];
    }
}
