using Battleships.Core.Models;

namespace Battleships.Core.Interfaces
{
    public interface ICell
    {
        public void PointTypeDraw(DrawType draw, Cell cell);
        public Cell FirstPosition();
    }

    public enum DrawType
    {
        Hit = 0,
        Miss = 1,
        ShipMark = 2
    }
}
