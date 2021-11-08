using Battleships.Core.Interfaces;
using Battleships.Core.Models;
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

        }

        private Cell FindSpot(Player player)
        {
            var cell = Cell.FirstPosition();

            if (player.GameBoard[cell.X, cell.Y]
)
            {

            }

        }
      

    }
}
