using Vending;
using Xunit;

namespace TestVending
{
    public class Test_GetBrand
    {
        [Theory]
        [InlineData(1, "Trocadero")]
        [InlineData(2, "Sandwich")]
        [InlineData(5, "Mariestad")]
        public void GetBrand_TestingDifferentBrand(int produktID, string expected)
        {
            // Arrange
            VendingMachine vm1 = new VendingMachine(5);


            // Act
            string actual1 = vm1.GetBrand(produktID);

            // Assert
            Assert.Equal(expected, actual1);
        }
    }
}
