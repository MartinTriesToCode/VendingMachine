using Vending;
using Xunit;

namespace TestVending
{
    public class Test_EnoughMoney
    {
        [Fact]
        public void EnooughMoney_TestingIfCustomerCanAffordProduct1()
        {
            // Arrange
            VendingMachine vm1 = new VendingMachine(10);
            vm1.InsertMoney(50);
            vm1.Purchase(2); // Product costs 55

            bool expected = false;
            // Act
            bool actual1 = vm1.EnoughMoney(2);

            // Assert
            Assert.Equal(expected, actual1);
        }

        [Fact]
        public void EnooughMoney_TestingIfCustomerCanAffordProduct2()
        {
            // Arrange
            VendingMachine vm2 = new VendingMachine(10);
            vm2.InsertMoney(50);
            vm2.Purchase(1); // Product costs 20

            bool expected = false;
            // Act
            bool actual1 = vm2.EnoughMoney(1);

            // Assert
            Assert.Equal(expected, actual1);
        }
    }
}
