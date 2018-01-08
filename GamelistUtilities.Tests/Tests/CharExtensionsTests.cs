using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamelistUtilities.Extensions;
using Xunit;

namespace GamelistUtilities.Tests
{
    public class CharExtensionsTests
    {
        [Theory]
        [InlineData('"', "&#x22;")]
        [InlineData('&', "&#x26;")]
        [InlineData('<', "&#x3C;")]
        [InlineData('>', "&#x3E;")]
        [InlineData('A', "&#x41;")]
        public void Test_ToHexadecimalReference(char input, string expectedValue)
        {
            var actualValue = input.ToHexadecimalReference();
            Assert.Equal(expectedValue, actualValue);
        }

        [Theory]
        [InlineData('"', "&#34;")]
        [InlineData('&', "&#38;")]
        [InlineData('<', "&#60;")]
        [InlineData('>', "&#62;")]
        [InlineData('A', "&#65;")]
        public void Test_ToDecimalReference(char input, string expectedValue)
        {
            var actualValue = input.ToDecimalReference();
            Assert.Equal(expectedValue, actualValue);
        }

        [Theory]
        [InlineData('"', "&quot;")]
        [InlineData('&', "&amp;")]
        [InlineData('<', "&lt;")]
        [InlineData('>', "&gt;")]
        [InlineData('A', "A")]
        public void Test_ToHtmlEncoded(char input, string expectedValue)
        {
            var actualValue = input.ToHtmlEncoded();
            Assert.Equal(expectedValue, actualValue);
        }
    }
}