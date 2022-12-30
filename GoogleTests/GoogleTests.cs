using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace Tests
{
    [TestClass]
    public class GoogleTests
    {
        public IWebDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new EdgeDriver();
            driver.Navigate().GoToUrl("https://www.google.com.br/");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }

        [TestMethod]
        public void GoogleSearch()
        {
            // Seleciona a caixa de pesquisa
            var searchInput = driver.FindElement(By.Name("q"));
            // Digita 'selenium' na caixa de pesquisa
            // Executa a pesquisa pressionando enter
            searchInput.SendKeys("selenium" + Keys.Enter);
            // Verifica se a url contem o parametro de pesquisa
            Assert.IsTrue(driver.Url.Contains("/search?q=selenium"));
        }

        [TestMethod]
        public void GoogleSearchBySubmit()
        {
            var searchInput = driver.FindElement(By.Name("q"));
            searchInput.SendKeys("selenium");

            // Espera o botao de submit ficar visivel
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(driver => driver.FindElement(By.Name("btnK")).Displayed);

            var submit = driver.FindElement(By.Name("btnK"));
            submit.Click();

            Assert.IsTrue(driver.Url.Contains("/search?q=selenium"));
        }

        [TestMethod]
        public void IsVirtualKeyBoardVisible()
        {
            var kbButton = driver.FindElement(By.ClassName("Umvnrc"));
            kbButton.Click();

            // Espera o teclado ficar visivel
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(driver => driver.FindElement(By.Id("kbd")).Displayed);
        }

        [TestMethod]
        public void ClearButton()
        {
            var searchInput = driver.FindElement(By.Name("q"));
            searchInput.SendKeys("selenium");

            // Espera o botao que limpa a caixa de pesquisa ficar visivel
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(driver => driver.FindElement(By.CssSelector(".vOY7J.M2vV3")).Displayed);

            var clearBtn = driver.FindElement(By.CssSelector(".vOY7J.M2vV3"));
            clearBtn.Click();
            Assert.IsTrue(searchInput.Text == "");
        }
    }
}