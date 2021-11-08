using Battleships.Core.Interfaces;
using Battleships.Core.Models;
using Battleships.Logic.Helpers;
using System;
using System.Threading.Tasks;

namespace Battleships.Logic.BoardLogic
{
    //wylosuj pozycje
    //sprawdz czy jest 1 czy 0
    //jesli zero to pudlo i zaznacz miss czyli 2
    //jesli trafiłeś to zaznacz trafienie, sprawdż czy wszystkie pola są zerami dookoła, jeśli nie to niezatopiony i możesz strzelać w losowym kierunku dalej
    //sprawdz czy kierunek wybrany idzie w ściane
    //powtarzaj az do zatopienia
    //przy pudle następny gracz, przy trafieniu kontynuacja
    //18 punktów = 18 trafień to koniec meczu i wygrana


    public class ShootingGenerator
    {
        public static ICell Cell;

        public void ShotEnemy(Player player)
        {
            if (player is null)
                throw new ArgumentNullException(nameof(player));

            Cell = new CellLogic(player);

            var cell = FirstShoot(player);
            HitOrMiss(cell, player);
        }

        private Cell FirstShoot(Player player)
            => Cell.FirstPosition();

        private Cell HitOrMiss(Cell cell, Player player)
        {
            if (player.GameBoard[cell.X, cell.Y] == 1)
                return Hit(cell, player);
            else
                return Miss(cell);
        }


        private Cell Hit(Cell cell, Player player)
        {
            player.HitPoints++;
            Console.WriteLine($"{player.Name} GOT HIT!");

            //trzeba dodac, zeby narysowalo wszedzie 2 dookoloa jak zatopiony
            //jesli dookola sa 0 to true zwraca czyli byl pojedynczy statek, czyli zatopienie
            if (Cell.PointTypeDraw(DrawType.Hit, cell).CheckForFreeSpace(player))
            {
                Console.WriteLine($"{player.Name} GOT SINKING SHIP!");
                var tmp = FirstShoot(player);
                HitOrMiss(tmp, player);
            }
            else
                Direction();
        }

        private Cell Miss(Cell cell)
            => Cell.PointTypeDraw(DrawType.Miss, cell);

        private void Direction()
        {
            var cell = player.PlacedShips.Last();
            Cell tmp = null;

            var direction = Extensions.RandomDirection();

            for (int i = 1; i < length; i++)
            {
                switch (direction)
                {
                    case 0:
                        tmp = new Cell { X = cell.X - i, Y = cell.Y };
                        break;
                    case 1:
                        tmp = new Cell { X = cell.X, Y = cell.Y + i };
                        break;
                    case 2:
                        tmp = new Cell { X = cell.X + i, Y = cell.Y };
                        break;
                    case 3:
                        tmp = new Cell { X = cell.X, Y = cell.Y - i };
                        break;
                    default:
                        break;
                }

                player.PlacedShips.Add(Cell.PointTypeDraw(DrawType.ShipMark, tmp));
            }
        }
    }
}
