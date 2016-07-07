using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tests
{
    [TestClass()]
    public class PagingTests
    {
        [TestMethod()]
        public void three_continuous_number_as_a_part_add_cost()
        {
            //Arrange
            var costSum = new PagingSum().GetCost();


            //Act
            var expected = "6,15,24,21";
            var actual = costSum;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void three_continuous_number_as_a_part_add_cost_1()
        {
            //Arrange
            var products = new PagingSum().GetProducts().ToList();
            var cost = products.Select(p => p.Cost).ToList();
            var pageCount = 3;
            var costSum = new PagingSum().GetSum(cost, pageCount);

            //Act
            //var expected = new int[] {6, 15, 24, 21};
            var expected = new List<decimal>() { 6, 15, 24, 21 };
            var actual = costSum;

            //Assert
            //Assert.AreEqual(expected, actual);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void four_continuous_number_as_a_part_add_revenue()
        {
            //Arrange
            var revenueSum = new PagingSum().GetRevenue();


            //Act
            var expected = "50,66,60";
            var actual = revenueSum;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void four_continuous_number_as_a_part_add_revenue_1()
        {
            //Arrange
            var products = new PagingSum().GetProducts().ToList();
            var revenue = products.Select(p => p.Revenue).ToList();
            var pageCount = 4;
            var revenueSum = new PagingSum().GetSum(revenue, pageCount);

            //Act
            //var expected = new int[] {6, 15, 24, 21};
            var expected = new List<decimal>() {50, 66, 60};
            var actual = revenueSum;

            //Assert
            //Assert.AreEqual(expected, actual);
            CollectionAssert.AreEqual(expected, actual);
        }


    }
}