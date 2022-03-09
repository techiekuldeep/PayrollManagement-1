using PayrollManagement.Services;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;

namespace PayrollManagement.Tests
{
    public class MathRoundServiceTests
    {
        private MathRoundService _mathRoundService;
        
        [Theory]
        [InlineData(0.6)]
        [InlineData(0.8)]
        public void Round_Return1_IfInputGreaterThan0Point5(double input)
        {
            // Arrange
            var logger = Mock.Of<ILogger<MathRoundService>>();
            MathRoundService mathRoundService = new MathRoundService(logger);
            _mathRoundService = mathRoundService;

            // Act
            int actual = _mathRoundService.Round(input);
            int expected = 1;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0.420)]
        [InlineData(0)]
        public void Round_Return2_IfInputSmallerThan0Point5(double input)
        {
            // Arrange
            var logger = Mock.Of<ILogger<MathRoundService>>();
            MathRoundService mathRoundService = new MathRoundService(logger);
            _mathRoundService = mathRoundService;

            // Act
            int actual = _mathRoundService.Round(input);
            int expected = 0;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
