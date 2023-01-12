using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using EKRLib;

namespace App
{
    /// <summary>
    /// Represents a class for writing
    /// transports data to the files.
    /// </summary>
    internal static class Writer
    {
        private static readonly string s_workingDir = AppContext.BaseDirectory;
        private static readonly string s_carsPath = s_workingDir + "Cars.txt";
        private static readonly string s_motorBoatsPath = s_workingDir + "MotorBoats.txt";
        private static readonly Encoding s_writeEncoding = Encoding.Unicode;

        /// <summary>
        /// Represents method for writing List with transports to the files.
        /// </summary>
        /// <param name="transports">List with classes inherited from the <see cref="Transport"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown if transports is null or any element in transports is null.</exception>
        internal static void WriteTransport([DisallowNull] List<Transport> transports)
        {
            if (transports == null)
            {
                throw new ArgumentNullException(nameof(transports));
            }

            (StringBuilder cars, StringBuilder motorBoats) = ProcessTransport(transports);
            WriteCars(cars);
            WriteMotorBoats(motorBoats);
        }

        /// <summary>
        /// Represents a method to fill StringBuilders with cars' and motorBoats' data.
        /// </summary>
        /// <param name="transports">List with classes inherited from the <see cref="Transport"/>.</param>
        /// <returns>Two StringBuilders with rows with cars' and boats' data.</returns>
        /// <exception cref="ArgumentNullException">Thrown if any element in transports is null.</exception>
        [return: NotNull]
        private static (StringBuilder, StringBuilder) ProcessTransport([DisallowNull] List<Transport> transports)
        {
            StringBuilder cars = new StringBuilder();
            StringBuilder motorBoats = new StringBuilder();

            // Быстрый проход по коллекции List при помощи спана и управляемого (безопасного) указателя.
            Span<Transport> transportsSpan = CollectionsMarshal.AsSpan(transports);
            ref Transport transpManagedPointer = ref MemoryMarshal.GetReference(transportsSpan);
            for (int i = 0; i < transportsSpan.Length; ++i)
            {
                Transport transport = Unsafe.Add(ref transpManagedPointer, i);
                if (transport == null)
                {
                    throw new ArgumentNullException(nameof(transport));
                }

                if (transport is Car)
                {
                    cars.AppendLine(transport.ToString());
                }
                else if (transport is MotorBoat)
                {
                    motorBoats.AppendLine(transport.ToString());
                }
                else
                {// Если библиотека была расширена, и были добавлены
                 // новые наследники Transport, их не надо учитывать.
                    continue;
                }
            }

            return (cars, motorBoats);
        }

        /// <summary>
        /// Represents a method to write cars' data to the file.
        /// </summary>
        /// <param name="cars"><see cref="StringBuilder"/> with cars' data.</param>
        private static void WriteCars([DisallowNull] StringBuilder cars)
        {
            if (cars == null || cars.Length == 0)
            {
                return;
            }

            try
            {
                // Если файл уже существует, данные будут дописаны в конец.
                File.AppendAllText(s_carsPath, cars.ToString(), s_writeEncoding);
                Console.WriteLine($"Информация о машинах была сохранена в\n{s_carsPath}");
            } catch
            {
                Console.WriteLine($"При попытке записать данные о машинах произошла ошибка");
            }
        }

        /// <summary>
        /// Represents a method to write motorBoats' data to the file.
        /// </summary>
        /// <param name="motorBoats"><see cref="StringBuilder"/> with motorBoats' data.</param>
        private static void WriteMotorBoats([DisallowNull] StringBuilder motorBoats)
        {
            if (motorBoats == null || motorBoats.Length == 0)
            {
                return;
            }

            try
            {
                // Если файл уже существует, данные будут дописаны в конец.
                File.AppendAllText(s_motorBoatsPath, motorBoats.ToString(), s_writeEncoding);
                Console.WriteLine($"Информация о моторных лодках была сохранена в\n{s_motorBoatsPath}");
            } catch
            {
                Console.WriteLine($"При попытке записать данные о моторных лодках произошла ошибка");
            }
        }
    }
}