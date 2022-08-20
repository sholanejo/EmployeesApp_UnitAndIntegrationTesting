using EmployeesApp.Validation;

namespace EmployeesApp.Tests.Validation
{
    public class AccountNumberValidationTests
    {
        private readonly AccountNumberValidation _validation;

        public AccountNumberValidationTests()
        {
            _validation = new AccountNumberValidation();
        }

        [Fact]
        public void IsValid_ValidAccountNumber_ReturnsTrue()
        {
            Assert.True(_validation.IsValid("123-4544537859-23"));
        }

        [Theory]
        [InlineData("1234-2345434564-34")]
        [InlineData("12-2345434564-34")]
        public void IsValid_AccountNumberFirstPartWrong_ReturnsFalse(string accountNumber)
        {
            Assert.False(_validation.IsValid(accountNumber));
        }

        [Theory]
        [InlineData("123-23234232-23")]
        [InlineData("123-2323423343322-23")]
        public void IsValid_AccountNumberMiddlePartWrong_ReturnsFalse(string accountNumber)
        {
            Assert.False(_validation.IsValid(accountNumber));
        }

        [Theory]
        [InlineData("123-1234543213-3453")]
        [InlineData("123-1234543213-3453453")]
        public void IsValid_AccountNumberLastPartWrong_ReturnsFalse(string accountNumber)
        {
            Assert.False(_validation.IsValid(accountNumber));
        }

        [Theory]
        [InlineData("123-2323453214=34")]
        [InlineData("123=2323453214-34")]
        [InlineData("123=2323453214+34")]
        public void IsValid_InvalidDelimiters_ThrowsArgumentException(string accountNumber)
        {
            Assert.Throws<ArgumentException>(() => _validation.IsValid(accountNumber));
        }
    }
}
