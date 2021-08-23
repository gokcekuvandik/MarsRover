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
            var isNewRover = true;

            //temp plateau object
            var plateau = new Plateau();
            while (!plateauExists)
            {
                //Reads Plateau upper limit.Removes extra spaces of input
                input = TrimInput(Console.ReadLine());
                //validates
                var validPlateau = plateau.IsValid(input);
                //if valid fills plateau object
                if (validPlateau)
                    plateau = new Plateau(input);
                //sets if plateau object is created correctly
                plateauExists = plateau.MaxRowNo > 0 && plateau.MaxColumnNo > 0 && validPlateau;
            }

            //n Rover can be inputted
            while (isNewRover)
            {
                Console.WriteLine("\nInput:");
                isNewRover = false;
                //temp start location object
                var location = new Location();
                //if plateau exists and location is absent
                while (plateauExists && !locationExists)
                {
                    //Reads Location info.Removes extra spaces of input
                    input = TrimInput(Console.ReadLine());
                    //validates
                    var validLocation = location.IsValid(input, plateau.MaxRowNo, plateau.MaxColumnNo);
                    //if valid fills location object
                    if (validLocation)
                        location = new Location(input);
                    //sets if location object is created correctly
                    locationExists = location.RowNo >= 0 && location.ColumnNo >= 0 && validLocation;
                }

                //temp actions object
                var actions = new Actions();
                //if plateau and location exists bu actiona are missing
                while (plateauExists && locationExists && !actionsExists)
                {
                    //Reads actions info.Removes extra spaces of input
                    input = TrimInput(Console.ReadLine());
                    //validates
                    var validActions = actions.IsValid(input);
                    //if valid fills actions object
                    if (validActions)
                        actions = new Actions(input);
                    //sets if location object is created correctly
                    actionsExists = actions.Moves.Any() && validActions;
                }
                //if all necessary info gathered
                if (plateauExists && locationExists && actionsExists)
                {
                    //updated the current location according to the actions
                    location.Update(actions, plateau);

                    //Displays
                    Console.WriteLine("\nOutput:");
                    Console.WriteLine($"{location.ColumnNo } {location.RowNo  } {location.Heading}\n");// 0,1,2,3,4,5

                    //Cleans
                    isNewRover = true;
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
