using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ShoppingKart;
using ShoppingKart.Repository;

namespace ShoppingKartTest
{
    [TestFixture]
    public class CheckoutShould
    {
        [TestCase("A", 5)]
        [TestCase("B", 3)]
        [TestCase("C", 2)]
        [TestCase("D", 1.5)]
        [TestCase("AAA", 13)]
        [TestCase("BB", 4.5)]
        [TestCase("AAB", 11)]
        [TestCase("ABABACADB", 28.5)]
        public void CalculateTheTotalPrice(string shopping, decimal expectedPrice)
        {
            // Arrange 
            var sut = new Checkout(new Repository());

            // Act
            var actualPrice = sut.GetTotalPrice(shopping.Select(x => x.ToString()).ToArray());

            // Assert
            Assert.That(actualPrice, Is.EqualTo(expectedPrice));
        }

        [Test]
        public void Throw_GivenTheSkuIsNotKnown()
        {
            // Arrange
            var unknownSku = "Z";
            var sut = new Checkout(new Repository());

            // Act
            void Action() => sut.GetTotalPrice(new List<string>() {unknownSku});

            // Assert
            var exception = Assert.Throws<Exception>(Action);
            Assert.That(exception.Message, Is.EqualTo($"Sku {unknownSku} does not exit."));
        }
    }
}
