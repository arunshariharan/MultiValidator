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
    public class BusinessDaysTest
    {
        [Theory]
        [ClassData(typeof(ValidBusinessDataClass))]
        public void ShouldReturnTrueForValidDays(CallConnectModel model)
        {
            var validator = new BusinessDaysValidator();
            var result = validator.Validate(model);
            Assert.True(result);
        }

        [Theory]
        [ClassData(typeof(InvalidBusinessDataClass))]
        public void ShouldThrowExceptionForInvalidDays(CallConnectModel model)
        {
            var validator = new BusinessDaysValidator();
            Assert.Throws<InvalidBusinessDaysException>(() => validator.Validate(model));
        }
    }

    public class ValidBusinessDataClass : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new CallConnectModel() { BusinessDays = new List<string> { "Sunday", "Monday", "Friday" } } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }

    public class InvalidBusinessDataClass : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new CallConnectModel() { BusinessDays = new List<string> { null, "Thursday" } } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
