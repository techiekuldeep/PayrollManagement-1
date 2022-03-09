using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Moq;
using PayrollManagement;
using PayrollManagement.Services;
using Xunit;

namespace PayrollManagement.Tests
{
    public class PayeTaxRateServiceTests
    {
        private PayeTaxRateService _payeTaxRateService;
        [Theory]
        [InlineData(1)]
        [InlineData(7000)]
        [InlineData(18200)]
        public void CalculatePayeTax_Return0_WhenIncomeIsLessThan18201(int yearlySalary)
        {
            // Arrange
            var logger = Mock.Of<ILogger<MathRoundService>>();
            MathRoundService mathRoundService = new MathRoundService(logger);
            var logger2 = Mock.Of<ILogger<PayeTaxRateService>>();
            PayeTaxRateService payeTaxRateService = new PayeTaxRateService(logger2, mathRoundService);
            _payeTaxRateService = payeTaxRateService;
            // Act
            int actual = _payeTaxRateService.CalculatePayeTax(yearlySalary);
            int expected = 0;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(18201,0)]
        [InlineData(18300,2)]
        [InlineData(37000,298)]
        public void CalculatePayeTax_Return0PlusTaxRate_WhenIncomeBracketIsBetween18201And37000(int yearlySalary, int expected)
        {
            // Arrange
            var logger = Mock.Of<ILogger<MathRoundService>>();
            MathRoundService mathRoundService = new MathRoundService(logger);
            var logger2 = Mock.Of<ILogger<PayeTaxRateService>>();
            PayeTaxRateService payeTaxRateService = new PayeTaxRateService(logger2, mathRoundService);
            _payeTaxRateService = payeTaxRateService;
            // Act
            int actual = _payeTaxRateService.CalculatePayeTax(yearlySalary);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(37001,298)]
        [InlineData(60000, 921)]
        [InlineData(87000, 1652)]
        public void CalculatePayeTax_Return3572PlusTaxRate_WhenIncomeBracketIsBetween37001And87000(int yearlySalary, int expected)
        {
            // Arrange
            var logger = Mock.Of<ILogger<MathRoundService>>();
            MathRoundService mathRoundService = new MathRoundService(logger);
            var logger2 = Mock.Of<ILogger<PayeTaxRateService>>();
            PayeTaxRateService payeTaxRateService = new PayeTaxRateService(logger2, mathRoundService);
            _payeTaxRateService = payeTaxRateService;
            // Act
            int actual = _payeTaxRateService.CalculatePayeTax(yearlySalary);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(87001,1652)]
        [InlineData(120000,2669)]
        [InlineData(180000,4519)]
        public void CalculatePayeTax_Return19822PlusTaxRate_WhenIncomeBracketIsBetween87001And180000(int yearlySalary, int expected)
        {
            // Arrange
            var logger = Mock.Of<ILogger<MathRoundService>>();
            MathRoundService mathRoundService = new MathRoundService(logger);
            var logger2 = Mock.Of<ILogger<PayeTaxRateService>>();
            PayeTaxRateService payeTaxRateService = new PayeTaxRateService(logger2, mathRoundService);
            _payeTaxRateService = payeTaxRateService;
            // Act
            int actual = _payeTaxRateService.CalculatePayeTax(yearlySalary);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(180001, 4519)]
        [InlineData(330000, 10144)]
        [InlineData(int.MaxValue, 80528406)]
        public void CalculatePayeTax_Return54232PlusTaxRate_WhenIncomeBracketIsBetween180001AndIntMax(int yearlySalary, int expected)
        {
            // Arrange
            var logger = Mock.Of<ILogger<MathRoundService>>();
            MathRoundService mathRoundService = new MathRoundService(logger);
            var logger2 = Mock.Of<ILogger<PayeTaxRateService>>();
            PayeTaxRateService payeTaxRateService = new PayeTaxRateService(logger2, mathRoundService);
            _payeTaxRateService = payeTaxRateService;
            // Act
            int actual = _payeTaxRateService.CalculatePayeTax(yearlySalary);
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
