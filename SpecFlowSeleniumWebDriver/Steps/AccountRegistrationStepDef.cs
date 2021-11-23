using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
<<<<<<< HEAD
using OpenQA.Selenium.Firefox;
using SpecFlowSeleniumWebDriver.Drivers;
using SpecFlowSeleniumWebDriver.Enums;
using System.IO;
=======
using SpecFlowSeleniumWebDriver.Drivers;
>>>>>>> 604ef3a45979a4c3858720f0cff784ff8ceb363c
using TechTalk.SpecFlow;

namespace SpecFlowSeleniumWebDriver.Steps
{
    [Binding]
    public class AccountRegistrationStepDef
    {
        private static WebDriver driver;

        private IWebElement element;
        private string text;

        private const string Username = "thiagonogueira@hotmail.com.br";
        private const string Password = "625836";

<<<<<<< HEAD
        [BeforeScenario]
        public void InitializeDriver()
        {
            driver = DriverFactory.GetDriver(Browser.Chrome);            
=======
        [BeforeFeature]
        public static void CleanDatabase()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");

            driver = new ChromeDriver(chromeOptions);
            driver.Navigate().GoToUrl("https://seubarriga.wcaquino.me/");
            driver.FindElement(By.Id("email")).SendKeys(Username);
            driver.FindElement(By.Id("senha")).SendKeys(Password);
            driver.FindElement(By.TagName("button")).Click();
            driver.FindElement(By.LinkText("reset")).Click();
        }

        [BeforeScenario]
        public void Setup()
        {
            driver = DriverFactory.GetDriver(Enums.Browser.Chrome);
>>>>>>> 604ef3a45979a4c3858720f0cff784ff8ceb363c
        }

        [Given(@"que estou logado na aplicação")]
        public void GivenQueEstouLogadoNaAplicacao()
        {
            driver.Navigate().GoToUrl("https://seubarriga.wcaquino.me/");
            driver.FindElement(By.Id("email")).SendKeys(Username);
            driver.FindElement(By.Id("senha")).SendKeys(Password);
            driver.FindElement(By.TagName("button")).Click();
            element = driver.FindElement(By.XPath("/html/body/div[1]"));
            text = element.Text;
            Assert.AreEqual("Bem vindo, Thiago Nogueira dos Santos!", text);
        }

        [When(@"cadastro a conta (.*)")]
        public void WhenCadastroAContaConta(string conta)
        {
            driver.FindElement(By.LinkText("Contas")).Click();
            driver.FindElement(By.LinkText("Adicionar")).Click();
            driver.FindElement(By.Id("nome")).SendKeys(conta);
            driver.FindElement(By.XPath("/html/body/div[2]/form/div[2]/button")).Click();
        }

        [Then(@"recebo a mensagem (.*)")]
        public void ThenReceboAMensagem(string mensagem)
        {
            element = driver.FindElement(By.XPath("/html/body/div[1]"));
            text = element.Text;
<<<<<<< HEAD
            Assert.AreEqual(mensagem, text);            
        }        
    }    
=======
            Assert.AreEqual(mensagem, text);
        }

        [AfterTestRun]
        public static void CloseBrowser()
        {
            driver.Quit();
        }
    }
>>>>>>> 604ef3a45979a4c3858720f0cff784ff8ceb363c
}
