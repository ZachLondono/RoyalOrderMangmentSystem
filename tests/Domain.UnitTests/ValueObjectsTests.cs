using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoyalOrderManager.Domain.ValueObjects;
using RoyalOrderManager.Domain.Exceptions;

namespace DomainUnitTests;

[TestClass]
public class ValueObjectsTests {
        
    [TestMethod]
    public void EqualDimensions() {
        Assert.AreEqual(
            Millimeters.FromInches(1),
            Millimeters.From(25.4));
    }

    [TestMethod]
    public void NotEqualDimensions() {
        Assert.AreNotEqual(
            Millimeters.FromInches(1),
            Millimeters.From(1));
    }

    [TestMethod]
    public void ImplicitConversionFromMM() {
        var dim = (Millimeters) 12.0;
        Assert.AreEqual(dim, Millimeters.From(12));
    }

    [TestMethod]
    public void MultiplyDimensions() {
        Millimeters a = Millimeters.From(5);
        Millimeters b = Millimeters.From(10);
        Millimeters product = a * b;
        Assert.AreEqual(product, Millimeters.From(50));
    }

    [TestMethod]
    public void DivideDimensions() {
        Millimeters a = Millimeters.From(5);
        Millimeters b = Millimeters.From(10);
        Millimeters product = a / b;
        Assert.AreEqual(product, Millimeters.From(0.5));
    }

    [TestMethod]
    public void AddDimensions() {
        Millimeters a = Millimeters.From(5);
        Millimeters b = Millimeters.From(10);
        Millimeters sum = a + b;
        Assert.AreEqual(sum, Millimeters.From(15));
    }

    [TestMethod]
    public void SubtractDimensions() {
        Millimeters a = Millimeters.From(10);
        Millimeters b = Millimeters.From(5);
        Millimeters sum = a - b;
        Assert.AreEqual(sum, Millimeters.From(5));
    }

    [TestMethod]
    public void ZeroDimension() {
        Assert.ThrowsException<BellowOrEqualToZeroMillimetersException>(() => Millimeters.From(0));
    }

    [TestMethod]
    public void NegativeDimension() {
        Assert.ThrowsException<BellowOrEqualToZeroMillimetersException>(() => Millimeters.From(-1));
    }

    [TestMethod]
    public void EqualQty() {
        Assert.AreEqual(
            Quantity.From(1),
            Quantity.From(1));
    }

    [TestMethod]
    public void NotEqualQty() {
        Assert.AreNotEqual(
            Quantity.From(1),
            Quantity.From(2));
    }

    [TestMethod]
    public void ImplicitConversion() {
        var dim = (Quantity)12;
        Assert.AreEqual(dim, Quantity.From(12));
    }

    [TestMethod]
    public void MultiplyQty() {
        Quantity a = Quantity.From(5);
        Quantity b = Quantity.From(10);
        Quantity product = a * b;
        Assert.AreEqual(product, Quantity.From(50));
    }

    [TestMethod]
    public void DivideQty() {
        Quantity a = Quantity.From(10);
        Quantity b = Quantity.From(5);
        Quantity product = a / b;
        Assert.AreEqual(product, Quantity.From(2));
    }

    [TestMethod]
    public void AddQty() {
        Quantity a = Quantity.From(5);
        Quantity b = Quantity.From(10);
        Quantity sum = a + b;
        Assert.AreEqual(sum, Quantity.From(15));
    }

    [TestMethod]
    public void SubtractQty() {
        Quantity a = Quantity.From(10);
        Quantity b = Quantity.From(5);
        Quantity sum = a - b;
        Assert.AreEqual(sum, Quantity.From(5));
    }

    [TestMethod]
    public void ZeroQty() {
        Assert.ThrowsException<BellowOrEqualToZeroQuantityException>(() => Quantity.From(0));
    }

    [TestMethod]
    public void NegativeQty() {
        Assert.ThrowsException<BellowOrEqualToZeroQuantityException>(() => Quantity.From(-1));
    }

    [TestMethod]
    public void EqualAddresses() {
        Assert.AreEqual(
            Address.From(("line1", "line2", "city", "state", "postalCode")),
            Address.From(("line1", "line2", "city", "state", "postalCode")));
    }

    [TestMethod]
    public void NotEqualAddresses() {
        Assert.AreNotEqual(
            Address.From(("line1", "line2", "city", "state", "postalCode")),
            Address.From(("postalCode", "state", "city", "line2", "line1")));
    }


}