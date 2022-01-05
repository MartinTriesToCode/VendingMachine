using Vending;
using System;
using Xunit;

namespace TestVending
{
    public class Test_EndTransaction
    {
        [Theory]
        [InlineData(35)]
        public void EndTransaction_TestIfCustomerGetsMoneyBack1(int moneybackexpected)
        {
            // Arrange
            VendingMachine vm1 = new VendingMachine(10);
            vm1.InsertMoney(20);
            vm1.InsertMoney(20);
            vm1.InsertMoney(50);
            vm1.Purchase(2);  // Product costs 55

            // Act
            int actual1 = vm1.EndTransaction();

            // Assert
            Assert.Equal(moneybackexpected, actual1);
        }

        [Fact]
      
        public void EndTransaction_TestIfCustomerGetsMoneyBack2()
        {
            // Arrange
            VendingMachine vm2 = new VendingMachine(10);
            vm2.InsertMoney(50);
            vm2.InsertMoney(5);

            vm2.Purchase(2);  // Product costs 55
         
            int moneybackexpected = 0;
            // Act
            int actual2 = vm2.EndTransaction();

            // Assert
            Assert.Equal(moneybackexpected, actual2);
        }

        [Fact]

        public void EndTransaction_TestIfCustomerGetsMoneyBack3()
        {
            // Arrange
            VendingMachine vm2 = new VendingMachine(10);
            vm2.InsertMoney(50);
          

            vm2.Purchase(2);  // Product costs 55

            int moneybackexpected = 50;
            // Act
            int actual2 = vm2.EndTransaction();

            // Assert
            Assert.Equal(moneybackexpected, actual2);
        }
    }
}
