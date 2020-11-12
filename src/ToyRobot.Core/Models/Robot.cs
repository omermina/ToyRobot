using ToyRobot.Core.Interfaces;

namespace ToyRobot.Core.Models
{
    public class Robot : IRobot
    {
        private readonly IBoard _board;
        public Robot(IBoard board)
        {
            _board = board;
            X = -1;
            Y = -1;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public Direction Direction { get; internal set; }

        public void Place(int x, int y, Direction direction)
        {
            if (!_board.IsValidLocation(x, y)) 
                return;

            Direction = direction;
            X = x;
            Y = y;
        }

        public Robot GetRobot()
        {
            return this;
        }

        public bool CanMove()
        {
            var testX = X;
            var testY = Y;
            switch (Direction)
            {
                case Direction.East:
                    testX = X + 1;
                    break;
                case Direction.West:
                    testX = X - 1;
                    break;
                case Direction.North:
                    testY = Y + 1;
                    break;
                case Direction.South:
                    testY = Y - 1;
                    break;
            }

            return _board.IsValidLocation(testX, testY);
        }

        public void Move()
        {
            switch (Direction)
            {
                case Direction.East:
                    X += 1;
                    break;
                case Direction.West:
                    X -= 1;
                    break;
                case Direction.North:
                    Y += 1;
                    break;
                case Direction.South:
                    Y -= 1;
                    break;
            }
        }
        public void Left()
        {
            switch (Direction)
            {
                case Direction.East:
                    Direction = Direction.North;
                    break;
                case Direction.West:
                    Direction = Direction.South;
                    break;
                case Direction.North:
                    Direction = Direction.West;
                    break;
                case Direction.South:
                    Direction = Direction.East;
                    break;
            }
        }

        public void Right()
        {
            switch (Direction)
            {
                case Direction.East:
                    Direction = Direction.South;
                    break;
                case Direction.West:
                    Direction = Direction.North;
                    break;
                case Direction.North:
                    Direction = Direction.East;
                    break;
                case Direction.South:
                    Direction = Direction.West;
                    break;
            }
        }

        public string Report()
        {
            return $"{X},{Y},{Direction.ToString().ToUpper()}";
        }


    }
}
