using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace HerokuAppAssignment.src.utils
{
    public class Driver 
    {
        public static readonly string browserType = "chrome";
        public static readonly int implicitlyWaitTime = 30;

        private readonly IWebDriver _webDriver;

        public Driver() => this._webDriver = this.InitializeWebdriver();

        

        public IWebDriver WebDriver => this._webDriver;

        public void TearDown()
        {           
                this._webDriver.Quit();
                this._webDriver.Dispose();      
        }

        private IWebDriver InitializeWebdriver()
        {

            IWebDriver newDriver;

            switch (browserType.ToLower())
            {
                case "chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    newDriver = new ChromeDriver();
                    break;
                case "edge":
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    newDriver = new EdgeDriver();
                    break;
                default:
                    throw new ArgumentException("The browser type you provided is not supported!");
            }

            newDriver.Manage().Window.Maximize();
            newDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            return newDriver;
        }
    }
}
