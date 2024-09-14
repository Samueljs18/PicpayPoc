using OpenQA.Selenium.Appium;
using PicpayPoc.Biblioteca.Global;
using TechTalk.SpecFlow;
using static PicpayPoc.Biblioteca.Global.Begin;

namespace PicpayPoc.MainProject.StepDefinitions
{
    [Binding]
    public class InvestimentoStepDefinitions : BaseTests
    {
        [Given(@"Que estou logado na plataforma do Picpay")]
        public void GivenQueEstouLogadoNaPlataformaDoPicpay()
        {

            IniciarAplicativo();
            if (UsuarioNaoEstiverLogado())
            {
                if (!ElementoDaTelaInvestimento.UsuarioEstaComATelaInvestimentosAberta())
                {
                    ClicarElemento(ElementoDaTelaLogin.BotaoEntrar());
                    PreencherCampo(ElementoDaTelaLogin.CampoInformeCPF(), "14544862795");
                    PreencherCampo(ElementoDaTelaLogin.CampoSenha(), "47586900");
                    ClicarElemento(ElementoDaTelaLogin.BotaoEntrar());
                    ClicarElemento(ElementoDaTelaInvestimento.BotaoAtivarMaisTarde());
                    ClicarElemento(ElementoDaTelaInvestimento.BotaoAgoraNao());
                    ClicarElemento(ElementoDaTelaInvestimento.BotaoOkEntendi2());
                }
            }

        }
        private bool UsuarioNaoEstiverLogado()
        {
            return !ElementoDaTelaInvestimento.UsuarioEstaLogado();
        }
        private void IniciarAplicativo()
        {
            GetDriver();
        }

        [Then(@"Valido que estou na tela de Investimentos")]
        public void ThenValidoQueEstouNaTelaDeInvestimentos()
        {
            VerificarCondicaoVerdadeira(ElementoDaTelaInvestimento.UsuarioEstaNaTealaInvestimentos(), "Teste usuário se encontra na tela Investimentos", "Emprestimo Teste");
        }

        [Then(@"Valido que efetuei filtro por renda fixa")]
        public void ThenValidoQueEfetueiFiltroPorRendaFixa()
        {
            VerificarCondicaoVerdadeira(ElementoDaTelaInvestimento.SistemaEfetuouBuscaPeloFiltroDesejado(), "Teste sistema estáe fetuando filtro por produto desejado", "Emprestimo Teste");
            ClicarElemento(ElementoDaTelaInvestimento.BotaoVoltar());
            ClicarElemento(ElementoDaTelaInvestimento.BotaoVoltarOpcoesInvestimentos());
        }


        [When(@"Seleciono um investimento")]
        public void WhenSelecionoUmInvestimento()
        {
            ClicarElemento(ElementoDaTelaInvestimento.InvestimentoProduto3dias());
            Scroll("DOWN");
        }

        [Then(@"Valido mensagem informativa perfil de investidor")]
        public void ThenValidoMensagemInformativaPerfilDeInvestidor()
       {
            ClicarElemento(ElementoDaTelaInvestimento.BotaoInvestir());
            VerificarCondicaoVerdadeira(CampoTipoTextoEstaComValorCorreto(ElementoDaTelaInvestimento.SistemaApresentaMensagemInvestimentoArriscado(), "Este investimento é arriscado para o seu perfil de investidor"), "Teste sistema apresenta mensagem de investimento arriscado", "Emprestimo Teste");
            VerificarCondicaoVerdadeira(CampoTipoTextoEstaComValorCorreto(ElementoDaTelaInvestimento.SistemaApresentaQualPerfilEDoUsuario(), "Seu perfil atual é Conservador. Este produto é recomendado para o perfil Moderado."), "Teste sistema apresenta mensagem de qual perfil é recomendado", "Emprestimo Teste");
            VoltarParaTelaInvestimentos();
        }

