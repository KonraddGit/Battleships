using Battleships.Core.Interfaces;
using Battleships.Core.Models;
using Battleships.Logic.Helpers;
using System;

namespace Battleships.Logic.BoardLogic
{
    //jesli zero to pudlo i zaznacz miss czyli 2
    //jesli trafiłeś to zaznacz trafienie, sprawdż czy wszystkie pola są zerami dookoła, jeśli nie to niezatopiony i możesz strzelać w losowym kierunku dalej
    //sprawdz czy kierunek wybrany idzie w ściane
    //powtarzaj az do zatopienia
    //przy pudle następny gracz, przy trafieniu kontynuacja
    //18 punktów = 18 trafień to koniec meczu i wygrana pod warunkiem, że tyle statków istnieje


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

            //0 - empty,
            //1 - ship,
            //2 - miss or space around ship,
            //3 - already hit
            var type = ShotType(cell, player);

            return type switch
            {
                0 => Miss(cell),
                1 => Hit(cell, player),
                2 or 3 => ShotLogic(player),
                _ => throw new NotImplementedException(""),
            };
        }

        private Cell Hit(Cell cell, Player player)
        {
            player.HitPoints++;
            Console.WriteLine($"{player.Name} GOT HIT!");

            //trzeba dodac, zeby narysowalo wszedzie 2 dookola jak zatopiony
            //jesli dookola sa 0 to true zwraca czyli byl pojedynczy statek, czyli zatopienie
            if (Cell.PointTypeDraw(DrawType.Hit, cell).CheckForFreeSpace(player))
            {
                MarkSpaceAroundSinkedShip(cell, player);
                Console.WriteLine($"{player.Name} GOT SINKING SHIP!");
                ShotLogic(player);
            }
            else
            {
                var tmp = Direction(cell);
                ShotLogic(player, tmp);
            }
        }

        private bool MarkSpaceAroundSinkedShip(Cell cell, Player player)
        {
            if (!Cell.PointTypeDraw(DrawType.Miss, cell).CheckForFreeSpace(player))
            {

            }
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











        private Cell Miss(Cell cell)
            => Cell.PointTypeDraw(DrawType.Miss, cell);

        private Cell FirstShoot()
            => Cell.FirstPosition();

        private int ShotType(Cell cell, Player player)
            => player.GameBoard[cell.X, cell.Y];
    }
}
