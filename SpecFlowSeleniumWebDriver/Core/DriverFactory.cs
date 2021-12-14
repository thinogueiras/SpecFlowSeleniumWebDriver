using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SpecFlowSeleniumWebDriver.Enums;

namespace SpecFlowSeleniumWebDriver.Drivers
{
    public class DriverFactory
    {
        private static WebDriver driver;

        private DriverFactory()
        {

        }

        public static WebDriver GetDriver()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
            }
            
            return driver;
        }

        public static WebDriver GetDriver(Browser browser, bool headless = false)
        {
            if (driver == null)
            {
                switch (browser)
                {
                    case Browser.Chrome:
                        var chromeOptions = new ChromeOptions();
                        if (headless)
                        {
                            chromeOptions.AddArgument("--headless");
                        }
                        driver = new ChromeDriver(chromeOptions);
                        break;
                    case Browser.Firefox:
                        var firefoxOptions = new FirefoxOptions();
                        if (headless)
                        {
                            firefoxOptions.AddArgument("--headless");
                        }
                        driver = new FirefoxDriver(firefoxOptions);
                        break;
                    case Browser.Edge:
                        var edgeOptions = new EdgeOptions();
                        if (headless)
                        {
                            edgeOptions.AddArgument("--headless");
                        }
                        driver = new EdgeDriver(edgeOptions);
                        break;
                }            
            }
            
            driver.Manage().Window.Maximize();
            return driver;
        }

        public static void KillDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }   
}
