using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverCalculatorPOM.Pages;

namespace WebDriverCalculatorPOM.Tests
{
    public class CalculateNumbersTests : BaseTest
    {
        private CalculateNumbersPage page;

        [SetUp]
        public void Setup()
        {
            this.page = new CalculateNumbersPage(driver); //driver must be protected in BaseTest in order for child class to use it
            page.Open();
        }

        [Test]
        public void Test_CalculateNumbersPage_CheckTitle ()
        {
            page.Open();
            Assert.That(page.GetPageTitle(), Is.EqualTo("Number Calculator")); 
        }

        [Test]
        public void Test_CalculateNumbersPage_SumTwoPositiveNumbers()
        {
            var actualResult = page.CalculateNumbers("12", "+", "13");

            Assert.That(actualResult, Is.EqualTo("Result: 25"));
        }

        [Test]
        public void Test_CalculateNumbersPage_MultuplyTwoPositiveNumbers()
        {
            var actualResult = page.CalculateNumbers("5", "*", "12");

            Assert.That(actualResult, Is.EqualTo("Result: 60"));
        }

        [TestCase ( "5", "*", "-10", "Result: -50")]
        [TestCase("5", "-", "-10", "Result: 15")]
        [TestCase("5", "/", "-10", "Result: -0.5")]
        [TestCase("5", "*", "absd", "Result: invalid input")]
        public void Test_CalculateNumbersPage_CalculateOperations(string firstValue, string operation, string secondValue, string result)
        {
            var actualResult = page.CalculateNumbers(firstValue, operation, secondValue);

            Assert.That(actualResult, Is.EqualTo(result));
        }

        [Test]
        public void Test_CalculateNumbersPage_CheckResetButton()
        {
            page.CalculateNumbers("6", "+", "8");
            page.ResetForm();

            Assert.That(page.IsFormEmpty(), Is.True);
        }
    }
}