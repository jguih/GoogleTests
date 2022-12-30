using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace Tests
{
    [TestClass]
    public class GoogleTests
    {
        public static IWebDriver GetDriver()
        {
            IWebDriver driver = new EdgeDriver();
            driver.Navigate().GoToUrl("https://www.google.com.br/");
            return driver;
        }

        [TestMethod]
        public void GoogleSearch()
        {
            var driver = GetDriver();

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
            var driver = GetDriver();

            var searchInput = driver.FindElement(By.Name("q"));
            searchInput.SendKeys("selenium");

            // Espera a interface atualizar e mostrar o botao de submit
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

            var submit = driver.FindElement(By.Name("btnK"));
            submit.Click();

            Assert.IsTrue(driver.Url.Contains("/search?q=selenium"));

            driver.Quit();
        }

        [TestMethod]
        public void IsVirtualKeyBoardVisible()
        {
            var driver = GetDriver();

            var kbButton = driver.FindElement(By.ClassName("Umvnrc"));
            kbButton.Click();

            // Espera ateh que o teclado esteja visivel
            var virtualKb = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(driver => driver.FindElement(By.Id("kbd")));

            Assert.IsTrue(virtualKb.Displayed);

            driver.Quit();
        }
    }
}