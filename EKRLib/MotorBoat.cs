using System.Diagnostics.CodeAnalysis;

namespace EKRLib
{
    /// <summary>
    /// Represents a class <see cref="MotorBoat"/> inherited from
    /// the abstract transport class <see cref="Transport"/>.
    /// </summary>
    public sealed class MotorBoat : Transport
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MotorBoat"/> class with provided <paramref name="model"/> and <paramref name="power"/>.
        /// </summary>
        /// <param name="model"><see cref="MotorBoat"/> model name.</param>
        /// <param name="power"><see cref="MotorBoat"/> engine power.</param>
        /// <exception cref="TransportException">
        /// Thrown if model or power are in the incorrect format.
        /// </exception>
        public MotorBoat([DisallowNull] string model, uint power)
            : base(model, power)
        {
        }

        /// <summary>
        /// Starts <see cref="MotorBoat"/> engine.
        /// </summary>
        /// <returns>Engine's sound.</returns>
        [return: NotNull]
        public override string StartEngine()
            => $"{Model}: Brrrbrr";

        public override string ToString()
            => "MotorBoat. " + base.ToString();
    }
}
