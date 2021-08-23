using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace HepsiBurada.MarsRover.Model
{
    public class Location
    {
        public Location(string input)
        {
            var values = input.Split(' ');

            RowNo = Convert.ToInt32(values[1]);
            ColumnNo = Convert.ToInt32(values[0]);
            Heading = (CompassDirection)Enum.Parse(typeof(CompassDirection), values[2], false);
        }

        public bool IsValid(string input, int maxRowNo, int maxColumnNo)
        {
            var valid = true;
            try
            {
                if(string.IsNullOrEmpty(input))
                    throw new Exception("Value can not be empty.");
                var values = input.Split(' ');
                if (values.Length != 3)
                    throw new Exception("Please enter 2 numeric and 1 letter values seperated with a space.");
                int rowNo;
                var isNumeric1 = int.TryParse(values[0], out rowNo);
                int columnNo;
                var isNumeric2 = int.TryParse(values[1], out columnNo);
                if (!isNumeric1 || !isNumeric2)
                    throw new Exception("Please enter 2 numeric values seperated with a space.");
                var validValues = ((CompassDirection[])Enum.GetValues(typeof(CompassDirection))).Select(x => x.ToString());
                if (!validValues.Contains(values[2]))
                    throw new Exception("Heading must be N, W, S or E.");

                if (rowNo > maxRowNo)
                    throw new Exception("Row No must be less or equal to the given max row no.");
                if (columnNo > maxColumnNo)
                    throw new Exception("Column No must be less or equal to the given max column no.");
                if (rowNo < 0)
                    throw new Exception("Row No must be greater or equal to 0.");
                if (columnNo < 0)
                    throw new Exception("Column No must be greater or equal to 0.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                valid = false;
            }
            return valid;
        }

        public Location()
        {
        }

        public void Update(Actions actions, Plateau plateau)
        {
            var validValues = ((PointingDirection[])Enum.GetValues(typeof(PointingDirection))).Select(x => x.ToString());
            foreach (var action in actions.Moves)
            {
                if (validValues.Any(x => x == action))
                    UpdateHeading(action);
                else
                    UpdateLocation(plateau.MaxRowNo, plateau.MaxColumnNo);

                //Console.WriteLine($"{action}: {ColumnNo } {RowNo } {Heading}");
            }
        }

        private void UpdateLocation(int maxRowNo, int maxColumnNo)
        {
            switch (Heading)
            {
                case CompassDirection.N:
                    if (RowNo < maxRowNo)
                        RowNo++;
                    break;
                case CompassDirection.S:
                    if (RowNo > 0)
                        RowNo--;
                    break;
                case CompassDirection.E:
                    if (ColumnNo < maxColumnNo)
                        ColumnNo++;
                    break;
                case CompassDirection.W:
                    if (ColumnNo > 0)
                        ColumnNo--;
                    break;

            }
        }

        private void UpdateHeading(string val)
        {
            var pointing = (PointingDirection)Enum.Parse(typeof(PointingDirection), val, false);
            var angle = ((int)Heading + (int)pointing) < 0 ? 360 + (int)Heading + (int)pointing : (int)Heading + (int)pointing;
            Heading = (CompassDirection)(angle % 360);
        }

        public int RowNo { get; private set; }
        public int ColumnNo { get; private set; }
        public CompassDirection Heading { get; private set; }
    }
}