        [When(@"Acesso tela Valor a investir")]
        public void WhenAcessoTelaValorAInvestir()
        {
            ClicarElemento(ElementoDaTelaInvestimento.BotaoInvestir());
        }
        [When(@"Acesso tela Valor Investido")]
        public void WhenAcessoTelaValorInvestido()
        {
            PreencherCampo(ElementoDaTelaInvestimento.CampoValor(), "1");
            ClicarElemento(ElementoDaTelaInvestimento.BotaoContinuar());
        }

        [When(@"Efetuo Processo de investimento")]
        public void WhenEfetuoProcessoDeInvestimento()
        {
            ClicarElemento(ElementoDaTelaInvestimento.InvestimentoProduto3dias());
            Scroll("DOWN");
            ClicarElemento(ElementoDaTelaInvestimento.BotaoInvestir());
            if (ElementoDaTelaInvestimento.SistemaApresentaMensagemInvestimento())
            {
                ClicarElemento(ElementoDaTelaInvestimento.BotaoContinuar());
                ClicarElemento(ElementoDaTelaInvestimento.BotaoInvestir());
            }
            PreencherCampo(ElementoDaTelaInvestimento.CampoValor(), "1");
            ClicarElemento(ElementoDaTelaInvestimento.BotaoContinuar());
        }

        [Then(@"Valido Investimento efetivado com sucesso")]
        public void ThenValidoInvestimentoEfetivadoComSucesso()
        {
            ClicarElemento(ElementoDaTelaInvestimento.BotaoContinuar());
            VerificarCondicaoVerdadeira(CampoTipoTextoEstaComValorCorreto(ElementoDaTelaInvestimento.MensagemOrdemDeInvestimentos(), "Enviando sua ordem de investimento"), "Teste sistema apresenta mensagem na tela de load antes de efetivar investimento", "Emprestimo Teste");
            VerificarCondicaoVerdadeira(CampoTipoTextoEstaComValorCorreto(ElementoDaTelaInvestimento.MensagemApresentadasOrdemEnviada(), "Ordem enviada"), "Teste Validar mensagem apresentada de investimento concluido com sucesso", "Emprestimo Teste");
            VerificarCondicaoVerdadeira(CampoTipoTextoEstaComValorCorreto(ElementoDaTelaInvestimento.DesricaoPrazoParaAparecerInvestimentoEstaCorreto(), "Esse investimento pode levar até 1 dia útil para aparecer em Meus investimentos. Se quiser, você pode pedir a nota de corretagem pela Central de Ajuda."), "Teste descrição prazo investimento para ser apresentado está correto", "Emprestimo Teste");
            ClicarElemento(ElementoDaTelaInvestimento.BotaoVoltarAoCatalogo());
            VoltarParaTelaInvestimentos();
        }


        [Then(@"Valido se saldo investido e igual ao saldo apresentado")]
        public void ThenValidoSeSaldoInvestidoEIgualAoSaldoApresentado()
        {
            VerificarCondicaoVerdadeira(CampoTipoTextoEstaComValorCorreto(ElementoDaTelaInvestimento.ValorInvestido(), "R$ 0,01"), "Teste Saldo apresentado investido é o mesmo que foi realmente investido", "Emprestimo Teste");
            VerificarCondicaoVerdadeira(CampoTipoTextoEstaComValorCorreto(ElementoDaTelaInvestimento.ValorUsadoDaConta(), "R$ 0,01"), "Teste Saldo usado da conta apresentado é o realmente o que foi usado da conta", "Emprestimo Teste");
            ClicarElemento(ElementoDaTelaInvestimento.BotaoVoltar());
            ClicarElemento(ElementoDaTelaInvestimento.BotaoVoltar());
            ClicarElemento(ElementoDaTelaInvestimento.BotaoVoltar());
        }

