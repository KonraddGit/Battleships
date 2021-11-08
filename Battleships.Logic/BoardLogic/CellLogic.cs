using Battleships.Core.Interfaces;
using Battleships.Core.Models;
using System;

namespace Battleships.Logic.BoardLogic
{
    public class CellLogic : ICell
    {
        private static readonly Random rnd = new();

        public Player Player { get; }

        public CellLogic(Player player)
        {
            if (player is null)
                throw new ArgumentNullException(nameof(player));
            
            Player = player;
        }

        public Cell FirstPosition()
            => new Cell
            {
                X = rnd.Next(0, 10),
                Y = rnd.Next(0, 10),
            };

        public Cell PointTypeDraw(DrawType draw, Cell cell)
        {
            switch (draw)
            {
                case DrawType.Hit:
                    return ShipHit(cell);

                case DrawType.Miss:
                    return ShipMiss(cell);

                case DrawType.ShipMark:
                    return ShipMark(cell);

                default:
                    break;
            }

            return cell;
        }

        public Cell ShipMark(Cell cell)
        {
            Player.GameBoard[cell.X, cell.Y] = 1;
            return cell;
        }

        public Cell ShipHit(Cell cell)
        {
            Player.GameBoard[cell.X, cell.Y] = 2;
            return cell;
        }

        public Cell ShipMiss(Cell cell)
        {
            Player.GameBoard[cell.X, cell.Y] = 3;
            return cell;
        }
    }
}