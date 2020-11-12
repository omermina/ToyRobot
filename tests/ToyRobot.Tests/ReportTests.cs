using FluentAssertions;
using ToyRobot.Core.Models;
using Xunit;

namespace ToyRobot.Tests
{
    public class ReportTests
    {
        [Theory]
        [InlineData(1, 2, Direction.East, "1,2,EAST")]
        [InlineData(5, 2, Direction.North, "5,2,NORTH")]
        [InlineData(5, 1, Direction.West, "5,1,WEST")]
        [InlineData(1, 1, Direction.South, "1,1,SOUTH")]
        [InlineData(10, 15, Direction.South, "-1,-1,NORTH")]

        public void Is_Placed_On_Board(int x, int y, Direction f, string expected)
        {

            var board = new Board {MaxXUnits = 5, MaxYUnits = 5};
            var robot = new Robot(board);
            robot.Place(x, y, f);

            var sut = robot.Report();

            sut.Should().Be(expected);
        }


    }
}
