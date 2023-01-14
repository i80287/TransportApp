using System.Diagnostics.CodeAnalysis;

namespace EKRLib
{
    /// <summary>
    /// Represents a class <see cref="Car"/> inherited from
    /// the abstract transport class <see cref="Transport"/>.
    /// </summary>
    public sealed class Car : Transport
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Car"/> class with provided <paramref name="model"/> and <paramref name="power"/>.
        /// </summary>
        /// <param name="model"><see cref="Car"/> model name.</param>
        /// <param name="power"><see cref="Car"/> engine power.</param>
        /// <exception cref="TransportException">
        /// Thrown if model or power are in the incorrect format.
        /// </exception>
        public Car([DisallowNull] string model, uint power)
            : base(model, power)
        {
        }

        /// <summary>
        /// Starts <see cref="Car"/> engine.
        /// </summary>
        /// <returns>Engine's sound.</returns>
        [return: NotNull]
        public override string StartEngine()
            => $"{Model}: Vroom";

        public override string ToString()
            => "Car. " + base.ToString();
    }
}
