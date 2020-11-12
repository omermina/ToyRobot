using ToyRobot.Core.Models;

namespace ToyRobot.Core.Interfaces
{
    public interface IRobot
    {
        public void Place(int x, int y, Direction direction);
        public Robot GetRobot();
        public bool CanMove();
        public void Move();
        public void Left();
        public void Right();
        public string Report();
        
    }
}