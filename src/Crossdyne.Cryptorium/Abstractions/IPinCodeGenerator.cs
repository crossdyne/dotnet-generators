using Crossdyne.Cryptorium.PinCode;

namespace Crossdyne.Cryptorium.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPinCodeGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        PinCodeGenerateResult<string> Generate(int length);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        PinCodeGenerateResult<List<string>> Generate(int count, int length);
    }
}