using ToyRobot.Core.Models;

namespace ToyRobot.Core.Interfaces
{
    public interface IPlayService
    {

        public bool Place(int x, int y, Direction direction);
        public void SentCommand(string command);
        public string Report();
    }
}
