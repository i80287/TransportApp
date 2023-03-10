using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using EKRLib;

namespace App
{
    /// <summary>
    /// Represents a class for generating random values.
    /// </summary>
    public sealed class Generator
    {
        internal const int MinListLength = 6;
        internal const int MaxListLengthExcluding = 10;
        internal const int MinPower = 10;
        internal const int MaxPowerExcluding = 100;

        private readonly Random random;

        /// <summary>
        /// Initializes a new instance of the <see cref="Random"/> class using a default seed value.
        /// </summary>
        public Generator()
            => random = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="Random"/> class, using the specified seed value.
        /// </summary>
        /// <param name="seed">
        /// A number used to calculate a starting value for the pseudo-random number sequence.
        /// </param>
        public Generator(int seed)
            => random = new Random(seed);

        /// <summary>
        /// Returns one of <see cref="Car"/> or <see cref="MotorBoat"/> classes that is selected equally likely.
        /// </summary>
        /// <returns>
        /// One of <see cref="Car"/> or <see cref="MotorBoat"/> classes inherited from the base abstract class <see cref="Transport"/>.
        /// </returns>
        /// <exception cref="TransportException">
        /// Thrown if power or modelName are in the incorrect format.
        /// </exception>
        [return: NotNull]
        public Transport GetRandomTransport([DisallowNull] string modelName, uint power)
            => random.Next(2) switch
                {
                    0 => new Car(modelName, power),
                    _ => new MotorBoat(modelName, power),
                };
        

        /// <summary>
        /// Returns a random length for the List with <see cref="Transport"/>.
        /// </summary>
        /// <returns>
        /// Random 32-bit positive integer from <see cref="MinListLength"/> to <see cref="MaxListLengthExcluding"/> excluding right border.
        /// </returns>
        public int GetRandomListLength()
            => random.Next(MinListLength, MaxListLengthExcluding);

        /// <summary>
        /// Returns a random power for the <see cref="Transport"/>.
        /// </summary>
        /// <returns>
        /// Random 32-bit unsigned integer from <see cref="MinPower"/> to <see cref="MaxPowerExcluding"/> excluding right border.
        /// </returns>
        public uint GetRandomPower()
            => (uint)random.Next(MinPower, MaxPowerExcluding);

        /// <summary>
        /// Returns string with <see cref="Transport"/> model name. THe length is the <see cref="Transport.ModelNameLength"/>
        /// </summary>
        /// <returns>Random <see cref="Transport"/> model name.</returns>
        [return: NotNull]
        public string GetRandomModelString()
        {
            // ????????????????, ?????? ?????????????????? ?? ???????????? Transport ?????????????????? ???????????????? ???????????????????? ????????????.
            // Debug.Assert ?????????? ?????????????????? ???????????????? ???????????? ?? ???????????????????? ???????????? (?????????? ??????????).
            Debug.Assert(Transport.ModelNameLength >= 0);
            char[] modelNameAsChars = new char[Transport.ModelNameLength];
            for (int i = 0; i < Transport.ModelNameLength; ++i)
            {
                modelNameAsChars[i] = random.Next(2) switch
                {
                    0 => (char)random.Next('A', 'Z' + 1),
                    _ => (char)random.Next('0', '9' + 1),
                };
            }

            return new string(modelNameAsChars);
        }
    }
}
