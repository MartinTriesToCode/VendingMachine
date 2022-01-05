using Vending;
using Xunit;

namespace TestVending
{
    public class Test_IsSoldOut
    {
       
        [Fact]
        public void IsSoldOut_TestingIfProductIsSoldOut()
        {
            // Arrange
            VendingMachine vm10 = new VendingMachine(3);
            vm10.InsertMoney(1000);
            vm10.Purchase(1);
            vm10.Purchase(1);
            vm10.Purchase(1);
       

            bool expected = true;

            // Act
            bool actual1 = vm10.IsSoldOut(1);

            // Assert
            Assert.Equal(expected, actual1);
        }
    }
}
