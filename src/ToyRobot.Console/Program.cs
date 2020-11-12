using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using ToyRobot.Core.Models;
using ToyRobot.Core.Services;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = args[0];


            if (string.IsNullOrEmpty(fileName) || !File.Exists(fileName))
            {
                Console.WriteLine("Please configure commands text file.");
                return;
            }

            ExecuteCommands(fileName);

        }

        private static void ExecuteCommands(string fileName)
        {
            var commands = File.ReadAllLines(fileName);
            var board = new Board { MaxXUnits = 5, MaxYUnits = 5 };
            var robot = new Robot(board);
            var playService = new PlayService(robot,board);

            foreach (var command in commands)
            {
                if (Regex.IsMatch(command.ToLower(), "^place"))
                {
                    var commandSplit = command.Split(new[] { ' ',',' }, StringSplitOptions.RemoveEmptyEntries);

                    var isValidX = int.TryParse(commandSplit[1], out var x);
                    var isValidY = int.TryParse(commandSplit[2], out var y);
                    var f = (Direction)Enum.Parse(typeof(Direction), commandSplit[3], true);

                    if (isValidX && isValidY)
                    {
                        playService.Place(x, y, f);
                    }

                }

                else if (Regex.IsMatch(command.ToLower(), "^left") || Regex.IsMatch(command.ToLower(), "^right") || Regex.IsMatch(command.ToLower(), "^move"))
                {
                    playService.SentCommand(command);
                }

                else if (Regex.IsMatch(command.ToLower(), "^report"))
                {
                    Console.WriteLine(playService.Report());
                    Console.WriteLine();
                }

                else
                {
                    Console.WriteLine( $"command { command} is unidentified");
                }
            }
        }
    }
}
