using FluentAssertions;
using Moq;
using ToyRobot.Core.Interfaces;
using ToyRobot.Core.Models;
using ToyRobot.Core.Services;
using Xunit;

namespace ToyRobot.Tests
{
    public class PlacementTests
    {
        [Theory]
        [InlineData(1, 2, Direction.East, true)]
        [InlineData(4, 4, Direction.East, true)]
        [InlineData(5, 6, Direction.East, false)]
        [InlineData(6, 5, Direction.East, false)]
        [InlineData(-1, 2, Direction.East, false)]
        [InlineData(1, -2, Direction.East, false)]
        public void Is_Placed_On_Board(int x, int y, Direction f, bool expected)
        {

            var board = new Board { MaxXUnits = 5, MaxYUnits = 5 };
            var robot = new Mock<IRobot>();
            var playService = new PlayService(robot.Object, board);

            var sut = playService.Place(x: x, y, f);

            sut.Should().Be(expected);
        }

        [Fact]
        public void Move_Too_South_Should_BeIgnored()
        {

            var board = new Board { MaxXUnits = 5, MaxYUnits = 5 };
            var robot = new Robot(board);
            var playService = new PlayService(robot, board);

            var isPlaced = playService.Place(x: 1, 1, Direction.South);
            isPlaced.Should().BeTrue();

            playService.SentCommand("move");
            playService.SentCommand("move");
            playService.SentCommand("move");

            var sut = playService.Report();

            sut.Should().Be("1,0,SOUTH");
        }

        [Fact]
        public void None_Placed_BeIgnored()
        {
            var board = new Board { MaxXUnits = 5, MaxYUnits = 5 };
            var robot = new Robot(board);
            var playService = new PlayService(robot, board);
            
            playService.SentCommand("move");
            playService.SentCommand("move");
            playService.SentCommand("move");

            var sut = playService.Report();

            sut.Should().Be("-1,-1,NORTH");
        }

        [Fact]
        public void Too_South_Placement_Should_BeIgnored()
        {
            var board = new Board { MaxXUnits = 5, MaxYUnits = 5 };
            var robot = new Robot(board);
            var playService = new PlayService(robot, board);
            var isPlaced = playService.Place(x: 0, -5, Direction.North);
            isPlaced.Should().BeFalse();

            playService.SentCommand("move");
            playService.SentCommand("move");
            playService.SentCommand("move");

            var sut = playService.Report();

            sut.Should().Be("-1,-1,NORTH");
        }

        [Fact]
        public void Too_North_Placement_Should_BeIgnored()
        {
            var board = new Board { MaxXUnits = 5, MaxYUnits = 5 };
            var robot = new Robot(board);
            var playService = new PlayService(robot, board);
            var isPlaced = playService.Place(x: 0, 20, Direction.North);
            isPlaced.Should().BeFalse();

            playService.SentCommand("move");
            playService.SentCommand("move");
            playService.SentCommand("move");

            var sut = playService.Report();

            sut.Should().Be("-1,-1,NORTH");
        }

    }
}
