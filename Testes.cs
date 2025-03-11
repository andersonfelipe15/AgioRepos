using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestProjectAgio;



namespace TestProject2
{

    public class Testes
    {
#pragma warning disable NUnit1032
        private IWebDriver driver;
#pragma warning restore NUnit1032
        private WebDriverWait _wait;

        private PageObject pageObjectAgioBlog;

        [SetUp]
        public void Setup()
        {
            // Inicializa o driver e o WebDriverWait
            driver = new ChromeDriver();
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Abre a página desejada
            driver.Navigate().GoToUrl("https://blog.agibank.com.br/#");

            // Cria uma instância da página de login
            pageObjectAgioBlog = new PageObject(driver);
        }

        [Test]
        public void TestPesquisarEmprestimoConsignado()
        {

            pageObjectAgioBlog.RealizarPesquisa(driver, "Empréstimo Consignado");

        }

        [Test]
        public void TestPesquisarEmprestimoPessoal()
        {

            pageObjectAgioBlog.RealizarPesquisa(driver, "Empréstimo Pessoal");

        }



        [TearDown]
        public void TearDown()
        {
            // Garante que o driver será fechado, mesmo em caso de falha
            driver?.Quit();
        }
    }
}