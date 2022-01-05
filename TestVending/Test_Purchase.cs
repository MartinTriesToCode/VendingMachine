using System;
using Vending;
using Xunit;

namespace TestVending
{

    public class Test_Purchase
    {
        [Fact]
       
        public void Purchase_TestWhenCustomerIsSolvent1()
        {
            //Arrange
            VendingMachine vm1 = new VendingMachine(10);
            bool expected = true;
            
            vm1.InsertMoney(20); // Product costs 20


            // Act
            bool actual1 = vm1.Purchase(1);
          

            // Actual
            Assert.Equal(expected, actual1);
            
        }

        [Fact]
        public void Purchase_TestWhenCustomerIsSolvent2()
        {
            //Arrange
            VendingMachine vm2 = new VendingMachine(10);
            bool expected = true;

            vm2.InsertMoney(20); // Product costs 55
            vm2.InsertMoney(20);
            vm2.InsertMoney(20);

            // Act
            bool actual2 = vm2.Purchase(1);


            // Actual
            Assert.Equal(expected, actual2);

        }

        [Fact]
        public void Purchase_TestWhenCustomerIsInSolvent1()
        {
            //Arrange
            VendingMachine vm1 = new VendingMachine(10);
            bool expected = false;

            vm1.InsertMoney(20); // Product costs 55
            vm1.InsertMoney(20);
        

            // Act
            bool actual1 = vm1.Purchase(2);


            // Actual
            Assert.Equal(expected, actual1);

        }

        [Fact]
        public void Purchase_TestWhenCustomerIsInSolvent2()
        {
            //Arrange
            VendingMachine vm2 = new VendingMachine(10);
            bool expected = false;

            vm2.InsertMoney(5); // Product costs 15
            vm2.InsertMoney(5);


            // Act
            bool actual2 = vm2.Purchase(2);


            // Actual
            Assert.Equal(expected, actual2);

        }


    }
     




}
    

