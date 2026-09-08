using System.Security.Cryptography;
using Crossdyne.Cryptorium.Abstractions;
using Crossdyne.Cryptorium.Password;

namespace Crossdyne.Cryptorium.PinCode
{
    /// <summary>
    /// 
    /// </summary>
    public class PinCodeGenerator : IPinCodeGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public PinCodeGenerateResult<string> Generate(int length) => PinCodeGenerateResult<string>.Create(GeneratePinCode(length));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public PinCodeGenerateResult<List<string>> Generate(int count, int length)
        {
            List<string> pool = [];

            for (int i = 0; i < count; i++)
            {
                var result = GeneratePinCode(length);
                pool.Add(result);
            }

            return PinCodeGenerateResult<List<string>>.Create(pool);
        }

        private static string GeneratePinCode(int length)
        {
            if (length < 4)
                throw new ArgumentException("Length must be greater than 4.", nameof(length));

            char[] codes = RandomNumberGenerator.GetItems(Symbols.Numbers, length);

            return new string(codes);            
        }
    }
}