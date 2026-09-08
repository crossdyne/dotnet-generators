namespace Crossdyne.Cryptorium.Password
{
    /// <summary>
    /// 
    /// </summary>
    public class PasswordGeneratorSettings
    {
        /// <summary>
        /// 
        /// </summary>
        public required int Length { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public bool UseUppercase { get; init; } = true;

        /// <summary>
        /// 
        /// </summary>
        public bool UseLowercase { get; init; } = true;
        
        /// <summary>
        /// 
        /// </summary>
        public bool UseNumbers { get; init; } = true;
        
        /// <summary>
        /// 
        /// </summary>
        public bool UseSymbols { get; init; } = true;

        /// <summary>
        /// Добавляет эти символы к стандартному пулу (если флаги включены).
        /// Например, добавить пробел или специфичный символ типа '§'.
        /// </summary>
        public char[]? AdditionalCharacters { get; init; }

        /// <summary>
        /// Если задано, ИГНОРИРУЕТ все флаги выше и использует ТОЛЬКО этот набор.
        /// Идеально для PIN-кодов, hex-ключей или строгих корпоративных политик.
        /// </summary>
        public char[]? ExclusiveCharacters { get; init; }
    }
}