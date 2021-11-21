using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SpecFlowSeleniumWebDriver.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowSeleniumWebDriver.Drivers
{
    public class DriverFactory
    {
        private static WebDriver driver = null;        

        public static WebDriver GetDriver(Browser browser)
        {
            if (driver == null)
            { 
                switch (browser)
                {
                    case Browser.Chrome:
                        driver = new ChromeDriver();
                        var chromeOptions = new ChromeOptions();
                        break;
                    case Browser.Firefox:
                        driver = new FirefoxDriver();
                        break;
                    case Browser.Edge:
                        driver = new EdgeDriver();
                        break;
                }                
            }
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
