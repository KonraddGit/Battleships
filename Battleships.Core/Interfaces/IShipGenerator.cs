using Battleships.Core.Models;
using System.Threading.Tasks;

namespace Battleships.Core.Interfaces
{
    public interface IShipGenerator
    {
        public Task DrawShipsAsync();
    }
}
