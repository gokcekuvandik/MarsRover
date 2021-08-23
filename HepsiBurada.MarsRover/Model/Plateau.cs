using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HepsiBurada.MarsRover.Model
{
    public class Plateau
    {
        public Plateau()
        {
        }

        public Plateau(string input)
        {
            var values = input.Split(' ');
            MaxRowNo = Convert.ToInt32(values[0]);   //with 0
            MaxColumnNo = Convert.ToInt32(values[1]);//with 0
        }

        public bool IsValid(string input)
        {
            var valid = true;
            try
            {
                if (string.IsNullOrEmpty(input))
                    throw new Exception("Value can not be empty.");
                var values = input.Split(' ');
                if (values.Length != 2)
                    throw new Exception("Please enter 2 numeric values seperated with a space.");
                int val1;
                var isNumeric1 = int.TryParse(values[0], out val1);
                int val2;
                var isNumeric2 = int.TryParse(values[1], out val2);

                if (!isNumeric1 || !isNumeric2)
                    throw new Exception("Please enter 2 numeric values seperated with a space.");

                if (val1 < 1 || val2 < 1)
                    throw new Exception("Please enter values greater than 0.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                valid = false;
            }
            return valid;
        }

        public int MaxRowNo { get; }
        public int MaxColumnNo { get; }
    }
}
