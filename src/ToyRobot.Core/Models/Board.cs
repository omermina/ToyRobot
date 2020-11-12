using ToyRobot.Core.Interfaces;

namespace ToyRobot.Core.Models
{
    public class Board : IBoard
    {
        public int MaxXUnits { get; set; }
        public int MaxYUnits { get; set; }
        public bool IsValidLocation(int x, int y)
        {
            return x >= 0 && x <= MaxXUnits && y >= 0 && y <= MaxYUnits;
        }
    }
}
