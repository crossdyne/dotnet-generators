using System.Security.Cryptography;
using Crossdyne.Cryptorium.Abstractions;
using Crossdyne.Cryptorium.Resources;

namespace Crossdyne.Cryptorium.Password
{
    /// <summary>
    /// 
    /// </summary>
    internal class PasswordGenerator : IPasswordGenerator
    {
        public IGenerateResult<string> Generate() => Generate(PasswordGeneratorSettingsPresets.Default);

        public IGenerateResult<List<string>> Generate(int count, PasswordGeneratorSettings settings)
        {
            List<string> passwords = [];

            for (int i = 0; i < count; i++)
            {
                var result = Generate(settings);
                passwords.Add(result.Value);
            }

            return PasswordGenerateResult<List<string>>.Create(passwords);
        }

        public IGenerateResult<string> Generate(PasswordGeneratorSettings settings) => PasswordGenerateResult<string>.Create(CreatePassword(settings));

        private static string CreatePassword(PasswordGeneratorSettings settings)
        {
            if (settings.Length <= 0)
                throw new ArgumentException("Length must be greater than 0.", nameof(settings.Length));

            var pool = new List<char>();

            if (settings.ExclusiveCharacters is { Length: > 0 })
            {
                pool.AddRange(settings.ExclusiveCharacters);
            }
            else
            {
                if (settings.UseUppercase)  pool.AddRange(Symbols.Uppercase);
                if (settings.UseLowercase)  pool.AddRange(Symbols.Lowercase);
                if (settings.UseNumbers)    pool.AddRange(Symbols.Numbers);
                if (settings.UseSymbols)    pool.AddRange(Symbols.Special);

                if (settings.AdditionalCharacters is { Length: > 0 })
                    pool.AddRange(settings.AdditionalCharacters);
            }

            if (pool.Count == 0)
                throw new InvalidOperationException("No characters have been selected for generation.");

            char[] randomChars = RandomNumberGenerator.GetItems(pool.ToArray(), settings.Length);
            return new string(randomChars);
        }
    }
}