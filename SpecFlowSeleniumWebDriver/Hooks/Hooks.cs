using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowSeleniumWebDriver.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private WebDriver driver;        
        private const string Username = "thiagonogueira@hotmail.com.br";
        private const string Password = "625836";
        
        [BeforeScenario]
        public void CleanDatabase()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");

            driver = new ChromeDriver(chromeOptions);
            driver.Navigate().GoToUrl("https://seubarriga.wcaquino.me/");
            driver.FindElement(By.Id("email")).SendKeys(Username);
            driver.FindElement(By.Id("senha")).SendKeys(Password);
            driver.FindElement(By.TagName("button")).Click();
            driver.FindElement(By.LinkText("reset")).Click();
            driver.Quit();
        }       
    }
}
