using NUnit.Framework;
using Common;
using Validator;

namespace Tests
{
    public class Tests
    {
        IEGNvalidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new EGNValidator();
        }

        [Test]
        public void ValidateEmptyEGNTest()
        {
            string EGN = "";
            validatinResult result = validator.ValidateEGNFormat(EGN);
            Assert.IsTrue(result != null);
            Assert.IsTrue(result.IsValid == false);
            Assert.IsTrue(result.Error == ValidationError.EmptyString);
        }

        [Test]
        public void ValidateTooLongEGNTest()
        {
            string EGN = "123456789123456";
            validatinResult result = validator.ValidateEGNFormat(EGN);
            Assert.IsTrue(result != null);
            Assert.IsTrue(result.IsValid == false);
            Assert.IsTrue(result.Error == ValidationError.TooLongString);
        }

        [Test]
        public void ValidateTooShortEGNTest()
        {
            string EGN = "123456";
            validatinResult result = validator.ValidateEGNFormat(EGN);
            Assert.IsTrue(result != null);
            Assert.IsTrue(result.IsValid == false);
            Assert.IsTrue(result.Error == ValidationError.TooShortString);
        }

        [Test]
        public void ValidateOnlyNumbersEGNTest()
        {
            string EGN = "123aadd456";
            validatinResult result = validator.ValidateEGNFormat(EGN);
            Assert.IsTrue(result != null);
            Assert.IsTrue(result.IsValid == false);
            Assert.IsTrue(result.Error == ValidationError.InvalidSymbols);
        }

        [Test]
        public void ValidateWrongDateEGNTest()
        {
            string EGN = "1234567891";
            validatinResult result = validator.ValidateEGNFormat(EGN);
            Assert.IsTrue(result != null);
            Assert.IsTrue(result.IsValid == false);
            Assert.IsTrue(result.Error == ValidationError.InvalidDate);
        }

        [Test]
        public void ValidateValidDateEGNTest()
        {
            string EGN = "1212317897";
            validatinResult result = validator.ValidateEGNFormat(EGN);
            Assert.IsTrue(result != null);
            Assert.IsTrue(result.IsValid == true);
            Assert.IsTrue(result.Error == ValidationError.None);
        }

        [Test]
        public void ValidateYearBefore1900EGNTest()
        {
            string EGN = "1232317891";
            validatinResult result = validator.ValidateEGNFormat(EGN);
            Assert.IsTrue(result != null);
            Assert.IsTrue(result.IsValid == true);
            Assert.IsTrue(result.Error == ValidationError.None);
        }

        [Test]
        public void ValidateYearAfter2000EGNTest()
        {
            string EGN = "1252317896";
            validatinResult result = validator.ValidateEGNFormat(EGN);
            Assert.IsTrue(result != null);
            Assert.IsTrue(result.IsValid == true);
            Assert.IsTrue(result.Error == ValidationError.None);
        }

        [Test]
        public void ValidateControlNumber2000EGNTest()
        {
            string EGN = "1252317891";
            validatinResult result = validator.ValidateEGNFormat(EGN);
            Assert.IsTrue(result != null);
            Assert.IsTrue(result.IsValid == false);
            Assert.IsTrue(result.Error == ValidationError.InvalidControlNumber);
        }
    }
}