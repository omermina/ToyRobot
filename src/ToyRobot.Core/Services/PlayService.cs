using ToyRobot.Core.Interfaces;
using ToyRobot.Core.Models;

namespace ToyRobot.Core.Services
{
    public class PlayService : IPlayService
    {
        private readonly IRobot _robot;
        private readonly IBoard _board;

        public PlayService(IRobot robot, IBoard board)
        {
            _robot = robot;
            _board = board;
        }


        public bool Place(int x, int y, Direction f)
        {
            if (!_board.IsValidLocation(x, y))
                return false;

            _robot.Place(x, y, f);
            return true;
        }

        public void SentCommand(string command)
        {
            switch (command.ToLower())
            {
                case "move":
                    if (_robot.CanMove()) 
                        _robot.Move();
                    break;
                case "right":
                    _robot.Right();
                    break;
                case "left":
                    _robot.Left();
                    break;
            }
        }

        public string Report()
        {
            return _robot.Report();
        }
    }
}
