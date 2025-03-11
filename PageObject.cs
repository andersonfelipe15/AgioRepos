using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectAgio
{
    public class PageObject
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        // Elementos da tela
        public IWebElement BtnPesquisar => _driver.FindElement(By.XPath("//span[@class='screen-reader-text' and text()='Pesquisar']"));
        public IWebElement TxtCampoDePesquisa => _driver.FindElement(By.Id("search-field"));
        public IWebElement BtnLinkPostEmprestimoConsignado => _driver.FindElement(By.XPath("//a[@href='https://blog.agibank.com.br/como-quitar-emprestimo-consignado-inss/']"));
        public IWebElement BtnLinkPostEmprestimoPessoal => _driver.FindElement(By.XPath("//a[@href='https://blog.agibank.com.br/o-que-e-emprestimo-pessoal/']"));

        public PageObject(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        private IWebElement EsperarElementoVisivel(By localizador)
        {
            return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(localizador));
        }


        private void ClicarElemento(IWebDriver driver, IWebElement elemento)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            Thread.Sleep(2000);
            jsExecutor.ExecuteScript("arguments[0].click();", elemento);
        }
        // Ação de inserir a pesquisa
        public void InserirBusca(IWebDriver driver, string textoDaBusca)
        {
            Thread.Sleep(6000);

            //Esperar elemento ficar visivel
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    // Espera o botão de pesquisa ficar visível e clica nele
                    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("uagb-heading-text")));
                    i = 11;
                }
                catch
                {

                }
            }


            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='screen-reader-text' and text()='Pesquisar']")));

            var btnPesuisar = BtnPesquisar;
            ClicarElemento(driver, btnPesuisar);

            // Envia o termo de pesquisa digitado
            EsperarElementoVisivel(By.Id("search-field"));
            TxtCampoDePesquisa.SendKeys(textoDaBusca);
            TxtCampoDePesquisa.SendKeys(Keys.Enter);




        }


        // Ação de clicar no botão "Entrar"
        public void ClicarNoResultadoDaBusca(string tipoEmprestimo)
        {

            //Esperar Elemento da pesquisa
            if (tipoEmprestimo.Equals("Empréstimo Pessoal"))
            {
                // Espera o link específico do post aparecer e clica nele
                EsperarElementoVisivel(By.XPath("//a[@href='https://blog.agibank.com.br/o-que-e-emprestimo-pessoal/']"));
                BtnLinkPostEmprestimoPessoal.Click();


                // Espera a página carregar completamente
                _wait.Until(driver => driver.Url.Contains("o-que-e-emprestimo-pessoal"));

                // Verifica se o elemento com o id "Emprestimo Pessoal" está presente na página
                IWebElement titulo = this._driver.FindElement(By.Id("o-que-é-empréstimo-pessoal-como-funciona-e-como-contratar-o-crédito"));
                Assert.IsNotNull(titulo, "O elemento com o ID 'emprestimo pessoal' não foi encontrado.");
            }
            else if (tipoEmprestimo.Equals("Empréstimo Consignado"))
            {

                // Espera o link específico do post aparecer e clica nele
                EsperarElementoVisivel(By.XPath("//a[@href='https://blog.agibank.com.br/como-quitar-emprestimo-consignado-inss/']"));
                BtnLinkPostEmprestimoConsignado.Click();

                // Espera a página carregar completamente
                _wait.Until(driver => driver.Url.Contains("como-quitar-emprestimo-consignado-inss"));

                // Verifica se o elemento com o id "Quitar Consignado" está presente na página
                IWebElement titulo = this._driver.FindElement(By.Id("como-quitar-empréstimo-consignado-inss"));
                Assert.IsNotNull(titulo, "O elemento com o ID 'meuElementoId' não foi encontrado.");
            }


        }

        // Método que pode ser utilizado para realizar o login completo
        public void RealizarPesquisa(IWebDriver driver, string textoDaBusca)
        {
            InserirBusca(driver, textoDaBusca);
            ClicarNoResultadoDaBusca(textoDaBusca);
        }
    }
}
