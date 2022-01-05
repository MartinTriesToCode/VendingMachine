using Vending;
using Xunit;


namespace TestVending
{
    public class Test_CheapestPrice
    {
        [Fact]
        public void CheapestPrice_TestingPricesInProducts()
        {
            // Arrange
            VendingMachine vm1 = new VendingMachine(10);
                    
            int minimumexpected = 15;
            // Act
            int actual1 = vm1.CheapestPrice();

            // Assert
            Assert.Equal(minimumexpected, actual1);
        }
    }
}
