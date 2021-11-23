using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowSeleniumWebDriver.Drivers;
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
            Assert.AreEqual(mensagem, text);
        }

        [AfterTestRun]
        public static void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
