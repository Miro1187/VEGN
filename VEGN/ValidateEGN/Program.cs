using System;
using Common;
using Validator;

namespace ValidateEGN
{
    class Program
    {
        static void Main(string[] args)
        {
            var validator = ValidatorFactory.GetValidator();

            Console.WriteLine("Welcome!");
            bool quit = false;

            while (quit == false)
            {
                Console.WriteLine("Enter EGN to validate!(q to quit)");
                string egn = Console.ReadLine();

                if (egn == "q")
                {
                    quit = true;
                }
                else
                {
                    var result = validator.ValidateEGNFormat(egn);
                    if (result.IsValid == true)
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine(string.Format("Error: {0}", result.Error.ToString()));
                    }
                    
                }
            }
        }
    }

    public static class ValidatorFactory
    {
        public static IEGNvalidator GetValidator()
        {
            return new EGNValidator();
        }
    }
}
