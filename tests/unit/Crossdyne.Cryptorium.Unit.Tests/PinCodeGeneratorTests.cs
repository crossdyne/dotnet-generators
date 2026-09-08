using Crossdyne.Cryptorium.Abstractions;
using Crossdyne.Cryptorium.PinCode;
using Xunit.Abstractions;

namespace Crossdyne.Cryptorium.Unit.Tests
{
    public class PinCodeGeneratorTests(ITestOutputHelper output)
    {
        private readonly ITestOutputHelper _output = output;
        private readonly IPinCodeGenerator _generator = new PinCodeGenerator();

        [Fact]
        public void Generate_SoloPinCode_ReturnsPinCodeOfCorrectLength()
        {
            var length = 6;

            var result = _generator.Generate(length);

            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.Equal(length, result.Value.Length);

            _output.WriteLine($"Generated pin code: {result.Value}");
        }

        [Fact]
        public void Generate_ThrowArgumentException_LengthLessThan4()
        {
            Assert.Throws<ArgumentException>(() => _generator.Generate(2));
        }  

        [Fact]
        public void Generate_PerformanceTest_Generates1000PinCodeQuickly()
        {
            int length = 6;

            var startTime = DateTime.UtcNow;
            var result = _generator.Generate(1000, length);
            var elapsed = DateTime.UtcNow - startTime;

            Assert.Equal(1000, result.Value.Count);

            _output.WriteLine($"Generated 1000 pin codes in {elapsed.TotalMilliseconds:F2}ms");
            _output.WriteLine($"Average: {elapsed.TotalMilliseconds / 1000:F4}ms per pin code");
            _output.WriteLine($"Sample: {result.Value[0]}");
        }
    }
}