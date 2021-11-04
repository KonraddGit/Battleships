using Battleships.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Core.Interfaces
{
    public interface ICell
    {
        public void DrawHitOrMissOnBoard(Cell cell);
        public Cell DrawPointOnBoard(Cell cell);
        public void DrawShips();
        public Cell FirstPosition();
    }
}
