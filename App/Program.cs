﻿using System;
using System.Collections.Generic;
using EKRLib;

namespace App
{
    /// <summary>
    /// Represents a class with program entry point and main loop logic.
    /// </summary>
    public sealed class Program
    {
        /// <summary>
        /// Represents program entry point.
        /// </summary>
        /// <param name="args">Array with arguments from the console.</param>
        private static void Main(string[] args)
            => new Program()
                .StartProgramLoop()
                .PrintExitMessage();

        /// <summary>
        /// Starts main program loop.
        /// </summary>
        /// <returns>Reference to the <see cref="Program"/> instance.</returns>
        public Program StartProgramLoop()
        {
            Generator generator = new Generator();
            do
            {
                int length = generator.GetRandomListLength();
                List<Transport> transports = new List<Transport>(length);

                while (transports.Count < length)
                {
                    Transport transport;
                    try
                    {
                        transport = generator.GetRandomTransport();
                    }
                    catch (TransportException ex)
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    transports.Add(transport);
                    Console.WriteLine(transport.StartEngine());
                }

                Writer.WriteTransport(transports);
            }
            while (AskToContinue());
            return this;
        }

        /// <summary>
        /// Asks user to continue program execution.
        /// </summary>
        /// <returns>True if execution should be continued. Otherwise, false.</returns>
        private bool AskToContinue()
        {
            Console.WriteLine("\nНажмите Escape для выхода или нажмите любую другую клавишу для продолжения.\n");
            return Console.ReadKey(true).Key != ConsoleKey.Escape;
        }
            
        /// <summary>
        /// Prints exit message.
        /// </summary>
        private void PrintExitMessage()
            => Console.WriteLine("Работа программы была завершена, благодарим за использование.");
    }
}
