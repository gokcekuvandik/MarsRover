using HepsiBurada.MarsRover.Model;
using System;
using System.Linq;

namespace HepsiBurada.MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input:");
            var input = string.Empty;

            var plateauExists = false;
            var locationExists = false;
            var actionsExists = false;
            var isNewRanger = true;

            var plateau = new Plateau();
            while (!plateauExists)
            {
                input = TrimInput(Console.ReadLine());
                var validPlateau = plateau.IsValid(input);
                if (validPlateau)
                    plateau = new Plateau(input);
                plateauExists = plateau.MaxRowNo > 0 && plateau.MaxColumnNo > 0 && validPlateau;
            }

            while (isNewRanger)
            {
                Console.WriteLine("\nInput:");
                isNewRanger = false;
                var location = new Location();
                while (plateauExists && !locationExists)
                {
                    input = TrimInput(Console.ReadLine());
                    var validLocation = location.IsValid(input, plateau.MaxRowNo, plateau.MaxColumnNo);
                    if (validLocation)
                        location = new Location(input);
                    locationExists = location.RowNo >= 0 && location.ColumnNo >= 0 && validLocation;
                }

                var actions = new Actions();
                while (plateauExists && locationExists && !actionsExists)
                {
                    input = TrimInput(Console.ReadLine());
                    var validActions = actions.IsValid(input);
                    if (validActions)
                        actions = new Actions(input);
                    actionsExists = actions.Moves.Any() && validActions;
                }

                if (plateauExists && locationExists && actionsExists)
                {
                    location.Update(actions, plateau);

                    Console.WriteLine("\nOutput:");
                    Console.WriteLine($"{location.ColumnNo } {location.RowNo  } {location.Heading}\n");// 0,1,2,3,4,5

                    isNewRanger = true;
                    locationExists = actionsExists = false;
                }
            }
        }

        private static string TrimInput(string input)
        {
            input = input.Trim();
            while (input.Contains("  "))
                input = input.Replace("  ", " ");
            return input;
        }
    }
}
