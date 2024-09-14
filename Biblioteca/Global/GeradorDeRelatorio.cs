using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PicpayPoc.Biblioteca.Global.Begin;

namespace PicpayPoc.Biblioteca.Global
{
    public class GeradorDeRelatorio
    {
        public static int TotalDeTestesAprovados;
        public static string NomeDaEstoriaTestadaAtualmente;
        public static int TotalDeTesteReprovados;
        public static int CasosDeTeste => TotalDeTestesAprovados + TotalDeTesteReprovados;
        public static string DataDoRelatorio => DateTime.Today.ToString("dd/MM/yyyy").Replace("/", ".");


        public static void GerarRelatorio(string NomeDaVerificacao, bool StatusDoTeste, int TesteAprovado, int TesteReprovado, string NomeDaEstoriaNovaASerTestada = "")
        {
            if (NomeDaEstoriaTestadaAtualmente != NomeDaEstoriaNovaASerTestada && !(NomeDaEstoriaNovaASerTestada == "")) { TotalDeTestesAprovados = 0; TotalDeTesteReprovados = 0; }
            if (NomeDaEstoriaNovaASerTestada != "") { NomeDaEstoriaTestadaAtualmente = NomeDaEstoriaNovaASerTestada; }
            TotalDeTestesAprovados = TotalDeTestesAprovados + TesteAprovado;
            TotalDeTesteReprovados = TotalDeTesteReprovados + TesteReprovado;
            string CaminhoDoRelatorio = Path.Combine(new FileInfo(typeof(GeradorDeRelatorio).Assembly.Location).DirectoryName, "Relatorios Testes Backoffice\\Relatorio " + NomeDaEstoriaTestadaAtualmente + " " + DataDoRelatorio + "\\" + NomeDaEstoriaTestadaAtualmente + NumeroDaExecucao + " " + DataDoRelatorio + ".xlsx");
            string PastaDosTeste = Path.Combine(new FileInfo(typeof(GeradorDeRelatorio).Assembly.Location).DirectoryName, "Relatorios Testes Backoffice\\Relatorio " + NomeDaEstoriaTestadaAtualmente + " " + DataDoRelatorio);



            if (!Directory.Exists(PastaDosTeste))
            {
                Directory.CreateDirectory(PastaDosTeste);
            }
            if (!File.Exists(CaminhoDoRelatorio))
            {
                XLWorkbook Relatorio = new XLWorkbook();
                IXLWorksheet Planilha = Relatorio.Worksheets.Add("Planilha 1");
                CriarTituloDoRelatorio(Planilha);
                CabecalhoDoRelatorio(Planilha, NomeDaEstoriaTestadaAtualmente);
                int linha = CorpoDoRelatorio(NomeDaVerificacao, StatusDoTeste, Planilha);
                AtivarFiltro(Planilha, linha);
                CriarTabelaDeResultado(Planilha, TotalDeTestesAprovados, TotalDeTesteReprovados, CasosDeTeste);
                Relatorio.SaveAs(CaminhoDoRelatorio);
                Relatorio.Dispose();
            }
            else
            {
                XLWorkbook Relatorio = new XLWorkbook(CaminhoDoRelatorio);
                IXLWorksheet planilha = Relatorio.Worksheet(1);
                int linha = 4;
                while (true)
                {
                    string NomeDoTesteEfetuado = planilha.Cell("B" + linha.ToString()).Value.ToString();
                    if (String.IsNullOrEmpty(NomeDoTesteEfetuado))
                    {



                        planilha.Cells("B" + linha.ToString()).Value = NomeDaVerificacao;
                        if (StatusDoTeste == true) { planilha.Cell("C" + linha.ToString()).Value = "Aprovado"; }
                        else { planilha.Cell("C" + linha.ToString()).Value = "Reprovado"; }
                        planilha.Cells("D" + linha.ToString()).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        planilha.Cells("F4").Value = "Casos de Teste =" + CasosDeTeste;
                        planilha.Cells("F5").Value = "Realizado com sucesso =" + TotalDeTestesAprovados;
                        planilha.Cells("F6").Value = "Realizado com Falha =" + TotalDeTesteReprovados;
                        try
                        {
                            Relatorio.SaveAs(CaminhoDoRelatorio);
                        }
                        catch
                        {
                            Thread.Sleep(1000);
                            Relatorio.SaveAs(CaminhoDoRelatorio);
                        }
                        break;
                    }
                    linha++;
                }
                Relatorio.Dispose();
            }
        }
        private static IXLRange CriarTabelaDeResultado(IXLWorksheet Planilha, int TotalDeTestesAprovados, int TotalDeTestesReprovados, int CasosDeTeste)
        {
            // CriarTabelaDeResultado
            IXLRange range = Planilha.Range("F3");
            range.CreateTable();
            Planilha.Columns("F").Style.Font.FontSize = 14;
            Planilha.Cell("F3").Style.Font.FontColor = XLColor.Black;
            Planilha.Cell("F3").Value = "Resultado Final";
            Planilha.Cell("F4").Style.Font.FontColor = XLColor.Black;
            Planilha.Cells("F4").Value = "Casos de Teste = " + " " + CasosDeTeste;
            Planilha.Cell("F5").Style.Font.FontColor = XLColor.Green;
            Planilha.Cells("F5").Value = "Realizado com sucesso =" + " " + TotalDeTestesAprovados;
            Planilha.Cell("F6").Style.Font.FontColor = XLColor.Red;
            Planilha.Cells("F6").Value = "Realizado com Falha = " + " " + TotalDeTestesReprovados;
            return range;
        }
        private static IXLRange AtivarFiltro(IXLWorksheet Planilha, int linha)
        {
            // Crio uma tabela para ativar os filtros
            IXLRange range = Planilha.Range("B3:D" + linha.ToString());
            range.CreateTable();
            return range;
        }
        private static int CorpoDoRelatorio(string NomeDaVerificacao, bool StatusDoTeste, IXLWorksheet Planilha)
        {
            //Corpo do relatorio
            int linha = 4;
            Planilha.Column("D").Style.NumberFormat.Format = "dd/MM/yyyy HH:mm:ss";
            Planilha.Cell("B" + linha.ToString()).Value = NomeDaVerificacao;
            if (StatusDoTeste == true) { Planilha.Cell("C" + linha.ToString()).Value = "Aprovado"; }
            else { Planilha.Cell("C" + linha.ToString()).Value = "Reprovado"; }
            Planilha.Cell("D" + linha.ToString()).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            linha++;
            return linha;
        }
        private static void CriarTituloDoRelatorio(IXLWorksheet Planilha)
        {
            //Titulo do Relatorio
            Planilha.Cell("B2").Value = "Relatório de Teste";
            IXLRange range = Planilha.Range("B2:D2");
            range.Merge().Style.Font.SetBold().Font.FontSize = 20;
        }
        private static void CabecalhoDoRelatorio(IXLWorksheet Planilha, string NomeDaEstoriaDeTeste = "")
        {
            //Cabecalho do Relatorio
            FormatarCabecalho(Planilha);
            Planilha.Cell("B3").Value = NomeDaEstoriaDeTeste;
            Planilha.Cell("C3").Value = "Status";
            Planilha.Cell("D3").Value = "Horario";
        }
        private static void FormatarCabecalho(IXLWorksheet Planilha)
        {
            Planilha.Column(2).Width = 96;
            Planilha.Column(3).Width = 18;
            Planilha.Column(4).Width = 23;
            Planilha.Column(6).Width = 30;
            Planilha.Columns().Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            Planilha.Columns().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        }


    }
    }
