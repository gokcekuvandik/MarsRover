using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HepsiBurada.MarsRover.Model
{
    public class Actions
    {
        public Actions()
        {
        }

        public Actions(string input)
        {
            Moves = input.ToCharArray().Select(x => x.ToString()).ToList();
        }
        public List<string> Moves { get; set; } = new List<string>();

        public bool IsValid(string input)
        {
            var valid = true;
            try
            {
                if (string.IsNullOrEmpty(input))
                    throw new Exception("Value can not be empty.");
                var temp = input.ToCharArray().Select(x => x.ToString()).ToList();
                var validValues = ((PointingDirection[])Enum.GetValues(typeof(PointingDirection))).Select(x => x.ToString()).ToList();
                validValues.Add("M");
                if (temp.Distinct().Except(validValues).Any())
                    throw new Exception("Actions must be L, R or M.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                valid = false;
            }
            return valid;
        }
    }
}
