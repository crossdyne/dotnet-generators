namespace Crossdyne.Cryptorium.Password
{
    /// <summary>
    /// 
    /// </summary>
    internal static class PasswordGeneratorSettingsPresets
    {
        public static PasswordGeneratorSettings Default = new()
        {
            Length = 32,
            UseUppercase = true,
            UseLowercase = true,
            UseNumbers = true,
            UseSymbols = true
        };
    }
}