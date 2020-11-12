using ToyRobot.Core.Models;

namespace ToyRobot.Core.Interfaces
{
    public interface IBoard
    {
        bool IsValidLocation(int x, int y);
    }
}