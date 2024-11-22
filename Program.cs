using System;
using System.Collections.Generic;
using NLog;

class Program
{
    // Initialize the NLog logger
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();

    // Dictionary to store exceptions
    private static readonly Dictionary<DateTime, string> exceptionLog = new();

    static void Main(string[] args)
    {
        Console.WriteLine("Exception Logging Example");

        try
        {
            // Simulate an exception
            Console.WriteLine("Enter a number:");
            int number = Convert.ToInt32(Console.ReadLine()); // May throw FormatException
            int result = 100 / number; // May throw DivideByZeroException
        }
        catch (Exception ex)
        {
            // Log exception using NLog
            logger.Error(ex, "An error occurred.");

            // Log exception in the dictionary
            LogExceptionInDictionary(ex);
        }

        // Display the dictionary logs
        DisplayDictionaryLogs();

        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }

    // Method to log exception in the dictionary
    private static void LogExceptionInDictionary(Exception ex)
    {
        DateTime timestamp = DateTime.Now; // Current timestamp
        string errorMessage = ex.Message; // Exception message

        // Add to the dictionary
        exceptionLog[timestamp] = errorMessage;

        Console.WriteLine($"Logged exception in dictionary: {timestamp} - {errorMessage}");
    }

    // Method to display the logged dictionary entries
    private static void DisplayDictionaryLogs()
    {
        Console.WriteLine("\nLogged Exceptions (in Dictionary):");
        foreach (var entry in exceptionLog)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }
}
