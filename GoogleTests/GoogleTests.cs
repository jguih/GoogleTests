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
        public void SearchSubmitByEnter()
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
        public void SearchSubmitByButton()
        {
            var searchInput = driver.FindElement(By.Name("q"));
            searchInput.SendKeys("selenium");

            // Espera a div que contem o botao 'Pesquisa Google' ficar visivel
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(driver => driver.FindElement(By.ClassName("lJ9FBc")).Displayed);

            // Seleciona os botoes 'Pesquisa Google' e 'Estou com sorte' a partir de uma div
            var btns = driver.FindElements(By.CssSelector(".lJ9FBc input"));

            foreach (IWebElement e in btns)
            {
                if (e.GetAttribute("value") == "Pesquisa Google")
                {
                    e.Click();
                    break;
                }
            }

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

        [TestMethod]
        public void Doodles()
        {
            // Seleciona os botoes 'Pesquisa Google' e 'Estou com sorte' a partir de uma div
            var btns = driver.FindElements(By.CssSelector(".FPdoLc.lJ9FBc input"));
            
            foreach(IWebElement e in btns) { 
                if(e.GetAttribute("value") == "Estou com sorte")
                {
                    e.Click();
                    break;
                }
            }

            Assert.IsTrue(driver.Url == "https://www.google.com/doodles");
        }
    }
}