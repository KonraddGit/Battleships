using Battleships.Core.Interfaces;
using Battleships.Logic.BoardLogic;

namespace Battleships.Logic
{
    public class Simulation
    {
        public ICell Cell { get; set; }
        public Simulation()
        {
            Cell = new CellLogic();
        }

        public void Run()
        {
            Board.DrawBoard();
        }
    }
}
