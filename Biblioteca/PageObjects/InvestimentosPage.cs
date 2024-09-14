using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using PicpayPoc.Biblioteca.Global;
using static PicpayPoc.Biblioteca.Global.Begin;


namespace PicpayPoc.Biblioteca.PageObjects
{
    public class InvestimentosPage : BasePage
    {
        public AppiumElement BotaoAtivarMaisTarde()
        {
            Esperar("new UiSelector().text(\"Ativar mais tarde\")", "androidUI");
            return ProcurarElementoPorAndroidUiAutomator("new UiSelector().text(\"Ativar mais tarde\")");
        }
        public AppiumElement BotaoAgoraNao()
        {
            Esperar("new UiSelector().text(\"Agora não\")", "androidUI");
            return ProcurarElementoPorAndroidUiAutomator("new UiSelector().text(\"Agora não\")");
        }
        public AppiumElement BotaoMenuPrincipal()
        {
            return ProcurarElementoPorAndroidUiAutomator("new UiSelector().text(\"Menu\")");
        }
        public AppiumElement BotaoInvestimentos()
        {
            Esperar("new UiSelector().text(\"Investimentos\")", "androidUI");
            return ProcurarElementoPorAndroidUiAutomator("new UiSelector().text(\"Investimentos\")");
        }
        public AppiumElement BotaoInvestirMais()
        {
            Esperar("new UiSelector().text(\"Investir mais\")", "androidUI");
            return ProcurarElementoPorAndroidUiAutomator("new UiSelector().text(\"Investir mais\")");
        }

        public AppiumElement BotaoRendaFixa()
        {
            Esperar("new UiSelector().text(\"Renda fixa\")", "androidUI");
            return ProcurarElementoPorAndroidUiAutomator("new UiSelector().text(\"Renda fixa\")");
        }

        public AppiumElement BotaoFiltrar()
        {
            Esperar("new UiSelector().text(\"Filtrar\")", "androidUI");
            return ProcurarElementoPorAndroidUiAutomator("new UiSelector().text(\"Filtrar\")");
        }
        public AppiumElement BotaoFiltro()
        {
            Esperar("new UiSelector().text(\"Filtrar\")", "androidUI");
            return ProcurarElementoPorAndroidUiAutomator("new UiSelector().text(\"Filtrar\")");
        }
        public AppiumElement BotaoVoltarAoCatalogo()
        {
            Esperar("new UiSelector().text(\"Voltar ao catálogo\")", "androidUI");
            return ProcurarElementoPorAndroidUiAutomator("new UiSelector().text(\"Voltar ao catálogo\")");
        }

        public AppiumElement BotaoConferirExtratoInvestimento()
        {
            Esperar("new UiSelector().text(\"Conferir extrato de investimento\")", "androidUI");
            return ProcurarElementoPorAndroidUiAutomator("new UiSelector().text(\"Conferir extrato de investimento\")");
        }

        public AppiumElement OpcaoFiltroAteCemReais()
        {
            Esperar("new UiSelector().text(\"Até R$ 100,00\")", "androidUI");
            return ProcurarElementoPorAndroidUiAutomator("new UiSelector().text(\"Até R$ 100,00\")");
        }

        public AppiumElement OpcaoVencimentoAteSeisMeses()
        {
            Esperar("new UiSelector().text(\"Até 6 meses\")", "androidUI");
            return ProcurarElementoPorAndroidUiAutomator("new UiSelector().text(\"Até 6 meses\")");
        }

        public AppiumElement InvestimentoProduto3dias()
        {
            Esperar("new UiSelector().text(\"Produto 3 dias\")", "androidUI");
            return ProcurarElementoPorAndroidUiAutomator("new UiSelector().text(\"Produto 3 dias\")");
        }
        public AppiumElement BotaoVoltar()
        {
            Esperar("Voltar", "acessID");
            return ProcurarElementoPorAcessbilityID("Voltar");
        }
        public AppiumElement BotaoVoltarOpcoesInvestimentos()
        {
            Esperar("com.picpay.debug:id/apollo3NavbarButtonIconLeftTextId", "id");
            return ProcurarElementoPorID("com.picpay.debug:id/apollo3NavbarButtonIconLeftTextId");
        }
        public AppiumElement BotaoContinuar()
        {
            Esperar("new UiSelector().text(\"Continuar\")", "androidUI");
            return ProcurarElementoPorAndroidUiAutomator("new UiSelector().text(\"Continuar\")");
        }

