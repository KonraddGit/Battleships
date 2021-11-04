namespace Battleships.Core.Interfaces
{
    public interface IShip
    {
        int ShipNumber { get; set; }
        ShipType ShipType { get; set; }
        int Size { get; set; }
    }

    public enum ShipType
    {
        Destroyer = 1,
        Cruiser = 2,
        Submarine = 3,
        Warmachine = 4,
        Fighter = 5
    }
}
