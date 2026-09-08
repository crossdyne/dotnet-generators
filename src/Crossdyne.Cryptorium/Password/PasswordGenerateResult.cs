using Crossdyne.Cryptorium.Abstractions;

namespace Crossdyne.Cryptorium.Password
{
    /// <summary>
    /// 
    /// </summary>
    internal sealed record PasswordGenerateResult<TResult>(TResult Value) : IGenerateResult<TResult>
    {
        public static PasswordGenerateResult<TResult> Create(TResult value)
        {
            return new PasswordGenerateResult<TResult>(value);
        }
    }
}