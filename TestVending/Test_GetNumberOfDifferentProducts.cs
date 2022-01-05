using Vending;
using Xunit;

namespace TestVending
{
    public class Test_GetNumberOfDifferentProducts
    {
        [Fact]
        
        public void GetNumberOfDifferentProducts_TestingForNumber5()
        {
            // Arrange
            VendingMachine vm1 = new VendingMachine(2);

            int expected = 5;
     
            // Act
            int actual1 = vm1.GetNumberOfDifferentProducts();

            // Assert
            Assert.Equal(expected, actual1);
        }

       
       
    }
}
