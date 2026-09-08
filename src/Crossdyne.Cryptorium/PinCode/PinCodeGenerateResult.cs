using Crossdyne.Cryptorium.Abstractions;

namespace Crossdyne.Cryptorium.PinCode
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="Value"></param>
    public sealed record class PinCodeGenerateResult<TResult>(TResult Value) : IGenerateResult<TResult>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static PinCodeGenerateResult<TResult> Create(TResult value)
        {
            return new PinCodeGenerateResult<TResult>(value);
        }
    }
}