        public AppiumElement BotaoOkEntendi()
        {
            Esperar("com.picpay.debug:id/textViewMessageButton","id");
            return ProcurarElementoPorID("com.picpay.debug:id/textViewMessageButton");
        }

        public AppiumElement SistemaApresentaQualPerfilEDoUsuario()
        {
            return ProcurarElementoPorID("com.picpay.debug:id/ppProductSubtitle");
        }
        public AppiumElement SistemaApresentaMensagemInvestimentoArriscado()
        {
            return ProcurarElementoPorID("com.picpay.debug:id/ppProductTitle");
        }
        public bool SistemaApresentaMensagemInvestimento()
        {
            return VerificarSeElementoExiste(MobileBy.Id("com.picpay.debug:id/ppProductTitle"));
        }
        public bool UsuarioEstaNaTealaInvestimentos()
        {
            return ProcurarElementoPorAcessibilityID("Investimentos").Text.Equals("Investimentos");
        }
        public bool UsuarioEstaComATelaInvestimentosAberta()
        {
            return VerificarSeElementoExiste(MobileBy.AccessibilityId("Investimentos"));
        }
        public bool UsuarioEstaLogado()
        {
            return VerificarSeElementoExiste(MobileBy.AndroidUIAutomator("new UiSelector().text(\"Início\")"));
        }
        public bool SistemaEfetuouBuscaPeloFiltroDesejado()
        {
            return ProcurarElementoPorAndroidUiAutomator("new UiSelector().text(\"Produto 3 dias\")").Text.Equals("Produto 3 dias");
        }
        public bool SistemaApresentaModalSaldoParaInvestir()
        {
            return ProcurarElementoPorID("com.picpay.debug:id/bsTextTitle").Text.Equals("Saldo para investir");
        }
        public bool MensagemDoModalSaldoParaInvestirEstaCorreto()
        {
            return ProcurarElementoPorID("com.picpay.debug:id/bsTextSubtitle").Text.Equals("Caso não haja saldo suficiente na sua conta de Pagamento PicPay, ao prosseguir você autoriza expressamente a transferência de valores da sua conta PicPay Invest.");
        }
        public AppiumElement Mensagem12()
        {
            return ProcurarElementoPorID("com.picpay.debug:id/ppProductSubtitle");
        }

        public AppiumElement BotaoInvestir()
        {
            Esperar("com.picpay.debug:id/textViewMessageButton","id");
            return ProcurarElementoPorID("com.picpay.debug:id/textViewMessageButton");
        }

        public AppiumElement CampoValor()
        {
            return ProcurarElementoPorID("com.picpay.debug:id/editTextMoneyEditTextValue");
        }
        public AppiumElement BotaoInfoSaldoConta()
        {
            Esperar("android.widget.ImageView", "ClassName");
            return ProcurarElementoPorClassName("android.widget.ImageView");
        }
        public AppiumElement BotaoOkEntendi2()
        {
            Esperar("com.picpay.debug:id/textViewMessageButton", "id");
            return ProcurarElementoPorID("com.picpay.debug:id/textViewMessageButton");
        }
        public AppiumElement MensagemApresentandoValor()
        {
            return ProcurarElementoPorID("com.picpay.debug:id/ppInvestFeedBackHint");
        }
        public AppiumElement ValorInvestido()
        {
            return ProcurarElementoPorID("com.picpay.debug:id/summaryValueInput");
        }
        public AppiumElement ValorUsadoDaConta()
        {
            return ProcurarElementoPorID("com.picpay.debug:id/balanceTitle");
        }
        public AppiumElement MensagemInformativa()
        {
            return ProcurarElementoPorID("com.picpay.debug:id/textDisclaimer");
        }
        public AppiumElement MensagemOrdemDeInvestimentos()
        {
            return ProcurarElementoPorID("com.picpay.debug:id/warningTextTitle");
        }
        public AppiumElement MensagemApresentadasOrdemEnviada()
        {
            return ProcurarElementoPorID("com.picpay.debug:id/textFeedbackPageTitle");
        }
        public AppiumElement DesricaoPrazoParaAparecerInvestimentoEstaCorreto()
        {
            return ProcurarElementoPorID("com.picpay.debug:id/textFeedbackPageSubtitle");
        }

        public string SaldoDisponivelParaInvestir()
        {
            return GetDriver().FindElements(By.XPath("//android.widget.TextView[@resource-id='com.picpay.debug:id/balanceValue']"))[2].Text;
        }

    }
}
