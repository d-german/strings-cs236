using System.Text;
using NUnit.Framework;

namespace StringTests
{
    internal class Address
    {
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }

    public class InClassLabTests
    {
        private const string ExpectedValue = "12345 College Blvd, Overland Park, KS 66210";

        private readonly Address _address = new Address
        {
            City = "Overland Park",
            State = "KS",
            StreetName = "College Blvd",
            StreetNumber = "12345",
            ZipCode = "66210"
        };

        [Test]
        public void PlusOverloadOperatorTest()
        {
            var actualAddress = _address.StreetNumber +
                                " " +
                                _address.StreetName +
                                ", " +
                                _address.City +
                                ", " +
                                _address.State +
                                " " +
                                _address.ZipCode;

            Assert.AreEqual(ExpectedValue, actualAddress);
        }

        [Test]
        public void ConcatTest()
        {
            var actualAddress = string.Concat(_address.StreetNumber, " ", _address.StreetName, ", ", _address.City, ", ", _address.State, " ", _address.ZipCode);
            Assert.AreEqual(ExpectedValue, actualAddress);
        }

        [Test]
        public void FormatTest()
        {
            var actualAddress = string.Format("{0} {1}, {2}, {3} {4}", _address.StreetNumber, _address.StreetName, _address.City, _address.State, _address.ZipCode);
            Assert.AreEqual(ExpectedValue, actualAddress);
        }

        [Test]
        public void StrungBuilderTest()
        {
            var buffer = new StringBuilder("");
            var actualAddress = buffer
                .Append(_address.StreetNumber)
                .Append(" ")
                .Append(_address.StreetName)
                .Append(", ")
                .Append(_address.City)
                .Append(", ")
                .Append(_address.State)
                .Append(" ")
                .Append(_address.ZipCode);

            Assert.AreEqual(ExpectedValue, actualAddress.ToString());
        }

        [Test]
        public void InterpolationTest()
        {
            var actualAddress = $"{_address.StreetNumber} {_address.StreetName}, {_address.City}, {_address.State} {_address.ZipCode}";
            Assert.AreEqual(ExpectedValue, actualAddress);
        }
    }
}