        [When(@"Efetuo Busca por Renda Fixa")]
        public void WhenEfetuoBuscaPorRendaFixa()
        {
            ClicarElemento(ElementoDaTelaInvestimento.BotaoInvestirMais());
            ClicarElemento(ElementoDaTelaInvestimento.BotaoRendaFixa());
            ClicarElemento(ElementoDaTelaInvestimento.BotaoFiltro());
            ClicarElemento(ElementoDaTelaInvestimento.OpcaoFiltroAteCemReais());
            ClicarElemento(ElementoDaTelaInvestimento.OpcaoVencimentoAteSeisMeses());
            ClicarElemento(ElementoDaTelaInvestimento.BotaoFiltrar());
        }
        [Then(@"Valido mensagem apresentada com valor investimento menor que o minimo")]
        public void ThenValidoMensagemApresentadaComValorInvestimentoMenorQueOMinimo()
        {
            PreencherCampo(ElementoDaTelaInvestimento.CampoValor(), "0");
            VerificarCondicaoVerdadeira(CampoTipoTextoEstaComValorCorreto(ElementoDaTelaInvestimento.MensagemApresentandoValor(), "Opa! Ainda falta digitar um valor"), "Teste Sistema apresenta mensagem de validação quando não preenchido campo valor de investimento", "Emprestimo Teste");
            VoltarParaTelaInvestimentos();
        }

        [Then(@"Valido info saldo da conta")]
        public void ThenValidoInfoSaldoDaConta()
        {
            if (ElementoDaTelaInvestimento.SistemaApresentaMensagemInvestimento())
            {
                ClicarElemento(ElementoDaTelaInvestimento.BotaoContinuar());
                ClicarElemento(ElementoDaTelaInvestimento.BotaoInvestir());
            }
            ClicarElemento(ElementoDaTelaInvestimento.BotaoInfoSaldoConta());
            VerificarCondicaoVerdadeira((ElementoDaTelaInvestimento.SistemaApresentaModalSaldoParaInvestir()), "Teste Sistema apresenta modal saldo para investir", "Emprestimo Teste");
            VerificarCondicaoVerdadeira((ElementoDaTelaInvestimento.MensagemDoModalSaldoParaInvestirEstaCorreto()), "Teste Sistema apresenta mensageria referente a saldo investir de forma correta", "Emprestimo Teste");
            ClicarElemento(ElementoDaTelaInvestimento.BotaoOkEntendi());
            VoltarParaTelaInvestimentos();
        }

        private void VoltarParaTelaInvestimentos()
        {
            ClicarElemento(ElementoDaTelaInvestimento.BotaoVoltar());
            ClicarElemento(ElementoDaTelaInvestimento.BotaoVoltar());
            ClicarElemento(ElementoDaTelaInvestimento.BotaoVoltar());
            ClicarElemento(ElementoDaTelaInvestimento.BotaoVoltarOpcoesInvestimentos());
        }

        [Then(@"Valido mensagem apresentada com valor investimento maior que o saldo")]
        public void ThenValidoMensagemApresentadaComValorInvestimentoMaiorQueOSaldo()
        {
            PreencherCampo(ElementoDaTelaInvestimento.CampoValor(), "900000000");
            var SaldoDaConta = ElementoDaTelaInvestimento.SaldoDisponivelParaInvestir();
            VerificarCondicaoVerdadeira(CampoTipoTextoEstaComValorCorreto(ElementoDaTelaInvestimento.MensagemApresentandoValor(), "Opa! Digite um valor até R$ " + SaldoDaConta), "Teste Validar se sistema apresenta mensagem de validação quando preenchido saldo de investimento maior que saldo da conta", "Emprestimo Teste");
            VoltarParaTelaInvestimentos();
        }


        [Given(@"Acesso a Tela De Investimentos")]
        public void GivenAcessoATelaDeInvestimentos()
        {
            if (!ElementoDaTelaInvestimento.UsuarioEstaComATelaInvestimentosAberta())
            {
                ClicarElemento(ElementoDaTelaInvestimento.BotaoMenuPrincipal());
                AppiumElement element = GetDriver().FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView(new UiSelector().text(\"Investimentos\"))"));
                ClicarElemento(ElementoDaTelaInvestimento.BotaoInvestimentos());

            }
        }
    }
}
