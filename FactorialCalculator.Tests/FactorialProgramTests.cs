using Xunit;
using Moq;
using FactorialCalculator.Interfaces;
using FactorialCalculator.Util;

namespace FactorialCalculator.Tests
{
    public class FactorialProgramTests
    {
        [Theory]
        [InlineData("5", 120)]
        [InlineData("0", 1)]
        [InlineData("abc", "Invalid input. Please enter a valid integer.")]
        public void Run_ValidInput_ReturnsExpectedOutput(string input, object expectedOutput)
        {
            // Arrange
            var mockInputReader = new Mock<IInputReader>();
            mockInputReader.Setup(x => x.ReadInput()).Returns(() =>
            {
                string value = input;
                input = string.Empty;
                return int.TryParse(value, out int number) ? number : throw new System.ArgumentException("Invalid input. Please enter a valid integer.");
            });

            var mockOutputWriter = new Mock<IOutputWriter>();
            mockOutputWriter.Setup(x => x.WriteOutput(It.IsAny<int>()))
                .Callback<int>(result =>
                {
                    Assert.Equal(expectedOutput, result);
                });

            var program = new FactorialProgram(mockInputReader.Object, mockOutputWriter.Object, new RecursiveFactorialCalculator());

            // Act
            program.Run();

            // Assert
            mockInputReader.Verify(x => x.ReadInput(), Times.Once);
            mockOutputWriter.Verify(x => x.WriteOutput(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void GetInstance_ReturnsSameInstance()
        {
            // Arrange & Act
            var instance1 = FactorialProgram.GetInstance();
            var instance2 = FactorialProgram.GetInstance();

            // Assert
            Assert.Same(instance1, instance2);
        }
    }
}
