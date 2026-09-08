using Crossdyne.Cryptorium.Abstractions;
using Crossdyne.Cryptorium.Password;
using Crossdyne.Cryptorium.PinCode;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Crossdyne.Cryptorium.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCryptoGenerators(this IServiceCollection services)
        {
            services.TryAddSingleton<IPasswordGenerator, PasswordGenerator>();
            services.TryAddSingleton<IPinCodeGenerator, PinCodeGenerator>();

            return services;
        }
    }
}