using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ValidationProject.Exceptions;
using ValidationProject.Models;
using ValidationProject.Validators;
using Xunit;

namespace ValidationProject.Test.ValidatorTests
{
    
    public class PhoneValidatorTest
    {
        [Theory]
        [ClassData(typeof(ValidPhoneDataClass))]
        public void ShouldReturnTrueForValidNumber(CallConnectModel model)
        {
            var phoneValidator = new PhoneNumberValidator();
            var result = phoneValidator.Validate(model);
            Assert.True(result);
        }

        [Theory]
        [ClassData(typeof(InvalidPhoneDataClass))]
        public void ShouldThrowExceptionForInvalidNumber(CallConnectModel model)
        {
            var phoneValidator = new PhoneNumberValidator();
            Assert.Throws<InvalidPhoneNumberException>(() => phoneValidator.Validate(model));
        }
    }

    public class ValidPhoneDataClass : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new CallConnectModel() { PhoneNumber = "61458208101" } };
            yield return new object[] { new CallConnectModel() { PhoneNumber = "458208101" } };
            yield return new object[] { new CallConnectModel() { PhoneNumber = "0458208101" } };
            yield return new object[] { new CallConnectModel() { PhoneNumber = "+61458208101" } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidPhoneDataClass : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new CallConnectModel() { PhoneNumber = "58208101" } };
            yield return new object[] { new CallConnectModel() { PhoneNumber = "0" } };
            yield return new object[] { new CallConnectModel() { PhoneNumber = null } };
            yield return new object[] { new CallConnectModel() { PhoneNumber = "5.2" } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
