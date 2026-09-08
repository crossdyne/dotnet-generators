using System.CodeDom.Compiler;
using Crossdyne.Cryptorium.Password;

namespace Crossdyne.Cryptorium.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPasswordGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IGenerateResult<string> Generate();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IGenerateResult<string> Generate(PasswordGeneratorSettings settings);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IGenerateResult<List<string>> Generate(int count, PasswordGeneratorSettings settings);
    }
}