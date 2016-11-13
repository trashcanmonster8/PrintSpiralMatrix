using System;

namespace PrintSpiral
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = GetInteger();                  //Gets integer from use
            int[,] spiral = new int[number, number];    //Initializes matrix
            int rowPosition = 0;                        //Variable for current row
            int columnPosition = 0;                     //Variable for current column
            int direction = 0;                          //Variable for direction, 0 = right, 1 = down, 2 = left, 3 = up

            for (int i = 0; i < number * number; i++)
            {
                //Assign next value to current position in matrix
                spiral[rowPosition, columnPosition] = i + 1;

                //Decide if direction to the next position needs to change
                if (direction == 0)
                {
                    if (columnPosition == number - 1)
                    {
                        direction = (direction + 1) % 4;
                    }
                    else if (spiral[rowPosition, columnPosition + 1] != 0)
                    {
                        direction = (direction + 1) % 4;
                    }
                }
                else if (direction == 1)
                {
                    if (rowPosition == number - 1)
                    {
                        direction = (direction + 1) % 4;
                    }
                    else if (spiral[rowPosition + 1, columnPosition] != 0)
                    {
                        direction = (direction + 1) % 4;
                    }
                }
                else if (direction == 2)
                {
                    if (columnPosition == 0)
                    {
                        direction = (direction + 1) % 4;
                    }
                    else if (spiral[rowPosition, columnPosition - 1] != 0)
                    {
                        direction = (direction + 1) % 4;
                    }
                }
                else if (direction == 3)
                {
                    if (rowPosition == 0)
                    {
                        direction = (direction + 1) % 4;
                    }
                    else if (spiral[rowPosition - 1, columnPosition] != 0)
                    {
                        direction = (direction + 1) % 4;
                    }
                }

                //Change the row or column position for the next iteration
                switch (direction)
                {
                    case 0:
                        columnPosition++;
                        break;
                    case 1:
                        rowPosition++;
                        break;
                    case 2:
                        columnPosition--;
                        break;
                    case 3:
                        rowPosition--;
                        break;
                    default:
                        break;
                }
            }

            
            //Print the matrix to console
            for (int j = 0; j < number; j++)
            {
                for (int k = 0; k < number; k++)
                {
                    Console.Write("{0,4}", spiral[j, k]);
                }

                Console.WriteLine();
            }
            
        }

        //Gets integer from user and validates input can be parsed
        static int GetInteger()
        {
            int number = 0;
            string input;
            bool parse = false;

            while (!parse)
            {
                Console.Write("Please enter an integer: ");
                input = Console.ReadLine();

                parse = int.TryParse(input, out number);

                if (!parse)
                {
                    Console.Write("Invalid entry. ");
                }
            }

            return number;
        }
    }
}
