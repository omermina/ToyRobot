using FluentAssertions;
using ToyRobot.Core.Models;
using Xunit;

namespace ToyRobot.Tests
{
    public class MovementsTests
    {
        [Fact]
        public void Move_Two_Times_North()
        {

            var board = new Board { MaxXUnits = 5, MaxYUnits = 5 };
            var sut = new Robot(board);
            sut.Place(0, 0, Direction.North);
            sut.Move();
            sut.Move();

            sut.Y.Should().Be(2);
        }

        [Fact]
        public void Move_Two_Times_East()
        {

            var board = new Board { MaxXUnits = 5, MaxYUnits = 5 };
            var sut = new Robot(board);
            sut.Place(0, 0, Direction.East);
            sut.Move();
            sut.Move();

            sut.X.Should().Be(2);
        }

        [Fact]
        public void Move_Two_Times_East_Two_Times_North()
        {

            var board = new Board { MaxXUnits = 5, MaxYUnits = 5 };
            var sut = new Robot(board);
            sut.Place(0, 0, Direction.East);
            sut.Move();
            sut.Move();

            sut.Left();
            sut.Move();
            sut.Move();

            sut.X.Should().Be(2);
            sut.Y.Should().Be(2);
        }

        [Fact]
        public void Move_Two_Times_North_Turn_Right()
        {

            var board = new Board { MaxXUnits = 5, MaxYUnits = 5 };
            var sut = new Robot(board);
            sut.Place(0, 0, Direction.North);
            sut.Move();
            sut.Move();

            sut.Right();
            
            sut.Y.Should().Be(2);
            sut.Direction.Should().Be(Direction.East);
        }

    }
}
