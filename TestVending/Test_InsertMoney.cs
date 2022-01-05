using Vending;
using System;
using Xunit;


namespace TestVending
{
    public class Test_InsertMoney
    {
        [Theory]
        [InlineData(5, true)]
        [InlineData(10, true)]
        [InlineData(20, true)]
        [InlineData(50, true)]
        [InlineData(100, true)]
        [InlineData(500, true)]
        [InlineData(1000, true)]
        public void InsertMoney_TestOfValidNumbers(int money, bool expected)
        {
            // Arrange
            VendingMachine vm = new VendingMachine(10);

            // Act
            bool actual = vm.InsertMoney(money);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, false)]
        [InlineData(15, false)]
        [InlineData(35, false)]
        [InlineData(-50, false)]
        [InlineData(120, false)]
        [InlineData(654, false)]
        [InlineData(10000, false)]
        public void InsertMoney_TestOfInValidNumbers(int money, bool expected)
        {
            // Arrange
            VendingMachine vm = new VendingMachine(10);

            // Act
            bool actual = vm.InsertMoney(money);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
