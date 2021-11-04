using Battleships.Core.Models;
using System.Threading.Tasks;

namespace Battleships.Core.Interfaces
{
    public interface ICell
    {
        public Task PointTypeDraw(DrawType draw, Cell cell);
        public Cell FirstPosition();
    }

    public enum DrawType
    {
        Hit = 0,
        Miss = 1,
        ShipMark = 2
    }
}
