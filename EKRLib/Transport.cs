using System.Diagnostics.CodeAnalysis;

namespace EKRLib
{
    /// <summary>
    /// Represents an abstract class for all types of transport.
    /// </summary>
    public abstract class Transport
    {
        public const int ModelStringLength = 5;
        public const uint MinEnginePower = 20U;

        private string _model = string.Empty;
        private uint _power = 0U;

        /// <summary>
        /// Initializes a new instance of the class inherited from the abstract <see cref="Transport"/>
        /// class with provided <paramref name="model"/> and <paramref name="power"/>.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="power"></param>
        /// <exception cref="TransportException">
        /// Thrown if model or power are in the incorrect format.
        /// </exception>
        public Transport([DisallowNull] string model, uint power)
        {
            Model = model;
            Power = power;
        }

        /// <summary>
        /// Represents a property with <see cref="Transport"/> model name.
        /// </summary>
        /// <exception cref="TransportException">
        /// Thrown if value is null or value length does not equal to <see cref="ModelStringLength"/>.
        /// </exception>
        [DisallowNull]
        public string Model
        {
            get => _model;
            protected set => _model =
                value?.Length == ModelStringLength ?
                value :
                throw new TransportException($"Недопустимая модель {value}");
        }

        /// <summary>
        /// Represents a property with <see cref="Transport"/> engine power.
        /// </summary>
        /// <exception cref="TransportException">
        /// Thrown if value is less then <see cref="MinEnginePower"/>.
        /// </exception>
        public uint Power
        {
            get => _power;
            protected set => _power =
                value >= MinEnginePower ?
                value :
                throw new TransportException("мощность не может быть меньше 20 л.с.");
        }

        /// <summary>
        /// Abstract method to start <see cref="Transport"/> engine.
        /// </summary>
        /// <returns>Engine's sound.</returns>
        [return: NotNull]
        public abstract string StartEngine();

        [return: NotNull]
        public override string ToString()
            => $"Model: {_model}, Power: {_power}";
    }
}
