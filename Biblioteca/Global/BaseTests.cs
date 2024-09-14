using OpenQA.Selenium;
using System;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.MultiTouch;
using PicpayPoc.Biblioteca.PageObjects;
using static PicpayPoc.Biblioteca.Global.Begin;
using static PicpayPoc.Biblioteca.Global.GeradorDeRelatorio;
using SeleniumExtras.WaitHelpers;

namespace PicpayPoc.Biblioteca.Global
{
    public class BaseTests
    {
        #region InstanciacaoClassesPageObject
        public LoginPage ElementoDaTelaLogin => new LoginPage();
        public InvestimentosPage ElementoDaTelaInvestimento => new InvestimentosPage();
        public GeradorDeRelatorio Gerar => new GeradorDeRelatorio();


        #endregion

        public void Scroll(string direction)
        {
            var size = GetDriver().Manage().Window.Size;

            int startX = 0;
            int endX = 0;
            int startY = 0;
            int endY = 0;

            switch (direction)
            {
                case "RIGHT":
                    startY = size.Height / 2;
                    startX = (int)(size.Width * 0.90);
                    endX = (int)(size.Width * 0.05);
                    new TouchAction(GetDriver())
                            .Press(startX, startY)
                            .Wait(200)
                            .MoveTo(endX, startY)
                            .Release()
                            .Perform();
                    break;

                case "LEFT":
                    startY = size.Height / 2;
                    startX = (int)(size.Width * 0.05);
                    endX = (int)(size.Width * 0.90);
                    new TouchAction(GetDriver())
                            .Press(startX, startY)
                            .Wait(200)
                            .MoveTo(endX, startY)
                            .Release()
                            .Perform();

                    break;

                case "UP":
                    endY = (int)(size.Height * 0.70);
                    startY = (int)(size.Height * 0.30);
                    startX = size.Width / 2;
                    new TouchAction(GetDriver())
                            .Press(startX, startY)
                            .Wait(200)
                            .MoveTo(startX, endY)
                            .Release()
                            .Perform();
                    break;


                case "DOWN":
                    startY = (int)(size.Height * 0.70);
                    endY = (int)(size.Height * 0.30);
                    startX = size.Width / 2;
                    new TouchAction(GetDriver())
                            .Press(startX, startY)
                            .Wait(200)
                            .MoveTo(startX, endY)
                            .Release()
                            .Perform();

                    break;

            }
        }
        public void PreencherCampo(AppiumElement Campo, string Valor)
        {
            Campo.SendKeys(Valor);
        }
        public void ClicarElemento(AppiumElement Elemento)
        {
            Elemento.Click();
        } 
        public void ProcurarElementoPorTexto(string TextoElemento)
        {
            AppiumElement element = GetDriver().FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView(new UiSelector().text("+ TextoElemento + "))"));
        }
        public void VerificarCondicaoVerdadeira(bool StatusDoTeste, string NomeDaVerificacao, string NomeDaEstoriaDeTeste = "", int QuantidadeDeTeste = 1)
        {
            int Verdadeiro = 0, Falso = 0;
            if (StatusDoTeste == true) { Verdadeiro = QuantidadeDeTeste; } else { Falso = QuantidadeDeTeste; }
            if (StatusDoTeste == true)
            {
                Assert.True(StatusDoTeste);
                GerarRelatorio(NomeDaVerificacao, StatusDoTeste, Verdadeiro, Falso, NomeDaEstoriaDeTeste + NumeroDaExecucao);
            }
            else { GerarRelatorio(NomeDaVerificacao, StatusDoTeste, Verdadeiro, Falso, NomeDaEstoriaDeTeste + NumeroDaExecucao); }
            CapturaTela(NomeDaVerificacao);
        }

        public bool CampoTipoTextoEstaComValorCorreto(AppiumElement Campo, string Valor)
        {
            return Campo.Text.Equals(Valor);
        }
        public static void CapturaTela(string NomeDoArquivo)
        {
            string PastaDosTeste = Path.Combine(new FileInfo(typeof(GeradorDeRelatorio).Assembly.Location).DirectoryName, "Relatorios Testes Backoffice\\Relatorio " + NomeDaEstoriaTestadaAtualmente + " " + DataDoRelatorio);

            try
            {
                Screenshot ss = ((ITakesScreenshot)GetDriver()).GetScreenshot();
                ss.SaveAsFile(PastaDosTeste + "\\" + NomeDoArquivo + ".png");

            }
            catch (Exception e)
            {
                throw;
            }

        }
    }

}
