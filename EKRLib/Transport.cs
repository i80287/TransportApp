using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace EKRLib
{
    /// <summary>
    /// Represents an abstract class for all types of transport.
    /// </summary>
    public abstract class Transport
    {
        public const int ModelNameLength = 5;
        public const uint MinEnginePower = 20U;

        private string _model = string.Empty;
        private uint _power = 0U;

        /// <summary>
        /// Initializes a new instance of the class inherited from this abstract class
        /// <see cref="Transport"/> with provided <paramref name="model"/> and <paramref name="power"/>.
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
        /// <remarks>
        /// This property can be initialized only once in the constructor.
        /// </remarks>
        /// <exception cref="TransportException">
        /// Thrown if value is null or value does not fit format.>.
        /// </exception>
        [DisallowNull]
        public string Model
        {
            get => _model;
            init => _model =
                VerifyModelName(value) ?
                value :
                throw new TransportException($"Недопустимая модель {value}");
        }

        /// <summary>
        /// Represents a property with <see cref="Transport"/> engine power.
        /// </summary>
        /// <remarks>
        /// This property can be initialized only once in the constructor.
        /// </remarks>
        /// <exception cref="TransportException">
        /// Thrown if value is less then <see cref="MinEnginePower"/>.
        /// </exception>
        public uint Power
        {
            get => _power;
            init => _power =
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
        
        /// <summary>
        /// Represents a static method to verify <see cref="Model"/> initialization value.
        /// </summary>
        /// <param name="modelName">Model name.</param>
        /// <returns>true if <paramref name="modelName"/> fits the format. Otherwise, false.</returns>
        private static bool VerifyModelName(string modelName)
        {
            // Если modelName == null, то условие также будет ложно.
            if (modelName?.Length != ModelNameLength)
            {
                return false;
            }

            // Проверка того, что все символы строки - цифры или заглавные латинские буквы.
            return modelName.All(symbol => ('0' <= symbol && symbol <= '9') || ('A' <= symbol && symbol <= 'Z'));
        }
    }
}
