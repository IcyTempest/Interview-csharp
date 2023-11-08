using Microsoft.VisualBasic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace ConsoleApp1
{
    internal class Program
    {
        public enum Channels { BE, FE, QA, Urgent };
        static void Main()
        {
            try
            {
                Console.Write("Input signal: ");
                string? name = Console.ReadLine();
                if (string.IsNullOrEmpty(name) && (name?.Length ?? 0) == 0)
                {
                    Console.WriteLine("No Argument, exiting....");
                    System.Environment.Exit(1);
                }

                List<String> warning = new();
                foreach (string channel in Enum.GetNames(typeof(Channels)))
                {
                    string signal = $"[{channel}]";
                    if (name!.ToUpper().Contains(signal.ToUpper()))
                    {
                        warning.Add(channel);
                    }
                }

                bool notHasChannel = !warning.Any();
                if (notHasChannel)
                {
                    Console.WriteLine($"Did not find any signal. Exiting....");
                    System.Environment.Exit(1);
                }

                Console.WriteLine($"{Environment.NewLine}Receive channels: {Strings.Join(warning.ToArray(), ", ")}");

                Console.WriteLine($"{Environment.NewLine}Press any key to exit...");
                Console.ReadKey(true);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong...");
                System.Environment.Exit(1);
            }
        }
    }
}