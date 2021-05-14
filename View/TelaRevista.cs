using ClubeDoLivro.Controller;
using ClubeDoLivro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.View
{
    public class TelaRevista : TelaBase, ICadastro
    {
        private ControladorCaixa controladorCaixa;
        private ControladorRevista controladorRevista;
        private TelaCaixa telaCaixa;
        public TelaRevista(ControladorCaixa controlador, ControladorRevista ctrlRevista,TelaCaixa tlCaixa) : base("TelaRevista")
        {
            controladorCaixa = controlador;
            controladorRevista = ctrlRevista;
            telaCaixa = tlCaixa;


        }

        public void EditarRegistro()
        {
            ConfigurarTela("Editando um Registro");

            telaCaixa.VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número da revista que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuEditar = GravarRevista(idSelecionado);

            if (conseguiuEditar)
            {
                Console.WriteLine("Revista editada com sucesso ");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Erro ao editar revista, tente novamente");
                Console.ReadLine();
                EditarRegistro();
            }
        }

        public void ExcluirRegistro()
        {
            ConfigurarTela("Excluindo um Registro...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número da revista que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorRevista.ExcluirRevista(idSelecionado);

            if (conseguiuExcluir)
            {
                Console.WriteLine("Revista excluida com sucesso");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Erro ao excluir revista, tente novamente");
                Console.ReadLine();
                ExcluirRegistro();
            }
        }

        public void InserirNovoRegistro()
        {
            ConfigurarTela("Inserindo novo Registro");

            bool consegueGravar = GravarRevista(0);

            if (consegueGravar)
            {
                Console.WriteLine("Revista inserida com sucesso");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Erro ao inserir revista");
                Console.ReadLine();
                
            }
        }

        public bool VisualizarRegistros()
        {
            ConfigurarTela("Visualizando revistas...");

            string configuracaColunasTabela = "{0,-10} | {1,-17} | {2,-27} | {3,-37}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Revista[] revista = controladorRevista.SelecionarTodasAsRevistas();

            if (revista.Length == 0)
            {
                Console.WriteLine("Nehuma revista cadastrada");
                Console.ReadLine();
                return false;
            }

            for (int i = 0; i < revista.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela,
                   revista[i].id, revista[i].caixa.numero, revista[i].colecao, revista[i].numeroEdicao);
            }

            return true;
        }

       
        

        public string ObterOpcao()
        {
            Console.WriteLine("Digite 1 para inserir uma nova revista");
            Console.WriteLine("Digite 2 para visualizar revistas");
            Console.WriteLine("Digite 3 para editar revista");
            Console.WriteLine("Digite 4 para excluir revista");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        private bool GravarRevista(int id)
        {


            string resultadoValidacao;
            bool conseguiuGravar = false;



            if (telaCaixa.VisualizarRegistros())
            {


                Console.Write("Informe o numero da caixa em que a revista sera guarada: ");
                int numeroCaixa = Convert.ToInt32(Console.ReadLine());


                Console.Write("Informe o numero da edição da revista: ");
                int numeroEdicao = Convert.ToInt32(Console.ReadLine());

                Console.Write("Informe o ano da edição: ");
                DateTime anoEdicao = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Informe a coleção da revista: ");
                string colecao = Console.ReadLine();


                resultadoValidacao = controladorRevista.RegistrarRevista(id, numeroCaixa, numeroEdicao, anoEdicao, colecao);
                if (resultadoValidacao != "REVISTA_VALIDA")
                {
                    Console.WriteLine(resultadoValidacao);
                    Console.ReadLine();
                    conseguiuGravar = false;
                }

                conseguiuGravar = true;

            }
            

            return conseguiuGravar;
        }
            
        

        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Numero Caixa", "Coleção", "Numero Edição");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

       

    }
}
