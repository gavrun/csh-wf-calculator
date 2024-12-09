using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csh_wf_calculator
{
    internal class CalcEngine
    {

        // Operation Constants
        public enum Operator : int
        {
            eUnknown = 0,
            eAdd = 1,
            eSubtract = 2,
            eMultiply = 3,
            eDivide = 4,
            ePower = 5 
        }

        // Module-Level Constant
        private static double negativeConverter = -1;

        // Version output
        // TODO: Upgrade the version number to 3.0.1.1
        private static string versionInfo = "Calculator v2.0.1.1";

        // Module-level Variables

        private static double numericAnswer;
        private static string stringAnswer;

        private static Operator calcOperation;

        private static double firstNumber;
        private static double secondNumber;
        private static bool secondNumberAdded;
        private static bool decimalAdded;

        // Class Constructor
        public CalcEngine()
        {
            decimalAdded = false;
            secondNumberAdded = false;
        }

        // Returns the custom version string to the caller
        public static string GetVersion()
        {
            return (versionInfo);
        }

        // Called when the Date key is pressed
        //public static string GetDate()
        //{
        //    DateTime curDate = new DateTime();
        //    curDate = DateTime.Now;

        //    stringAnswer = String.Concat(curDate.ToShortDateString(), " ", curDate.ToLongTimeString());

        //    return (stringAnswer);
        //}

        // Called when a number key is pressed on the keypad
        public static string CalcNumber(string KeyNumber)
        {
            stringAnswer = stringAnswer + KeyNumber;
            return (stringAnswer);
        }

        // Called when an operator is selected (+, -, *, /)
        public static void CalcOperation(Operator calcOper)
        {
            if (stringAnswer != "" && !secondNumberAdded)
            {
                firstNumber = Convert.ToDouble(stringAnswer);
                calcOperation = calcOper;
                stringAnswer = "";
                decimalAdded = false;
            }
        }

        // Called when the +/- key is pressed
        public static string CalcSign()
        {
            if (stringAnswer != "")
            {
                double numHold = Convert.ToDouble(stringAnswer);
                stringAnswer = Convert.ToString(numHold * negativeConverter);
            }

            return (stringAnswer);
        }

        // Called when the . key is pressed
        public static string CalcDecimal()
        {
            if (!decimalAdded && !secondNumberAdded)
            {
                if (stringAnswer != "")
                    stringAnswer = stringAnswer + ".";
                else
                    stringAnswer = "0.";

                decimalAdded = true;
            }

            return (stringAnswer);
        }

        // Called when = is pressed
        public static string CalcEqual()
        {
            //bool validEquation = false;

            //if (stringAnswer != "")
            if (string.IsNullOrEmpty(stringAnswer) || calcOperation == Operator.eUnknown)
                return stringAnswer;

            // chain calculation
            if (!secondNumberAdded)
            {
                secondNumber = Convert.ToDouble(stringAnswer);
                secondNumberAdded = true;
            }


            switch (calcOperation)
            {
                case Operator.eUnknown:
                    //validEquation = false;
                    break;

                case Operator.eAdd:
                    numericAnswer = firstNumber + secondNumber;
                    //validEquation = true;
                    break;

                case Operator.eSubtract:
                    numericAnswer = firstNumber - secondNumber;
                    //validEquation = true;
                    break;

                case Operator.eMultiply:
                    numericAnswer = firstNumber * secondNumber;
                    //validEquation = true;
                    break;

                case Operator.eDivide:
                    if (secondNumber != 0)
                    {
                        numericAnswer = firstNumber / secondNumber;
                        //validEquation = true;
                    }
                    else
                    {
                        return "Error"; // Division by zero 
                    }
                    break;

                case Operator.ePower: 
                    numericAnswer = Math.Pow(firstNumber, secondNumber); // Power (x^N)
                    //validEquation = true;
                    break;

                default:
                    //validEquation = false;
                    //break;
                    return stringAnswer;

                    //if (validEquation)
                    //    stringAnswer = Convert.ToString(numericAnswer);
            }

            // chain calculation
            firstNumber = numericAnswer;

            stringAnswer = numericAnswer.ToString();
            //secondNumberAdded = false;

            return (stringAnswer);
        }

        // Resets the various module-level variables for the next calculation
        public static void CalcReset()
        {
            numericAnswer = 0;
            firstNumber = 0;
            secondNumber = 0;
            stringAnswer = "";
            calcOperation = Operator.eUnknown;
            decimalAdded = false;
            secondNumberAdded = false;
        }

        // Engineering Operations

        // Reciprocal (1/x)
        public static string CalcReciprocal(double number)
        {
            if (number == 0)
                return "Error"; //Division by zero

            return (1 / number).ToString();
        }

        // Square Root
        public static string CalcSquareRoot(double number)
        {
            if (number < 0)
                return "Error"; // Negative input for square root

            return Math.Sqrt(number).ToString();
        }

        // Cubic Root
        public static string CalcCubicRoot(double number)
        {
            //if (number < 0)
            //    return "Error"; // non-negative 

            if (number < 0)
                return (-Math.Pow(-(number), 1.0 / 3.0)).ToString();

            return Math.Pow(number, 1.0 / 3.0).ToString();
        }

        // Exponent of 2, sqared (x^2)
        public static string CalcSquared(double number)
        {
            return Math.Pow(number, 2).ToString();
        }

        // Power (x^N)
        //public static string CalcPower(double baseNumber, double exponent)
        //{
        //    return Math.Pow(baseNumber, exponent).ToString();
        //}

        // Factorial
        public static string CalcFactorial(double number)
        {
            if (number < 0)
                return "Error"; // Factorial is only defined for non-negative integers

            if (number != Math.Floor(number))
                return "Error"; //Factorial is only defined for integers

            if (number > 20)
                return "Error"; //Factorial is too large for calculation

            long factorial = 1;
            //double factorial = 1;

            for (int i = 1; i <= (int)number; i++)
                factorial *= i;

            return factorial.ToString();
        }
        //
        public static async Task<string> CalcFactorialAsync(double number)
        {
            return await Task.Run(() =>
            {
                // Simulate long-running operation
                System.Threading.Thread.Sleep(3000);

                if (number < 0)
                    return "Error";
                if (number != Math.Floor(number))
                    return "Error";
                if (number > 20)
                    return "Error";
                long factorial = 1;
                for (int i = 1; i <= (int)number; i++)
                    factorial *= i;
                
                string result = factorial.ToString();

                // TODO: Update UI by callback
                //updateCallback?.Invoke(result);
                return $"Factorial: {result}";
            });
        }


        // Quadratic Equation
        public static string CalcQuadEquation(double a, double b, double c)
        {
            if (a == 0)
                return "Not a quadratic equation"; // Not a quadratic equation

            double discriminant = b * b - 4 * a * c;

            if (discriminant > 0)
            {
                double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);

                return $"Roots: x1 = {Math.Round(root1, 2)}, x2 = {Math.Round(root2, 2)}";
            }
            else if (discriminant == 0)
            {
                double root = -b / (2 * a);

                return $"One root: x = {Math.Round(root, 2)}";
            }
            else
            {
                return "No real roots";
            }
        }
    }
}
