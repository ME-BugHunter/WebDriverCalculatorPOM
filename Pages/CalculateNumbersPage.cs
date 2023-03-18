using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverCalculatorPOM.Pages
{
    public class CalculateNumbersPage
    {
        private WebDriver driver;
        private const string baseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";

        public CalculateNumbersPage(WebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement fieldNum1 => driver.FindElement(By.Id("number1"));
        //public IWebElement field1 { get; { return driver.FindElement(By.Id("number1")); } } same as above
        public IWebElement fieldNum2 => driver.FindElement(By.Id("number2"));
        public IWebElement resultLabel => driver.FindElement(By.Id("result"));
        public IWebElement operand => driver.FindElement(By.Id("operation"));
        public IWebElement resetBtn => driver.FindElement(By.Id("resetButton"));
        public IWebElement calcBtn => driver.FindElement(By.Id("calcButton"));

        public void Open()
        {
            driver.Navigate().GoToUrl(baseUrl);
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public bool IsPageOpen()
        {
            return driver.Url == baseUrl;
        }

        public string CalculateNumbers(string firstValue, string operation, string secondValue)
        {
            fieldNum1.SendKeys(firstValue);
            operand.SendKeys(operation);
            fieldNum2.SendKeys(secondValue);
            calcBtn.Click();

            return resultLabel.Text;
        }

        public bool IsFormEmpty()
        {
            bool empty = (fieldNum1.Text == "" && fieldNum2.Text == "");
            return empty;
        }

        public void ResetForm()
        {
            resetBtn.Click();
        }
    }
}

