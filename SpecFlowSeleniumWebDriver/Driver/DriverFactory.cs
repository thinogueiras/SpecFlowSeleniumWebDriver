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
        private static WebDriver webDriver;        

        public DriverFactory(WebDriver driver)
        {
            webDriver = driver;
        }

        public static WebDriver GetDriver(Browser browser)
        {
            if (webDriver == null)
            { 
                switch (browser)
                {
                    case Browser.Chrome:
                        webDriver = new ChromeDriver();
                        var chromeOptions = new ChromeOptions();
                        break;
                    case Browser.Firefox:
                        webDriver = new FirefoxDriver();
                        break;
                    case Browser.Edge:
                        webDriver = new EdgeDriver();
                        break;
                }                
            }
            webDriver.Manage().Cookies.DeleteAllCookies();
            webDriver.Manage().Window.Maximize();
            return webDriver;
        }
    }
}
