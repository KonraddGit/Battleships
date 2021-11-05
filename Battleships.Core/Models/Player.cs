namespace Battleships.Core.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int[,] GameBoard { get; set; } = new int[10, 10];
    }
}
