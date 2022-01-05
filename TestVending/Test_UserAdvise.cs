using Vending;
using Xunit;

namespace TestVending
{
    public class Test_UserAdvise
    {
        [Theory]
        [InlineData(1,"Customer drinks the Trocadero")]
        [InlineData(2, "Customer eats the Sandwich")]
        
        public void UserAdvide_TestingUserAdviseOutput(int productID, string expected)
        {
            // Arrange
            VendingMachine vm1 = new VendingMachine(3);
            

            // Act
            string actual1 = vm1.UserAdvise(productID);

            // Assert
            Assert.Equal(expected, actual1);
        }
    }
}
