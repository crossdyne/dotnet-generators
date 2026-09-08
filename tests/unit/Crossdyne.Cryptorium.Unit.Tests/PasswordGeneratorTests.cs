using Crossdyne.Cryptorium.Abstractions;
using Crossdyne.Cryptorium.Password;
using Xunit.Abstractions;

namespace Crossdyne.Cryptorium.Unit.Tests
{
    public class PasswordGeneratorTests(ITestOutputHelper output)
    {
        private readonly ITestOutputHelper _output = output;
        private readonly IPasswordGenerator _generator = new PasswordGenerator();

        [Fact]
        public void Generate_WithDefaultSettings_ReturnsPasswordOfCorrectLength()
        {
            var settings = PasswordGeneratorSettingsPresets.Default;

            var result = _generator.Generate(settings);

            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.Equal(settings.Length, result.Value.Length);

            _output.WriteLine($"Generated password: {result.Value}");
            _output.WriteLine($"Length: {result.Value.Length}");
        }

        [Fact]
        public void Generate_With1000Length_ReturnsCorrectPassword()
        {
            var settings = new PasswordGeneratorSettings
            {
                Length = 1_000,
                UseUppercase = true,
                UseLowercase = true,
                UseNumbers = true,
                UseSymbols = true
            };

            var startTime = DateTime.UtcNow;
            var result = _generator.Generate(settings);
            var elapsed = DateTime.UtcNow - startTime;
            
            var password = result.Value;

            _output.WriteLine($"1000 length password: {password}");
            _output.WriteLine($"Generated 1000 length password in {elapsed.TotalMilliseconds:F2}ms");

        }

        [Fact]
        public void Generate_WithNumbersOnly_ReturnsOnlyDigits()
        {
            var settings = new PasswordGeneratorSettings
            {
                Length = 10,
                UseUppercase = false,
                UseLowercase = false,
                UseNumbers = true,
                UseSymbols = false
            };

            var result = _generator.Generate(settings);
            var password = result.Value;

            Assert.All(password, c => Assert.True(char.IsDigit(c)));

            _output.WriteLine($"PIN-like password: {password}");
        }

        [Fact]
        public void Generate_MultiplePasswords_AllAreUnique()
        {
            var settings = new PasswordGeneratorSettings
            {
                Length = 16,
                UseUppercase = true,
                UseLowercase = true,
                UseNumbers = true,
                UseSymbols = true
            };

            var result = _generator.Generate(100, settings);
            var passwords = result.Value;

            Assert.Equal(100, passwords.Count);
            Assert.Equal(100, passwords.Distinct().Count());

            _output.WriteLine($"Generated {passwords.Count} unique passwords:");
            foreach (var pwd in passwords.Take(5))
            {
                _output.WriteLine($"  - {pwd}");
            }
        }

        [Fact]
        public void Generate_WithExclusiveCharacters_UsesOnlyThoseChars()
        {
            var hexChars = "0123456789ABCDEF".ToCharArray();
            var settings = new PasswordGeneratorSettings
            {
                Length = 32,
                ExclusiveCharacters = hexChars
            };

            var result = _generator.Generate(settings);
            var password = result.Value;

            Assert.All(password, c => Assert.Contains(c, hexChars));

            _output.WriteLine($"Hex password: {password}");
        }

        [Fact]
        public void Generate_WithInvalidSettings_ThrowsException()
        {
            var settings = new PasswordGeneratorSettings
            {
                Length = 0,
                UseUppercase = false,
                UseLowercase = false,
                UseNumbers = false,
                UseSymbols = false
            };

            Assert.ThrowsAny<Exception>(() => _generator.Generate(settings));

            _output.WriteLine("Exception thrown as expected for invalid settings");
        }

        [Fact]
        public void Generate_PerformanceTest_Generates1000PasswordsQuickly()
        {
            var settings = new PasswordGeneratorSettings
            {
                Length = 32,
                UseUppercase = true,
                UseLowercase = true,
                UseNumbers = true,
                UseSymbols = true
            };

            var startTime = DateTime.UtcNow;
            var result = _generator.Generate(1000, settings);
            var elapsed = DateTime.UtcNow - startTime;

            Assert.Equal(1000, result.Value.Count);

            _output.WriteLine($"Generated 1000 passwords in {elapsed.TotalMilliseconds:F2}ms");
            _output.WriteLine($"Average: {elapsed.TotalMilliseconds / 1000:F4}ms per password");
            _output.WriteLine($"Sample: {result.Value[0]}");
        }
    }
}