using OpenQA.Selenium;
using Xunit.Sdk;
using HerokuAppAssignment.src.utils;
using System.Collections.ObjectModel;

namespace HerokuAppAssignment.src.tests
{
    public class HerokuAppTests
    {

        private readonly Driver _driver;

        public HerokuAppTests()
        {
            _driver = new Driver();
        }
        
        [Fact]
        public void Test1()
        {
            _driver.WebDriver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            //used xpath for using the text() method for dynamically locating the element.
            var mainContentLinks = _driver.WebDriver.FindElement(By.CssSelector("#content ul"));
            // Link text can be change to anything else dynamically for the future.
            mainContentLinks.FindElement(By.LinkText("Add/Remove Elements")).Click();

            // locating the button and clicking 5 times.
            var addElementButton = _driver.WebDriver.FindElement(By.CssSelector(".example button"));
            for (int i = 0; i < 5; i++) addElementButton.Click();

            // locate all the elements and make sure there are 5 of them.
            var elements = _driver.WebDriver.FindElements(By.CssSelector("#elements button"));
            Assert.Equal(5, elements.Count);

            // tearing down the browser with quitting and disposing.
            _driver.TearDown();
        }

    }
}