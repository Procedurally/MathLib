using System;

namespace MathLib
{
    /// <summary>
    /// Quantize values into a given range of values
    /// </summary>
    public class Quantize
    {
        public enum QuantizerType
        {
            Clamp,
            Mod,
            Oscillate
        }

        /// <summary>
        /// Start value of the data
        /// </summary>
        public readonly float Start;

        /// <summary>
        /// End value of the data
        /// </summary>
        public readonly float End;

        /// <summary>
        /// Range of values
        /// </summary>
        public readonly float Range;

        /// <summary>
        /// Number of samples
        /// </summary>
        public readonly int Samples;

        /// <summary>
        /// Size of each sample
        /// </summary>
        public readonly float Increment;

        public readonly QuantizerType Type;

        public Quantize(float start, float end, int samples, QuantizerType type = QuantizerType.Clamp)
        {
            Start = start;
            End = end;
            Range = End - Start;
            Samples = samples;
            Increment = Range / Samples;
            Type = type;
        }

        /// <summary>
        /// Round a value to the nearest bucket
        /// </summary>
        public float Apply(float value)
        {
            return Start + QuantizeIndex(value) * Increment;
        }

        /// <summary>
        /// Get the index of the bucket containing value
        /// </summary>
        /// <returns></returns>
        public int QuantizeIndex(float value)
        {
            switch (Type)
            {
                case QuantizerType.Clamp:
                    value = Clamp(value);
                    break;
                case QuantizerType.Mod:
                    value = Mod(value);
                    break;
                case QuantizerType.Oscillate:
                    value = Oscillate(value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return (int) MathF.Round(((value - Start) / Range) * (Samples - 1));
        }

        /// <summary>
        /// Modulo a value within the range of the quantizer
        /// </summary>
        public float Mod(float value)
        {
            return Start + MathF.Mod((value - Start), Range);
        }

        /// <summary>
        /// Ocillates (Ping Pongs) a value between the start and end of the quantizer
        /// </summary>
        public float Oscillate(float value)
        {
            var state = MathF.Mod(value - Start, 2 * Range);

            if (state > Range)
                state = (2 * Range) - state;

            return Start + state;
        }

        /// <summary>
        /// Clamps a value between the start and end of the quantizer
        /// </summary>
        public float Clamp(float value)
        {
            return MathF.Clamp(value, Start, End);
        }
    }
}
