using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Tests
{
    [TestClass]
    public class GoogleTests
    {
        [TestMethod]
        public void GoogleSearch()
        {
            IWebDriver driver = new EdgeDriver();

            driver.Navigate().GoToUrl("https://www.google.com.br/");

            // Seleciona a caixa de pesquisa
            var searchInput = driver.FindElement(By.Name("q"));
            // Digita 'selenium' na caixa de pesquisa
            // Executa a pesquisa pressionando enter
            searchInput.SendKeys("selenium" + Keys.Enter);
            // Verifica se a url contem o parametro de pesquisa
            Assert.IsTrue(driver.Url.Contains("/search?q=selenium"));

            driver.Quit();
        }

        [TestMethod]
        public void GoogleSearchBySubmit()
        {
            IWebDriver driver = new EdgeDriver();

            driver.Navigate().GoToUrl("https://www.google.com.br/");

            var searchInput = driver.FindElement(By.Name("q"));
            searchInput.SendKeys("selenium");

            // Espera a interface atualizar e mostrar o botao de submit
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

            var submit = driver.FindElement(By.Name("btnK"));
            submit.Click();

            Assert.IsTrue(driver.Url.Contains("/search?q=selenium"));

            driver.Quit();
        }
    }
}